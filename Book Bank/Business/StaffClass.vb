' this class is used to manage staff information
Public Class StaffClass

    ' define the members
    Private EmployeeLoginName As String
    Private EmployeeName As String
    Private EmployeePassword As String

    Private OldEmployeeLoginName As String
    Private OldEmployeeName As String
    Private OldEmployeePassword As String


    ' define the setters
    Public Sub SetEmployeeLoginName(ByVal LoginName As String)
        Me.EmployeeLoginName = LoginName
    End Sub

    Public Sub SetEmployeeName(ByVal Name As String)
        Me.EmployeeName = Name
    End Sub

    Public Sub SetEmployeePassword(ByVal Password As String)
        Me.EmployeePassword = Password
    End Sub

    ' define the getters
    Public Function GetEmployeeLoginName() As String
        Return Me.EmployeeLoginName
    End Function

    Public Function GetEmployeeName() As String
        Return Me.EmployeeName
    End Function

    Public Function GetEmployeePassword() As String
        Return Me.EmployeePassword
    End Function

    ' this function is used to save a staff member into the db
    Public Function InsertIntoDB(ByVal DBMS As DBMSClass, ByVal Commit As Boolean) As Boolean
        Try
            ' insert the values into db
            Dim SQL As String = "insert into staff ( " & _
                                " employeeloginname, " & _
                                " employeename, " & _
                                " employeepassword) values " & _
                                "(@0,@1,@2)"
            DBMS.ExecuteSQL(SQL, Me.EmployeeLoginName, Me.EmployeeName, Me.EmployeePassword)

            ' commit the changes
            If Commit Then
                DBMS.Commit()
            End If

            ' make old = new
            Me.OldEmployeeLoginName = Me.EmployeeLoginName
            Me.OldEmployeeName = Me.EmployeeName
            Me.EmployeePassword = Me.EmployeePassword

            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to load staff information from db
    Public Function LoadFromDB(ByVal DBMS As DBMSClass, ByVal LoginName As String) As Boolean
        Try
            ' get the record
            Dim S As String
            S = DBMS.CreateResultSet("select * from staff where employeeloginname=@0", LoginName)
            If DBMS.ReadAndNotEOF(S) Then

                ' fill the object
                Me.EmployeeLoginName = DBMS.GetColumnValue(S, "employeeloginname")
                Me.EmployeeName = DBMS.GetColumnValue(S, "employeename")
                Me.EmployeePassword = DBMS.GetColumnValue(S, "employeepassword")

                ' set old =new
                Me.OldEmployeeName = Me.EmployeeName
                Me.OldEmployeeLoginName = Me.EmployeeLoginName
                Me.OldEmployeePassword = Me.EmployeePassword

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
            Dim TMP As New StaffClass
            If Not TMP.LoadFromDB(DBMS, Me.OldEmployeeLoginName) Then
                DBMS.Rollback()
                Return "error"
            End If

            ' check if any value was changed
            If TMP.OldEmployeeLoginName <> Me.OldEmployeeLoginName Then Return "yes"
            If TMP.OldEmployeeName <> Me.OldEmployeeName Then Return "yes"
            If TMP.OldEmployeePassword <> Me.OldEmployeePassword Then Return "yes"

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
            DBMS.ExecuteSQL("update staff set employeeloginname=@0 where employeeloginname=@0 ", Me.OldEmployeeLoginName)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' update the db
            DBMS.ExecuteSQL("update staff set employeepassword=@0 where employeeloginname=@1", Me.EmployeePassword, Me.OldEmployeeLoginName)
            DBMS.ExecuteSQL("update staff set employeename=@0 where employeeloginname=@1", Me.EmployeeName, Me.OldEmployeeLoginName)
            DBMS.ExecuteSQL("update staff set employeeloginname=@0 where employeeloginname=@1", Me.EmployeeLoginName, Me.OldEmployeeLoginName)

            ' commit the changes
            If Commit Then
                DBMS.Commit()
            End If

            ' set old values = new
            Me.OldEmployeeLoginName = Me.EmployeeLoginName
            Me.OldEmployeeName = Me.EmployeeName
            Me.OldEmployeePassword = Me.OldEmployeePassword

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
            DBMS.ExecuteSQL("update staff set employeeloginname=@0 where employeeloginname=@0 ", Me.OldEmployeeLoginName)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' remove the record
            DBMS.ExecuteSQL("delete from staff where employeeloginname=@0", Me.OldEmployeeLoginName)

            If Commit Then
                DBMS.Commit()
            End If
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to check user login 
    Public Shared Function Login(ByVal DBMS As DBMSClass, ByVal EmpLoginName As String, ByVal EmpPassword As String) As StaffClass
        Try
            Dim S As String
            S = DBMS.CreateResultSet("select * from staff where employeeloginname=@0 and employeepassword=@1", EmpLoginName, EmpPassword)
            If DBMS.ReadAndNotEOF(S) Then
                Dim Tmp As New StaffClass
                If Tmp.LoadFromDB(DBMS, EmpLoginName) Then
                    DBMS.CloseResultSet(S)
                    Return Tmp
                Else
                    DBMS.CloseResultSet(S)
                    Return Nothing
                End If
            End If
            DBMS.CloseResultSet(S)
            Return Nothing
        Catch ex As Exception
            DBMS.Rollback()
            Return Nothing
        End Try
    End Function

    ' this function is used to fill the dgv with staff info
    Public Shared Function FillDGVWithStaffInfo(ByVal DGV As DataGridView, ByVal DBMS As DBMSClass) As Boolean
        Try
            ' display all the staff information in the data grid view
            If Not DBMS.FillDataGridViewWithData(DGV, "select * from staff") Then
                Return False
            End If
            DGV.Columns("EmployeePassword").Visible = False
            DGV.Columns("EmployeeLoginName").HeaderText = "Login Name"
            DGV.Columns("EmployeeName").HeaderText = "Full Name"
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

End Class
