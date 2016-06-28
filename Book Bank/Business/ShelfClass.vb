' this class is used to manage shelves
Public Class ShelfClass

    ' define the members of the class
    Private ShelfNo As String
    Private Floor As String
    Private Section As String

    Private OldShelfNo As String
    Private OldFloor As String
    Private OldSection As String

    ' setters and getters for the methods
    Public Sub SetShelfNo(ByVal ShelfNumber As String)
        Me.ShelfNo = ShelfNumber
    End Sub

    Public Sub SetFloor(ByVal ShelfFloor As String)
        Me.Floor = ShelfFloor
    End Sub

    Public Sub SetSection(ByVal ShelfSection As String)
        Me.Section = ShelfSection
    End Sub

    Public Function GetShelfNo() As String
        Return Me.ShelfNo
    End Function

    Public Function GetFloor() As String
        Return Me.Floor
    End Function

    Public Function GetSection() As String
        Return Me.Section
    End Function

    ' this method is used to insert an object into the database
    Public Function InsertIntoDB(ByVal DBMS As DBMSClass, ByVal Commit As Boolean) As Boolean
        Try
            ' insert the record
            Dim SQL As String
            SQL = "insert into shelves values (@0,@1,@2)"
            DBMS.ExecuteSQL(SQL, Me.ShelfNo, Me.Floor, Me.Section)

            ' save the changes
            If Commit Then
                DBMS.Commit()
            End If

            Me.OldFloor = Me.Floor
            Me.OldSection = Me.Section
            Me.OldShelfNo = Me.ShelfNo

            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to load shelf information from db
    Public Function LoadFromDB(ByVal DBMS As DBMSClass, ByVal ShelfNo As String) As Boolean
        Try
            ' get the record
            Dim S As String
            S = DBMS.CreateResultSet("select * from shelves where shelfno=@0", ShelfNo)
            If DBMS.ReadAndNotEOF(S) Then

                ' fill the object
                Me.ShelfNo = DBMS.GetColumnValue(S, "shelfno")
                Me.Floor = DBMS.GetColumnValue(S, "floor")
                Me.Section = DBMS.GetColumnValue(S, "section")

                ' set old =new
                Me.OldShelfNo = Me.ShelfNo
                Me.OldFloor = Me.Floor
                Me.OldSection = Me.Section

                ' close recordset
                DBMS.CloseResultSet(S)

                Return True
            Else

                ' no record was found, so close result set
                DBMS.CloseResultSet(S)

                ' rollback
                DBMS.Rollback()

                Return False

            End If
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function checks to see if the record was changed or not
    Public Function WasRecordChanged(ByVal DBMS As DBMSClass) As String
        Try
            ' load the record from db
            Dim TMP As New ShelfClass
            If Not TMP.LoadFromDB(DBMS, Me.OldShelfNo) Then
                DBMS.Rollback()
                Return "error"
            End If

            ' check if any value was changed
            If TMP.OldShelfNo <> Me.OldShelfNo Then Return "yes"
            If TMP.OldFloor <> Me.OldFloor Then Return "yes"
            If TMP.OldSection <> Me.OldSection Then Return "yes"

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
            DBMS.ExecuteSQL("update shelves set shelfno=@0 where shelfno=@0 ", Me.OldShelfNo)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' update the db
            DBMS.ExecuteSQL("update shelves set floor=@0 where shelfno=@1", Me.Floor, Me.OldShelfNo)
            DBMS.ExecuteSQL("update shelves set section=@0 where shelfno=@1", Me.Section, Me.OldShelfNo)
            DBMS.ExecuteSQL("update shelves set shelfno=@0 where shelfno=@1", Me.ShelfNo, Me.OldShelfNo)

            ' commit the changes
            If Commit Then
                DBMS.Commit()
            End If

            ' set old values = new
            Me.OldShelfNo = Me.ShelfNo
            Me.OldFloor = Me.Floor
            Me.OldSection = Me.Section

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
            DBMS.ExecuteSQL("update shelves set shelfno=@0 where shelfno=@0 ", Me.OldShelfNo)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' remove the record
            DBMS.ExecuteSQL("delete from shelves where shelfno=@0", Me.OldShelfNo)

            If Commit Then
                DBMS.Commit()
            End If
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function


    ' this function is used to fill the dgv with shelves info
    Public Shared Function FillDGVWithShelfInfo(ByVal DGV As DataGridView, ByVal DBMS As DBMSClass) As Boolean
        Try
            ' display all the staff information in the data grid view
            If Not DBMS.FillDataGridViewWithData(DGV, "select * from shelves") Then
                Return False
            End If
            DGV.Columns("ShelfNo").HeaderText = "Shelf No"
            DGV.Columns("Floor").HeaderText = "Floor"
            DGV.Columns("Section").HeaderText = "Section"
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to fill the combobox with shelves info
    Public Shared Function FillComboBoxWithShelfInfo(ByVal CMBBox As ComboBox, ByVal DBMS As DBMSClass) As Boolean
        Try
            ' remove all the values displayed in the combobox
            CMBBox.Items.Clear()
            Dim S As String
            S = DBMS.CreateResultSet("select * from shelves")
            Do While DBMS.ReadAndNotEOF(S)
                CMBBox.Items.Add(DBMS.GetColumnValue(S, "Shelfno"))
            Loop
            DBMS.CloseResultSet(S)
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            CMBBox.Items.Clear()
            Return False
        End Try
    End Function
End Class
