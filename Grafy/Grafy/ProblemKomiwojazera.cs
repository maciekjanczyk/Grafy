using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grafy;

public static class ProblemKomiwojazera
{
    public static bool CzyOdwiedzone<T>(List<Wezel<T>> V)
    {
        int ilosc = 0;

        foreach (Wezel<T> v in V)
            if (v.Odwiedzony)
                ilosc++;

        return ilosc == V.Count;
    }

    public static List<Wezel<T>> SzukajNieOdwiedzonychSasiadow<T>(Wezel<T> v)
    {
        List<Wezel<T>> ret = new List<Wezel<T>>();

        foreach (Wezel<T> s in v.Sasiedzi)
            if (!s.Odwiedzony)
                ret.Add(s);

        return ret;
    }

    public static List<Wezel<T>> SzukajDrogi<T>(Graf<T> graf, Wezel<T> v_start)
    {
        Graf<T> mst = MinDrzewoRozpinajace.Kruskal(graf);
        List<Wezel<T>> ret = new List<Wezel<T>>();
        List<Wezel<T>> V = mst.V;
        List<Krawedz<T>> G = mst.E;
        Wezel<T> v = v_start;

        foreach (Wezel<T> u in V)
            u.Czysc();

        while (!CzyOdwiedzone(V))
        {
            if (!v.Odwiedzony)
            {
                v.Odwiedz();
                ret.Add(v);
            }

            if (v.Sasiedzi.Count == 1)
                v = v.Sasiedzi[0];
            else
            {
                List<Wezel<T>> nieodwiedzeni = SzukajNieOdwiedzonychSasiadow(v);
                if (nieodwiedzeni.Count != 0)
                {
                    Wezel<T> min = nieodwiedzeni[0];
                    foreach (Wezel<T> s in nieodwiedzeni)
                        if (s.Sasiedzi.Count < min.Sasiedzi.Count)
                            min = s;
                    v = min;
                }
                else
                {
                    Wezel<T> max = v.Sasiedzi[0];
                    foreach (Wezel<T> s in v.Sasiedzi)
                        if (s.Sasiedzi.Count > max.Sasiedzi.Count)
                            max = s;
                    v = max;
                }
            }
        }

        ret.Reverse();
        return ret;
    }
}