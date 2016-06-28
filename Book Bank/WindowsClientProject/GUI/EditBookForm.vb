Public Class EditBookForm

    ' define the book object that we can update
    Public BookObj As Book_Bank.BookClass


    Private Sub EditBookForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' fill the user interface
        BTitle.Text = BookObj.GetBookTitle()
        BAuthor.Text = BookObj.GetBookAuthor()
        BYear.Text = BookObj.GetBookPublicationYear()
        BPress.Text = BookObj.GetPress
        BSubject.Text = BookObj.GetSubject
        BKeywords.Text = BookObj.GetKeywords
        BAvailableCopies.Text = BookObj.GetAvailableCopies
        BTotalCopies.Text = BookObj.GetTotalCopies
        BBarCode.Text = BookObj.GetBarcode

        If Not Book_Bank.ShelfClass.FillComboBoxWithShelfInfo(BShelfNo, MainWindow.DBMS) Then
            MsgBox("Error while getting shelf information", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            Me.Close()
            Exit Sub
        End If

        BShelfNo.Text = BookObj.GetShelfNo
    End Sub

    ' cancel the edit
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' first stage is to perform validation
        If BTitle.Text.Trim = "" Then
            MsgBox("You should enter a title for the book", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BTitle.Focus()
            Exit Sub
        End If

        If BAuthor.Text.Trim = "" Then
            MsgBox("You should enter an author for the book", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BAuthor.Focus()
            Exit Sub
        End If

        If BYear.Text.Trim = "" Then
            MsgBox("You should enter publication year for the book", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BYear.Focus()
            Exit Sub
        End If

        If BPress.Text.Trim = "" Then
            MsgBox("You should enter the press for the book", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BPress.Focus()
            Exit Sub
        End If

        If Not IsNumeric(BAvailableCopies.Text) Then
            MsgBox("You should enter the available copies for the book as a number", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BAvailableCopies.Focus()
            Exit Sub
        End If

        If Double.Parse(BAvailableCopies.Text) <> Integer.Parse(BAvailableCopies.Text) Then
            MsgBox("You should enter the available copies as an integer value", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BAvailableCopies.Focus()
            Exit Sub
        End If

        If Double.Parse(BAvailableCopies.Text) < 0 Then
            MsgBox("You should enter the available copies as +ve value", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BAvailableCopies.Focus()
            Exit Sub
        End If

        If Not IsNumeric(BTotalCopies.Text) Then
            MsgBox("You should enter the total copies for the book as a number", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BTotalCopies.Focus()
            Exit Sub
        End If

        If Double.Parse(BTotalCopies.Text) <> Integer.Parse(BTotalCopies.Text) Then
            MsgBox("You should enter the total copies as an integer value", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BTotalCopies.Focus()
            Exit Sub
        End If

        If Double.Parse(BTotalCopies.Text) < 0 Then
            MsgBox("You should enter the total copies as +ve value", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BTotalCopies.Focus()
            Exit Sub
        End If

        If Double.Parse(BTotalCopies.Text) <> Double.Parse(BAvailableCopies.Text) Then
            MsgBox("the available copies should equal total copies ", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BTotalCopies.Focus()
            Exit Sub
        End If


        If BShelfNo.Text = "" Then
            MsgBox("you should select the shelf no", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BShelfNo.Focus()
            Exit Sub
        End If

        If BBarCode.Text.Trim = "" Then
            MsgBox("you should enter the barcode", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            BBarCode.Focus()
            Exit Sub
        End If

        ' create the book object
        Dim Book As Book_Bank.BookClass = Me.BookObj

        ' fill the book object
        Book.SetAvailableCopies(BAvailableCopies.Text)
        Book.SetBarcode(BBarCode.Text.Trim)
        Book.SetBookAuthor(BAuthor.Text.Trim)
        Book.SetBookKeywords(BKeywords.Text.Trim)
        Book.SetBookPress(BPress.Text.Trim)
        Book.SetBookPublicationYear(BYear.Text.Trim)
        Book.SetBookSubject(BSubject.Text.Trim)
        Book.SetBookTitle(BTitle.Text.Trim)
        Book.SetShelfNO(BShelfNo.Text)
        Book.SetTotalCopies(BTotalCopies.Text.Trim)

        ' save the object
        If Not Book.UpdateDB(MainWindow.DBMS, True) Then
            MsgBox("Unable of updating the book", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End If



        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub
End Class