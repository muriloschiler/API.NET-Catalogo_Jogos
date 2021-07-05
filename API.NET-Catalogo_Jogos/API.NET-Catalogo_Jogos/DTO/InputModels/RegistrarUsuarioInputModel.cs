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
    }
}
