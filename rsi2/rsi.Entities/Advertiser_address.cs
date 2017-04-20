using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    public class Advertiser_address : Auxiliar
    {
        public int Id { get; set; }

        [DisplayName("anunciante")]
        public int AdvertiserId { get; set; }

        [StringLength(50, ErrorMessage = "são necessários de 1 à 100 caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "informação necessária!!!")]
        [DisplayName("descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "informação necessária!!!")]
        [DisplayName("uf")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "informação necessária!!!")]
        [DisplayName("cidade")]
        public int CityId { get; set; }

        [DisplayName("cep")]
        public string ZipCode { get; set; }

        [StringLength(100, ErrorMessage = "são necessários de 1 à 100 caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "informação necessária!!!")]
        [DisplayName("logradouro")]
        public string Street { get; set; }

        [DisplayName("google maps")]
        public string GoogleMaps { get; set; }

        [StringLength(100, ErrorMessage = "são necessários de 1 à 100 caracteres", MinimumLength = 1)]
        [DisplayName("hora funcmto")]
        public string OpeningHours { get; set; } //Horário de funcionamento

        [Required(ErrorMessage = "informação necessária!!!")]
        [DisplayName("tipo")]
        public addressType Type { get; set; }

        [Required(ErrorMessage = "informação necessária!!!")]
        [DisplayName("ordem")]
        public int DisplayOrder { get; set; }

        [NotMapped]
        public string CityName { get; set; }
    }

    public enum addressType
    {
        noInformation, matriz, filial, outros
    }
}