

namespace Cw2_s3059;

public class Kontener : OverfillException
{
    private static HashSet<int> użyteNumery = new HashSet<int>();
    private static int ostatniNumer = 0;
    
    public double masaLadunku { get; set; }
    public double wysokosc { get; set; }
    public double wagaWlasna { get; set; }
    public double glebokosc { get; set; }
    public double maxLadownosc { get; set; }
    public string numerSeryjny;

    public string NumerSeryjny
    {
        get { return numerSeryjny; }
        set
        {
            if (numerSeryjny == null)
            {
                ostatniNumer++;
                while (użyteNumery.Contains(ostatniNumer))
                {
                    ostatniNumer++;
                }

                użyteNumery.Add(ostatniNumer);
                numerSeryjny = $"KON-{char.ToUpper(value[0])}-{ostatniNumer}";
            }
            else
            {
                throw new InvalidOperationException("Numer seryjny nie moze byc zmieniony");
            }
        }
    }
    

    public override string ToString()
    {
        return $" Kontener: {numerSeryjny}";
    }

    public virtual void Rozladuj()
    {
        masaLadunku = 0;
    }

}