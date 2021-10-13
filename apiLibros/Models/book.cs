using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiLibros.Models
{
    public class book
    {
        public int id { set; get; }
        public string titulo { set; get; }
        public string autor { set; get; }
        public int paginas { set; get; }

    }
}
