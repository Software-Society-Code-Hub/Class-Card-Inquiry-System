Imports System.IO
Imports System.Data.OleDb
Public Class Form2
    Dim provider As String
    Dim dataFile As String
    Dim conString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/Database.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("Select * FROM [StudentList] WHERE [BarCode] = '" & TextBox1.Text & "' AND [Subject] = '" & TextBox2.Text & "'", myConnection)


        Dim dr As OleDbDataReader = cmd.ExecuteReader


        Dim Name As String = ""
        Dim Course As String = ""
        Dim SpecialKey As String = ""

        While dr.Read
            Name = dr("Names").ToString
            Course = dr("YearandCourse").ToString
            SpecialKey = dr("SpecialKey").ToString

        End While
        myConnection.Close()
        myConnection.Open()

        myConnection.Close()
        Label1.Text = Name
        Label2.Text = Course
        Label3.Text = SpecialKey

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
        dataFile = "../../db/Database.accdb"
        conString = provider & dataFile
        myConnection.ConnectionString = conString
        myConnection.Open()
        Dim cardReleased As String
        cardReleased = "Released"

        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE StudentList SET[ClassCard] = '" & cardReleased & "' WHERE [Subject] = '" & TextBox2.Text & "'", myConnection)
        Dim dm As OleDbDataReader = cmd.ExecuteReader


        myConnection.Close()

        TextBox1.Clear()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        MsgBox("Credentials Claim")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub
End Class