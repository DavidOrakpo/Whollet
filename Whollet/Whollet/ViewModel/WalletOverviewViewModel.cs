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

namespace Whollet.ViewModel
{
    public class WalletOverviewViewModel : BaseViewModel
    {
        private readonly ICryptoService _cryptoservice;
        private IGeckoPriceHistoryService _geckoPriceHistory;

        public WalletOverviewViewModel(ICryptoService cryptoService, IGeckoPriceHistoryService geckoPriceHistory)
        {
            _cryptoservice = cryptoService;
            _geckoPriceHistory = geckoPriceHistory;
            PopulateListCommand.Execute(this);
            PopulateChart.Execute(this);
        }
        public async Task PopulateList()
        {
            var temp = await _cryptoservice.GetLatest();
            LatestListings = new ObservableCollection<LatestListing>(temp);
            CoinPrice = LatestListings.Where(i => i.symbol == "BTC").Select(p => p.price).FirstOrDefault();
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

        public Command PopulateChart => new Command(async () =>
        {
            var currentTime = DateTime.Now;
            var oneMonthAgo = DateTime.Today.AddMonths(-3);
            

            var PriceObject = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime);
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
            PriceChart = new LineChart() { Entries = chartEntries, EnableYFadeOutGradient = false, LineAreaAlpha = 0, PointMode = PointMode.None,
                MaxValue = maxprice, MinValue = minprice, LineMode = LineMode.Straight, BackgroundColor = SKColor.Empty };
        });

        public Command TimeChartCommand => new Command(async (x) =>
        {
            var temp = int.Parse(x.ToString());
            DateTime currentTime, oneMonthAgo;
            switch (temp)
            {
                case 1:
                     currentTime = DateTime.Now;
                     oneMonthAgo = DateTime.Today.AddDays(-1);
                     var PriceObject = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime);
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
                    var PriceObject2 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime);
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
                    var PriceObject3 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime);
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
                    var PriceObject4 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime);
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
                    oneMonthAgo = DateTime.Today.AddDays(-1);
                    var PriceObject5 = await _geckoPriceHistory.GetCoinGeckoPriceHistory(currency: "usd", oneMonthAgo, currentTime);
                    var pricelist5 = PriceObject5.prices.ToList();
                    var minprice5 = pricelist5.Select(p => p[1]).Min();
                    var maxprice5 = pricelist5.Select(p => p[1]).Max();
                    List<ChartEntry> chartEntries5 = new List<ChartEntry>();
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

        private ObservableCollection<LatestListing> _LatestListing;

        public ObservableCollection<LatestListing> LatestListings
        {
            get { return _LatestListing; }
            set { _LatestListing = value; OnPropertyChanged(); }
        }

        public long DateTimetoEpochConverter(DateTime dateTime)
        {
            //var dateTime = new DateTime(2021, 02, 21, 22, 0, 0, DateTimeKind.Utc);
            var dateWithOffset = new DateTimeOffset(dateTime).ToUniversalTime();
            long timestamp = dateWithOffset.ToUnixTimeMilliseconds();
            return timestamp;
        }

    }
}
