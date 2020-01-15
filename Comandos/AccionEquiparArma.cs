namespace EjemploComando
{
    public class AccionEquiparArma : IAcciones
    {
        private ReceiverPersonaje receiverPersonaje;

        public AccionEquiparArma(ReceiverPersonaje receiver)
        {
            this.receiverPersonaje = receiver;
        }

        public void Ejecutar()
        {
            receiverPersonaje.EjecutaAccion($"EQUIPAR ARMA\n");
        }
    }
}
