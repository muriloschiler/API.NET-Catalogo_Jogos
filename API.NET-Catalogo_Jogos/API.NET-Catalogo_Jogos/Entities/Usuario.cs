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

        [Required]
        [DataType(DataType.Password)]
        public string senha { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public string  dataNasc { get; set; }

        [EnumDataType(typeof(Sexo))]
        [Required]
        public  char sexo { get; set; }

    }
    public enum Sexo {M = 0, F = 1}
}
