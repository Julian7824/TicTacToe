using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_TicTacToe2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
        }

        Random random = new Random();
        int i,iPattzaehler = 0,iRanNum;
        int iPatts = 0, iXwinns = 0 , iOwinns = 0;
        char currentSpieler = 'X';
        string gewinner = "";

        Rahmen rahmen;
        Elemente[] tictactoeButtons = new Elemente[9];

        private void Spiel_Erstellen(object sender, RoutedEventArgs e)
        {
            rahmen = new Rahmen();
            Grid.Children.Add(rahmen.WrapPanel);
            for (i = 0; i < 9; i++)
            {
                tictactoeButtons[i] = new Elemente();
                rahmen.WrapPanel.Children.Add(tictactoeButtons[i].Button);
                tictactoeButtons[i].Button.Click += new RoutedEventHandler(Spielen);
            }
            anzeigeLabelsUpdaten();
            bSpielStarten.IsEnabled = false;
            bNeueRunde.IsEnabled = true;
        }
        private void Spielen(object sender, RoutedEventArgs e)
        {
            Elemente clickedElement = tictactoeButtons.FirstOrDefault(element => element.Button == sender as Button);

            if (clickedElement.Button.Content.ToString() != "")
            {
                MessageBox.Show("Dieses Feld ist bereits belegt"); return;
                
            }
            //X
            else
            {
                if(currentSpieler == 'X')
                {
                    if (iPattzaehler != 9 && gewinner == "")
                    {
                        clickedElement.Button.Content = 'X';
                        iPattzaehler++;
                        check();
                        anzeigeLabelsUpdaten();
                    }

                }
                currentSpieler = (currentSpieler == 'X') ? 'O' : 'X'; 
                //O
                if(iPattzaehler != 9 && gewinner == "")
                {
                    zugKI();
                    check();
                    anzeigeLabelsUpdaten();
                    currentSpieler = (currentSpieler == 'X') ? 'O' : 'X';//X
                }               
            }

        }
        private void zugKI()
        {
            if (!makeIntelligentMove())
            {
                do
                {
                    iRanNum = random.Next(0, 9);

                } while (tictactoeButtons[iRanNum].Button.Content.ToString() != "");
                tictactoeButtons[iRanNum].Button.Content = "O";
            }
            iPattzaehler++;            
        }
             private bool makeIntelligentMove()
        {

            //Angriff
            //Feld1
            if (tictactoeButtons[1].Button.Content.ToString() == "O" && tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[0].Button.Content.ToString() == "" ||
                tictactoeButtons[3].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "O" && tictactoeButtons[0].Button.Content.ToString() == "" ||
                tictactoeButtons[8].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[0].Button.Content.ToString() == "")
            {
                tictactoeButtons[0].Button.Content = "O";
                return true;
            }
            //Feld2
            if (
                tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[1].Button.Content.ToString() == "" ||
                tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[7].Button.Content.ToString() == "O" && tictactoeButtons[1].Button.Content.ToString() == "")
            {
                tictactoeButtons[1].Button.Content = "O";
                return true;
            }
            //Feld3
            if (
                tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[1].Button.Content.ToString() == "O" && tictactoeButtons[2].Button.Content.ToString() == "" ||
                tictactoeButtons[6].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[2].Button.Content.ToString() == "" ||
                tictactoeButtons[5].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O" && tictactoeButtons[2].Button.Content.ToString() == "")
            {
                tictactoeButtons[2].Button.Content = "O";
                return true;
            }
            //Feld4
            if (
                tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "O" && tictactoeButtons[3].Button.Content.ToString() == "" ||
                tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[5].Button.Content.ToString() == "O" && tictactoeButtons[3].Button.Content.ToString() == "")
            {
                tictactoeButtons[3].Button.Content = "O";
                return true;
            }
            //Feld5
            if (
                tictactoeButtons[1].Button.Content.ToString() == "O" && tictactoeButtons[7].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "" ||
                tictactoeButtons[3].Button.Content.ToString() == "O" && tictactoeButtons[5].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "" ||
                tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "" ||
                tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "")
            {
                tictactoeButtons[4].Button.Content = "O";
                return true;
            }
            //Feld6
            if (
                tictactoeButtons[3].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[5].Button.Content.ToString() == "" ||
                tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O" && tictactoeButtons[5].Button.Content.ToString() == "")
            {
                tictactoeButtons[5].Button.Content = "O";
                return true;
            }
            //Feld7
            if (
                tictactoeButtons[7].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "" ||
                tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[3].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "" ||
                tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "")
            {
                tictactoeButtons[6].Button.Content = "O";
                return true;
            }
            //Feld8
            if (
                tictactoeButtons[1].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[7].Button.Content.ToString() == "" ||
                tictactoeButtons[6].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O" && tictactoeButtons[7].Button.Content.ToString() == "")
            {
                tictactoeButtons[7].Button.Content = "O";
                return true;
            }
            //Feld9
            if (
                tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[5].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "" ||
                tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "" ||
                tictactoeButtons[6].Button.Content.ToString() == "O" && tictactoeButtons[7].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "")
            {
                tictactoeButtons[8].Button.Content = "O";
                return true;
            }
            //Verteidigung
            //Feld1
            if (tictactoeButtons[1].Button.Content.ToString() == "X" &&  tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[0].Button.Content.ToString() == "" ||
                tictactoeButtons[3].Button.Content.ToString() == "X" &&  tictactoeButtons[6].Button.Content.ToString() == "X" && tictactoeButtons[0].Button.Content.ToString() == "" ||
                tictactoeButtons[8].Button.Content.ToString() == "X" &&  tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[0].Button.Content.ToString() == "" )
            {
                tictactoeButtons[0].Button.Content = "O";
                return true;
            }

            //Feld2
            if (tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[1].Button.Content.ToString() == "" ||
                tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[7].Button.Content.ToString() == "X" && tictactoeButtons[1].Button.Content.ToString() == "")
            {
                tictactoeButtons[1].Button.Content = "O";
                return true;
            }

            //Feld3
            if (tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[1].Button.Content.ToString() == "X" && tictactoeButtons[2].Button.Content.ToString() == "" ||
                tictactoeButtons[6].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[2].Button.Content.ToString() == "" ||
                tictactoeButtons[5].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X" && tictactoeButtons[2].Button.Content.ToString() == "" )
            {
                tictactoeButtons[2].Button.Content = "O";
                return true;
            }

            //Feld4
            if (tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[6].Button.Content.ToString() == "X" && tictactoeButtons[3].Button.Content.ToString() == "" ||
                tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[5].Button.Content.ToString() == "X" && tictactoeButtons[3].Button.Content.ToString() == "")
            {
                tictactoeButtons[3].Button.Content = "O";
                return true;
            }

            //Feld5
            if (tictactoeButtons[1].Button.Content.ToString() == "X" && tictactoeButtons[7].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "" ||
                iPattzaehler == 1 && tictactoeButtons[4].Button.Content.ToString() == "" ||
                tictactoeButtons[3].Button.Content.ToString() == "X" && tictactoeButtons[5].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "" ||
                tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "" ||
                tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[6].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "")
            {
                tictactoeButtons[4].Button.Content = "O";
                return true;
            }

            //Feld6
            if (tictactoeButtons[3].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[5].Button.Content.ToString() == "" ||
                tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X" && tictactoeButtons[5].Button.Content.ToString() == "")
            {
                tictactoeButtons[5].Button.Content = "O";
                return true;
            }

            //Feld7
            if (tictactoeButtons[7].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X" && tictactoeButtons[6].Button.Content.ToString() == "" ||
                tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[3].Button.Content.ToString() == "X" && tictactoeButtons[6].Button.Content.ToString() == "" ||
                tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[6].Button.Content.ToString() == "")
            {
                tictactoeButtons[6].Button.Content = "O";
                return true;
            }

            //Feld8
            if (tictactoeButtons[1].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[7].Button.Content.ToString() == "" ||
                tictactoeButtons[6].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X" && tictactoeButtons[7].Button.Content.ToString() == "")
            {
                tictactoeButtons[7].Button.Content = "O";
                return true;
            }

            //Feld9
            if (tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[5].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "" ||
                tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "" ||
                tictactoeButtons[6].Button.Content.ToString() == "X" && tictactoeButtons[7].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "")
            {
                tictactoeButtons[8].Button.Content = "O";
                return true;
            }
            return false;
        }
        private bool check()
        {
            if (checkgewinner())
            {
                MessageBox.Show($"Spieler {currentSpieler} hat gewonnen");
                gewinner =  currentSpieler.ToString();
                if(gewinner == "X")
                {
                    iXwinns++;
                }
                else{
                    iOwinns++;
                }
                disableAllButtons();
            }
            else if (iPattzaehler == 9)
            {
                MessageBox.Show("Patt"); disableAllButtons();
                gewinner = "P";
                iPatts++;                
            }
            return false;
        }
        private bool checkgewinner()
        {
            if (tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[1].Button.Content.ToString() == "X" && tictactoeButtons[2].Button.Content.ToString() == "X"
                || tictactoeButtons[3].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[5].Button.Content.ToString() == "X"
                || tictactoeButtons[6].Button.Content.ToString() == "X" && tictactoeButtons[7].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X"
                || tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[3].Button.Content.ToString() == "X" && tictactoeButtons[6].Button.Content.ToString() == "X"
                || tictactoeButtons[1].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[7].Button.Content.ToString() == "X"
                || tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[5].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X"
                || tictactoeButtons[0].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[8].Button.Content.ToString() == "X"
                || tictactoeButtons[2].Button.Content.ToString() == "X" && tictactoeButtons[4].Button.Content.ToString() == "X" && tictactoeButtons[6].Button.Content.ToString() == "X"
                
                || tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[1].Button.Content.ToString() == "O" && tictactoeButtons[2].Button.Content.ToString() == "O"
                || tictactoeButtons[3].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[5].Button.Content.ToString() == "O"
                || tictactoeButtons[6].Button.Content.ToString() == "O" && tictactoeButtons[7].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O"
                || tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[3].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "O"
                || tictactoeButtons[1].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[7].Button.Content.ToString() == "O"
                || tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[5].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O"
                || tictactoeButtons[0].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[8].Button.Content.ToString() == "O"
                || tictactoeButtons[2].Button.Content.ToString() == "O" && tictactoeButtons[4].Button.Content.ToString() == "O" && tictactoeButtons[6].Button.Content.ToString() == "O")
            {
                return true;
            }

            return false;
        }
          private void NeueRunde(object sender, RoutedEventArgs e)
        {
            gewinner = "";
            iPattzaehler = 0;
            currentSpieler = 'X';
            tictactoeButtons[0].Button.Content = "";
            tictactoeButtons[1].Button.Content = "";
            tictactoeButtons[2].Button.Content = "";
            tictactoeButtons[3].Button.Content = "";
            tictactoeButtons[4].Button.Content = "";
            tictactoeButtons[5].Button.Content = "";
            tictactoeButtons[6].Button.Content = "";
            tictactoeButtons[7].Button.Content = "";
            tictactoeButtons[8].Button.Content = "";
            enableAllButtons();
        }
    private void disableAllButtons()
        {
            tictactoeButtons[0].Button.IsEnabled = false;
            tictactoeButtons[1].Button.IsEnabled = false;
            tictactoeButtons[2].Button.IsEnabled = false;
            tictactoeButtons[3].Button.IsEnabled = false;
            tictactoeButtons[4].Button.IsEnabled = false;
            tictactoeButtons[5].Button.IsEnabled = false;
            tictactoeButtons[6].Button.IsEnabled = false;
            tictactoeButtons[7].Button.IsEnabled = false;
            tictactoeButtons[8].Button.IsEnabled = false;
        }
    private void enableAllButtons()
        {
            tictactoeButtons[0].Button.IsEnabled = true;
            tictactoeButtons[1].Button.IsEnabled = true;
            tictactoeButtons[2].Button.IsEnabled = true;
            tictactoeButtons[3].Button.IsEnabled = true;
            tictactoeButtons[4].Button.IsEnabled = true;
            tictactoeButtons[5].Button.IsEnabled = true;
            tictactoeButtons[6].Button.IsEnabled = true;
            tictactoeButtons[7].Button.IsEnabled = true;
            tictactoeButtons[8].Button.IsEnabled = true;
        }
    private void anzeigeLabelsUpdaten()
        {
            lPatts.Content = "Patts:  " + iPatts;
            lXwinns.Content = "Gewinne spieler X:  " + iXwinns;
            lOwinns.Content = "Gewinne spieler O:  " + iOwinns;
        }
    }
}
