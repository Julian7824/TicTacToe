using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace wpf_TicTacToe2
{
    internal class Elemente
    {
        int i;
        Button button = new Button();


        public Button Button

        {
            get { return button; }
            set { button = value; }
        }
        public Elemente()
        {
            button.Width = 80;
            button.Height = 80;
            button.Background = new SolidColorBrush(Colors.OrangeRed);
            button.Foreground = new SolidColorBrush(Colors.White);
            button.FontFamily = new FontFamily("Arial Black");
            button.FontSize = 40;
            button.BorderBrush = Brushes.Black;
            button.BorderThickness = new Thickness(3, 3, 3, 3);
            button.Content = "";
        }
    }
}
