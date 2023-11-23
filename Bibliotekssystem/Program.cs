using System;

class Program
{
    static void Main(string[] args)
    {
        Bibliotek bibliotek = new Bibliotek();

        for (int i = 0; i < 10; i++)
        {
            bibliotek.LäggTillBok(new Bok($"Bok {i + 1}"));
        }

        bool körs = true;
        while (körs)
        {
            Console.WriteLine("Välkommen till biblioteket!");
            Console.WriteLine("1. Registrera låntagare");
            Console.WriteLine("2. Visa alla låntagare");
            Console.WriteLine("3. Visa alla böcker");
            Console.WriteLine("4. Låna böcker");
            Console.WriteLine("5. Lämna tillbaka böcker");
            Console.WriteLine("6. Avsluta programmet");
            Console.Write("Välj ett alternativ: ");

            int val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    Console.Write("Ange låntagarens namn: ");
                    string namn = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(namn))
                    {
                        bibliotek.RegistreraLåntagare(namn);
                    }
                    else
                    {
                        Console.WriteLine("Du måste ange ett namn.");
                    }
                    break;

                case 2:
                    bibliotek.VisaLåntagare();
                    break;

                case 3:
                    bibliotek.VisaBöcker();
                    break;

                case 4:
                    bibliotek.LånaBok();
                    break;

                case 5:
                    bibliotek.LämnaTillbakaBok();
                    break;

                case 6:
                    körs = false;
                    break;

                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }
}
