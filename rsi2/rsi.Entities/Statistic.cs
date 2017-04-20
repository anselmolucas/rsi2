using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    /// <summary>
    /// tabela responsável por armazenar as estatíticas de visitação do site
    /// </summary>
    public class Statistic
    {
        public int Id { get; set; }

        /// <summary>
        /// eu imagino que ao entrar no site uma sessão é criada, verificar se isso realmente ocorre...
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// ip do visitante
        /// </summary>
        public string VisitorIp { get; set; }

        /// <summary>
        /// página do anunciante visitado
        /// </summary>
        public int AdvertiserId { get; set; }

        /// <summary>
        /// categoria visitada
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// subcategoria visitada
        /// </summary>
        public int SubCategoryId { get; set; }

        public string UF { get; set; }

        public int CityId { get; set; }

        public string Tag { get; set; }

        /// <summary>
        /// chave de pesquisa usada pelo visitante para encontrar o anunciante desejado
        /// </summary>
        public string SearchKey { get; set; }

        /// <summary>
        /// local do visitante (país, ou estado)
        /// </summary>
        public string visitorLocal { get; set; }

        /// <summary>
        /// url anterior
        /// </summary>
        public string PreviousURL { get; set; }

        /// <summary>
        /// url seguinte
        /// </summary>
        public string NextUrl { get; set; }

        public DateTime StartOfVisit { get; set; }
        public DateTime EndOfVisit { get; set; }

        [NotMapped]
        public string AdvertiserName { get; set; }
    }
}
