using System;
using System.Collections.Generic;

namespace Grafy
{
	public class MaksymalneSkojarzenie
	{
		public static List<Wezel<T>> ZnajdzDrogeRozszerzajaca<T>(List<Wezel<T>> V1, List<Wezel<T>> V2, List<Krawedz<T>> E)
		{
			List<Wezel<T>> V1prim = new List<Wezel<T>> ();
			List<Wezel<T>> V2prim = new List<Wezel<T>> ();
			List<Wezel<T>> Vtmp = new List<Wezel<T>> (V1);
			Vtmp.AddRange (V2);
			List<Krawedz<T>> Etmp = new List<Krawedz<T>> (E);
            //foreach (Krawedz<T> e in E)
            //    Etmp.Add(new Krawedz<T>(e.Wezly[0], e.Wezly[1], e.Waga, e.Skojarzenie));

			foreach (Krawedz<T> e in Etmp)
				e.NadajKierunek ();

			Graf<T> graf = new Graf<T> (Vtmp, Etmp, true);

			foreach (Krawedz<T> e in E) 
			{
				if (!e.Skojarzenie) 
				{
					if (!V1prim.Contains (e.Wezly [0]))
						V1prim.Add (e.Wezly [0]);
					if (!V2prim.Contains (e.Wezly [1]))
						V2prim.Add (e.Wezly [1]);
				}
			}

			//List<Wezel<T>> droga = MinDrzewoRozpinajace.BFS<T> (graf);
            List<Wezel<T>> droga = new List<Wezel<T>>();

            Wezel<T> u = V1prim[0];


			bool dojscieV1p = false;
			bool dojscieV2p = false;

			foreach (Wezel<T> w in droga) 
			{
				if (dojscieV1p && dojscieV2p)
					break;

				if (V1prim.Contains (w))
					dojscieV1p = true;
				if (V2prim.Contains (w))
					dojscieV2p = true;
			}

			if (!(dojscieV1p || dojscieV2p))
				return null;            

			return droga;
		}
	}
}

