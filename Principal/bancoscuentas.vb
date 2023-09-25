Public Class bancoscuentas
    Dim strtag As String = 0
    Dim strconsulta As String = ""
    Dim con As New conexion()
    Private Sub txtguardar_Click(sender As Object, e As EventArgs) Handles txtguardar.Click
        If validarCampos() Then
            strconsulta = "INSERT INTO bancoscuentas (no,descripcion)VALUES('" & txtnombre.Text & "','" & txtDesc.Text & "')"
            If con.registreDatos(strconsulta) Then
                MessageBox.Show("Banco con exito", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            Else
                MessageBox.Show("Ocurrio un error en registro", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Function validarCampos() As Boolean
        Dim booSaber As Boolean = False
        If Not txtnombre.Text.Equals("") Then
            booSaber = True
        Else : MessageBox.Show("Debe agregar un no", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return booSaber
    End Function

    Sub limpiar()
        txtnombre.Focus()
        mostrarBancosCuentas(lstBancos)
        txtnombre.Text = ""
        txtDesc.Text = ""
        txtModificar.Enabled = False
        txtguardar.Enabled = True
        strconsulta = ""
    End Sub

    Private Sub bancoscuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtModificar.Enabled = False
        mostrarBancosCuentas(lstBancos)
    End Sub

    Private Sub txtModificar_Click(sender As Object, e As EventArgs) Handles txtModificar.Click
        If Not validarCampos() Then Exit Sub
        strconsulta = "UPDATE bancoscuentas SET no='" & txtnombre.Text & "', descripcion='" & txtDesc.Text & "'  WHERE id ='" & strtag & "'"
        If con.registreDatos(strconsulta) Then
            MessageBox.Show("Banco actualizado con exito", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        Else
            MessageBox.Show("Ocurrio un error en la actualización", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lstBancos_MouseClick(sender As Object, e As MouseEventArgs) Handles lstBancos.MouseClick
        If lstBancos.SelectedItems.Count = 0 Then Exit Sub
        strtag = lstBancos.SelectedItems(0).Tag
        txtnombre.Text = lstBancos.SelectedItems(0).Text
        txtDesc.Text = lstBancos.SelectedItems(0).SubItems(1).Text
        txtModificar.Enabled = True
        txtguardar.Enabled = False
        txtnombre.Focus()
    End Sub
End Class