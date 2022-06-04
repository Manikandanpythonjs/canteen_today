Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports canteen.Form1
Module id_field_validation

    Public Sub id_field_validation(sender As Object, e As KeyEventArgs)



        If e.KeyCode = Keys.Enter Then


            If Form1.Id_field.Text = "" Then

                MessageBox.Show("Please Fill The  ID Field", "Empty")

                Form1.Id_field.Focus()
                Form1.Id_field.Clear()

            Else
                Dim con As SqlConnection = New SqlConnection("Data Source=103.207.1.93;Initial Catalog=canteen;Persist Security Info=True;User ID=mzcanteen;Password=Admin@123")
                con.Open()
                Dim checkid As SqlCommand = New SqlCommand("select id from buyer where id='" + Form1.Id_field.Text + "'", con)
                Dim checkreader As SqlDataReader
                checkreader = checkid.ExecuteReader
                checkreader.Read()


                Try

                    If Form1.Id_field.Text.Equals(checkreader("id")) Then

                        con.Close()
                        Try
                            con.Open()
                            Dim cmd As SqlCommand = New SqlCommand("select spr_no,name,department,year,type,balance from buyer where id='" + Form1.Id_field.Text + "'", con)
                            Dim myreader As SqlDataReader
                            myreader = cmd.ExecuteReader
                            myreader.Read()
                            Form1.spr_field.Text = myreader("spr_no")
                            Form1.name_field.Text = myreader("name")
                            Form1.type_field.Text = myreader("type")
                            Form1.dp_field.Text = myreader("department")
                            Form1.year_field.Text = myreader("year")
                            Form1.type_field.Text = myreader("type")
                            Form1.balance_field.Text = myreader("balance")

                            If Form1.balance_field.Text = 0 Then



                                If MessageBox.Show("insufficent Balance", "Error") Then

                                    clear_fields.clear_all_ordered_Click()
                                    Form1.Id_field.Focus()

                                End If

                            Else
                                Form1.item_field.Focus()
                                con.Close()

                            End If



                        Catch ex As Exception

                        End Try

                    Else

                        'Dim con1 As SqlConnection = New SqlConnection("data source=103.207.1.93;initial catalog=canteen;persist security info=true;user id=mzcanteen;password=admin@123")
                        'con.Open()
                        'Dim checkidbalance As SqlCommand = New SqlCommand("select balance from buyer where id='" + Form1.Id_field.Text + "'", con1)
                        'Dim balancereader As SqlDataReader
                        'balancereader = checkidbalance.ExecuteReader
                        'balancereader.Read()



                    End If


                Catch ex As Exception

                    MessageBox.Show("Invalid ID", "Error")
                    Form1.Id_field.Clear()
                    Form1.Id_field.Focus()

                End Try




            End If


        Else

            Exit Sub

        End If

        e.SuppressKeyPress = True


    End Sub

End Module
