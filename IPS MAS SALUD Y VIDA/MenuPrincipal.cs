using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;
using System.IO;

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

        public void registro()
        {
            string IdLiquidacion;
            string Fecha;
            string IdPaciente;
            string TipoAfiliacion;
            double SalarioDevengado;
            double ValorHospitalizacion;
            double Tarifa;
            double CuotaModeradora;
            string TopeMax;

        char OP = 'S';
            while (OP == 'S')
            {
                try
                {
                    //titulos1();
                    Console.SetCursorPosition(35, 11); Console.WriteLine("ID DE LIQUIDACIÓN        : ");
                    Console.SetCursorPosition(35, 12); Console.WriteLine("FECHA                    : ");
                    Console.SetCursorPosition(35, 12); Console.WriteLine("ID DE PACIENTE           : ");
                    Console.SetCursorPosition(35, 13); Console.WriteLine("TIPO DE AFILIACIÓN       : ");
                    Console.SetCursorPosition(35, 14); Console.WriteLine("SALARIO DEVENGADO        : ");
                    Console.SetCursorPosition(35, 15); Console.WriteLine("VALOR DE HOSPITALIZACIÓN : ");

                    Console.SetCursorPosition(64, 11); IdLiquidacion = Console.ReadLine();
                    Console.SetCursorPosition(64, 11); Fecha = Console.ReadLine();

                    Console.SetCursorPosition(64, 12); IdPaciente = Console.ReadLine().ToUpper();

                    do
                    {
                        Console.SetCursorPosition(35, 25); Console.WriteLine("Digite S: Subsidiado o Digite C: Contributivo");
                        Console.SetCursorPosition(64, 13); TipoAfiliacion = Console.ReadLine().ToUpper();
                    } while ((TipoAfiliacion != "S") && (TipoAfiliacion != "C"));
                    do
                    {
                        Console.SetCursorPosition(64, 14); SalarioDevengado = Convert.ToDouble(Console.ReadLine());
                    } while (SalarioDevengado < 0);
                    do
                    {
                        Console.SetCursorPosition(64, 15); ValorHospitalizacion = Convert.ToDouble(Console.ReadLine());
                    } while (ValorHospitalizacion < 0);
                   
                    

                    Liquidacion liquidacion = new Liquidacion(IdLiquidacion,Fecha, IdPaciente, TipoAfiliacion, SalarioDevengado, ValorHospitalizacion,0,0,"");

                    
                    liquidacion.tarifa();
                    liquidacion.CalculoCuotaModeradora();
                    liquidacion.tope();
                    Console.SetCursorPosition(34, 25); Console.WriteLine(liquidacionoService.GuardarRegistros(liquidacion));
                    {
                        Console.SetCursorPosition(34, 18); Console.WriteLine("¿Desea continuar? S/N : ");
                        Console.SetCursorPosition(58, 18); OP = Convert.ToChar(Console.ReadLine());
                        OP = char.ToUpper(OP);
                        Console.Clear();
                    } while ((OP != 'S') && (OP != 'N')) ;
                }
                catch (IOException)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Ingresa un dato valido");
                }
            }
        }
    }
}
