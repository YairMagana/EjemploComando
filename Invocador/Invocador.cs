namespace EjemploComando
{
    public class Invocador
    {
        private IAcciones acciones;

        public void EstablecerComando(IAcciones acciones)
        {
            this.acciones = acciones;
        }

        public void EjecutarAccion()
        {
            this.acciones.Ejecutar();
        }
    }
}
