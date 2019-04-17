using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project6
{
    public class RestaurantSystem
    {
        string scriptPath = @"..\OrderHistory.txt";
        string reportPath = @"..\Report.txt";
        string OrderId = "M001";
        FileStream fs;
        StreamWriter sw;
        StreamReader sr;
        
        public void Survey(int[] FoodOrdered)
        {
            fs = new FileStream(reportPath, FileMode.Open, FileAccess.Write);
            sw = new StreamWriter(fs);
            
            

            sw.Close();
            fs.Close();
        }

        public string AutoGenerateId()
        {
            int kode = 0;
            string newcode;
            string lastline;
            string[] isi;
            fs = new FileStream(@"C:\Users\gading\source\repos\Project6\Project6\bin\Debug\Number.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            string str;
            newcode = "M0001";

            while ((str = sr.ReadLine()) != null)
            {
                lastline = File.ReadLines(@"C:\Users\gading\source\repos\Project6\Project6\bin\Debug\Number.txt").Last();
                isi = lastline.Split('#');
                kode = Convert.ToInt32(isi[0].Substring(1, 4));
                kode = kode + 1;
                if (kode < 10)
                {
                    newcode = "M000" + kode;
                }
                else if (kode >= 10 && kode < 99)
                {
                    newcode = "M00" + kode;
                }
                else if (kode >= 99 && kode < 999)
                {
                    newcode = "M0" + kode;
                }
                else
                {

                }
            }
            sr.Close();
            fs.Close();
            return newcode;
        }
    }
}
