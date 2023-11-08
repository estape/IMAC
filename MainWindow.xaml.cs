using IMAC.BackEnd;
using System;
using System.Windows;
//using Microsoft.Web.WebView2.Wpf;

namespace IMAC
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WebXAML.EnsureCoreWebView2Async(); // Inicializa o controle WebView2


            //baseRef.SetRunas();

            //Mantem as entradas de latitude e longitude ocultos
            LatiInput.Visibility = Visibility.Collapsed;
            LongiInput.Visibility = Visibility.Collapsed;
            Btn_LatiLongi.Visibility = Visibility.Collapsed;
        }


        private void BtnUpdateImac(object sender, RoutedEventArgs e)
        {
            _ = new Updater();

            Updater.CallUpdate();
        }
        
        //Pegar a localização por link do Google
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           if (string.IsNullOrEmpty(GMapsInput.Text))
            {
                MessageBox.Show("Por favor, copie e cole na caixa de pesquisa o link do Google Maps antes de pesquisar", "Erro ao pesquisar: Google Maps", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                (string lati, string longi) = GoogleLink.CallGoogleLink(GMapsInput.Text);
                string FullUrl = Base.BuildUrl(Uri.EscapeDataString(lati), Uri.EscapeDataString(longi)); // Fundamental para o navegador de internet interpretar os parametros de forma correta.
                WebXAML.CoreWebView2.Navigate(FullUrl);
            }
        }

        private void GMapsInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GMapsInput.Text == "Cole o link do Google Maps aqui...")
            {
                GMapsInput.Text = "";
            }
        }

        private void GMapsInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GMapsInput.Text))
            {
                GMapsInput.Text = "Cole o link do Google Maps aqui...";
            }
        }

        //Pegar a localização por latitude e longitude
        private void Btn_LatiLongi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LatiInput.Text) && string.IsNullOrEmpty(LongiInput.Text))
            {
                MessageBox.Show("Por favor, digite a Latitude e a Longitude antes de pesquisar", "Erro ao pesquisar", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                string FullUrl = Base.BuildUrl(Uri.EscapeDataString(LatiInput.Text), Uri.EscapeDataString(LongiInput.Text)); // Fundamental para o navegador de internet interpretar os parametros de forma correta.
                WebXAML.CoreWebView2.Navigate(FullUrl);
            }
        }

        private void LatiInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LatiInput.Text == "Latitude")
            {
                LatiInput.Text = "";
            }
        }

        private void LongiInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LongiInput.Text == "Longitude")
            {
                LongiInput.Text = "";
            }
        }

        private void LatiInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LatiInput.Text))
            {
                LatiInput.Text = "Latitude";
            }
        }

        private void LongiInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LongiInput.Text))
            {
                LatiInput.Text = "Longitude";
            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GMapsInput.Visibility = Visibility.Collapsed;
            Btn_Gmap.Visibility = Visibility.Collapsed;
            LatiInput.Visibility = Visibility.Visible;
            LongiInput.Visibility = Visibility.Visible;
            Btn_LatiLongi.Visibility = Visibility.Visible;
            TXT__Title.Text = "Latitude e Longitude";
            TXT__Title.VerticalAlignment = VerticalAlignment.Top;
            TXT__Title.HorizontalAlignment = HorizontalAlignment.Center;
            TXT__Title.FontSize = 18;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GMapsInput.Visibility = Visibility.Visible;
            Btn_Gmap.Visibility = Visibility.Visible;
            LatiInput.Visibility = Visibility.Collapsed;
            LongiInput.Visibility = Visibility.Collapsed;
            Btn_LatiLongi.Visibility = Visibility.Collapsed;
            TXT__Title.Text = "Link";
            TXT__Title.VerticalAlignment = VerticalAlignment.Top;
            TXT__Title.HorizontalAlignment = HorizontalAlignment.Right;
            TXT__Title.FontSize = 20;
        }
    }
}
