﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Entities
{
    public class Jogo
    {
        public Guid id { get; set; }
        public string titulo { get; set; }
        public string produtora { get; set; }
        public string categoria { get; set; }
        public double valor { get; set; }
        public DateTime anoLancamento { get; set; }

    }
}
