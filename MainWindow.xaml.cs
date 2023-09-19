using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMeSelf_7_July7_BingMap;
using Path = System.IO.Path;

namespace WpfMeSelf_7_July7_BingMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private BakuBus? _myBus;

        public BakuBus? MyBuses
        {
            get => _myBus;
            set { _myBus = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyBuses")); }
        }


        private string  _selectedItem;
        public string  SelectedCBox_Item
        {
            get => _selectedItem;
            set { _selectedItem = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCBox_Item")); }
        }



        private Pushpin _pushpin;
        private Location _location;
        public Pushpin PP { get => _pushpin;
            set { _pushpin = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PP")); }
        }
        public Location location
        {
            get => _location;  
            set { _location = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("location")); }
        }

        public MainWindow()
        {
            InitializeComponent();
            string mapKey = "bVdaYjGsfP8kn9Kmkalz~cwyKZRxj0016apN4V1M5pQ~Al8eRWIp3eVgWCVNW_A90wGi82NEJ_gSUXpVbRr-mXaAc-Pj1-BebRsyUsdThRNP";
            CredKey.CredentialsProvider = new ApplicationIdCredentialsProvider(mapKey);


            Combo.ItemsSource = ROUTE_CODE;
            //Combo.ItemsSource = ROUTE;
            
           
           



           

        var dir = new DirectoryInfo("../../../");
            var fileName = "bakubusApi.json";

            var fullName = Path.Combine(dir.FullName, fileName);
            var StrFile = File.ReadAllText(fullName);

            MyBuses = JsonSerializer.Deserialize<BakuBus>(StrFile);
            Dictionary<decimal, decimal> Loc = new() { };
            foreach (var item in MyBuses.BUS)
            {
                //Location location = new Location();
                //Pushpin PP = new();
                
                //MessageBox.Show(item.attributes.LATITUDE);

                string numberString = item.attributes.LATITUDE;
                numberString = numberString.Replace(',', '.');
                double number1 = double.Parse(numberString, CultureInfo.InvariantCulture);
                numberString = item.attributes.LONGITUDE;
                numberString = numberString.Replace(',', '.');
                double number2 = double.Parse(numberString, CultureInfo.InvariantCulture);

                N = item.attributes.DISPLAY_ROUTE_CODE;
                ROUTE_CODE.Add(N);

                N = item.attributes.DISPLAY_ROUTE_CODE;
                Button btn = new Button(); btn.Content = N;
                ROUTE.Add(btn);
                //btn.Command = forSelect;


                if (item.attributes.DISPLAY_ROUTE_CODE == "7A")
                {
                    PP.Background = Brushes.Red;
                    PP.Content = "7A"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "14")
                {
                    PP.Background = Brushes.Blue;
                    PP.Content = "14"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "2")
                {
                    PP.Background = Brushes.CadetBlue;
                    PP.Content = "2"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "205")
                {
                    PP.Background = Brushes.Pink;
                    PP.Content = "205"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "3")
                {
                    PP.Background = Brushes.DarkOrange;
                    PP.Content = "3"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else
                {
                    PP.Background = Brushes.Wheat;
                    PP.Content = item.attributes.DISPLAY_ROUTE_CODE; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }

                PP.Height = 30;
                PP.Width = 30;
                PP.Foreground = Brushes.White;
                PP.Location = new Location(number1, number2);

                //if (SelectedCBox_Item is Button buton)
                //{
                    
                    if (Combo.SelectedItem == "7A")
                    {
                   
                        CredKey.Children.Add(PP);
                    }
               // }
               
                
                //var Pin = new Pushpin();
                //Pin.Location = new  ();
                // Loc.Add(Convert.ToDecimal(item.attributes.LATITUDE), Convert.ToDecimal(item.attributes.LONGITUDE));
                
            }
        }





        public ObservableCollection<string> ROUTE_CODE = new();
        public ObservableCollection<Button> ROUTE = new ObservableCollection<Button>();




        string N;

        double CE = 40; double CU = 50;
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var dir = new DirectoryInfo("../../../");
            var fileName = "bakubusApi.json";

            var fullName = Path.Combine(dir.FullName, fileName);
            var StrFile = File.ReadAllText(fullName);

            MyBuses = JsonSerializer.Deserialize<BakuBus>(StrFile);
            Dictionary<decimal, decimal> Loc = new() { };
            foreach (var item in MyBuses.BUS)
            {
                Location location = new Location();
                Pushpin PP = new();
                //MessageBox.Show(item.attributes.LATITUDE);

                string numberString = item.attributes.LATITUDE;
                numberString = numberString.Replace(',', '.');
                double number1 = double.Parse(numberString, CultureInfo.InvariantCulture);
                numberString = item.attributes.LONGITUDE;
                numberString = numberString.Replace(',', '.');
                double number2 = double.Parse(numberString, CultureInfo.InvariantCulture);
                N = item.attributes.DISPLAY_ROUTE_CODE;
                ROUTE_CODE.Add(N);

                N = item.attributes.DISPLAY_ROUTE_CODE;
                Button btn = new Button(); btn.Content = N;
                ROUTE.Add(btn);
                //btn.Command = forSelect;


                if (item.attributes.DISPLAY_ROUTE_CODE == "7A")
                {
                    PP.Background = Brushes.Red;
                    PP.Content = "7A"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "14")
                {
                    PP.Background = Brushes.Blue;
                    PP.Content = "14"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "2")
                {
                    PP.Background = Brushes.CadetBlue;
                    PP.Content = "2"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "205")
                {
                    PP.Background = Brushes.Pink;
                    PP.Content = "205"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else if (item.attributes.DISPLAY_ROUTE_CODE == "3")
                {
                    PP.Background = Brushes.DarkOrange;
                    PP.Content = "3"; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }
                else
                {
                    PP.Background = Brushes.Wheat;
                    PP.Content = item.attributes.DISPLAY_ROUTE_CODE; PP.HorizontalAlignment = HorizontalAlignment.Center;
                    PP.VerticalAlignment = VerticalAlignment.Center;
                }

                //PP.Height = 30;
                PP.Width = 30;
                PP.Foreground = Brushes.White;
                PP.Location = new Location(number1, number2);
                //CredKey.Children.Add(PP);
               
            }

            //MessageBox.Show(MyBuses.BUS [0].attributes.DISPLAY_ROUTE_CODE);
        }



    }
}
