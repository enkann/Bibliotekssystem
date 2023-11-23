using System.Collections.Generic;

public class Låntagare
{
    public string Namn { get; set; }
    public List<Bok> UtlånadeBöcker { get; set; }

    public Låntagare(string namn)
    {
        Namn = namn;
        UtlånadeBöcker = new List<Bok>();
    }
}
