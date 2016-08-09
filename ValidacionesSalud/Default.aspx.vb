Imports System.Data
Imports MySql.Data.MySqlClient

Public Class _Default
    Inherits Page

    Dim con As New MySqlConnection("Data Source=localhost; Database=validaciones; User Id=root; Password=''")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click1(sender As Object, e As EventArgs) Handles Button3.Click
        con.Open()
        Dim cmd As MySqlCommand = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "truncate prueba"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class