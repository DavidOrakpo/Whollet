using System;
using System.Collections.Generic;
using System.Text;
using Whollet.Model;
using Whollet.Views.KYC;
using Xamarin.Forms;

namespace Whollet.ViewModel
{
    public class PersonalInformationViewModel : BaseViewModel
    {
        private Address _address;
        public PersonalInformationViewModel()
        {
            FirstName = App.LoggedInUser.FirstName;
            LastName = App.LoggedInUser.LastName;
            
            GoToNextPage = new Command(async () => {

                if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(City) ||
                    String.IsNullOrEmpty(Citizenship) || String.IsNullOrEmpty(AreaCode) || String.IsNullOrEmpty(Address))
                    {
                        await Application.Current.MainPage.DisplayAlert("Uh Oh", "Please fill in the empty fields", "Ok");
                    }
                else
                {
                    _address = new Address
                    {
                        MyProperty = Address,
                        City = City,
                        Citizenship = Citizenship,
                        AreaCode = AreaCode,
                        Owner = App.LoggedInUser
                    };
                    await App.GetDatabase.SaveAsync<Address>(_address);
                    App.LoggedInUser.address = _address;
                    await App.GetDatabase.UpdateWithChildAsync<User>(App.LoggedInUser);
                    
                    GoToPageAsync(new DocumentVerificationPage());
                }
                   
            });
        }
        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(); }
        }
        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged(); }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); }
        }

        private string areacode;

        public string AreaCode
        {
            get { return areacode; }
            set { areacode = value; OnPropertyChanged(); }
        }

        private string citizenship;

        public string Citizenship
        {
            get { return citizenship; }
            set { citizenship = value; OnPropertyChanged(); }
        }


       public Command GoToNextPage { get; }
    }
}
