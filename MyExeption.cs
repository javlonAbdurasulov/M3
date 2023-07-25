using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_Examen
{
    public class MyException : Exception
    {
        public MyException(string ex)
        {
            this.HelpLink= ex;
            Delegates.consoleToLoge += consoleToLoge;
            Delegates.writeToFile += writeFile;
            Delegates.sendSms += sendSms;
            Delegates.sendSmsTelegram += sendSmsTelegram;
        }
        public static void consoleToLoge(string str)
        {
            Console.WriteLine(str);
        }
        public static void writeFile(string path,string exception)
        {

            using(StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine(exception);
            }
            Console.WriteLine(exception);
            Console.WriteLine("File ga yozildi!");

        }
        public static void sendSms(string str)
        {
            Console.WriteLine(str);
            Console.WriteLine("Sms yuborildi");
        }
        public static void sendSmsTelegram(string str) 
        { 
            Console.WriteLine(str);
            Console.WriteLine("Telegramga Sms yuborildi");
        }
    }
}
