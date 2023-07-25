using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M3_Examen
{
    public class Users
    {

        public Users(string name,string path)
        {
            UserPath = path;
            ProductsInStore = Smartfon.GetSmartfon();

            Delegates.Create += Smartfon.Creat;
            Delegates.Update += Smartfon.UpdatePriceAndCount;
            Delegates.CreateDB += OnCreate;
            Delegates.UpdateDB += OnUpdate;
        }
        public  void OnCreate(WriteToFile writeTofile, SendSms sendTelegram)
        {
            writeTofile.Invoke(this.UserPath,"yangi smartfon yaratildi");
            sendTelegram.Invoke("Telegram: Yangi smartfon yaratildi");
        }
        public  void OnUpdate(SendSms ConsoleToLog, SendSms SendSms)
        {
            ConsoleToLog.Invoke("smartfon yangilandi");
            SendSms.Invoke("SMS: smartfon yangilandi");
        }
        public string UserPath{ get; set; }
        public string UserName { get; set; }
        public List<Smartfon> ProductsInStore{ get; set; }


    }
}
