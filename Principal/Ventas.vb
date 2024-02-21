

Public Class Ventas
    Dim gestor1 As New Soltec.Gestor
    Dim intidpersona As Integer
    Dim intBusqueda As Integer = 1
    Dim intfacturaregistrada As Integer = 0
    Dim con As New conexion()
    Dim imp As New Imprimir()
    Dim idcliente As Integer = 22


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtProducto.TextChanged
        Dim vector As Array
        Dim cadena As String = ""
        If (txtProducto.Text.Contains(" ")) Then
            vector = txtProducto.Text.Split(" ")
            cadena = "SELECT p.id,p.pro_nombre,p.pro_precioventa,IFNULL((select k.scantidad from kardex k where k.idproducto=p.id order by id desc limit 1),0) FROM PRODUCTO p WHERE pro_nombre like '%" & vector(0) & "%% " & vector(1) & "%' "
        Else
            cadena = "SELECT p.id,p.pro_nombre,p.pro_precioventa,IFNULL((select k.scantidad from kardex k where k.idproducto=p.id order by id desc limit 1),0) FROM PRODUCTO p WHERE  pro_nombre like '%" & txtProducto.Text & "%' or pro_referencia like '%" & txtProducto.Text & "%'"
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
    Public Sub alimenteLista(id As Integer, nombre As String, valor As Integer, cantidad As Integer)
        Dim lviEncontrado As New ListViewItem
        lviEncontrado.Tag = id
        lviEncontrado.Text = cantidad
        lviEncontrado.SubItems.Add(nombre)
        lviEncontrado.SubItems.Add(valor)
        lviEncontrado.SubItems.Add(valor * cantidad)
        lstArticulos.Items.Add(lviEncontrado)
    End Sub
    Public Sub adicionarCantidad(id As Integer, nombre As String, valor As Integer, cantidadNueva As Integer)
        Dim cantidad As Integer = 0
        Dim contar As Integer = 0
        For Each item As ListViewItem In lstArticulos.Items
            If item.Tag = id Then

                lstArticulos.Items(contar).Selected = True
                cantidad = lstArticulos.SelectedItems(0).Text
                lstArticulos.SelectedItems(0).Remove()
                alimenteLista(id, nombre, valor, (cantidadNueva + cantidad))
                Exit Sub
            End If
            contar += 1

        Next
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
    Public Sub recorrerListview(list As ListView, total As TextBox, columna As Integer)
        Dim intSuma As Integer
        For Each item As ListViewItem In list.Items
            intSuma += Convert.ToInt32(item.SubItems(columna).Text)
        Next
        total.Text = intSuma
        txtProducto.Focus()
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
    Function ExisteEnLista(id As Integer) As Boolean
        Dim booSaber As Boolean = False
        For Each item As ListViewItem In lstArticulos.Items
            If id = item.Tag Then
                booSaber = True
            End If
        Next
        Return booSaber
    End Function

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
                    Dim precio As Integer
                    datosArticulo(idproducto, nombre, precio)
                    If ExisteEnLista(idproducto) Then
                        adicionarCantidad(idproducto, nombre, precio, txtCantidad.Text)
                    Else
                        alimenteLista(idproducto, nombre, precio, txtCantidad.Text)
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
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
        End If

    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        Dim intMovimiento As Integer = 0
        If e.KeyCode = Keys.Down Then intMovimiento = 1
        If e.KeyCode = Keys.Up Then intMovimiento = -1
        lstNombres.BringToFront()
        If intMovimiento = 0 Then
            If e.KeyCode = Keys.End Then
                If lstNombres.Visible Then
                    SeñaleItemListView(lstNombres, lstNombres.Items.Count - 1, False)
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        If lstNombres.Visible Then
            SeñaleItemListView(lstNombres, intMovimiento)
            Exit Sub
        End If
        txtCliente.Select(txtCliente.Text.Length + 1, 0)
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If lstNombres.SelectedItems.Count = 0 Then Exit Sub
            intidpersona = lstNombres.SelectedItems(0).Tag
            txtCliente.Text = lstNombres.SelectedItems(0).Text & " " & lstNombres.SelectedItems(0).SubItems(1).Text

            lstNombres.Visible = False
            txtProducto.Focus()

        End If
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        If txtCliente.Text = "" Then Exit Sub
        Dim arlCoincidencias = gestor1.DatosDeConsulta("SELECT id, nombre ,apellido FROM cliente WHERE nombre LIKE '%" & txtCliente.Text & "%' ORDER BY nombre LIMIT 30", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstNombres.Visible = True
        lstNombres.Items.Clear()
        lstNombres.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lviEncontrado.SubItems.Add(Encontrado(2))
            lstNombres.Items.Add(lviEncontrado)
        Next
        lstNombres.EndUpdate()
    End Sub


    Private Sub lstArticulos_MouseClick(sender As Object, e As MouseEventArgs) Handles lstArticulos.MouseClick

        If lstArticulos.SelectedItems.Count > 0 Then
            Dim nuevo As String = InputBox("Esciba el nuevo precio", "Mensaje del sistema", lstArticulos.SelectedItems(0).SubItems(2).Text)
            Dim idarticulo As Integer = lstArticulos.SelectedItems(0).Tag
            adicionarCantidad(idarticulo, lstArticulos.SelectedItems(0).SubItems(1).Text, nuevo, 0)
            recorrerListview(lstArticulos, txtTotal, 3)
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub

    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkNombre.Checked = True
        chkReferencia.Visible = False
        txtCliente.Focus()
        lblAbono.Visible = False
        txtAbono.Visible = False
        colorBarras(PanelCabecera)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles txtRegistrar.Click
        Dim valorcaja As Integer = 0
        Dim booregistrado = True
        Dim idproducto As Integer = 0
        Dim cantidad As Integer = 0
        Dim precio As Integer = 0
        Dim strFactura As String = "INSERT INTO factura(fac_idcliente,fac_idempleado,fac_fecha,fac_tipo) values ('" & intidpersona & "',22,now(),2)"

        If Not con.registreDatos(strFactura) Then
            booregistrado = False
        End If
        intfacturaregistrada = ultimaFactura()
        Dim detalleVenta(3) As String
        For Each item As ListViewItem In lstArticulos.Items
            idproducto = Convert.ToInt32(item.Tag)
            cantidad = Convert.ToInt32(item.SubItems(0).Text)
            precio = Convert.ToInt32(item.SubItems(2).Text)
            strFactura = "insert into detalle_producto(detpro_idfactura,detpro_idproducto,detpro_cantidad,detpro_precio)values('" & intfacturaregistrada & "','" & idproducto & "','" & cantidad & "','" & precio & "')"
            Dim array As Array = ultimokardex(idproducto)
            Dim strExistencia As String = "INSERT INTO kardex (idproducto,idfactura,cantidad,valor,scantidad,costo,mov) values ('" & idproducto & "', " & vbCrLf &
                      "'" & intfacturaregistrada & "','" & cantidad & "','" & array(1) & "','" & array(2) - cantidad & "','" & Convert.ToInt32(array(3)) & "',7 ) "
            con.registreDatos(strExistencia)
            If Not con.registreDatos(strFactura) Then
            End If
        Next
        valorcaja = txtTotal.Text
        If chkAbono.Checked Then
            If existeSado(intidpersona) Then
                strFactura = "update saldoventa set saldo=" & extraerSaldo(intidpersona) + (txtTotal.Text - txtAbono.Text) & " where idcliente=" & intidpersona & " "
                con.registreDatos(strFactura)
            Else
                strFactura = "INSERT INTO saldoVenta (idCliente,saldo) values ('" & intidpersona & "','" & (txtTotal.Text - txtAbono.Text) & "')"

                con.registreDatos(strFactura)

            End If
            valorcaja = txtAbono.Text
        End If
            If booregistrado Then
            MessageBox.Show("El registro se actualizo correctamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            If chkAbono.Checked Then
                txtAbono.Visible = True
            End If
            Select Case (Principal.intTipoImpresion)
                Case 0

                Case 1
                    Dim res = MessageBox.Show("Desea Imprimir la factura ", "Informacion Del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If res = Windows.Forms.DialogResult.Yes Then
                        imp.GenereImpresionventa(intidpersona, NombreClientebyd(intidpersona), lstArticulos, valorcaja)
                    End If
                Case 2
                    imp.GenereImpresionventa(intidpersona, NombreClientebyd(intidpersona), lstArticulos, valorcaja)
            End Select
            registreMovimiento(3, 0, valorcaja, Principal.intidusuario, 1)
            limpiar()
        End If

    End Sub

    Sub limpiar()
        txtCliente.Text = ""
        txtProducto.Text = ""
        txtCantidad.Text = ""
        txtCliente.Focus()
        For Each item As ListViewItem In lstArticulos.Items
            item.Remove()
        Next
        chkAbono.Checked = False
        txtAbono.Text = ""
        txtAbono.Visible = False
        lblAbono.Visible = False
        txtTotal.Text = 0
    End Sub

    Private Sub chkAbono_CheckedChanged(sender As Object, e As EventArgs) Handles chkAbono.CheckedChanged
        If chkAbono.Checked Then
            txtAbono.Visible = True
            lblAbono.Visible = True
            txtAbono.Text = "0"
        Else
            txtAbono.Visible = False
            lblAbono.Visible = False
        End If
    End Sub

    Private Sub lstArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstArticulos.SelectedIndexChanged

    End Sub

    Private Sub lstNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles lstNombres.MouseClick
        If lstNombres.SelectedItems.Count = 0 Then Exit Sub
        intidpersona = lstNombres.SelectedItems(0).Tag
        txtCliente.Text = lstNombres.SelectedItems(0).Text & " " & lstNombres.SelectedItems(0).SubItems(1).Text

        lstNombres.Visible = False
        txtProducto.Focus()

    End Sub

    Private Sub lstEncontrados_MouseClick(sender As Object, e As MouseEventArgs) Handles lstEncontrados.MouseClick
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
    End Sub
End Class