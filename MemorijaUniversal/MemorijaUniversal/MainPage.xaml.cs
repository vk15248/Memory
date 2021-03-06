﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemorijaUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string numberOfPlayers;
        private string numberOfCards;

        public string NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }

            set
            {
                numberOfPlayers = value;
            }
        }

        public string NumberOfCards
        {
            get
            {
                return numberOfCards;
            }

            set
            {
                numberOfCards = value;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                var statusBar = StatusBar.GetForCurrentView();
                statusBar.HideAsync();
            }
        }

        private void SetUpGame(object sender, RoutedEventArgs e)
        {
            Board.Instance.startGame(int.Parse(picker2.CurrentValue), int.Parse(picker1.CurrentValue));
           // BoardPage boardPage = new BoardPage();
            this.Frame.Navigate(typeof(BoardPage));
            // this.Content = boardPage;
        }
    }
}
