Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class firmaAcompañante
    Dim con As New conexion

    Dim bm As Bitmap
    Dim g As Graphics
    Dim paintd As Boolean = False
    Dim px As Point
    Dim py As Point
    Dim p As New Pen(Color.Black, 3)
    Dim index As Integer
    Dim DATOS As IDataObject
    Dim IMAGEN As Image
    Public hHwnd As Integer ' Handle to preview window
    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Dim strCedulaCliente As String = ""
    Dim strFirma As String
    Private Sub firmar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Bounds = Screen.FromPoint(MousePosition).Bounds
        iniciar()


    End Sub
    Sub iniciar()
        bm = New Bitmap(pic.Width, pic.Height)
        g = Graphics.FromImage(bm)
        g.Clear(Color.White)

        pic.Image = bm
    End Sub
    Private Sub pic_MouseDown(sender As Object, e As MouseEventArgs) Handles pic.MouseDown
        paintd = True
        py = e.Location
    End Sub

    Private Sub pic_MouseMove(sender As Object, e As MouseEventArgs) Handles pic.MouseMove
        If paintd = True Then
            If index = 1 Then
                px = e.Location
                g.DrawLine(p, px, py)
                py = px
            End If
        End If
        pic.Refresh()
    End Sub

    Private Sub pic_MouseUp(sender As Object, e As MouseEventArgs) Handles pic.MouseUp
        paintd = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strCedula = InputBox("Escriba una cedula", "Mensaje del Sistema")
        If Not ValideCedulaExistente(strCedula, "cliente") Then : MessageBox.Show("Documento No Registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : End If
        If Not strCedula.Equals("") Then
            strCedulaCliente = strCedula
            index = 1
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim foto As Image = pic.Image
        If foto Is Nothing Then

        End If
        bm = foto
        Dim strHora As String = Now.ToString.Replace(".", "_").Replace("/", "_").Replace(" ", "_").Replace(":", "_")
        strFirma = Principal.strunidad & ":\SISTEMGYM_DATOS\fotos\" & Now.Day & "_" & con.saberNombreporCedula(strCedulaCliente) & "_" & strCedulaCliente & strHora & ".jpg"
        '   pic.Image.Save(strFirma, Drawing.Imaging.ImageFormat.Jpeg)
        bm.Save(strFirma)
        registre(strCedulaCliente, strFirma)
        iniciar()
        MessageBox.Show("Registro Exitoso", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        iniciar()


    End Sub

    Sub registre(strCedula, ruta)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidor
        Builderconex.UserID = Principal.usuario
        Builderconex.Password = Principal.password
        Builderconex.Database = Principal.database
        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()
        cmd = conexion.CreateCommand()
        cmd.CommandText = "update cliente set instructor=? where cedula='" & strCedula & "' "
        cmd.Parameters.AddWithValue("ruta", ruta)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        conexion.Close()
        conexion.Dispose()
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub pic_Click(sender As Object, e As EventArgs) Handles pic.Click

    End Sub
End Class