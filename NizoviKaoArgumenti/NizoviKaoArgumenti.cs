using System;

namespace Vsite.CSharp
{
    // niz kao argument metode
    public class NizoviKaoArgumenti
    {
        // U metodi SamVrag() napisati naredbu kojom se jedan od članova niza mijenja u neki drugi tekst. Pokrenuti program i usporediti sadržaj nakon poziva metode.
        public static void SamVrag(string[] božjeZapovjedi)
        {
			božjeZapovjedi[2]="Ne radi" ;
        }

        static void Main(string[] args)
        {
            string[] parBožjih = new string[] { "Ne ubij!", "Ne sagriješi bludno!", "Ne kradi!", };

            foreach (string s in parBožjih)
                Console.WriteLine(s);

            Console.WriteLine("Nakon poziva metode");

            SamVrag(parBožjih);

            foreach (string s in parBožjih)
                Console.WriteLine(s);

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey();
        }
    }
}
