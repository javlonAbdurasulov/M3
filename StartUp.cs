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
                        Create(users);
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
                        Update(users);

                    }
                    break;
                case 4:
                    {
                        Delete(users);
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

        private static async Task Delete(Users users)
        {
            Console.WriteLine("Name smartfon kiriting:");
            string name = Console.ReadLine();
            await Task.Delay(10000);
            users.ProductsInStore = Smartfon.Delete(users.ProductsInStore, name);
        }

        private static async Task Update(Users users)
        {
            Console.WriteLine("Update qilsangiz -> (count 0 teglashtiriladi)");
            Console.WriteLine("Qaysi smartfonni update qilas? : ");
            string name = Console.ReadLine();
            Console.WriteLine("yangi price?: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("update run");
            await Task.Delay(10000);
            Delegates.Update.Invoke(users.ProductsInStore, name, price);
        }

        public static async Task Create(Users users)
        {
            PrintCreate();
            string name = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            decimal price = Convert.ToDecimal(Console.ReadLine());
            //chunki uzgartirish kirsa saytda xam xam userni ekranida (users.ProductsInStore) list uzgarish kerak
            Console.WriteLine("create run!");
            await Task.Delay(10000);
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
