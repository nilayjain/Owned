using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Owned.Resources;
using System.IO.IsolatedStorage;

namespace Owned
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        // Constructor
        public MainPage()
        {
          App.settings = IsolatedStorageSettings.ApplicationSettings;
           try
           {
               App.name = (String)App.settings["name"];
               
           }
           catch (KeyNotFoundException ex)
           {
               App.settings.Add("name", "noname");
               App.settings.Save();
           }             //Nitesh
           InitializeComponent();
           if (!App.name.Equals(""))
           {
               name.Visibility = System.Windows.Visibility.Collapsed;
               name_inp.Visibility = System.Windows.Visibility.Collapsed;
               submit.Visibility = System.Windows.Visibility.Collapsed;
               greet.Text = "Hello " + App.name;
           }
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private void new_user(object sender, RoutedEventArgs e)
        {
            App.name = "";
        }
        private void classic_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/classic.xaml",UriKind.Relative));
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            App.name = name_inp.Text;
            App.settings["name"] = App.name;
            greet.Text = "Hello " + App.name;
            name.Visibility = System.Windows.Visibility.Collapsed;
            name_inp.Visibility = System.Windows.Visibility.Collapsed;
            submit.Visibility = System.Windows.Visibility.Collapsed; 
            App.settings.Save();               //Nitesh
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/alarm.xaml",UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/leaderboard.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}