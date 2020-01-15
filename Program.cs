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
            ReceiverPersonaje personaje = null;
            AdministradorAcciones administradorAcciones;

            string menuJuego;

            ConsoleKeyInfo k1;
            ConsoleKeyInfo k2;

            do
            {
                Console.WriteLine("-- MENÚ --\n\nA. Jugar  X. Salir");

                k1 = Console.ReadKey();
                if (k1.Key == ConsoleKey.A)
                {

                    personaje = SeleccionarTipoPersonaje();

                    if (personaje != null)
                    {

                        Console.Clear();
                        administradorAcciones = IniciarPersonaje(personaje);

                        do
                        {
                            menuJuego = GenerarMenuAcciones(administradorAcciones.dicAcciones);
                            Console.WriteLine(menuJuego);
                            k2 = Console.ReadKey();

                            IAcciones accion = administradorAcciones.ObtenerAccion(k2.KeyChar.ToString());
                            if (accion != null)
                            {
                                // ** Ejecución de comandos normales
                                invocador.EstablecerComando(accion);
                                invocador.EjecutarAccion();

                                // ** Detección de comandos Especiales
                                if (accion == administradorAcciones.ObtenerAccion("1"))
                                {
                                    administradorAcciones.AgegarComando(new string[] { "Q", "Disparar Lanzagranadas" }, new AccionDispararLanzagranadas(personaje));
                                    administradorAcciones.RemoverComando("1");
                                }
                                if (accion == administradorAcciones.ObtenerAccion("2"))
                                {
                                    administradorAcciones.AgegarComando(new string[] { "W", "Disparar Rifle de Plasma" }, new AccionDispararRifle(personaje));
                                    administradorAcciones.RemoverComando("2");
                                }
                            }
                            else
                            {
                                Console.WriteLine("...\n");
                            }

                        } while (k2.Key != ConsoleKey.X);
                        Console.Clear();
                    }
                    Console.Clear();
                }
            } while (k1.Key != ConsoleKey.X);
        }

        public static ReceiverPersonaje SeleccionarTipoPersonaje()
        {
            ReceiverPersonaje personaje = null;
            ConsoleKeyInfo k;
            do
            {
                Console.Clear();
                Console.WriteLine("Seleccionar Tipo de Personaje:\n\tA. Guerrero Nivel 10\n\tB. Guerrero Nivel 20\n\tC. Guerrero Nivel 30\n\tX. Regresar");
                k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.A:
                        personaje = new ReceiverPersonaje(10);
                        break;
                    case ConsoleKey.B:
                        personaje = new ReceiverPersonaje(20);
                        break;
                    case ConsoleKey.C:
                        personaje = new ReceiverPersonaje(30);
                        break;
                }
            } while (k.Key != ConsoleKey.X && personaje == null);
            return personaje;
        }

        public static string GenerarMenuAcciones(Dictionary<string[], IAcciones> dicAcciones)
        {
            string v = string.Empty;
            foreach (var e in dicAcciones)
            {
                v += $"{e.Key[0]}:{e.Key[1]}  ";
            }
            v += $"X: Salir  ";

            return v;
        }

        public static AdministradorAcciones IniciarPersonaje(ReceiverPersonaje receiverPersonaje)
        {
            Dictionary<string[], IAcciones> dicAcciones = new Dictionary<string[], IAcciones>();
            AdministradorAcciones administradorAcciones = new AdministradorAcciones(dicAcciones);

            administradorAcciones.AgegarComando(new string[] { "A", "Caminar" }, new AccionCaminar(receiverPersonaje));
            administradorAcciones.AgegarComando(new string[] { "S", "Saltar" }, new AccionSaltar(receiverPersonaje));
            administradorAcciones.AgegarComando(new string[] { "D", "Golpear" }, new AccionGolpear(receiverPersonaje));
            administradorAcciones.AgegarComando(new string[] { "F", "Disparar" }, new AccionDisparar(receiverPersonaje));
            administradorAcciones.AgegarComando(new string[] { "1", "Conseguir Lanzagranadas" }, new AccionEquiparLanzagranadas(receiverPersonaje));
            administradorAcciones.AgegarComando(new string[] { "2", "Conseguir Rifle de plasma" }, new AccionEquiparRifle(receiverPersonaje));

            return administradorAcciones;
        }
    }
}
