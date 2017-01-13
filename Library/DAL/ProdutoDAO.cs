using Library.BLL;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Library.DAL
{
    /// <summary>
    /// Produto Data Access Object
    /// </summary>
    public class ProdutoDAO
    {
        #region Selects

        #region SelectByAll

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>DataTable com os produtos</returns>
        public DataTable SelectByAll()
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT DISTINCT p.*, (SELECT COUNT(v.IdProduto) FROM venda AS v WHERE v.IdProduto = p.Id) AS Quantidade
                                    FROM produto AS p
                                    LEFT JOIN venda AS v ON (v.IdProduto = p.Id)
                                    WHERE p.Exclusao IS NULL";
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
        /// Lista um produto por id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>DataTable com o produto</returns>
        public DataTable SelectById(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM produto WHERE Exclusao IS NULL AND Id = @id";
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

        #endregion

        #region Insert

        /// <summary>
        /// Insere um produto
        /// </summary>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="valor">Valor do produto</param>
        public void Insert(string descricao, double valor)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO produto (Descricao, Valor) VALUES (@descricao, @valor)";
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@valor", valor.ToString().Replace(",", "."));
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
        /// Atualiza um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="valor">Valor do produto</param>
        public void Update(int id, string descricao, double valor)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE produto SET Descricao = @descricao, Valor = @valor WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@valor", valor.ToString().Replace(",", "."));
                conn.Open();
                cmd.ExecuteNonQuery();

                // Recebe os dados do produto
                ProdutoBO produto = new ProdutoBO();
                DataTable dtProduto = produto.SelectById(1);

                cmd.CommandText = @"UPDATE produto SET Valor = @valorBase *   5 WHERE Id =  2;
                                    UPDATE produto SET Valor = @valorBase *  10 WHERE Id =  3;
                                    UPDATE produto SET Valor = @valorBase *  20 WHERE Id =  4;
                                    UPDATE produto SET Valor = @valorBase *  30 WHERE Id =  5;
                                    UPDATE produto SET Valor = @valorBase *  40 WHERE Id =  6;
                                    UPDATE produto SET Valor = @valorBase *  50 WHERE Id =  7;
                                    UPDATE produto SET Valor = @valorBase * 100 WHERE Id =  8;
                                    UPDATE produto SET Valor = @valorBase * 200 WHERE Id =  9;
                                    UPDATE produto SET Valor = @valorBase * 300 WHERE Id = 10;
                                    UPDATE produto SET Valor = @valorBase * 300 WHERE Id = 11;
                                    UPDATE produto SET Valor = @valorBase * 500 WHERE Id = 12;";
                cmd.Parameters.AddWithValue("@valorBase", dtProduto.Rows[0]["Valor"].ToString().Replace(",", "."));
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
        /// Exclui um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE produto SET Exclusao = NOW() WHERE Id = @id";
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