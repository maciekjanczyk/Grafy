using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    //- wszystkie podzbiory zbioru n-elementowego
    //- algorytm plecakowy    

    public class Przedmiot
    {
        public string Nazwa { get; set; }
        public int Wartosc { get; set; }
        public int Waga { get; set; }
    }

    public static class AlgorytmPlecakowy
    {        
        private static void Podzbior<T>(List<T> A, int k, int start, int currLen, bool[] used, List<List<T>> ret)
        {
            if (currLen == k)
            {
                List<T> malaLista = new List<T>();

                for (int i = 0; i < A.Count; i++)
                {
                    if (used[i] == true)
                    {
                        malaLista.Add(A[i]);
                    }
                }

                ret.Add(malaLista);

                return;
            }

            if (start == A.Count)
            {
                return;
            }

            used[start] = true;
            Podzbior(A, k, start + 1, currLen + 1, used, ret);

            used[start] = false;
            Podzbior(A, k, start + 1, currLen, used, ret);
        }

        public static List<List<T>> WszystkiePodzbiory<T>(List<T> v, int k)
        {
            List<List<T>> ret = new List<List<T>>();
            bool[] used = new bool[v.Count];
            Podzbior(v, k, 0, 0, used, ret);

            return ret;
        }       
        
        public static List<Przedmiot> Run(List<Przedmiot> przedmioty, int wielkosc)
        {
            List<Przedmiot> ret = null;
            List<List<Przedmiot>> wszystkiePodzbiory = new List<List<Przedmiot>>();

            for (int i = 1; i <= przedmioty.Count; i++)
            {
                List<List<Przedmiot>> podzbior = WszystkiePodzbiory(przedmioty, i);

                foreach (List<Przedmiot> l in podzbior)
                {
                    wszystkiePodzbiory.Add(l);
                }
            }

            int najwyzszaWaga = -1;
            int najwyzszaWartosc = -1;
            int najwyzszaIlosc = -1;

            foreach (List<Przedmiot> podzbior in wszystkiePodzbiory)
            {
                int obecnaWaga = 0;
                int obecnaWartosc = 0;
                int obecnaIlosc = podzbior.Count;

                foreach (Przedmiot przedmiot in podzbior)
                {
                    obecnaWaga += przedmiot.Waga;
                    obecnaWartosc += przedmiot.Wartosc;
                }

                if (obecnaWaga <= wielkosc && obecnaWaga >= najwyzszaWaga)
                {
                    if (obecnaWaga != najwyzszaWaga)
                    {
                        ret = podzbior;
                        najwyzszaWaga = obecnaWaga;
                        najwyzszaIlosc = obecnaIlosc;
                    }
                    else
                    {
                        if (obecnaWartosc > najwyzszaWartosc)
                        {
                            ret = podzbior;
                            najwyzszaWaga = obecnaWaga;
                            najwyzszaIlosc = obecnaIlosc;
                        }
                        else if (obecnaWartosc == najwyzszaWartosc)
                        {
                            if (obecnaIlosc > najwyzszaIlosc)
                            {
                                ret = podzbior;
                                najwyzszaWaga = obecnaWaga;
                                najwyzszaIlosc = obecnaIlosc;
                            }
                        }
                    }
                }
            }

            return ret;
        } 
    }
}
