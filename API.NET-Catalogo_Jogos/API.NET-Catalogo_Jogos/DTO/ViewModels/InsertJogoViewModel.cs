using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.ViewModels
{
    public class InsertJogoViewModel
    {        
            public Guid id { get; set; }
            public string titulo { get; set; }
            public Guid idProdutora { get; set; }
            public Guid idCategoria { get; set; }
            public double valor { get; set; }
            public DateTime anoLancamento { get; set; }   
    }
}
