namespace Cw2_s3059;

public class KontenerGaz : Kontener, IHazardNotifier
{
    public double cisnienie { get; set; }
    
    public void Zaladuj(double masa)
    {
        
        if (masaLadunku + masa > maxLadownosc)
        {
            throw new OverfillException();
        }
        masaLadunku += masa;
    }

    public override void Rozladuj()
    {
        if (masaLadunku!=0)
        {
            masaLadunku = masaLadunku*0.05;
        }
    }

    public void Niebezpiecznie()
    {
        Console.WriteLine($"Zaszla proba wykonania niebezpiecznej operacji na kontenerze: {NumerSeryjny}\n");
    }
}