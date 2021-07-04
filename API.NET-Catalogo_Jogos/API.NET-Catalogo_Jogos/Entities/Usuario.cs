using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Entities
{
    public class Usuario
    {
        [Required]
        public Guid id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [DataType(DataType.Password)]
        public string senha { get; set; }
    
        
    }
}
