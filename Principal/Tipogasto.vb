Public Class Tipogasto

    Dim strtag As String = 0
    Dim strconsulta As String = ""
    Dim con As New conexion()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles txtguardar.Click
        If validarCampos() Then
            strconsulta = "INSERT INTO tipogasto (nombre,descripcion)VALUES('" & txtnombre.Text & "','" & txtDesc.Text & "')"
            If con.registreDatos(strconsulta) Then
                MessageBox.Show("Tipo Registrado con exito", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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
        Else : MessageBox.Show("Debe agregar un nombre al Tipo", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return booSaber
    End Function
    Sub limpiar()
        txtnombre.Focus()
        con.mostrarTipogatos(lstTarifas)
        txtnombre.Text = ""
        txtDesc.Text = ""
        txtModificar.Enabled = False
        txtguardar.Enabled = True
        strconsulta = ""
    End Sub

    Private Sub Tarifas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtModificar.Enabled = False
        con.mostrarTipogatos(lstTarifas)
    End Sub


    Private Sub lstTarifas_MouseClick(sender As Object, e As MouseEventArgs) Handles lstTarifas.MouseClick

    End Sub

    Private Sub lstTarifas_Click(sender As Object, e As EventArgs) Handles lstTarifas.Click
        If lstTarifas.SelectedItems.Count = 0 Then Exit Sub
        strtag = lstTarifas.SelectedItems(0).Tag
        txtnombre.Text = lstTarifas.SelectedItems(0).Text
        txtDesc.Text = lstTarifas.SelectedItems(0).SubItems(1).Text
        txtModificar.Enabled = True
        txtguardar.Enabled = False
        txtnombre.Focus()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles txtModificar.Click
        If Not validarCampos() Then Exit Sub
        strconsulta = "UPDATE tipogasto SET nombre='" & txtnombre.Text & "', descripcion='" & txtDesc.Text & "'  WHERE id ='" & strtag & "'"
        If con.registreDatos(strconsulta) Then
            MessageBox.Show("Tipo actualizado con exito", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        Else
            MessageBox.Show("Ocurrio un error en la actualización", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtLimpiar_Click(sender As Object, e As EventArgs) Handles txtLimpiar.Click
        limpiar()

    End Sub

    Private Sub txtvalor_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtDesc.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtvalor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtdias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtguardar.Enabled Then
                txtguardar.PerformClick()
            Else : txtModificar.PerformClick()
            End If
        End If
    End Sub

    Private Sub txtdias_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged

    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtDesc.Focus()
        End If

    End Sub


    Private Sub lstTarifas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTarifas.SelectedIndexChanged

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged

    End Sub
End Class