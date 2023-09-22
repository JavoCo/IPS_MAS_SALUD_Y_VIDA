using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;

namespace IPS_MAS_SALUD_Y_VIDA
{
    internal class Principal
    {
        static void Main(string[] args)
        {
            Console.Title = "/tMi Aplicación en Pantalla Completa";
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.BufferHeight = Console.LargestWindowHeight;
            Console.BufferWidth = Console.LargestWindowWidth;
            Liquidacion producto = new Liquidacion();
            MenuPrincipal menu = new MenuPrincipal(producto);
            menu.menuPrincipal_();

        }
    }
}
