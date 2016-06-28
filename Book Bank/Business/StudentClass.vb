' this class is used to manage basic student information.

Public Class StudentClass

    ' define the members of the class
    Private StudentID As Long
    Private StudentName As String
    Private StudentIDENT As String
    Private StudentYear As Integer
    Private StudentContact As String
    Private StudentEmail As String
    Private StudentPassword As String
    Private StudentLoginName As String

    Private OldStudentID As Long
    Private OldStudentName As String
    Private OldStudentIDENT As String
    Private OldStudentYear As Integer
    Private OldStudentContact As String
    Private OldStudentEmail As String
    Private OldStudentPassword As String
    Private OldStudentLoginName As String

    ' the setters and getters
    Public Sub SetStudentLoginName(ByVal LoginName As String)
        Me.StudentLoginName = LoginName
    End Sub

    Public Function GetStudentLoginName() As String
        Return Me.StudentLoginName
    End Function


    ' the setters and getters
    Public Sub SetStudentPassword(ByVal PSW As String)
        Me.StudentPassword = PSW
    End Sub

    Public Function GetStudentPassword() As String
        Return Me.StudentPassword
    End Function

    Public Sub SetStudentID(ByVal ID As Long)
        Me.StudentID = ID
    End Sub

    Public Function GetStudentID() As Long
        Return Me.StudentID
    End Function

    Public Sub SetStudentName(ByVal StName As String)
        Me.StudentName = StName
    End Sub

    Public Function GetStudentName() As String
        Return Me.StudentName
    End Function

    Public Sub SetStudentIDENT(ByVal IDENT As String)
        Me.StudentIDENT = IDENT
    End Sub

    Public Function GetStudentIDENT() As String
        Return Me.StudentIDENT
    End Function

    Public Sub SetStudentYear(ByVal Year As Integer)
        Me.StudentYear = Year
    End Sub

    Public Function GetStudentYear() As Integer
        Return Me.StudentYear
    End Function

    Public Sub SetStudentContact(ByVal StContact As String)
        Me.StudentContact = StContact
    End Sub

    Public Function GetStudentContact() As String
        Return Me.StudentContact
    End Function

    Public Sub SetStudentEmail(ByVal StEmail As String)
        Me.StudentEmail = StEmail
    End Sub

    Public Function GetStudentEmail() As String
        Return Me.StudentEmail
    End Function

    ' save the student info into the db
    Public Function InsertIntoDB(ByVal DBMS As DBMSClass, ByVal Commit As Boolean) As Boolean
        Try
            Dim SQL As String
            SQL = "insert into Students ( " & _
                "                       studentid,   " & _
                "                       studentname, " & _
                "                       studentident," & _
                "                       studentyear, " & _
                "                       studentcontact," & _
                "                       studentpassword," & _
                "                       studentloginname," & _
                "                       studentemail ) values (@0,@1,@2,@3,@4,@5,@6,@7)"



            StudentID = GetNextVal()
            DBMS.ExecuteSQL(SQL, StudentID, StudentName, StudentIDENT, StudentYear, StudentContact, StudentPassword, StudentLoginName, StudentEmail)

            If Commit Then
                DBMS.Commit()
            End If

            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to load shelf information from db
    Public Function LoadFromDBByID(ByVal DBMS As DBMSClass, ByVal Student_ID As String) As Boolean
        Try
            ' get the record
            Dim S As String
            S = DBMS.CreateResultSet("select * from students where studentid=@0", Student_ID)
            If DBMS.ReadAndNotEOF(S) Then

                ' fill the object
                Me.StudentID = DBMS.GetColumnValue(S, "studentid")
                Me.StudentContact = DBMS.GetColumnValue(S, "studentcontact")
                Me.StudentEmail = DBMS.GetColumnValue(S, "studentemail")
                Me.StudentIDENT = DBMS.GetColumnValue(S, "studentident")
                Me.StudentName = DBMS.GetColumnValue(S, "studentname")
                Me.StudentYear = DBMS.GetColumnValue(S, "studentyear")
                Me.StudentPassword = DBMS.GetColumnValue(S, "studentpassword")
                Me.StudentLoginName = DBMS.GetColumnValue(S, "studentloginname")

                ' set old =new
                Me.OldStudentContact = Me.StudentContact
                Me.OldStudentEmail = Me.StudentEmail
                Me.OldStudentID = Me.StudentID
                Me.OldStudentIDENT = Me.StudentIDENT
                Me.OldStudentName = Me.StudentName
                Me.OldStudentYear = Me.StudentYear
                Me.OldStudentPassword = Me.StudentPassword
                Me.OldStudentLoginName = Me.StudentLoginName


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

    ' this function is used to load shelf information from db
    Public Function LoadFromDBByLoginName(ByVal DBMS As DBMSClass, ByVal Student_LoginName As String) As Boolean
        Try
            ' get the record
            Dim S As String
            S = DBMS.CreateResultSet("select * from students where studentloginname=@0", Student_LoginName)
            If DBMS.ReadAndNotEOF(S) Then

                ' fill the object
                Me.StudentID = DBMS.GetColumnValue(S, "studentid")
                Me.StudentContact = DBMS.GetColumnValue(S, "studentcontact")
                Me.StudentEmail = DBMS.GetColumnValue(S, "studentemail")
                Me.StudentIDENT = DBMS.GetColumnValue(S, "studentident")
                Me.StudentName = DBMS.GetColumnValue(S, "studentname")
                Me.StudentYear = DBMS.GetColumnValue(S, "studentyear")
                Me.StudentPassword = DBMS.GetColumnValue(S, "studentpassword")
                Me.StudentLoginName = DBMS.GetColumnValue(S, "studentloginname")

                ' set old =new
                Me.OldStudentContact = Me.StudentContact
                Me.OldStudentEmail = Me.StudentEmail
                Me.OldStudentID = Me.StudentID
                Me.OldStudentIDENT = Me.StudentIDENT
                Me.OldStudentName = Me.StudentName
                Me.OldStudentYear = Me.StudentYear
                Me.OldStudentPassword = Me.StudentPassword
                Me.OldStudentLoginName = Me.StudentLoginName


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
            Dim TMP As New StudentClass
            If Not TMP.LoadFromDBByID(DBMS, Me.OldStudentID) Then
                DBMS.Rollback()
                Return "error"
            End If

            ' check if any value was changed
            If TMP.OldStudentContact <> Me.OldStudentContact Then Return "yes"
            If TMP.OldStudentEmail <> Me.OldStudentEmail Then Return "yes"
            If TMP.OldStudentID <> Me.OldStudentID Then Return "yes"
            If TMP.OldStudentIDENT <> Me.OldStudentIDENT Then Return "yes"
            If TMP.OldStudentName <> Me.OldStudentName Then Return "yes"
            If TMP.OldStudentYear <> Me.OldStudentYear Then Return "yes"
            If TMP.OldStudentPassword <> Me.OldStudentPassword Then Return "yes"
            If TMP.OldStudentLoginName <> Me.OldStudentLoginName Then Return "yes"

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
            DBMS.ExecuteSQL("update students set studentid=@0 where studentid=@0 ", Me.OldStudentID)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' update the db
            DBMS.ExecuteSQL("update students set StudentName    =@0 where StudentID=@1", Me.StudentName, Me.OldStudentID)
            DBMS.ExecuteSQL("update students set StudentIDENT   =@0 where StudentID=@1", Me.StudentIDENT, Me.OldStudentID)
            DBMS.ExecuteSQL("update students set StudentYear    =@0 where StudentID=@1", Me.StudentYear, Me.OldStudentID)
            DBMS.ExecuteSQL("update students set StudentContact =@0 where StudentID=@1", Me.StudentContact, Me.OldStudentID)
            DBMS.ExecuteSQL("update students set StudentEmail   =@0 where StudentID=@1", Me.StudentEmail, Me.OldStudentID)
            DBMS.ExecuteSQL("update students set StudentID      =@0 where StudentID=@1", Me.StudentID, Me.OldStudentID)
            DBMS.ExecuteSQL("update students set StudentPassword=@0 where StudentID=@1", Me.StudentPassword, Me.OldStudentID)
            DBMS.ExecuteSQL("update students set StudentLoginName=@0 where StudentID=@1", Me.StudentLoginName, Me.OldStudentID)

            ' commit the changes
            If Commit Then
                DBMS.Commit()
            End If

            ' set old values = new
            Me.OldStudentContact = Me.StudentContact
            Me.OldStudentEmail = Me.StudentEmail
            Me.OldStudentID = Me.StudentID
            Me.OldStudentIDENT = Me.StudentIDENT
            Me.OldStudentName = Me.StudentName
            Me.OldStudentYear = Me.StudentYear
            Me.OldStudentPassword = Me.StudentPassword
            Me.OldStudentLoginName = Me.StudentLoginName

            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to remove a student record from db
    Public Function RemoveFromDB(ByVal DBMS As DBMSClass, ByVal Commit As Boolean) As Boolean
        Try
            ' first lock this record
            DBMS.ExecuteSQL("update students set studentname=@0 where studentname=@0 ", Me.OldStudentName)

            ' check if record was changed
            Dim R = Me.WasRecordChanged(DBMS)
            If R = "error" Or R = "yes" Then
                DBMS.Rollback()
                Return False
            End If

            ' remove the record
            DBMS.ExecuteSQL("delete from students where studentname=@0", Me.OldStudentName)

            If Commit Then
                DBMS.Commit()
            End If
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to fill data grid view with student information
    ' this function is used to fill the dgv with shelves info
    Public Shared Function FillDGVWithStudentInfo(ByVal DGV As DataGridView, ByVal DBMS As DBMSClass) As Boolean
        Try
            ' display all the staff information in the data grid view
            If Not DBMS.FillDataGridViewWithData(DGV, "select StudentID,StudentName,StudentYear,StudentContact,StudentEmail,StudentIDENT,StudentLoginName from students") Then
                Return False
            End If
            DGV.Columns("StudentID").HeaderText = "ID"
            DGV.Columns("StudentName").HeaderText = "Name"
            DGV.Columns("StudentYear").HeaderText = "Year"
            DGV.Columns("StudentContact").HeaderText = "Contact"
            DGV.Columns("StudentEmail").HeaderText = "Email"
            DGV.Columns("StudentIDENT").HeaderText = "Identefication"
            DGV.Columns("StudentLoginName").HeaderText = "Login Name"
            Return True
        Catch ex As Exception
            DBMS.Rollback()
            Return False
        End Try
    End Function

    ' this function is used to fill the combobox with student info
    Public Shared Function FillComboBoxWithStudnetNames(ByVal CMBBox As ComboBox, ByVal DBMS As DBMSClass) As Boolean
        Try
            ' remove all the values displayed in the combobox
            CMBBox.Items.Clear()
            Dim S As String
            S = DBMS.CreateResultSet("select * from students")
            Do While DBMS.ReadAndNotEOF(S)
                CMBBox.Items.Add(DBMS.GetColumnValue(S, "StudentName"))
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
