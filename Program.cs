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

            EvesMunkavegzes();

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
        public static void Main(string[] args)
        {
            new Program();
            Console.ReadKey();
        }
    }
}


