Imports System.Windows.Forms

Public Class EditStudentForm

    Public StudentObj As Book_Bank.StudentClass

    ' this sub is used to save changes
    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
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

        ' create the student object and fill it
        StudentObj.SetStudentName(StudentName.Text.Trim)
        StudentObj.SetStudentIDENT(IDENT.Text.Trim)
        StudentObj.SetStudentYear(StudentYear.Text)
        StudentObj.SetStudentContact(StudentContact.Text.Trim)
        StudentObj.SetStudentEmail(StudentEmail.Text.Trim)

        If Not StudentObj.UpdateDB(MainWindow.DBMS, True) Then
            MsgBox("Error while updating student", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    ' this method is used to fill the GUI
    Private Sub EditStudentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StudentName.Text = StudentObj.GetStudentName
        Me.StudentContact.Text = StudentObj.GetStudentContact
        Me.StudentEmail.Text = StudentObj.GetStudentEmail
        Me.StudentYear.Text = StudentObj.GetStudentYear
        Me.IDENT.Text = StudentObj.GetStudentIDENT
        Me.StudentLoginName.Text = StudentObj.GetStudentLoginName
    End Sub

    ' this get executed when you want to cancel the update
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class
