namespace EjemploComando
{
    public class AccionDisparar : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionDisparar(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"DISPARA\n");
        }
    }
}
