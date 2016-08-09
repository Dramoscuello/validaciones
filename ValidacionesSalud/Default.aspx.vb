Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.IO

Public Class _Default
    Inherits Page

    Dim con As New MySqlConnection("Data Source=localhost; Database=validaciones; User Id=root; Password=''")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click1(sender As Object, e As EventArgs) Handles Button3.Click
        'con.Open()
        'Dim cmd As MySqlCommand = con.CreateCommand()
        'cmd.CommandType = CommandType.Text
        'cmd.CommandText = "truncate prueba"
        'cmd.ExecuteNonQuery()
        'con.Close()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path As String = "C:\\Users\\Win10\\Dropbox\\Guardados\\" + FileUpload1.PostedFile.FileName
        If Not String.IsNullOrEmpty(path) Then
            con.Open()
            Dim cmd As MySqlCommand = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "LOAD DATA LOCAL INFILE " + "'" + path + "'" + " INTO TABLE datosusutext FIELDS TERMINATED BY ',' ENCLOSED BY " + "'" + "\" + Chr(34) + "'" + " ESCAPED BY " + "'" + "\" + "\" + "'"
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub
End Class