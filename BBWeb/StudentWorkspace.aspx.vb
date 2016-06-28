Partial Public Class StudentWorkspace
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim StudentOBJ As Book_Bank.StudentClass
        StudentOBJ = Session("student")
        If StudentOBJ Is Nothing Then
            Server.Transfer("default.aspx")
            Exit Sub
        End If
        WelcomeMessage.Text = "Welcome " & StudentOBJ.GetStudentName
    End Sub

    Protected Sub SignOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SignOut.Click
        Session.Abandon()
        Server.Transfer("default.aspx")
    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        If e.Item.Text = "Change Password" Then
            Server.Transfer("changepassword.aspx")
        End If
    End Sub

End Class