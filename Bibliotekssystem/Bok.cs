public class Bok
{
    public string Titel { get; set; }
    public bool ÄrUtlånad { get; set; }

    public Bok(string titel)
    {
        Titel = titel;
        ÄrUtlånad = false;
    }
}
