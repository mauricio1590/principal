Public Class AjusteDeInventario
    Dim gestor1 As New Soltec.Gestor
    Dim intidpersona As Integer
    Dim intBusqueda As Integer = 1
    Dim intfacturaregistrada As Integer = 0
    Dim con As New conexion()
    Dim idcliente As Integer = 22
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub
    Public Sub recorrerListview(list As ListView, total As TextBox, columna As Integer)
        Dim intSuma As Integer
        For Each item As ListViewItem In list.Items
            intSuma += Convert.ToInt32(item.SubItems(columna).Text)
        Next
        total.Text = intSuma
        txtProducto.Focus()
    End Sub
    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown
        Dim intMovimiento As Integer = 0
        Dim intborrar As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        If e.KeyCode = Keys.Delete Then
            If lstArticulos.SelectedItems.Count > 0 Then
                lstArticulos.SelectedItems(0).Remove()
                recorrerListview(lstArticulos, txtTotal, 3)
            End If
        End If


        If lstEncontrados.Visible Then
            lstEncontrados.BringToFront()
            If intMovimiento = 0 Then
                If e.KeyCode = Keys.End Then
                    If lstEncontrados.Visible Then
                        SeñaleItemListView(lstEncontrados, lstEncontrados.Items.Count - 1, False)
                        Exit Sub
                    End If
                End If
                Exit Sub
            End If
            If lstEncontrados.Visible Then
                SeñaleItemListView(lstEncontrados, intMovimiento)
                Exit Sub
            End If
            txtProducto.Select(txtProducto.Text.Length + 1, 0)

        Else

            lstArticulos.BringToFront()
            If intMovimiento = 0 Then
                If e.KeyCode = Keys.End Then
                    If lstArticulos.Visible Then
                        SeñaleItemListView(lstArticulos, lstArticulos.Items.Count - 1, False)
                        Exit Sub
                    End If
                End If
                Exit Sub
            End If
            If lstArticulos.Visible Then
                SeñaleItemListView(lstArticulos, intMovimiento)
                Exit Sub
            End If
            txtProducto.Select(txtProducto.Text.Length + 1, 0)
        End If
    End Sub
    Public Sub alimenteLista(id As Integer, nombre As String, existencia As Integer, cantidad As Integer)
        Dim lviEncontrado As New ListViewItem
        lviEncontrado.Tag = id
        lviEncontrado.Text = cantidad
        lviEncontrado.SubItems.Add(nombre)
        lviEncontrado.SubItems.Add(existencia)
        lviEncontrado.SubItems.Add(existencia + cantidad)
        lstArticulos.Items.Add(lviEncontrado)
    End Sub
    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then

            Select Case intBusqueda
                Case 1
                    txtCantidad.Text = "1"
                    txtCantidad.Focus()
                Case 2
                    Dim strcadena As String = "SELECT id,pro_nombre,pro_precioventa,pro_cantidad FROM PRODUCTO WHERE pro_referencia= '" & txtProducto.Text & "' "
                    Dim arlCoincidencias = gestor1.DatosDeConsulta(strcadena, , Principal.cadenadeconexion)
                    If Not arlCoincidencias.Count = 0 Then
                        For Each dato As ArrayList In arlCoincidencias
                            alimenteLista(dato(0), dato(1), dato(2), 1)
                        Next
                        txtProducto.Text = ""
                        txtProducto.Focus()
                    End If


            End Select



        End If
    End Sub

    Private Sub txtProducto_TextChanged(sender As Object, e As EventArgs) Handles txtProducto.TextChanged
        Dim vector As Array
        Dim cadena As String = ""
        If (txtProducto.Text.Contains(" ")) Then
            vector = txtProducto.Text.Split(" ")
            cadena = "SELECT id,pro_nombre,pro_precioventa,pro_cantidad FROM PRODUCTO WHERE pro_nombre like '%" & vector(0) & "%% " & vector(1) & "%'"
        Else
            cadena = "SELECT id,pro_nombre,pro_precioventa,pro_cantidad FROM PRODUCTO WHERE pro_nombre like '%" & txtProducto.Text & "%'"
        End If
        If chkNombre.Checked Then
            intBusqueda = 1
        Else
            intBusqueda = 2
        End If
        Select Case intBusqueda
            Case 1
                If txtProducto.Text = "" Then Exit Sub
                Dim arlCoincidencias = gestor1.DatosDeConsulta(cadena, , Principal.cadenadeconexion)
                If Not arlCoincidencias.Count = 0 Then lstEncontrados.Visible = True
                lstEncontrados.BringToFront()
                lstEncontrados.Items.Clear()
                lstEncontrados.BeginUpdate()
                For Each Encontrado As ArrayList In arlCoincidencias
                    Dim lviEncontrado As New ListViewItem
                    lviEncontrado.Tag = Encontrado(0)
                    lviEncontrado.Text = Encontrado(1)
                    lviEncontrado.SubItems.Add(Encontrado(2))
                    lviEncontrado.SubItems.Add(Encontrado(3))
                    lstEncontrados.Items.Add(lviEncontrado)
                Next
                lstEncontrados.EndUpdate()

        End Select
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If lstEncontrados.SelectedItems.Count = 0 Then
                MessageBox.Show("Ingrese un articulo antes de continuar", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProducto.Focus()
                Exit Sub
            End If
            Select Case intBusqueda
                Case 1
                    If lstEncontrados.SelectedItems.Count = 0 Then Exit Sub
                    Dim idproducto = lstEncontrados.SelectedItems(0).Tag
                    Dim nombre As String = ""
                    Dim existencia As Integer
                    datosArticuloAjuste(idproducto, nombre, existencia)
                    If ExisteEnLista(idproducto) Then
                        adicionarCantidad(idproducto, nombre, existencia, txtCantidad.Text)
                    Else
                        alimenteLista(idproducto, nombre, existencia, txtCantidad.Text)
                    End If

                    txtProducto.Text = ""
                    txtCantidad.Text = "1"
                    txtProducto.Focus()
                    lstEncontrados.Items.Clear()
                    lstEncontrados.Visible = False
                    recorrerListview(lstArticulos, txtTotal, 3)

                Case 2

            End Select
        End If
       

    End Sub

    Public Sub adicionarCantidad(id As Integer, nombre As String, existencia As Integer, cantidadNueva As Integer)
        Dim cantidad As Integer = 0
        Dim contar As Integer = 0
        For Each item As ListViewItem In lstArticulos.Items
            If item.Tag = id Then

                lstArticulos.Items(contar).Selected = True
                cantidad = lstArticulos.SelectedItems(0).Text
                lstArticulos.SelectedItems(0).Remove()
                alimenteLista(id, nombre, existencia, (cantidadNueva + cantidad))
                Exit Sub
            End If
            contar += 1

        Next
    End Sub
    Function ExisteEnLista(id As Integer) As Boolean
        Dim booSaber As Boolean = False
        For Each item As ListViewItem In lstArticulos.Items
            If id = item.Tag Then
                booSaber = True
            End If
        Next
        Return booSaber
    End Function

    Private Sub AjusteDeInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkNombre.Checked = True
        chkReferencia.Visible = False
        txtProducto.Focus()
        colorBarras(PanelCabecera)
    End Sub

    Private Sub txtRegistrar_Click(sender As Object, e As EventArgs) Handles txtRegistrar.Click
        Dim scantidad As Integer = 0
        Dim booregistrado = True
        Dim idproducto As Integer = 0
        Dim cantidad As Integer = 0
        Dim precio As Integer = 0
        Dim nota As String = InputBox("Mensaje del Sistema", "Escriba la nota del ajuste")
        If nota.Equals("") Then MessageBox.Show("Ingrese la nota del ajuste", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        Dim strCadena As String
        For Each item As ListViewItem In lstArticulos.Items
            idproducto = Convert.ToInt32(item.Tag)
            cantidad = Convert.ToInt32(item.SubItems(0).Text)
            precio = Convert.ToInt32(item.SubItems(2).Text)
            scantidad = Convert.ToInt32(item.SubItems(3).Text)
            Dim datos() As Double = saberExistenciaKardex(idproducto, precio)
            Dim prom As Double = PromediarCosto(idproducto, precio)
            strCadena = "insert into kardex (idproducto,idfactura,cantidad,valor,scantidad,costo,mov,nota)values('" & idproducto & "','" & Principal.intidusuario & "','" & cantidad & "','" & precio & "','" & scantidad & "','" & datos(2) & "',6,'" & nota & "')"
            If Not con.registreDatos(strCadena) Then
            End If
        Next
        If booregistrado Then
            MessageBox.Show("El registro se actualizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            limpiar()
        End If
    End Sub
    Sub limpiar()
        txtProducto.Text = ""
        txtCantidad.Text = ""
        txtProducto.Focus()
        For Each item As ListViewItem In lstArticulos.Items
            item.Remove()
        Next
        txtTotal.Text = 0
    End Sub
End Class