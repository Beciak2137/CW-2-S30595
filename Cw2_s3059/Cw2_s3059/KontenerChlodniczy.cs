namespace Cw2_s3059;

public class KontenerChlodniczy : Kontener
{
    private static Dictionary<string, double> wymaganeTemperatury = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    private double temperatura;

    public double Temperatura
    {
        get { return temperatura; }
        set
        {
            if (temperatura > wymaganeTemperatury[rodzajProduktu])
            {
                throw new ArgumentException($"Temperatura {temperatura}°C jest za wysoka dla produktu {rodzajProduktu} (max {wymaganeTemperatury[rodzajProduktu]}°C)");
            }
            temperatura = value;
        }
    }
    private string rodzajProduktu;

    public string RodzajProduktu
    {
        get { return rodzajProduktu; }
        set
        {
            if (!wymaganeTemperatury.ContainsKey(value))
            {
                throw new ArgumentException($"Nieznany produkt: {rodzajProduktu}");
            }
            rodzajProduktu = value;
        }
    }
    
    public void Zaladuj(double masa, string rodzaj)
    {
        if (masaLadunku + masa > maxLadownosc)
        {
            throw new OverfillException();
        }

        if (rodzaj != rodzajProduktu)
        {
            throw new InvalidOperationException($"Kontener może przechowywać tylko {rodzajProduktu}");
        }
    }
    
    
}