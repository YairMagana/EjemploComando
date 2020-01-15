namespace EjemploComando
{
    public class AccionCaminar : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionCaminar(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"AVANZA {receiverPersonaje.poder / 10.0m} {((receiverPersonaje.poder / 10.0m > 1m) ? "PASOS" : "PASO")}\n");
        }
    }
}
