using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.DTO.InputModels
{
    public class RegistrarUsuarioInputModel
    {
        [Required]
        public string nome { get; set; }
    
        [EmailAddress]
        [Required]
        public string email { get; set; }
    
        [DataType(DataType.Password)]
        [Required]
        public string senha { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("senha")]
        public string senhaConfirmacao { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public string dataNasc { get; set; }

        [EnumDataType(typeof(Sexo))]
        [Required]
        public string sexo { get; set; }
    }
    public enum Sexo { M = 0, F = 1 ,m= 2,f = 3}
}
