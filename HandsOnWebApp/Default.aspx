<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandsOnWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="70" MaxLength="5"></asp:TextBox> +
            <asp:TextBox ID="TextBox2" runat="server" Width="70" MaxLength="5"></asp:TextBox> =
            <asp:Label ID="Label1" runat="server" ></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Text="計算" OnClick="Button1_Click" />
        </div>
        <div>
            計算履歴
            <asp:Button ID="Button2" runat="server" Text="消去" OnClick="Button2_Click" />
            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <%# HttpUtility.HtmlEncode(string.Format("{0} + {1} = {2}", Eval("v1"), Eval("v2"), Eval("sum"))) %>
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:handsondb %>"
                SelectCommand="SELECT * FROM sum_results"
                InsertCommand="INSERT INTO sum_results VALUES(@v1, @v2, @sum)" 
                DeleteCommand="DELETE FROM sum_results" />
        </div>
    </form>
</body>
</html>
