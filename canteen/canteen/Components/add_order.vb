
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports canteen.Form1
Imports canteen.Connection
Imports canteen.render
Module add_order


    Public Sub add_btn_Click(sender As Object, e As EventArgs)



        Dim con As SqlConnection = New SqlConnection("Data Source=103.207.1.93;Initial Catalog=canteen;Persist Security Info=True;User ID=mzcanteen;Password=Admin@123")


        If String.IsNullOrWhiteSpace(Form1.Id_field.Text) Then

            If MessageBox.Show("Please Fill All Fields", "Error") Then

                Form1.Id_field.Focus()

            End If




        Else

            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("select Quantity from items where Product_id='" + Form1.item_field.Text + "'", con)
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()

            Dim result = myreader("Quantity")

            If Form1.quant_field.Text > result Then
                con.Close()
                MessageBox.Show("Item Out of Stocks 2", "Error")
                Form1.quant_field.Focus()
                Form1.quant_field.Clear()

            Else

                Dim status As String = "unordered"
                Dim datetime_result As String
                datetime_result = DateAndTime.Now()


                Try

                    dtCustomers = ReadFromDatabase("Insert into Buyer_Details (Bill_no,Spr_no,product_id,quantity,total,status,Date)values('" + Form1.Billingno_field.Text + "','" + Form1.spr_field.Text + "','" + Form1.item_field.Text + "','" + Form1.quant_field.Text + "','" + Form1.total_field.Text + "','" + status + "','" + datetime_result + "')")

                Catch ex As Exception

                    MessageBox.Show("Server Error Please Wait or Try Again", "Error")

                End Try


                If Form1.add_btn.Focus() Then
                    Form1.item_field.Focus()


                End If

                LoadDataInGrid()

                render.renderFunction()


                'getNenaRecords("select sum(total) From buyer_details where bill_no='" + Form1.Billingno_field.Text + "'", "", Form1.grand_field.Text)


                Form1.item_field.Clear()
                Form1.pd_name.Clear()
                Form1.price_field.Clear()

                Form1.quant_field.Clear()
                Form1.total_field.Clear()

                con.Close()


            End If

        End If






    End Sub

End Module
