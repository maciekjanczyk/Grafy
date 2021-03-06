﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grafy
{
    class Program
    {
        static void UzupelnijDaneV(List<Wezel<int>> V)
        {
            Random rand = new Random();

            for (char n = 'a'; n <= 'i'; n++)
            {
                string nazwa = Convert.ToString(n);
                V.Add(new Wezel<int>(nazwa, rand.Next(10)));
            }
        }

        static void UzupelnijDaneVDlaCykluEulera(List<Wezel<int>> V)
        {
            Random rand = new Random();

            for (char n = 'a'; n <= 'e'; n++)
            {
                string nazwa = Convert.ToString(n);
                V.Add(new Wezel<int>(nazwa, rand.Next(10)));
            }

            // dodatkowe
            V.Add(new Wezel<int>("f", rand.Next(10)));
            V.Add(new Wezel<int>("g", rand.Next(10)));
        }

        static void UzupelnijDaneVDlaCykluEulera2(List<Wezel<int>> V)
        {
            Random rand = new Random();

            for (char n = '0'; n <= '5'; n++)
            {
                string nazwa = Convert.ToString(n);
                V.Add(new Wezel<int>(nazwa, rand.Next(10)));
            }
        }

        static void UzupelnijDaneEDlaCykluEulera2(List<Wezel<int>> V, List<Krawedz<int>> E)
        {
            E.Add(new Krawedz<int>(V[0], V[4], 4, false));
            E.Add(new Krawedz<int>(V[0], V[1], 5, false));
            E.Add(new Krawedz<int>(V[1], V[3], 4, false));
            E.Add(new Krawedz<int>(V[2], V[3], 4, false));
            E.Add(new Krawedz<int>(V[1], V[4], 4, false));
            E.Add(new Krawedz<int>(V[1], V[2], 4, false));
            E.Add(new Krawedz<int>(V[2], V[5], 4, false));
            E.Add(new Krawedz<int>(V[4], V[5], 4, false));
            E.Add(new Krawedz<int>(V[1], V[5], 4, false));
            E.Add(new Krawedz<int>(V[2], V[4], 4, false));
            
        }

        static void UzupelnijDaneE(List<Wezel<int>> V, List<Krawedz<int>> E)
        {
            E.Add(new Krawedz<int>(V[0], V[1], 4, false));
            E.Add(new Krawedz<int>(V[0], V[7], 8, false));
            E.Add(new Krawedz<int>(V[1], V[7], 11, false));
            E.Add(new Krawedz<int>(V[1], V[2], 8, false));
            E.Add(new Krawedz<int>(V[6], V[7], 1, false));
            E.Add(new Krawedz<int>(V[7], V[8], 7, false));
            E.Add(new Krawedz<int>(V[6], V[8], 6, false));
            E.Add(new Krawedz<int>(V[2], V[8], 2, false));
            E.Add(new Krawedz<int>(V[2], V[3], 7, false));
            E.Add(new Krawedz<int>(V[5], V[6], 2, false));
            E.Add(new Krawedz<int>(V[2], V[5], 4, false));
            E.Add(new Krawedz<int>(V[3], V[5], 14, false));
            E.Add(new Krawedz<int>(V[3], V[4], 9, false));
            E.Add(new Krawedz<int>(V[4], V[5], 10, false));
        }

        static void UzupelnijDaneEDlaCykluEulera(List<Wezel<int>> V, List<Krawedz<int>> E)
        {                        
            E.Add(new Krawedz<int>(V[0], V[1], 4, false));
            E.Add(new Krawedz<int>(V[0], V[2], 4, false));
            E.Add(new Krawedz<int>(V[1], V[2], 4, false));
            E.Add(new Krawedz<int>(V[2], V[3], 4, false));
            E.Add(new Krawedz<int>(V[2], V[4], 4, false));
            E.Add(new Krawedz<int>(V[3], V[4], 4, false));
            
            // dodatkowe krawedzie
            E.Add(new Krawedz<int>(V[0], V[3], 4, false));
            E.Add(new Krawedz<int>(V[1], V[4], 4, false));
            E.Add(new Krawedz<int>(V[0], V[5], 4, false));
            E.Add(new Krawedz<int>(V[5], V[3], 4, false));
            E.Add(new Krawedz<int>(V[1], V[6], 4, false));
            E.Add(new Krawedz<int>(V[6], V[4], 4, false));
        }

		static void UzupelnijDaneVDlaBFS(List<Wezel<int>> V)
		{
			Random rand = new Random();

			for (char n = '1'; n <= '6'; n++)
			{
				string nazwa = Convert.ToString(n);
				V.Add(new Wezel<int>(nazwa, rand.Next(10)));
			}
		}

		static void UzupelnijDaneEDlaBFS(List<Wezel<int>> V, List<Krawedz<int>> E)
		{                        
			E.Add(new Krawedz<int>(V[0], V[1], 4, false));
			E.Add(new Krawedz<int>(V[0], V[2], 4, false));
			E.Add(new Krawedz<int>(V[1], V[4], 4, false));
			E.Add(new Krawedz<int>(V[1], V[3], 4, false));
			E.Add(new Krawedz<int>(V[2], V[3], 4, false));
			E.Add(new Krawedz<int>(V[2], V[5], 4, false));
			E.Add(new Krawedz<int>(V[3], V[0], 4, false));
			E.Add(new Krawedz<int>(V[4], V[3], 4, false));
		}

		static void UzupelnijDaneVDlaDrogiRozszerzajacej(List<Wezel<int>> V1, List<Wezel<int>> V2)
		{
			Random rand = new Random();

			for (char n = '1'; n <= '4'; n++)
			{
				string nazwa = Convert.ToString(n);
				V1.Add(new Wezel<int>(nazwa, rand.Next(10)));
			}

			for (char n = '5'; n <= '8'; n++)
			{
				string nazwa = Convert.ToString(n);
				V2.Add(new Wezel<int>(nazwa, rand.Next(10)));
			}
		}

		static void UzupelnijDaneEDlaDrogiRozszerzajacej(List<Wezel<int>> V1, List<Wezel<int>> V2, List<Krawedz<int>> E)
		{                        
			E.Add (new Krawedz<int> (V1 [0], V2 [1], 4));
			E.Add (new Krawedz<int> (V1 [0], V2 [2], 4, true));
			E.Add (new Krawedz<int> (V1 [1], V2 [0], 4, true));
			E.Add (new Krawedz<int> (V1 [1], V2 [2], 4));
			E.Add (new Krawedz<int> (V1 [2], V2 [1], 4, true));
			E.Add (new Krawedz<int> (V1 [2], V2 [3], 4));
			E.Add (new Krawedz<int> (V1 [3], V2 [0], 4));
			E.Add (new Krawedz<int> (V1 [3], V2 [3], 4, true));
		}

		static void UzupelnijDaneVDlaAKM(List<Wezel<int>> V)
		{
			Random rand = new Random();

			for (char n = '1'; n <= '6'; n++)
			{
				string nazwa = Convert.ToString(n);
				V.Add(new Wezel<int>(nazwa, rand.Next(10)));
			}
		}

		static void UzupelnijDaneEDlaAKM(List<Wezel<int>> V, List<Krawedz<int>> E)
		{
			E.Add (new Krawedz<int> (V[0], V[3], 4));
			E.Add (new Krawedz<int> (V[0], V[5], 1));
			E.Add (new Krawedz<int> (V[1], V[4], 8));
			E.Add (new Krawedz<int> (V[1], V[5], 6));
			E.Add (new Krawedz<int> (V[2], V[3], 1));
			E.Add (new Krawedz<int> (V[2], V[4], 6));
		}

        static void UzupelnijDaneVDlaKomiwojazera(List<Wezel<int>> V)
        {
            Random rand = new Random();

            V.Add(new Wezel<int>("Medford", rand.Next(10)));    // 0
            V.Add(new Wezel<int>("Arlington", rand.Next(10)));  // 1
            V.Add(new Wezel<int>("Somerville", rand.Next(10))); // 2
            V.Add(new Wezel<int>("Everett", rand.Next(10)));    // 3
            V.Add(new Wezel<int>("Belmont", rand.Next(10)));    // 4
            V.Add(new Wezel<int>("Cambridge", rand.Next(10)));  // 5
        }

        static void UzupelnijDaneEDlaKomiwojazera(List<Wezel<int>> V, List<Krawedz<int>> E)
        {
            E.Add(new Krawedz<int>(V[0], V[1], 11));
            E.Add(new Krawedz<int>(V[0], V[3], 9));
            E.Add(new Krawedz<int>(V[0], V[2], 9));
            E.Add(new Krawedz<int>(V[0], V[4], 15));
            E.Add(new Krawedz<int>(V[0], V[5], 16));
            E.Add(new Krawedz<int>(V[1], V[2], 10));
            E.Add(new Krawedz<int>(V[1], V[4], 10));
            E.Add(new Krawedz<int>(V[1], V[3], 14));
            E.Add(new Krawedz<int>(V[1], V[5], 15));
            E.Add(new Krawedz<int>(V[2], V[3], 6));
            E.Add(new Krawedz<int>(V[2], V[4], 9));
            E.Add(new Krawedz<int>(V[2], V[5], 10));
            E.Add(new Krawedz<int>(V[3], V[4], 13));
            E.Add(new Krawedz<int>(V[3], V[5], 11));
            E.Add(new Krawedz<int>(V[4], V[5], 8));
        }

        static void MSTMain()
        {
            List<Wezel<int>> V = new List<Wezel<int>>();
            List<Krawedz<int>> E = new List<Krawedz<int>>();
            UzupelnijDaneV(V);
            UzupelnijDaneE(V, E);

            // tworzenie i wyswietlenie grafu
			Graf<int> graf = new Graf<int>(V, E, true);
            graf.WyswietlWezly(Console.Out);
            Console.WriteLine();
            graf.WyswietlKrawedzie(Console.Out);

            // wyswietlenie sumy wszystkich wag
            Console.WriteLine("\nSuma wag: {0}", graf.SumaWag());

            // testowanie sortowania
            List<Krawedz<int>> E_sort = MinDrzewoRozpinajace.SortujPoWagach<int>(E);
            Console.WriteLine("\nPosortowane krawedzie:");
            foreach (Krawedz<int> e in E_sort)
                Console.WriteLine("{0},{1},{2} ", e.Wezly[0].Nazwa,
                    e.Wezly[1].Nazwa, e.Waga);

            // minimalne drzewo rozpinajace - kruskal : tworzenie i wysw.
            Graf<int> mdr = MinDrzewoRozpinajace.Kruskal<int>(graf);
            Console.WriteLine("\nMinimalne drzewo rozpinajace:");
            mdr.WyswietlWezly(Console.Out);
            Console.WriteLine();
            mdr.WyswietlKrawedzie(Console.Out);
        }

        static void KomiwojazerMain(string[] args = null)
        {
            List<Wezel<int>> V = new List<Wezel<int>>();
            List<Krawedz<int>> E = new List<Krawedz<int>>();

			UzupelnijDaneVDlaKomiwojazera(V);
			UzupelnijDaneEDlaKomiwojazera(V, E);

			Graf<int> graf = new Graf<int>(V, E, false);
			/*AlgorytmWegierski.PoczatkoweWartosciEtykiet(graf, true);
			AlgorytmWegierski.SkojarzeniePoczatkowe(graf);*/            
            /*List<List<Wezel<int>>> ltmp = AlgorytmWegierski.OddzielZbiory(graf);
            List<Wezel<int>> V1 = ltmp[0], V2 = ltmp[1];
            List<Wezel<int>> msk = MaksymalneSkojarzenie.ZnajdzDrogeRozszerzajaca(V1, V2, E);*/

            Graf<int> minD = MinDrzewoRozpinajace.Kruskal(graf);
            List<Wezel<int>> msk = ProblemKomiwojazera.SzukajDrogi(graf, V[2]);
            //graf.WyswietlWezly(Console.Out);
            minD.WyswietlWezly(Console.Out);
            //minD.WyswietlWezly(Console.Out);
            Console.WriteLine();
            //graf.WyswietlKrawedzie(Console.Out);
            minD.WyswietlKrawedzie(Console.Out);
            Console.WriteLine();
            foreach (Wezel<int> m in msk)
                Console.WriteLine(m.Nazwa);
        }

        static void SudokuMain(string[] args = null)
        {
            string[] strs = new string[9];
            strs[0] = "29--53---";
            strs[1] = "--58-9---";
            strs[2] = "6---4----";
            strs[3] = "3-------6";
            strs[4] = "-4--96---";
            strs[5] = "---4-----";
            strs[6] = "---2-7-94";
            strs[7] = "48-------";
            strs[8] = "5--36--78";


            // wczytujemy sudoku liczby nieoddzielone spacja, puste miejsca to '-'
            /*Console.WriteLine("Wpisz proste sudoku:");
            for (int i = 0; i < 9; i++)
                strs[i] = Console.ReadLine();*/

            Console.WriteLine("Wprowadzone sudoku:");
            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < strs[0].Length; j++)
                {
                    Console.Write("{0} ", strs[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nRozwiazanie:");
            int[,] sudoku = KolorowanieGrafuSudoku.TablicaStringDoSudoku(strs);
            sudoku = KolorowanieGrafuSudoku.RozwiazSudoku3(sudoku);

            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                    if (sudoku[i, j] != -1)
                        Console.Write("{0} ", sudoku[i, j]);
                    else
                        Console.Write("- ");
                Console.WriteLine();
            }
        }

        static void PodzbioryMain(string[] args = null)
        {
            List<int> zbior = new List<int>(5);
            for (int i = 0; i < 5; i++)
                zbior.Add(i + 1);            
            List<List<int>> pdzb = AlgorytmPlecakowy.WszystkiePodzbiory(zbior, 3);

            foreach (List<int> l in pdzb)
            {
                foreach (int el in l)
                {
                    Console.Write("{0} ", el);
                }
                Console.WriteLine();
            }
        }

        static void PlecakMain(string[] args = null)
        {
            Przedmiot spodnie = new Przedmiot { Nazwa = "Spodnie", Waga = 14, Wartosc = 20 };
            Przedmiot koszula = new Przedmiot { Nazwa = "Koszula", Waga = 8, Wartosc = 5 };
            Przedmiot bielizna = new Przedmiot { Nazwa = "Bielizna", Waga = 3, Wartosc = 7 };
            Przedmiot skarpetki = new Przedmiot { Nazwa = "Skarpy", Waga = 2, Wartosc = 1 };
            Przedmiot kurtka = new Przedmiot { Nazwa = "Kurtka", Waga = 10, Wartosc = 14 };

            List<Przedmiot> lista = new List<Przedmiot>();
            lista.Add(spodnie);
            lista.Add(koszula);
            lista.Add(bielizna);
            lista.Add(skarpetki);
            lista.Add(kurtka);

            List<Przedmiot> plecak = AlgorytmPlecakowy.Run(lista, 25);
            Console.WriteLine("Plecak o wytrzymalosci 25:");
            foreach (Przedmiot p in plecak)
            {
                Console.WriteLine("Nazwa: {0}, Waga: {1}, Wartosc: {2}", p.Nazwa, p.Waga, p.Wartosc);
            }
        }

        static void drogPowMain(string[] args = null)
        {
            int[,] mat = { { 0, 0, 1, 0 }, { 1, 2, 0, 1 }, { 0, 1, 2, 0 }, { 0, 0, 1, 2 } };
            List<int> ret = MaksymalneSkojarzenie.ZnajdzDrogePowiekszajaca(mat);
            foreach (int r in ret)
            {
                Console.WriteLine("{0}", r);
            }
        }

        static void MaksSkojrzMain(string[] args = null)
        {
            int[,] mat = { { 0, 0, 1, 0 }, { 1, 2, 0, 1 }, { 0, 1, 2, 0 }, { 0, 0, 1, 2 } };
            int[,] msk = MaksymalneSkojarzenie.Znajdz(mat);

            Console.WriteLine("Macierz wejsciowa:");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nRozwiazanie:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write("{0} ", msk[i, j]);
                Console.WriteLine();
            }
        }

        static void WegierMain(string[] args = null)
        {
            int[,] mat = { { 14, 5, 8, 7 }, { 2, 12, 6, 5 }, { 7, 8, 3, 9 }, { 2, 4, 6, 10 } };
            List<int> rozw = AlgorytmWegierski.Znajdz(mat);
            int sum = 0;
            Console.WriteLine("Macierz wejsciowa:");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)             
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nRozwiazanie:");
            for (int i = 0; i < rozw.Count; i++)
            {
                int l = rozw[i];
                sum += l;
                if (i != rozw.Count - 1)
                    Console.Write("{0} + ", l);
                else
                    Console.WriteLine("{0} = {1} ", l, sum);
            }
        }

        static void EulerMain(string[] args = null)
        {
            List<Wezel<int>> V = new List<Wezel<int>>();
            List<Krawedz<int>> E = new List<Krawedz<int>>();

            UzupelnijDaneVDlaCykluEulera(V);
            UzupelnijDaneEDlaCykluEulera(V, E);

            Graf<int> graf = new Graf<int>(V, E);
            Queue<Wezel<int>> ret = CyklEulera.Run(graf, V[0]);
            graf.WyswietlWezly(Console.Out);
            graf.WyswietlKrawedzie(Console.Out);
            Console.WriteLine("Rozwiazanie:");
            while (ret.Count > 0)
            {
                Wezel<int> w = ret.Dequeue();
                Console.WriteLine("{0} {1}", w.Nazwa, w.Wart);
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Metody optymalizacji - Maciek Janczyk\n---------------------------");

            char k = '-';
            while (k != '8')
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Cykl Eulera");
                Console.WriteLine("2. Maksymalne skojarzenie");
                Console.WriteLine("3. Algorytm wegierski");
                Console.WriteLine("4. Minimalne drzewo rozpinajace");
                Console.WriteLine("5. Problem komiwojazera");
                Console.WriteLine("6. Sudoku");
                Console.WriteLine("7. Algorytm plecakowy");
                Console.WriteLine("8. Wyjscie");
                Console.Write("Wybor: ");
                k = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (k)
                {
                    case '3':
                        WegierMain();
                        break;
                    case '5':
                        KomiwojazerMain();
                        break;
                    case '1':
                        EulerMain();
                        break;
                    case '7':
                        PlecakMain();
                        break;
                    case '6':
                        SudokuMain();
                        break;
                    case '2':
                        MaksSkojrzMain();
                        break;
                    case '4':
                        MSTMain();
                        break;
                }
            }                                    
        }
    }
}
