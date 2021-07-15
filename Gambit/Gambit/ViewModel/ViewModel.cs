using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Gambit.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model.Silnik silnik = new Model.Silnik();


        private string[] board;
        public string[] Board
        {
            get { return board; }
            private set
            {
                board = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Board)));

            }
        }

        private string[] choice = new string[4];
        public string[] Choice
        {
            get { return choice; }
            private set
            {
                choice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Choice)));

            }
        }


        private bool foc;
        public bool Foc
        {
            get { return foc; }
            private set
            {

                foc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Foc)));

            }
        }

        private Visibility visibility = Visibility.Hidden;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Visibility)));
            }
        }

        private Visibility visibility2;
        public Visibility Visibility2
        {
            get
            {
                return visibility2;
            }
            set
            {
                visibility2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Visibility2)));
            }
        }



        private string[] kolor = new string[64];
        public string[] Kolor
        {
            get { return kolor; }
            private set
            {
                kolor = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kolor)));

            }
        }


        private ICommand start;
        public ICommand Start
        {
            get
            {
                return start ?? (start = new Totolotek.ViewModel.BaseClass.RelayCommand(Strt, null));
            }

        }
        public void Strt(object param)
        {
            Foc = true;
            Visibility2 = Visibility.Hidden;
            Kolor = silnik.bazowykolor();
            Board = silnik.konwersja();
        }



        private ICommand clicked;
        public ICommand Clicked
        {
            get
            {
                return clicked ?? (clicked = new Totolotek.ViewModel.BaseClass.RelayCommand(Clck, null));
            }

        }

        public void Clck(object param)
        {
            var tmp = (string)param;
            int x = chartonumber(Convert.ToSByte(tmp[0]));
            int y = chartonumber(Convert.ToSByte(tmp[1]));

            if (silnik.hmmm(x, y) != null)
            {
                Kolor = silnik.hmmm(x, y);
            }
            else
                Kolor = silnik.bazowykolor();

            Board = silnik.move(x, y);
            Board = silnik.attack(x, y);

            for(int i = 0; i < 8; i++)
            {
                if(Board[i] == "/ViewModel/Figury/bp.png")
                {
                    Foc = false;
                    Visibility = Visibility.Visible;
                    Choice = silnik.rev(x,y);
                }
            }
            for (int i = 56; i < 64; i++)
            {
                if (Board[i] == "/ViewModel/Figury/cp.png")
                {
                    Foc = false;
                    Visibility = Visibility.Visible;
                    Choice = silnik.rev(x, y);
                }
            }

            if (silnik.checkmate())
            {
                //Console.WriteLine("WIN");
                Foc = false;
                MessageBox.Show("Szach-mat", "Partia zakończona", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private ICommand wybor;
        public ICommand Wybor
        {
            get
            {
                return wybor ?? (wybor = new Totolotek.ViewModel.BaseClass.RelayCommand(Wyb, null));
            }

        }

        public void Wyb(object param)
        {
            var tmp = (string)param;
            int x = chartonumber(Convert.ToSByte(tmp[0]));
            Board =  silnik.rivia(x);

            Visibility = Visibility.Hidden;
            Foc = true;
        }




            public int chartonumber(sbyte x)
            {
                switch (x)
                {
                    case 48:
                        return 0;
                    case 49:
                        return 1;
                    case 50:
                        return 2;
                    case 51:
                        return 3;
                    case 52:
                        return 4;
                    case 53:
                        return 5;
                    case 54:
                        return 6;
                    case 55:
                        return 7;
                    case 56:
                        return 8;
                    case 57:
                        return 9;
                    default:
                        return 0;

                }

            }

    }
}
