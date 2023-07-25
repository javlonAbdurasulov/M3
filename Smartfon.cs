using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_Examen
{
    public class Smartfon
    {
        
        public string Name{ get; set; }
        public int Year { get; set; }
        public decimal PriceDol { get; set; }
        public int Count { get; set; }


        public static List<Smartfon> GetSmartfon()
        {
            List<Smartfon> smartfons = new List<Smartfon>()
            {
                new Smartfon { Name = "Samsung A11",Year = 2019,PriceDol = 167,Count=100},
                new Smartfon { Name = "Samsung A13",Year = 2022,PriceDol = 240,Count=10},
                new Smartfon { Name = "Samsung A51",Year = 2023,PriceDol = 275,Count=80},
                new Smartfon { Name = "Samsung AA1",Year = 2000,PriceDol = 200,Count=20},
                new Smartfon { Name = "Samsung AA2",Year = 2000,PriceDol = 200,Count=200},
                new Smartfon { Name = "Samsung AA3",Year = 2000,PriceDol = 200,Count=200},
                new Smartfon { Name = "Samsung S23",Year = 2022,PriceDol = 1000,Count=90},
            };
            
            return smartfons;
        }

        #region Crud


        public static async Task Creat(List<Smartfon> smartfons,string name, int year, decimal priceDol, int Count=0)
        {
            
            smartfons.Add(new Smartfon { Name = name,Year = year,PriceDol = priceDol,Count = Count});
            Console.WriteLine("complite");
            Delegates.CreateDB.Invoke(MyException.writeFile, MyException.sendSmsTelegram);
        }

        public static void Read(List<Smartfon> smartfons)
        {
            foreach (var smartfon in smartfons)
            {
                Console.WriteLine(smartfon.ToString());
            }

        }
        
        public static void UpdatePriceAndCount(List<Smartfon> smartfons,string Name, int priceDol,int count=0)
        {
            var updateSmartfon = smartfons.Where(sm => sm.Name == Name);
            Smartfon upSmart = updateSmartfon.FirstOrDefault();
            upSmart.PriceDol = priceDol;
            upSmart.Count = count;
            Delegates.UpdateDB.Invoke(MyException.consoleToLoge, MyException.sendSms);

        }


        public static List<Smartfon> Delete(List<Smartfon> smartfons, string Name)
        {
            return smartfons.Where((sm) => sm.Name != Name).Select(x => x).ToList();
        }


        #endregion

        #region Toplik

        public static void EngKopSotilgan(List<Smartfon> smartfons)
        {
            Console.WriteLine("EngKopSotilgan");
            int maxx = smartfons.Max(x => x.Count);
            var EngKopSotilganSmartfon = smartfons.FirstOrDefault(x=>x.Count==maxx);
            Console.WriteLine(EngKopSotilganSmartfon.ToString());
        }
        public static void EngKamSotilgan5lik(List<Smartfon> smartfons)
        {
            Console.WriteLine("EngKamSotilgan5lik");
            var S5lik = smartfons.OrderBy(x => x.Count).Take(5).ToList();
            Smartfon.Read(S5lik);
        }
        public static void EngArzon(List<Smartfon> smartfons)
        {
            Console.WriteLine("EngArzon");
            int minPrice  = smartfons.Min(x => (int)x.PriceDol);
            var engArzon = smartfons.FirstOrDefault(x => x.PriceDol==minPrice);
            Console.WriteLine(engArzon.ToString());
        }



        #endregion





        public override string ToString()
        {
            return $"Name: {this.Name} Year: {this.Year} Price$: {this.PriceDol}\tBuy Count: {this.Count}";
        }


    }
}
