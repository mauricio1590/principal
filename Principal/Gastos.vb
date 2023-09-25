Public Class Gastos
    Dim lsttag As Integer = -1
    Dim Gestor1 As New Soltec.Gestor()
    Dim con As New conexion()
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub txtTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTipo.KeyDown
        lstTipo.Visible = True
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstTipo.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstTipo.Visible Then
                    SeñaleItemListView(lstTipo, lstTipo.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstTipo.Visible Then
            SeñaleItemListView(lstTipo, intMovimiento)
            Exit Sub
        End If
        txtTipo.Select(txtTipo.Text.Length + 1, 0)
    End Sub
    Public Sub SeñaleItemListView(Lista As ListView, Indice As Integer, Optional EsMovimiento As Boolean = True, Optional EsUnicoSeñalado As Boolean = True)
        If Lista.Items.Count = 0 Then Exit Sub
        Dim intIndiceSeñaladoAnterior As Integer = 0
        If Not Lista.SelectedItems.Count = 0 Then
            intIndiceSeñaladoAnterior = Lista.SelectedItems(0).Index
        Else
            Lista.Items(0).Selected = True
            Lista.Items(0).EnsureVisible()
            If EsUnicoSeñalado Then Exit Sub
        End If
        If EsUnicoSeñalado Then
            For Each Item As ListViewItem In Lista.Items
                Item.Selected = False
            Next
        End If
        If Not EsMovimiento Then
            If Indice < 0 Or Indice > Lista.Items.Count - 1 Then Exit Sub
            Lista.Items(Indice).Selected = True
            Lista.Items(Indice).EnsureVisible()
        Else
            If Indice < 0 Then
                If Not intIndiceSeñaladoAnterior + Indice < 0 Then
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).Selected = True
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).EnsureVisible()
                End If
            End If
            If Indice > 0 Then
                If Not intIndiceSeñaladoAnterior + Indice > Lista.Items.Count - 1 Then
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).Selected = True
                    Lista.Items(intIndiceSeñaladoAnterior + Indice).EnsureVisible()
                End If
            End If
        End If
    End Sub
    Private Sub txtTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTipo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If lstTipo.SelectedItems.Count = 0 Then Exit Sub
            lsttag = lstTipo.SelectedItems(0).Tag
            txtTipo.Text = lstTipo.SelectedItems(0).Text
            lstTipo.Visible = False
            txtValor.Focus()

        End If
    End Sub

    Private Sub txtTipo_TextChanged(sender As Object, e As EventArgs) Handles txtTipo.TextChanged

    End Sub

    Private Sub Gastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtTipo.Focus()
        lstTipo.Visible = True
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,nombre FROM tipogasto", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstTipo.Visible = True
        lstTipo.Items.Clear()
        lstTipo.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstTipo.Items.Add(lviEncontrado)
        Next

        lstTipo.EndUpdate()
        lstTipo.Items(4).Selected = True
        Timer1.Enabled = True
        colorBarras(PanelCabecera)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValor.KeyPress
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
            If Not txtValor.Text.Equals("") Then
                If Not lstTipo.SelectedItems.Count = 0 Then
                    If con.registreDatos("INSERT INTO gastos (idtipo,descripcion,valor,fecha) VALUES  ('" & lsttag & "','" & txtDescripcion.Text & "','" & txtValor.Text & "',current_date)") Then
                        registreMovimiento(4, 1, txtValor.Text, Principal.intidusuario)
                        MessageBox.Show("El gasto fue registrado correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        limpiar()
                    End If
                Else : MessageBox.Show("Seleccione un tipo de gasto", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtTipo.Focus() : Exit Sub
                End If
            Else
                MessageBox.Show("Ingrese Un valor para el gasto", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtValor.Focus() : Exit Sub
            End If
        End If
    End Sub

    Sub limpiar()
        txtDescripcion.Text = ""
        txtValor.Text = ""
        txtTipo.Text = ""
        VisualizarPagos(lstgastos, 1, txtTotal)
        txtTipo.Focus()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        VisualizarPagos(lstgastos, 1, txtTotal)
        Timer1.Enabled = False
    End Sub

    Private Sub lstTipo_MouseClick(sender As Object, e As MouseEventArgs) Handles lstTipo.MouseClick
        If lstTipo.SelectedItems.Count = 0 Then Exit Sub
        lsttag = lstTipo.SelectedItems(0).Tag
        txtTipo.Text = lstTipo.SelectedItems(0).Text
        lstTipo.Visible = False
        txtValor.Focus()
    End Sub
End Class