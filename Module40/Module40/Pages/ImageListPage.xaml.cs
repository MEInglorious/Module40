using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Module40.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageListPage : ContentPage
    {
        public ObservableCollection <Image> Photos { get; set; } = new ObservableCollection<Image>();
        Image SelectedImage;
        public ImageListPage()
        {
            InitializeComponent();
            Photos.Add(new Image() { Source = "Kettle.png" });
            Photos.Add(new Image() { Source = "Chainik.png" });
            Photos.Add(new Image() { Source = "Multivarka.png" });
            Photos.Add(new Image() { Source = "PosudomoechnayaMashina.png" });
            Photos.Add(new Image() { Source = "StiralnayaMashina.png" });
            BindingContext = this;
        }
        private void imageList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedImage = (Image)e.SelectedItem;
        }
        private async void OpenButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagePage(SelectedImage));
        }
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {         
            var path = SelectedImage.Source.ToString().Replace("File: ", "");  
            var fullPath = Path.Combine("/Module40", "Module40", "Module40.Android", "Resources", "drawable", path);
            try
            {
                
                DisplayAlert("Delete!", fullPath, "Ok");
                File.Delete(fullPath);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error!", ex.Message, "Ok");
            }
        }
    }
}