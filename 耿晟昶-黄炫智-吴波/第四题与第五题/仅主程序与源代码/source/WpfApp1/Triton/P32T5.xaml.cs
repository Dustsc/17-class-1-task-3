using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using log4net;
using WpfApp1.Triton.Common;
using WpfApp1.Triton.Common.settings;
using Logger = WpfApp1.Triton.Common.LogUtilities.LogManagers;

namespace WpfApp1.Plugins.P32T5
{
    /// <summary>
    /// P32T5.xaml 的交互逻辑
    /// </summary>
    public class P32T5Settings : JsonSettings
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();
        private static P32T5Settings _instance;

        private long year=1960;
        private long count_daily=10;
        private short day_permonth=30;
        private long pay=1000;
        private double demand =0.0;
        private Double price=0.0;
        private Double cost=0.0;

        /// <summary>The current instance for this class. </summary>
        public static P32T5Settings Instance
        {
            get { return _instance ?? (_instance = new P32T5Settings()); }
        }

        public void Reset()
        {
            Year = 1974;
            Count_daily = 10;
            Day_permonth = 30;
            Pay = 1000;
        }

        public long Year
        {
            get => year;
            set
            {
                year = value;
                Log.Info("[P32T5] Year = " + year);
                if (year < 1974)
                {
                    year = 1974;
                    Log.Warn("[P32T5] Year can't be less than 1974.");
                }
                Demand = 4080 * System.Math.Pow(System.Math.E, year - 1960 + 0.0);
                Price = Demand * 0.048 * System.Math.Pow(0.72, year - 1974 + 0.0);
                Cost = Pay * (Demand / Count_daily / Day_permonth / 12.0);
            }
        }
        public long Count_daily
        {
            get => count_daily;
            set
            {
                count_daily = value;
                Log.Info("[P32T5] count = " + count_daily);
                if (count_daily <= 0)
                {
                    count_daily = 10;
                    Log.Warn("[P32T5] The count can't be less than 0.");
                }
                Cost = Pay * (Demand / Count_daily / Day_permonth / 12.0);
            }
        }
        public short Day_permonth
        {
            get => day_permonth;
            set
            {
                day_permonth = value;
                Log.Info("[P32T5] the number of days = " + day_permonth);
                if (count_daily <= 0)
                {
                    count_daily = 30;
                    Log.Warn("[P32T5] The number can't be less than 0.");
                }
                if (count_daily > 31)
                {
                    count_daily = 30;
                    Log.Warn("[P32T5] The number can't be more than 31.");
                }
                Cost = Pay * (Demand / Count_daily / Day_permonth / 12.0);
            }
        }
        public long Pay
        {
            get => pay;
            set
            {
                pay = value;
                Log.Info("[P32T5] pay = " + pay);
                if (pay < 0)
                {
                    pay = 1000;
                    Log.Warn("[P32T5] Pay can't be less than 0.");
                }
                Cost = Pay * (Demand / Count_daily / Day_permonth / 12.0);
            }
        }
        public double Demand
        {
            get => demand;
            set => demand = value; 
        }
        public double Price
        {
            get => price;
            set => price = value;
        }
        public double Cost
        {
            get => cost;
            set => cost = value;
        }

        public P32T5Settings() : base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "AutoStop")))
        {
        }
    }
}
