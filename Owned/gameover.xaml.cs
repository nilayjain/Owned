using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace Owned
{
    public partial class gameover : PhoneApplicationPage
    {
        
        public gameover()
        {
            InitializeComponent();
            try
            {
                App.highscore = (int)App.settings["highscore"];
            }
            catch (KeyNotFoundException ex)
            {
                App.settings.Add("highscore", 0);
                App.settings.Save();
            }
            score.Text = App.score + "";
            if (App.score > App.highscore)
            {
                App.highscore = App.score;
                App.settings["highscore"] = App.highscore;
                App.settings.Save();
            }
            highscore.Text = App.highscore + "";
        }
            
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            main();
            
            //       NavigationService.Navigate(new Uri("/classic.xaml", UriKind.Relative));
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            highscore hs = new highscore();
            hs.score = App.score;
            hs.username = App.name;
            await App.MobileService.GetTable<highscore>().InsertAsync(hs);
            main();
        }
        public void main()
        {
            App.score = 0;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

    }
}