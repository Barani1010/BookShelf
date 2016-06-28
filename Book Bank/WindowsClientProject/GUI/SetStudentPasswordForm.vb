Imports System.Windows.Forms

''' <summary>
''' This form is used to update student password
''' </summary>
''' <remarks></remarks>
Public Class SetStudentPasswordForm

    ' used to store student information
    Public StudentObj As Book_Bank.StudentClass

    ''' <summary>
    ''' this method is used to update the password
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' first step is to perform validation
        If PSW.Text <> PSW2.Text Then
            MsgBox("Student password and its confirmation don't match", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            PSW.Focus()
            Exit Sub
        End If

        If PSW.Text = "" Then
            MsgBox("Student password can't be empty", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            PSW.Focus()
            Exit Sub
        End If

        StudentObj.SetStudentPassword(PSW.Text)

        If Not StudentObj.UpdateDB(MainWindow.DBMS, True) Then
            MsgBox("Unable of updating student password", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' initalization of GUI happens here
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SetStudentPasswordForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StudentName.Text = StudentObj.GetStudentName
    End Sub
End Class
