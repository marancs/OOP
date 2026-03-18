using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Model
{
    public class Tabor
    {
        public int KezdHonap {  get; set; }
        public int KezdNap { get; set; }
        public int VegHonap { get; set; }
        public int VegNap { get; set; }
        public string? Diakok {  get; set; }
        public string? Tema {  get; set; }

        public Tabor()
        {

        }
             

        public Tabor(string sor) {

            string[] t = sor.Trim().Split('\t');
            KezdHonap = int.Parse(t[0]);
            KezdNap = int.Parse(t[1]);
            VegHonap = int.Parse(t[2]);
            VegNap = int.Parse(t[3]);
            Diakok = t[4];
            Tema = t[5];


        }




    }
}
