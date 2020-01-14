using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploComando
{
    public interface IAcciones
    {
        void Ejecutar();
    }

    public class AccionCaminar : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionCaminar(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"AVANZA 1 PASO");
        }
    }

    public class AccionGolpear : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionGolpear(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"LANZA GOLPE");
        }
    }

    public class AdministradorAcciones
    {
        Dictionary<string[], IAcciones> dicAcciones;

        public AdministradorAcciones(Dictionary<string[], IAcciones> _dicAcciones)
        {
            dicAcciones = _dicAcciones;
        }

        public void AgegarComandos(string[] nAccion, IAcciones accion)
        {
            dicAcciones.Add(nAccion, accion);
        }

        public IAcciones ObtenerAccion(string nAccion)
        {
            return dicAcciones.Where(w => w.Key[0].ToUpper() == nAccion.ToUpper()).Select(s => s.Value).FirstOrDefault();
        }
    }

    public class AccionDisparar : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionDisparar(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"DISPARA");
        }
    }

    public class ReceiverPersonaje
    {
        public void EjecutaAccion(string a)
        {
            Console.WriteLine($"\tPersonaje: {a}");
        }
    }

    public class Invocador
    {
        private IAcciones acciones;

        public void EstablecerComando(IAcciones acciones)
        {
            this.acciones = acciones;
        }

        public void EjecutarAccion()
        {
            Console.WriteLine("Acción:");
            this.acciones.Ejecutar();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Invocador invocador = new Invocador();
            ReceiverPersonaje receiverPersonaje = new ReceiverPersonaje();

            IAcciones accionCaminar = new AccionCaminar(receiverPersonaje);
            IAcciones accionGolpear = new AccionGolpear(receiverPersonaje);
            IAcciones accionDisparar = new AccionDisparar(receiverPersonaje);

            Dictionary<string[], IAcciones> dicAcciones = new Dictionary<string[], IAcciones>();
            AdministradorAcciones administradorAcciones = new AdministradorAcciones(dicAcciones);

            administradorAcciones.AgegarComandos(new string[] { "A","Caminar" }, accionCaminar);
            administradorAcciones.AgegarComandos(new string[] { "B","Golpear" }, accionGolpear);

            string k;
            string menu;

            while ((k = Console.ReadLine()) != "x")
            {
                menu = GenrarMenuAcciones(dicAcciones);
                Console.WriteLine(menu);



                //Console.WriteLine();
                //Console.WriteLine("A. Caminar");
                //Console.WriteLine("B. Golpear");
                //Console.WriteLine("X. Salir");
                //Console.WriteLine("- W. Tomar Arma -");


                //switch (k)
                //{
                //    case "a":
                //        invocador.EstablecerComando(accionCaminar);
                //        invocador.EjecutarAccion();
                //        break;
                //    case "b":
                //        invocador.EstablecerComando(accionGolpear);
                //        invocador.EjecutarAccion();
                //        break;
                //}

            }
        }



        public static string GenrarMenuAcciones(Dictionary<string[], IAcciones> dicAcciones)
        {
            string v = string.Empty;
            foreach (var e in dicAcciones)
            {
                v+= $"{e.Key[0]}. {e.Key[1]} ";
            }
            v += $"X. Salir";
            return v;
        }
    }
}
