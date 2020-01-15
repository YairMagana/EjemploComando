using System;

namespace EjemploComando
{
    public class ReceiverPersonaje
    {
        public int poder;
        public ReceiverPersonaje(int _poder)
        {
            poder = _poder;
        }

        public void EjecutaAccion(string a)
        {
            Console.WriteLine($"\tPersonaje: {a}");
        }
    }
}
