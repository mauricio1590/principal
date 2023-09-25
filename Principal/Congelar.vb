Public Class Congelar
    Dim con As New conexion()

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not Estacongelado(txtCedula.Text) Then

                If Principal.intCongelarConClaveAdmin = 1 Then
                    If Not Datoscongelado(txtCedula.Text, txtCliente, txtFecha, txtDias) Then
                        MessageBox.Show("Esta cedula no existe en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    If Principal.intCongelarpormes = 1 And Not validarUltimoCongelado(txtCedula.Text) Then
                        MessageBox.Show(" Este cliente se congelo hace menos de 30 dias ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                        limpiar()
                    End If
                    If Not Datoscongelado(txtCedula.Text, txtCliente, txtFecha, txtDias) Then
                        MessageBox.Show("Esta cedula no existe en la base de datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        If Not txtDias.Text >= Principal.intNumeroDiasMinimos Then
                            MessageBox.Show("La cantidad de dias minimos para congelar son " & Principal.intNumeroDiasMinimos & " dias ", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            limpiar()
                        End If
                    End If
                End If


            Else
                MessageBox.Show("Este cliente ya fue congelado", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If
    End Sub
    Private Sub txtCedula_TextChanged(sender As Object, e As EventArgs) Handles txtCedula.TextChanged

    End Sub
    Sub limpiar()
        txtCedula.Text = ""
        txtCliente.Text = ""
        txtDias.Text = ""
        txtFecha.Text = ""
        Me.Dispose()

    End Sub


    Private Sub txtAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not txtCliente.Text.Equals("") Then

            Select Case Principal.intCongelarConClaveAdmin
                Case 1
                    If con.registreDatos("INSERT INTO congelado (cedula,dias,estado) VALUES ('" & txtCedula.Text & "','" & txtDias.Text & "',1)") Then
                        con.registreDatos("UPDATE PAGO set fecha_corte=current_date WHERE cedula='" & txtCedula.Text & "'")
                        limpiar()
                        MessageBox.Show("El cliente se congelo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Else
                        MessageBox.Show("Error al registrar los datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If



                Case 2

                    If Not validarTarifaNocongelable(txtCedula.Text) Then


                        If con.registreDatos("INSERT INTO congelado (cedula,dias,estado) VALUES ('" & txtCedula.Text & "','" & txtDias.Text & "',1)") Then
                            con.registreDatos("UPDATE PAGO set fecha_corte=current_date WHERE cedula='" & txtCedula.Text & "'")
                            limpiar()
                            MessageBox.Show("El cliente se congelo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Else
                            MessageBox.Show("Error al registrar los datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Esta Tarifa no puede ser Congelada", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

            End Select

        Else
            MessageBox.Show("Seleccione un cliente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'txtCedula.Focus()
        End If

    End Sub

    Private Sub Congelar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class