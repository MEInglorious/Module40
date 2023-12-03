using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Module40.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Login_Click(object sender, EventArgs e)
        {
            if (PIN.Text == null)
            {
                await DisplayAlert("Error!", "Password entry is empty!", "Ok");
                return;
            }
            if (PIN.Text.Length != 4)
            {
                await DisplayAlert("Error!", "The password's length must be 4 symbols!", "Ok");
                return;
            }
            if (!Preferences.ContainsKey("password"))
            {
                Preferences.Set("password", PIN.Text);
            }
            if (PIN.Text != Preferences.Get("password", "password"))
            {
                await DisplayAlert("Error!", "Incorrect password!", "Ok");
                return;
            }
            loginButton.Text = $"Enter is processing..";
            await Task.Delay(150);
            await Navigation.PushAsync(new ImageListPage());           
        }
    }
}