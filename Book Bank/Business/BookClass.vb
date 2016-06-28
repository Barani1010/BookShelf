' this class is used to manage book information
Public Class BookClass

    ' defining the properties
    Private BookID As String
    Private BookTitle As String
    Private BookAuthor As String
    Private PublicationYear As String
    Private Press As String
    Private Subject As String
    Private Keywords As String
    Private AvailableCopies As String
    Private TotalCopies As String
    Private ShelfNo As String
    Private Barcode As String

    Private OldBookID As String
    Private OldBookTitle As String
    Private OldBookAuthor As String
    Private OldPublicationYear As String
    Private OldPress As String
    Private OldSubject As String
    Private OldKeywords As String
    Private OldAvailableCopies As String
    Private OldTotalCopies As String
    Private OldShelfNo As String
    Private OldBarcode As String


    ' set book id
    Public Sub SetBookID(ByVal ID As String)
        Me.BookID = ID
    End Sub

    ' set book title
    Public Sub SetBookTitle(ByVal Title As String)
        Me.BookTitle = Title
    End Sub

    ' set book author
    Public Sub SetBookAuthor(ByVal Author As String)
        Me.BookAuthor = Author
    End Sub

    ' set publication year
    Public Sub SetBookPublicationYear(ByVal PubYear As String)
        Me.PublicationYear = PubYear
    End Sub

    ' set press
    Public Sub SetBookPress(ByVal Prs As String)
        Me.Press = Prs
    End Sub

    ' set the subject
    Public Sub SetBookSubject(ByVal SBJ As String)
        Me.Subject = SBJ
    End Sub

    ' set keywords
    Public Sub SetBookKeywords(ByVal KWD As String)
        Me.Keywords = KWD
    End Sub

    ' set available copies
    Public Sub SetAvailableCopies(ByVal AvailCOPY As Integer)
        Me.AvailableCopies = AvailCOPY
    End Sub

    ' set the total copies
    Public Sub SetTotalCopies(ByVal TOTCOPY As Integer)
        Me.TotalCopies = TOTCOPY
    End Sub

    ' set shelf no
    Public Sub SetShelfNO(ByVal Shelf_NO As String)
        Me.ShelfNo = Shelf_NO
    End Sub

    ' set the barcode
    Public Sub SetBarcode(ByVal BarcodeNo As String)
        Me.Barcode = BarcodeNo
    End Sub



    ' get book id
    Public Function GetBookID() As String
        Return Me.BookID
    End Function

    ' get book title 
    Public Function GetBookTitle() As String
        Return Me.BookTitle
    End Function

    ' get book author
    Public Function GetBookAuthor() As String
        Return Me.BookAuthor
    End Function

    ' get book publication year
    Public Function GetBookPublicationYear() As String
        Return Me.PublicationYear
    End Function

    ' get press
    Public Function GetPress() As String
        Return Me.Press
    End Function

    ' get subject
    Public Function GetSubject() As String
        Return Me.Subject
    End Function

    ' get keywords
    Public Function GetKeywords() As String
        Return Me.Keywords
    End Function

    ' get available copies
    Public Function GetAvailableCopies() As Integer
        Return Me.AvailableCopies
    End Function

    ' get total copies 
    Public Function GetTotalCopies() As Integer
        Return Me.TotalCopies
    End Function

    ' get shelf no
    Public Function GetShelfNo() As String
        Return Me.ShelfNo
    End Function

    ' get barcode
    Public Function GetBarcode() As String
        Return Me.Barcode
    End Function


    ' insert the record into the database
    Public Function InsertIntoDB(ByVal DBMS As DBMSClass, ByVal Commit As Boolean) As Boolean
        Try

            ' first generate the sql command
            Dim SQL As String
            SQL = "insert into books (" & _
                  "BookID, " & _
                  "BookTitle, " & _
                  "BookAuthor, " & _
                  "PublicationYear, " & _
                  "Press, " & _
                  "Subject, " & _
                  "Keywords, " & _
                  "AvailableCopies, " & _
                  "TotalCopies, " & _
                  "ShelfNo, " & _
                  "Barcode " & _
                  ") values (@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)"
            Me.BookID = GetNextVal()
            DBMS.ExecuteSQL(SQL, _
                            Me.BookID, _
                            Me.BookTitle, _
                            Me.BookAuthor, _
                            Me.PublicationYear, _
                            Me.Press, _
                            Me.Subject, _
                            Me.Keywords, _
                            Me.AvailableCopies, _
                            Me.TotalCopies, _
                            Me.ShelfNo, _
                            Me.Barcode)

            ' commit changes
            If Commit Then
                DBMS.Commit()
            End If

            ' set old =new
            Me.OldBookID = Me.BookID
            Me.OldBookTitle = Me.BookTitle
            Me.OldBookAuthor = Me.BookAuthor
            Me.OldPublicationYear = Me.PublicationYear
            Me.OldPress = Me.Press
            Me.OldSubject = Me.Subject
            Me.OldKeywords = Me.Keywords
            Me.OldAvailableCopies = Me.AvailableCopies
            Me.OldTotalCopies = Me.TotalCopies
            Me.OldShelfNo = Me.ShelfNo
            Me.OldBarcode = Me.Barcode

            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try

    End Function

    ' load the record from db
    Public Function LoadFromDB(ByVal DBMS As DBMSClass, ByVal BkID As String) As Boolean
        Try
            ' get the record
            Dim S As String
            S = DBMS.CreateResultSet("select * from books where BookID=@0", BkID)
            If Not DBMS.ReadAndNotEOF(S) Then
                DBMS.CloseResultSet(S)
                DBMS.Rollback()
                Return False
            End If

            ' load the information
            Me.BookID = DBMS.GetColumnValue(S, "BookID") & ""
            Me.BookTitle = DBMS.GetColumnValue(S, "BookTitle") & ""
            Me.BookAuthor = DBMS.GetColumnValue(S, "BookAuthor") & ""
            Me.PublicationYear = DBMS.GetColumnValue(S, "PublicationYear") & ""
            Me.Press = DBMS.GetColumnValue(S, "Press") & ""
            Me.Subject = DBMS.GetColumnValue(S, "Subject") & ""
            Me.Keywords = DBMS.GetColumnValue(S, "Keywords") & ""
            Me.AvailableCopies = DBMS.GetColumnValue(S, "AvailableCopies") & ""
            Me.TotalCopies = DBMS.GetColumnValue(S, "TotalCopies") & ""
            Me.ShelfNo = DBMS.GetColumnValue(S, "ShelfNo") & ""
            Me.Barcode = DBMS.GetColumnValue(S, "Barcode") & ""

            DBMS.CloseResultSet(S)

            ' set old = new
            Me.OldBookID = Me.BookID
            Me.OldBookTitle = Me.BookTitle
            Me.OldBookAuthor = Me.BookAuthor
            Me.OldPublicationYear = Me.PublicationYear
            Me.OldPress = Me.Press
            Me.OldSubject = Me.Subject
            Me.OldKeywords = Me.Keywords
            Me.OldAvailableCopies = Me.AvailableCopies
            Me.OldTotalCopies = Me.TotalCopies
            Me.OldShelfNo = Me.ShelfNo
            Me.OldBarcode = Me.Barcode

            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function


    Public Function WasRecordChanged(ByVal DBMS As DBMSClass) As String
        Try
            ' load the record from db
            Dim TMP As New BookClass
            If Not TMP.LoadFromDB(DBMS, Me.OldBookID) Then
                DBMS.Rollback()
                Return "error"
            End If

            ' check if any value was changed
            If TMP.OldAvailableCopies <> Me.OldAvailableCopies Then Return "yes"
            If TMP.OldBarcode <> Me.OldBarcode Then Return "yes"
            If TMP.OldBookAuthor <> Me.OldBookAuthor Then Return "yes"
            If TMP.OldBookTitle <> Me.OldBookTitle Then Return "yes"
            If TMP.OldKeywords <> Me.OldKeywords Then Return "yes"
            If TMP.OldPress <> Me.OldPress Then Return "yes"
            If TMP.OldPublicationYear <> Me.OldPublicationYear Then Return "yes"
            If TMP.OldShelfNo <> Me.OldShelfNo Then Return "yes"
            If TMP.OldSubject <> Me.OldSubject Then Return "yes"
            If TMP.OldTotalCopies <> Me.OldTotalCopies Then Return "yes"

            Return "no"
        Catch ex As Exception
            DBMS.Rollback()
            Return "error"
        End Try
    End Function

    ' this function is used to edit the record in the db
    Public Function UpdateDB(ByVal DBMS As DBMSClass, ByVal Commit As Boolean) As Boolean
        Try
            ' first lock this record
            DBMS.ExecuteSQL("update books set bookid=@0 where bookid=@0 ", Me.BookID)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' update the db
            DBMS.ExecuteSQL("update books set booktitle=@0 where bookid=@1", Me.BookTitle, Me.BookID)
            DBMS.ExecuteSQL("update books set bookauthor=@0 where bookid=@1", Me.BookAuthor, Me.BookID)
            DBMS.ExecuteSQL("update books set publicationyear=@0 where bookid=@1", Me.PublicationYear, Me.BookID)
            DBMS.ExecuteSQL("update books set press=@0 where bookid=@1", Me.Press, Me.BookID)
            DBMS.ExecuteSQL("update books set subject=@0 where bookid=@1", Me.Subject, Me.BookID)
            DBMS.ExecuteSQL("update books set keywords=@0 where bookid=@1", Me.Keywords, Me.BookID)
            DBMS.ExecuteSQL("update books set availablecopies=@0 where bookid=@1", Me.AvailableCopies, Me.BookID)
            DBMS.ExecuteSQL("update books set totalcopies=@0 where bookid=@1", Me.TotalCopies, Me.BookID)
            DBMS.ExecuteSQL("update books set shelfno=@0 where bookid=@1", Me.ShelfNo, Me.BookID)
            DBMS.ExecuteSQL("update books set barcode=@0 where bookid=@1", Me.Barcode, Me.BookID)
            DBMS.ExecuteSQL("update books set bookid=@0 where bookid=@1", Me.OldBookID, Me.BookID)

            ' commit the changes
            If Commit Then
                DBMS.Commit()
            End If

            ' set old values = new
            Me.OldBookID = Me.BookID
            Me.OldBookTitle = Me.BookTitle
            Me.OldBookAuthor = Me.BookAuthor
            Me.OldPublicationYear = Me.PublicationYear
            Me.OldPress = Me.Press
            Me.OldSubject = Me.Subject
            Me.OldKeywords = Me.Keywords
            Me.OldAvailableCopies = Me.AvailableCopies
            Me.OldTotalCopies = Me.TotalCopies
            Me.OldShelfNo = Me.ShelfNo
            Me.OldBarcode = Me.Barcode

            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to remove the object from db
    Public Function RemoveFromDB(ByVal DBMS As DBMSClass, ByVal Commit As Boolean) As Boolean
        Try
            ' first lock this record
            DBMS.ExecuteSQL("update books set bookid=@0 where bookid=@0 ", Me.OldBookID)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' remove the record
            DBMS.ExecuteSQL("delete from books where bookid=@0", Me.OldBookID)

            If Commit Then
                DBMS.Commit()
            End If
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to fill the dgv with books info
    Public Shared Function FillDGVWithBookInfo(ByVal DGV As DataGridView, ByVal DBMS As DBMSClass) As Boolean
        Try
            ' display all the staff information in the data grid view
            If Not DBMS.FillDataGridViewWithData(DGV, "select * from books") Then
                Return False
            End If
            DGV.Columns("BookID").HeaderText = "Book ID"
            DGV.Columns("BookTitle").HeaderText = "Book Title"
            DGV.Columns("BookAuthor").HeaderText = "Book Author"
            DGV.Columns("PublicationYear").HeaderText = "Year"
            DGV.Columns("Press").HeaderText = "Press"
            DGV.Columns("Subject").HeaderText = "Subject"
            DGV.Columns("Keywords").HeaderText = "Keywords"
            DGV.Columns("AvailableCopies").HeaderText = "Available"
            DGV.Columns("TotalCopies").HeaderText = "Total"
            DGV.Columns("ShelfNo").HeaderText = "Shelf"
            DGV.Columns("Barcode").HeaderText = "Barcode"

            DGV.Columns("BookID").Visible = False
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function




    ' this function is used to search for books and display the information in DGV
    Public Shared Function FillDGVWithBookInfoUsingSearch(ByVal DGV As DataGridView, ByVal DBMS As DBMSClass, ByVal WherePart As String, ByVal ParamArray Values() As Object) As Boolean
        Try
            ' display all the staff information in the data grid view
            If Not DBMS.FillDataGridViewWithData(DGV, "select * from books" & WherePart, Values) Then
                Return False
            End If
            DGV.Columns("BookID").HeaderText = "Book ID"
            DGV.Columns("BookTitle").HeaderText = "Book Title"
            DGV.Columns("BookAuthor").HeaderText = "Book Author"
            DGV.Columns("PublicationYear").HeaderText = "Year"
            DGV.Columns("Press").HeaderText = "Press"
            DGV.Columns("Subject").HeaderText = "Subject"
            DGV.Columns("Keywords").HeaderText = "Keywords"
            DGV.Columns("AvailableCopies").HeaderText = "Available"
            DGV.Columns("TotalCopies").HeaderText = "Total"
            DGV.Columns("ShelfNo").HeaderText = "Shelft"
            DGV.Columns("Barcode").HeaderText = "Barcode"

            DGV.Columns("BookID").Visible = False
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function


End Class
