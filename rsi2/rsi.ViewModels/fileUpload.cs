using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.ViewModels
{
    public class fileUpload
    {
        public string fileName { get; set; }
        public string table { get; set; }
        public int tableRecordId { get; set; }
        public imageType imageType { get; set; }
    }

    public enum imageType
    {
        noInformation, icon, slider, gallery, advertising, mainImage
    }
}
