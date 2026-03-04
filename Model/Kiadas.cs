using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Model
{
    internal class Kiadas
    {
        public int KiadasEv {  get; set; }
        public int KiadasNegyedEv { get; set; }
        public string? Eredet {  get; set; }
        public string? Leiras { get; set; }
        public int Peldany {  get; set; }

        public Kiadas() { }

        public Kiadas(string sor)
        {
            //sor = "2020;1;ma;Szobonya Erzsébet: Sapho 1.;20000"
            string[] t = sor.Split(';');
            int.TryParse(t[0], out int ev);
            KiadasEv = ev;
            int.TryParse(t[1], out int negyed);
            KiadasNegyedEv = negyed;
            Eredet = t[2];
            Leiras = t[3];
            int.TryParse(t[4], out int p);
            Peldany = p;
        }


    }
}
