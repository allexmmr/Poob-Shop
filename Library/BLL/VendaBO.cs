using Library.DAL;
using System.Data;

namespace Library.BLL
{
    /// <summary>
    /// Venda Business Object
    /// </summary>
    public class VendaBO
    {
        #region Selects

        #region SelectByAll

        /// <summary>
        /// Lista todas as vendas
        /// </summary>
        /// <returns>DataTable com as vendas</returns>
        public DataTable SelectByAll()
        {
            VendaDAO dal = new VendaDAO();

            DataTable dt = dal.SelectByAll();

            return dt;
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
            VendaDAO dal = new VendaDAO();

            DataTable dt = dal.SelectById(id);

            return dt;
        }

        #endregion

        #region SelectByStatus

        /// <summary>
        /// Lista todos os status da venda
        /// </summary>
        /// <returns>DataTable com os status</returns>
        public DataTable SelectByStatus()
        {
            VendaDAO dal = new VendaDAO();

            DataTable dt = dal.SelectByStatus();

            return dt;
        }

        #endregion

        #region SelectByStatusId1e2

        /// <summary>
        /// Lista os status da venda com id 1 e 2
        /// </summary>
        /// <returns>DataTable com os status</returns>
        public DataTable SelectByStatusId1e2()
        {
            VendaDAO dal = new VendaDAO();

            DataTable dt = dal.SelectByStatusId1e2();

            return dt;
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
        public static void Insert(int idCliente, int idProduto, int idStatus, double valor, double frete, double desconto, int quantidade, bool mercadoLivre)
        {
            VendaDAO dal = new VendaDAO();
            dal.Insert(idCliente, idProduto, idStatus, valor, frete, desconto, quantidade, mercadoLivre);
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
        public static void Update(int id, int idStatus, double valor, double frete, double desconto, bool mercadoLivre, bool qualificado)
        {
            VendaDAO dal = new VendaDAO();
            dal.Update(id, idStatus, valor, frete, desconto, mercadoLivre, qualificado);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Exclui uma venda
        /// </summary>
        /// <param name="id">Id da venda</param>
        public static void Delete(int id)
        {
            VendaDAO dal = new VendaDAO();
            dal.Delete(id);
        }

        #endregion
    }
}