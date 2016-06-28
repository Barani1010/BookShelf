<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StudentWorkspace.aspx.vb" Inherits="BBWeb.StudentWorkspace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
                <img alt="" src="/images/Title.png" style="margin-left: 0px" /></td>
            <td>
                <asp:Label ID="WelcomeMessage" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                <br />
                <br />
                <asp:LinkButton ID="SignOut" runat="server" Font-Size="Medium">Sign out</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
                    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#FFFBD6" />
                    <DynamicSelectedStyle BackColor="#FFCC66" />
                    <Items>
                        <asp:MenuItem Selected="True" Text="Workspace" Value="Workspace" NavigateUrl="~/StudentWorkspace.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Change Password" Value="Change Password" NavigateUrl="~/ChangePassword.aspx"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/SelectBook.aspx" Text="Search Books" Value="Search Books"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#FFCC66" />
                </asp:Menu>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
