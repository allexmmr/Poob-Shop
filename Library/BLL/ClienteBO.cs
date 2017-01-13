using Library.DAL;
using System.Data;

namespace Library.BLL
{
    /// <summary>
    /// Cliente Business Object
    /// </summary>
    public class ClienteBO
    {
        #region Selects

        #region SelectByAll

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>DataTable com os clientes</returns>
        public DataTable SelectByAll()
        {
            ClienteDAO dal = new ClienteDAO();

            DataTable dt = dal.SelectByAll();

            return dt;
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
            ClienteDAO dal = new ClienteDAO();

            DataTable dt = dal.SelectById(id);

            return dt;
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
            ClienteDAO dal = new ClienteDAO();

            DataTable dt = dal.SelectByEmail(email);

            return dt;
        }

        #endregion

        #endregion

        #region Insert

        /// <summary>
        /// Insere um cliente
        /// </summary>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        public static void Insert(string nomeCompleto, string email)
        {
            ClienteDAO dal = new ClienteDAO();
            dal.Insert(nomeCompleto, email);
        }

        #endregion

        #region Update

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        public static void Update(int id, string nomeCompleto, string email)
        {
            ClienteDAO dal = new ClienteDAO();
            dal.Update(id, nomeCompleto, email);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        /// <param name="id">Id do cliente</param>
        public static void Delete(int id)
        {
            ClienteDAO dal = new ClienteDAO();
            dal.Delete(id);
        }

        #endregion
    }
}