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
                    ret[i, j] = Convert.ToInt32(tab[i, j].Kolor);
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
    }
}

