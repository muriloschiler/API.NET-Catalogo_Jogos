using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Entities
{
    public class Venda
    {

        public Guid id { get; set; }

        [Required]
        public Guid id_usuario { get; set; }

        [ForeignKey("id_usuario")]
        public virtual Usuario usuario { get; set; }

        [Required]
        public Guid id_jogo { get; set; }

        [ForeignKey("id_jogo")]
        public virtual Jogo jogo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dataVenda { get; set; }

        [Required]
        public double valorTotal { get; set; }
    }
}
