using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.DTO.InputModels
{
    public class LoginUsuarioInputModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
    
        [Required]
        [DataType(DataType.Password)]
        public string senha { get; set; }
    }
}
