using System.Data;
using System.Threading.Channels;
using ZakładPracy;

var Massage = new Massage();

Massage.ShowStartScreen();

if (Massage.answer == "1")
{   
    Console.Clear();
    Massage.DisplayPerson();
    Massage.ShowStartScreen();
}

if (Massage.answer == "2")
{
    Console.Clear();
    Console.WriteLine("PROSZĘ PODAĆ ID PRACOWNIKA DLA KTÓREGO ZOSTANIE WYLICZONE WYNAGRODZENIE:");
    Massage.answer = Console.ReadLine();
    
    Massage.FindPerson();
}
