using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    //- wszystkie podzbiory zbioru n-elementowego
    //- algorytm plecakowy

    public class Drzewo
    {
        public Drzewo p;
        public Drzewo l;
        public int wart;
        public int n;
        public int k;

        public Drzewo(int n, int k, int wart = default(int))
        {
            this.n = n;
            this.k = k;
            p = null;
            l = null;
            this.wart = wart;
        }
    }

    public static class AlgorytmPlecakowy
    {


        public static List<List<T>> WszystkiePodzbiory<T>(List<T> v, int n, int k)
        {
            List<List<T>> ret = new List<List<T>>();

            Drzewo d = BudujDrzewo(v, n, k);
            List<List<int>> r2 = new List<List<int>>();
            AnalizujDrzewo(d, r2, new List<int>(), n, false);
            foreach (List<int> l in r2)
            {
                foreach (int lb in l)
                    Console.Write("{0} ", lb);
                Console.WriteLine();
            }

            return ret;
        }

        public static Drzewo BudujDrzewo<T>(List<T> v, int n, int k)
        {
            Drzewo ret = new Drzewo(n, k, -1);
            Stack<Drzewo> wezly = new Stack<Drzewo>();

            wezly.Push(ret);

            while (wezly.Count > 0)
            {
                Drzewo w = wezly.Peek();
                int current_n = w.n;
                int current_k = w.k;

                if (w.n == 0)
                {
                    wezly.Pop();
                }
                else if (w.l != null && w.p != null)
                {
                    wezly.Pop();
                }
                else if (w.l == null)
                {
                    if (current_k < current_n)
                    {
                        w.l = new Drzewo(current_n - 1, current_k, 1);
                    }
                    else
                    {
                        w.l = new Drzewo(current_n - 1, current_k, 0);
                    }
                    wezly.Push(w.l);
                    Console.WriteLine("{0} {1} {2} L", w.l.wart, w.l.n, w.l.k);
                }
                else if (w.p == null)
                {
                    if (current_k > 0)
                    {
                        w.p = new Drzewo(current_n - 1, current_k - 1, 1);
                    }
                    else
                    {
                        w.p = new Drzewo(current_n - 1, current_k - 1, 0);
                    }
                    wezly.Push(w.p);
                    Console.WriteLine("{0} {1} {2} P", w.p.wart, w.p.n, w.p.k);
                }
            }            

            return ret;
        }

        public static void AnalizujDrzewo(Drzewo root, List<List<int>> rootList, List<int> currentList, int k, bool notfirst)
        {
            if (notfirst)
            {
                currentList.Add(root.wart);

                if (root.l == null && root.p == null)
                {
                    rootList.Add(currentList);
                    return;
                }
            }

            List<int> currentListCpy = new List<int>();
            currentList.ForEach(new Action<int>(e => currentListCpy.Add(e)));
            if (root.l != null)
            {
                AnalizujDrzewo(root.l, rootList, currentList, k, true);
            }

            if (root.p != null)
            {
                List<int> newList = new List<int>();
                currentListCpy.ForEach(new Action<int>(e => newList.Add(e)));
                AnalizujDrzewo(root.p, rootList, newList, k, true);
            }
        }
    }
}
