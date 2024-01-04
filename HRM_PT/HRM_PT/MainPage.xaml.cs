using HRM_PT.DbModel;
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
        private async void ShowSignIn(object sender, EventArgs e)
        {
        Button clickedButton = (Button)sender;

        // Change the background color when the button is clicked
        clickedButton.BackgroundColor = Colors.PapayaWhip; // Change to any desired color

        // Use a delay or timer to revert the color after a certain time
        await Task.Delay(500); // Wait for 1 second (adjust time as needed)

        // Revert to the original color after 1 second (adjust time as needed)
        clickedButton.BackgroundColor = Colors.NavajoWhite;
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
        Button clickedButton = (Button)sender;

        // Change the background color when the button is clicked
        clickedButton.BackgroundColor = Colors.PapayaWhip; // Change to any desired color

        // Use a delay or timer to revert the color after a certain time
        await Task.Delay(500); // Wait for 1 second (adjust time as needed)

        // Revert to the original color after 1 second (adjust time as needed)
        clickedButton.BackgroundColor = Colors.NavajoWhite;
        await Navigation.PushAsync(new SignUpPage("Hello"));
    }


    string staffID;

    async void On_Name(object sender, TextChangedEventArgs e)
    {

        string entryValue = hello.Text;
        password.Text = string.Empty;
        if (!string.IsNullOrEmpty(entryValue))
        {
            List<Logins> list = await App.LoginsRep.CheckUserStaffID(entryValue);

             
            try
            {
                if (!string.IsNullOrEmpty(App.LoginsRep.statusMessage))
                {
                    if (App.LoginsRep.statusMessage.Equals("Success"))
                    {
                        right();
                        left();
                        foreach (Logins emp in list)
                        {
                            user.Text = emp.surname;
                            staffID = emp.staffID;
                        }

                        await Task.Delay(2000);
                        userPassword.IsVisible = true;
                        
                        
                    }
                    else
                    {

                        user.Text = "!Friend";
                        userPassword.IsVisible = false;
                        staffID = "";
                    }
                }
                else
                {
                    userPassword.IsVisible = false;

                    user.Text = "!Friend";
                    staffID = "";

                }
            }catch (Exception ex)
            {
                user.Text = "!Friend";
                userPassword.IsVisible = false;
                staffID = "";
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        
    }

    string upassword;
    async void setUserPassword(object sender, TextChangedEventArgs e)
    {
        string entryValue = password.Text;
        if (!string.IsNullOrEmpty(entryValue))
        {
            upassword = entryValue;
            List<Logins> list = await App.LoginsRep.CheckUser(staffID, entryValue);

            try
            {
                if (!string.IsNullOrEmpty(App.LoginsRep.statusMessage))
                {
                    if (App.LoginsRep.statusMessage.Equals("Success"))
                    {
                        

                                userButton.IsVisible = true;
                        
                    }else if (App.LoginsRep.statusMessage.Equals("error"))
                    {
                        userButton.IsVisible = false;
                    }
                    else
                    {
                        userButton.IsVisible = false;

                    }
                }
                else
                {
                    userButton.IsVisible = false;

                }
            }
            catch (Exception ex)
            {
                userButton.IsVisible = false;

            }

        }
        else
        {

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
        signInActivitor.IsRunning = true;
        Button clickedButton = (Button)sender;

        // Change the background color when the button is clicked
        clickedButton.BackgroundColor = Colors.PapayaWhip; // Change to any desired color

        // Use a delay or timer to revert the color after a certain time
        await Task.Delay(500); // Wait for 1 second (adjust time as needed)

        // Revert to the original color after 1 second (adjust time as needed)
        clickedButton.BackgroundColor = Colors.NavajoWhite;

        List<Logins> list = await  App.LoginsRep.CheckUser(staffID, upassword);

        
        

        if (App.LoginsRep.statusMessage.Equals("Success"))
        {
            signInActivitor.IsRunning = false;
            password.Text = string.Empty;
            hello.Text = string.Empty;
            user.Text = "!Friend";
            userPassword.IsVisible = false;
            userButton.IsVisible = false;
            await Navigation.PushAsync(new ActionPage(list));

        }
        else
        {
            signInActivitor.IsRunning = false;

        }

    }

}
