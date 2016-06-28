Imports System.Windows.Forms

Public Class EditShelfForm

    ' this object should store the original shelf information
    Public OriginalShelfInfo As Book_Bank.ShelfClass

    ' used to initalize the form information
    Private Sub EditShelfForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' fill the shelf information
        ShelfNoText.Text = OriginalShelfInfo.GetShelfNo
        ShelfFloorText.Text = OriginalShelfInfo.GetFloor
        ShelfSectionText.Text = OriginalShelfInfo.GetSection

    End Sub

    ' this is used to cancel the changes
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' this is used to save the changes
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' first step is to validate the input
        If ShelfNoText.Text.Trim = "" Then
            MsgBox("You should specify shelf number", MsgBoxStyle.Critical Or MsgBoxStyle.OkCancel, "Error")
            ShelfNoText.Focus()
            Exit Sub
        End If
        If ShelfFloorText.Text.Trim = "" Then
            MsgBox("You should specify shelf floor", MsgBoxStyle.Critical Or MsgBoxStyle.OkCancel, "Error")
            ShelfFloorText.Focus()
            Exit Sub
        End If
        If ShelfSectionText.Text.Trim = "" Then
            MsgBox("You should specify shelf section", MsgBoxStyle.Critical Or MsgBoxStyle.OkCancel, "Error")
            ShelfSectionText.Focus()
            Exit Sub
        End If

        ' update the object
        Me.OriginalShelfInfo.SetShelfNo(ShelfNoText.Text)
        Me.OriginalShelfInfo.SetFloor(ShelfFloorText.Text)
        Me.OriginalShelfInfo.SetSection(ShelfSectionText.Text)

        ' update the db
        If Not Me.OriginalShelfInfo.UpdateDB(MainWindow.DBMS, True) Then
            MsgBox("Unable to update the database", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If


    End Sub
End Class

