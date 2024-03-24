using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Models
{
    public class EpostaGonderimDetayWithIncludeModel
    {
        public Guid EpostaGonderimId { get; set; }
        public EpostaGonderim EpostaGonderim { get; set; }
        public Kisi Kisi { get; set; }
        public int KisiId { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public bool GonderimDurumu { get; set; }
    }
}
