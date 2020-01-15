namespace EjemploComando
{
    public class AccionDispararRifle : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionDispararRifle(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"DISPARA RIFLE DE PLASMA\n");
        }
    }
}
