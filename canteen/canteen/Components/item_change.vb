Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports canteen.Form1
Module item_change
    Public Sub item_field_TextChanged(sender As Object, e As EventArgs)
        Dim con As SqlConnection = New SqlConnection("Data Source=103.207.1.93;Initial Catalog=canteen;Persist Security Info=True;User ID=mzcanteen;Password=Admin@123")

        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("select product_id,product_name,price,Quantity from items where product_id='" + Form1.item_field.Text + "'", con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()



        Try

            If Form1.item_field.Text.Equals(myreader("product_id")) Then

                Dim result = myreader("Quantity")
                Form1.pd_name.Text = myreader("product_name")

                Form1.price_field.Text = myreader("price")

                If result = 0 Then
                    con.Close()
                    MessageBox.Show("Item Out of Stocks", "Error")
                    Form1.item_field.Clear()
                    Form1.quant_field.Clear()
                    Form1.price_field.Clear()
                    Form1.pd_name.Clear()
                    Form1.item_field.Focus()

                End If


            Else




            End If





        Catch ex As Exception

            Form1.item_field.Clear()
            MessageBox.Show("Item Not Found", "Error")

            Form1.item_field.Focus()



        End Try
        con.Close()
        con.Open()
        transdatagrid()
        con.Close()




    End Sub
End Module
