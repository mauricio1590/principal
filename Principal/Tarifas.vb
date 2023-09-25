Public Class Tarifas
    Dim strtag As String = 0
    Dim strconsulta As String = ""
    Dim intSpa As Integer = 1
    Dim con As New conexion()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles txtguardar.Click
        If validarCampos() Then
            strconsulta = "INSERT INTO PRECIO (tipo,valor,dias,det)VALUES('" & txtnombre.Text & "','" & txtvalor.Text & "','" & txtdias.Text & "','" & intSpa & "')"
            If con.registreDatos(strconsulta) Then
                MessageBox.Show("Tarfia registrada con exito", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                limpiar()
            Else
                MessageBox.Show("Ocurrio un error en registro", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Function validarCampos() As Boolean
        Dim booSaber As Boolean = False
        If Not txtnombre.Text.Equals("") Then
            If Not txtvalor.Text.Equals("") Then
                If Not txtdias.Text.Equals("") Then
                    booSaber = True
                Else : MessageBox.Show("Debe agregar los dias  a la tarifa", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else : MessageBox.Show("Debe agregar un valor a la tarifa", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else : MessageBox.Show("Debe agregar un nombre a la tarifa", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return booSaber
    End Function
    Sub limpiar()
        txtnombre.Focus()
        con.mostrarTarias(lstTarifas)
        txtnombre.Text = ""
        txtdias.Text = ""
        txtvalor.Text = ""
        txtModificar.Enabled = False
        txtguardar.Enabled = True
        strconsulta = ""
    End Sub

    Private Sub Tarifas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtModificar.Enabled = False
        con.mostrarTarias(lstTarifas)
    End Sub


    Private Sub lstTarifas_MouseClick(sender As Object, e As MouseEventArgs) Handles lstTarifas.MouseClick

    End Sub

    Private Sub lstTarifas_Click(sender As Object, e As EventArgs) Handles lstTarifas.Click
        If lstTarifas.SelectedItems.Count = 0 Then Exit Sub
        strtag = lstTarifas.SelectedItems(0).Tag
        txtnombre.Text = lstTarifas.SelectedItems(0).Text
        txtvalor.Text = lstTarifas.SelectedItems(0).SubItems(1).Text
        txtdias.Text = lstTarifas.SelectedItems(0).SubItems(2).Text
        If lstTarifas.SelectedItems(0).SubItems(3).Text.Equals("SPA") Then
            chkDetalle.Checked = True
        End If

        txtModificar.Enabled = True
        txtguardar.Enabled = False
        txtnombre.Focus()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles txtModificar.Click
        If Not validarCampos() Then Exit Sub
        strconsulta = "UPDATE PRECIO SET tipo='" & txtnombre.Text & "', valor='" & txtvalor.Text & "' , dias='" & txtdias.Text & "',det='" & intSpa & "' WHERE serial ='" & strtag & "'"
        If con.registreDatos(strconsulta) Then
            MessageBox.Show("Tarfia actualizada con exito", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        Else
            MessageBox.Show("Ocurrio un error en la actualización", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtLimpiar_Click(sender As Object, e As EventArgs) Handles txtLimpiar.Click
        limpiar()

    End Sub

    Private Sub txtvalor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvalor.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtdias.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtvalor_TextChanged(sender As Object, e As EventArgs) Handles txtvalor.TextChanged

    End Sub

    Private Sub txtdias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdias.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtguardar.Enabled Then
                txtguardar.PerformClick()
            Else : txtModificar.PerformClick()
            End If
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub txtdias_TextChanged(sender As Object, e As EventArgs) Handles txtdias.TextChanged

    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtvalor.Focus()
        End If
        
    End Sub

    Private Sub chkDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles chkDetalle.CheckedChanged
        If chkDetalle.Checked Then
            intSpa = 5 'control de tarifa por dias 
        Else
            intSpa = 1
        End If
    End Sub

    Private Sub txtEliminar_Click(sender As Object, e As EventArgs) Handles txtEliminar.Click
        If lstTarifas.SelectedItems.Count = 0 Then
            MessageBox.Show("Debe Seleccionar la tarifa que desea eliminar", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            con.registreDatos("DELETE FROM PRECIO WHERE serial='" & lstTarifas.SelectedItems(0).Tag & "'")
            MessageBox.Show("Tarifa eliminada", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        End If
        Exit Sub

    End Sub
End Class