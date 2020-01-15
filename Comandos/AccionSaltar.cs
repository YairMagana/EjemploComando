namespace EjemploComando
{
    public class AccionSaltar : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionSaltar(ReceiverPersonaje receiverPersonaje)
        {
            this.receiverPersonaje = receiverPersonaje;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"SALTA {receiverPersonaje.poder / 20.0m} METROS\n");
        }
    }
}