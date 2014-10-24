using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using WhereIsMyBike.Model;
using Windows.Storage;
using System.IO.Compression;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

//using Newtonsoft.Json;

namespace WhereIsMyBike.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        //private var  _stationList = new Stations


        private string _helloWorld;
        private List<Feature>.Enumerator _stationName;

        private StationsRawData _rawData = new StationsRawData();

        public StationsRawData StationRawData
        {
            get
            {
                return _rawData;
            }
            set
            {
                _rawData = value;
                RaisePropertyChanged("StationRawData");
            }
        }

   

             
            //ICI recup json
           // StorageFile file = await folder.GetFileAsync("Velo_Toulouse.json");
            //string rawData = await Windows.Storage.FileIO.ReadTextAsync(file);
        

        public Task<Stream> GetFromWeb(string feedUrl)
        {
            var client = new HttpClient();
            var result = client.GetStreamAsync(new Uri(feedUrl));
            return result;


        }          

        public async Task<Stream> DownloadJson()
        {
                using(var zipStream = await GetFromWeb("http://data.toulouse-metropole.fr/les-donnees/-/opendata/card/12546-velo-toulouse/resource/document"))
                {
                        using(var archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                    {
                            foreach(ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.Name == "Velo_Toulouse.json")
                                {
                                    using(StreamReader stream = new StreamReader(entry.Open()))
                                    {
                                        string tmpString = stream.ReadToEnd();
                                        this.SetJSON(tmpString);
                                    }
                                }

                            }

                    }
                }
                return null;
        }
        public async void SetJSON(string rawData)
        {
            var listeStation = new Stations();
           

           StationRawData = JsonConvert.DeserializeObject<StationsRawData>(rawData);
           var features = StationRawData.features;
           foreach (var feature in features)
           {
               var prop = feature.properties;
               StationsList.Add(new Station(prop.Mot_Directeur, prop.street, prop.nom));

           }

        }


        private ObservableCollection<Station> _stationsList;

        public ObservableCollection<Station> StationsList
        {
            get
            {
                return _stationsList;
            }
            set
            {
                _stationsList = value;
            }
        }

        public List<Feature>.Enumerator StationName
        {
            get
            {
                return _stationName;
            }
            set
            {
                _stationName = value;
                

            }
        }
        public string HelloWorld
        {
            get
            {
                return _helloWorld;
            }
            set
            {
                Set(() => HelloWorld, ref _helloWorld, value);
            }
        }

        
        public MainViewModel()
        {
            var x = this.DownloadJson();

            StationsList = new Stations() ;
            HelloWorld = IsInDesignMode
             ? "Runs in design mode"
             : "Runs in runtime mode";
        }
    
    }

}
