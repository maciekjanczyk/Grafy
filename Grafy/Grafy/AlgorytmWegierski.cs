using System;
using System.Collections.Generic;

namespace Grafy
{
	public class AlgorytmWegierski
	{
        private static void NajmWartWiersz(int[,] graf, List<int[]> ret)
        {
            int LEN = graf.GetLength(0);

            for (int i = 0; i < LEN; i++)
            {
                int[] pkt = new int[2];
                int wart = Int32.MaxValue;

                for (int j = 0; j < LEN; j++)
                {
                    if (graf[i, j] < wart)
                    {
                        pkt[0] = i;
                        pkt[1] = j;
                        wart = graf[i, j];
                    }
                }

                ret.Add(pkt);
            }
        }

        private static void OdejmijNajmniejsze(int[,] graf, List<int[]> najm)
        {
            int LEN = graf.GetLength(0);

            foreach (int[] pkt in najm)
            {
                int wiersz = pkt[0];
                int wart = graf[pkt[0], pkt[1]];

                for (int i = 0; i < LEN; i++)
                    graf[wiersz, i] -= wart;
            }
        }

        private static void NaprawZeraWKolumnach(int[,] graf)
        {
            int LEN = graf.GetLength(0);
            List<int> kolumnyBezZer = new List<int>();

            for (int i = 0; i < LEN; i++)
            {
                int ileLiczb = 0;
                for (int j = 0; j < LEN; j++)
                {
                    if (graf[j, i] == 0)
                        break;
                    else
                        ileLiczb++;
                }

                if (ileLiczb == LEN)
                    kolumnyBezZer.Add(i);
            }

            foreach (int i in kolumnyBezZer)
            {
                int najm = Int32.MaxValue;
                for (int j = 0; j < LEN; j++)
                    if (graf[j, i] < najm)
                        najm = graf[j, i];
                for (int j = 0; j < LEN; j++)
                    graf[j, i] -= najm;
            }
        }

        private static int[,] Skreslaj(int[,] graf, out int liczba, out int[,] mskreslen)
        {
            int[,] ret = new int[graf.GetLength(0), graf.GetLength(1)];
            int LEN = graf.GetLength(0);

            liczba = 0;

            List<int[]> wz = new List<int[]>(); // przechowuje numer wiersza/kolumny i ile zer w nim

            for (int i = 0; i < LEN; i++)
            {
                int ileZerW = 0;
                int ileZerK = 0;

                for (int j = 0; j < LEN; j++)
                {
                    if (graf[i, j] == 0)
                        ileZerW++;
                    if (graf[j, i] == 0)
                        ileZerK++;
                }

                if (ileZerW > 0)
                {
                    wz.Add(new int[] { i, ileZerW, 0 }); // 0 - wiersz
                }

                if (ileZerK > 0)
                {
                    wz.Add(new int[] { i, ileZerK, 1 }); // 1 - kolumna
                }
            }

            int ILE_W_MACIERZY = 0;

            for (int i = 0; i < LEN; i++)
                for (int j = 0; j < LEN; j++)
                    if (graf[i, j] == 0)
                        ILE_W_MACIERZY++;

            wz.Sort(new Comparison<int[]>((a1, a2) => { return a1[1] > a2[1] ? -1 : 1; } ));
            List<int> skresloneWiersze = new List<int>();
            List<int> skresloneKolumny = new List<int>();
            int[,] macierzSkreslen = new int[LEN, LEN];

            foreach (int[] pkt in wz)
            {
                if (pkt[2] == 0)
                {
                    int ileDa = 0;
                    for (int i = 0; i < LEN; i++)
                    {
                        if (graf[pkt[0], i] == 0 && macierzSkreslen[pkt[0], i] == 0)
                            ileDa++;
                    }
                    if (ileDa == 0)
                        continue;

                    for (int i = 0; i < LEN; i++)
                    {
                        macierzSkreslen[pkt[0], i] += 1;
                        if (graf[pkt[0], i] == 0 && macierzSkreslen[pkt[0], i] == 1)
                            ILE_W_MACIERZY--;
                    }
                    skresloneWiersze.Add(pkt[0]);                    
                }
                else
                {
                    int ileDa = 0;
                    for (int i = 0; i < LEN; i++)
                    {
                        if (graf[i, pkt[0]] == 0 && macierzSkreslen[i, pkt[0]] == 0)
                            ileDa++;
                    }
                    if (ileDa == 0)
                        continue;

                    for (int i = 0; i < LEN; i++)
                    {
                        macierzSkreslen[i, pkt[0]] += 1;
                        if (graf[i, pkt[0]] == 0 && macierzSkreslen[i, pkt[0]] == 1)
                            ILE_W_MACIERZY--;
                    }
                    skresloneKolumny.Add(pkt[0]);   
                }

                if (ILE_W_MACIERZY <= 0)
                    break;
            }

            liczba = skresloneWiersze.Count + skresloneKolumny.Count;
            mskreslen = macierzSkreslen;

            return ret;
        }

        public static int[,] Znajdz(int[,] graf)
        {
            if (graf.GetLength(0) != graf.GetLength(1))
                throw new Exception("Argument musi byc macierza kwadratowa!");

            int[,] _clone = (int[,])graf.Clone();
            int LENGTH = graf.GetLength(0);
            int SKRESLENIA = 0;

            while (SKRESLENIA != LENGTH)
            {
                List<int[]> najmWiersz = new List<int[]>();
                NajmWartWiersz(_clone, najmWiersz);
                OdejmijNajmniejsze(_clone, najmWiersz);
                NaprawZeraWKolumnach(_clone);
                int iloscSkreslen = 0;
                int[,] mskreslen = new int[LENGTH, LENGTH];
                Skreslaj(_clone, out iloscSkreslen, out mskreslen);
                //if (iloscSkreslen == LENGTH)
            }

            return _clone;
        }

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

