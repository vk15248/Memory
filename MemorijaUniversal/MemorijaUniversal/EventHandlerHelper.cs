using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MemorijaUniversal
{
    class EventHandlerHelper
    {
        public static void displayBoard(int cols, Windows.UI.Xaml.Controls.Grid BoardGrid)
        {
            BoardGrid.Children.Clear();
            int j = 0;
            int k = 0;
            for (int i = 0; i < Board.Instance.NumberOfCards; i++)
            {
                if (!Board.Instance.Cards[i].Isout)
                {
                    CardControl cardControl = new CardControl();
                    cardControl.CardValue = Board.Instance.Cards[i];
                    cardControl.Margin = new Thickness(6, 6, 6, 6);
                    Windows.UI.Xaml.Controls.Grid.SetColumn(cardControl, j);
                    Windows.UI.Xaml.Controls.Grid.SetRow(cardControl, k);

                    if (k == cols - 1)
                    {
                        k = 0; j++; 
                    }
                    else
                        k++;
                    BoardGrid.Children.Add(cardControl);
                }
                else
                {
                    if (k == cols - 1)
                    {
                        k = 0;
                        j++; 
                    }
                    else
                        k++;
                }
            }
        }
    }
}
