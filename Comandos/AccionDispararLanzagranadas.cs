namespace EjemploComando
{
    public class AccionDispararLanzagranadas : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionDispararLanzagranadas(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"DISPARA LANZAGRANADAS\n");
        }
    }
}
