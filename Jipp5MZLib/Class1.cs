using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jipp5MZLib
{
    public abstract class Napoj
    {
        protected abstract double Cena { get; set; }
        protected abstract double Pojemnosc { get; set; }
        protected double Zawartosc; //Zawartosc/Pojemnosc - ile zostało napoju

        public Napoj()
        {
            Zawartosc = Pojemnosc;
        }

        public abstract void Otworz();

        public event Action NapojPusty; //uzylem Action bo inaczej trzeba by bylo tworzyc delegate public delegate void MojaDelegata();

        public void Wypij(double iloscDoWypicia)
        {
            Zawartosc -= iloscDoWypicia;
            if (Zawartosc <= 0)
            {
                if (NapojPusty != null) //jesli tego nie sprawdze, a do zdarzenia nie jest przypisana zadna funkcja to wywali bledem
                {
                    NapojPusty();
                }
            }
        }
    }
    public class Cola : Napoj
    {
        double cena = 2;
        protected override double Cena { get => cena; set => cena = value; }
        double pojemnosc = 0.33;
        protected override double Pojemnosc { get => pojemnosc; set => pojemnosc = value; }

        public override void Otworz()
        {
            Console.WriteLine("Otwarto puszkę");
        }
        public Cola() : base()
        {
            NapojPusty += Cola_NapojPusty;
        }

        private void Cola_NapojPusty()
        {
            Console.WriteLine("Napoj pusty - zgnieć puszkę i wyrzuć do śmietnika");
        }
    }

    public class Cappy : Napoj
    {
        double cena = 2;
        protected override double Cena { get => cena; set => cena = value; }
        double pojemnosc = 0.33;
        protected override double Pojemnosc { get => pojemnosc; set => pojemnosc = value; }

        public override void Otworz()
        {
            Console.WriteLine("Otwarto butelkę");
        }

        public Cappy() : base()
        {
            NapojPusty += Cappy_NapojPusty;
        }

        private void Cappy_NapojPusty()
        {
            Console.WriteLine("Napoj pusty - zgnieć butelkę i wyrzuć do śmietnika");
        }
    }


}
