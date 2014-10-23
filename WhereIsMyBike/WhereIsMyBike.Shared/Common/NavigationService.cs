using System;
using System.Collections.Generic;
using System.Text;
using WhereIsMyBike.Common;
using WhereIsMyBike.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WhereIsMyBike.ViewModel
{
    class NavigationService : INavigationService
    {
        private Type GetViewType(Views view)
        {
            switch (view)
            {
                case Views.Map:
                    return typeof(MainPage);
                case Views.Stations:
                    return typeof(StationPage); 
                case Views.Search:
                    return typeof(SearchPage);
                case Views.ClosestStation:
                    return typeof(ClosestStationPage);
                default:
                    break;
            }
            return null;
        }
        public void Navigate(Views sourcePageType)
        {
            var pageType = this.GetViewType(sourcePageType);

            if (pageType != null)
            {

                ((Frame)Window.Current.Content).Navigate(pageType);
            }
        }
        public void Navigate(Views sourcePageType, object parameter)
        {
            var pageType = this.GetViewType(sourcePageType);

            if (pageType != null)
            {
                ((Frame)Window.Current.Content).Navigate(pageType, parameter);
            }
        }

        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
