using DomainObjects.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Files
{
    public class TextFile
    {
        public static void Write(string input)
        {
            DateTime dateTime = DateTime.Now;
            string curr = dateTime.ToString().Replace(' ', '_');
            curr = curr.Replace(':', '_');
            using (FileStream fs = new FileStream("out"+curr+".txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(input);
                }
            }
        }
    }
}
