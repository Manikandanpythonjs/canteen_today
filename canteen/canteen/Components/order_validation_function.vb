Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports canteen.Form1
Imports canteen.pin_form




Module order_validation_function


    Public Sub print_btn_Click(sender As Object, e As EventArgs)



        If String.IsNullOrWhiteSpace(Form1.Id_field.Text) Then

            MessageBox.Show("Please Fill the All Fields", "ERROR")



        Else


            Dim con As SqlConnection = New SqlConnection("Data Source=103.207.1.93;Initial Catalog=canteen;Persist Security Info=True;User ID=mzcanteen;Password=Admin@123")
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("select balance from buyer where id='" + Form1.Id_field.Text + "'", con)
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            Dim result = myreader("balance")

            If Form1.grand_field.Text > result Then
                con.Close()
                MessageBox.Show("Insufficient Balance", "Error")
            Else

                pin_form.ShowDialog()
                Form1.Id_field.Focus()


            End If


        End If

    End Sub


End Module
