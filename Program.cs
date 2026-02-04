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

            TarsajatekProgram();

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






        }

        public static void Main(string[] args)
        {
            new Program();
            Console.ReadKey();
        }
    }
}


