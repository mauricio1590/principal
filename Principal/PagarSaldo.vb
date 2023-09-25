Public Class PagarSaldo
    Dim con As New conexion()
    Dim gestor1 As New Soltec.Gestor
    Public strId As String = 0
    Private Sub PagarSaldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Principal.strCedulaGeneral.Equals("") Then
            txtCedula.Text = Principal.strCedulaGeneral
            con.Extraersaldo(Principal.strCedulaGeneral, txtnombre, txtSaldo, txtAbono)
        Else

            txtCedula.Focus()
        End If

        mostrarBancosCuentas(lstBancos)
    End Sub

    Private Sub PagarSaldo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Pago.limipar()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click

        Dim idbanco As Integer = -10
        If lstBancos.SelectedItems.Count = 0 Then : MessageBox.Show("Seleccione un Banco", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub : End If
        idbanco = lstBancos.SelectedItems(0).Tag
        Dim tarjeta As Integer = 1
        If idbanco = 0 Then
            tarjeta = 2
        End If
        saberidAbono(txtCedula.Text)
        If con.registreDatos("INSERT INTO detalles (cedula,fecha_pago,fecha_fin,tiempo,valor,tarjeta,banco)VALUES " & vbCrLf &
                             "('" & txtCedula.Text & "',CURRENT_DATE,'" & Now.Date & "','SALDO','" & txtAbono.Text & "'," & tarjeta & ",'" & idbanco & "')") Then
            Dim strCadena As String = "UPDATE abonos set abono=(abono +" & txtAbono.Text & ") ,saldo= (saldo -" & txtAbono.Text & "),tipo=(tipo+1) WHERE idabonos='" & strId & "' "

            con.registreDatos(strCadena)
            con.registreDatos("UPDATE abonos SET dia=5 WHERE cedula='" & txtCedula.Text & "'")
            registreMovimiento(2, 0, txtSaldo.Text, Principal.intidusuario)
            con.registreDatos("DELETE FROM abonos WHERE saldo =0")
            MessageBox.Show("El pago se Acturalizo Exitosamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Dispose()
        Else : MessageBox.Show("Ocurrio un error en el proceso", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Sub saberidAbono(strcedula As String)

        Dim arlCoincidencias = gestor1.DatosDeConsulta("SELECT idabonos from abonos where cedula ='" & strcedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each registro As ArrayList In arlCoincidencias
                strId = registro(0)
            Next
        End If

    End Sub

    Private Sub txtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not con.Extraersaldo(txtCedula.Text, txtnombre, txtSaldo, txtAbono) Then
                MessageBox.Show("Este cliente no tiene deudas registradas", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
End Class