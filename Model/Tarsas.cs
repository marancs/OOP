using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Model
{
    internal class Tarsas
    {
        private string? _nev;
        private string? _megjelenes_napja;
        private int _ar;
        private string[]? _temak;
        private string? _korosztaly;

        public string? Nev { get { return _nev; } set { _nev = value; } }
        public string? MegjelenesNapja { get { return _megjelenes_napja; } set { _megjelenes_napja = value; } }
        public int Ar { get { return _ar; } set { _ar = value; } }
        public string[]? Temak { get { return _temak; } set { _temak = value; } }
        public string? Korosztaly { get { return _korosztaly; } set { _korosztaly = value; } }

        public Tarsas()
        {

        }

        public Tarsas(string? sor)
        {
            //sor = "Catan;1995-01-01;15000;településépítés, kereskedelem;10-99"
            string[] t = sor.Split(";");
            this.Nev = t[0];
            MegjelenesNapja = t[1];
            int.TryParse(t[2],out _ar);
            Temak = new string[t[3].Split(",").Length];
            
            foreach(var tema in t[3].Split(","))
                Temak.Append(tema);

            Korosztaly = t[4].Trim();
        }










    }
}
