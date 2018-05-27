<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ClienteWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <link rel="stylesheet" href="css/style.css">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="EXP" OnClick="Button1_Click" CssClass="btn btn-2" />
            <asp:Button ID="Button2" runat="server" Text="AST" CssClass="btn btn-2" OnClick="Button2_Click" />
            <br />
        </div>
        <div class="marco">
            <asp:Image ID="Image1" runat="server" Height="100%" />

        </div>

    </form>
</body>
</html>
