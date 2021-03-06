﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MemorijaUniversal
{
    class EventHandlerHelper
    {
        public static Windows.UI.Xaml.Controls.TextBlock PlayerName { get; set;}
        public static Windows.UI.Xaml.Controls.TextBlock PlayerScore { get; set; }
        public static double Width { get; set; }
        public static double Height { get; set; }

        public static void displayBoard(int cols, Windows.UI.Xaml.Controls.Grid BoardGrid)
        {
            BoardGrid.Children.Clear();
            int j = 0;
            int k = 0;
            for (int i = 0; i < Board.Instance.NumberOfCards; i++)
            {

                CardControl cardControl = new CardControl();
                cardControl.CardValue = Board.Instance.Cards[i];
                cardControl.Margin = new Thickness(2, 2, 2, 2);
                cardControl.Height = (Height / (cols+1)) -2;
                cardControl.Width = (Width / cols) -2;
                cardControl.Visibility = cardControl.CardValue.Isout ? Visibility.Collapsed : Visibility.Visible;
                Windows.UI.Xaml.Controls.Grid.SetColumn(cardControl, j);
                Windows.UI.Xaml.Controls.Grid.SetRow(cardControl, k);

                if (j == cols - 1) {
                    j = 0; k++;
                }
                else
                    j++;
                    BoardGrid.Children.Add(cardControl);
                if(PlayerName!=null)
                    PlayerName.Text = Board.Instance.CurrentPlayerText;
                if (PlayerScore != null)
                    PlayerScore.Text = Board.Instance.CurrentScoreText;
            }

            openGameOverScreen(BoardGrid);
        }

        public static async void openGameOverScreen(Windows.UI.Xaml.Controls.Grid BoardGrid)
        {
            if (Board.Instance.isGameOver())
            {
                var dialog = new ContentDialog()
                {
                    Title = "Game over!",
                    MaxWidth = 400,// Required for Mobile!
                    Content = "Winner is " + Board.Instance.getWinner() + "\n" + Board.Instance.getScores()
                };
                dialog.PrimaryButtonText = "Start new game";
                dialog.SecondaryButtonText = "Go back to set up";
                dialog.IsPrimaryButtonEnabled = true;
                dialog.PrimaryButtonClick +=  delegate
                {
                    Board.Instance.startGame(Board.Instance.NumberOfCards, Board.Instance.NumberOfPlayers);
                    displayBoard(Convert.ToInt32(Math.Sqrt(Board.Instance.NumberOfCards)), BoardGrid);
                    dialog.Hide();
                };
                dialog.SecondaryButtonClick += delegate
                {
                    Page boardPage = getParentPage(BoardGrid);
                    boardPage.Frame.Navigate(typeof(MainPage));
                    dialog.Hide();
                };

                var result = await dialog.ShowAsync();
            }
        }

        private static Page getParentPage(Grid control)
        {
            if (control.Parent is Page) return (Page)control.Parent;
            else return getParentPage((Grid)control.Parent);
        }
    }
}
