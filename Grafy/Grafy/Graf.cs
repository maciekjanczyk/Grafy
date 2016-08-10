using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Grafy
{
    public class Graf<T>
    {
        public List<Wezel<T>> V { get; set; }
        public List<Krawedz<T>> E { get; set; }
		public List<Krawedz<T>> Skojarzenia { get; set; }

		public Graf(List<Wezel<T>> V, List<Krawedz<T>> E, bool skierowany = false)
        {
            this.V = V;
            this.E = E;

			if (!skierowany)
				foreach (Wezel<T> v in this.V) {
					foreach (Krawedz<T> e in this.E) {
						if (e.Wezly.Contains (v))
							v.DodajSasiada (e.SasiedniWezel (v));
					}
				}
			else
				foreach (Krawedz<T> e in this.E) 
				{
					e.Wezly [0].DodajSasiada (e.Wezly [1]);
				}

			Skojarzenia = new List<Krawedz<T>> ();
			foreach (Krawedz<T> e in this.E)
				if (e.Skojarzenie)
					Skojarzenia.Add (e);
        }

        public void WyswietlWezly(TextWriter tw)
        {
            tw.WriteLine("Wezly:");
            tw.WriteLine("-------------------------------------------");
            tw.WriteLine("Nazwa:  Wartosc:  Odwiedzony:  Sasiedzi:");
            foreach (Wezel<T> v in V)
            {
                tw.Write("{0,-8}{1,-10}{2,-13}", v.Nazwa, v.Wart, v.Odwiedzony);
                foreach (Wezel<T> vv in v.Sasiedzi)
                    tw.Write("{0} ", vv.Nazwa);
                tw.WriteLine();
            }
        }

        public void WyswietlKrawedzie(TextWriter tw)
        {
            tw.WriteLine("Krawedzie:");
            tw.WriteLine("-------------------------------------------");
            tw.WriteLine("Wezel.1:  Wezel.2:  Waga:  Skojarzenie:  Kierunek:");
            foreach (Krawedz<T> e in E)
            {
                tw.WriteLine("{0,-10}{1,-10}{2,-7}{3,-14}{4}", e.Wezly[0].Nazwa,
                    e.Wezly[1].Nazwa, e.Waga, e.Skojarzenie, e.Kierunek);
            }
        }

        public int SumaWag()
        {
            int ret = 0;
            foreach (Krawedz<T> e in E)
                ret += e.Waga;
            return ret;
        }

        public void CzyscKolory()
        {
            foreach (Wezel<T> v in V)
                v.Czysc();
        }

        public void CzyscSasiadow()
        {
            foreach (Wezel<T> v in V)
                v.CzyscSasiadow();
        }
    }
}
