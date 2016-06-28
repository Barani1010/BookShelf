Imports System.Windows.Forms

Public Class AddStudentForm

    ' this method runs when the ok button is used
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' first perform validation
        If StudentName.Text.Trim = "" Then
            MsgBox("You should enter a student name", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            StudentName.Focus()
            Exit Sub
        End If

        If IDENT.Text.Trim = "" Then
            MsgBox("You should enter an identification number for the student", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            IDENT.Focus()
            Exit Sub
        End If

        If StudentYear.Text = "" Then
            MsgBox("You should select the year for the student", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            StudentYear.Focus()
            Exit Sub
        End If

        If StudentContact.Text.Trim = "" Then
            MsgBox("You should enter contact information for student", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            StudentContact.Focus()
            Exit Sub
        End If

        If StudentEmail.Text.Trim = "" Then
            MsgBox("You should enter an email for the student", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            StudentEmail.Focus()
            Exit Sub
        End If

        If StudentLoginName.Text.Trim = "" Then
            MsgBox("You should enter the student login name", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            StudentLoginName.Focus()
            Exit Sub
        End If
        ' create the student object and fill it
        Dim StudentObj As New Book_Bank.StudentClass
        StudentObj.SetStudentName(StudentName.Text.Trim)
        StudentObj.SetStudentIDENT(IDENT.Text.Trim)
        StudentObj.SetStudentYear(StudentYear.Text)
        StudentObj.SetStudentContact(StudentContact.Text.Trim)
        StudentObj.SetStudentEmail(StudentEmail.Text.Trim)
        StudentObj.SetStudentPassword("")
        StudentObj.SetStudentLoginName(StudentLoginName.Text.Trim)
        If Not StudentObj.InsertIntoDB(MainWindow.DBMS, True) Then
            MsgBox("Error while adding student", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
