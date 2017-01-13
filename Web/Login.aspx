﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Início das meta tags -->
    <meta name="title" content="Poob Shop" />
    <meta name="description" content="Preços baixos e ótimas ofertas de vídeo-games, jogos, câmeras digitais e mais, tudo a pronta entrega na Poob Shop. Compre já!" />
    <meta name="abstract" content="Preços baixos e ótimas ofertas de vídeo-games, jogos, câmeras digitais e mais, tudo a pronta entrega na Poob Shop. Compre já!" />
    <meta name="keywords" content="Poob Shop, Preços baixos, Barato, Vídeo-games, Jogos, Acessórios para PlayStation, Câmeras digitais" />
    <meta name="rating" content="general" />
    <meta name="author" content="Poob Shop; Allex Rocha" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Fim das meta tags -->
    <title>Poob Shop – Log In</title>
    <!-- Favicon -->
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <!-- Início do código do Google Analytics -->
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-43031323-1', 'auto');
        ga('send', 'pageview');
    </script>
    <!-- Fim do código do Google Analytics -->
    <style>
        body {
            margin: 0;
            left: 50%;
            top: 50%;
            margin-left: -152px;
            margin-top: -84px;
            background-color: rgba(37, 160, 218, .3);
            position: absolute;
        }

        .padding {
            padding: 5px 0px 5px 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="Login1" RememberMeSet="True" OnAuthenticate="Login1_Authenticate" runat="server" UserNameLabelText="E-mail:" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Medium" ForeColor="#333333" FailureText="Sua tentativa de login não foi bem sucedida.&lt;br /&gt;Por favor, tente novamente." LoginButtonText="Entrar" PasswordLabelText="Senha:" PasswordRequiredErrorMessage="Senha requerida." RememberMeText="Lembre-se de mim na próxima vez." UserNameRequiredErrorMessage="E-mail requerido.">
                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="Large" ForeColor="White" Font-Names="Arial" CssClass="padding" />
                <TextBoxStyle Font-Size="Medium" />
                <FailureTextStyle Font-Size="Small" ForeColor="Red" />
                <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Medium" ForeColor="#284E98" />
            </asp:Login>
        </div>
    </form>
</body>
</html>