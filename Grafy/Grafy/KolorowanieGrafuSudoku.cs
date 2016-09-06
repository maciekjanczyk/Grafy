using System;
using System.Collections.Generic;

namespace Grafy
{
    // pole Wartosc w wezle grafu Sudoku mowi, w ktorym kwadracie ten wezel lezy
    // mamy sudoku 9x9

    public static class KolorowanieGrafuSudoku
    {
        public static int[,] TablicaStringDoSudoku(string[] strs)
        {
            int[,] ret = new int[9, 9];
            int i = 0, j = 0;

            i = 0;
            foreach (string str in strs)
            {
                j = 0;
                foreach (char ch in str)
                {
                    if (ch != '-')
                        ret[i, j] = Convert.ToInt32(Convert.ToString(ch));
                    else
                        ret[i, j] = -1;
                    j++;
                }
                i++;
            }

            return ret;
        }

        public static Wezel<int>[,] SudokuDoTablicyWezlow(int[,] sudoku)
        {
            Wezel<int>[,] ret = new Wezel<int>[9,9];

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    ret[i,j] = new Wezel<int>("", i / 3 * 3 + j / 3);
                    if (sudoku[i, j] != -1)
                        ret[i, j].Koloruj(Convert.ToString(sudoku[i, j]));
                    else
                        ret[i, j].Koloruj("-");
                }                    

            return ret;
        }

        public static int[,] TablicaWezlowDoSudoku(Wezel<int>[,] tab)
        {
            int[,] ret = new int[9, 9];

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    //ret[i, j] = Convert.ToInt32(tab[i, j].Nazwa);
                    if (tab[i, j].Kolor != "-")
                        ret[i, j] = Convert.ToInt32(tab[i, j].Kolor);
                    else
                        ret[i, j] = -1;
                }

            return ret;
        }

        public static int MaksimumSudoku(int[,] sudoku)
        {
            int ret = 0;

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (sudoku[i, j] > ret)
                        ret = sudoku[i, j];

            return ret;
        }
            

        public static int[,] RozwiazSudoku(int[,] sudoku)
        {
            Wezel<int>[,] ret = SudokuDoTablicyWezlow(sudoku);                        
            int max = MaksimumSudoku(sudoku);
            List<List<Wezel<int>>> sektory = new List<List<Wezel<int>>>();

            for (int i = 0; i < 9; i++)
            {
                sektory.Add(new List<Wezel<int>>());
                for (int j = 0; j < 9; j++)
                    sektory[i].Add(ret[i, j]);
            }

            int WAGA = 1;
            while (WAGA < 10)
            {
                Wezel<int> wybrany = null;
                int wybI = -1, wybJ = -1;

                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        if (ret[i, j].Kolor == Convert.ToString(WAGA) && (!ret[i, j].Odwiedzony))
                        {
                            wybrany = ret[i, j];
                            wybI = i;
                            wybJ = j;
                            sektory[wybrany.Wart].Add(wybrany);
                            break;
                        }

                // jesli null --> podnosimy wage i czyscimy, i next iteracja
                if (wybrany == null)
                {
                    bool[] wystWBoxie = new bool[9];
                    for (int i = 0; i < 9; i++)
                        wystWBoxie[i] = false;

                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            if (ret[i, j].Kolor == "-" && (!ret[i, j].Odwiedzony) && (!wystWBoxie[ret[i, j].Wart]))
                            {
                                ret[i, j].Odwiedz();
                                ret[i, j].Kolor = Convert.ToString(WAGA);
                                wystWBoxie[ret[i, j].Wart] = true;
                            }

                    WAGA++;
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                            ret[i, j].CzyscSkreslenie();

                    continue;
                }

                // skreslenia w sektorze
                foreach (Wezel<int> w in sektory[wybrany.Wart])
                    w.Odwiedz();

                // skreslenia w wierszach i kolumnach
                for (int i = 0; i < 9; i++)
                {
                    ret[wybI, i].Odwiedz();
                    ret[i, wybJ].Odwiedz();
                }
            }

            return TablicaWezlowDoSudoku(ret);
        }

        public static int NumerKwadratu(int i, int j)
        {
            if (i == 0 || i == 1 || i == 2)
            {
                if (j == 0 || j == 1 || j == 2)
                    return 0;
                if (j == 3 || j == 4 || j == 5)
                    return 1;
                if (j == 6 || j == 7 || j == 8)
                    return 2;
            }
            else if (i == 3 || i == 4 || i == 5)
            {
                if (j == 0 || j == 1 || j == 2)
                    return 3;
                if (j == 3 || j == 4 || j == 5)
                    return 4;
                if (j == 6 || j == 7 || j == 8)
                    return 5;
            }
            else if (i == 6 || i == 7 || i == 8)
            {
                if (j == 0 || j == 1 || j == 2)
                    return 6;
                if (j == 3 || j == 4 || j == 5)
                    return 7;
                if (j == 6 || j == 7 || j == 8)
                    return 8;
            }
            return -1;
        }

        public static int LiczWagi(int[,] sudoku, int waga)
        {
            int ile = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku[i, j] == waga)
                        ile++;
                }
            }

            return ile;
        }

        public static void SkreslSasiednieKw(int nrKw, List<int> list)
        {
            if (nrKw == 0 || nrKw == 1 || nrKw == 2)
            {
                for (int i = 0; i <= 2; i++)
                    if (!list.Contains(i))
                        list.Add(i);                
            }
            if (nrKw == 3 || nrKw == 4 || nrKw == 5)
            {
                for (int i = 3; i <= 5; i++)
                    if (!list.Contains(i))
                        list.Add(i);
            }
            if (nrKw == 6 || nrKw == 7 || nrKw == 8)
            {
                for (int i = 6; i <= 8; i++)
                    if (!list.Contains(i))
                        list.Add(i);
            }
            if (nrKw == 0 || nrKw == 3 || nrKw == 6)
            {
                for (int i = 0; i <= 6; i += 3)
                    if (!list.Contains(i))
                        list.Add(i);
            }
            if (nrKw == 1 || nrKw == 4 || nrKw == 7)
            {
                for (int i = 1; i <= 7; i += 3)
                    if (!list.Contains(i))
                        list.Add(i);
            }
            if (nrKw == 2 || nrKw == 5 || nrKw == 8)
            {
                for (int i = 2; i <= 8; i += 3)
                    if (!list.Contains(i))
                        list.Add(i);
            }
        }

        public static bool KwadratZawieraWage(int[,] sudoku, int waga, int nrKw)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int nr = NumerKwadratu(i, j);
                    if (nr != nrKw)
                        continue;
                    if (sudoku[i, j] == waga)
                        return true;
                }
            }

            return false;
        }

        public static Stack<int> NajczestszeWystapienia(int[,] sudoku)
        {
            List<List<int>> wyst = new List<List<int>>();
            Stack<int> ret = new Stack<int>();

            for (int i = 0; i < 8; i++)
            {
                List<int> pkt = new List<int>();
                pkt.Add(i);
                pkt.Add(0);
                wyst.Add(pkt);
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (sudoku[i, j] != -1)
                    {
                        wyst[sudoku[i, j] - 1][1] += 1;
                    }
                }
            }

            wyst.Sort(new Comparison<List<int>>((a, b) => { if (a[1] > b[1]) return 1; else return -1; }));
            for (int i = 0; i < 8; i++)
            {
                ret.Push(wyst[i][1]);
            }

            return ret;
        }

        public static int[,] RozwiazSudoku2(int[,] sudoku)
        {
            int[,] ret = (int[,]) sudoku.Clone();
            Stack<int> najczWyst = NajczestszeWystapienia(sudoku);
            int WAGA = najczWyst.Pop(); 

            while (najczWyst.Count > 0)
            {
                List<int> skresloneKwadraty = new List<int>();
                List<int> skresloneKolumny = new List<int>(); // j
                List<int> skresloneWiersze = new List<int>(); // i

                // szukamy wszystkich liczb typu WAGA i skrelamy
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (ret[i, j] == WAGA)
                        {
                            int nrKw = NumerKwadratu(i, j);
                            if (!skresloneKwadraty.Contains(nrKw))
                            {
                                skresloneKwadraty.Add(nrKw);
                                //SkreslSasiednieKw(nrKw, skresloneKwadraty);
                            }
                            if (!skresloneKolumny.Contains(j))
                            {
                                skresloneKolumny.Add(j);
                            }
                            if (!skresloneWiersze.Contains(i))
                            {
                                skresloneWiersze.Add(i);
                            }
                        }
                    }
                }

                // lecimy z pustymi polami i skreslamy
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        int nrKw = NumerKwadratu(i, j);
                        if (ret[i, j] == -1 && !KwadratZawieraWage(ret, WAGA, nrKw) && !skresloneKwadraty.Contains(nrKw) && !skresloneWiersze.Contains(i) && !skresloneKolumny.Contains(j))
                        {
                            ret[i, j] = WAGA;
                            //SkreslSasiednieKw(nrKw, skresloneKwadraty);
                            skresloneKwadraty.Add(nrKw);
                            skresloneKolumny.Add(j);
                            skresloneWiersze.Add(i);
                        }
                    }
                }

                if (najczWyst.Count > 0)
                    WAGA = najczWyst.Pop();
            }

            return ret;
        }

        // rekurencja

        private static bool CzyMoznaWstawic(int i, int j, int waga, int[,] sudoku)
        {
            for (int k = 0; k < 9; k++)
            {
                if (waga == sudoku[i, k] || waga == sudoku[k, j] || waga == sudoku[i / 3 * 3 + k % 3, j / 3 * 3 + k / 3])
                    return false;
            }

            return true;
        }

        private static bool CzyKoniec(int i, int j, int[,] problem, int[,] rozw)
        {
            if (i == 8 && j == 8)
                return true;
            else if (i == 8)
                return Rozwiazuj(0, j + 1, problem, rozw);
            else
                return Rozwiazuj(i + 1, j, problem, rozw);
        }

        private static bool Rozwiazuj(int i, int j, int[,] problem, int[,] rozw)
        {
            if (problem[i, j] == -1)
            {
                for (int k = 1; k <= 9; k++)
                {
                    if (CzyMoznaWstawic(i, j, k, rozw))
                    {
                        rozw[i, j] = k;
                        if (CzyKoniec(i, j, problem, rozw))
                            return true;
                    }
                }
                rozw[i, j] = -1;
                return false;
            }

            return CzyKoniec(i, j, problem, rozw);
        }

        public static int[,] RozwiazSudoku3(int[,] sudoku)
        {
            int[,] ret = (int[,])sudoku.Clone();

            Rozwiazuj(0, 0, sudoku, ret);

            return ret;
        }
    }
}

