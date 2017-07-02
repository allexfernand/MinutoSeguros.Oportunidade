<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetWords.aspx.cs" Inherits="MinutoSeguros.Oportunidade.UI.GetWords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnGetWords" runat="server" Text="Get Words" OnClick="BtnGetWords_Click" />
    </div>
        <div>
            <br />
            <asp:GridView ID="GViewResult" runat="server"></asp:GridView>

        </div>
        <div style="float:left;">
            <br />
            <asp:GridView ID="GViewTopics" runat="server"></asp:GridView>

        </div>
    </form>
</body>
</html>
