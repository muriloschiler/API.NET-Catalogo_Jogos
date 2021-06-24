using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string categoria { get; set; }
        public double valor { get; set; }
        public DateTime anoLancamento { get; set; }

    }
}
