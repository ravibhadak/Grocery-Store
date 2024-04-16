Imports System.Data.OleDb

Public Class Form1
    Dim cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Z_project sem4\vb.net\Grocery Store\Database.mdb")

    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim adp As New OleDbDataAdapter
    Dim ds As New DataSet


    Public Sub display()
        ds.Clear()
        adp = New OleDbDataAdapter("select * from GroceryMaster", cn)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Z_project sem4\vb.net\Grocery Store\Database.mdb")
        cn.Open()
        display()
        cn.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            cn.Open()
            cmd = New OleDbCommand("insert into GroceryMaster values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')", cn)
            cmd.ExecuteNonQuery()
            display()
            MsgBox("insert successful!")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            cn.Open()
            cmd = New OleDbCommand("update GroceryMaster set ItemNo = '" & TextBox1.Text & "', MRP = '" & TextBox3.Text & "', SellPrice = '" & TextBox4.Text & "', Quantity = '" & TextBox5.Text & "' where [Name] = '" & TextBox2.Text & "'", cn)
            cmd.ExecuteNonQuery()
            display()
            MsgBox("update successful!")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            cn.Open()
            cmd = New OleDbCommand("delete from GroceryMaster where Name='" & TextBox2.Text & "'", cn)
            cmd.ExecuteNonQuery()
            display()
            MsgBox("delete successful!")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            cn.Open()
            cmd = New OleDbCommand("select * from GroceryMaster where ItemNo = '" & TextBox1.Text & "'", cn)

            ' Query to retrieve out-of-stock grocery items
            Dim query As String = "SELECT ItemID, ItemName, StockQuantity " &
                                  "FROM GroceryItems " &
                                  "WHERE OutOfStock = True"
            dr = cmd.ExecuteReader()

            While dr.Read()
                TextBox1.Text = dr.Item(1)
                TextBox2.Text = dr.Item(2)
                TextBox3.Text = dr.Item(3)
                TextBox4.Text = dr.Item(4)
                TextBox5.Text = dr.Item(5)
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()

    End Sub
End Class
