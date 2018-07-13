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
    public class CategoriaRepositorio
    {
        #region "Metodos No Transaccionales"
        public List<CategoriaEntidad> listarActivos()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCarritoCompras);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Categoria_ListarActivos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<CategoriaEntidad> ListaCategoria = new List<CategoriaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CategoriaEntidad oCategoriaEntidad = new CategoriaEntidad();
                        oCategoriaEntidad.Cod_Categoria = Reader.GetIntValue(reader, "Cod_Categoria");
                        oCategoriaEntidad.Nom_Categoria = Reader.GetStringValue(reader, "Nom_Categoria");
                        ListaCategoria.Add(oCategoriaEntidad);
                    }
                }
                return ListaCategoria;
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
