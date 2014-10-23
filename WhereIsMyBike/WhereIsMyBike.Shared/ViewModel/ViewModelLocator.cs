using System;
using System.Collections.Generic;
using System.Text;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace WhereIsMyBike.ViewModel
{
   public class ViewModelLocator
    {
       public INavigationService DefaultNavigationService { get; private set; }
       public static ViewModelLocator Default { get; private set;}

       public ViewModelLocator(){
           ServiceLocator.SetLocatorProvider(()=> SimpleIoc.Default);
           
           SimpleIoc.Default.Register<MainViewModel>();

           SimpleIoc.Default.Register<INavigationService, NavigationService>();
           //IDataServicce ?

           SimpleIoc.Default.Register<StationViewModel>();
           SimpleIoc.Default.Register<NavigateViewModel>();
           SimpleIoc.Default.Register<ClosestStationViewModel>();
           SimpleIoc.Default.Register<SearchViewModel>();


           DefaultNavigationService = SimpleIoc.Default.GetInstance<INavigationService>();
       }

       public ViewModelBase Main{
           get{
               return ServiceLocator.Current.GetInstance<MainViewModel>();
           }
       }
       public ViewModelBase StationsModel{
           get{
               return ServiceLocator.Current.GetInstance<StationViewModel>();
           }
       }
       public ViewModelBase ClosestStationModel
       {
           get
           {
               return ServiceLocator.Current.GetInstance<ClosestStationViewModel>();
           }
       }
       public ViewModelBase SearchModel
       {
           get
           {
               return ServiceLocator.Current.GetInstance<SearchViewModel>();
           }
       }
       public ViewModelBase NavigateViewModel
       {
           get
           {
               return ServiceLocator.Current.GetInstance<NavigateViewModel>();
           }
       }
       /*
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
        }*/
    }
}
