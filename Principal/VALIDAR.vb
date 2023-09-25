Public Class VALIDAR
    Dim con As New conexion()
    Private Sub txtpass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim validado As Boolean = False
            Principal.booReporte = False
            Select Case Principal.intValidar
                Case 1
                    If validarContraseña2(txtpass.Text, 4) Then
                        Dim tar As New Tarifas()
                        validado = True
                        tar.ShowDialog()
                    End If
                Case 2
                    If validarContraseña2(txtpass.Text, 4) Then
                        Dim cam As New CambiarFecha()
                        cam.ShowDialog()
                        validado = True
                    End If
                Case 3
                    If validarContraseña(txtpass.Text) Then
                        Principal.validado = True
                        validado = True
                    End If
                Case 4
                    If validarContraseña2(txtpass.Text, 4) Then
                        Dim configuracion As New Configuracion()
                        configuracion.ShowDialog()
                        validado = True
                    End If
                Case 5
                    If validarContraseña2(txtpass.Text, 4) Then
                        validado = True
                        Principal.booReporte = True
                    End If
                Case 6
                    If validarContraseña2(txtpass.Text, 4) Then
                        validado = True
                        Principal.booEliminarDetalle = True
                    End If
                Case 7
                    If validarContraseña2(txtpass.Text, 4) Then
                        Principal.booEliminarDetalle = True
                        validado = True
                    End If
                Case 8
                    If validarContraseña2(txtpass.Text, 4) Then
                        Dim strFactura As String = InputBox("Escriba los dias a reponer", "Mensaje del sistema")
                        EliminarFactura(strFactura)
                    End If
                Case 9
                    If validarContraseña2(txtpass.Text, 4) Then
                        actualiceLicencia()
                        validado = True
                    End If
                Case 10
                    If validarContraseña2(txtpass.Text, 4) Then
                        Dim cong As New Congelar()
                        cong.ShowDialog()
                        validado = True
                    End If
                Case 11
                    If validarContraseña2(txtpass.Text, 4) Then
                        validado = True
                        Principal.booReporte = True
                    End If
            End Select
            If Not validado Then
                MessageBox.Show("Contraseña incorrecta", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
            Me.Dispose()
        End If

    End Sub

    Private Sub txtpass_TextChanged(sender As Object, e As EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub VALIDAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class