using CarritoCompras.Dominio;
using CarritoCompras.Entidad;
using CarritoCompras.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarritoCompras.TaskService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsuarioService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsuarioService.svc or UsuarioService.svc.cs at the Solution Explorer and start debugging.
    public class UsuarioService : IUsuarioService
    {

        public UsuarioEntidad ValidarUsuario(UsuarioEntidad entidad)
        {
            UsuarioDominio oUsuarioDominio = new UsuarioDominio();
            return oUsuarioDominio.validarUsuario(entidad);
        }
    }
}
