﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaAPI.Common.DTO.Request
{
    public class ClienteRequest
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
