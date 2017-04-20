using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities;
using rsi.Entities.AdvertiserDetails;

namespace rsi.Apps
{
    public class Context : DbContext
    {
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Media> Medias { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagAdvertiser> TagAdvertisers { get; set; }
        public DbSet<City> Cities { get; set; }
        
        public DbSet<EmailBox> EmailBoxes { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<SubCategory> SubCategories { get; set; }
        
        //public DbSet<PageElement> PageElements { get; set; }
        //public DbSet<Ad_MediaList> Ad_MediaLists { get; set; }
        //public DbSet<AdvertisersShortList> AdvertisersShortLists { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<Advertiser_SubCategory> Advertisers_SubCategories { get; set; }

        public DbSet<Statistic> Statistics { get; set; }
        //public DbSet<Menu> Menus { get; set; }


        public DbSet<Advertiser_address> Advertisers_adresses { get; set; }
        public DbSet<Advertiser_com> Advertisers_coms { get; set; }
        public DbSet<ImageMedia> ImageMedias { get; set; }
    }
}
