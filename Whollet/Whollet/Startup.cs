﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Whollet.Model;
using Microsoft.Extensions.Http;
using Whollet.ViewModel;
using Whollet.Views;
using Whollet.Views.FirstTimeInApp;
using Whollet.Views.KYC;
using Whollet.Views.Login;
using Whollet.Services.CoinMarketCap;

namespace Whollet
{
    public static class Startup
    {
        public static IServiceProvider serviceprovider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add servicecs
            services.AddSingleton<IUser, User>();
            services.AddSingleton<IAddress, Address>();
            services.AddHttpClient<ICryptoService, CryptoService>(c =>
            {
                c.BaseAddress = new Uri("https://pro-api.coinmarketcap.com");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("Accept-Encoding", "deflate, gzip");
                c.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "69278825-fee4-431c-8546-fe8995d5372f");
            });

            //add viewmodels
            services.AddTransient<OnboardingViewModel>();
            services.AddTransient<WelcomeViewModel>();
            services.AddTransient<CheckEmailViewModel>();
            services.AddTransient<ConfirmPinViewModel>();
            services.AddTransient<CreatePinViewModel>();
                    //-----password view model----------
            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<SignUpViewModel>();
            services.AddTransient<VerificationViewModel>();
            services.AddTransient<BackDocumentScanViewModel>();
            services.AddTransient<DocumentVerificationViewModel>();
            services.AddTransient<FinalConfirmationPageViewModel>();
            services.AddTransient<FrontDocumentScanViewModel>();
                    //-----kyc last confirmed-----------
            services.AddTransient<KycTabModel2>();
            services.AddTransient<PersonalInformationViewModel>();
                    //-----Empty State finished---------
                    //-----Empty State Pending----------
                    //-----Empty State View-------------
            services.AddTransient<PortfolioViewModel>();
            services.AddTransient<TransactionsViewModel>();

            //add pages/views
            services.AddTransient<OnboardingPage>();
                    //Login
            services.AddTransient<WelcomeView>();
            services.AddTransient<CheckEmailPage>();
            services.AddTransient<ConfirmPin>();
            services.AddTransient<CreatePin>();
            services.AddTransient<ForgotPassword>();
            services.AddTransient<LoginPage>();
            services.AddTransient<SignupView>();
            services.AddTransient<VerificationPage>();
                    //KYC
            services.AddTransient<BackDocumentScan>();
            services.AddTransient<DocumentVerificationPage>();
            services.AddTransient<FinalConfirmationPage>();
            services.AddTransient<FrontDocumentScan>();
            services.AddTransient<KycLastConfirmed>();
            services.AddTransient<PersonalInformationPage>();
                    //First Time In APp
            services.AddTransient<EmptyStateFinished>();
            services.AddTransient<EmptyStatePending>();
            services.AddTransient<EmptyStateView>();
            services.AddTransient<KycEmptyPage>();
            services.AddTransient<PortfolioView>();
            services.AddTransient<TransactionsView>();


            

            //Build
            serviceprovider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceprovider.GetService<T>();
    }
}
