using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;

namespace WhereIsMyBike.ViewModel
{
    public class StationViewModel : ViewModelBase
    {
        private string _helloWorld;

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

        public StationViewModel()
        {
            HelloWorld = IsInDesignMode
             ? "Runs in design mode _ Station"
             : "Runs in runtime mode _ Station";
        }
    }
}
