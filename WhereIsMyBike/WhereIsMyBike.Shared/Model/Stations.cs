using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace WhereIsMyBike.Model
{

        public class Properties
        {
            public string name { get; set; }
        }

        public class Crs
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

        public class Properties2
        {
            public string nom { get; set; }
            public int num_station { get; set; }
            public int nb_bornettes { get; set; }
            public string En_service { get; set; }
            public string M_en_S_16_nov_07 { get; set; }
            public string street { get; set; }
            public string Mot_Directeur { get; set; }
            public string commune { get; set; }
            public string code_insee { get; set; }
            public double X_CC43 { get; set; }
            public double Y_CC43 { get; set; }
            public double X_WGS84 { get; set; }
            public double Y_WGS84 { get; set; }
            public string Nrivoli { get; set; }
            public string No { get; set; }
        }

        public class Feature 
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
            public Properties2 properties { get; set; }

        }

        public class StationsRawData
        {
            public string name { get; set; }
            public string type { get; set; }
            public Crs crs { get; set; }
            public List<Feature> features { get; set; }
            
        }




       
        public class Stations : ObservableCollection<Station>
        {
            public Stations()
            {

            }
        }
        public class Station : INotifyPropertyChanged
        {
            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value; NotifyPropertyChanged("Name");
                }
            }

            private string _street;
            public string Street
            {
                get
                {
                    return _street;
                }
                set
                {
                    _street = value; NotifyPropertyChanged("Street");
                }
            }

            private string _fullName;
            public string FullName
            {
                get
                {
                    return _fullName;
                }
                set
                {
                    _fullName = value; NotifyPropertyChanged("FullName");
                }
            }




            public Station(string fullName, string street, string name)
            {
                this.Name = name;
                this.Street = street;
                this.FullName = fullName;    
            }



            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public override string ToString()
            {
                return string.Format("{0} {1}, {2}", FullName, Street, Name);
            }
        }

       

    
       
    
}
