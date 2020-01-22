using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{

    class Napoj
    {
        public string nazwa { get; set; }
        public Napoj(string name)
        {
            nazwa = name;
        }
    }

    class Dodatek
    {
        public string nazwa { get; set; }
        public bool stan { get; set; }
        public Dodatek(string name)
        {
            nazwa = name;
            stan = false;
        }
    }



    class MenuNapoj
    {
        Dictionary<int, Napoj> menu;
        private int id;
        private int chosenNapoj;
        public MenuNapoj()
        {
            id = 0;
            menu = new Dictionary<int, Napoj>();
        }

        public void Add(Napoj napoj)
        {
            menu.Add(++id, napoj);
        }
        public void Show()
        {
            Console.WriteLine("Do wybrania jest:");
            foreach (var item in menu)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value.nazwa);
            }
        }
        public void ChooseNapoj()
        {
            int x;
            do
            {
                x = Convert.ToInt32(Console.ReadLine());
                chosenNapoj = x;
            } while (x <= 0 || x > id);
        }

        public string GetNapoj()
        {
            string str = "";
            str += "Wybrano napoj ";
            str += menu[chosenNapoj].nazwa;
            return str;
        }
    }

    class MenuDodatek
    {
        Dictionary<int, Dodatek> menu;
        private int id;
        public MenuDodatek()
        {
            id = 0;
            menu = new Dictionary<int, Dodatek>();
        }

        public void Add(Dodatek dodatek)
        {
            menu.Add(++id, dodatek);
        }

        public void Show()
        {
            Console.WriteLine("Aktualny stan:");
            foreach (var item in menu)
            {
                Console.WriteLine("{0} - {1}   {2}", item.Key, item.Value.nazwa, item.Value.stan);
            }
            Console.WriteLine("Wcisnij 0, by zatwierdzic");
        }
        public void ChangeState(int x)
        {
            if (x == 0)
                return;
            if (menu[x].stan == true)
            {
                menu[x].stan = false;
            }
            else
            {
                menu[x].stan = true;
            }
        }

        public void ChangeStateTillZero()
        {
            int x;
            do
            {
                Show();
                do
                {
                    x = Convert.ToInt32(Console.ReadLine());
                } while (x < 0 || x > id);
                ChangeState(x);

            } while (x > 0 && x <= id);
        }

        public string[] GetDodatki()
        {
            string[] str = new string[id + 1];
            for (int i = 1; i <= id; i++)
            {
                if (menu[i].stan == true)
                {
                    str[i] += ", z ";
                }
                else
                {
                    str[i] += ", bez ";
                }
                str[i] += menu[i].nazwa;
            }
            return str;
        }
    }

    class Printer
    {
        private string strMain;

        public void AddStr(string str)
        {
            strMain += str;
        }

        public void AddStrArr(string[] str)
        {
            foreach (var item in str)
                strMain += item;
        }

        public void Show()
        {
            Console.WriteLine(strMain);
        }
        public Printer()
        {
            strMain = "";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            MenuNapoj menuNapoj = new MenuNapoj();
            MenuDodatek menuDodatek = new MenuDodatek();
            Printer print = new Printer();

            menuNapoj.Add(new Napoj("kawa 1"));
            menuNapoj.Add(new Napoj("kawa 2"));
            menuNapoj.Add(new Napoj("czek"));

            menuDodatek.Add(new Dodatek("cukier"));
            menuDodatek.Add(new Dodatek("mleko"));

            menuNapoj.Show();
            menuNapoj.ChooseNapoj();
            menuDodatek.ChangeStateTillZero();

            print.AddStr(menuNapoj.GetNapoj());
            print.AddStrArr(menuDodatek.GetDodatki());
            print.Show();
            Console.ReadLine();
        }
    }
}
