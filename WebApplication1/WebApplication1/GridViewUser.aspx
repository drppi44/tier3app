<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewUser.aspx.cs" Inherits="WebApplication1.GridViewUser" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>

    <div id="menu">
        <a href="/gridviewlist.aspx">books</a>
        <a href="/gridviewuser.aspx">users</a>
        <a href="/gridviewhistory.aspx">history</a>
    </div>

    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="tbName" placeholder="User name">
        </asp:TextBox>
        <asp:TextBox runat="server" ID="tbEmail" placeholder="User email">
        </asp:TextBox>
        <asp:Button runat="server" OnClick="BtAddPeople" Text="+" Width="22px" />
        <hr />
        
        
    
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />


        </asp:GridView>
    
    </div>
    </form>
</body>
</html>