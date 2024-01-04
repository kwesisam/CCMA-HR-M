
namespace HRM_PT;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(string a)
	{
		InitializeComponent();
		// Set an empty title to hide the system back button
		System.Diagnostics.Debug.WriteLine(a);
    }
    protected override bool OnBackButtonPressed()
    {
        // Perform any custom logic if needed before disabling the back button
        // For example:
        // Display an alert or confirmation dialog before preventing the back action

        // Disable the back button action (prevent navigating back or closing the page)
        return true;
    }
    private bool isvalidStaffID;
    private bool isvalidFirstName;
    private bool isvalidSurname;
    private bool isvalidPassword;

    private bool staffIDError = false;
    private bool firstNameError = false;
    private bool surnameError = false;
    private bool passwordError = false;


    private string staffID_;
    private string firstName_;
    private string surname_;
    private string password_;
    bool eye = false;
	private void ShowPassword(object sender, EventArgs e)
	{
		if (!eye)
		{
			show_password.IsPassword = false;
			image_show_password.Source = "eye_vision_view_icon.png";
			eye = true;
		}
		else
		{
			show_password.IsPassword = true;
			eye = false;
			image_show_password.Source = "eye_slash_icon.png";
		}
	}

	


	void OnStaffID(object sender, TextChangedEventArgs e)
	{
		string entryValue = staffID.Text;
        submitInfo.IsVisible = false;

        if (!(string.IsNullOrEmpty(entryValue)))
		{
			staffID_ = entryValue;
			isvalidStaffID = true;
			staffIDError = true;
			staffID_error.IsVisible = false;
		}
		else
		{
            isvalidStaffID = false;
            staffIDError = false;
        }

    }

	void OnFirstName(object sender, TextChangedEventArgs e)
	{
		string entryValue = firstName.Text;
        submitInfo.IsVisible = false;

        if (!(string.IsNullOrEmpty(entryValue)))
		{
			firstName_ = entryValue;
			firstName_error.IsVisible = false;
			firstNameError = true;
			isvalidFirstName = true;
		}
		else
		{
            firstNameError = false;
            isvalidFirstName = false;
        }


    }

	void OnSurname(object sender, TextChangedEventArgs e)
	{
		string entryValue = surname.Text;
        submitInfo.IsVisible = false;

        if (!(string.IsNullOrEmpty(entryValue)))
		{
			surname_ = entryValue;
            isvalidSurname = true;
            surnameError = true;
			surname_error.IsVisible = false;
		}
		else{
            isvalidSurname = false;
            surnameError = false;
        }

    }

	void OnPassword(object sender, TextChangedEventArgs e)
	{
		string entryValue = show_password.Text;
        submitInfo.IsVisible = false;

        if (!(string.IsNullOrEmpty(entryValue)))
		{
			password_ = entryValue;
			isvalidPassword = true;
			password_error.IsVisible = false;
			passwordError = true;
		}
		else
		{
            isvalidPassword = false;

            passwordError = false;

        }
    }

	async void OnSubmit (object sender, EventArgs e)
	{
        Button clickedButton = (Button)sender;

        // Change the background color when the button is clicked
        clickedButton.BackgroundColor = Colors.PapayaWhip; // Change to any desired color

        // Use a delay or timer to revert the color after a certain time
        await Task.Delay(500); // Wait for 1 second (adjust time as needed)

        // Revert to the original color after 1 second (adjust time as needed)
        clickedButton.BackgroundColor = Colors.NavajoWhite;
        


        signUpActivitor.IsRunning = true;

        if (!(staffIDError))
		{
			staffID_error.Text = "This field cannot be empty";
			staffID_error.IsVisible = true;
		}

		if (!(firstNameError))
		{
			firstName_error.Text = "This field cannot be empty";
			firstName_error.IsVisible = true;
		}

		if (surnameError == false)
		{
			surname_error.IsVisible = true;
			surname_error.Text = "This field cannot be empty";
		}

		if (passwordError == false)
		{
			password_error.Text = "Please enter a password";
			password_error.IsVisible = true;
		}

		if(isvalidFirstName && isvalidStaffID && isvalidPassword && isvalidSurname)
		{
            submitInfo.IsVisible = true;
            signUpActivitor.IsRunning = false;
            await App.LoginsRep.AddNewEmployee(staffID_, firstName_, surname_, password_);
			submitInfo.Text =  App.LoginsRep.statusMessage;
			if (App.LoginsRep.statusMessage.Equals("Success"))
			{
                await Navigation.PopAsync();
            }
        }
		else
		{
            signUpActivitor.IsRunning = false;
            submitInfo.IsVisible = true;
			submitInfo.Text = "Try again";
		}
	}

	async void goToHome(object sender, EventArgs e)
	{
        await Navigation.PopAsync();

    }
}