Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' this method is used for login
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub UserLogin_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles UserLogin.Authenticate

        ' open db
        Dim DBMS As New Book_Bank.DBMSClass
        Dim Result = DBMS.OpenDB

        If Result <> "OK" Then
            UserLogin.FailureText = Result
            Exit Sub
        End If

        ' get student object
        Dim StudentOBJ As New Book_Bank.StudentClass
        If Not StudentOBJ.LoadFromDBByLoginName(DBMS, UserLogin.UserName) Then
            UserLogin.FailureText = "Invalid Username or Password"
            DBMS.CloseDB()
            Exit Sub
        End If

        ' check the password
        If StudentOBJ.GetStudentPassword <> UserLogin.Password Then
            UserLogin.FailureText = "Invalid Username or Password"
            DBMS.CloseDB()
            Exit Sub
        End If

        ' close db
        DBMS.CloseDB()

        ' save student
        Session.Add("student", StudentOBJ)

        ' go to main page
        Server.Transfer("StudentWorkspace.aspx")

    End Sub
End Class