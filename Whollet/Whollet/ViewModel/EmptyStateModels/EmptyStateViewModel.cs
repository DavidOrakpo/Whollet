using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Whollet.ViewModel.EmptyStateModels
{
    public class EmptyStateViewModel : BaseViewModel
    {
        public event EventHandler CallNextViewEvent;

        public EmptyStateViewModel()
        {
            
        }

        public Command ProxyCommand => new Command(() =>
        {
            CallNextViewEvent?.Invoke(this, EventArgs.Empty);
        });
    }
}
