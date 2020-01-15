namespace EjemploComando
{
    public class AccionEquiparLanzagranadas : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionEquiparLanzagranadas(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"EQUIPAR LANZAGRANADAS\n");
        }
    }
}
