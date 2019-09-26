using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class EvaluacionDetalle
    {
        [Key]
        public int EvaluacionDetalleId { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }
        public EvaluacionDetalle()
        {
            EvaluacionDetalleId = 0;
            Categoria = string.Empty;
            Valor = 0;
            Logrado = 0;
            Perdido = 0;
        }
        public EvaluacionDetalle(string Cat, decimal Val, decimal Log, decimal Per)
        {
            Cat = this.Categoria;
            Val = this.Valor;
            Log = this.Logrado;
            Per = this.Perdido;
        }
    }
}
