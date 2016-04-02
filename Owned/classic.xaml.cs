using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using System.Resources;
namespace Owned
{
    public partial class classic : PhoneApplicationPage
    {
        int[] cl = { -1, -1, -1, -1 };
        int x = 0;
        int ans;
        DispatcherTimer dt;
        public classic()
        {
            InitializeComponent();
            
         
            
           
         //write logic here
         dt = new DispatcherTimer();
         set();
         progress.Value = 100;
         dt.Interval = new TimeSpan(0, 0, 0, 0, 30);
         dt.Tick += dt_Tick;
   
         
        }

     

   
        void dt_Tick(object sender, System.EventArgs e)
        {
            progress.Value -= 1;
            if (progress.Value == 0)
                gameover();
            //throw new System.NotImplementedException();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (compcol(sender))
            {
                App.score++;
                score.Text = App.score +"";
                set();
                dt.Interval = new TimeSpan(0,0,0,0,dt.Interval.Milliseconds - 10);
                dt.Start();
                progress.Value = 100;
            }
            else
                gameover();
           
        }
        public void set()
        {
            b1.Background = colorify();
            b1.BorderBrush = b1.Background;
            b1.Foreground = b1.Background;
            b2.Background = colorify();
            b2.BorderBrush = b2.Background;
            b3.Background = colorify();
            b3.BorderBrush = b3.Background;
            setcolortext();
            color_text.Foreground = colorify();
            reset();
        }

        public void reset()
        {
            x = 0;
            cl[0] = -1;
            cl[1] = -1;
            cl[2] = -1;
            cl[3] = -1;
        }

        public SolidColorBrush colorify()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 6);
            while (cl.Contains(i))
                i = rnd.Next(0, 6);
            cl[x] = i;
            switch (i)
            {
                case 0:
                    x++;
                    return new SolidColorBrush(Colors.Red);
                case 1:
                    x++;
                    return new SolidColorBrush(Colors.Blue);
                case 2:
                    x++;
                    return new SolidColorBrush(Colors.Purple);
                case 3:
                    x++;
                    return new SolidColorBrush(Colors.Orange);
                case 4:
                    x++;
                    return new SolidColorBrush(Colors.Green);
                case 5:
                    x++;
                    return new SolidColorBrush(Colors.White);
                default:
                    return new SolidColorBrush(Colors.Blue);
            }
        }

        public void setcolortext()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 3);
            ans = i;
            switch (cl[i])
            {
                case 0:
                    color_text.Text = "Red";
                    break;
                case 1:
                    color_text.Text = "Blue";
                    break;
                case 2:
                    color_text.Text = "Purple";
                    break;
                case 3:
                    color_text.Text = "Orange";
                    break;
                case 4:
                    color_text.Text = "Green";
                    break;
                case 5:
                    color_text.Text = "White";
                    break;
            }
        }
        public bool compcol(object sender)
        {
            switch (ans)
            {
                case 0:
                    return ((Button)sender).Equals(b1);
                case 1:
                    return ((Button)sender).Equals(b2);
                case 2:
                    return ((Button)sender).Equals(b3);
                default :
                    return true;

            }
        }
        public void gameover()
        {
            dt.Stop();
            NavigationService.Navigate(new Uri("/gameover.xaml", UriKind.Relative));
        }
        
    }
}
