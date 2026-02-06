using OOP.Model;

namespace OOP
{
    public class Program
    {
        Random random = new Random();

        public Program()
        {
            //Dolgozo Marci = new Dolgozo();
            //Marci.Nev = "Marci";
            //Marci.Kor = 17;            

            //Dolgozo Rita = new Dolgozo("Rita",16);

            //Marci.FizetesEmeles(random.Next(10, 1000));
            //Rita.FizetesEmeles(random.Next(10, 1000));

            //TarsajatekProgram();

            HaziFeladat();

        }

        public void EvesMunkavegzes()
        {
            Dolgozo Rita = new Dolgozo("Rita", 16);
            Dolgozo Marci = new Dolgozo("Marci", 17);

            int honap = 12;


            for (int i = 0; i < honap; i++)
            {
                int kocka = random.Next(1, 7);
                if (kocka < 3)
                {
                    Rita.Cigiszunet();
                    Marci.FizetesEmeles(100);
                }
                else if (kocka > 3)
                {
                    Marci.Cigiszunet();
                    Rita.FizetesEmeles(100);
                }
                else {
                    Marci.FizetesEmeles(100);
                    Rita.FizetesEmeles(100);
                }
            }
            
            Console.WriteLine($"Rita fizetése: {Math.Round(Rita.Fizetes,2)}");
            Console.WriteLine($"Marci fizetése: {Math.Round(Marci.Fizetes,2)}");

        }
        
        public void TarsajatekProgram()
        {
            List<Tarsas> tarsasok = new List<Tarsas>();

            //Skip(1) első sort kihagyja!
            foreach(string sor in File.ReadAllLines("tarsasjatekok.txt").Skip(1))
            {
                //társasok listába adok egy új társast a sor alapján!
                tarsasok.Add(new Tarsas(sor));
            }

            Console.WriteLine(tarsasok[0].Nev);

            /*Írd ki azokat a társasokat amik 12 éves gyereknek ajánlható és az ára 45000 ft alatt van*/
            tarsasok.Where(i => i.KorosztalybanVan(8) && i.Ar < 45000)
                                   .Select(i => i.Nev).ToList()
                                   .ForEach(Console.WriteLine);

            //foreach(string sor in eredmeny)
            //    Console.WriteLine(sor);

            //linq
            /*
             lista.Where().Select().Orderby()

              
             */
            (from v in tarsasok
             where v.KorosztalybanVan(10) && v.Ar < 45000
             select v.Nev).ToList().ForEach(Console.WriteLine);

            /*Írd ki a legdrágább társas nevét és árát*/
            var eredmeny = (from v in tarsasok
                            orderby v.Ar descending
                            select new {nev = v.Nev, ar = v.Ar })
                            .First();

            Console.WriteLine(eredmeny);
            Console.WriteLine("Írd ki azokat a társasokat amiknek a témályában 'űr' szó szerepel");
            (from v in tarsasok
            where v.Temak.Exists(i=>i.Contains("űr"))
            select v.Nev).ToList().ForEach (Console.WriteLine);

            Console.WriteLine(tarsasok[0]);

            Console.WriteLine(tarsasok[0].GetHashCode());
            Console.WriteLine(tarsasok[1].GetHashCode());

            Console.WriteLine(tarsasok[1].Equals(tarsasok[2]));

        }

        public void HaziFeladat()
        {
            List<Tarsas> tarsasok = new List<Tarsas>();

            //Skip(1) első sort kihagyja!
            foreach (string sor in File.ReadAllLines("tarsasjatekok.txt").Skip(1))
            {
                //társasok listába adok egy új társast a sor alapján!
                tarsasok.Add(new Tarsas(sor));
            }

            Console.WriteLine("1. Olcsó társasjátékok");
            (from x in tarsasok
            where x.Ar < 5000
            select x.Nev).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("2. Ár szerint rendezés");
            (from x in tarsasok
            orderby x.Ar descending
            select $"{x.Nev}-{x.Ar}").ToList().ForEach(Console.WriteLine);


            Console.WriteLine("3. 2015 után megjelent játékok");
            (from x in tarsasok
             where Convert.ToInt32(x.MegjelenesNapja.Split('-')[0]) > 2015
             select x).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("4. „Party” témájú játékok száma");
            //Számold meg, hány olyan társasjáték van,
            //amelynek a témái között szerepel a „party” szó.
            int db = (from x in tarsasok
                      where x.Temak.Exists(i=>i.Contains("party"))
                      select x).Count();
            Console.WriteLine(db);

            Console.WriteLine("5.Legdrágább társasjáték");
            Console.WriteLine(tarsasok.OrderByDescending(i => i.Ar).First());

            Console.WriteLine("6.Ajánlott 10 éveseknek");
            tarsasok.Where(i => i.KorosztalybanVan(10)).Select(i => i.Nev).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("7.Összes különböző téma");

            List<string> temak = tarsasok.SelectMany(i => i.Temak).Select(i => i.Trim()).Distinct().ToList();

            Console.WriteLine("9. feladat:– Átlagár témánként");
            var atlagArTemankent = tarsasok.Where(t => t.Temak != null)
                                           .SelectMany(t => t.Temak.Select(tema => new {
                                                Tema = tema.Trim(),
                                                Ar = t.Ar
                                            }))
                                           .GroupBy(x => x.Tema)
                                           .Select(g => new //Ez egy anonim típus
                                            {
                                                Tema = g.Key,
                                                AtlagAr = g.Average(x => x.Ar)
                                            })
                                            .OrderBy(x => x.Tema)
                                            .ToList();
        }

        public static void Main(string[] args)
        {
            new Program();
            Console.ReadKey();
        }
    }
}


