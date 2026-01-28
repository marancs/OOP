
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

}

public class Program
{

    public Program()
    {
        Dolgozo Marci = new Dolgozo();
    }

    public static void Main(string[] args) {
        new Program();
        Console.ReadKey();
    }
}



