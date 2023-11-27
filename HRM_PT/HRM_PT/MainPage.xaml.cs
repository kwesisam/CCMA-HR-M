using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Threading.Tasks;

namespace HRM_PT;
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }


        bool eye = false;
        private void ShowPassword(object sender, EventArgs e)
        {
            if (!eye)
            {
                show_password.Source = "eye_vision_view_icon.png";
                password.IsPassword = false;
                eye = true;
            }
            else
            {
                show_password.Source = "eye_slash_icon.png";
                password.IsPassword = true;
                eye = false;
            }
        }


        bool ssignin = false; 
        private void ShowSignIn(object sender, EventArgs e)
        {
            if (!ssignin)
            {

                signinpage.IsVisible = true;
                ssignin = true;
            }
            else
            {
                signinpage.IsVisible = false;
                ssignin = false;
              
            }

        }

    

    async void SignUpPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }


    string name;

    void On_Name(object sender, TextChangedEventArgs e)
    {
        name = hello.Text;
        display.Text = name;
        
    }

   
    void ha(object sender, EventArgs e)
    {
        if(name == "sam")
        {
            
            right();
            left();
            user.Text = "Samuel!";
        }
        else
        {
            user.Text = "Friend!";
            
        }
    }

    async void right()
    {
        await user.TranslateTo(500,user.TranslationX, 2000);
        await user.FadeTo(0, 10);
        
    }

    async void left()
    {
        await user.TranslateTo(-0,user.TranslationX,1000);
        await user.FadeTo(1, 1000);
    }

    async void nextPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ActionPage());
    }

    }
