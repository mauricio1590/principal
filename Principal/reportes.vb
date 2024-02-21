
Imports System.IO




Public Class reportes

    Dim con As New conexion()
    Dim lsttag As Integer = -1
    Dim reporte As String = ""
    Dim intTarjeta As Integer = 2


    Dim Gestor1 As New Soltec.Gestor
    Dim Stream As Object

    Private Sub reportes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub txtReporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReporte.KeyDown
        lstreporte.Visible = True
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstreporte.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstreporte.Visible Then
                    SeñaleItemListView(lstreporte, lstreporte.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstreporte.Visible Then
            SeñaleItemListView(lstreporte, intMovimiento)
            Exit Sub
        End If
        txtReporte.Select(txtReporte.Text.Length + 1, 0)
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
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReporte.KeyPress

        If Asc(e.KeyChar) = 13 Then
            BuscarAccion()
        End If
    End Sub

    Sub BuscarAccion()
        If lstreporte.SelectedItems.Count = 0 Then Exit Sub
        lsttag = lstreporte.SelectedItems(0).Tag
        If lsttag = 1 Or lsttag = 12 Then
            chkTarjeta.Visible = True
        Else
            chkTarjeta.Visible = True
        End If

        If lsttag = 7 Then
            Principal.intValidar = 5
            Dim validar As New VALIDAR
            validar.ShowDialog()
            If Principal.booReporte Then
                txtReporte.Text = lstreporte.SelectedItems(0).Text
                reporte = lstreporte.SelectedItems(0).Text
                lstreporte.Visible = False
                buscarDatos()
            End If
        Else
            txtReporte.Text = lstreporte.SelectedItems(0).Text
            reporte = lstreporte.SelectedItems(0).Text
            lstreporte.Visible = False
            buscarDatos()
        End If
        If lsttag = 1 Or lsttag = 12 Then
            chkTarjeta.Visible = True
        Else
            chkTarjeta.Visible = False
        End If
        If Not lsttag = 9 Then
            'chkAm.Visible = False
            'chkPm.Visible = False
            'chkM.Visible = False
            chkGrupo.Visible = False
        Else
            chkGrupo.Visible = True
        End If
    End Sub
    Private Sub TextBox1_MouseMove(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ponerFecha()
        txtReporte.Focus()
        Dim strConsulta As String = ""
        lstreporte.Visible = True
        Select Case Principal.intNivelUsuario
            Case 3
                strConsulta = "SELECT id,no FROM reporte  WHERE tipo=2 ORDER BY ORDEN ASC"
            Case 4
                strConsulta = "SELECT id,no FROM reporte ORDER BY ORDEN ASC"
        End Select
        Dim arlCoincidencias = Gestor1.DatosDeConsulta(strConsulta, , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstreporte.Visible = True
        lstreporte.Items.Clear()
        lstreporte.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lstreporte.Items.Add(lviEncontrado)
        Next
        lstreporte.EndUpdate()
        colorBarras(PanelCabecera)
    End Sub

    Private Sub DateTimePicker1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fhasta.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscarDatos()
        End If
    End Sub

    Private Sub fhasta_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub fdesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fdesde.KeyPress
        If Asc(e.KeyChar) = 13 Then
            buscarDatos()
        End If
    End Sub

    Public Sub buscarDatos()
        Dim intHora As String = " <24 "
        If chkTarjeta.Checked Then
            intTarjeta = 1
        Else : intTarjeta = 2
        End If

        If chkAm.Checked Or chkPm.Checked Then
            If chkAm.Checked Then

                intHora = "<13"
            Else

                intHora = ">=13"
            End If

        End If

        lstreporte.Visible = False
        Dim fecha1 As Date = fdesde.Value.Date
        Dim fecha2 As Date = fhasta.Value.Date
        If Not lstreporte.SelectedItems.Count = 0 Then
            con.VisualizarRortes(lstreportes, Format(fecha1, "yyyy-MM-dd"), Format(fecha2, "yyyy-MM-dd"), lstreporte.SelectedItems(0).Tag, txtTotal, , , intTarjeta,,, intHora)
        Else : MessageBox.Show("Seleecione un reporte", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : txtReporte.Focus()
        End If
    End Sub
    Sub ponerFecha()
        fdesde.CustomFormat = Now.Date.ToString
        fhasta.CustomFormat = Now.Date.ToString
    End Sub


    Private Sub btncerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btncerrar_Click_1(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub



    Private Sub PanelCabecera_Paint(sender As Object, e As PaintEventArgs) Handles PanelCabecera.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim SaveFileDialog1 As New Windows.Forms.SaveFileDialog
        SaveFileDialog1.DefaultExt = "*.csv"
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos CSV de Excel (*.csv|*.csv"
        SaveFileDialog1.ShowDialog()
        GuardeEnArchivo(ListViewACsv(lstreportes, True), SaveFileDialog1.FileName, True)

    End Sub

    Private Sub txtExportar_Click(sender As Object, e As EventArgs) Handles txtExportar.Click
        Dim SaveFileDialog1 As New Windows.Forms.SaveFileDialog
        SaveFileDialog1.DefaultExt = "*.csv"
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos CSV de Excel (*.csv|*.csv"
        SaveFileDialog1.ShowDialog()
        GuardeEnArchivo(ListViewACsv(lstreportes, True), SaveFileDialog1.FileName, True)
    End Sub

    Private Sub chkTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chkTarjeta.CheckedChanged
        buscarDatos()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkPm_CheckedChanged(sender As Object, e As EventArgs)
        buscarDatos()

    End Sub

    Private Sub chkAm_CheckedChanged(sender As Object, e As EventArgs)
        buscarDatos()

    End Sub

    Private Sub chkAm_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkAm.CheckedChanged, txtReporte.TextChanged
        buscarDatos()
    End Sub

    Private Sub chkPm_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkPm.CheckedChanged
        buscarDatos()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles chkM.CheckedChanged
        buscarDatos()

    End Sub

    Private Sub txtReporte_MouseClick(sender As Object, e As MouseEventArgs) 

    End Sub

    Private Sub lstreporte_MouseClick(sender As Object, e As MouseEventArgs) Handles lstreporte.MouseClick
        If lstreporte.SelectedItems.Count = 0 Then Exit Sub
        lsttag = lstreporte.SelectedItems(0).Tag
        If lsttag = 7 Then
            Principal.intValidar = 5
            Dim validar As New VALIDAR
            validar.ShowDialog()
            If Principal.booReporte Then
                txtReporte.Text = lstreporte.SelectedItems(0).Text
                reporte = lstreporte.SelectedItems(0).Text
                lstreporte.Visible = False
                buscarDatos()
            End If
        Else
            txtReporte.Text = lstreporte.SelectedItems(0).Text
            reporte = lstreporte.SelectedItems(0).Text
            lstreporte.Visible = False
            buscarDatos()
            If lsttag = 1 Or lsttag = 12 Then
                chkTarjeta.Visible = True
            Else
                chkTarjeta.Visible = False
            End If
        End If
    End Sub
End Class