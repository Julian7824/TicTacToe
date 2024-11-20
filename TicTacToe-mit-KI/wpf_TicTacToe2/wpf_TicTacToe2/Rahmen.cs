using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace wpf_TicTacToe2
{
    
    internal class Rahmen
    {
      private WrapPanel wrapPanel = new WrapPanel();

        public WrapPanel WrapPanel { get {  return wrapPanel; } }
        public Rahmen() 
        {
            wrapPanel.Width = 240;
            wrapPanel.Height = 240;
            wrapPanel.Background = new SolidColorBrush(Colors.Black);
            wrapPanel.Margin = new System.Windows.Thickness(100, -30, 0, 0);
        }
    }
}
