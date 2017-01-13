using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Library.DAL
{
    /// <summary>
    /// Venda Data Access Object
    /// </summary>
    public class VendaDAO
    {
        #region Selects

        #region SelectByAll

        /// <summary>
        /// Lista todas as vendas
        /// </summary>
        /// <returns>DataTable com as vendas</returns>
        public DataTable SelectByAll()
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT v.Id, v.Cadastro, c.NomeCompleto, c.Email, CONVERT(CONCAT(p.Descricao, ' (', v.Quantidade, 'x)') USING utf8) AS Descricao, v.Quantidade, v.Valor, v.Frete, v.Desconto, (((v.Valor * v.Quantidade) + v.Frete) - (v.Desconto * v.Quantidade)) AS Total, CASE v.MercadoLivre WHEN 1 THEN 'Sim' WHEN 0 THEN 'Não' END AS MercadoLivre, CASE v.Qualificado WHEN 1 THEN 'Sim' WHEN 0 THEN 'Não' END AS Qualificado, s.Descricao AS Status
                                    FROM venda AS v
                                    INNER JOIN cliente AS c ON (c.Id = v.IdCliente)
                                    INNER JOIN produto AS p ON (p.Id = v.IdProduto)
                                    INNER JOIN status AS s ON (s.Id = v.IdStatus)
                                    WHERE v.Exclusao IS NULL
                                    ORDER BY v.Id DESC";
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
        /// Lista uma venda por id
        /// </summary>
        /// <param name="id">Id da venda</param>
        /// <returns>DataTable com a venda</returns>
        public DataTable SelectById(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT v.Id, v.Cadastro, c.NomeCompleto, c.Email, CONVERT(CONCAT(p.Descricao, ' (', v.Quantidade, 'x)') USING utf8) AS Descricao, v.Quantidade, v.Valor, v.Frete, v.Desconto, (((v.Valor * v.Quantidade) + v.Frete) - (v.Desconto * v.Quantidade)) AS Total, CASE v.MercadoLivre WHEN 1 THEN 'Sim' WHEN 0 THEN 'Não' END AS MercadoLivre, CASE v.Qualificado WHEN 1 THEN 'Sim' WHEN 0 THEN 'Não' END AS Qualificado, s.Descricao AS Status
                                    FROM venda AS v
                                    INNER JOIN cliente AS c ON (c.Id = v.IdCliente)
                                    INNER JOIN produto AS p ON (p.Id = v.IdProduto)
                                    INNER JOIN status AS s ON (s.Id = v.IdStatus)
                                    WHERE v.Exclusao IS NULL AND v.Id = @id";
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

        #region SelectByStatus

        /// <summary>
        /// Lista todos os status da venda
        /// </summary>
        /// <returns>DataTable com os status</returns>
        public DataTable SelectByStatus()
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM status";
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

        #region SelectByStatusId1e2

        /// <summary>
        /// Lista os status da venda com id 1 e 2
        /// </summary>
        /// <returns>DataTable com os status</returns>
        public DataTable SelectByStatusId1e2()
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM status WHERE Id IN (1, 2)";
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
        /// Insere uma venda
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <param name="idProduto">Id do produto</param>
        /// <param name="idStatus">Id do status da venda</param>
        /// <param name="valor">Valor da venda</param>
        /// <param name="frete">Valor do frete</param>
        /// <param name="desconto">Valor do desconto</param>
        /// <param name="quantidade">Quantidade de venda</param>
        /// <param name="mercadoLivre">MercadoLivre</param>
        public void Insert(int idCliente, int idProduto, int idStatus, double valor, double frete, double desconto, int quantidade, bool mercadoLivre)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO venda (IdCliente, IdProduto, IdStatus, Valor, Frete, Desconto, Quantidade, MercadoLivre, Qualificado) VALUES (@idCliente, @idProduto, @idStatus, @valor, @frete, @desconto, @quantidade, @mercadoLivre, @qualificado)";
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idProduto", idProduto);
                cmd.Parameters.AddWithValue("@idStatus", idStatus);
                cmd.Parameters.AddWithValue("@valor", valor.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@frete", frete.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@desconto", desconto.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@mercadoLivre", mercadoLivre);
                cmd.Parameters.AddWithValue("@qualificado", false);
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
        /// Atualiza uma venda
        /// </summary>
        /// <param name="id">Id da venda</param>
        /// <param name="idStatus">Id do status da venda</param>
        /// <param name="valor">Valor da venda</param>
        /// <param name="frete">Valor do frete</param>
        /// <param name="desconto">Valor do desconto</param>
        /// <param name="mercadoLivre">MercadoLivre</param>
        /// <param name="qualificado">Qualificado</param>
        public void Update(int id, int idStatus, double valor, double frete, double desconto, bool mercadoLivre, bool qualificado)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE venda SET IdStatus = @idStatus, Valor = @valor, Frete = @frete, Desconto = @desconto, MercadoLivre = @mercadoLivre, Qualificado = @qualificado WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idStatus", idStatus);
                cmd.Parameters.AddWithValue("@valor", valor.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@frete", frete.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@desconto", desconto.ToString().Replace(",", "."));
                cmd.Parameters.AddWithValue("@mercadoLivre", mercadoLivre);
                cmd.Parameters.AddWithValue("@qualificado", qualificado);
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
        /// Exclui uma venda
        /// </summary>
        /// <param name="id">Id da venda</param>
        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PoobShop"].ConnectionString;
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE venda SET Exclusao = NOW() WHERE Id = @id";
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