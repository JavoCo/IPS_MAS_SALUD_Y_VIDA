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
            Console.SetCursorPosition(75, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(77, 7); Console.WriteLine("TALLER DE PROGRAMACION III");
            Console.SetCursorPosition(68, 8); Console.WriteLine("SOFTWARE DE LIQUIDACIÓN IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(76, 9); Console.WriteLine("M E N U  P R I N C I P A L");
            Console.SetCursorPosition(75, 13); Console.WriteLine("1. REGISTRO DE PACIENTES");
            Console.SetCursorPosition(75, 14); Console.WriteLine("2. CONSULTA TOTAL DE PACIENTES");
            Console.SetCursorPosition(75, 15); Console.WriteLine("3. ELIMINAR PACIENTE");
            Console.SetCursorPosition(75, 18); Console.WriteLine("4. SALIR");
            do
            {
                Console.SetCursorPosition(75, 21); Console.WriteLine("Seleccione una opcion: ");
                Console.SetCursorPosition(98, 21); OPC = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(98, 21); Console.WriteLine("         ");
                Console.SetCursorPosition(98, 26); Console.WriteLine("Opcion no valida");
            } while ((OPC < 1) || (OPC > 4));
            Console.SetCursorPosition(98, 21); Console.WriteLine("                                     ");
            Console.SetCursorPosition(98, 26); Console.WriteLine("                                     ");
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
                    titulos1();
                    Console.SetCursorPosition(35, 11); Console.WriteLine("ID DE LIQUIDACIÓN        : ");
                    Console.SetCursorPosition(35, 12); Console.WriteLine("FECHA                    : ");
                    Console.SetCursorPosition(35, 13); Console.WriteLine("ID DE PACIENTE           : ");
                    Console.SetCursorPosition(35, 14); Console.WriteLine("TIPO DE AFILIACIÓN       : ");
                    Console.SetCursorPosition(35, 15); Console.WriteLine("SALARIO DEVENGADO        : ");
                    Console.SetCursorPosition(35, 16); Console.WriteLine("VALOR DE HOSPITALIZACIÓN : ");

                    Console.SetCursorPosition(63, 11); IdLiquidacion = Console.ReadLine();
                    Console.SetCursorPosition(63, 12); Fecha = Console.ReadLine();

                    Console.SetCursorPosition(63, 13); IdPaciente = Console.ReadLine().ToUpper();

                    do
                    {
                        Console.SetCursorPosition(35, 25); Console.WriteLine("Digite S: Subsidiado o Digite C: Contributivo");
                        Console.SetCursorPosition(63, 14); TipoAfiliacion = Console.ReadLine().ToUpper();
                        
                    } while ((TipoAfiliacion != "S") && (TipoAfiliacion != "C"));
                    Console.SetCursorPosition(35, 25); Console.WriteLine("                                                         ");
                    do
                    {
                        Console.SetCursorPosition(63, 15); SalarioDevengado = Convert.ToDouble(Console.ReadLine());
                    } while (SalarioDevengado < 0);
                    do
                    {
                        Console.SetCursorPosition(63, 16); ValorHospitalizacion = Convert.ToDouble(Console.ReadLine());
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
                Console.SetCursorPosition(5, 15); Console.WriteLine("ID LIQUIDACIÓN  FECHA LIQUIDACIÓN       ID PACIENTE     TIPO AFILIACIÓN    SALARIO DEVENGADO    VALOR DE HOSPITALIZACIÓN   TARIFA     CUOTA MODERADA   TOPE MÁX");
                int X = 17;
                var lista = liquidacionoService.CargarRegistros();
                if(lista != null){
                    foreach (var i in lista)
                    {
                        Console.SetCursorPosition(5, X); Console.WriteLine(i.IdLiquidacion);
                        Console.SetCursorPosition(21, X); Console.WriteLine(i.FechaLiquidacion);
                        Console.SetCursorPosition(46, X); Console.WriteLine(i.IdPaciente);
                        Console.SetCursorPosition(68, X); Console.WriteLine(i.TipoAfiliacion);
                        Console.SetCursorPosition(81, X); Console.WriteLine($"{i.SalarioDevengado:C}");
                        Console.SetCursorPosition(102, X); Console.WriteLine($"{i.ValorHospitalizacion:C}");
                        Console.SetCursorPosition(129, X); Console.WriteLine(i.Tarifa.ToString("F2"));
                        Console.SetCursorPosition(140, X); Console.WriteLine($"{i.CuotaModeradora:C}");
                        Console.SetCursorPosition(156, X); Console.WriteLine(i.TopeMax);
                        X++;
                    }
                    Console.SetCursorPosition(70, 14 + X); Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.SetCursorPosition(110, 14 + X); Console.ReadKey();
                    Console.Clear();
                }
                else{
                    
                    Console.SetCursorPosition(75, 25); Console.WriteLine("No hay registros para mostrar. ");
                    Console.SetCursorPosition(105, 25); Console.ReadKey();
                }

                
            }catch (IOException)
            {

            }
        }

        public void EliminarRegistro()
        {


        }
        public void titulos1()
        {
            Console.SetCursorPosition(75, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(77, 7); Console.WriteLine("TALLER DE PROGRAMACION III");
            Console.SetCursorPosition(68, 8); Console.WriteLine("SOFTWARE DE LIQUIDACIÓN IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(80, 9); Console.WriteLine("R E G I S T R O");
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
            Console.SetCursorPosition(75, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(77, 7); Console.WriteLine("TALLER DE PROGRAMACION III");
            Console.SetCursorPosition(68, 8); Console.WriteLine("SOFTWARE DE LIQUIDACIÓN IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(80, 9); Console.WriteLine("INFORMACION DE IPS");
        }
    }
}
