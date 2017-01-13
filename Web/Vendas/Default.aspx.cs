using Library.BLL;
using Library.Common;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Web.Vendas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Força o fechamento da popup ao paginar o grid
            rwUpload.VisibleOnPageLoad = false;
            rwAttached.VisibleOnPageLoad = false;
        }

        #region Recebemos o seu pedido

        /// <summary>
        /// Envia o e-mail 'Recebemos o seu pedido'
        /// </summary>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="total">Valor total da venda</param>
        private void RecebemosSeuPedido(string nomeCompleto, string email, string descricao, double total)
        {
            #region Recebemos o seu pedido

            Mail mail = new Mail();

            // Criando o corpo do e-mail
            string mensagem = string.Empty;
            mensagem = "<html xmlns='http://www.w3.org/1999/xhtml'>";
            mensagem += "<head>";
            mensagem += "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />";
            mensagem += "<title>Poob Shop – " + descricao + " - Recebemos o seu pedido</title>";
            mensagem += "</head>";
            mensagem += "<body>";
            mensagem += "<table width='600px' cellpadding='0' cellspacing='0' align='center'>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Topo.jpg' alt='Topo' width='600px' height='79' border='0' usemap='#Map'>";
            mensagem += "<map name='Map'>";
            mensagem += "<area shape='rect' coords='31, 16, 152, 74' href='http://shop.poob.com.br' target='_blank' title='Poob Shop' alt='Poob Shop'>";
            mensagem += "<area shape='rect' coords='399, 17, 470, 38' href='http://shop.poob.com.br' target='_blank' title='Confira os nossos produtos' alt='Nossos Produtos'>";
            mensagem += "<area shape='rect' coords='485, 17, 572, 38' href='http://perfil.mercadolivre.com.br/POOBSHOP' target='_blank' title='Confira as nossas qualificações' alt='Nossas Qualificações'>";
            mensagem += "</map>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Banner.jpg' width='600' height='172' alt='Banner'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td style='padding: 10px; background-color: #c00102; border: 1px solid #000000; font-family: Arial; font-size: 12px; color: #FFFFFF; text-align: justify;'>";
            mensagem += "<strong>" + nomeCompleto + "</strong>,";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Obrigado por comprar <strong>" + descricao + "</strong> com a <a href='http://shop.poob.com.br' target='_blank' style='font-size: 13px; font-weight: bold; color: #FFFFFF; text-decoration: none;'>Poob Shop</a>!";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Caso tenha optado pagar pelo Mercado Pago, o pedido será enviado assim que o Mercado Livre confirmar o seu pagamento.";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<span style='color: #FFFFFF;'>►</span> Caso deseje efetuar o pagamento através de uma de nossas contas, os dados para depósito bancário ou transferência on-line são:";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Banco do Brasil (Conta Corrente):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 6971-X";
            mensagem += "<br />";
            mensagem += "Conta: 51747-X";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Caixa Econômica Federal (Conta Poupança):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 0820";
            mensagem += "<br />";
            mensagem += "Conta: 128-7";
            mensagem += "<br />";
            mensagem += "Operação: 013";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Banco Bradesco (Conta Corrente):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 0138-4";
            mensagem += "<br />";
            mensagem += "Conta: 0175809-8";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Banco Itaú (Conta Poupança):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 6330";
            mensagem += "<br />";
            mensagem += "Conta: 08384-8";
            mensagem += "<br />";
            mensagem += "Operação: 500";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Atenção:</strong> o valor para depósito bancário ou transferência on-line é de <strong>" + string.Format("{0:c}", total) + "</strong>.";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<span style='color: #FFFFFF;'>►</span> Após efetuar o depósito ou transferência, envie um e-mail para <a href='mailto: Poob Shop <shop@poob.com.br>?subject=Comprovante de Pagamento' style='color: #FFFFFF; text-decoration: none;'>shop@poob.com.br</a>, informando os seguintes dados:";
            mensagem += "<br />";
            mensagem += "- Banco depositado ou transferido: ";
            mensagem += "<br />";
            mensagem += "- Número do documento ou da transferência: ";
            mensagem += "<br />";
            mensagem += "- Valor depositado ou transferido: ";
            mensagem += "<br />";
            mensagem += "- Seu nome completo: ";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Formas-de-Pagamento.jpg' width='600' height='189' alt='Formas de Pagamento'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Rodape.jpg' width='600' height='77' alt='Rodapé'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "</table>";
            mensagem += "</body>";
            mensagem += "</html>";

            mail.SenderName = "Poob Shop";
            mail.SenderMail = "shop@poob.com.br";
            mail.Recipient = email;
            mail.Subject = "Recebemos o seu pedido";
            mail.Message = mensagem;

            try
            {
                mail.SendMail();
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }

            #endregion
        }

        #endregion

        #region Identificamos o seu pagamento

        /// <summary>
        /// Envia o e-mail 'Identificamos o seu pagamento'
        /// </summary>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="quantidade">Quantidade de venda</param>
        private void IdentificamosSeuPagamento(string nomeCompleto, string email, string descricao, int quantidade)
        {
            #region Identificamos o seu pagamento

            Mail mail = new Mail();

            // Criando o corpo do e-mail
            string mensagem = string.Empty;
            mensagem = "<html xmlns='http://www.w3.org/1999/xhtml'>";
            mensagem += "<head>";
            mensagem += "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />";
            mensagem += "<title>Poob Shop – " + descricao + " - Identificamos o seu pagamento</title>";
            mensagem += "</head>";
            mensagem += "<body>";
            mensagem += "<table width='600px' cellpadding='0' cellspacing='0' align='center'>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Topo.jpg' alt='Topo' width='600px' height='79' border='0' usemap='#Map'>";
            mensagem += "<map name='Map'>";
            mensagem += "<area shape='rect' coords='31, 16, 152, 74' href='http://shop.poob.com.br' target='_blank' title='Poob Shop' alt='Poob Shop'>";
            mensagem += "<area shape='rect' coords='399, 17, 470, 38' href='http://shop.poob.com.br' target='_blank' title='Confira os nossos produtos' alt='Nossos Produtos'>";
            mensagem += "<area shape='rect' coords='485, 17, 572, 38' href='http://perfil.mercadolivre.com.br/POOBSHOP' target='_blank' title='Confira as nossas qualificações' alt='Nossas Qualificações'>";
            mensagem += "</map>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Banner.jpg' width='600' height='172' alt='Banner'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td style='padding: 10px; background-color: #c00102; border: 1px solid #000000; font-family: Arial; font-size: 12px; color: #FFFFFF; text-align: justify;'>";
            mensagem += "<strong>" + nomeCompleto + "</strong>,";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Obrigado por comprar <strong>" + descricao + "</strong> com a <a href='http://shop.poob.com.br' target='_blank' style='font-size: 13px; font-weight: bold; color: #FFFFFF; text-decoration: none;'>Poob Shop</a>!";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Identificamos o seu pagamento, o seu jogador será comprado em breve.";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<span style='color: #FFFFFF;'>►</span> Liste um jogador, com duração de 3 dias e com valor de Comprar Já (Buy Now) no mesmo valor comprado em moedas. Depois me informe os seguintes dados:";
            mensagem += "<br />";
            mensagem += "- Nome do seu time no Ultimate Team: ";
            mensagem += "<br />";
            mensagem += "- Nome do jogador: ";
            mensagem += "<br />";
            mensagem += "- Pontuação geral do jogador (70, por exemplo): ";
            mensagem += "<br />";
            mensagem += "- Carta do jogador (ouro, prata ou bronze): ";
            mensagem += "<br />";
            mensagem += "- Clube do jogador: ";
            mensagem += "<br />";
            mensagem += "- Nacionalidade do jogador: ";
            mensagem += "<br />";
            // Verifica se a compra é menor que 13.500 coins
            mensagem += Convert.ToDouble(descricao.Substring(0, descricao.IndexOf(" "))) * quantidade < 13500 ? "- Preço inicial: 3.250" : "- Preço inicial: 13.250";
            mensagem += "<br />";
            mensagem += "- Comprar já: " + string.Format("{0:0,0}", Convert.ToDouble(descricao.Substring(0, descricao.IndexOf(" "))) * quantidade) + " (valor comprado)";
            mensagem += "<br />";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Formas-de-Pagamento.jpg' width='600' height='189' alt='Formas de Pagamento'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Rodape.jpg' width='600' height='77' alt='Rodapé'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "</table>";
            mensagem += "</body>";
            mensagem += "</html>";

            mail.SenderName = "Poob Shop";
            mail.SenderMail = "shop@poob.com.br";
            mail.Recipient = email;
            mail.Subject = "Identificamos o seu pagamento";
            mail.Message = mensagem;

            try
            {
                mail.SendMail();
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }

            #endregion
        }

        #endregion

        #region O seu pedido foi entregue

        /// <summary>
        /// Envia o e-mail 'O seu pedido foi entregue'
        /// </summary>
        /// <param name="idVenda">Id da venda</param>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="mercadoLivre">MercadoLivre</param>
        private void SeuPedidoFoiEntregue(int idVenda, string nomeCompleto, string email, string descricao, bool mercadoLivre)
        {
            #region O seu pedido foi entregue

            Mail mail = new Mail();

            // Criando o corpo do e-mail
            string mensagem = string.Empty;
            mensagem = "<html xmlns='http://www.w3.org/1999/xhtml'>";
            mensagem += "<head>";
            mensagem += "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />";
            mensagem += "<title>Poob Shop – " + descricao + " - O seu pedido foi entregue</title>";
            mensagem += "</head>";
            mensagem += "<body>";
            mensagem += "<table width='600px' cellpadding='0' cellspacing='0' align='center'>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Topo.jpg' alt='Topo' width='600px' height='79' border='0' usemap='#Map'>";
            mensagem += "<map name='Map'>";
            mensagem += "<area shape='rect' coords='31, 16, 152, 74' href='http://shop.poob.com.br' target='_blank' title='Poob Shop' alt='Poob Shop'>";
            mensagem += "<area shape='rect' coords='399, 17, 470, 38' href='http://shop.poob.com.br' target='_blank' title='Confira os nossos produtos' alt='Nossos Produtos'>";
            mensagem += "<area shape='rect' coords='485, 17, 572, 38' href='http://perfil.mercadolivre.com.br/POOBSHOP' target='_blank' title='Confira as nossas qualificações' alt='Nossas Qualificações'>";
            mensagem += "</map>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Banner.jpg' width='600' height='172' alt='Banner'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td style='padding: 10px; background-color: #c00102; border: 1px solid #000000; font-family: Arial; font-size: 12px; color: #FFFFFF; text-align: justify;'>";
            mensagem += "<strong>" + nomeCompleto + "</strong>,";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Obrigado por comprar <strong>" + descricao + "</strong> com a <a href='http://shop.poob.com.br' target='_blank' style='font-size: 13px; font-weight: bold; color: #FFFFFF; text-decoration: none;'>Poob Shop</a>!";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "O jogador acaba de ser comprado:";
            mensagem += "<br />";
            mensagem += "<img src='http://shop.poob.com.br/Images/Venda/" + idVenda + ".png' alt='Carta do Ultimate Team' width='300px' height='533' border='0'>";
            mensagem += "<br />";
            mensagem += "<br />";
            if (mercadoLivre)
            {
                mensagem += "Aguardo a sua qualificação positiva no MercadoLivre.";
                mensagem += "<br />";
                mensagem += "<br />";
            }
            mensagem += "Confira nossos produtos em <a href='http://shop.poob.com.br' target='_blank' style='font-size: 12px; font-weight: bold; color: #FFFFFF; text-decoration: none;'>shop.poob.com.br</a>.";
            mensagem += "<br />";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Formas-de-Pagamento.jpg' width='600' height='189' alt='Formas de Pagamento'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Rodape.jpg' width='600' height='77' alt='Rodapé'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "</table>";
            mensagem += "</body>";
            mensagem += "</html>";

            mail.SenderName = "Poob Shop";
            mail.SenderMail = "shop@poob.com.br";
            mail.Recipient = email;
            mail.Subject = "O seu pedido foi entregue";
            mail.Message = mensagem;

            try
            {
                mail.SendMail();
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }

            #endregion
        }

        #endregion

        #region Ainda não identificamos o seu pagamento

        /// <summary>
        /// Envia o e-mail 'Ainda não identificamos o seu pagamento'
        /// </summary>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="total">Valor total da venda</param>
        private void AindaNaoIdentificamosSeuPagamento(string nomeCompleto, string email, string descricao, double total)
        {
            #region Ainda não identificamos o seu pagamento

            Mail mail = new Mail();

            // Criando o corpo do e-mail
            string mensagem = string.Empty;
            mensagem = "<html xmlns='http://www.w3.org/1999/xhtml'>";
            mensagem += "<head>";
            mensagem += "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />";
            mensagem += "<title>Poob Shop – " + descricao + " - Ainda não identificamos o seu pagamento</title>";
            mensagem += "</head>";
            mensagem += "<body>";
            mensagem += "<table width='600px' cellpadding='0' cellspacing='0' align='center'>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Topo.jpg' alt='Topo' width='600px' height='79' border='0' usemap='#Map'>";
            mensagem += "<map name='Map'>";
            mensagem += "<area shape='rect' coords='31, 16, 152, 74' href='http://shop.poob.com.br' target='_blank' title='Poob Shop' alt='Poob Shop'>";
            mensagem += "<area shape='rect' coords='399, 17, 470, 38' href='http://shop.poob.com.br' target='_blank' title='Confira os nossos produtos' alt='Nossos Produtos'>";
            mensagem += "<area shape='rect' coords='485, 17, 572, 38' href='http://perfil.mercadolivre.com.br/POOBSHOP' target='_blank' title='Confira as nossas qualificações' alt='Nossas Qualificações'>";
            mensagem += "</map>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Banner.jpg' width='600' height='172' alt='Banner'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td style='padding: 10px; background-color: #c00102; border: 1px solid #000000; font-family: Arial; font-size: 12px; color: #FFFFFF; text-align: justify;'>";
            mensagem += "<strong>" + nomeCompleto + "</strong>,";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Ainda não identificamos o seu pagamento referente a <strong>" + descricao + "</strong>.";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Caso tenha optado pagar pelo Mercado Pago, refaça o seu pagamento, pois o seu cartão de crédito pode ter sido recusado.";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<span style='color: #FFFFFF;'>►</span> Caso deseje efetuar o pagamento através de uma de nossas contas, os dados para depósito bancário ou transferência on-line são:";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Banco do Brasil (Conta Corrente):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 6971-X";
            mensagem += "<br />";
            mensagem += "Conta: 51747-X";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Caixa Econômica Federal (Conta Poupança):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 0820";
            mensagem += "<br />";
            mensagem += "Conta: 128-7";
            mensagem += "<br />";
            mensagem += "Operação: 013";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Banco Bradesco (Conta Corrente):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 0138-4";
            mensagem += "<br />";
            mensagem += "Conta: 0175809-8";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Banco Itaú (Conta Poupança):</strong>";
            mensagem += "<br />";
            mensagem += "Agência: 6330";
            mensagem += "<br />";
            mensagem += "Conta: 08384-8";
            mensagem += "<br />";
            mensagem += "Operação: 500";
            mensagem += "<br />";
            mensagem += "Favorecido: Allex Motta Melo da Rocha";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<strong>Atenção:</strong> o valor para depósito bancário ou transferência on-line é de <strong>" + string.Format("{0:c}", total) + "</strong>.";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "<span style='color: #FFFFFF;'>►</span> Após efetuar o depósito ou transferência, envie um e-mail para <a href='mailto: Poob Shop <shop@poob.com.br>?subject=Comprovante de Pagamento' style='color: #FFFFFF; text-decoration: none;'>shop@poob.com.br</a>, informando os seguintes dados:";
            mensagem += "<br />";
            mensagem += "- Banco depositado ou transferido: ";
            mensagem += "<br />";
            mensagem += "- Número do documento ou da transferência: ";
            mensagem += "<br />";
            mensagem += "- Valor depositado ou transferido: ";
            mensagem += "<br />";
            mensagem += "- Seu nome completo: ";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Formas-de-Pagamento.jpg' width='600' height='189' alt='Formas de Pagamento'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Recebemos-o-seu-pedido/Rodape.jpg' width='600' height='77' alt='Rodapé'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "</table>";
            mensagem += "</body>";
            mensagem += "</html>";

            mail.SenderName = "Poob Shop";
            mail.SenderMail = "shop@poob.com.br";
            mail.Recipient = email;
            mail.Subject = "Ainda não identificamos o seu pagamento";
            mail.Message = mensagem;

            try
            {
                mail.SendMail();
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }

            #endregion
        }

        #endregion

        #region Ainda não recebemos a sua qualificação

        /// <summary>
        /// Envia o e-mail 'Ainda não recebemos a sua qualificação'
        /// </summary>
        /// <param name="nomeCompleto">Nome completo do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <param name="descricao">Descrição do produto</param>
        private void AindaNaoRecebemosSuaQualificacao(string nomeCompleto, string email, string descricao)
        {
            #region Ainda não recebemos a sua qualificação

            Mail mail = new Mail();

            // Criando o corpo do e-mail
            string mensagem = string.Empty;
            mensagem = "<html xmlns='http://www.w3.org/1999/xhtml'>";
            mensagem += "<head>";
            mensagem += "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />";
            mensagem += "<title>Poob Shop – " + descricao + " - Ainda não recebemos a sua qualificação</title>";
            mensagem += "</head>";
            mensagem += "<body>";
            mensagem += "<table width='600px' cellpadding='0' cellspacing='0' align='center'>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Topo.jpg' alt='Topo' width='600px' height='79' border='0' usemap='#Map'>";
            mensagem += "<map name='Map'>";
            mensagem += "<area shape='rect' coords='31, 16, 152, 74' href='http://shop.poob.com.br' target='_blank' title='Poob Shop' alt='Poob Shop'>";
            mensagem += "<area shape='rect' coords='399, 17, 470, 38' href='http://shop.poob.com.br' target='_blank' title='Confira os nossos produtos' alt='Nossos Produtos'>";
            mensagem += "<area shape='rect' coords='485, 17, 572, 38' href='http://perfil.mercadolivre.com.br/POOBSHOP' target='_blank' title='Confira as nossas qualificações' alt='Nossas Qualificações'>";
            mensagem += "</map>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Banner.jpg' width='600' height='172' alt='Banner'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td style='padding: 10px; background-color: #c00102; border: 1px solid #000000; font-family: Arial; font-size: 12px; color: #FFFFFF; text-align: justify;'>";
            mensagem += "<strong>" + nomeCompleto + "</strong>,";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Recentemente você comprou <strong>" + descricao + "</strong> com a <a href='http://shop.poob.com.br' target='_blank' style='font-size: 13px; font-weight: bold; color: #FFFFFF; text-decoration: none;'>Poob Shop</a>!";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Verificamos no sistema que você ainda não nos qualificou.";
            mensagem += "<br />";
            mensagem += "<a href='https://myaccount.mercadolivre.com.br/purchases/list' target='_blank' style='font-size: 16px; font-weight: bold; color: #FFFFFF; text-decoration: none;'>Clique e nos qualifique agora mesmo!</a>";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Peço que nos qualifique o mais breve possível, pois temos os menores preços do MercadoLivre. Nos ajude a manter esses preços!";
            mensagem += "<br />";
            mensagem += "<br />";
            mensagem += "Mais uma vez, obrigado por comprar com a <a href='http://shop.poob.com.br' target='_blank' style='font-size: 13px; font-weight: bold; color: #FFFFFF; text-decoration: none;'>Poob Shop</a>.";
            mensagem += "<br />";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Formas-de-Pagamento.jpg' width='600' height='189' alt='Formas de Pagamento'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "<tr>";
            mensagem += "<td>";
            mensagem += "<img src='http://email.poob.com.br/Coins-Fifa-15-Ultimate-Team-PS3-e-PS4/Identificamos-o-seu-pagamento/Rodape.jpg' width='600' height='77' alt='Rodapé'>";
            mensagem += "</td>";
            mensagem += "</tr>";
            mensagem += "</table>";
            mensagem += "</body>";
            mensagem += "</html>";

            mail.SenderName = "Poob Shop";
            mail.SenderMail = "shop@poob.com.br";
            mail.Recipient = email;
            mail.Subject = "Ainda não recebemos a sua qualificação";
            mail.Message = mensagem;

            try
            {
                mail.SendMail();
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }

            #endregion
        }

        #endregion

        #region btnExportarParaExcel_Click

        protected void btnExportarParaExcel_Click(object sender, EventArgs e)
        {
            // Oculta as colunas de edição e exclusão
            RadGrid1.MasterTableView.GetColumn("EditColumn").Visible = false;
            RadGrid1.MasterTableView.GetColumn("DeleteColumn").Visible = false;

            // Configura a exportação
            RadGrid1.ExportSettings.FileName = "Vendas";
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;

            // Exporta para Excel
            RadGrid1.MasterTableView.ExportToExcel();
        }

        #endregion

        #region btnExportarParaPDF_Click

        protected void btnExportarParaPDF_Click(object sender, EventArgs e)
        {
            // Oculta as colunas de edição e exclusão
            RadGrid1.MasterTableView.GetColumn("EditColumn").Visible = false;
            RadGrid1.MasterTableView.GetColumn("DeleteColumn").Visible = false;

            // Configura a exportação
            RadGrid1.ExportSettings.FileName = "Vendas";
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;

            // Exporta para PDF
            RadGrid1.MasterTableView.ExportToPdf();
        }

        #endregion

        #region RadGrid1_ItemDataBound

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                if (File.Exists(Server.MapPath(string.Format("~/Images/Venda/{0}.png", item.GetDataKeyValue("Id")))))
                {
                    ImageButton btnAttach = (ImageButton)e.Item.FindControl("btnAttach");
                    btnAttach.ToolTip = "Visualizar";
                }
            }
        }

        #endregion

        #region RadGrid1_BatchEditCommand

        protected void RadGrid1_BatchEditCommand(object sender, GridBatchEditingEventArgs e)
        {
            foreach (GridBatchEditingCommand command in e.Commands)
            {
                if ((command.Type == GridBatchEditingCommandType.Update))
                {
                    Hashtable oldValues = command.OldValues;
                    Hashtable newValues = command.NewValues;

                    try
                    {
                        // Verifica se a compra não foi realizada pelo MercadoLivre
                        if (newValues["MercadoLivre"].ToString() == "0")
                        {
                            newValues["Qualificado"] = "0";
                        }

                        // Recebe os dados inicial da venda
                        VendaBO venda = new VendaBO();
                        DataTable dtVendaInicial = venda.SelectById(Convert.ToInt32(oldValues["Id"]));

                        // Atualiza a venda
                        VendaBO.Update(Convert.ToInt32(oldValues["Id"]), Convert.ToInt32(newValues["Status"]), Convert.ToDouble(newValues["Valor"]), Convert.ToDouble(newValues["Frete"]), Convert.ToDouble(newValues["Desconto"]), newValues["MercadoLivre"].ToString() == "1" ? true : false, newValues["Qualificado"].ToString() == "1" ? true : false);

                        // Recebe os dados atualizados da venda
                        DataTable dtVenda = venda.SelectById(Convert.ToInt32(oldValues["Id"]));

                        // Verifica se houve mudança no status da venda
                        if (dtVendaInicial.Rows[0]["Status"].ToString() != dtVenda.Rows[0]["Status"].ToString())
                        {
                            // Envia o e-mail para o cliente
                            switch (Convert.ToInt32(newValues["Status"]))
                            {
                                // Pagamento Recebido
                                case 2: IdentificamosSeuPagamento(dtVenda.Rows[0]["NomeCompleto"].ToString(), dtVenda.Rows[0]["Email"].ToString(), dtVenda.Rows[0]["Descricao"].ToString(), Convert.ToInt32(dtVenda.Rows[0]["Quantidade"]));
                                    break;
                                // Pagamento Recusado
                                case 3: AindaNaoIdentificamosSeuPagamento(dtVenda.Rows[0]["NomeCompleto"].ToString(), dtVenda.Rows[0]["Email"].ToString(), dtVenda.Rows[0]["Descricao"].ToString(), (Convert.ToInt32(dtVenda.Rows[0]["Quantidade"]) * Convert.ToDouble(dtVenda.Rows[0]["Valor"])) + Convert.ToDouble(dtVenda.Rows[0]["Frete"]));
                                    break;
                                // Pedido Entregue
                                case 4: SeuPedidoFoiEntregue(Convert.ToInt32(oldValues["Id"]), dtVenda.Rows[0]["NomeCompleto"].ToString(), dtVenda.Rows[0]["Email"].ToString(), dtVenda.Rows[0]["Descricao"].ToString(), dtVenda.Rows[0]["MercadoLivre"].ToString() == "Sim" ? true : false);
                                    break;
                            }
                        }

                        // Verifica se o pedido foi entregue, se a compra foi realizada pelo MercadoLivre e se ainda não foi qualificada
                        if (newValues["Status"].ToString() == "4" && newValues["MercadoLivre"].ToString() == "1" && newValues["Qualificado"].ToString() == "0")
                        {
                            // Ainda não recebemos a sua qualificação
                            AindaNaoRecebemosSuaQualificacao(dtVenda.Rows[0]["NomeCompleto"].ToString(), dtVenda.Rows[0]["Email"].ToString(), dtVenda.Rows[0]["Descricao"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
                    }
                }
            }
        }

        #endregion

        #region btnSave_Click

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeCompleto.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                try
                {
                    // Verifica se o cliente já existe na base
                    ClienteBO cliente = new ClienteBO();
                    DataTable dtCliente = cliente.SelectByEmail(txtEmail.Text.Replace(";", "").Trim());

                    // Se não existir, insere o cliente
                    if (dtCliente.Rows.Count == 0)
                    {
                        ClienteBO.Insert(txtNomeCompleto.Text.Replace(";", "").Trim(), txtEmail.Text.Replace(";", "").Trim());
                        dtCliente = cliente.SelectByEmail(txtEmail.Text.Replace(";", "").Trim());
                    }

                    // Recebe os dados do produto
                    ProdutoBO produto = new ProdutoBO();
                    DataTable dtProduto = produto.SelectById(Convert.ToInt32(ddlProduto.SelectedValue));

                    // Insere a venda
                    VendaBO.Insert(Convert.ToInt32(dtCliente.Rows[0]["Id"]), Convert.ToInt32(ddlProduto.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue), Convert.ToDouble(dtProduto.Rows[0]["Valor"]), Convert.ToDouble(txtFrete.Value), Convert.ToDouble(txtDesconto.Value), Convert.ToInt32(txtQuantidade.Value), chkMercadoLivre.Checked);

                    // Envia o e-mail para o cliente
                    switch (Convert.ToInt32(ddlStatus.SelectedValue))
                    {
                        // Pagamento a Combinar
                        case 1: RecebemosSeuPedido(dtCliente.Rows[0]["NomeCompleto"].ToString(), dtCliente.Rows[0]["Email"].ToString(), ddlProduto.SelectedText + " (" + txtQuantidade.Text + "x)", (Convert.ToInt32(txtQuantidade.Value) * Convert.ToDouble(dtProduto.Rows[0]["Valor"])) + Convert.ToDouble(txtFrete.Value));
                            break;
                        // Pagamento Recebido
                        case 2: IdentificamosSeuPagamento(dtCliente.Rows[0]["NomeCompleto"].ToString(), dtCliente.Rows[0]["Email"].ToString(), ddlProduto.SelectedText + " (" + txtQuantidade.Text + "x)", Convert.ToInt32(txtQuantidade.Value));
                            break;
                    }

                    #region Limpa os dados da venda

                    txtNomeCompleto.Entries.Clear();
                    txtEmail.Entries.Clear();
                    ddlProduto.SelectedIndex = 6;
                    txtQuantidade.Value = 1;
                    txtFrete.Value = 0;
                    ddlStatus.SelectedIndex = 0;
                    chkMercadoLivre.Checked = true;

                    // Recebe os dados do produto
                    dtProduto = produto.SelectById(7);

                    // Calcula 16% de desconto da tarifa de venda do MercadoLivre
                    double desconto = Convert.ToDouble(dtProduto.Rows[0]["Valor"]) * Convert.ToDouble(0.16);
                    txtDesconto.Value = desconto;

                    #endregion

                    // Atualiza o grid
                    RadGrid1.MasterTableView.Rebind();
                }
                catch (Exception ex)
                {
                    RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
                }
            }
            else
            {
                RadWindowManager1.RadAlert("Por favor, preencha o nome completo e o e-mail do cliente.", 300, 150, "Mensagem", null);
            }
        }

        #endregion

        #region ddlProduto_DataBound

        protected void ddlProduto_DataBound(object sender, EventArgs e)
        {
            // Recebe os dados do produto
            ProdutoBO produto = new ProdutoBO();
            DataTable dtProduto = produto.SelectById(7);

            // Calcula 16% de desconto da tarifa de venda do MercadoLivre
            double desconto = Convert.ToDouble(dtProduto.Rows[0]["Valor"]) * Convert.ToDouble(0.16);
            txtDesconto.Value = desconto;

            // 530.000 Coins Fifa 15 Ultimate Team PS3 e PS4
            ddlProduto.SelectedIndex = 6;
        }

        #endregion

        #region ddlProduto_SelectedIndexChanged

        protected void ddlProduto_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            // Recebe os dados do produto
            ProdutoBO produto = new ProdutoBO();
            DataTable dtProduto = produto.SelectById(Convert.ToInt32(ddlProduto.SelectedValue));

            // Calcula 16% de desconto da tarifa de venda do MercadoLivre
            double desconto = Convert.ToDouble(dtProduto.Rows[0]["Valor"]) * Convert.ToDouble(0.16);
            txtDesconto.Value = desconto;
        }

        #endregion

        #region chkMercadoLivre_CheckedChanged

        protected void chkMercadoLivre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMercadoLivre.Checked)
            {
                // Recebe os dados do produto
                ProdutoBO produto = new ProdutoBO();
                DataTable dtProduto = produto.SelectById(Convert.ToInt32(ddlProduto.SelectedValue));

                // Calcula 16% de desconto da tarifa de venda do MercadoLivre
                double desconto = Convert.ToDouble(dtProduto.Rows[0]["Valor"]) * Convert.ToDouble(0.16);
                txtDesconto.Value = desconto;
            }
            else
            {
                txtDesconto.Text = "0";
            }
        }

        #endregion

        #region btnAttach_Click

        protected void btnAttach_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                ImageButton btnAttach = sender as ImageButton;
                Session["IdVenda"] = btnAttach.CommandArgument;

                if (File.Exists(Server.MapPath(string.Format("~/Images/Venda/{0}.png", Session["IdVenda"]))))
                {
                    rwUpload.VisibleOnPageLoad = false;
                    rwAttached.VisibleOnPageLoad = true;
                    imgAttached.ImageUrl = string.Format("~/Images/Venda/{0}.png", Session["IdVenda"]);
                }
                else
                {
                    rwUpload.VisibleOnPageLoad = true;
                    rwAttached.VisibleOnPageLoad = false;
                }
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }
        }

        #endregion

        #region btnUpload_Click

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (UploadedFile upload in RadAsyncUpload1.UploadedFiles)
                {
                    upload.SaveAs(Server.MapPath(string.Format("~/Images/Venda/{0}.png", Session["IdVenda"])), true);
                }
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }
            finally
            {
                Session["IdVenda"] = string.Empty;
            }
        }

        #endregion

        #region btnMail_Click

        protected void btnMail_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                ImageButton btnMail = sender as ImageButton;

                // Recebe os dados da venda
                VendaBO venda = new VendaBO();
                DataTable dtVenda = venda.SelectById(Convert.ToInt32(btnMail.CommandArgument));

                // Pagamento Recebido
                if (dtVenda.Rows[0]["Status"].ToString() == "Pagamento Recebido")
                {
                    IdentificamosSeuPagamento(dtVenda.Rows[0]["NomeCompleto"].ToString(), dtVenda.Rows[0]["Email"].ToString(), dtVenda.Rows[0]["Descricao"].ToString(), Convert.ToInt32(dtVenda.Rows[0]["Quantidade"]));
                }

                // Pagamento Recusado
                if (dtVenda.Rows[0]["Status"].ToString() == "Pagamento Recusado")
                {
                    AindaNaoIdentificamosSeuPagamento(dtVenda.Rows[0]["NomeCompleto"].ToString(), dtVenda.Rows[0]["Email"].ToString(), dtVenda.Rows[0]["Descricao"].ToString(), (Convert.ToInt32(dtVenda.Rows[0]["Quantidade"]) * Convert.ToDouble(dtVenda.Rows[0]["Valor"])) + Convert.ToDouble(dtVenda.Rows[0]["Frete"]));
                }

                // Pedido Entregue
                if (dtVenda.Rows[0]["Status"].ToString() == "Pedido Entregue")
                {
                    // Verifica se a compra foi realizada pelo MercadoLivre e se ainda não foi qualificada
                    if (dtVenda.Rows[0]["MercadoLivre"].ToString() == "Sim" && dtVenda.Rows[0]["Qualificado"].ToString() == "Não")
                    {
                        AindaNaoRecebemosSuaQualificacao(dtVenda.Rows[0]["NomeCompleto"].ToString(), dtVenda.Rows[0]["Email"].ToString(), dtVenda.Rows[0]["Descricao"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }
        }

        #endregion
    }
}