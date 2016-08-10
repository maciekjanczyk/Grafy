using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    public static class CyklEulera
    {
        public static Queue<Wezel<T>> Run<T>(Graf<T> graf, Wezel<T> start)
        {
            if (!graf.V.Contains(start))
                return null;

            Stack<Wezel<T>> stos = new Stack<Wezel<T>>();
            Queue<Wezel<T>> kolejka = new Queue<Wezel<T>>();
            List<Krawedz<T>> krawedzie = new List<Krawedz<T>>(graf.E);

            Wezel<T> biezacy = start;
            stos.Push(biezacy);

            while (stos.Count != 0)
            {
                biezacy = stos.Peek();
                Krawedz<T> dostepnaDroga = null;

                foreach (Krawedz<T> k in krawedzie)
                    if (k.CzyZawiera(biezacy))
                    {
                        dostepnaDroga = k;
                        break;
                    }

                if (dostepnaDroga == null)
                {
                    stos.Pop();
                    kolejka.Enqueue(biezacy);
                }
                else
                {
                    Wezel<T> sasiadBiezacego = dostepnaDroga.SasiedniWezel(biezacy);
                    stos.Push(sasiadBiezacego);
                    krawedzie.Remove(dostepnaDroga);
                }
            }

            return kolejka;
        }
    }
}
