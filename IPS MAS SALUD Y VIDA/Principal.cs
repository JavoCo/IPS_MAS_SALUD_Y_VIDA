using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;

namespace IPS_MAS_SALUD_Y_VIDA
{
    internal class Principal
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_MAXIMIZE = 3;
        static void Main(string[] args)
        {


            // Obtén el identificador de la ventana de la consola actual
            IntPtr hwnd = GetConsoleWindow();

            if (hwnd != IntPtr.Zero)
            {
                // Maximiza la ventana de la consola
                ShowWindow(hwnd, SW_MAXIMIZE);
            }
            Console.Title = "IPS MAS SALUD Y VIDA - LIQUIDES";

            Liquidacion producto = new Liquidacion();
            MenuPrincipal menu = new MenuPrincipal(producto);
            menu.menuPrincipal_();


        }

    }
}
