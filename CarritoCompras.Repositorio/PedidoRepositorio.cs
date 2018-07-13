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
    public class PedidoRepositorio
    {
        #region "Metodos No Transaccionales"
        public List<PedidoEntidad> FiltrarPedido(PedidoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Pedido_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", SqlDbType.VarChar,10)).Value = entidad.Fecha_Inicio.ToString("dd/MM/yyyy");
                cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", SqlDbType.VarChar, 10)).Value = entidad.Fecha_Fin.ToString("dd/MM/yyyy");
                cmd.CommandType = CommandType.StoredProcedure;
                List<PedidoEntidad> ListaPedido = new List<PedidoEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PedidoEntidad oPedidoEntidad = new PedidoEntidad();
                        oPedidoEntidad.Cod_Pedido = Reader.GetIntValue(reader, "Cod_Pedido");
                        oPedidoEntidad.Num_Pedido = Reader.GetStringValue(reader, "Num_Pedido");
                        oPedidoEntidad.Cliente = new ClienteEntidad
                        {
                            Cod_Cliente = Reader.GetIntValue(reader, "Cod_Cliente"),
                            Nom_Cliente = Reader.GetStringValue(reader, "Nom_Cliente")
                        };
                        oPedidoEntidad.Fecha_Pedido = Reader.GetDateTimeValue(reader, "Fecha_Pedido");
                        oPedidoEntidad.Fecha_Entrega = Reader.GetDateTimeValue(reader, "Fecha_Entrega");
                        oPedidoEntidad.Total_Neto = Reader.GetDoubleValue(reader, "Total_Neto");
                        oPedidoEntidad.EstadoPedido = new EstadoPedidoEntidad
                        {
                            Cod_EstadoPedido = Reader.GetIntValue(reader, "Cod_EstadoPedido"),
                            Nom_EstadoPedido = Reader.GetStringValue(reader, "Nom_EstadoPedido")
                        };
                        ListaPedido.Add(oPedidoEntidad);
                    }
                }
                return ListaPedido;
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

        public PedidoEntidad ObtenerxId(PedidoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Pedido_ObtenerxId", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Pedido", SqlDbType.Int)).Value = entidad.Cod_Pedido;
                cmd.CommandType = CommandType.StoredProcedure;
                PedidoEntidad oPedidoEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oPedidoEntidad = new PedidoEntidad();
                        oPedidoEntidad.Cod_Pedido = Reader.GetIntValue(reader, "Cod_Pedido");
                        oPedidoEntidad.Num_Pedido = Reader.GetStringValue(reader, "Num_Pedido");
                        oPedidoEntidad.Cliente = new ClienteEntidad
                        {
                            Cod_Cliente = Reader.GetIntValue(reader, "Cod_Cliente"),
                            Nom_Cliente = Reader.GetStringValue(reader, "Nom_Cliente")
                        };
                        oPedidoEntidad.Fecha_Pedido = Reader.GetDateTimeValue(reader, "Fecha_Pedido");
                        oPedidoEntidad.Fecha_Entrega = Reader.GetDateTimeValue(reader, "Fecha_Entrega");
                        oPedidoEntidad.Total_Neto = Reader.GetDoubleValue(reader, "Total_Neto");
                        oPedidoEntidad.EstadoPedido = new EstadoPedidoEntidad
                        {
                            Cod_EstadoPedido = Reader.GetIntValue(reader, "Cod_EstadoPedido"),
                            Nom_EstadoPedido = Reader.GetStringValue(reader, "Nom_EstadoPedido")
                        };
                    }
                }
                return oPedidoEntidad;
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

        public bool RegistrarPedido(PedidoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            SqlTransaction trans = null;
            try
            {
                bool estado = true;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd01 = new SqlCommand("usp_Pedido_Grabar", cn);
                cmd01.Parameters.Add(new SqlParameter("@Cod_Cliente", SqlDbType.Int)).Value = entidad.Cliente.Cod_Cliente;
                cmd01.Parameters.Add(new SqlParameter("@Cod_MedioPago", SqlDbType.Int)).Value = entidad.MedioPago.Cod_MedioPago;
                cmd01.Parameters.Add(new SqlParameter("@Dir_Entrega", SqlDbType.VarChar,50)).Value = entidad.Dir_Entrega;
                cmd01.Parameters.Add(new SqlParameter("@Fecha_Entrega", SqlDbType.SmallDateTime)).Value = entidad.Fecha_Entrega;
                cmd01.Parameters.Add(new SqlParameter("@Total_Neto", SqlDbType.Real)).Value = entidad.Total_Neto;
                cmd01.Parameters.Add(new SqlParameter("@Cod_Pedido", SqlDbType.Int)).Direction = ParameterDirection.Output;
                cmd01.CommandType = CommandType.StoredProcedure;
                cmd01.Transaction = trans;

                if (cmd01.ExecuteNonQuery() > 0)
                {
                    var Cod_Pedido = int.Parse(cmd01.Parameters["@Cod_Pedido"].Value.ToString());
                    foreach (var objeto in entidad.DetallePedido)
                    {
                        SqlCommand cmd02 = new SqlCommand("usp_DetallePedido_Grabar", cn);
                        cmd02.Parameters.Add(new SqlParameter("@Cod_Pedido", SqlDbType.Int)).Value = Cod_Pedido;
                        cmd02.Parameters.Add(new SqlParameter("@Cod_Producto", SqlDbType.Int)).Value = objeto.Producto.Cod_Producto;
                        cmd02.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int)).Value = objeto.Cantidad;
                        cmd02.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Real)).Value = objeto.SubTotal;
                        cmd02.CommandType = CommandType.StoredProcedure;
                        cmd02.Transaction = trans;
                        if (cmd02.ExecuteNonQuery() < 1)
                        {
                            estado = false;
                            break;
                        }
                    }
                }
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


        public bool ModificarPedido(PedidoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            SqlTransaction trans = null;
            try
            {
                bool estado = true;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Pedido_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Pedido", SqlDbType.Int)).Value = entidad.Cod_Pedido;
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
