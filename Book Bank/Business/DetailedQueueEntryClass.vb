''' <summary>
''' this class represents a record for a given book
''' it shows which student want to borrow which book
''' </summary>
''' <remarks></remarks>
Public Class DetailedQueueEntryClass

    Public StudentOBJ As StudentClass
    Public BookOBJ As BookClass
    Public BookingOrder As Integer


    ''' <summary>
    ''' this function is used to load a queue record
    ''' </summary>
    ''' <param name="DBMS"></param>
    ''' <param name="StudentID"></param>
    ''' <param name="BookID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadBookingRecord(ByVal DBMS As DBMSClass, ByVal StudentID As Long, ByVal BookID As String) As Boolean
        Try
            Dim S As String = DBMS.CreateResultSet("select * from queue where studentid=@0 and bookid=@1", StudentID, BookID)
            If Not DBMS.ReadAndNotEOF(S) Then
                DBMS.CloseResultSet(S)
                DBMS.Rollback()
                Return False
            End If

            ' load the student record
            Me.StudentOBJ = New StudentClass
            If Not Me.StudentOBJ.LoadFromDBByID(DBMS, StudentID) Then
                DBMS.CloseResultSet(S)
                DBMS.Rollback()
                Return False
            End If

            ' load the book information
            Me.BookOBJ = New BookClass
            If Not Me.BookOBJ.LoadFromDB(DBMS, BookID) Then
                DBMS.CloseResultSet(S)
                DBMS.Rollback()
                Return False
            End If

            Me.BookingOrder = DBMS.GetColumnValue(S, "bookingorder")

            DBMS.CloseResultSet(S)

            Return True

        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' get list of booking details for a book
    ''' </summary>
    ''' <param name="DBMS"></param>
    ''' <param name="BookID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetBookingListForBook(ByVal DBMS As DBMSClass, ByVal BookID As String) As List(Of DetailedQueueEntryClass)
        Try
            ' create an empty list for the results
            Dim Result As New List(Of DetailedQueueEntryClass)

            ' get the records
            Dim S As String = DBMS.CreateResultSet("select * from queue where bookid=@0 order by bookingorder", BookID)
            Do While DBMS.ReadAndNotEOF(S)

                Dim TMP As New DetailedQueueEntryClass
                Dim STID As Long = DBMS.GetColumnValue(S, "studentid")

                If Not TMP.LoadBookingRecord(DBMS, STID, BookID) Then
                    DBMS.CloseResultSet(S)
                    Return Nothing
                End If

                Result.Add(TMP)

            Loop

            DBMS.CloseResultSet(S)

            Return Result

        Catch ex As Exception
            DBMS.Rollback()
            Return Nothing
        End Try
    End Function
End Class
