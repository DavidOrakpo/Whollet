using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microcharts.Forms;
using System.Linq;
using Whollet.Model.APIModels;
using Whollet.Services.CoinMarketCap;
using System.Threading.Tasks;
using Xamarin.Forms;
using Whollet.Services.CoinGecko;
using Microcharts;
using SkiaSharp;
using System.Globalization;
using Whollet.Views.FirstTimeInApp;

namespace Whollet.ViewModel
{
    public class WalletOverviewViewModel : BaseViewModel
    {
        private readonly ICryptoService _cryptoservice;
        private IGeckoPriceHistoryService _geckoPriceHistory;
        private Grid gridselected;

        public static event EventHandler<ObservableCollection<LatestListings>> PopulateCarouselView;


        public WalletOverviewViewModel(IGeckoPriceHistoryService geckoPriceHistory)
        {
           // _cryptoservice = cryptoService;
            _geckoPriceHistory = geckoPriceHistory;
            PopulateListCommand.Execute(this);
            PopulateChartCommand.Execute(this);
            KycEmptyPage.OnDepositTapped += KycEmptyPage_OnDepositTapped;
        }

        //~WalletOverviewViewModel()
        //{
        //    KycEmptyPage.OnDepositTapped -= KycEmptyPage_OnDepositTapped;
        //}

        private void KycEmptyPage_OnDepositTapped(object sender, EventArgs e)
        {
            PopulateCarouselView?.Invoke(this, LatestListings);
        }

        public async Task PopulateList()
        {
            var temp = await _geckoPriceHistory.GetGeckoLatest(limit: 20);
            LatestListings = new ObservableCollection<LatestListings>(temp);
            CoinPrice = LatestListings.Where(i => i.symbol == "btc").Select(p => p.price).FirstOrDefault();
        }

        private double coinPrice;

        public double CoinPrice
        {
            get { return coinPrice; }
            set { coinPrice = value; OnPropertyChanged(); }
        }


        public Command PopulateListCommand => new Command(async () =>
        {
            await PopulateList();
        });

        public Command PopulateChartCommand => new Command(async () =>
        {
            await PopChartAsync();
        });

        private async Task PopChartAsync(LatestListings coin = null)
        {
            var currentTime = DateTime.Now;
            var oneMonthAgo = DateTime.Today.AddMonths(-3);
            var PriceObject = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime, coin?.id);
            var pricelist = PriceObject.prices.ToList();
            var minprice = pricelist.Select(p => p[1]).Min();
            var maxprice = pricelist.Select(p => p[1]).Max();
            List<ChartEntry> chartEntries = new List<ChartEntry>();
            var i = 0;
            foreach (var price in pricelist)
            {

                //i++;
                if (i  == 30)
                {

                    var x = Decimal.Parse(price[0].ToString(), NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint);
                    var timestring = long.Parse(x.ToString());
                    var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestring);
                    var t = dateTime.DateTime;
                    var time = t.ToShortDateString();
                    ChartEntry chartEntry = new ChartEntry(float.Parse(price[1].ToString()))
                    {
                        ValueLabel = price[1].ToString(),
                        ValueLabelColor = SKColor.Parse("#FFFFFFFF"),
                        Label = time,

                        Color = SKColor.Parse("#FFFFFF")
                    };
                    chartEntries.Add(chartEntry);
                }
                else
                {
                    ChartEntry chartEntry = new ChartEntry(float.Parse(price[1].ToString()))
                    {

                        Color = SKColor.Parse("#FFFFFF")
                    };
                    chartEntries.Add(chartEntry);
                }

            }
            // Chart chartName => new BarChart() { Entries = entries }
            PriceChart = new LineChart()
            {
                Entries = chartEntries,
                //LabelColor = SKColor.Parse("#FFFFFF"),
               // LabelOrientation = Orientation.Vertical,
               // ValueLabelOrientation = Orientation.Vertical,
               // LabelTextSize = 18,

                EnableYFadeOutGradient = false,
                LineAreaAlpha = 0,
                PointMode = PointMode.None,
                MaxValue = maxprice,
                MinValue = minprice,
                LineMode = LineMode.Straight,
                BackgroundColor = SKColor.Empty
            };
        }

        public Command TimeChartCommand => new Command(async (x) =>
        {
            var parameterarray = x.ToString().Split(",");
            var id = parameterarray[0];
            var timespan = Int32.Parse(parameterarray[1]);
           // var temp = int.Parse(x.ToString());
            DateTime currentTime, oneMonthAgo;
            switch (timespan)
            {
                case 1:
                    currentTime = DateTime.Now;
                    oneMonthAgo = DateTime.Today.AddDays(-1);
                    var PriceObject = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime, id);
                    var pricelist = PriceObject.prices.ToList();
                    var minprice = pricelist.Select(p => p[1]).Min();
                    var maxprice = pricelist.Select(p => p[1]).Max();
                    List<ChartEntry> chartEntries = new List<ChartEntry>();
                    foreach (var price in pricelist)
                    {
                        ChartEntry chartEntry = new ChartEntry(float.Parse(price[1].ToString()))
                        {
                            Color = SKColor.Parse("#FFFFFF")
                        };
                        chartEntries.Add(chartEntry);
                    }
                    // Chart chartName => new BarChart() { Entries = entries }
                    PriceChart = new LineChart()
                    {
                        Entries = chartEntries,
                        EnableYFadeOutGradient = false,
                        LineAreaAlpha = 0,
                        PointMode = PointMode.None,
                        MaxValue = maxprice,
                        MinValue = minprice,
                        LineMode = LineMode.Straight,
                        BackgroundColor = SKColor.Empty
                    };

                    break;
                case 7:
                    currentTime = DateTime.Now;
                    oneMonthAgo = DateTime.Today.AddDays(-7);
                    var PriceObject2 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime, id);
                    var pricelist2 = PriceObject2.prices.ToList();
                    var minprice2 = pricelist2.Select(p => p[1]).Min();
                    var maxprice2 = pricelist2.Select(p => p[1]).Max();
                    List<ChartEntry> chartEntries2 = new List<ChartEntry>();
                    foreach (var price in pricelist2)
                    {
                        ChartEntry chartEntry = new ChartEntry(float.Parse(price[1].ToString()))
                        {
                            Color = SKColor.Parse("#FFFFFF")
                        };
                        chartEntries2.Add(chartEntry);
                    }
                    // Chart chartName => new BarChart() { Entries = entries }
                    PriceChart = new LineChart()
                    {
                        Entries = chartEntries2,
                        EnableYFadeOutGradient = false,
                        LineAreaAlpha = 0,
                        PointMode = PointMode.None,
                        MaxValue = maxprice2,
                        MinValue = minprice2,
                        LineMode = LineMode.Straight,
                        BackgroundColor = SKColor.Empty
                    };
                    break;
                case 30:
                    currentTime = DateTime.Now;
                    oneMonthAgo = DateTime.Today.AddMonths(-1);
                    var PriceObject3 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime, id);
                    var pricelist3 = PriceObject3.prices.ToList();
                    var minprice3 = pricelist3.Select(p => p[1]).Min();
                    var maxprice3 = pricelist3.Select(p => p[1]).Max();
                    List<ChartEntry> chartEntries3 = new List<ChartEntry>();
                    foreach (var price in pricelist3)
                    {
                        ChartEntry chartEntry = new ChartEntry(float.Parse(price[1].ToString()))
                        {
                            Color = SKColor.Parse("#FFFFFF")
                        };
                        chartEntries3.Add(chartEntry);
                    }
                    // Chart chartName => new BarChart() { Entries = entries }
                    PriceChart = new LineChart()
                    {
                        Entries = chartEntries3,
                        EnableYFadeOutGradient = false,
                        LineAreaAlpha = 0,
                        PointMode = PointMode.None,
                        MaxValue = maxprice3,
                        MinValue = minprice3,
                        LineMode = LineMode.Straight,
                        BackgroundColor = SKColor.Empty
                    };
                    break;
                case 365:
                    currentTime = DateTime.Now;
                    oneMonthAgo = DateTime.Today.AddYears(-1);
                    var PriceObject4 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime, id);
                    var pricelist4 = PriceObject4.prices.ToList();
                    var minprice4 = pricelist4.Select(p => p[1]).Min();
                    var maxprice4 = pricelist4.Select(p => p[1]).Max();
                    List<ChartEntry> chartEntries4 = new List<ChartEntry>();
                    foreach (var price in pricelist4)
                    {
                        ChartEntry chartEntry = new ChartEntry(float.Parse(price[1].ToString()))
                        {
                            Color = SKColor.Parse("#FFFFFF")
                        };
                        chartEntries4.Add(chartEntry);
                    }
                    // Chart chartName => new BarChart() { Entries = entries }
                    PriceChart = new LineChart()
                    {
                        Entries = chartEntries4,
                        EnableYFadeOutGradient = false,
                        LineAreaAlpha = 0,
                        PointMode = PointMode.None,
                        MaxValue = maxprice4,
                        MinValue = minprice4,
                        LineMode = LineMode.Straight,
                        BackgroundColor = SKColor.Empty
                    };
                    break;
                case 999:
                    currentTime = DateTime.Now;
                    oneMonthAgo = DateTime.Today.AddYears(-8);
                    var PriceObject5 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime, id);
                    var pricelist5 = PriceObject5.prices.ToList();
                    var minprice5 = pricelist5.Select(p => p[1]).Min();
                    var maxprice5 = pricelist5.Select(p => p[1]).Max();
                    List<ChartEntry> chartEntries5 = new List<ChartEntry>();
                    var i = 0;
                    foreach (var price in pricelist5)
                    {

                        ChartEntry chartEntry = new ChartEntry(float.Parse(price[1].ToString()))
                        {
                            Color = SKColor.Parse("#FFFFFF")

                        };
                        chartEntries5.Add(chartEntry);
                    }
                    // Chart chartName => new BarChart() { Entries = entries }
                    PriceChart = new LineChart()
                    {
                        Entries = chartEntries5,
                        EnableYFadeOutGradient = false,
                        LineAreaAlpha = 0,
                        PointMode = PointMode.None,
                        MaxValue = maxprice5,
                        MinValue = minprice5,
                        LineMode = LineMode.Straight,
                        BackgroundColor = SKColor.Empty
                    };
                    break;
                default:
                    break;
            }
        });

        private Chart priceChart;

        public Chart PriceChart
        {
            get { return priceChart; }
            set { priceChart = value; OnPropertyChanged(); }

        }

        public List<string> SortValues { get;  } = new List<string>
        {
            "Name",
            "Price",
            "Price Change"
        };

        public Command SortCommand => new Command(async (x) =>
        {
            
            var parameter = x.ToString();
            switch (parameter)
            {
                case "Name":
                    var temp = LatestListings.OrderByDescending(i => i.name).Reverse().ToList();
                    LatestListings.Clear();
                    await Task.Delay(500);
                    LatestListings = new ObservableCollection<LatestListings>(temp);
                    break;
                case "Price":
                    var temp1 = LatestListings.OrderByDescending(i => i.price).ToList();
                    LatestListings.Clear();
                    await Task.Delay(500);
                    LatestListings = new ObservableCollection<LatestListings>(temp1);
                    break;
                case "Price Change":
                    var temp2 = LatestListings.OrderByDescending(i => i.price_change_24h).ToList();
                    LatestListings.Clear();
                    await Task.Delay(500);
                    LatestListings = new ObservableCollection<LatestListings>(temp2);
                    break;
                default:
                    break;
            }
            
             
        });

        public Command GridStateCommand => new Command((x) =>
        {
            if (gridselected is not null)
            {
                VisualStateManager.GoToState(gridselected, "UnSelected");
            }
            VisualStateManager.GoToState((Grid)x, "Selected");
            gridselected = (Grid)x;
        });

        public Command GetCoinCommand => new Command(async (e) =>
        {

            var coin = e as LatestListings;
            await PopChartAsync(coin);
            CoinPrice = coin.price;

        });

        private ObservableCollection<LatestListings> _LatestListing;

        public ObservableCollection<LatestListings> LatestListings
        {
            get { return _LatestListing; }
            set { _LatestListing = value; OnPropertyChanged(); }
        }

        

    }
}
