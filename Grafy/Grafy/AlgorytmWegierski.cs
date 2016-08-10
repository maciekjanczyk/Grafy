using System;
using System.Collections.Generic;

namespace Grafy
{
	public class AlgorytmWegierski
	{
		public static List<List<Wezel<T>>> OddzielZbiory<T>(Graf<T> graf, bool pierwszyWiekszy = true)
		{
			List<List<Wezel<T>>> ret = new List<List<Wezel<T>>> ();
			List<Wezel<T>> V1 = new List<Wezel<T>> ();
			List<Wezel<T>> V2 = new List<Wezel<T>> ();
			Wezel<T>[] tabv1;
			Wezel<T>[] tabv2;

			if (graf.V.Count % 2 == 0) 
			{
				int ilosc = graf.V.Count / 2;
				tabv1 = new Wezel<T>[ilosc];
				tabv2 = new Wezel<T>[ilosc];

				graf.V.CopyTo (0, tabv1, 0, ilosc);
				graf.V.CopyTo (ilosc, tabv2, 0, ilosc);
			}
			else 
			{
				int ilosc = graf.V.Count / 2;

				if (pierwszyWiekszy) 
				{
					tabv1 = new Wezel<T>[ilosc + 1];
					tabv2 = new Wezel<T>[ilosc];

					graf.V.CopyTo (0, tabv1, 0, ilosc + 1);
					graf.V.CopyTo (ilosc + 1, tabv2, 0, ilosc);
				}
				else 
				{
					tabv1 = new Wezel<T>[ilosc];
					tabv2 = new Wezel<T>[ilosc + 1];

					graf.V.CopyTo (0, tabv1, 0, ilosc);
					graf.V.CopyTo (ilosc, tabv2, 0, ilosc + 1);
				}
			}

			V1.AddRange (tabv1);
			V2.AddRange (tabv2);
			ret.Add (V1);
			ret.Add (V2);

			return ret;
		}

		public static void PoczatkoweWartosciEtykiet(Graf<int> graf, bool pierwszyWiekszy)
		{
			List<List<Wezel<int>>> zbiorV = OddzielZbiory (graf, pierwszyWiekszy);
			List<Wezel<int>> V1 = zbiorV [0];
			List<Wezel<int>> V2 = zbiorV [1];

			foreach (Wezel<int> v in V2)
				v.Etykietuj(0);

			foreach (Wezel<int> v in V1)
				v.Etykietuj(0);

			foreach (Krawedz<int> e in graf.E)
			{
				Wezel<int> vtmp = V1.Contains(e.Wezly[0]) ? e.Wezly[0] : e.Wezly[1];
				vtmp.Etykietuj(Math.Max(e.Waga, vtmp.Wart));
			}
		}

		public static void SkojarzeniePoczatkowe<T>(Graf<T> graf)
		{
			int N = graf.V.Count;
			int[] mate = new int[N];
			int expo = N;
			List<Wezel<T>> V = graf.V;

			for (int i = 0; i < mate.Length; i++)
				mate[i] = -1;

			foreach (Wezel<T> u in V)
			{
				int idx = V.IndexOf(u);

				if (mate[idx] == -1)
				{
					foreach (Wezel<T> v in u.Sasiedzi)
					{
						if (v.Wolny)
						{
							int idx2 = V.IndexOf(v);

                            if (mate[idx2] == -1)
                            {
                                mate[idx] = idx2;
                                mate[idx2] = idx;
                                u.DodajSkojarzenie();
                                v.DodajSkojarzenie();

                                foreach (Krawedz<T> e in graf.E)
                                {
                                    if (e.CzyZawiera(u, v))
                                    {
                                        e.NadajSkojarzenie();
                                        break;
                                    }
                                }							

                                expo -= 2;
                                break;
                            }
						}
					}
				}
			}
		}

        public static void KuhnMunkers(Graf<int> graf, bool pierwszyWiekszy)
        {
            List<Wezel<int>> V = graf.V;
            List<Krawedz<int>> E = graf.E;

            krok1:
            PoczatkoweWartosciEtykiet(graf, pierwszyWiekszy);
            SkojarzeniePoczatkowe(graf);

            krok2:
            // skojarzenie pelne tutaj!!!

            // N(S) zbior wierzcholkow V1 polaczonych krawedzia z jednym z wierzcholkow z S
            Wezel<int> u = null;
            foreach (Wezel<int> uu in V)
                if (uu.Wolny)
                {
                    u = uu;
                    break;
                }

            List<Wezel<int>> S = new List<Wezel<int>>();
            List<Wezel<int>> T = new List<Wezel<int>>();
            S.Add(u);

            krok3:
            // if (N(S) == T)
            int N_S = 0;
            foreach (Wezel<int> w in V)
                if ((!w.Wolny))
                    foreach (Krawedz<int> k in E)
                        if (k.CzyZawiera(w) && k.Skojarzenie && T.Contains(k.SasiedniWezel(w)))
                        {
                            N_S++;
                            break;
                        }

            if (N_S == S.Count)
            {
                
            }
            else
            {
                
            }
        }
	}
}

