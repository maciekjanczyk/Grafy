using System;
using System.Collections.Generic;

namespace Grafy
{
	public class MaksymalneSkojarzenie
	{
        public static List<int> ZnajdzDrogePowiekszajaca(int[,] mat)
        {
            List<int> ret = new List<int>();
            int LENGTH = (int)Math.Sqrt((double)mat.Length);

            // lewa strona - pierwszy index, prawa - drugi index
            // 0 - brak drogi, 1 - droga, 2 - skojarzenie

            for (int loop_main = 0; loop_main < LENGTH; loop_main++)
            {
                int i = loop_main;

                // patrzymy czy obecny wierzcholek jest wolny
                int wolny = 0;
                for (int k = 0; k < LENGTH; k++)
                    if (mat[i, k] == 2)
                    {
                        wolny = 0;
                        break;
                    }
                    else if (mat[i, k] == 1)
                    {
                        wolny++;
                    }

                if (wolny <= 0)
                    continue;

                List<int> currWay = new List<int>();

                int skojarzenie = 1; // jak bedzie po skojarzeniu to 2
                int obecny_w = loop_main;
                int strona = 0; // lewa strona
                wolny = 1; // jestesmy teraz w wolnym wierzcholku
                currWay.Add(obecny_w);

                while (true)
                {
                    int _cnt = 0;

                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (strona == 0)
                        {
                            if (mat[obecny_w, j] == skojarzenie)
                            {                                
                                if (currWay.Contains(j + LENGTH))
                                    continue;
                                currWay.Add(j + LENGTH);
                                obecny_w = j;
                                _cnt = 1;
                                break;
                            }
                        }
                        else if (strona == 1)
                        {
                            if (mat[j, obecny_w] == skojarzenie)
                            {
                                if (currWay.Contains(j))
                                    continue;
                                currWay.Add(j);
                                obecny_w = j;
                                _cnt = 1;
                                break;
                            }
                        }
                    }

                    if (_cnt == 0)
                        break;

                    if (skojarzenie == 1)
                        skojarzenie = 2;
                    else
                        skojarzenie = 1;
                    if (strona == 0)
                        strona = 1;
                    else
                        strona = 0;
                    if (wolny == 1)
                        wolny = 0;
                    else
                        wolny = 1;
                }

                if (ret.Count < currWay.Count)
                    ret = currWay;
            }

            return ret;
        }

        private static List<int[]> DrogaNaParyPunktow(List<int> droga)
        {
            List<int[]> ret = new List<int[]>();

            for (int i = 1; i < droga.Count; i++)
            {
                int[] pkt = new int[2];
                if (i % 2 == 1)
                {
                    pkt[0] = droga[i - 1];
                    pkt[1] = droga[i];
                }
                else
                {
                    pkt[1] = droga[i - 1];
                    pkt[0] = droga[i];
                }
                ret.Add(pkt);
            }

            return ret;
        }

        public static int[,] Znajdz(int[,] graf)
        {
            int LENGTH = (int)Math.Sqrt((double)graf.Length);
            int[,] ret = (int[,])graf.Clone();            

            while (true)
            {
                List<int> dp = ZnajdzDrogePowiekszajaca(ret);
                if (dp.Count == 0)
                    break;

                List<int[]> punkty = DrogaNaParyPunktow(dp);

                foreach (int[] pkt in punkty)
                {
                    if (ret[pkt[0], pkt[1] - LENGTH] == 1)
                        ret[pkt[0], pkt[1] - LENGTH] = 2;
                    else if (ret[pkt[0], pkt[1] - LENGTH] == 2)
                        ret[pkt[0], pkt[1] - LENGTH] = 1;
                }
            }

            return ret;
        }

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

