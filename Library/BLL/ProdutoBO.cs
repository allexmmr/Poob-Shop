using Library.DAL;
using System.Data;

namespace Library.BLL
{
    /// <summary>
    /// Produto Business Object
    /// </summary>
    public class ProdutoBO
    {
        #region Selects

        #region SelectByAll

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>DataTable com os produtos</returns>
        public DataTable SelectByAll()
        {
            ProdutoDAO dal = new ProdutoDAO();

            DataTable dt = dal.SelectByAll();

            return dt;
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
            ProdutoDAO dal = new ProdutoDAO();

            DataTable dt = dal.SelectById(id);

            return dt;
        }

        #endregion

        #endregion

        #region Insert

        /// <summary>
        /// Insere um produto
        /// </summary>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="valor">Valor do produto</param>
        public static void Insert(string descricao, double valor)
        {
            ProdutoDAO dal = new ProdutoDAO();
            dal.Insert(descricao, valor);
        }

        #endregion

        #region Update

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="valor">Valor do produto</param>
        public static void Update(int id, string descricao, double valor)
        {
            ProdutoDAO dal = new ProdutoDAO();
            dal.Update(id, descricao, valor);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public static void Delete(int id)
        {
            ProdutoDAO dal = new ProdutoDAO();
            dal.Delete(id);
        }

        #endregion
    }
}