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

        public void menuPrincipal_()
        {

            int MENU_;
            char OP = 'S';
            while (OP == 'S')
            {
                MENU_ = menuPrincipal();
                switch (MENU_)
                {
                    case 1:
                        Console.Clear();
                        registro();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        MostrarRegistro();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        EliminarRegistro();
                        Console.Clear();
                        break;
                    case 4:
                        OP = 'N';
                        break;
                }
            }
        }

        public void registro()
        {
            string IdLiquidacion;
            string Fecha;
            string IdPaciente;
            string TipoAfiliacion;
            double SalarioDevengado;
            double ValorHospitalizacion;
          

        char OP = 'S';
            while (OP == 'S')
            {
                try
                {
                    //titulos1();
                    Console.SetCursorPosition(35, 11); Console.WriteLine("ID DE LIQUIDACIÓN        : ");
                    Console.SetCursorPosition(35, 12); Console.WriteLine("FECHA                    : ");
                    Console.SetCursorPosition(35, 13); Console.WriteLine("ID DE PACIENTE           : ");
                    Console.SetCursorPosition(35, 14); Console.WriteLine("TIPO DE AFILIACIÓN       : ");
                    Console.SetCursorPosition(35, 15); Console.WriteLine("SALARIO DEVENGADO        : ");
                    Console.SetCursorPosition(35, 16); Console.WriteLine("VALOR DE HOSPITALIZACIÓN : ");

                    Console.SetCursorPosition(64, 11); IdLiquidacion = Console.ReadLine();
                    Console.SetCursorPosition(64, 12); Fecha = Console.ReadLine();

                    Console.SetCursorPosition(64, 13); IdPaciente = Console.ReadLine().ToUpper();

                    do
                    {
                        Console.SetCursorPosition(35, 25); Console.WriteLine("Digite S: Subsidiado o Digite C: Contributivo");
                        Console.SetCursorPosition(64, 14); TipoAfiliacion = Console.ReadLine().ToUpper();
                    } while ((TipoAfiliacion != "S") && (TipoAfiliacion != "C"));
                    do
                    {
                        Console.SetCursorPosition(64, 15); SalarioDevengado = Convert.ToDouble(Console.ReadLine());
                    } while (SalarioDevengado < 0);
                    do
                    {
                        Console.SetCursorPosition(64, 16); ValorHospitalizacion = Convert.ToDouble(Console.ReadLine());
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

        public void MostrarRegistro()
        {
            titulos4();
            try
            {
                Console.SetCursorPosition(35, 15); Console.WriteLine("ID ESTABLECIMIENTO  ESTABLECIMIENTO            INGRESOS ANUALES     GASTOS ANUALES    TIEMPO DE FUNCIONAMIENTO  TIPO DE RESPONSABILIDAD  GANANCIA     VALOR UVT   TARIFA  IMPUESTO");
                int X = 17;
                var lista = liquidacionoService.CargarRegistros();
                foreach (var i in lista)
                {
                    Console.SetCursorPosition(42, X); Console.WriteLine(i.IdLiquidacion);
                    Console.SetCursorPosition(59, X); Console.WriteLine(i.FechaLiquidacion);
                    Console.SetCursorPosition(83, X); Console.WriteLine(i.IdPaciente  );
                    Console.SetCursorPosition(103, X); Console.WriteLine(i.TipoAfiliacion);
                    Console.SetCursorPosition(131, X); Console.WriteLine($"{i.SalarioDevengado:C}");
                    Console.SetCursorPosition(159, X); Console.WriteLine($"{i.ValorHospitalizacion:C}");
                    Console.SetCursorPosition(169, X); Console.WriteLine(i.Tarifa.ToString("F1"));
                    Console.SetCursorPosition(187, X); Console.WriteLine(i.CuotaModeradora.ToString("F1"));
                    Console.SetCursorPosition(197, X); Console.WriteLine(i.TopeMax);
                    X++;
                }
                Console.SetCursorPosition(115, 14 + X); Console.WriteLine("Presione cualquier tecla para continuar.");
                Console.SetCursorPosition(155, 14 + X); Console.ReadKey();
                Console.Clear();
            }
            catch (IOException)
            {
                Console.SetCursorPosition(108, 20); Console.Write("Ups... Algo pasó");
                Console.SetCursorPosition(108, 25); Console.WriteLine("No hay registros para mostrar.");
            }

        }

        public void EliminarRegistro()
        {


        }
        public void titulos1()
        {
            Console.SetCursorPosition(115, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(116, 7); Console.WriteLine("TALLER DE PROGRAMACION III");
            Console.SetCursorPosition(108, 8); Console.WriteLine("SOFTWARE DE LIQUIDACIÓN IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(122, 9); Console.WriteLine("R E G I S T R O");
        }
        public void titulos2()
        {
            Console.SetCursorPosition(115, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(116, 7); Console.WriteLine("TALLER DE PROGRAMACION III");
            Console.SetCursorPosition(108, 8); Console.WriteLine("SOFTWARE DE LIQUIDACIÓN IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(119, 9); Console.WriteLine("E L I M I N A C I O N");
        }
        public void titulos4()
        {
            Console.SetCursorPosition(115, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(118, 7); Console.WriteLine("TALLER DE PROGRAMACION III");
            Console.SetCursorPosition(108, 8); Console.WriteLine("SOFTWARE DE LIQUIDACIÓN IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(114, 9); Console.WriteLine("INFORMACION DE IPS");
        }
    }
}
