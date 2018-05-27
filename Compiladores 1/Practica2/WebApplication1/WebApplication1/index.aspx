<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>

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
        <%--</div>--%>
            <div>
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="Iniciar"  Text="Analizar" ForeColor="White" />
              <asp:Button ID="Button2" runat="server"  CssClass="Iniciar"  Text="Resultados" ForeColor="White" OnClick="Button2_Click" />
                
                <asp:FileUpload ID="FileUpload1" runat="server"  />
                <asp:Button ID="Button3" runat="server"  CssClass="Iniciar"  Text="Abrir" ForeColor="White" OnClick="Button3_Click" /> 
                <asp:Button ID="Button4" runat="server"  CssClass="Iniciar"  Text="Limpiar" ForeColor="White" OnClick="Button4_Click"  /> 
            </>
            <div>
        <asp:TextBox ID="cuerpo" runat="server" Height="1000px" TextMode="MultiLine" Width="100%" CssClass="Consola"></asp:TextBox>
         </div>
         <div>
        <asp:TextBox ID="errores" runat="server" Height="119px" TextMode="MultiLine" Width="100%" CssClass="Consola" ></asp:TextBox>
         </div>
    </form>
</body>
</html>
