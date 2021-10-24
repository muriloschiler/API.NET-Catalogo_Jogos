using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Entities
{
    public class Produtora
    {
        [Required]
        public Guid id { set; get; }
        [Required]
        public string produtora { get; set; }
    }
}
