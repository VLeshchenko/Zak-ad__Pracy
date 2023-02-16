using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakładPracy
{
    public class Massage
    {
        public double? Wynagrodzenie { get; set; }
        public string? answer { get; set; }
        public void ShowStartScreen()
        {
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA WSZYSTKICH PRACOWNIKÓW");
            Console.WriteLine("2 => WYLICZ PENSJĘ PRACOWNIKA");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");
            answer = Console.ReadLine();
        }

        public Massage()
        {
            CreatePerson();
        }

        public List<Pracownik>? AllPerson { get; set; }
        public void CreatePerson()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Pracowniki.json";
            var json = File.ReadAllText(path);
            AllPerson = JsonConvert.DeserializeObject<List<Pracownik>>(json);
        }

        public void DisplayPerson()
        {
            Console.WriteLine("ID | IMIĘ I NAZWISKO | DATA UR. | STANOWISKO");
            foreach (var p in AllPerson)
            {
                Console.WriteLine(p.Id + " | " + p.ImieNasw + " | " + p.DataUrodz.ToShortDateString() + " | " + p.Stanowisko);
            }
        }

        public void FindPerson()
        {
            foreach (var p in AllPerson)
            {
                if (p.Id == Int32.Parse(answer))
                {
                    Console.WriteLine("WYLICZANIE WYNAGRODZENIA PRACOWNIKA");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("DANE PRACOWNIKA: ");
                    Console.WriteLine("IMIE I NAZWISKO: " + p.ImieNasw);
                    int age = DateTime.Now.Year - p.DataUrodz.Year;
                    Console.WriteLine("WIEK: " + age);
                    Console.WriteLine("STANOWISKO: " + p.Stanowisko);
                    Console.WriteLine("PENSJA STAŁA: " + p.Pensja);
                    Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA (MAX.20): ");

                    var Days = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("PROSZĘ PODAĆ KWOTĘ PREMII DLA PRACOWNIKA:");

                    var Premia = Console.ReadLine();

                    if (p.Stanowisko == "Urzędnik")
                    {
                        if (Days == "20")
                        {
                            var Podstawa = p.Pensja;
                            Wynagrodzenie = Podstawa + Int32.Parse(Premia);
                        }
                        else
                        {
                            double Podstawa = p.Pensja * 0.8;
                            Wynagrodzenie = Podstawa;
                        }

                    }
                    if (p.Stanowisko == "Pracownik fizyczny")
                    {
                        var Podstawa = p.StawkaGodz * 8 * Int32.Parse(Days);
                        if (Days == "20")
                        {
                            Wynagrodzenie = Podstawa + Int32.Parse(Premia);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: " + Wynagrodzenie);
                    if (age < 26)
                    {
                        Console.WriteLine("BRAK PODATKU");
                        Console.WriteLine("DO WYPŁATY: " + Wynagrodzenie);
                    }
                    else
                    {
                        Console.WriteLine("POTRĄCONY PODATEK (18%): " + Wynagrodzenie * 0.18);
                        Console.WriteLine("DO WYPŁATY: " + (Wynagrodzenie - Wynagrodzenie * 0.18));


                    }



                }
            }

        }
    }
}
