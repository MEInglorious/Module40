using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Module40.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        Image image;
        public ImagePage(Image selectedImage)
        {
            InitializeComponent();
            image = selectedImage;
            Photo.Source = image.Source;
            Name.Text = image.Source.ToString();
        }
    }
}