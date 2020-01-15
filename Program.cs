using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EjemploComando
{
    class Program
    {
        static void Main(string[] args)
        {
            Invocador invocador = new Invocador();
            ReceiverPersonaje receiverPersonaje = new ReceiverPersonaje();

            IAcciones accionCaminar = new AccionCaminar(receiverPersonaje);
            IAcciones accionGolpear = new AccionGolpear(receiverPersonaje);
            IAcciones accionDisparar = new AccionDisparar(receiverPersonaje);
            IAcciones accionEquiparArma = new AccionEquiparArma(receiverPersonaje);

            Dictionary<string[], IAcciones> dicAcciones = new Dictionary<string[], IAcciones>();
            AdministradorAcciones administradorAcciones = new AdministradorAcciones(dicAcciones);

            administradorAcciones.AgegarComando(new string[] { "A", "Caminar" }, accionCaminar);
            administradorAcciones.AgegarComando(new string[] { "S", "Golpear" }, accionGolpear);
            administradorAcciones.AgegarComando(new string[] { "W", "Equipar Arma" }, accionEquiparArma);

            string k;
            string menu;

            do
            {
                Console.WriteLine("-- MENÚ --\n\nA. Jugar  X. Salir");

                k = Console.ReadLine();
                if (k.ToUpper() == "A")
                {
                    k = string.Empty;
                    Console.Clear();
                    do
                    {
                        menu = GenrarMenuAcciones(dicAcciones);
                        Console.WriteLine(menu);
                        k = Console.ReadLine();

                        IAcciones accion = administradorAcciones.ObtenerAccion(k);
                        if (accion != null)
                        {
                            invocador.EstablecerComando(accion);
                            invocador.EjecutarAccion();

                            if (accion == accionEquiparArma)
                            {
                                administradorAcciones.AgegarComando(new string[] { "D", "Disparar" }, accionDisparar);
                                administradorAcciones.RemoverComando("W");
                            }
                        }
                        else
                        {
                            Console.WriteLine("...\n");
                        }

                    } while (k.ToUpper() != "X");

                    k = string.Empty;
                    Console.Clear();
                }
            } while (k.ToUpper() != "X");
        }

        public static string GenrarMenuAcciones(Dictionary<string[], IAcciones> dicAcciones)
        {
            string v = string.Empty;
            foreach (var e in dicAcciones)
            {
                v += $"{e.Key[0]}:{e.Key[1]}  ";
            }
            v += $"X: Salir  ";

            return v;
        }
    }
}
