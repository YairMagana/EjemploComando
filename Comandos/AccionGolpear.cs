namespace EjemploComando
{
    public class AccionGolpear : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionGolpear(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"LANZA GOLPE\n");
        }
    }
}
