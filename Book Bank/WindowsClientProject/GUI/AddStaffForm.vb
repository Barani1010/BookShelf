Imports System.Windows.Forms

Public Class AddStaffForm

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' perform validation
        If UsernameTextBox.Text.Trim = "" Then
            MsgBox("You should enter a valid staff login name", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Error")
            UsernameTextBox.Focus()
            Exit Sub
        End If

        If StaffFullNameTextBox.Text.Trim = "" Then
            MsgBox("You should enter a valid staff full name", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Error")
            StaffFullNameTextBox.Focus()
            Exit Sub
        End If

        If PasswordTextBox.Text <> ConfirmPasswordTextBox.Text Then
            MsgBox("The password and its confirmation does not match", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Error")
            PasswordTextBox.Focus()
            Exit Sub
        End If

        If PasswordTextBox.Text = "" Then
            MsgBox("You can't use an empty password", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Error")
            PasswordTextBox.Focus()
            Exit Sub
        End If

        ' create the user or staff object
        Dim STOBJ As New Book_Bank.StaffClass
        STOBJ.SetEmployeeLoginName(UsernameTextBox.Text)
        STOBJ.SetEmployeeName(StaffFullNameTextBox.Text)
        STOBJ.SetEmployeePassword(PasswordTextBox.Text)

        ' insert the information into the database
        If STOBJ.InsertIntoDB(MainWindow.DBMS, True) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Unable of adding staff information", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
