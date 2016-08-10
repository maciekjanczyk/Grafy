using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    public class Mrowka<T>
    {
        public Wezel<T> ObecnaPozycja { get; private set; }
        public List<Wezel<T>> Tabu { get; private set; }
        public double Parowanie { get; private set; }

        public Mrowka(Wezel<T> poz, double parowanie)
        {
            ObecnaPozycja = poz;
            Parowanie = parowanie;
        }

        public void IdzDalej()
        {
            foreach (Krawedz<T> k in ObecnaPozycja.)
        }
    }

    public static class AlgorytmMrowkowy
    {
    }
}
