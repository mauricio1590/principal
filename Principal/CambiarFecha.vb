Public Class CambiarFecha
    Dim con As New conexion()


    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not cambiarPago(txtCedula.Text, txtCliente, txtFecha) Then
                MessageBox.Show("EL no corresponde a un cliente con pago registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                txtCedula.Focus()
            End If
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim res = MessageBox.Show("Esta seguro de cambiar la fecha", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If Not res = Windows.Forms.DialogResult.Yes Then Exit Sub
        Dim dato As Array = Split(dtfecha.Value, " ", , 0)
        Dim arlDatos As ArrayList = arrayDatosCambioFecha(txtCedula.Text)
        If arlDatos.Count > 0 Then
            con.registreDatos("INSERT INTO logs (cedula,fechaCorteOld,fechaPagoOld,fechaCorteNew,tarifa,tarifaDias,usuario_id)VALUES('" & txtCedula.Text & "',STR_TO_DATE('" & arlDatos(1) & "','%d/%m/%Y'),STR_TO_DATE('" & arlDatos(2) & "','%d/%m/%Y'),STR_TO_DATE('" & dato(0) & "','%d/%m/%Y'),'" & arlDatos(3) & "','" & arlDatos(4) & "','" & Principal.intidusuario & "')")
        End If


        If con.registreDatos("UPDATE pago SET fecha_corte= STR_TO_DATE('" & dato(0) & "','%d/%m/%Y') WHERE cedula='" & txtCedula.Text & "'") Then
            MessageBox.Show("El cambio de la fecha fue registrado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Dispose()
        Else : MessageBox.Show("Ocurrio un error al cambiar la fecha", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


End Class