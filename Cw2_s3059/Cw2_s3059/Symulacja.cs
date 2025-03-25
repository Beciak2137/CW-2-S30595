namespace Cw2_s3059;

public class Symulacja
{
    static List<Kontenerowiec> kontenerowce = new List<Kontenerowiec>();
    static List<Kontener> kontenery = new List<Kontener>();
    static List<Kontener> wolneKontenery = new List<Kontener>();

    public void Symulacjaa()
    {
        while (true)
             {
                 WyswietlStan();
                 Console.WriteLine("Mozliwe akcje:");
                 Console.WriteLine("1. Dodaj kontenerowiec");
                 if (kontenerowce.Count > 0)
                 {
                     Console.WriteLine("2. Usun kontenerowiec");
                     Console.WriteLine("3. Dodaj kontener");
                     Console.WriteLine("4. Przypisz kontener do kontenerowca");
                     Console.WriteLine("5. Usun dany kontener ze statku");
                     Console.WriteLine("6. Zaladuj kontener");
                     Console.WriteLine("7. Rozladuj kontener");
                     Console.WriteLine("8. Zastap kontener na statku o danym numerze innym kontenerem");
                     Console.WriteLine("9. Przenies kontener na inny statek");
                     Console.WriteLine("10. Wypisz informacje o danym kontenerze");
                     Console.WriteLine("11. Wypisz informacje o danym statku i jego ladunku");
                     Console.WriteLine("12. Wyjdź");
                 }
                 

                 Console.Write("\nWybierz opcję: ");
                 string wybor = Console.ReadLine();

                 switch (wybor)
                 {
                     case "1":
                         DodajKontenerowiec();
                         break;
                     case "2":
                         UsunKontenerowiec();
                         break;
                     case "3":
                         DodajKontener();
                         break;
                     case "4":
                         PrzypiszKontenerDoKontenerowca();
                         break;
                     case "5":
                         UsunDanyKontenerZeStatku();
                         break;
                     case "6":
                         ZaladujKontener();
                         break;
                     case "7":
                         RozladujKontener();
                         break;
                     case "8":
                         ZastapKontener();
                         break;
                     case "9":
                         PrzeniesKontener();
                         break;
                     case "10":
                         WypiszInfoKontener();
                         break;
                     case "11":
                         WypiszInfoStatku();
                         break;
                     case "12":
                         break;
                     default:
                         Console.WriteLine("Niepoprawny wybór nacisnij enter by kontynuowac ");
                         Console.ReadLine();
                         break;
                 }
             }
         }

         static void WyswietlStan()
         {
             Console.WriteLine("Lista Kontenerowcow: ");
             if (kontenerowce.Count == 0)
             {
                 Console.WriteLine("Brak");
             }
             else
             {
                 for (int i = 0; i < kontenerowce.Count; i++)
                 {
                     Console.WriteLine($"{i+1}{kontenerowce[i]}");
                 }
             }
             Console.WriteLine("Lista kontenerow: ");
             if (kontenery.Count == 0)
             {
                 Console.WriteLine("Brak");
             }
             else
             {
                 for (int i = 0; i < kontenery.Count; i++)
                 {
                     Console.WriteLine($"{i+1}{kontenery[i]}");
                 }
             }
             Console.WriteLine();
         }

         static void DodajKontenerowiec()
         {
             Kontenerowiec k = new Kontenerowiec();
             Console.Write("Podaj predkosc kontenerowca: ");
             double predkosc = double.Parse(Console.ReadLine());
             k.predkosc = predkosc;
             Console.Write("Podaj maksymalna liczbę kontenerów: ");
             int maxKontenery = int.Parse(Console.ReadLine());
             k.maxLiczbaKontenerow = maxKontenery;
             Console.Write("Podaj maksymalna ladownosc (t): ");
             double maxWaga = double.Parse(Console.ReadLine());
             k.maxWaga = maxWaga;
             k.aktualnaWaga = 0;
             k.kontenery = new List<Kontener>();
             kontenerowce.Add(k);
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }

         static void UsunKontenerowiec()
         {
             Console.Write("Podaj numer kontenerowca do usunięcia: ");
             int index = int.Parse(Console.ReadLine()) - 1;
             if (index >= 0 && index < kontenerowce.Count)
             {
                 kontenerowce.RemoveAt(index);
             }
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }

         static void DodajKontener()
         {
             Console.Write("Podaj typ kontenera (L - Plyny, G - Gaz, C - chlodniczy): ");
             char typ = Console.ReadKey().KeyChar;
             Kontener k = new Kontener();
             k.NumerSeryjny = typ.ToString();
             Console.WriteLine("\nPodaj wysokosc (cm): ");
             double wysokosc = double.Parse(Console.ReadLine());
             k.wysokosc = wysokosc;
             Console.WriteLine("Podaj wage wlasna (kg): ");
             double wage = double.Parse(Console.ReadLine());
             k.wagaWlasna = wage;
             Console.WriteLine("Podaj glebokosc (cm): ");
             double glebokosc = double.Parse(Console.ReadLine());
             k.glebokosc = glebokosc;
             Console.WriteLine("Podaj maksymalna ladownosc (kg): ");
             double maksymalna = double.Parse(Console.ReadLine());
             k.maxLadownosc = maksymalna;
             k.masaLadunku = 0;
             kontenery.Add(k);
             wolneKontenery.Add(k);
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
             
         }
         static void PrzypiszKontenerDoKontenerowca()
         {
             if (wolneKontenery.Count == 0)
             {
                 Console.WriteLine("Brak dostępnych kontenerów do przypisania.");
                 Console.ReadLine();
                 return;
             }

             if (kontenerowce.Count == 0)
             {
                 Console.WriteLine("Brak kontenerowców do przypisania kontenera.");
                 Console.ReadLine();
                 return;
             }
             
             Console.WriteLine("\nDostępne kontenery:");
             for (int i = 0; i < wolneKontenery.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {wolneKontenery[i]}");
             }

             Console.Write("Wybierz numer kontenera do przypisania: ");
             if (!int.TryParse(Console.ReadLine(), out int kontenerIndex) || kontenerIndex < 1 || kontenerIndex > kontenery.Count)
             {
                 Console.WriteLine("Niepoprawny wybór.");
                 Console.ReadLine();
                 return;
             }
             
             Console.WriteLine("\nDostępne kontenerowce:");
             for (int i = 0; i < kontenerowce.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenerowce[i]}");
             }

             Console.Write("Wybierz numer kontenerowca: ");
             if (!int.TryParse(Console.ReadLine(), out int statekIndex) || statekIndex < 1 || statekIndex > kontenerowce.Count)
             {
                 Console.WriteLine("Niepoprawny wybór.");
                 Console.ReadLine();
                 return;
             }
             
             Kontener wybranyKontener = wolneKontenery[kontenerIndex - 1];
             Kontenerowiec wybranyStatek = kontenerowce[statekIndex - 1];
             
             wybranyStatek.DodajKontener(wybranyKontener);
             wolneKontenery.RemoveAt(kontenerIndex - 1);
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
             
         }
         static void UsunDanyKontenerZeStatku()
         {
             Console.WriteLine("\nDostępne kontenerowce:");
             for (int i = 0; i < kontenerowce.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenerowce[i]}");
             }

             Console.Write("Wybierz numer kontenerowca, z którego chcesz usunąć kontener: ");
             if (!int.TryParse(Console.ReadLine(), out int statekIndex) || statekIndex < 1 || statekIndex > kontenerowce.Count)
             {
                 Console.WriteLine("Niepoprawny wybór.");
                 Console.ReadLine();
                 return;
             }

             Kontenerowiec wybranyStatek = kontenerowce[statekIndex - 1];

             if (wybranyStatek.kontenery.Count == 0)
             {
                 Console.WriteLine("Ten kontenerowiec nie ma żadnych kontenerów.");
                 Console.ReadLine();
             }
             Console.WriteLine("\nKontenery na statku:");
             for (int i = 0; i < wybranyStatek.kontenery.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {wybranyStatek.kontenery[i]}");
             }
             
             Console.Write("Wybierz numer kontenera do usunięcia: ");
             if (!int.TryParse(Console.ReadLine(), out int kontenerIndex) || kontenerIndex < 1 || kontenerIndex > wybranyStatek.kontenery.Count)
             {
                 Console.WriteLine("Niepoprawny wybór.");
                 Console.ReadLine();
             }
             wybranyStatek.kontenery.RemoveAt(kontenerIndex - 1);
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
             
         }
         static void ZaladujKontener()
         {
             Console.WriteLine("\nDostepne kontenery:");
             for (int i = 0; i < kontenery.Count(); i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenery[i]}");
             }
             Console.WriteLine("\nWybierz kontener do zaladowania: ");
             if (!int.TryParse(Console.ReadLine(), out int kontenerIndex) || kontenerIndex < 1 || kontenerIndex > kontenery.Count)
             {
                 Console.WriteLine("Niepoprawny wybór.");
                 Console.ReadLine();
             }
             Kontener wybranyKontener = kontenery[kontenerIndex - 1];
             if (wybranyKontener.NumerSeryjny.Contains('L'))
             {
                 Console.WriteLine("Czy plyn jest niebezpieczny? (tak - 1, nie - 0): ");
                 int niebezpieczny = int.Parse(Console.ReadLine());
                 KontenerPlyn kontenerPlyn = new KontenerPlyn();
                 kontenerPlyn.wysokosc = kontenery[kontenerIndex - 1].wysokosc;
                 kontenerPlyn.wagaWlasna = kontenery[kontenerIndex - 1].wagaWlasna;
                 kontenerPlyn.glebokosc = kontenery[kontenerIndex - 1].glebokosc;
                 kontenerPlyn.masaLadunku = kontenery[kontenerIndex - 1].masaLadunku;
                 kontenerPlyn.maxLadownosc = kontenery[kontenerIndex - 1].maxLadownosc;
                 kontenerPlyn.numerSeryjny = kontenery[kontenerIndex - 1].numerSeryjny;
                 if (niebezpieczny == 0)
                 {
                     kontenerPlyn.niebezpieczne = false;
                 }
                 else
                 {
                     kontenerPlyn.niebezpieczne = true;
                 }
                 Console.WriteLine("Wpisz mase plynu: ");
                 double masa = double.Parse(Console.ReadLine());
                 kontenerPlyn.Zaladuj(masa);
                 kontenery[kontenerIndex - 1] = kontenerPlyn;
             }
             if (wybranyKontener.NumerSeryjny.Contains('G'))
             {
                 KontenerGaz kontenerGaz = new KontenerGaz();
                 kontenerGaz.wysokosc = kontenery[kontenerIndex - 1].wysokosc;
                 kontenerGaz.wagaWlasna = kontenery[kontenerIndex - 1].wagaWlasna;
                 kontenerGaz.glebokosc = kontenery[kontenerIndex - 1].glebokosc;
                 kontenerGaz.masaLadunku = kontenery[kontenerIndex - 1].masaLadunku;
                 kontenerGaz.maxLadownosc = kontenery[kontenerIndex - 1].maxLadownosc;
                 kontenerGaz.numerSeryjny = kontenery[kontenerIndex - 1].numerSeryjny;
                 Console.WriteLine("Wpisz mase gazu: ");
                 double masa = double.Parse(Console.ReadLine());
                 kontenerGaz.Zaladuj(masa);
                 kontenery[kontenerIndex - 1] = kontenerGaz;
             }
             if (wybranyKontener.NumerSeryjny.Contains('C'))
             {
                 KontenerChlodniczy kontenerChlodniczy = new KontenerChlodniczy();
                 kontenerChlodniczy.wysokosc = kontenery[kontenerIndex - 1].wysokosc;
                 kontenerChlodniczy.wagaWlasna = kontenery[kontenerIndex - 1].wagaWlasna;
                 kontenerChlodniczy.glebokosc = kontenery[kontenerIndex - 1].glebokosc;
                 kontenerChlodniczy.masaLadunku = kontenery[kontenerIndex - 1].masaLadunku;
                 kontenerChlodniczy.maxLadownosc = kontenery[kontenerIndex - 1].maxLadownosc;
                 kontenerChlodniczy.numerSeryjny = kontenery[kontenerIndex - 1].numerSeryjny;
                 Console.WriteLine("Wpisz rodzaj produktu: ");
                 string rodzajProduktu = Console.ReadLine();
                 kontenerChlodniczy.RodzajProduktu= rodzajProduktu;
                 Console.WriteLine("Wpisz temperature: "); 
                 double temperatura = double.Parse(Console.ReadLine());
                 kontenerChlodniczy.Temperatura = temperatura;
                 Console.WriteLine("Wpisz masa: ");
                 double masa = double.Parse(Console.ReadLine());
                 kontenerChlodniczy.Zaladuj(masa,rodzajProduktu);
                 kontenery[kontenerIndex - 1] = kontenerChlodniczy;
             }
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }

         static void RozladujKontener()
         {
             Console.WriteLine("\nDostepne kontenery:");
             for (int i = 0; i < kontenery.Count(); i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenery[i]}");
             }
             Console.WriteLine("\nWybierz kontener do rozladowania: ");
             if (!int.TryParse(Console.ReadLine(), out int kontenerIndex) || kontenerIndex < 1 || kontenerIndex > kontenery.Count)
             {
                 Console.WriteLine("Niepoprawny wybór.");
                 Console.ReadLine();
             }
             Kontener wybranyKontener = kontenery[kontenerIndex - 1];
             wybranyKontener.Rozladuj();
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }

         static void ZastapKontener()
         {
             Console.WriteLine("Wybierz statek:");
             for (int i = 0; i < kontenerowce.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenerowce[i]}");
             }
    
             int statekIndex = int.Parse(Console.ReadLine()) - 1;
             Kontenerowiec wybranyStatek = kontenerowce[statekIndex];

             Console.WriteLine("Wybierz kontener do zastapienia:");
             for (int i = 0; i < wybranyStatek.kontenery.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {wybranyStatek.kontenery[i]}");
             }

             int kontenerIndex = int.Parse(Console.ReadLine()) - 1;

             Console.WriteLine("Wybierz nowy kontener:");
             for (int i = 0; i < wolneKontenery.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {wolneKontenery[i]}");
             }

             int nowyKontenerIndex = int.Parse(Console.ReadLine()) - 1;
             Kontener nowyKontener = wolneKontenery[nowyKontenerIndex];
             
             wybranyStatek.kontenery[kontenerIndex] = nowyKontener;
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }

         static void PrzeniesKontener()
         {
             Console.WriteLine("Wybierz statek, z ktorego chcesz przeniesc kontener:");
             for (int i = 0; i < kontenerowce.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenerowce[i]}");
             }

             int statekZIndex = int.Parse(Console.ReadLine()) - 1;
             Kontenerowiec statekZrodlowy = kontenerowce[statekZIndex];

             Console.WriteLine("Wybierz kontener do przeniesienia:");
             for (int i = 0; i < statekZrodlowy.kontenery.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {statekZrodlowy.kontenery[i]}");
             }

             int kontenerIndex = int.Parse(Console.ReadLine()) - 1;
             Kontener kontenerDoPrzeniesienia = statekZrodlowy.kontenery[kontenerIndex];

             Console.WriteLine("Wybierz statek docelowy:");
             for (int i = 0; i < kontenerowce.Count; i++)
             {
                 if (i != statekZIndex) 
                 {
                     Console.WriteLine($"{i + 1}. {kontenerowce[i]}");
                 }
             }

             int statekDoIndex = int.Parse(Console.ReadLine()) - 1;
             Kontenerowiec statekDocelowy = kontenerowce[statekDoIndex];
             
             statekZrodlowy.kontenery.RemoveAt(kontenerIndex);
             statekDocelowy.kontenery.Add(kontenerDoPrzeniesienia);
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }

         static void WypiszInfoKontener()
         {
             Console.WriteLine("Wybierz kontener, o którym chcesz wyswietlic informacje:");

             for (int i = 0; i < kontenery.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenery[i].NumerSeryjny}");
             }

             int kontenerIndex = int.Parse(Console.ReadLine()) - 1;
             Kontener wybranyKontener = kontenery[kontenerIndex];

             Console.WriteLine("\nInformacje o kontenerze:");
             Console.WriteLine($"Numer seryjny: {wybranyKontener.NumerSeryjny}");
             Console.WriteLine($"Masa ladunku: {wybranyKontener.masaLadunku} kg");
             Console.WriteLine($"Wysokosc: {wybranyKontener.wysokosc} cm");
             Console.WriteLine($"Waga wlasna: {wybranyKontener.wagaWlasna} kg");
             Console.WriteLine($"Glebokosc: {wybranyKontener.glebokosc} cm");
             Console.WriteLine($"Maksymalna ladownosc: {wybranyKontener.maxLadownosc} kg");
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }

         static void WypiszInfoStatku()
         {
             Console.WriteLine("Wybierz statek, o ktorym chcesz wyswietlic informacje:");

             for (int i = 0; i < kontenerowce.Count; i++)
             {
                 Console.WriteLine($"{i + 1}. {kontenerowce[i]}");
             }

             int statekIndex = int.Parse(Console.ReadLine()) - 1;
             Kontenerowiec wybranyStatek = kontenerowce[statekIndex];

             Console.WriteLine("\nInformacje o statku:");
             Console.WriteLine($"Predkosc: {wybranyStatek.predkosc} wezlow");
             Console.WriteLine($"Maksymalna liczba kontenerow: {wybranyStatek.maxLiczbaKontenerow}");
             Console.WriteLine($"Maksymalna ładownosc: {wybranyStatek.maxWaga} t");

             Console.WriteLine("\nLista kontenerów na statku:");
             if (wybranyStatek.kontenery.Count == 0)
             {
                 Console.WriteLine("Brak kontenerów na statku.");
             }
             else
             {
                 foreach (var kontener in wybranyStatek.kontenery)
                 {
                     Console.WriteLine($"- {kontener.NumerSeryjny}");
                 }
             }
             Console.WriteLine("Kliknij enter by kontynuowac");
             Console.ReadLine();
         }
     }
