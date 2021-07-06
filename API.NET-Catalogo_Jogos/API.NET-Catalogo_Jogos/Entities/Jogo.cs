using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Entities
{
    public class Jogo
    {
        public Guid id { get; set; }
        
        [Required]
        public string titulo { get; set; }
        
        [Required]
        public string produtora { get; set; }
        
        [Required]
        public Guid id_categoria { get; set; }

        [ForeignKey("id_categoria")]
        public Categoria categoria { get; set; }

        [Required]
        public double valor { get; set; }

        [Required]
        public DateTime anoLancamento { get; set; }

    }
}
