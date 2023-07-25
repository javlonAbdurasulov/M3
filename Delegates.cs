using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_Examen
{
    public delegate void createDB(WriteToFile writeTofile, SendSms sendTelegram);
    public delegate void updateDB(SendSms ConsoleToLog, SendSms SendSms);
    public delegate Task create(List<Smartfon> smartfons, string name, int year, decimal priceDol, int Count = 0);
    public delegate void update(List<Smartfon> smartfons, string Name, int priceDol, int count = 0);
    public delegate void concoleToLoge(string str);
    public delegate void WriteToFile( string path, string exception);
    public delegate void SendSms(string str);
    public delegate void SendSmsTelegram(string str);
    public class Delegates
    {
        public static createDB? CreateDB;
        public static updateDB? UpdateDB;
        public static create? Create;
        public static update? Update;
        public static concoleToLoge? consoleToLoge;
        public static SendSms? sendSms;
        public static SendSmsTelegram? sendSmsTelegram;
        public static WriteToFile? writeToFile;
        
    }



}
