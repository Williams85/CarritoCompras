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
    public class ClienteRepositorio
    {
        #region "Metodos No Transaccionales"
        public ClienteEntidad BuscarCliente(ClienteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Cliente_Buscar", cn);
                cmd.Parameters.Add(new SqlParameter("@Ema_Cliente", SqlDbType.VarChar, 250)).Value = entidad.Ema_Cliente;
                cmd.CommandType = CommandType.StoredProcedure;
                ClienteEntidad oClienteEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oClienteEntidad = new ClienteEntidad();
                        oClienteEntidad.Cod_Cliente = Reader.GetIntValue(reader, "Cod_Cliente");
                        oClienteEntidad.Nom_Cliente = Reader.GetStringValue(reader, "Nom_Cliente");
                        oClienteEntidad.Ema_Cliente = Reader.GetStringValue(reader, "Ema_Cliente");
                    }
                }
                return oClienteEntidad;
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

        #region "Metodos Transaccionales"

        public bool RegistrarCliente(ClienteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            SqlTransaction trans = null;
            try
            {
                bool estado = true;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Cliente", SqlDbType.VarChar,150)).Value = entidad.Nom_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Ema_Cliente", SqlDbType.VarChar, 150)).Value = entidad.Ema_Cliente;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                if (cmd.ExecuteNonQuery() < 1) { estado = false; }
                if (estado)
                    trans.Commit();
                else
                    trans.Rollback();

                return estado;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conexion.cerrarConexion(cn);
            }
        }


        public bool ModificarCliente(ClienteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            SqlTransaction trans = null;
            try
            {
                bool estado = true;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Cliente", SqlDbType.Int)).Value = entidad.Cod_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Nom_Cliente", SqlDbType.VarChar, 150)).Value = entidad.Nom_Cliente;
                cmd.Parameters.Add(new SqlParameter("@Ema_Cliente", SqlDbType.VarChar, 150)).Value = entidad.Ema_Cliente;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                if (cmd.ExecuteNonQuery() < 1) { estado = false; }
                if (estado)
                    trans.Commit();
                else
                    trans.Rollback();

                return estado;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conexion.cerrarConexion(cn);
            }
        }


        #endregion
    }
}
