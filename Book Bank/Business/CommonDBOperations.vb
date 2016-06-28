' this module contains some functions related to db
Public Module CommonDBOperations
    ' this first function is used to save and load values from
    ' vars table
    Public Function SaveVar(ByVal DBMS As DBMSClass, ByVal VarName As String, ByVal VarValue As String, ByVal Commit As Boolean) As Boolean
        Try
            ' remove previous var
            DBMS.ExecuteSQL("delete from vars where varname=@0", VarName)

            ' insert new one
            DBMS.ExecuteSQL("insert into vars(varname,varvalue) values (@0,@1)", VarName, VarValue)

            ' save changes
            If Commit Then
                DBMS.Commit()
            End If
            Return True

        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' used to load a variable
    Public Function LoadVar(ByVal DBMS As DBMSClass, ByVal VarName As String) As String
        Try
            Dim S As String = DBMS.CreateResultSet("select * from vars where varname=@0", VarName)
            If Not DBMS.ReadAndNotEOF(S) Then
                DBMS.CloseResultSet(S)
                DBMS.Rollback()
                Return ""
            End If
            Dim V As String = DBMS.GetColumnValue(S, "varvalue")
            DBMS.CloseResultSet(S)
            Return V
        Catch ex As Exception
            DBMS.Rollback()
            Return ""
        End Try
    End Function

    ' this function is used to create a sequence 
    Public Function GetNextVal() As String
        Dim DBMS As New DBMSClass
        DBMS.OpenDB()
        Try

            Dim V As String = LoadVar(DBMS, "seq")
            If V = "" Then
                V = "1"
            End If
            Dim VV As Long = Long.Parse(V)
            VV = VV + 1
            SaveVar(DBMS, "seq", VV, True)
            DBMS.CloseDB()
            Return VV
        Catch ex As Exception
            DBMS.closedb()
            Return ""
        End Try
    End Function
End Module

