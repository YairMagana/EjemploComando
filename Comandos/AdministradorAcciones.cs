using System.Collections.Generic;
using System.Linq;

namespace EjemploComando
{
    public class AdministradorAcciones
    {
        public Dictionary<string[], IAcciones> dicAcciones;

        public AdministradorAcciones(Dictionary<string[], IAcciones> _dicAcciones)
        {
            dicAcciones = _dicAcciones;
        }

        public void AgegarComando(string[] nAccion, IAcciones accion)
        {
            dicAcciones.Add(nAccion, accion);
        }

        public void RemoverComando(string nAccion)
        {
            string[] keyAccion = dicAcciones.Where(w => w.Key[0].ToUpper() == nAccion.ToUpper()).Select(s => s.Key).FirstOrDefault();
            dicAcciones.Remove(keyAccion);
        }

        public IAcciones ObtenerAccion(string nAccion)
        {
            return dicAcciones.Where(w => w.Key[0].ToUpper() == nAccion.ToUpper()).Select(s => s.Value).FirstOrDefault();
        }
    }
}
