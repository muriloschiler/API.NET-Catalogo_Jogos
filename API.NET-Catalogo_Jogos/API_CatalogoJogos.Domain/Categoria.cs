using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Entities
{
    public class Categoria
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string descricao { get; set; }
    }
}
