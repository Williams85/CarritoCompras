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
    public class MedioPagoRepositorio
    {
        #region "Metodos No Transaccionales"
        public List<MedioPagoEntidad> listarActivos()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_MedioPago_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<MedioPagoEntidad> ListaMedioPago = new List<MedioPagoEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MedioPagoEntidad oMedioPagoEntidad = new MedioPagoEntidad();
                        oMedioPagoEntidad.Cod_MedioPago = Reader.GetIntValue(reader, "Cod_MedioPago");
                        oMedioPagoEntidad.Nom_MedioPago = Reader.GetStringValue(reader, "Nom_MedioPago");
                        oMedioPagoEntidad.Foto = Reader.GetStringValue(reader, "Foto");
                        ListaMedioPago.Add(oMedioPagoEntidad);
                    }
                }
                return ListaMedioPago;
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
