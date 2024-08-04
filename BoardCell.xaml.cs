using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrameTikTakToe_2_
{
    /// <summary>
    /// Interaction logic for BoardCell.xaml
    /// </summary>
    public partial class BoardCell : Window
    {
        
        private int posX;
        private int posY;
        public int row;
        public int column;
        public BoardCell(int prow, int pcollumn, string pvalue)
        {
            InitializeComponent();

            row = prow;
            column = pcollumn;
            posX = Screen.PrimaryScreen.Bounds.Width - (((pcollumn-1)*-100) + (Screen.PrimaryScreen.Bounds.Width/2));
            posY = Screen.PrimaryScreen.Bounds.Height - (((prow) * 100) + (Screen.PrimaryScreen.Bounds.Height / 2));

            CellLabel.Content = pvalue;
            Left = posX;
            Top = posY;
            Visibility = Visibility.Visible;
        }

        public void setContent(string content)
        {
            CellLabel.Content = content;
        }

        public void setColor(int r, int g, int b)
        {
            this.Background = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
        }
        private void CellLabel_OnClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = System.Windows.Application.Current.Windows[0] as MainWindow;
            mw.takeTurn((row + 1) * (column + 1) + column * (2 - row) - 1, row, column);
        }
    }
}
