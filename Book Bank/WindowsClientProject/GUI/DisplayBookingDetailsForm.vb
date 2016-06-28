Public Class DisplayBookingDetailsForm


    Public DetailsList As List(Of Book_Bank.DetailedQueueEntryClass)



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub DisplayBookingDetailsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For Each ITM In DetailsList

            DGV3.Rows.Add(ITM.StudentOBJ.GetStudentName, ITM.StudentOBJ.GetStudentYear, ITM.BookingOrder)

        Next

    End Sub

    
End Class