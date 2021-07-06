using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.InputModels

{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100,MinimumLength =2,ErrorMessage = "O titulo do jogo deve conter entre 2 a 100 caracteres")]
        public string titulo { get; set; }

        [Required]
        [StringLength(50,MinimumLength =2,ErrorMessage ="A produtora deve conter entre 2 a 50 caracteres")]
        public string produtora { get; set; }

        [Required]
        public Guid id_categoria { get; set; }

        [Required]
        [Range(0.0,1000.0,ErrorMessage ="O valor do jogo deve estar entre 0.0 e 1000.0 Reais")]
        public double valor { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime anoLancamento { get; set; }

    }
}
