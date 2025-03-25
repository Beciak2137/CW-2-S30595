namespace Cw2_s3059;

public class KontenerPlyn :Kontener,IHazardNotifier
{
    public bool niebezpieczne { get; set; }

    public void Zaladuj(double masa)
    {
        if (niebezpieczne==true)
        {
            if (masaLadunku + masa > maxLadownosc/2)
            {
                throw new OverfillException();
            }
            masaLadunku += masa;
        }
        else
        {
            if (masaLadunku + masa > maxLadownosc*0.9)
            {
                throw new OverfillException();
            }
            masaLadunku += masa;
        }
    }
    
    public void Niebezpiecznie()
    {
       Console.WriteLine($"Zaszla proba wykonania niebezpiecznej operacji na kontenerze: {NumerSeryjny}\n");
    }
}