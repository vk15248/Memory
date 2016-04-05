using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MemorijaUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BoardPage : Page
    {
        public BoardPage()
        {
            this.InitializeComponent();
            int cols = Convert.ToInt32(Math.Sqrt(Board.Instance.NumberOfCards));
            for (int i = 0; i < cols; i++)
                BoardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < cols+1; i++)
                BoardGrid.RowDefinitions.Add(new RowDefinition());
            foreach(RowDefinition rowDef in BoardGrid.RowDefinitions)
            {
                rowDef.Height = GridLength.Auto;
            }
            EventHandlerHelper.displayBoard(cols, BoardGrid);
        }


/*        private void displayBoard(int cols, Grid BoardGrid)
        {
            int j = 0;
            int k = 0;
            for (int i = 0; i < Board.Instance.NumberOfCards; i++)
            {
                CardControl cardControl = new CardControl();
                cardControl.CardValue = Board.Instance.Cards[i];
                cardControl.Margin = new Thickness(6, 6, 6, 6);
                Grid.SetColumn(cardControl, j);
                Grid.SetRow(cardControl, k);
                if (k == cols - 1) { k = 0; j++; }
                else k++;
                BoardGrid.Children.Add(cardControl);
            }

        }*/
    }
}
