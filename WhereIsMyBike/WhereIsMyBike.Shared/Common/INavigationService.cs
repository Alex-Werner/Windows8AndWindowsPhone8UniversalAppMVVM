using System;
using System.Collections.Generic;
using System.Text;
using WhereIsMyBike.Common;

namespace WhereIsMyBike.ViewModel
{

    public interface INavigationService
    {
        void Navigate(Views view);
        void Navigate(Views view, object parameter);
        void GoBack();
    }
}
