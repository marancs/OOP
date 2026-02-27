using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Model
{
    public class Hozzavalok
    {
        private string? _nev;
        private int? _db;
        private string? _meegyseg;

        public string? Nev {
            get { return _nev; }
            set { _nev = value; }
        }
        public int? Db { get { return _db; } set { _db = value; } }
        public string? Meegyseg { get { return _meegyseg; } set { _meegyseg = value; } }


        public Hozzavalok() {
            Console.WriteLine("Üres konsti");
        }

        public Hozzavalok(string sor) {

            //alma;1;kg
            Nev = sor.Split(";")[0];
            int.TryParse(sor.Split(";")[1], out int db);
            Db = db;

            Meegyseg = sor.Split(";")[2];

        }

        public void Eskuvo()
        {
            if (Meegyseg.Equals("dkg") && Db * 20 > 99)
            {
                Meegyseg = "kg";
                Db = (Db * 20) / 100;
            }
            else
                Db *= 20;
        }


    }
}
