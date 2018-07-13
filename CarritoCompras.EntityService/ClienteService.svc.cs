using CarritoCompras.Entidad;
using CarritoCompras.EntityService.MCS;
using CarritoCompras.EntityService.MTS;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.EntityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.
    public class ClienteService : IClienteService
    {

        public ResponseWeb GuardarCliente(ClienteEntidad entidad)
        {
            MacroTransaccionServiceClient proxy = new MacroTransaccionServiceClient();
            return proxy.RegistrarCliente(entidad);
        }

        public ResponseWeb ActualizarCliente(ClienteEntidad entidad)
        {
            MacroTransaccionServiceClient proxy = new MacroTransaccionServiceClient();
            return proxy.ActualizarCliente(entidad);
        }

        public ClienteEntidad BuscarCliente(ClienteEntidad entidad)
        {
            MacroConsultaServiceClient proxy = new MacroConsultaServiceClient();
            return proxy.ObtenerCliente(entidad);
        }
    }
}
