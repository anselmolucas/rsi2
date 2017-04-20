using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    public class Advertiser_com : Auxiliar
    {
        public int Id { get; set; }

        [DisplayName("anunciante")]
        public int AdvertiserId { get; set; }

        public string DDD { get; set; }
        public string Tel { get; set; }

        [DisplayName("e-mail")]
        public string Email { get; set; }

        public string URL { get; set; }

        [DisplayName("conta")]
        public string Account { get; set; }

        [DisplayName("descrição")]
        public string Description { get; set; }

        [DisplayName("tipo")]
        public typeCom TypeCom { get; set; }

        [DisplayName("ordem")]
        public int DisplayOrder { get; set; }
    }

    public enum typeCom
    {
        noInformation, tel, cel, whatsapp, email, site, facebook, twitter, instagram, youtube, googlePlus, linkedin, vimeo, pinterest, flickr, mySpace, soundCloud
    }
}
