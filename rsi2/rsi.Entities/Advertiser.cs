using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rsi.Entities.AdvertiserDetails;

namespace rsi.Entities
{
    public class Advertiser : Auxiliar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }

        [StringLength(100, ErrorMessage = "o nome do anunciante precisa ter entre 2 e 100 caracteres", MinimumLength = 2)]
        [Required(ErrorMessage = "*** [nome] é uma informação necessária!!!")]
        [DisplayName("nome")]
        public string Name { get; set; }

        //[StringLength(1000, ErrorMessage = "o slogan precisa ter entre 2 e 1000 caracteres", MinimumLength = 2)]
        [DisplayName("slogan")]
        public string Slogan { get; set; }

        [DisplayName("tags")]
        public string Tags { get; set; }

        [DisplayName("situação")]
        public situation Situation { get; set; }

        public string FileName { get; set; }

        [DisplayName("tipo")]
        public pfPj PfPj { get; set; }

        public string CPF { get; set; }
        public string CNPJ { get; set; }

        [StringLength(100, ErrorMessage = "o nome do anunciante precisa ter entre 2 e 100 caracteres", MinimumLength = 2)]
        [DisplayName("contato")]
        public string Contact { get; set; }

        [NotMapped]
        public int StateId { get; set; }

        [NotMapped]
        public int CityId { get; set; }        

        [NotMapped]
        public List<Address> AddressList { get; set; }

        [NotMapped]
        public List<Media> MediaList { get; set; }

        [NotMapped]
        public List<SocialMedia> SocialMediaList { get; set; }   
    }

    /// <summary>
    /// 0)nenhuma informação, 1)complacente, 2)atrasado, 3)degustação, 4)bloqueado, 5)à espera de aprovação
    /// </summary>
    public enum situation
    {
        bloqueado, ativo, esperandoAprovação, degustação
    }

    /// <summary>
    /// tipos de clientes: anunciante (só para banners de anúncio), membro (anunciante que página de destaque e pesquisa no site)
    /// </summary>
    public enum pfPj
    {
        pf, pj
    }    
}
