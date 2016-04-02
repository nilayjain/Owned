using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;

namespace Owned
{
    public partial class leaderboard : PhoneApplicationPage
    {
        public leaderboard()
        {
            InitializeComponent();
            RefreshTodoItems();
        }

           private async void RefreshTodoItems()
            {
               
                 MobileServiceInvalidOperationException exception = null;
            try
            {
              // Query that returns all items.   
                List<highscore> hs = await App.MobileService.GetTable<highscore>().ToListAsync();

                for(int i=0;i<8;i++)
                {
                    names.Text = names.Text + "\n" + hs[i].username;
                    scores.Text = scores.Text + "\n" + hs[i].score;
                }
             }
            catch (MobileServiceInvalidOperationException e)
             {
               exception = e;
              }    
        }
        }
}