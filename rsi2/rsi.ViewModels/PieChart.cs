using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.ViewModels
{
    public class PieChart
    {
        public int AdvertiserId { get; set; }
        public string AdvertiserName { get; set; }
        public int TotalViews { get; set; }
    }

    public class PieChart_slices
    {
        public int AdvertiserId_slice1 { get; set; }
        public string AdvertiserName_slice1 { get; set; }
        public string AdvertiserShortName_slice1 { get; set; }
        public int TotalViews_slice1 { get; set; }

        public int AdvertiserId_slice2 { get; set; }
        public string AdvertiserName_slice2 { get; set; }
        public string AdvertiserShortName_slice2 { get; set; }
        public int TotalViews_slice2 { get; set; }

        public int AdvertiserId_slice3 { get; set; }
        public string AdvertiserName_slice3 { get; set; }
        public string AdvertiserShortName_slice3 { get; set; }
        public int TotalViews_slice3 { get; set; }

        public int AdvertiserId_slice4 { get; set; }
        public string AdvertiserName_slice4 { get; set; }
        public string AdvertiserShortName_slice4 { get; set; }
        public int TotalViews_slice4 { get; set; }

        public int AdvertiserId_slice5 { get; set; }
        public string AdvertiserName_slice5 { get; set; }
        public string AdvertiserShortName_slice5 { get; set; }
        public int TotalViews_slice5 { get; set; }

        public int TotalViews_remainingSlices { get; set; }
    }
}
