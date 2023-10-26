using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gyak_Kiterjeszthetoseg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program indul");

            // Ide kerulnek a beolvasott adatok
            List<Person> peopleUnsorted = new List<Person>();

            // A teszt adatok egy CSV fajlban vannak (forrasuk: https://www.briandunning.com/sample-data)
            using (StreamReader reader = new StreamReader("us-500.csv"))
            {
                Console.WriteLine("Fajl megnyitva");

                // Olvassuk be a CSV fajlt
                int personCount = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    ++personCount;

                    // Egy sor igy nez ki
                    // "James","Butt","Benton, John B Jr","6649 N Blue Gum St","New Orleans","Orleans","LA",70116,"504-621-8927","504-845-1427","jbutt@gmail.com","http://www.bentonjohnbjr.com"
                    // Felvagjuk oszlopokra a sort (nem kell megerteni regularis kifejezest)
                    System.Text.RegularExpressions.MatchCollection columns = new System.Text.RegularExpressions.Regex("((?<=\")[^\"]*(?=\"(,|$)+)|(?<=,|^)[^,\"]*(?=,|$))").Matches(line);

                    // Minden sorbol egy ember adatot leiro osztaly peldanyt keszitunk
                    peopleUnsorted.Add(new Person(firstName: columns[0].Value, lastName: columns[1].Value, companyName: columns[2].Value, address: columns[3].Value, city: columns[4].Value, state: columns[6].Value));

                    Console.WriteLine($"{personCount}. ember beolvasva");
                }
            }

            // Csoportositsuk az embereket az allam (state) alapjan
            // Az egyenloseg jobb oldalat nem kell most megerteni, csak lassuk, hogy a 'State' alapjan van rendezve
            List<Person> peopleByState = peopleUnsorted.OrderBy(p => p.State).ToList();

            // Irjuk ki szoveges fajlba a sorrendezett emberek neveit az allammal egyutt:
            // Keresztnev Vezeteknev, Allam
            // Keresztnev Vezeteknev, Allam
            using (StreamWriter writer = new StreamWriter(@"emberek.txt"))
            {
                foreach (Person p in peopleByState)
                    writer.WriteLine($"{p.FirstName} {p.LastName}, {p.State}");
            }
        }
    }
}
