﻿Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports canteen.Form1
Imports canteen.render

Module update_function

    Public Sub update_btn_Click(sender As Object, e As EventArgs)


        dtCustomers = ReadFromDatabase("update buyer_details set product_id='" + Form1.item_field.Text + "',Quantity='" + Form1.quant_field.Text + "',Total='" + Form1.total_field.Text + "'where Ref_no='" + Form1.ref_field.Text + "'")

        LoadDataInGrid()
        Form1.grand_field.Clear()
        render.renderFunction()

    End Sub

End Module
