' This class will manage connectivtiy with the database 
Public Class DBMSClass

    ' define the connection string
    Private DBMSConnectionString = "Data Source=D:\Study Time\OOAD\My Book bank Project\LMA 19\LMS.sdf"

    ' define the connection
    Private DBMSConnectionObj As System.Data.SqlServerCe.SqlCeConnection

    ' define the transaction
    Private DBMSTransactionObj As System.Data.SqlServerCe.SqlCeTransaction

    ' define the commands object and result sets
    Private DBMSCommands As List(Of System.Data.SqlServerCe.SqlCeCommand)
    Private DBMSCommandCodes As List(Of Long)
    Private DBMSResultSets As List(Of System.Data.SqlServerCe.SqlCeResultSet)

    ' command counter
    Private DBMSCommandCounter As Long

    ' open database connection
    Public Function OpenDB() As String
        Try
            ' open the connection
            DBMSConnectionObj = New System.Data.SqlServerCe.SqlCeConnection(DBMSConnectionString)
            DBMSConnectionObj.Open()

            ' create the transaction
            DBMSTransactionObj = DBMSConnectionObj.BeginTransaction

            ' prepare the commands list
            DBMSCommands = New List(Of System.Data.SqlServerCe.SqlCeCommand)
            DBMSCommandCodes = New List(Of Long)
            DBMSResultSets = New List(Of System.Data.SqlServerCe.SqlCeResultSet)

            ' prepare the command counter
            DBMSCommandCounter = 0

            ' return ok
            Return "OK"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    ' this is used to run sql commands
    Public Sub ExecuteSQL(ByVal SQL As String, ByVal ParamArray Obj() As Object)

        ' build the command object
        Dim CMD As New System.Data.SqlServerCe.SqlCeCommand(SQL, Me.DBMSConnectionObj, Me.DBMSTransactionObj)

        ' add the parameters to the sql command
        Dim I As Integer
        For I = 0 To Obj.Length - 1
            CMD.Parameters.AddWithValue("@" & I, Obj(I))
        Next

        ' run the sql
        CMD.ExecuteNonQuery()

    End Sub

    ' this function is used to commit a transaction
    Public Sub Commit()
        Me.DBMSTransactionObj.Commit()
        Me.DBMSTransactionObj = Me.DBMSConnectionObj.BeginTransaction
    End Sub

    ' this function is used to rollback a transaction
    Public Sub Rollback()
        Me.DBMSTransactionObj.Rollback()
        Me.DBMSTransactionObj = Me.DBMSConnectionObj.BeginTransaction
    End Sub

    ' this function is used to create a result set
    Public Function CreateResultSet(ByVal SQL As String, ByVal ParamArray OBJ() As Object) As Long
        DBMSCommandCounter += 1

        ' build the command object
        Dim CMD As New System.Data.SqlServerCe.SqlCeCommand(SQL, Me.DBMSConnectionObj, Me.DBMSTransactionObj)

        ' add the parameters to the sql command
        Dim I As Integer
        For I = 0 To OBJ.Length - 1
            CMD.Parameters.AddWithValue("@" & I, OBJ(I))
        Next

        ' read the data
        Dim RS = CMD.ExecuteResultSet(SqlServerCe.ResultSetOptions.Insensitive)

        ' store objects in list
        Me.DBMSCommandCodes.Add(DBMSCommandCounter)
        Me.DBMSCommands.Add(CMD)
        Me.DBMSResultSets.Add(RS)

        Return DBMSCommandCounter
    End Function

    ' this function is used to close a result set
    Public Sub CloseResultSet(ByVal Nmbr As Long)
        Dim I As Integer
        For I = 0 To Me.DBMSCommandCodes.Count - 1

            ' find the command and result set
            If DBMSCommandCodes(I) = Nmbr Then

                ' get the objects
                Dim R = Me.DBMSResultSets(I)
                Dim C = Me.DBMSCommands(I)

                ' remove the objects from the list
                Me.DBMSResultSets.RemoveAt(I)
                Me.DBMSCommands.RemoveAt(I)
                Me.DBMSCommandCodes.RemoveAt(I)

                ' return the resources
                R.Close()
                R.Dispose()
                C.Dispose()

                Return

            End If
        Next

        Throw New Exception("the command or result set does not exist")
    End Sub

    ' this function is used to read a single record from db
    Public Function ReadAndNotEOF(ByVal Code As Long) As Boolean
        ' do a search
        Dim I As Long
        For i = 0 To Me.DBMSCommandCodes.Count - 1
            If DBMSCommandCodes(i) = Code Then
                Return DBMSResultSets(i).Read
            End If
        Next
        Throw New Exception("Command or Resultset does not exist")
    End Function

    ' this function is used to get a column value from db
    Public Function GetColumnValue(ByVal Code As Long, ByVal ColumnName As String) As Object
        Dim I As Long
        For I = 0 To Me.DBMSCommands.Count - 1
            If DBMSCommandCodes(I) = Code Then
                Return DBMSResultSets(I).Item(ColumnName)
            End If
        Next
        Throw New Exception("Command or Resultset does not exist")
    End Function

    ' this function is used to fill the datagridview with data
    Public Function FillDataGridViewWithData(ByVal DGV As DataGridView, ByVal SQL As String, ByVal ParamArray SqlParams() As Object) As Boolean
        Try
            ' create the command object
            Dim TmpCMD As New System.Data.SqlServerCe.SqlCeCommand
            TmpCMD.CommandText = SQL
            TmpCMD.Connection = Me.DBMSConnectionObj
            Dim I As Integer
            For I = 0 To SqlParams.Count - 1
                TmpCMD.Parameters.AddWithValue("@" & I, SqlParams(I))
            Next


            ' create a data adapter
            Dim TmpDataAdapter As New System.Data.SqlServerCe.SqlCeDataAdapter(TmpCMD)

            ' next fill the datatable
            Dim TmpDataTable As New DataTable
            TmpDataAdapter.Fill(TmpDataTable)

            ' next create a binding source
            Dim TmpBindingSouce As New BindingSource
            TmpBindingSouce.DataSource = TmpDataTable

            ' display the info
            DGV.DataSource = TmpBindingSouce

            ' destroy the data adapter
            TmpDataAdapter.Dispose()
            TmpCMD.Dispose()

            Return True
        Catch ex As Exception
            Me.Rollback()
            DGV.DataSource = Nothing
            Return False
        End Try
    End Function

    ' this function is used to close db
    Public Function CloseDB() As Boolean
        Try
            Me.Rollback()
            For Each rs In DBMSResultSets
                rs.Close()
                rs.Dispose()
            Next
            For Each cmd In DBMSCommands
                cmd.Dispose()
            Next
            DBMSTransactionObj.Dispose()
            DBMSConnectionObj.Close()
            DBMSConnectionObj.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
