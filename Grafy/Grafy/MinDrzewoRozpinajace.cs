using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    public class MinDrzewoRozpinajace
    {
        public static List<Krawedz<T>> SortujPoWagach<T>(List<Krawedz<T>> E)
        {
            List<Krawedz<T>> ret = new List<Krawedz<T>>(E);
            ret.Sort(new Comparison<Krawedz<T>>((k1,k2) =>
                { return k1.Waga > k2.Waga ? 1 : -1; }));
            return ret;
        }

        public static Graf<T> Kruskal<T>(Graf<T> graf)
        {
            List<Wezel<T>> V = new List<Wezel<T>>(graf.V);
            foreach (Wezel<T> v in V)
                v.CzyscSasiadow();
            List<Krawedz<T>> E = SortujPoWagach<T>(graf.E);
            List<Krawedz<T>> E_w = new List<Krawedz<T>>();

            foreach (Krawedz<T> e in E)
            {
                KolorujBFS<T>(new Graf<T>(V, E_w), e.Wezly[0], true);
                if (!(e.Wezly[0].Odwiedzony && e.Wezly[1].Odwiedzony))
                {
                    E_w.Add(e);
                    e.Wezly[0].DodajSasiada(e.Wezly[1]);
                    e.Wezly[1].DodajSasiada(e.Wezly[0]);
                }
            }

            foreach (Wezel<T> v in V)
                v.CzyscSasiadow();
            return new Graf<T>(V, E_w);
        }
        
        public static bool KolorujBFS<T>(Graf<T> graf, Wezel<T> start, bool czyszczenie)
        {
            if (czyszczenie)
                graf.CzyscKolory();
            if (start.Odwiedzony)
                return true;
            
            start.Odwiedz();
            foreach (Wezel<T> sasiad in start.Sasiedzi)
                KolorujBFS<T>(graf, sasiad, false);
         
            return true;
        }

		public static List<Wezel<T>> BFS<T>(Graf<T> graf)
		{
			Queue<Wezel<T>> kolejka = new Queue<Wezel<T>> ();
			List<Wezel<T>> odwiedzone = new List<Wezel<T>> ();

			if (graf.V.Count < 2 || graf == null)
				return null;

			kolejka.Enqueue (graf.V [0]);

			while (kolejka.Count > 0) 
			{
				Wezel<T> w = kolejka.Dequeue ();
				odwiedzone.Add (w);
				foreach (Wezel<T> sasiad in w.Sasiedzi)
					if (!odwiedzone.Contains(sasiad) && !kolejka.Contains(sasiad))
						kolejka.Enqueue (sasiad);
			}				

			return odwiedzone;
		}
    }
}
