using System.Xml.Linq;

namespace M3_Examen
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            try
            {

                StartUp.Start();

            }

            catch(MyException ex) {

                Delegates.consoleToLoge.Invoke("Xatolik BOR!");

                Delegates.writeToFile.Invoke(StartUp.path,ex.HelpLink);

                Delegates.sendSms.Invoke("xato haqida sms yuborildi");
                
                Delegates.sendSmsTelegram.Invoke("xato haqida sms Telegramga yuborildi");

            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }


        }
    }
}