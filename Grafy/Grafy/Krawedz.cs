using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    public class Krawedz<T>
    {
        public List<Wezel<T>> Wezly { get; private set; }
        public int Waga { get; private set; }
		public bool Skojarzenie { get; private set; }
        public bool Kierunek { get; private set; }

        // dla algorytmu mrowkowego
        public double Prawdopodobienstwo { get; private set; }
        public int Feromony { get; private set; }

		public Krawedz(Wezel<T> w1, Wezel<T> w2, int waga, bool skojarzenie = false)
        {
            Wezly = new List<Wezel<T>>();
            Wezly.Add(w1);
            Wezly.Add(w2);
            Waga = waga;
			Skojarzenie = skojarzenie;
            Kierunek = false;
        }

        public Wezel<T> SasiedniWezel(Wezel<T> w)
        {
            if (!Wezly.Contains(w))
                return null;
            else if (Wezly[0] == w)
                return Wezly[1];
            else
                return Wezly[0];
        }

        public bool CzyZawiera(Wezel<T> w)
        {
            return Wezly.Contains(w);
        }

        public bool CzyZawiera(Wezel<T> w1, Wezel<T> w2)
        {
            bool b1 = Wezly.Contains(w1);
            bool b2 = Wezly.Contains(w2);
            return b1 && b2 ? true : false;
        }

		public bool Porownaj(Krawedz<T> k)
		{
			Wezel<T> w1 = k.Wezly [0];
			Wezel<T> w2 = k.Wezly [1];
			return CzyZawiera (w1, w2);
		}

		public void NadajSkojarzenie()
		{
			Skojarzenie = true;
		}

		public void ZdejmijSkojarzenie()
		{
			Skojarzenie = false;
		}

		public void NadajKierunek(Wezel<T> w1 = null, Wezel<T> w2 = null)
		{			
			if (w1 == null) 
			{
				w1 = Wezly [1];
				w2 = Wezly [0];
			}

			Wezly = new List<Wezel<T>> ();

			if (Skojarzenie) 
			{
				Wezly.Add (w1);
				Wezly.Add (w2);
			} 
			else 
			{
				Wezly.Add (w2);
				Wezly.Add (w1);
			}

            Kierunek = true;
		}
    }
}
