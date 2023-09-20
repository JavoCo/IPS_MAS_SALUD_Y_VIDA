using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Liquidacion
    {
        public string IdLiquidacion { get; set; }
        public string IdPaciente { get;set; }
        public string TipoAfiliacion { get; set; }
        public double SalarioDevengado { get; set; }
        public double valorHospitalizacion { get; set; }

        public Liquidacion(string idLiquidacion, string idPaciente, string tipoAfiliacion, double salarioDevengado, double valorHospitalizacion)
        {
            this.IdLiquidacion = idLiquidacion;
            this.IdPaciente = idPaciente;
            this.TipoAfiliacion = tipoAfiliacion;
            this.SalarioDevengado = salarioDevengado;
            this.valorHospitalizacion = valorHospitalizacion;
        }
        public Liquidacion() { }


    }
}
