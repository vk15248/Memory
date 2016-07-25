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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MemorijaUniversal
{
    public sealed partial class CardControl : UserControl
    {
        public CardControl()
        {
            this.InitializeComponent();
            buttonImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/background1.jpg"));
        }

        public static readonly DependencyProperty CardProperty = DependencyProperty.Register
         (
              "CardValue",
              typeof(Card),
              typeof(CardControl),
              new PropertyMetadata(new Card(0))
         );

        public Card CardValue
        {
            get { return (Card)GetValue(CardProperty); }
            set { SetValue(CardProperty, value); }
        }

        private void RevealCard(object sender, RoutedEventArgs e)
        {
            if (!CardValue.Isout)
            { 
                buttonImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Board.Instance.Theme + "/" + CardValue.Number.ToString() + ".jpg"));
                if (Board.Instance.playMove(CardValue))
                    EventHandlerHelper.displayBoard(Convert.ToInt32(Math.Sqrt(Board.Instance.NumberOfCards)), (Grid)this.Parent);
            }
        }
    }
}
