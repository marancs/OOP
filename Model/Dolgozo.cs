using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Model
{
    public class Dolgozo
    {
        private string? _nev;
        private int _kor;
        private decimal _fizetes;

        public string? Nev
        {
            get { return _nev; }
            set
            {
                _nev = value;// obj.Nev = "Almáspite";
            }
        }

        public int Kor
        {
            get { return _kor; }
            set { _kor = value; }
        }

        public decimal Fizetes
        {
            get { return _fizetes; }
        }

        #region Konstruktorok
        public Dolgozo()
        {
            Console.WriteLine("Létrehoztam egy üres dolgozót!");
        }

        public Dolgozo(string? nev, int kor)
        {
            Nev = nev;
            Kor = kor;
            _fizetes = 100;
        }
        #endregion

        public void Cigiszunet()
        {
            Console.WriteLine("Épp cigi szüneten vagyok! 10 perc pihi!");
            _fizetes = _fizetes * (decimal)0.9;
        }

        public void FizetesEmeles(decimal f)
        {
            _fizetes += f;
            Console.WriteLine($"{Nev} fizetésemelést kapott: új fizú :{_fizetes}");
        }
    }
}
