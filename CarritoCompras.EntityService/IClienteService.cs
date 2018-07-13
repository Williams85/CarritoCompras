﻿using CarritoCompras.Entidad;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.EntityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClienteService" in both code and config file together.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        ResponseWeb GuardarCliente(ClienteEntidad entidad);

        [OperationContract]
        ResponseWeb ActualizarCliente(ClienteEntidad entidad);

        [OperationContract]
        ClienteEntidad BuscarCliente(ClienteEntidad entidad);


    }
}
