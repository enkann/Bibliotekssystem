using System;
using System.Collections.Generic;

public class Bibliotek
{
    private List<Låntagare> låntagare = new List<Låntagare>();
    private List<Bok> böcker = new List<Bok>();

    public void RegistreraLåntagare(string namn)
    {
        låntagare.Add(new Låntagare(namn));
    }

    public void VisaLåntagare()
    {
        foreach (var person in låntagare)
        {
            Console.WriteLine(person.Namn);
        }
    }

    public void VisaBöcker()
    {
        foreach (var bok in böcker)
        {
            string utlåningsstatus = bok.ÄrUtlånad ? "Ja" : "Nej";
            Console.WriteLine($"{bok.Titel} - Utlånad: {utlåningsstatus}");
        }
    }

    public void LäggTillBok(Bok bok)
    {
        böcker.Add(bok);
    }

    public void LånaBok()
    {
        Console.WriteLine("Ange ditt namn:");
        string namn = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(namn))
        {
            Console.WriteLine("Namn kan inte vara tomt.");
            return;
        }

        var låntagaren = låntagare.FirstOrDefault(l => l.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));
        if (låntagaren == null)
        {
            Console.WriteLine("Låntagaren finns inte i systemet, lägger till låntagaren.");
            låntagaren = new Låntagare(namn);
            låntagare.Add(låntagaren);
        }

        Console.WriteLine("Vilken bok vill du låna? Ange nummer:");
        var tillgängligaBöcker = böcker.Where(b => !b.ÄrUtlånad).ToList();
        for (int i = 0; i < tillgängligaBöcker.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tillgängligaBöcker[i].Titel}");
        }

        if (int.TryParse(Console.ReadLine(), out int bokNummer) && bokNummer >= 1 && bokNummer <= tillgängligaBöcker.Count)
        {
            var valdBok = tillgängligaBöcker[bokNummer - 1];
            valdBok.ÄrUtlånad = true;
            låntagaren.UtlånadeBöcker.Add(valdBok);
            Console.WriteLine($"Du har lånat '{valdBok.Titel}'. Kom ihåg att lämna tillbaka den i tid!");
        }
        else
        {
            Console.WriteLine("Ogiltigt val. Vänligen ange ett nummer från listan.");
        }
    }

    public void LämnaTillbakaBok()
    {
        Console.WriteLine("Ange ditt namn:");
        string? namn = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(namn))
        {
            Console.WriteLine("Namn kan inte vara tomt.");
            return;
        }

        var låntagaren = låntagare.FirstOrDefault(l => l.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));
        if (låntagaren == null)
        {
            Console.WriteLine("Låntagaren finns inte i systemet.");
            return;
        }

        Console.WriteLine("Vilken bok vill du återlämna? Ange titeln:");
        string? titel = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(titel))
        {
            Console.WriteLine("Titeln kan inte vara tom.");
            return;
        }

        var boken = låntagaren.UtlånadeBöcker.FirstOrDefault(b => b.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
        if (boken == null || !boken.ÄrUtlånad)
        {
            Console.WriteLine("Boken är inte utlånad till dig och kan inte återlämnas.");
            return;
        }

        boken.ÄrUtlånad = false;
        låntagaren.UtlånadeBöcker.Remove(boken);
        Console.WriteLine($"Boken '{boken.Titel}' har återlämnats. Tack!");
    }
}
