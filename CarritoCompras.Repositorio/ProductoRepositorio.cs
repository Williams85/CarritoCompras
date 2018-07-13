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
    public class ProductoRepositorio
    {
        #region "Metodos No Transaccionales"
        public List<ProductoEntidad> filtrar(ProductoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Producto_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Categoria", SqlDbType.Int)).Value = entidad.Categoria.Cod_Categoria;
                cmd.Parameters.Add(new SqlParameter("@Nom_Producto", SqlDbType.VarChar, 100)).Value = (entidad.Nom_Producto != null ? entidad.Nom_Producto : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<ProductoEntidad> ListaProducto = new List<ProductoEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductoEntidad oProductoEntidad = new ProductoEntidad();
                        oProductoEntidad.Cod_Producto = Reader.GetIntValue(reader, "Cod_Producto");
                        oProductoEntidad.Nom_Producto = Reader.GetStringValue(reader, "Nom_Producto");
                        oProductoEntidad.Cantidad = Reader.GetIntValue(reader, "Cantidad");
                        oProductoEntidad.Foto = Reader.GetStringValue(reader, "Foto");
                        oProductoEntidad.Precio = Reader.GetDoubleValue(reader, "Precio");
                        ListaProducto.Add(oProductoEntidad);
                    }
                }
                return ListaProducto;
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

        public ProductoEntidad ObtenerxCodigo(string Codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Producto_ObtenerxId", cn);
                cmd.Parameters.Add(new SqlParameter("@Cod_Producto", SqlDbType.Int)).Value = Int32.Parse(Codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                ProductoEntidad oProductoEntidad = new ProductoEntidad();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oProductoEntidad.Cod_Producto = Reader.GetIntValue(reader, "Cod_Producto");
                        oProductoEntidad.Nom_Producto = Reader.GetStringValue(reader, "Nom_Producto");
                        oProductoEntidad.Categoria = new CategoriaEntidad
                        {
                            Cod_Categoria = Reader.GetIntValue(reader, "Cod_Categoria"),
                            Nom_Categoria = Reader.GetStringValue(reader, "Nom_Categoria"),
                        };
                        oProductoEntidad.UnidadMedida = new UnidadMedidaEntidad
                        {
                            Cod_UnidadMedida = Reader.GetIntValue(reader, "Cod_UnidadMedida"),
                            Nom_UnidadMedida = Reader.GetStringValue(reader, "Nom_UnidadMedida"),
                        };
                        oProductoEntidad.Foto = Reader.GetStringValue(reader, "Foto");
                        oProductoEntidad.Precio = Reader.GetDoubleValue(reader, "Precio");
                        oProductoEntidad.Cantidad = Reader.GetIntValue(reader, "Cantidad");
                        oProductoEntidad.Estado = Reader.GetBooleanValue(reader, "Estado");
                    }
                }
                return oProductoEntidad;
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
