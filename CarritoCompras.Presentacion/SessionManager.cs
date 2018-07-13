using CarritoCompras.Agente.US;
using CarritoCompras.Agente.VS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CarritoCompras.Presentacion
{
    public class SessionManager
    {
        public static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }
        #region "Atributos"
        const string _ListaCategorias = "ListaCategorias";
        const string _Usuario = "Usuario";
        #endregion

        #region "Propiedades"

        public static List<CategoriaEntidad> ListaCategorias
        {
            get { return (List<CategoriaEntidad>)Session[_ListaCategorias]; }
            set { Session[_ListaCategorias] = value; }
        }
        public static UsuarioEntidad Usuario
        {
            get { return (UsuarioEntidad)Session[_Usuario]; }
            set { Session[_Usuario] = value; }
        }


        #endregion

    }
}