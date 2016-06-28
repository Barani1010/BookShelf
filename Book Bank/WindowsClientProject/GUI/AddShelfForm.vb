Public Class AddShelfForm

    ' cancel the data entry
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    ' add a new shelf
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' perform validation
        If ShelfNOTX.Text.Trim = "" Then
            MsgBox("You should specify shelf no", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            ShelfNOTX.Focus()
            Exit Sub
        End If

        If FloorTX.Text.Trim = "" Then
            MsgBox("You should specify the floor", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            FloorTX.Focus()
            Exit Sub
        End If

        If SectionTX.Text.Trim = "" Then
            MsgBox("You should specify the section", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            SectionTX.Focus()
            Exit Sub
        End If

        ' create the object and insert it
        Dim ShelfObject As New Book_Bank.ShelfClass
        ShelfObject.SetShelfNo(ShelfNOTX.Text.Trim)
        ShelfObject.SetFloor(FloorTX.Text.Trim)
        ShelfObject.SetSection(SectionTX.Text.Trim)

        If Not ShelfObject.InsertIntoDB(MainWindow.DBMS, True) Then
            MsgBox("Unable of inserting the shelf information into the database", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub

  
End Class