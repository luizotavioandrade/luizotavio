﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EstoqueId { get; set; }
    }
}
