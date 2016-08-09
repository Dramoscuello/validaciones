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
        Ceros_izquierda()
        Sexo_Hombre_Mal()
        Sexo_Mujer_Mal()
        Edadnodocumento()
        Identificacionrepetida()
        Identificacionvacia()
        Primerapellidovacio()
        Pnombrevacio()
        Sexonoexiste()
        Tipodocnoexiste()
        Umenoexiste()
        Longitudmax()
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

    Protected Sub Ceros_izquierda()
        con.Open()
        Dim cmd As New MySqlCommand("PA_ceros", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Sexo_Hombre_Mal()
        con.Open()
        Dim cmd As New MySqlCommand("PA_sexohombremal", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Sexo_Mujer_Mal()
        con.Open()
        Dim cmd As New MySqlCommand("PA_sexomujermal", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Edadnodocumento()
        con.Open()
        Dim cmd As New MySqlCommand("PA_identificacionerronea", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Identificacionrepetida()
        con.Open()
        Dim cmd As New MySqlCommand("PA_identificacionesrepetidas", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Identificacionvacia()
        con.Open()
        Dim cmd As New MySqlCommand("PA_identificaciovacia", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Primerapellidovacio()
        con.Open()
        Dim cmd As New MySqlCommand("PA_papellidovacio", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Pnombrevacio()
        con.Open()
        Dim cmd As New MySqlCommand("PA_pnombrevacio", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Sexonoexiste()
        con.Open()
        Dim cmd As New MySqlCommand("PA_sexonoexiste", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Tipodocnoexiste()
        con.Open()
        Dim cmd As New MySqlCommand("PA_tipodocumentonoexiste", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Umenoexiste()
        con.Open()
        Dim cmd As New MySqlCommand("PA_umenoexiste", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub Longitudmax()
        con.Open()
        Dim cmd As New MySqlCommand("PA_logitudmax", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class