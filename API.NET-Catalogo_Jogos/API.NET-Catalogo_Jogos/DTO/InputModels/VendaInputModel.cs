using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.DTO.InputModels
{
    public class VendaInputModel
    {
        [Required]
        public Guid id_usuario { get; set; }
        [Required]
        public Guid id_Jogo { get; set; }
        [Required]
        public DateTime dataVenda { get; set; }
        [Required]
        public double valorTotal { get; set; }
    }
}
