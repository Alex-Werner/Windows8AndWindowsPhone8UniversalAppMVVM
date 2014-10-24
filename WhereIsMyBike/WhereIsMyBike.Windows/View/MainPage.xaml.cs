using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WhereIsMyBike.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Bing.Maps;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.UI.Core;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using WhereIsMyBike.Common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhereIsMyBike.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        
        public MainPage()
        {

            this.InitializeComponent();
           InitializeMap();



            //_geolocator = new Geolocator();
            //_geolocator.ReportInterval = 1000; //1sec

            //_geolocator.PositionChanged += new TypedEventHandler<Geolocator, PositionChangedEventArgs>(OnPositionChanged);
           // _geolocator.StatusChanged += new TypedEventHandler<Geolocator, StatusChangedEventArgs>(OnStatusChanged);
           // Geoposition pos = e.Position;


            
        }
       /* public async void GetPosition()
        {
            // Get my current location.
            Geolocator myGeolocator = new Geolocator();         
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
           // GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

            // Make my current location the center of the Map.
            // this.myMap.Center = myGeoCoordinate;
            this.myMap.ZoomLevel = 13;

          
        }*/
       
        void InitializeMap()
        {

            myMap.Center = new Location(43.596931999999995,1.421816);
            myMap.ZoomLevel = 12;
            myMap.MapType = MapType.Road;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("hey je suis onNavigateTO");
            var geoLocator = new GeolocatorService();
            try
            {
                Debug.WriteLine("hey je suis try");

                var t = await geoLocator.GetGeoposition();
                var longitude = t.Coordinate.Longitude;
                var latitude = t.Coordinate.Latitude;
                myMap.Center = new Location(latitude, longitude);
                myMap.ZoomLevel = 15;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("hey je suis AIE");

            }
        }
    }
}
