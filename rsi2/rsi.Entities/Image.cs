using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    public class ImageMedia : Auxiliar
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public byte[] Imagem { get; set; }
        public string ImagemMimeType { get; set; }
        public byte[] Thumbnail { get; set; }
        public string ThumbnailMimeType { get; set; }

        public byte[] BigImagem { get; set; }
        public string BigImagemMimeType { get; set; }
    }
}
