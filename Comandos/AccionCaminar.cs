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
            receiverPersonaje.EjecutaAccion($"AVANZA 1 PASO\n");
        }
    }
}
