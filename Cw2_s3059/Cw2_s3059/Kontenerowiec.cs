namespace Cw2_s3059;

public class Kontenerowiec()
{
    
    public List<Kontener> kontenery { get; set; }
    public double predkosc { get; set; }
    public int maxLiczbaKontenerow { get; set; }
    public double maxWaga { get; set; }
    public double aktualnaWaga { get; set; }

    public override string ToString()
    {
        return $" Statek (speed={predkosc}, maxContainerNum={maxLiczbaKontenerow}, maxWaight={maxWaga})\n";
    }

    public void DodajKontener(Kontener k)
    {
        if (kontenery.Count >= maxLiczbaKontenerow)
        {
            Console.WriteLine("Nie mozna dodac kontenerow, za duzo kontenerow");
        }
        double waga = 0;
        for (int i = 0; i < kontenery.Count; i++)
        {
            waga = (double)(k.wagaWlasna + k.masaLadunku);
        }

        if ((aktualnaWaga + waga)*0.001 > maxWaga)
        {
            Console.WriteLine("Nie mozna dodac kontenerow, za duza masa");
        }
        kontenery.Add(k);
    }
    
}