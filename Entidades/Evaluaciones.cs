﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Evaluaciones
    {
        [Key]
        public int EvaluacionId { get; set; }
        public string Estudiante { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<EvaluacionDetalle> Detalle { get; set; }
        public Evaluaciones()
        {
            EvaluacionId = 0;
            Estudiante = string.Empty;
            Total = 0;
            Fecha = DateTime.Now;
            Detalle = new List<EvaluacionDetalle>();
        }
    }
}
