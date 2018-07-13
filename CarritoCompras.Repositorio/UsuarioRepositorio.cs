using CarritoCompras.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras.Repositorio
{
    public class UsuarioRepositorio
    {
        #region "Metodos No Transaccionales"
        public UsuarioEntidad validarUsuario(UsuarioEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Usuario_ValidarUsuario", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Usuario", SqlDbType.VarChar, 250)).Value = entidad.Nom_Usuario;
                cmd.Parameters.Add(new SqlParameter("@Pass_Usuario", SqlDbType.VarChar, 250)).Value = entidad.Pass_Usuario;
                cmd.CommandType = CommandType.StoredProcedure;
                UsuarioEntidad oUsuarioEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oUsuarioEntidad = new UsuarioEntidad();
                        oUsuarioEntidad.Cod_Usuario = Reader.GetIntValue(reader, "Cod_Usuario");
                        oUsuarioEntidad.Nom_Usuario = Reader.GetStringValue(reader, "Nom_Usuario");
                        oUsuarioEntidad.Pass_Usuario = Reader.GetStringValue(reader, "Pass_Usuario");
                        oUsuarioEntidad.Perfil_Usuario = Reader.GetStringValue(reader, "Perfil_Usuario");
                    }
                }
                return oUsuarioEntidad;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.cerrarConexion(cn);
            }
        }
        #endregion



    }
}
