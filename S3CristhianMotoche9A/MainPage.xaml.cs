using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace S3CristhianMotoche9A
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnAbrir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calificaciones(TxtUsuario.Text, TxtPass.Text));

        }
    }
}
