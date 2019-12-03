Imports System.Data.OleDb
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.DataTable
Public Class Form3
    Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=../../../db/Database.accdb"
    Dim MyConn As OleDbConnection = New OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet = New DataSet
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource
    Dim reader As OleDbDataReader
    Dim command As OleDbCommand
    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MyConn = New OleDbConnection
        MyConn.ConnectionString = connString
        ds = New DataSet
        tables = ds.Tables
        da = New OleDbDataAdapter("Select * from [StudentList]", MyConn) 'Change items to your database name
        Dim cb = New OleDbCommandBuilder(da)
        cb.QuotePrefix = "["
        cb.QuoteSuffix = "]"
        da.Fill(ds, "StudentList") 'Change items to your database name
        Dim view As New DataView(tables(0))
        source1.Filter = ""
        source1.DataSource = view
        DataGridView1.DataSource = view
        TextBox1.Clear()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBox1.Clear()
        source1.Filter = ""
        DataGridView1.Refresh()
        da.Update(ds, "StudentList")
        MsgBox("SAVE")
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            da.Update(ds, "StudentList")
            If DataGridView1.SelectedCells.Item(0).Value <= "0" Then
                DataGridView1.SelectedCells.Item(0).Value = "1"
                da.Update(ds, "StudentList")
            ElseIf DataGridView1.SelectedCells.Item(0).Value <= "1" Then
                DataGridView1.SelectedCells.Item(0).Value = "0"
                da.Update(ds, "StudentList")
            Else
                da.Update(ds, "StudentList")
            End If
            da.Update(ds, "StudentList")
        Catch ex As Exception
            da.Update(ds, "StudentList")
        End Try
        da.Update(ds, "StudentList")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        source1.Filter = ""
        TextBox1.Clear()
        MyConn = New OleDbConnection
        MyConn.ConnectionString = connString
        ds = New DataSet
        tables = ds.Tables
        da = New OleDbDataAdapter("Select * from [StudentList]", MyConn) 'Change items to your database name
        Dim cb = New OleDbCommandBuilder(da)
        cb.QuotePrefix = "["
        cb.QuoteSuffix = "]"
        da.Fill(ds, "StudentList") 'Change items to your database name
        Dim view As New DataView(tables(0))
        source1.DataSource = view
        DataGridView1.DataSource = view
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        source1.Filter = "[Subject] = '" & TextBox1.Text & "'"
        DataGridView1.Refresh()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class