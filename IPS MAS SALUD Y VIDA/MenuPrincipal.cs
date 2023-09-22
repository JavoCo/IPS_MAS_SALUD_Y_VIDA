using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;

namespace IPS_MAS_SALUD_Y_VIDA
{
    public class MenuPrincipal
    {
        private Liquidacion liquidacion;
        private LiquidacionService liquidacionoService = new LiquidacionService();
        public MenuPrincipal(Liquidacion liquidacion)
        {
            this.liquidacion = liquidacion;
        }

        public int menuPrincipal()
        {
            int OPC;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(101, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(102, 7); Console.WriteLine("TALLER DE PROGRAMACION III");
            Console.SetCursorPosition(94, 8); Console.WriteLine("SOFTWARE DE LIQUIDACIÓN IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(102, 9); Console.WriteLine("M E N U  P R I N C I P A L");
            Console.SetCursorPosition(101, 13); Console.WriteLine("1. REGISTRO DE PACIENTES");
            Console.SetCursorPosition(101, 14); Console.WriteLine("2. CONSULTA TOTAL DE PACIENTES");
            Console.SetCursorPosition(101, 16); Console.WriteLine("3. ELIMINAR PACIENTE");
            Console.SetCursorPosition(101, 18); Console.WriteLine("4. SALIR");
            do
            {
                Console.SetCursorPosition(101, 21); Console.WriteLine("Seleccione una opcion: ");
                Console.SetCursorPosition(124, 21); OPC = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(124, 21); Console.WriteLine("         ");
                Console.SetCursorPosition(124, 26); Console.WriteLine("Opcion no valida");
            } while ((OPC < 1) || (OPC > 4));
            Console.SetCursorPosition(124, 21); Console.WriteLine("                                     ");
            Console.SetCursorPosition(124, 26); Console.WriteLine("                                     ");
            return OPC;
        }
    }
}
