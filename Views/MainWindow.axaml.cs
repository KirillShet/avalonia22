using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using Avalonia.Data;
using DynamicData;
using System.Threading.Tasks;
using Avalonia.Threading;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using SkiaSharp;
using System.Collections;
using System.Numerics;
namespace newproject.Views
{
    public partial class MainWindow : Window
    {
        private List<string> pupils = new List<string>();
        private List<string> password = new List<string>();
        private List<string> mail = new List<string>();
        private int index;
        private int povtore;
        private int del;
        private int lenght;
        private string mail1;
        private int osh;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonPressed4(object sender, RoutedEventArgs args)
        {
            page1.IsVisible = true;
            page3.IsVisible = false;
            obnull();
            noname.IsChecked = false;
            Pane.OpenPaneLength = 25;
            pictur2.IsVisible = true;
            pictur1.IsVisible = false;
            Kolos.IsVisible = false;
        }
        public async void ButtonPressed50(object sender, RoutedEventArgs args)
        {
            for (int i = 0; i < pupils.Count; i++)
            {
                if (name1.Text == pupils[i])
                {
                    name1.Background = Brushes.Red;
                    await Task.Delay(1000);
                    name1.Background = Brushes.White;
                }
            }
        }
        public void ButtonPressed3(object sender, RoutedEventArgs args)
        {
            obnull();
        }
        public void ButtonPressed99(object sender, RoutedEventArgs args)
        {
            page1.IsVisible = true;
            page2.IsVisible = false;
            pictur1.IsVisible = false;
            pictur2.IsVisible = true;
        }
        public void ButtonPressed1(object sender, RoutedEventArgs args)
        {
            if (Pane.OpenPaneLength == 25)
            {
                Pane.OpenPaneLength = 100;
                pictur1.IsVisible = true;
                pictur2.IsVisible = false;
                Kolos.IsVisible = true;
            }
            else if (Pane.OpenPaneLength == 100)
            {
                Pane.OpenPaneLength = 25;
                pictur1.IsVisible = false;
                pictur2.IsVisible = true;
                Kolos.IsVisible = false;
            }
        }
        public void ButtonPressed10(object sender, RoutedEventArgs args)
        {
            page1.IsVisible = false;
            page2.IsVisible = true;
            Pane.OpenPaneLength = 25;
            Kolos.IsVisible = false;
        }

        public void Vvod()
        {
            nname.Text = pupils[index];
            ppasword.Text = password[index];
            mmail.Text = mail[index];
        }
        public void ButtonPressed33(object sender, RoutedEventArgs args)
        {
            if (Pane2.OpenPaneLength == 25)
            {
                Pane2.OpenPaneLength = 280;
                pictur12.IsVisible = true;
                pictur22.IsVisible = false;
                Kolos1.IsVisible = true;
                RunButton2.IsEnabled = false;
            }
            else if (Pane2.OpenPaneLength == 280)
            {
                Pane2.OpenPaneLength = 25;
                pictur12.IsVisible = false;
                pictur22.IsVisible = true;
                Kolos1.IsVisible = false;
                RunButton2.IsEnabled = true;
            }
        }
        public async void ClickHandler(object sender, RoutedEventArgs args)
        {
            osh = 0;
            povtore = 0;
            mail1 = Mail.Text;
            if (name1.Text == "" || name1.Text == null)
            {
                name1.Background = Brushes.Red;
            }
            if (password1.Text == "" || password1.Text == null)
            {
                password1.Background = Brushes.Red;
            }
            if (password2.Text == "" || password2.Text == null)
            {
                password2.Background = Brushes.Red;
            }
            if (password1.Text != password2.Text)
            {
                password1.Background = Brushes.Red;
                password2.Background = Brushes.Red;
            }
            if (noname.IsChecked == false)
            {
                noname.Background = Brushes.Red;
            }
            if (Mail.Text == null)
            {
                Mail.Background = Brushes.Red;
                osh = 1;
            }
            else
            {
                bool containsAt = mail1.Contains("@");
                bool endsWithX = mail1.Substring(mail1.Length - 1) == "@";
                if (containsAt == false || endsWithX == true)
                {
                    Mail.Background = Brushes.Red;
                    osh = 1;
                }
            }
            for (int i = 0; i < mail.Count; i++)
            {
                if (mail[i] == Mail.Text)
                {
                    Mail.Background = Brushes.Red;
                    povtore = 1;
                }
                if (pupils[i] == name1.Text)
                {
                    name1.Background = Brushes.Red;
                    povtore = 1;
                }
            }
            button1.IsEnabled = false;
            await Task.Delay(1000);
            Perecras();
            button1.IsEnabled = true;
            if (name1.Text != "" && password1.Text != "" && password2.Text != "" && name1.Text != null && password1.Text != null && password2.Text != null
                && Mail.Text != null && password1.Text == password2.Text && password2.Text != null && osh == 0 && povtore == 0 && noname.IsChecked == true && povtore == 0)
            {
                index = lenght;
                lenght++;
                pupils.Add(name1.Text);
                password.Add(password1.Text);
                mail.Add(Mail.Text);
                page1.IsVisible = false;
                page3.IsVisible = true;
                dobvLIST();
                Vvod();
            }
        }
        public async void ButtonPressed8(object sender, RoutedEventArgs args)
        {
            osh = 0;
            if (name2.Text == "" || name2.Text == null)
            {
                name2.Background = Brushes.Red;
            }
            if (password3.Text == "" || password3.Text == null)
            {
                password3.Background = Brushes.Red;
            }
            if (Mail2.Text == null || Mail2.Text == "")
            {
                Mail2.Background = Brushes.Red;
                osh = 1;
            }
            else
            {
                bool containsAt = mail1.Contains("@");
                bool endsWithX = mail1.Substring(mail1.Length - 1) == "@";
                if (containsAt == false || endsWithX == true)
                {
                    Mail2.Background = Brushes.Red;
                    osh = 1;
                }
            }
            for (int i = 0; i < pupils.Count; i++)
            {
                if (name2.Text == pupils[i] && Mail2.Text == mail[i])
                {
                    povtore = 1;
                    index = i;
                }
            }
            await Task.Delay(1000);
            Perecras();
            if (name2.Text != "" && password3.Text != "" && name2.Text != null && password3.Text != null && Mail2.Text != null && povtore == 1)
            {
                obnull();
                Vvod();
                page3.IsVisible = true;
                page2.IsVisible = false;
            }
        }

        private void Perecras()
        {
            name1.Background = Brushes.White;
            password1.Background = Brushes.White;
            password2.Background = Brushes.White;
            noname.Background = Brushes.White;
            Mail.Background = Brushes.White;
            name2.Background = Brushes.White;
            password3.Background = Brushes.White;
            Mail2.Background = Brushes.White;
        }
        private void obnull()
        {
            name1.Text = null;
            password1.Text = null;
            password2.Text = null;
            Mail.Text = null;
            Mail2.Text = null;
            name2.Text = null;
            password3.Text = null;
        }
        private void ButtonPressed11(object sender, RoutedEventArgs args)
        {
            page3.IsVisible = false;
            page5.IsVisible = true;
        }
        public void dobvLIST()
        {
            Ffirstname.Items.Add(name1.Text);
            Ppassword.Items.Add(password1.Text);
            Eemail.Items.Add(Mail.Text);
        }
        private void ButtonPressed19(object sender, RoutedEventArgs args)
        {
            Pane2.OpenPaneLength = 25;
            pictur12.IsVisible = false;
            pictur22.IsVisible = true;
            Kolos1.IsVisible = false;
            RunButton2.IsEnabled = true;
            page5.IsVisible = false;
            page3.IsVisible = true;
        }
        private async void ButtonPressed20(object sender, RoutedEventArgs args)
        {
            if (delete1.Text == "" || delete1.Text == null)
            {
                delete1.Background = Brushes.Red;
                await Task.Delay(1000);
                delete1.Background = Brushes.White;
            }
            else
            {
                del = Convert.ToInt32(delete1.Text);
                name1.Text = pupils[del];
                password1.Text = password[del];
                Mail.Text = mail[del];
                Ffirstname.Items.Remove(name1.Text);
                Ppassword.Items.Remove(password1.Text);
                Eemail.Items.Remove(Mail.Text);
            }
        }
    }
}