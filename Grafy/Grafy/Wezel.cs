using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    public class Wezel<T>
    {
        public T Wart { get; private set; }
        public List<Wezel<T>> Sasiedzi { get; private set; }
        public string Nazwa { get; private set; }
        public bool Odwiedzony { get; private set; }
        public string Kolor { get; set; }
		public bool Wolny { get; private set; }

        public Wezel(string nazwa, T wart)
        {
            Odwiedzony = false;
			Wolny = true;
            Wart = wart;
            Nazwa = nazwa;
            Sasiedzi = new List<Wezel<T>>();
            Kolor = "";
        }

        public void Odwiedz()
        {
            Odwiedzony = true;
        }

        public void CzyscSkreslenie()
        {
            Odwiedzony = false;
        }

        public bool DodajSasiada(Wezel<T> sasiad)
        {
            if (Sasiedzi.Contains(sasiad))
                return false;
            else
                Sasiedzi.Add(sasiad);
            return true;
        }

        public void Czysc()
        {
            Odwiedzony = false;
            Kolor = "";
        }

        public void CzyscSasiadow()
        {
            Sasiedzi = new List<Wezel<T>>();
        }

        public void Koloruj(string kolor)
        {
            Kolor = kolor;
        }

		public void Etykietuj(T wart)
		{
			Wart = wart;
		}

		public void DodajSkojarzenie()
		{
			Wolny = false;
		}

		public void ZdejmijSkojarzenie()
		{
			Wolny = true;
		}
    }
}
