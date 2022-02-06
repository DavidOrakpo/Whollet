using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Whollet.Model.Helpers
{
    public class ViewSwitcher
    {
        public ViewSwitcher()
        {
            //PageChange = new Command(() =>
            //{
            //    if (PageIndex < 3)
            //    {
            //        PageIndex++;
            //        // OnPropertyChanged(nameof(PIndex));
            //    }

            //});
        }

        public int PageIndex { get; set; }
        public Command PageChange {get; set;}
    }
}
