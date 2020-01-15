namespace EjemploComando
{
    public class AccionEquiparRifle : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionEquiparRifle(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"EQUIPAR LANZAGRANADAS\n");
        }
    }
}
