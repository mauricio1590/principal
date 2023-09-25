Public Class Personalizado
    Dim Gestor1 As New Soltec.Gestor
    Dim con As New conexion
    Dim intIdPersona As String
    Dim intIdEmpleado As String
    Dim intIdHora As String

    Private Sub btncerrar_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub Personalizado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNameEmleado.Focus()
    End Sub

    

    Private Sub txtnameCliente_TextChanged(sender As Object, e As EventArgs) Handles txtnameCliente.TextChanged
        If txtnameCliente.Text = "" Then Exit Sub
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id, CONCAT(nombre,' ',apellido) FROM cliente WHERE nombre LIKE '%" & txtnameCliente.Text & "%' ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstNombresCliente.Visible = True
        lstNombresCliente.Items.Clear()
        lstNombresCliente.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstNombresCliente.Items.Add(lviEncontrado)
        Next
        lstNombresCliente.EndUpdate()
    End Sub

    Private Sub txtNameEmleado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNameEmleado.KeyDown
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstNombresE.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstNombresE.Visible Then
                    SeñaleItemListView(lstNombresE, lstNombresE.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstNombresE.Visible Then
            SeñaleItemListView(lstNombresE, intMovimiento)
            Exit Sub
        End If
        txtNameEmleado.Select(txtNameEmleado.Text.Length + 1, 0)
    End Sub

    Private Sub txtnameCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnameCliente.KeyDown
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstNombresCliente.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstNombresCliente.Visible Then
                    SeñaleItemListView(lstNombresCliente, lstNombresCliente.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstNombresCliente.Visible Then
            SeñaleItemListView(lstNombresCliente, intMovimiento)
            Exit Sub
        End If
        txtnameCliente.Select(txtnameCliente.Text.Length + 1, 0)
    End Sub

    Private Sub txtNameEmleado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNameEmleado.KeyPress
        If lstNombresE.SelectedItems.Count = 0 Then Exit Sub
        intIdEmpleado = lstNombresE.SelectedItems(0).Tag
        txtNameEmleado.Text = lstNombresE.SelectedItems(0).Text
        txtnameCliente.Focus()
        lstNombresE.Visible = False
        con.VisualizarRortes(lstPersonalizados, Now.Date, Now.Date, 500, txtTotales, , , , , intIdEmpleado)

    End Sub

    Private Sub btncerrar_Click_1(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub txtnameCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnameCliente.KeyPress
        If lstNombresCliente.SelectedItems.Count = 0 Then Exit Sub
        intIdPersona = lstNombresCliente.SelectedItems(0).Tag
        txtnameCliente.Text = lstNombresCliente.SelectedItems(0).Text
        txtHora.Focus()
        lstNombresCliente.Visible = False
    End Sub

 

    Private Sub txtHora_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHora.KeyDown
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstHoras.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstHoras.Visible Then
                    SeñaleItemListView(lstHoras, lstHoras.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstHoras.Visible Then
            SeñaleItemListView(lstHoras, intMovimiento)
            Exit Sub
        End If
        txtHora.Select(txtHora.Text.Length + 1, 0)
    End Sub

    Private Sub txtHora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHora.KeyPress
        If lstHoras.SelectedItems.Count > 0 Then
            registre()
        End If


    End Sub

    Private Sub CV(sender As Object, e As EventArgs) Handles lstHoras.SelectedIndexChanged

    End Sub



    Private Sub lstNombresE_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombresE.MouseClick
        If lstNombresE.SelectedItems.Count = 0 Then Exit Sub
        intIdEmpleado = lstNombresE.SelectedItems(0).Tag
        txtNameEmleado.Text = lstNombresE.SelectedItems(0).Text
        txtnameCliente.Focus()
        lstNombresE.Visible = False
        con.VisualizarRortes(lstPersonalizados, Now.Date, Now.Date, 500, txtTotales, , , , , intIdEmpleado)
    End Sub

    Private Sub lstNombresCliente_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombresCliente.MouseClick
        If lstNombresCliente.SelectedItems.Count = 0 Then Exit Sub
        intIdPersona = lstNombresCliente.SelectedItems(0).Tag
        txtnameCliente.Text = lstNombresCliente.SelectedItems(0).Text
        txtHora.Focus()
        lstNombresCliente.Visible = False
    End Sub

    Private Sub lstHoras_MouseClick(sender As Object, e As MouseEventArgs) Handles lstHoras.MouseClick
        intIdHora = lstHoras.SelectedItems(0).Tag
        registre()
        
    End Sub
    Public Sub registre()
        If lstHoras.SelectedItems.Count = 0 Then Exit Sub

        intIdHora = lstHoras.SelectedItems(0).Tag
        If TieneIntructor(intIdEmpleado, intIdPersona) = 0 Then
            con.registreDatos("INSERT INTO personalizado (empleado_id,persona_id,hora_id) values ('" & intIdEmpleado & "','" & intIdPersona & "','" & intIdHora & "')")
            con.VisualizarRortes(lstPersonalizados, Now.Date, Now.Date, 500, txtTotales, , , , , intIdEmpleado)
            MessageBox.Show("El registro se Realizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            txtHora.Text = ""
            txtnameCliente.Text = ""
            txtNameEmleado.Text = ""
            lstHoras.SelectedItems.Clear()
            lstHoras.Visible = False

        Else
            Exit Sub
        End If
    End Sub
    Private Sub lstPersonalizados_MouseClick(sender As Object, e As MouseEventArgs) Handles lstPersonalizados.MouseClick
        Dim idPersonalizado As String = lstPersonalizados.SelectedItems(0).Text
        Dim res = MessageBox.Show("Desea Eliminar el horario ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If res = Windows.Forms.DialogResult.Yes Then
            con.registreDatos("DELETE FROM personalizado WHERE id='" & idPersonalizado & "'")
            con.VisualizarRortes(lstPersonalizados, Now.Date, Now.Date, 500, txtTotales, , , , , intIdEmpleado)
        End If

    End Sub

  
    Private Sub txtNameEmleado_TextChanged(sender As Object, e As EventArgs) Handles txtNameEmleado.TextChanged
        If txtNameEmleado.Text = "" Then Exit Sub
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id, CONCAT(nombre,' ',apellido) FROM EMPLEADO WHERE nombre LIKE '%" & txtNameEmleado.Text & "%' ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstNombresE.Visible = True
        lstNombresE.Items.Clear()
        lstNombresE.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstNombresE.Items.Add(lviEncontrado)
        Next
        lstNombresE.EndUpdate()
    End Sub

    Private Sub txtHora_TextChanged(sender As Object, e As EventArgs) Handles txtHora.TextChanged
        If txtHora.Text = "" Then Exit Sub
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id, nombre  FROM hora WHERE nombre LIKE '%" & txtHora.Text & "%' ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstHoras.Visible = True
        lstHoras.Items.Clear()
        lstHoras.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstHoras.Items.Add(lviEncontrado)
        Next
        lstHoras.EndUpdate()
    End Sub

    Private Sub txtExportar_Click(sender As Object, e As EventArgs) Handles txtExportar.Click
        Dim SaveFileDialog1 As New Windows.Forms.SaveFileDialog
        SaveFileDialog1.DefaultExt = "*.csv"
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos CSV de Excel (*.csv|*.csv"
        SaveFileDialog1.ShowDialog()
        GuardeEnArchivo(ListViewACsv(lstPersonalizados, True), SaveFileDialog1.FileName, True)
    End Sub
End Class