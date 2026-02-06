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
        private List<string>? _temak;
        private string? _korosztaly;

        public string? Nev { get { return _nev; } set { _nev = value; } }
        public string? MegjelenesNapja { get { return _megjelenes_napja; } set { _megjelenes_napja = value; } }
        public int Ar { get { return _ar; } set { _ar = value; } }
        public List<string>? Temak { get { return _temak; } set { _temak = value; } }
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
            Temak = new (t[3].Split(","));

            //foreach(var tema in t[3].Split(","))
            //    Temak.Add(tema);

            Korosztaly = t[4].Trim();
        }

        public override string ToString()
        {
            return $"Társas neve: {Nev}, ára: {Ar}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Tarsas) return false;

            if ((obj as Tarsas).Nev != null && (obj as Tarsas).Korosztaly != null)
            {
                return (obj as Tarsas).Nev.Equals(Nev) &&
                       (obj as Tarsas).Korosztaly.Equals(Korosztaly);
            }
            else return false;
            //return base.Equals(obj);
        }


        public bool KorosztalybanVan(int kor)
        {
            //10-99
            int a = Convert.ToInt32(Korosztaly.Split("-")[0]);
            int b = Convert.ToInt32(Korosztaly.Split("-")[1]);

            return (kor >= a && kor <= b);


        }







    }
}
