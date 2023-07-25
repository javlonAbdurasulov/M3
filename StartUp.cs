using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace M3_Examen
{
    public class StartUp
    {
        //public static string path = @"C:\Users\HP\Desktop\Test\test.txt";
        public static string path = @"../../../test.txt";
        public static void Start()
        {
            Users users = new Users("Javlon",path);


            //throw new MyException("Xatolini uziz tugirlang");


        Menu:
            printMenu();
            int tanlov = int.Parse(Console.ReadLine());
            switch (tanlov)
            {
                case 1:
                    {
                        menu1(users);
                    }
                    break;
                case 2:
                    {
                        Smartfon.Read(users.ProductsInStore);

                    }
                    break;
                case 3:
                    {
                        //
                        Console.WriteLine("Update qilsangiz -> (count 0 teglashtiriladi)");
                        Console.WriteLine("Qaysi smartfonni update qilas? : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("yangi price?: ");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Delegates.Update.Invoke(users.ProductsInStore, name, price);

                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Name smartfon kiriting:");
                        string name = Console.ReadLine();
                        users.ProductsInStore =  Smartfon.Delete(users.ProductsInStore, name);
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("Other");
                        Smartfon.EngKopSotilgan(users.ProductsInStore);
                        Smartfon.EngKamSotilgan5lik(users.ProductsInStore);
                        Smartfon.EngArzon(users.ProductsInStore);
                    }
                    break;


            }
            goto Menu;



        }
        public static async Task menu1(Users users)
        {
            PrintCreate();
            string name = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            decimal price = Convert.ToDecimal(Console.ReadLine());
            //chunki uzgartirish kirsa saytda xam xam userni ekranida (users.ProductsInStore) list uzgarish kerak
            await Console.Out.WriteLineAsync("create run!");
            Delegates.Create.Invoke(users.ProductsInStore, name, year, price);
        }
        public static void printMenu() 
        {
            Console.WriteLine("Menu:\n\t1-create\n\t2-read\n\t3-update\n\t4-delete\n\t5-other ");
        }
        public static void PrintCreate()
        {
            Console.WriteLine("Name Year Price$ (Count=0)");
        }
    }
}
