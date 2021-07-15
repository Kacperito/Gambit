using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambit.Model
{
    class Silnik
    {
        Armia Biale = new Armia(false);
        Armia Czarne = new Armia(true);

        //Stack<int[]> moves = new Stack<int[]>();

        bool ruch = true;
        bool clicked = false;


        int lastmoveX = 9;
        int lastmoveY = 9;

        int xdorev;
        int ydorev;

        char[,] plansza = new char[8, 8] {  {'w','s','g','h','k','g','s','w' },
                                            {'p','p','p','p','p','p','p','p' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'0','0','0','0','0','0','0','0' },
                                            {'p','p','p','p','p','p','p','p' },
                                            {'w','s','g','h','k','g','s','w' } };



        public string[] hmmm(int x, int y)
        {

            int[,] tmp1;
            int[,] tmp2;
            int[,] tmp3;


            if (ruch)
            {
                tmp1 = Biale.TheChosenOne(x, y, plansza, false);
                tmp2 = Biale.TheChosenOne(x, y, plansza, true);
            }
            else
            {
                tmp1 = Czarne.TheChosenOne(x, y, plansza, false);
                tmp2 = Czarne.TheChosenOne(x, y, plansza, true);
            }

            tmp1 = checker(tmp1, x, y, plansza);
            tmp2 = checker(tmp2, x, y, plansza);
            tmp3 = roshadachecker(plansza, x, y);
            if (checkcheck(plansza, 8, 8))
                tmp3 = null;


            if (tmp1 == null && tmp2 == null && tmp3 == null)
            {
                Console.WriteLine("hmm");
                return null;
            }

            string[] hym;
            hym = bazowykolor();


            if (tmp1 != null)
            {
                int[] kolor1 = new int[tmp1.Length / 2];

                for (int i = 0; i < kolor1.Length; i++)
                {
                    kolor1[i] = 8 * tmp1[i, 0] + tmp1[i, 1];
                }

                for (int i = 0; i < kolor1.Length; i++)
                {
                    hym[kolor1[i]] = "AliceBlue";
                }
            }
            if (tmp2 != null)
            {
                int[] kolor2 = new int[tmp2.Length / 2];

                for (int i = 0; i < kolor2.Length; i++)
                {
                    kolor2[i] = 8 * tmp2[i, 0] + tmp2[i, 1];
                }

                for (int i = 0; i < kolor2.Length; i++)
                {
                    hym[kolor2[i]] = "Red";
                }
            }
            if (tmp3 != null)
            {
                int[] kolor3 = new int[tmp3.Length / 2];

                for (int i = 0; i < kolor3.Length; i++)
                {
                    kolor3[i] = 8 * tmp3[i, 0] + tmp3[i, 1];
                }

                for (int i = 0; i < kolor3.Length; i++)
                {
                    hym[kolor3[i]] = "AliceBlue";
                }
            }


            lastmove(x, y);
            return hym;
        }

        public string[] attack(int x, int y)
        {
            if (clicked)
            {
                int[,] tmp;
                int[,] tmpr;

                if (ruch)
                {
                    tmp = Biale.TheChosenOne(lastmoveX, lastmoveY, plansza, true);
                }
                else
                {
                    tmp = Czarne.TheChosenOne(lastmoveX, lastmoveY, plansza, true);
                }

                //tmp = checker(tmp, x, y, plansza);

                tmpr = roshadachecker(plansza, lastmoveX, lastmoveY);
                if (checkcheck(plansza, 8, 8))
                    tmpr = null;

                if (tmp == null && tmpr == null)
                    return konwersja();

                if (tmpr != null)
                {
                    for (int i = 0; i < tmpr.Length / 2; i++)
                    {
                        if (tmpr[i, 0] == x && tmpr[i, 1] == y)
                        {
                            rosh(tmpr, x, y, i);
                            return konwersja();
                        }
                    }
                }
                if (tmp != null)
                {
                    for (int i = 0; i < tmp.Length / 2; i++)
                    {
                        if (tmp[i, 0] == x && tmp[i, 1] == y)
                        {
                            ///
                            char who;
                            if (ruch)
                            {
                                who = Biale.armyattack(x, y, lastmoveX, lastmoveY);
                                Czarne.death(x, y);
                            }
                            else
                            {
                                who = Czarne.armyattack(x, y, lastmoveX, lastmoveY);
                                Biale.death(x, y);
                            }

                            if (who == 'x')
                                return konwersja();

                            plansza[lastmoveX, lastmoveY] = '0';
                            plansza[x, y] = who;
                            //checkcheck

                            ruch = !ruch;
                            clicked = false;

                        }
                    }
                }
                
            }
            return konwersja();
        }


        public string[] move(int x, int y)
        {
            if (clicked)
            {
                int[,] tmp;
                int[,] tmpr;
                if (ruch)
                {
                    tmp = Biale.TheChosenOne(lastmoveX, lastmoveY, plansza, false);
                }
                else
                {
                    tmp = Czarne.TheChosenOne(lastmoveX, lastmoveY, plansza, false);
                }

                tmp = checker(tmp, lastmoveX, lastmoveY, plansza);
                tmpr = roshadachecker(plansza, lastmoveX, lastmoveY);
                if (checkcheck(plansza, 8, 8))
                    tmpr = null;

                if (tmp == null && tmpr == null)
                    return konwersja();

                if(tmpr != null)
                {
                    for (int i = 0; i < tmpr.Length / 2; i++)
                    {
                        if (tmpr[i, 0] == x && tmpr[i, 1] == y)
                        {
                            rosh(tmpr, x, y, i);
                            return konwersja();
                        }
                    }
                }
                if (tmp != null)
                {
                    for (int i = 0; i < tmp.Length / 2; i++)
                    {
                        if (tmp[i, 0] == x && tmp[i, 1] == y)
                        {
                            char who;
                            if (ruch)
                                who = Biale.armymove(x, y, lastmoveX, lastmoveY);
                            else
                                who = Czarne.armymove(x, y, lastmoveX, lastmoveY);

                            if (who == 'x')
                            {
                                return konwersja();
                            }


                            plansza[lastmoveX, lastmoveY] = '0';
                            plansza[x, y] = who;
                            //checkcheck

                            ruch = !ruch;
                            clicked = false;
                            if (checkmate())
                            {
                                Console.WriteLine("WIN");
                            }
                        }
                    }
                }

            }
            return konwersja();
        }


        public void rosh(int[,] tmpr, int x, int y, int i)
        {
            if (tmpr[i, 1] == 2)
            {
                if (ruch)
                {
                    Biale.roszada(false, true, lastmoveX, lastmoveY);
                    plansza[x, y] = 'k';
                    plansza[x, y + 1] = 'w';
                    plansza[x, 0] = '0';
                    plansza[x, 4] = '0';
                }
                else
                {
                    Czarne.roszada(false, true, lastmoveX, lastmoveY);
                    plansza[x, y] = 'k';
                    plansza[x, y + 1] = 'w';
                    plansza[x, 0] = '0';
                    plansza[x, 4] = '0';
                }
            }
            if (tmpr[i, 1] == 6)
            {
                if (ruch)
                {
                    Biale.roszada(false, false, lastmoveX, lastmoveY);
                    plansza[x, y] = 'k';
                    plansza[x, y - 1] = 'w';
                    plansza[x, 7] = '0';
                    plansza[x, 4] = '0';
                }
                else
                {
                    Czarne.roszada(false, false, lastmoveX, lastmoveY);
                    plansza[x, y] = 'k';
                    plansza[x, y - 1] = 'w';
                    plansza[x, 7] = '0';
                    plansza[x, 4] = '0';
                }

            }

            ruch = !ruch;
            clicked = false;
            if (checkmate())
            {
                Console.WriteLine("WIN");
            }
            Console.WriteLine("ROSZADA");
        }




        public string[] rev(int x, int y)
        {
            string[] tmp2 = new string[4];
            char[] tmp1;
            xdorev = x;
            ydorev = y;

            if (!ruch)
            {
                    tmp1 = Biale.whorevive(x, y);
                    for (int j = 0; j < 4; j++)
                    {
                            tmp2[j] = "b" + tmp1[j];
                    }
            }
            else
            {
                    tmp1 = Czarne.whorevive(x, y);
                    for (int j = 0; j < 4; j++)
                    {
                            tmp2[j] = "c" + tmp1[j];
                    }
            }

            for (int i = 0; i < tmp2.Length; i++)
            {
                switch (tmp2[i])
                {
                    case "cw":
                        tmp2[i] = "/ViewModel/Figury/cw.png";
                        break;
                    case "bw":
                        tmp2[i] = "/ViewModel/Figury/bw.png";
                        break;
                    case "cg":
                        tmp2[i] = "/ViewModel/Figury/cg.png";
                        break;
                    case "bg":
                        tmp2[i] = "/ViewModel/Figury/bg.png";
                        break;
                    case "cs":
                        tmp2[i] = "/ViewModel/Figury/cs.png";
                        break;
                    case "bs":
                        tmp2[i] = "/ViewModel/Figury/bs.png";
                        break;
                    case "ch":
                        tmp2[i] = "/ViewModel/Figury/ch.png";
                        break;
                    case "bh":
                        tmp2[i] = "/ViewModel/Figury/bh.png";
                        break;
                }
            }

            return tmp2;
        }

        public string[] rivia(int x)
        {
            char wybraniec = 'h';

            switch (x)
            {
                case 1:
                    wybraniec = 'w';
                    break;
                case 2:
                    wybraniec = 's';
                    break;
                case 3:
                    wybraniec = 'g';
                    break;
                case 4:
                    wybraniec = 'h';
                    break;

            }
            if (!ruch)
            {
                Biale.revive(wybraniec, false);
            }
            else
            {
                Czarne.revive(wybraniec, true);
            }
            plansza[xdorev, ydorev] = wybraniec;

            return konwersja();
        }


        


        public string[] bazowykolor()
        {
            string[] tmp = new string[64];
            bool przelacznik = true;
            for (int i = 0; i < 64; i++)
            {
                if (przelacznik)
                    tmp[i] = "AntiqueWhite";
                else
                    tmp[i] = "DarkSlateGray";

                przelacznik = !przelacznik;
                if (i == 7 || (i - 7) % 8 == 0)
                    przelacznik = !przelacznik;
            }
            return tmp;
        }


        public string[] konwersja()
        {
            string[] tmp = new string[64];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (plansza[i, j] == '0')
                        tmp[8 * i + j] = " ";
                    else
                    {
                        if(Biale.rozklad[i,j] != '0')
                            tmp[8 * i + j] = "b" + plansza[i, j];
                        else
                            tmp[8 * i + j] = "c" + plansza[i, j];
                    }
                        
                }
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                switch (tmp[i])
                {
                    case "cp":
                        tmp[i] = "/ViewModel/Figury/cp.png";
                        break;    
                    case "bp":    
                        tmp[i] = "/ViewModel/Figury/bp.png";
                        break;    
                    case "cw":    
                        tmp[i] = "/ViewModel/Figury/cw.png";
                        break;    
                    case "bw":    
                        tmp[i] = "/ViewModel/Figury/bw.png";
                        break;    
                    case "cg":    
                        tmp[i] = "/ViewModel/Figury/cg.png";
                        break;    
                    case "bg":    
                        tmp[i] = "/ViewModel/Figury/bg.png";
                        break;    
                    case "cs":    
                        tmp[i] = "/ViewModel/Figury/cs.png";
                        break;    
                    case "bs":    
                        tmp[i] = "/ViewModel/Figury/bs.png";
                        break;    
                    case "ch":    
                        tmp[i] = "/ViewModel/Figury/ch.png";
                        break;    
                    case "bh":    
                        tmp[i] = "/ViewModel/Figury/bh.png";
                        break;    
                    case "ck":    
                        tmp[i] = "/ViewModel/Figury/ck.png";
                        break;    
                    case "bk":    
                        tmp[i] = "/ViewModel/Figury/bk.png";
                        break;
                    case " ":
                        tmp[i] = "/ViewModel/Figury/clear.png";
                        break;

                }
            }
            return tmp;
        }



        public void lastmove(int x, int y)
        {
            lastmoveX = x;
            lastmoveY = y;
            clicked = true;
        }


        public bool checkcheck(char[,] fakeplansza, int x, int y)
        {
            int[,] tmp;
            if (!ruch)
            {
                tmp = Biale.mozliwosciarmii(fakeplansza, x, y);
            }
            else
            {
                tmp = Czarne.mozliwosciarmii(fakeplansza, x, y);
            }

            if(tmp != null)
            {
                for (int k = 0; k < tmp.Length / 2; k++)
                {
                    if (fakeplansza[tmp[k, 0], tmp[k, 1]] == 'k')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int[,] roshadachecker(char[,] planszaa, int xx, int yy)
        {
            int[,] tmp;
            if (ruch)
                tmp = Biale.roszada(true, true, xx, yy);
            else
                tmp = Czarne.roszada(true, true, xx, yy);
            if (tmp == null)
                return null;

            List<int> tmpp = new List<int>();
            char[,] podmianka = new char[8, 8];
            int[,] after;
            int x;
            if (ruch)
                x = 7;
            else
                x = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    podmianka[i, j] = planszaa[i, j];
                }
            }

            for (int i = 0; i < tmp.Length / 2; i++)
            { 
                if(tmp[i,1] == 2)
                {
                    podmianka[x, tmp[i, 1]] = 'k';
                    podmianka[x, tmp[i, 1] + 1] = 'w';
                    podmianka[x, 0] = '0';
                    podmianka[x, 4] = '0';
                    if (!checkcheck(podmianka, 8, 8))
                    {
                        tmpp.Add(x);
                        tmpp.Add(tmp[i, 1]);
                    }
                    podmianka[x, tmp[i, 1]] = '0';
                    podmianka[x, tmp[i, 1] + 1] = '0';
                    podmianka[x, 0] = 'w';
                    podmianka[x, 4] = 'k';

                }

                if (tmp[i, 1] == 6)
                {
                    podmianka[x, tmp[i, 1]] = 'k';
                    podmianka[x, tmp[i, 1] - 1] = 'w';
                    podmianka[x, 7] = '0';
                    podmianka[x, 4] = '0';
                    if (!checkcheck(podmianka, 8, 8))
                    {
                        tmpp.Add(x);
                        tmpp.Add(tmp[i, 1]);
                    }
                    podmianka[x, tmp[i, 1]] = '0';
                    podmianka[x, tmp[i, 1] - 1] = '0';
                    podmianka[x, 7] = 'w';
                    podmianka[x, 4] = 'k';

                }

            }
            after = listto2darray(tmpp);
            return after;


        }

        public int[,] checker(int[,] b4, int x, int y, char[,] planszaa)
        {
            List<int> tmp = new List<int>();
            char[,] podmianka = new char[8,8];
            int[,] after;

            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j< 8; j++)
                {
                    podmianka[i, j] = planszaa[i, j];
                }
            }

            if (b4 != null)
            {
                char ktos = podmianka[x, y];
                podmianka[x, y] = '0';
                for (int i = 0; i< b4.Length / 2; i++)
                {
                    if(podmianka[b4[i, 0], b4[i, 1]] != '0')
                    {
                        podmianka[b4[i, 0], b4[i, 1]] = ktos;
                        if (!checkcheck(podmianka, b4[i, 0], b4[i, 1]))
                        {
                            tmp.Add(b4[i, 0]);
                            tmp.Add(b4[i, 1]);
                        }
                    }
                    else
                    {
                        podmianka[b4[i, 0], b4[i, 1]] = ktos;

                        if (!checkcheck(podmianka, 8, 8))
                        {
                            tmp.Add(b4[i, 0]);
                            tmp.Add(b4[i, 1]);
                        }
                    }
                    
                    podmianka[b4[i, 0], b4[i, 1]] = '0';
                }
                after = listto2darray(tmp);
                return after;
            }
            return null;
        }

        public bool checkmate()
        {
            int[,] tmp;
            int[,] tmp1;
            int[,] tmp2;
            List<int> zasoby = new List<int>();


            if (ruch)
            {
                tmp = Biale.zasobyarmii();
                for (int i = 0; i<tmp.Length/2; i++)
                {
                    tmp1 = Biale.TheChosenOne(tmp[i,0], tmp[i,1], plansza, false);
                    tmp2 = Biale.TheChosenOne(tmp[i, 0], tmp[i, 1], plansza, true);

                    tmp1 = checker(tmp1, tmp[i, 0], tmp[i, 1], plansza);
                    tmp2 = checker(tmp2, tmp[i, 0], tmp[i, 1], plansza);

                    if(tmp1 != null)
                    {
                        for (int a = 0; a < tmp1.Length / 2; a++)
                        {
                            zasoby.Add(tmp1[a, 0]);
                            zasoby.Add(tmp1[a, 1]);
                        }
                    }
                    if (tmp2 != null)
                    {
                        for (int a = 0; a < tmp2.Length / 2; a++)
                        {
                            zasoby.Add(tmp2[a, 0]);
                            zasoby.Add(tmp2[a, 1]);
                        }
                    }
                }
                tmp = listto2darray(zasoby);

            }
            else
            {
                tmp = Czarne.zasobyarmii();
                for (int i = 0; i < tmp.Length / 2; i++)
                {
                    tmp1 = Czarne.TheChosenOne(tmp[i, 0], tmp[i, 1], plansza, false);
                    tmp2 = Czarne.TheChosenOne(tmp[i, 0], tmp[i, 1], plansza, true);

                    tmp1 = checker(tmp1, tmp[i, 0], tmp[i, 1], plansza);
                    tmp2 = checker(tmp2, tmp[i, 0], tmp[i, 1], plansza);

                    if (tmp1 != null)
                    {
                        for (int a = 0; a < tmp1.Length / 2; a++)
                        {
                            zasoby.Add(tmp1[a, 0]);
                            zasoby.Add(tmp1[a, 1]);
                        }
                    }
                    if (tmp2 != null)
                    {
                        for (int a = 0; a < tmp2.Length / 2; a++)
                        {
                            zasoby.Add(tmp2[a, 0]);
                            zasoby.Add(tmp2[a, 1]);
                        }
                    }
                }
                tmp = listto2darray(zasoby);
            }
            if (tmp.Length == 0)
            {
                return true;
            }
            else
            {
                for (int a = 0; a < tmp.Length / 2; a++)
                {
                    Console.WriteLine(tmp[a, 0] + " : " + tmp[a, 1]);
                }
                Console.WriteLine("---------------------------");
                return false;
            }
            
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
