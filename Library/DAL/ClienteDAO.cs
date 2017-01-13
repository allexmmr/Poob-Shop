using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Library.DAL
{
    /// <summary>
    /// Cliente Data Access Object
    /// </summary>
    public class ClienteDAO
    {
        #region Selects

        #region SelectByAll

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>DataTable com os clientes</returns>
        public DataTable SelectByAll()
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT DISTINCT c.*, (SELECT COUNT(v.IdCliente) FROM venda AS v WHERE v.IdCliente = c.Id) AS Quantidade
                                    FROM cliente AS c
                                    LEFT JOIN venda AS v ON (v.IdCliente = c.Id)
                                    WHERE c.Exclusao IS NULL
                                    ORDER BY c.NomeCompleto";
                conn.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion

        #region SelectById

        /// <summary>
        /// Lista um cliente por id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>DataTable com o cliente</returns>
        public DataTable SelectById(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM cliente WHERE Exclusao IS NULL AND Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion

        #region SelectByEmail

        /// <summary>
        /// Lista um cliente por e-mail
        /// </summary>
        /// <param name="email">E-mail do cliente</param>
        /// <returns>DataTable com o cliente</returns>
        public DataTable SelectByEmail(string email)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM cliente WHERE Exclusao IS NULL AND Email LIKE @email";
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion

        #endregion

        #region Insert

        /// <summary>
        /// Insere um produto
        /// </summary>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        public void Insert(string nomeCompleto, string email)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO cliente (NomeCompleto, Email) VALUES (@nomeCompleto, @email)";
                cmd.Parameters.AddWithValue("@nomeCompleto", nomeCompleto);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        public void Update(int id, string nomeCompleto, string email)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE cliente SET NomeCompleto = @nomeCompleto, Email = @email WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nomeCompleto", nomeCompleto);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE cliente SET Exclusao = NOW() WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        #endregion
    }
}