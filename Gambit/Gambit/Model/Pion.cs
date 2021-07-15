using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambit.Model
{
    class Pion
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Who { get; set; }
        public bool Kolor { get; set; }

        public Pion(int x, int y, char who, bool kolor)
        {
            X = x;
            Y = y;
            Who = who;
            Kolor = kolor;
        }

        public int[,] mozliwosci(char[,] plansza, bool pm)
        {
            List<int> possible = new List<int>();
            List<int> maybe = new List<int>();

            switch (Who)
            {
                case 'w':
                    for (int i = X + 1; i < 8; i++)
                    {
                        if (plansza[i, Y] == '0')
                        {
                            possible.Add(i);
                            possible.Add(Y);
                        }

                        if (plansza[i, Y] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(Y);
                            break;
                        }
                    }

                    for (int i = X - 1; i >= 0; i--)
                    {
                        if (plansza[i, Y] == '0')
                        {
                            possible.Add(i);
                            possible.Add(Y);
                        }

                        if (plansza[i, Y] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(Y);
                            break;
                        }
                    }

                    for (int i = Y + 1; i < 8; i++)
                    {
                        if (plansza[X, i] == '0')
                        {
                            possible.Add(X);
                            possible.Add(i);
                        }

                        if (plansza[X, i] != '0')
                        {
                            maybe.Add(X);
                            maybe.Add(i);
                            break;
                        }
                    }

                    for (int i = Y - 1; i >= 0; i--)
                    {
                        if (plansza[X, i] == '0')
                        {
                            possible.Add(X);
                            possible.Add(i);
                        }

                        if (plansza[X, i] != '0')
                        {
                            maybe.Add(X);
                            maybe.Add(i);
                            break;
                        }
                    }

                    break;

                case 'g':
                    int j = Y + 1;
                    for (int i = X + 1; i < 8; i++)
                    {
                        if (j >= 8)
                            break;
                        if (plansza[i, j] == '0')
                        {
                            possible.Add(i);
                            possible.Add(j);
                        }

                        if (plansza[i, j] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(j);
                            break;
                        }

                        j++;
                        if (j >= 8)
                            break;
                    }

                    j = Y - 1;
                    for (int i = X + 1; i < 8; i++)
                    {
                        if (j < 0)
                            break;
                        if (plansza[i, j] == '0')
                        {
                            possible.Add(i);
                            possible.Add(j);
                        }

                        if (plansza[i, j] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(j);
                            break;
                        }

                        j--;
                        if (j < 0)
                            break;
                    }

                    j = Y - 1;
                    for (int i = X - 1; i >= 0; i--)
                    {
                        if (j < 0)
                            break;
                        if (plansza[i, j] == '0')
                        {
                            possible.Add(i);
                            possible.Add(j);
                        }

                        if (plansza[i, j] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(j);
                            break;
                        }

                        j--;
                        if (j < 0)
                            break;
                    }

                    j = Y + 1;
                    for (int i = X - 1; i >= 0; i--)
                    {
                        if (j >= 8)
                            break;
                        if (plansza[i, j] == '0')
                        {
                            possible.Add(i);
                            possible.Add(j);
                        }

                        if (plansza[i, j] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(j);
                            break;
                        }

                        j++;
                        if (j >= 8)
                            break;
                    }

                    break;

                case 'h':
                    for (int i = X + 1; i < 8; i++)
                    {
                        if (plansza[i, Y] == '0')
                        {
                            possible.Add(i);
                            possible.Add(Y);
                        }

                        if (plansza[i, Y] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(Y);
                            break;
                        }
                    }

                    for (int i = X - 1; i >= 0; i--)
                    {
                        if (plansza[i, Y] == '0')
                        {
                            possible.Add(i);
                            possible.Add(Y);
                        }

                        if (plansza[i, Y] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(Y);
                            break;
                        }
                    }

                    for (int i = Y + 1; i < 8; i++)
                    {
                        if (plansza[X, i] == '0')
                        {
                            possible.Add(X);
                            possible.Add(i);
                        }

                        if (plansza[X, i] != '0')
                        {
                            maybe.Add(X);
                            maybe.Add(i);
                            break;
                        }
                    }

                    for (int i = Y - 1; i >= 0; i--)
                    {
                        if (plansza[X, i] == '0')
                        {
                            possible.Add(X);
                            possible.Add(i);
                        }

                        if (plansza[X, i] != '0')
                        {
                            maybe.Add(X);
                            maybe.Add(i);
                            break;
                        }
                    }


                    int jj = Y + 1;
                    for (int i = X + 1; i < 8; i++)
                    {
                        if (jj >= 8)
                            break;
                        if (plansza[i, jj] == '0')
                        {
                            possible.Add(i);
                            possible.Add(jj);
                        }

                        if (plansza[i, jj] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(jj);
                            break;
                        }

                        jj++;
                        if (jj >= 8)
                            break;
                    }

                    jj = Y - 1;
                    for (int i = X + 1; i < 8; i++)
                    {
                        if (jj < 0)
                            break;
                        if (plansza[i, jj] == '0')
                        {
                            possible.Add(i);
                            possible.Add(jj);
                        }

                        if (plansza[i, jj] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(jj);
                            break;
                        }

                        jj--;
                        if (jj < 0)
                            break;
                    }

                    jj = Y - 1;
                    for (int i = X - 1; i >= 0; i--)
                    {
                        if (jj < 0)
                            break;
                        if (plansza[i, jj] == '0')
                        {
                            possible.Add(i);
                            possible.Add(jj);
                        }

                        if (plansza[i, jj] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(jj);
                            break;
                        }

                        jj--;
                        if (jj < 0)
                            break;
                    }

                    jj = Y + 1;
                    for (int i = X - 1; i >= 0; i--)
                    {
                        if (jj >= 8)
                            break;
                        if (plansza[i, jj] == '0')
                        {
                            possible.Add(i);
                            possible.Add(jj);
                        }

                        if (plansza[i, jj] != '0')
                        {
                            maybe.Add(i);
                            maybe.Add(jj);
                            break;
                        }

                        jj++;
                        if (jj >= 8)
                            break;
                    }

                    break;

                case 's':
                    if (X + 2 < 8 && Y + 1 < 8 && plansza[X + 2, Y + 1] == '0')
                    {
                        possible.Add(X + 2);
                        possible.Add(Y + 1);
                    }
                    if (X + 2 < 8 && Y + 1 < 8 && plansza[X + 2, Y + 1] != '0')
                    {
                        maybe.Add(X + 2);
                        maybe.Add(Y + 1);
                    }
                    if (X + 2 < 8 && Y - 1 >= 0 && plansza[X + 2, Y - 1] == '0')
                    {
                        possible.Add(X + 2);
                        possible.Add(Y - 1);
                    }
                    if (X + 2 < 8 && Y - 1 >= 0 && plansza[X + 2, Y - 1] != '0')
                    {
                        maybe.Add(X + 2);
                        maybe.Add(Y - 1);
                    }

                    if (X - 2 >= 0 && Y + 1 < 8 && plansza[X - 2, Y + 1] == '0')
                    {
                        possible.Add(X - 2);
                        possible.Add(Y + 1);
                    }
                    if (X - 2 >= 0 && Y + 1 < 8 && plansza[X - 2, Y + 1] != '0')
                    {
                        maybe.Add(X - 2);
                        maybe.Add(Y + 1);
                    }
                    if (X - 2 >= 0 && Y - 1 >= 0 && plansza[X - 2, Y - 1] == '0')
                    {
                        possible.Add(X - 2);
                        possible.Add(Y - 1);
                    }
                    if (X - 2 >= 0 && Y - 1 >= 0 && plansza[X - 2, Y - 1] != '0')
                    {
                        maybe.Add(X - 2);
                        maybe.Add(Y - 1);
                    }

                    if (X + 1 < 8 && Y + 2 < 8 && plansza[X + 1, Y + 2] == '0')
                    {
                        possible.Add(X + 1);
                        possible.Add(Y + 2);
                    }
                    if (X + 1 < 8 && Y + 2 < 8 && plansza[X + 1, Y + 2] != '0')
                    {
                        maybe.Add(X + 1);
                        maybe.Add(Y + 2);
                    }
                    if (X - 1 >= 0 && Y + 2 < 8 && plansza[X - 1, Y + 2] == '0')
                    {
                        possible.Add(X - 1);
                        possible.Add(Y + 2);
                    }
                    if (X - 1 >= 0 && Y + 2 < 8 && plansza[X - 1, Y + 2] != '0')
                    {
                        maybe.Add(X - 1);
                        maybe.Add(Y + 2);
                    }


                    if (X - 1 >= 0 && Y - 2 >= 0 && plansza[X - 1, Y - 2] == '0')
                    {
                        possible.Add(X - 1);
                        possible.Add(Y - 2);
                    }
                    if (X - 1 >= 0 && Y - 2 >= 0 && plansza[X - 1, Y - 2] != '0')
                    {
                        maybe.Add(X - 1);
                        maybe.Add(Y - 2);
                    }
                    if (X + 1 < 8 && Y - 2 >= 0 && plansza[X + 1, Y - 2] == '0')
                    {
                        possible.Add(X + 1);
                        possible.Add(Y - 2);
                    }
                    if (X + 1 < 8 && Y - 2 >= 0 && plansza[X + 1, Y - 2] != '0')
                    {
                        maybe.Add(X + 1);
                        maybe.Add(Y - 2);
                    }

                    break;

                case 'k':
                    for (int i = X - 1; i < X + 2; i++)
                    {
                        for (int l = Y - 1; l < Y + 2; l++)
                        {
                            if (i >= 0 && i < 8 && l >= 0 && l < 8)
                            {
                                if (plansza[i, l] == '0')
                                {
                                    possible.Add(i);
                                    possible.Add(l);
                                }
                                if (plansza[i, l] != '0')
                                {
                                    maybe.Add(i);
                                    maybe.Add(l);
                                }
                            }
                        }
                    }

                    break;

                case 'p':
                    if (Kolor == true)
                    {
                        if (X + 1 < 8 && plansza[X + 1, Y] == '0')
                        {
                            possible.Add(X + 1);
                            possible.Add(Y);

                            if (X == 1 && plansza[X + 2, Y] == '0')
                            {
                                possible.Add(X + 2);
                                possible.Add(Y);
                            }
                        }
                        if (Y + 1 < 8 && X + 1 < 8 && plansza[X + 1, Y + 1] != '0')
                        {
                            maybe.Add(X + 1);
                            maybe.Add(Y + 1);
                        }
                        if (Y - 1 >= 0 && X + 1 < 8 && plansza[X + 1, Y - 1] != '0')
                        {
                            maybe.Add(X + 1);
                            maybe.Add(Y - 1);
                        }
                    }

                    if (Kolor == false)
                    {
                        if (X - 1 >= 0 && plansza[X - 1, Y] == '0')
                        {
                            possible.Add(X - 1);
                            possible.Add(Y);

                            if (X == 6 && plansza[X - 2, Y] == '0')
                            {
                                possible.Add(X - 2);
                                possible.Add(Y);
                            }
                        }
                        if (Y + 1 < 8 && X - 1 >= 0 && plansza[X - 1, Y + 1] != '0')
                        {
                            maybe.Add(X - 1);
                            maybe.Add(Y + 1);
                        }
                        if (Y - 1 >= 0 && X - 1 >= 0 && plansza[X - 1, Y - 1] != '0')
                        {
                            maybe.Add(X - 1);
                            maybe.Add(Y - 1);
                        }

                    }

                    break;

                case '0':
                    possible.Clear();
                    maybe.Clear();
                    break;
            }

            int[,] wyjazd;
            if (!pm)
                wyjazd = listto2darray(possible);
            else
                wyjazd = listto2darray(maybe);

            return wyjazd;

        }


        public void move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int[,] listto2darray(List<int> list)
        {
            int[,] array2d;

            if (list != null)
            {
                array2d = new int[list.Count / 2, 2];
                int ii = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    if (i % 2 == 0)
                        array2d[ii, 0] = list[i];
                    else
                    {
                        array2d[ii, 1] = list[i];
                        ii++;
                    }
                }
            }
            else
                array2d = null;
            return array2d;
        }
    }

}
