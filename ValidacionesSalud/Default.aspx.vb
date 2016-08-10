Imports System.Data
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

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
        'Longitudmax()
        'ClientScript.RegisterStartupScript(Me.GetType(), "sweetAlert('Oops...', 'Something went wrong!', 'error');", True)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path As String = FileUpload1.PostedFile.FileName
        Dim x As String = "C:/Users/Win10/Dropbox/Guardados/"
        Dim source As String = ""
        'Inconveniente, el fileupload no da la ruta completa y no se guarda en /temo, tuve que colocar una ruta estatica para que sirviera el proyecto
        If Not String.IsNullOrEmpty(path) Then
            con.Open()
            source = x + path
            Dim cmd As MySqlCommand = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            'cmd.CommandText = "LOAD DATA LOCAL INFILE " + "'" + source + "'" + " INTO TABLE datosusutext FIELDS TERMINATED BY ',' ENCLOSED BY " + "'" + "\" + Chr(34) + "'" + " ESCAPED BY " + "'" + "\" + "\" + "'"
            cmd.CommandText = "LOAD DATA LOCAL INFILE " + "'" + source + "'" + " INTO TABLE datosusutext FIELDS TERMINATED BY ','"
            cmd.ExecuteNonQuery()
            con.Close()
        ElseIf String.IsNullOrEmpty(path) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Debe seleccionar un archivo .txt');", True)
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

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i, j As Integer
        Dim myData As New DataSet
        Dim myAdapter As New MySqlDataAdapter
        Dim xlap As New Excel.Application()
        xlap.Visible = True
        Dim misvalue As Object = System.Reflection.Missing.Value
        Dim xlworkbook As Excel.Workbook = xlap.Workbooks.Add(misvalue)
        Dim xlworksheet As Excel.Worksheet = CType(xlworkbook.Sheets(1), Excel.Worksheet)

        con.Open()
        Dim cmd As MySqlCommand = con.CreateCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PA_selectusuerrores"
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(myData)

        For i = 1 To myData.Tables(0).Rows.Count - 1
            For j = 1 To myData.Tables(0).Columns.Count - 1
                xlworksheet.Cells(i + 1, j + 1) = myData.Tables(0).Rows(i).Item(j)
            Next
        Next

        xlworksheet.SaveAs("D:\doc.xlsx")
        xlworkbook.Close()
        xlap.Quit()

        Myobject(xlap)
        Myobject(xlworkbook)
        Myobject(xlworksheet)

        Label2.Text = "Guardado excel en D:\\"

        Dim cmd2 As New MySqlCommand("PA_truncatedatosusuerrores", con)
        cmd2.CommandType = CommandType.StoredProcedure
        cmd2.ExecuteNonQuery()



        Dim cmd3 As New MySqlCommand("PA_truncatedatosusutext", con)
        cmd3.CommandType = CommandType.StoredProcedure
        cmd3.ExecuteNonQuery()

        con.Close()

    End Sub

    Private Sub Myobject(ByVal obj As Object)
        Marshal.ReleaseComObject(obj)
        obj = Nothing
    End Sub


End Class