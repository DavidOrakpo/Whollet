using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Model.Helpers;
using Xamarin.Forms;

namespace Whollet.DataTenplateSelectors
{
    public class PageTemplateSelector : DataTemplateSelector
    {
        public PageTemplateSelector()
        {

        }

        public DataTemplate FirstPage { get; set; }
        public DataTemplate SecondPage { get; set; }
        public DataTemplate ThirdPage { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var temp = ((ViewSwitcher)item).PageIndex;
            if (temp == 1)
            {
                return FirstPage;
            }
            else if (temp == 2)
            {
                return SecondPage;
            }
            else if (temp == 3)
            {
                return ThirdPage;
            }
            else
                return null;
        }
    }
}
