using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambit.Model
{
    class Armia
    {
        public char[,] rozklad;
        List<Pion> pionki = new List<Pion>();
        List<Pion> shadowrealm = new List<Pion>();
        private int xdorev;
        private int ydorev;
        private bool[] roshada = new bool[3] { true, true, true };

        public Armia(bool x)
        {

            if (x)
            {
                rozklad = new char[8, 8] {  {'w','s','g','h','k','g','s','w' },
                                            {'p','p','p','p','p','p','p','p' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' } };

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (rozklad[i, j] != '0')
                            pionki.Add(new Pion(i, j, rozklad[i, j], true));
                    }
                }

            }
            else
            {
                rozklad = new char[8, 8] {  {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'p','p','p','p','p','p','p','p' },
                                            {'w','s','g','h','k','g','s','w' } };

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (rozklad[i, j] != '0')
                            pionki.Add(new Pion(i, j, rozklad[i, j], false));
                    }
                }
            }
        }



        public int[,] TheChosenOne(int xx, int yy, char[,] plansza, bool aom)
        {
            for (int i = 0; i < pionki.Count; i++)
            {
                if (pionki[i].X == xx && pionki[i].Y == yy)
                {
                    if (aom)
                    {
                        int[,] mb = pionki[i].mozliwosci(plansza, true);
                        if (mb != null)
                        {
                            List<int> attck = new List<int>();
                            for (int k = 0; k < mb.Length / 2; k++)
                            {
                                if (rozklad[mb[k, 0], mb[k, 1]] == '0')
                                {

                                    attck.Add(mb[k, 0]);
                                    attck.Add(mb[k, 1]);
                                }

                            }
                            int[,] attack = new int[attck.Count / 2, 2];
                            attack = pionki[i].listto2darray(attck);
                            return attack;
                        }
                        return null;
                    }

                    return pionki[i].mozliwosci(plansza, false);
                }
            }
            return null;
        }





        public char armymove(int x, int y, int lastx, int lasty)
        {
            for (int i = 0; i < pionki.Count; i++)
            {
                if (pionki[i].X == lastx && pionki[i].Y == lasty)
                {
                    pionki[i].move(x, y);
                    checkrosh(lastx, lasty, pionki[i].Who);
                    rozklad[lastx, lasty] = '0';
                    rozklad[x, y] = pionki[i].Who;
                    return pionki[i].Who;
                }

            }
            return 'x';
        }


        public void checkrosh(int x, int y, char kto)
        {
            if ((x == 7 && y == 7 || x == 0 && y == 7) && kto == 'w')
            {
                roshada[2] = false;
            }
            if ((x == 7 && y == 0 || x == 0 && y == 0) && kto == 'w')
            {
                roshada[0] = false;
            }
            if ((x == 7 && y == 4 || x == 0 && y == 4) && kto == 'k')
            {
                roshada[1] = false;
            }
        }


        public int[,] roszada(bool sprawdzam, bool lewa, int x, int y)
        {
            if (sprawdzam)
            {
                if (rozklad[x, y] != 'k')
                    return null;
                List<int> mb = new List<int>();
                if (roshada[0] == true && roshada[1] == true)
                {
                    if (rozklad[0, 0] == 'w' && rozklad[0, 4] == 'k' && rozklad[0, 1] == '0' && rozklad[0, 2] == '0' && rozklad[0, 3] == '0')
                    {
                        mb.Add(0);
                        mb.Add(2);
                    }
                    if (rozklad[7, 4] == 'k' && rozklad[7, 0] == 'w' && rozklad[7, 1] == '0' && rozklad[7, 2] == '0' && rozklad[7, 3] == '0')
                    {
                        mb.Add(7);
                        mb.Add(2);
                    }
                }
                if (roshada[1] == true && roshada[2] == true)
                {
                    if (rozklad[0, 7] == 'w' && rozklad[0, 4] == 'k' && rozklad[0, 6] == '0' && rozklad[0, 5] == '0')
                    {
                        mb.Add(0);
                        mb.Add(6);
                    }
                    if (rozklad[7, 4] == 'k' && rozklad[7, 7] == 'w' && rozklad[7, 6] == '0' && rozklad[7, 5] == '0')
                    {
                        mb.Add(7);
                        mb.Add(6);
                    }
                }
                int[,] tmp = listto2darray(mb);
                return tmp;
            }
            else
            {
                if (lewa)
                {
                    if (rozklad[0, 0] == 'w' && rozklad[0, 4] == 'k')
                    {
                        rozklad[0, 0] = '0';
                        rozklad[0, 4] = '0';
                        rozklad[0, 2] = 'k';
                        rozklad[0, 3] = 'w';
                        for (int i = 0; i < pionki.Count; i++)
                        {
                            if (pionki[i].Y == 4 && pionki[i].X == 0)
                                pionki[i].Y = 2;

                            if (pionki[i].Y == 0 && pionki[i].X == 0)
                                pionki[i].Y = 3;
                        }
                    }
                    if (rozklad[7, 4] == 'k' && rozklad[7, 0] == 'w')
                    {
                        rozklad[7, 0] = '0';
                        rozklad[7, 4] = '0';
                        rozklad[7, 2] = 'k';
                        rozklad[7, 3] = 'w';
                        for (int i = 0; i < pionki.Count; i++)
                        {
                            if (pionki[i].Y == 4 && pionki[i].X == 7)
                                pionki[i].Y = 2;

                            if (pionki[i].Y == 0 && pionki[i].X == 7)
                                pionki[i].Y = 3;
                        }
                    }
                    
                }
                else
                {
                    if (rozklad[0, 7] == 'w' && rozklad[0, 4] == 'k')
                    {
                        rozklad[0, 4] = '0';
                        rozklad[0, 7] = '0';
                        rozklad[0, 6] = 'k';
                        rozklad[0, 5] = 'w';
                        for (int i = 0; i < pionki.Count; i++)
                        {
                            if (pionki[i].Y == 4 && pionki[i].X == 0)
                                pionki[i].Y = 6;

                            if (pionki[i].Y == 7 && pionki[i].X == 0)
                                pionki[i].Y = 5;
                        }
                    }
                    if (rozklad[7, 4] == 'k' && rozklad[7, 7] == 'w')
                    {
                        rozklad[7, 4] = '0';
                        rozklad[7, 7] = '0';
                        rozklad[7, 6] = 'k';
                        rozklad[7, 5] = 'w';
                        for (int i = 0; i < pionki.Count; i++)
                        {
                            if (pionki[i].Y == 4 && pionki[i].X == 7)
                                pionki[i].Y = 6;

                            if (pionki[i].Y == 7 && pionki[i].X == 7)
                                pionki[i].Y = 5;
                        }
                    }
                }
            }
            return null;
        }


        public char armyattack(int x, int y, int lastx, int lasty)
        {
            for (int i = 0; i < pionki.Count; i++)
            {
                if (pionki[i].X == lastx && pionki[i].Y == lasty)
                {
                    pionki[i].move(x, y);
                    checkrosh(lastx, lasty, pionki[i].Who);
                    rozklad[lastx, lasty] = '0';
                    rozklad[x, y] = pionki[i].Who;
                    return pionki[i].Who;
                }

            }
            return 'x';
        }

        public void death(int x, int y)
        {
            for (int i = 0; i < pionki.Count; i++)
            {
                if (pionki[i].X == x && pionki[i].Y == y)
                {
                    pionki[i].X = 9;
                    pionki[i].Y = 9;
                    shadowrealm.Add(pionki[i]);
                    pionki.RemoveAt(i);
                    rozklad[x, y] = '0';
                }
            }
        }
        public char[] whorevive(int x, int y)
        {
            death(x, y);
            xdorev = x;
            ydorev = y;
            char[] wybor = new char[4] { 'w', 's', 'g', 'h'};
            return wybor;
        }

        public void revive(char kto, bool kolor)
        {
            pionki.Add(new Pion(xdorev, ydorev, kto, kolor));
            rozklad[xdorev, ydorev] = kto;
        }


        public int[,] mozliwosciarmii(char[,] plansza, int x, int y)
        {
            List<int> attck = new List<int>();
            char[,] podmianka = new char[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podmianka[i, j] = rozklad[i, j];
                }
            }
            if(x !=8 && y != 8)
            {
                podmianka[x, y] = '0';
            }

            for (int i = 0; i < pionki.Count; i++)
            {
                int[,] mb = pionki[i].mozliwosci(plansza, true);

                if (pionki[i].X == x && pionki[i].Y == y)
                    mb = null;

                if (mb != null)
                {
                    for (int k = 0; k < mb.Length / 2; k++)
                    {
                        
                            if (podmianka[mb[k, 0], mb[k, 1]] == '0')
                            {
                                attck.Add(mb[k, 0]);
                                attck.Add(mb[k, 1]);
                            }

                    }
                }

            }
            int[,] attack = new int[attck.Count / 2, 2];
            attack = listto2darray(attck);
            return attack;
        }


        public int[,] zasobyarmii()
        {
            List<int> tmp = new List<int>();
            for (int i = 0; i < pionki.Count; i++)
            {
                tmp.Add(pionki[i].X);
                tmp.Add(pionki[i].Y);
            }

            int[,] wojsko = new int[tmp.Count / 2, 2];
            wojsko = listto2darray(tmp);
            return wojsko;
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
