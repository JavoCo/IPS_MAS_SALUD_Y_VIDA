using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.IO;

namespace Logica
{
    public class LiquidacionService
    {
        private LiquidacionRepository liquidacionRepository = null;
        private List<Liquidacion> liquidacionList = null;
        public LiquidacionService()
        {
            liquidacionRepository = new LiquidacionRepository();
            liquidacionList = liquidacionRepository.CargarRegistros();

        }

        public String GuardarRegistros(Liquidacion liquidacion)
        {
            if (liquidacion.IdLiquidacion == null || liquidacion.IdPaciente == null
                || liquidacion.ValorHospitalizacion == 0 || liquidacion.SalarioDevengado == 0)
            {
                return $"Campos nulos";
            }
            var message = (liquidacionRepository.GuardarRegistros(liquidacion));
            liquidacionList = liquidacionRepository.CargarRegistros();
            return message;
        }
        public List<Liquidacion> CargarRegistros()
        {
            return liquidacionList;
        }
        public string EliminarRegistro(string idAEliminar)
        {
            try
            {
                var pacienteAeliminar = liquidacionList.FirstOrDefault(p => p.IdLiquidacion == idAEliminar);

                if (pacienteAeliminar != null)
                {
                    liquidacionList.Remove(pacienteAeliminar);
                    liquidacionRepository.Guardar(liquidacionList);
                    return "Registro eliminado con éxito.";
                }
                else
                {
                    return "No se encontró un registro con el ID proporcionado.";
                }
            }
            catch (IOException)
            {
                return "Ocurrió un error al intentar eliminar el registro.";
            }
        }
    }
}
