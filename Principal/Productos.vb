Public Class Productos
    Dim con As New conexion
    Dim strTag As Integer
    Dim intIDarticuloCambio As Integer = 0
    Dim gestor1 As New Soltec.Gestor

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If validarcampos() Then
            Dim cadena As String = ""
            cadena = "INSERT INTO PRODUCTO (pro_referencia,pro_nombre,pro_preciocosto,pro_precioventa,pro_descripcion,pro_cantidad)VALUES ( '" & txtReferencia.Text & "'" & vbCrLf &
                      ", '" & txtNombre.Text.ToUpper & "',0," & txtVenta.Text & ",'" & txtDescripcion.Text & "',0) "
            If con.registreDatos(cadena) Then
                MessageBox.Show("El articulo fue registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            End If
        End If
    End Sub

    Function validarcampos() As Boolean
        Dim saber As Boolean = False
        If Not txtReferencia.Text.Equals("") Then
            If Not txtNombre.Text.Equals("") Then
                If Not txtVenta.Text.Equals("") Then
                    saber = True
                Else : MessageBox.Show("Es necesario alimentar el precio de venta", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtVenta.Focus()
                End If
            Else : MessageBox.Show("Ingrese el nombre del articulo", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtNombre.Focus()
            End If
        Else : MessageBox.Show("Ingrese Una referencia valida", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtReferencia.Focus()
        End If
        Return saber
    End Function


    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not verifiqueReferencia(txtReferencia.Text) Then
                MessageBox.Show("La referencia ya esta registrada en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                txtNombre.Focus()
            End If
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtVenta.Focus()

        End If

    End Sub
    Sub limpiar()
        txtReferencia.Text = ""
        txtNombre.Text = ""
        txtVenta.Text = ""
        txtDescripcion.Text = ""
        listaArticulos(lstArticulos)
        intIDarticuloCambio = 0
        btnActualizar.Enabled = False
        btnRegistrar.Enabled = True
        txtReferencia.Focus()

    End Sub
    Private Sub txtCosto_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtVenta.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVenta.KeyPress
        If Asc(e.KeyChar) = 13 Then

        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtExistencia_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtDescripcion.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If btnRegistrar.Visible Then
                btnRegistrar.PerformClick()
            Else
                btnActualizar.PerformClick()
            End If
        End If


    End Sub

    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtReferencia.Focus()
        listaArticulos(lstArticulos)
        colorBarras(PanelCabecera)
        btnActualizar.Enabled = False
    End Sub

    Private Sub lstArticulos_Click(sender As Object, e As EventArgs) Handles lstArticulos.Click
        If lstArticulos.SelectedItems.Count = 0 Then Exit Sub
        btnActualizar.Enabled = True
        btnRegistrar.Enabled = False
        strTag = lstArticulos.SelectedItems(0).Tag
        intIDarticuloCambio = strTag
        btnActualizar.Enabled = True
        btnRegistrar.Enabled = False
        llenar(strTag)
        txtReferencia.Focus()
    End Sub

    Public Sub llenar(id As Integer)
        Dim arlDatos As ArrayList = gestor1.DatosDeConsulta("SELECT pro_referencia,pro_nombre,pro_preciocosto,pro_precioventa,pro_cantidad,pro_descripcion FROM producto WHERE id=" & id & "", , Principal.cadenadeconexion)
        If Not arlDatos.Count = 0 Then
            For Each articulo As ArrayList In arlDatos
                txtReferencia.Text = articulo(0)
                txtNombre.Text = articulo(1)
                txtVenta.Text = articulo(3)
                txtDescripcion.Text = articulo(5)
            Next
        End If

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub txtReferencia_TextChanged(sender As Object, e As EventArgs) Handles txtReferencia.TextChanged

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If validarcampos() Then
            Dim cadena As String = ""
            cadena = "UPDATE PRODUCTO  SET pro_referencia='" & txtReferencia.Text & "', pro_nombre= '" & txtNombre.Text.ToUpper & "',pro_precioventa='" & txtVenta.Text & "' ,pro_descripcion='" & txtDescripcion.Text & "' WHERE id='" & intIDarticuloCambio & "'"
            If con.registreDatos(cadena) Then
                MessageBox.Show("El articulo fue Actualizado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            End If
        End If
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        limpiar()
    End Sub


End Class