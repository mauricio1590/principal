Imports System.ComponentModel
Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient


Module Funciones
    Dim direccion As String = ""
    Dim strPara As String = ""
    Dim strAsunto As String = ""
    Dim strMensaje As String = ""
    Dim strMensajeAnterior As String = ""
    Dim strAdjuntos As String = ""
    Dim intPrioridad As Integer = 0
    Dim strVersion As String = "5.0.1"
    Dim strUsuario As String = ""
    Dim strRemitente As String = ""
    Dim fdesdeinforme As Date
    Dim fhastainforme As Date
    Dim strContraseña As String = ""
    Dim Gestor1 As New Soltec.Gestor
    Dim con As New conexion
    Public template As New DPFP.Template
    Public Captura As DPFP.Capture.Capture
    Public verificador As New DPFP.Verification.Verification
    Public bytDecimales As Byte = 0
    Public Enroller As DPFP.Processing.Enrollment



    'Public verificador As DPFP.Verification.Verification

    Function Estacongelado(strCedula As String) As Boolean
        Dim booSaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT dias,mo FROM congelado WHERE cedula='" & strCedula & "' AND estado=1", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each congelado As ArrayList In arlCoincidencias
                Dim dia As Integer = DateDiff(DateInterval.Day, congelado(1), Now.Date)
                If Principal.intRestringirDiasCongelado = 1 AndAlso dia > Principal.intDiasRestringidos Then
                    con.registreDatos("delete from congelado where cedula= " & strCedula & "")
                    MessageBox.Show("Exedio el maximo de dias de inactividad", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return booSaber
                Else
                    booSaber = True
                    Principal.intdiascngelados = congelado(0)
                End If

            Next
        End If
        Return booSaber
    End Function
    Function esCliente(strCedula As String) As String
        Dim strIdPersona As String = 0
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM cliente WHERE cedula='" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                strIdPersona = cliente(0)
            Next
        End If
        Return strIdPersona
    End Function

    Function TieneIntructor(strIdempleado As String, strIdCliente As String) As String
        Dim saber As String = 0
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT h.nombre,e.nombre  FROM personalizado p,hora h,empleado e WHERE  h.id=p.hora_id  AND persona_id='" & strIdCliente & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each encontrado As ArrayList In arlCoincidencias
                MessageBox.Show("El cliente ya tiene una hora asignada '" & encontrado(0) & "' con '" & encontrado(1) & "' .", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                saber = 1
            Next
        End If
        Return saber
    End Function

    Function TieneHoraAsignada(strIdempleado As String, strIdCliente As String) As String
        Dim saber As String = 0

        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT h.nombre  FROM hora h,horario ho,cliente c WHERE  h.id=ho.hora_id AND ho.persona_id=c.id AND persona_id='" & strIdCliente & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each encontrado As ArrayList In arlCoincidencias
                MessageBox.Show("El cliente ya tiene una hora asignada '" & encontrado(0) & "' .", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                saber = 1
            Next
        End If
        Return saber
    End Function

    Function ElimineValorCaja(intValor As Integer) As Boolean
        Dim booSaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM caja WHERE valor='" & intValor & "' AND usuario='" & Principal.intidusuario & "' order by id desc limit 1", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each congelado As ArrayList In arlCoincidencias
                con.registreDatos("DELETE FROM CAJA where id ='" & congelado(0) & "'")
            Next
        End If
        Return booSaber
    End Function
    Public Sub listaArticulos(lstArticulos As ListView)

        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,pro_referencia,UPPER(pro_nombre),IFNULL((SELECT k.scantidad from kardex k where k.idproducto=p.id order by k.id desc limit 1),0),pro_precioventa FROM producto p order by pro_nombre", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstArticulos.Visible = True
        lstArticulos.Items.Clear()
        lstArticulos.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lviEncontrado.SubItems.Add(Encontrado(2))
            lviEncontrado.SubItems.Add(Encontrado(3))
            lviEncontrado.SubItems.Add(Encontrado(4))
            lstArticulos.Items.Add(lviEncontrado)
        Next
        lstArticulos.EndUpdate()

    End Sub
    Function colorBarras(barra As Panel)
        barra.BackColor = System.Drawing.Color.FromArgb(Principal.barra1, Principal.barra2, Principal.barra3)
        Return True
    End Function
    Function colorPanel(barra As Panel)
        barra.BackColor = System.Drawing.Color.FromArgb(Principal.cpanel1, Principal.cpanel2, Principal.cpanel3)
        Return True
    End Function

    Function IMCORPORAL(peso As Double, talla As Double, lblestado As Label) As String
        Dim imc As String = ""
        Dim denominador As Double = (talla / 100) * (talla / 100)
        Dim total As Double = (peso) / denominador
        imc = total.ToString.Substring(0, 5)

        If total < 16 Then
            lblestado.Text = "DELGADEZ SEVEREA"
        End If
        If total >= 16 AndAlso total < 17 Then
            lblestado.Text = "DELGADEZ MODERADA"
        End If
        If total >= 17 AndAlso total < 18.49 Then
            lblestado.Text = "DELGADEZ ACEPTABLE"
        End If
        If total >= 18.49 AndAlso total < 26 Then
            lblestado.Text = "PESO NORMAL"
        End If
        If total >= 25 AndAlso total < 30 Then
            lblestado.Text = "SOBRE PESO"
        End If
        If total >= 30 AndAlso total < 35 Then
            lblestado.Text = "OBESIDAD TIPO I"
        End If
        If total >= 35 AndAlso total < 40 Then
            lblestado.Text = "OBESIDAD TIPO II"
        End If
        If total >= 40 Then
            lblestado.Text = "OBESIDAD TIPO III"
        End If

        Return imc

    End Function
    Function porcentajeGrasa(sexo As Integer, imc As Double, edad As Integer) As String
        Dim totalgrasa As String = ""
        Dim total As Double = 0
        total = ((1.2 * imc) + (0.23 * edad) - (10.8 * sexo) - (5.4))
        totalgrasa = total.ToString
        If totalgrasa.Length > 5 Then
            totalgrasa = totalgrasa.Substring(0, 5)
        End If

        Return totalgrasa

    End Function
    Public Function registreMovimiento(movimiento As String, escredito As Integer, valor As Integer, usuario As Integer, Optional tabla As Integer = 0) As Boolean
        Dim booRegistrado As Boolean = False
        Dim consulta As String = ""
        If tabla = 0 Then
            consulta = "INSERT INTO caja (movimiento,escredito,valor,usuario) VALUES ('" & movimiento & "','" & escredito & "','" & valor & "','" & usuario & "')"
        ElseIf tabla = 1 Then
            consulta = "INSERT INTO caja1 (movimiento,escredito,valor,usuario) VALUES ('" & movimiento & "','" & escredito & "','" & valor & "','" & usuario & "')"
        ElseIf tabla = 2 Then
            consulta = "INSERT INTO caja2 (movimiento,escredito,valor,usuario) VALUES ('" & movimiento & "','" & escredito & "','" & valor & "','" & usuario & "')"
        End If

        Try
            Dim conectar As New MySqlConnection(Principal.cadenadeconexion)
            Dim cmd As New MySqlCommand(consulta, conectar)
            cmd.CommandText = consulta
            conectar.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                booRegistrado = True
            End If
            conectar.Close()
            conectar.Dispose()
        Catch ex As Exception
            booRegistrado = False
            MsgBox(ex.Message)
        End Try
        Return booRegistrado
    End Function
    Function ultimaFactura() As Integer
        Dim intfactura As Integer = 0
        Dim arlCoincidendias As ArrayList = Gestor1.DatosDeConsulta("SELECT MAX(id_factura) as id FROM factura", , Principal.cadenadeconexion)
        If Not arlCoincidendias.Count = 0 Then
            intfactura = arlCoincidendias(0)(0)
        End If
        Return intfactura
    End Function

    Function UltimaVersion() As String
        Dim strUltima As String = "0"
        Dim arlCoincidendias As ArrayList = Gestor1.DatosDeConsulta("SELECT ve FROM versiones ORDER BY id DESC LIMIT 1", , Principal.cadenadeconexion)
        If Not arlCoincidendias.Count = 0 Then
            strUltima = arlCoincidendias(0)(0)
        End If
        Return strUltima
    End Function
    Public Sub datosArticulo(id As Integer, ByRef strNombre As String, ByRef intPrecio As Integer)
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT pro_nombre,pro_precioventa FROM PRODUCTO WHERE id='" & id & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlCoincidencias
                strNombre = dato(0)
                intPrecio = dato(1)
            Next
        End If

    End Sub

    Public Sub datosArticuloAjuste(id As Integer, ByRef strNombre As String, ByRef intPrecio As Integer)
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT pro_nombre,scantidad FROM producto p,kardex k WHERE p.id=k.idproducto and p.id='" & id & "' order by k.id desc limit 1", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlCoincidencias
                strNombre = dato(0)
                intPrecio = dato(1)
            Next

        End If
        If strNombre = Nothing Then
            Dim arlCoincidencias1 As ArrayList = Gestor1.DatosDeConsulta("SELECT pro_nombre FROM  producto WHERE id='" & id & "' order by id desc limit 1", , Principal.cadenadeconexion)
            If arlCoincidencias1.Count > 0 Then
                strNombre = arlCoincidencias1(0)(0)
            End If
        End If

    End Sub
    Function validarUltimoCongelado(strcedula As String) As Boolean
        Dim booSber As Boolean = True
        Dim arlcoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT mo FROM congelado where cedula ='" & strcedula & "' and estado=2 order by serial desc limit 1", , Principal.cadenadeconexion)
        If Not arlcoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlcoincidencias
                If DateDiff(DateInterval.Day, dato(0), Now.Date()) < 30 Then
                    booSber = False
                End If
            Next
        End If
        Return booSber
    End Function
    Function Datoscongelado(strCedula As String, nombres As TextBox, fecha As TextBox, dias As TextBox) As Boolean
        Dim boosaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT CONCAT(UPPER(c.nombre),' ',UPPER(c.apellido)) AS nombre,p.fecha_corte FROM pago AS p,cliente AS c WHERE c.cedula='" & strCedula & "' AND c.cedula=p.cedula", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each registro As ArrayList In arlCoincidencias
                boosaber = True
                nombres.Text = registro(0)
                fecha.Text = registro(1)
                dias.Text = DateDiff(DateInterval.Day, Now.Date(), registro(1))

            Next
        End If
        Return boosaber
    End Function

    Public Function ProceseValor(strValor As String) As Double
        If IsNothing(strValor) Then Return 0
        If Not IsNumeric(strValor) Then Return 0
        Dim ii As Byte
        For ii = 1 To Len(strValor)
            If Mid(strValor, ii, 1) = "," Then Mid(strValor, ii, 1) = "."
        Next
        Return Val(strValor)
    End Function
    Public Function validarNivelUsuario(texto As String, Optional nivel As Integer = 1) As Boolean
        Dim boosaber As Boolean = False
        Dim arlCoincidencias As ArrayList

        If nivel = 1 Then
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT usuario,nivel FROM login WHERE  contraseña= '" & texto & "' ", , Principal.cadenadeconexion)
        Else
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT usuario,nivel FROM login WHERE nivel='" & nivel & "' AND contraseña= '" & texto & "' ", , Principal.cadenadeconexion)
        End If

        If Not arlCoincidencias.Count = 0 Then
            boosaber = True
        End If
        Return boosaber
    End Function
    Public Function validarContraseña2(texto As String, Optional nivel As Integer = 1) As Boolean
        Dim boosaber As Boolean = False
        Dim arlCoincidencias As ArrayList

        If nivel = 1 Then
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT usuario,nivel FROM login WHERE  contraseña= '" & texto & "' ", , Principal.cadenadeconexion)
        Else
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT usuario,nivel FROM login WHERE nivel='" & nivel & "' AND contraseña= '" & texto & "' ", , Principal.cadenadeconexion)
        End If

        If Not arlCoincidencias.Count = 0 Then
            boosaber = True
        End If
        Return boosaber
    End Function
    Public Sub GuardeEnArchivo(strTexto As String, Archivo As String, Muestre As Boolean)
        Using sw As New StreamWriter(Archivo, False, Encoding.Default)
            sw.WriteLine(strTexto)
            sw.Close()
        End Using
        If Muestre Then
            Dim pr As New Process()
            Try
                pr.StartInfo.FileName = Archivo
                pr.Start()
            Catch
            End Try
        End If
    End Sub

    Public Function ListViewACsvnuevo(Lista As ListView, Optional TitulosIncluidos As Boolean = True) As String
        Dim strHTML As String = ""
        If Not Lista.Groups.Count = 0 Then
            For i As Integer = 0 To Lista.Groups.Count - 1
                If Lista.Groups(i).Items.Count > 0 Then
                    For k As Integer = 0 To Lista.Columns.Count - 1
                        If Not Lista.Columns(i).Width = 0 Then strHTML += Chr(34) & Lista.Columns(k).Text & Chr(34) & ";"
                    Next
                    strHTML += vbCrLf
                    For Each Total As ListViewItem In Lista.Groups(i).Items
                        For k As Integer = 0 To Lista.Columns.Count - 1
                            If Not Lista.Columns(k).Width = 0 Then
                                strHTML += Chr(34) & Total.SubItems(k).Text & Chr(34) & ";"
                            End If
                        Next
                        strHTML += vbCrLf
                    Next
                End If
            Next
        Else
            For k As Integer = 0 To Lista.Columns.Count - 1
                If Not Lista.Columns(k).Width = 0 Then strHTML += Chr(34) & Lista.Columns(k).Text & Chr(34) & ";"
            Next
            strHTML += vbCrLf
            For Each Total As ListViewItem In Lista.Items
                For k As Integer = 0 To Lista.Columns.Count - 1
                    If Not Lista.Columns(k).Width = 0 Then
                        strHTML += Chr(34) & Total.SubItems(k).Text & Chr(34) & ";"
                    End If
                Next
                strHTML += vbCrLf
            Next
        End If
        Return strHTML
    End Function
    Public Function validarContraseña(texto As String, Optional nivel As Integer = 1) As Boolean
        Dim boosaber As Boolean = False
        Dim arlCoincidencias As ArrayList

        If nivel = 1 Then
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT usuario,nivel,id FROM login WHERE  contraseña= '" & texto & "' ", , Principal.cadenadeconexion)
        Else
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT usuario,nivel,id FROM login WHERE nivel='" & nivel & "' AND contraseña= '" & texto & "' ", , Principal.cadenadeconexion)
        End If

        If Not arlCoincidencias.Count = 0 Then

            Principal.intNivelUsuario = arlCoincidencias(0)(1)
            Principal.strUsuario = arlCoincidencias(0)(0)
            Principal.intidusuario = arlCoincidencias(0)(2)
            boosaber = True
        End If
        Return boosaber
    End Function
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
    Public Function arrayDatosCambioFecha(strCedula As String) As ArrayList
        Dim arlConicidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT p.cedula,p.fecha_corte,p.fecha_pago,d.tiempo,pr.dias " & vbCrLf &
                                                                    "FROM pago p,detalles d,precio pr WHERE p.cedula = d.cedula AND p.idprecio=pr.serial AND p.fecha_pago=d.fecha_pago AND p.cedula ='" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlConicidencias.Count = 0 Then
            For Each arraydatos1 As ArrayList In arlConicidencias
                Return arraydatos1
            Next
        End If

        Return Nothing
    End Function
    Public Function cambiarPago(strcedula As String, txtcliente As TextBox, txtfecha As TextBox) As Boolean
        Dim booSaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT CONCAT(UPPER(c.nombre),' ',UPPER(c.apellido)) AS Nombre, " & vbCrLf &
                                                                    "p.fecha_corte FROM cliente c,pago p WHERE c.cedula=p.cedula AND c.cedula='" & strcedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                txtcliente.Text = cliente(0)
                txtfecha.Text = cliente(1)
                booSaber = True
            Next
        End If
        Return booSaber
    End Function
    Public Sub Cargarconfiguracion(ByRef strunidad As String, ByRef intCorreo As Integer, ByRef intValEmp As Integer, ByRef intValClientes As Integer, ByRef intValEntradas As Integer, ByRef intNumEntradas As Integer, ByRef intPagoAbono As Integer, ByRef intCongClient As Integer, ByRef intNumMincongelado As Integer, ByRef intCongelarpormes As Integer, ByRef intHUella As Integer, ByRef intTipoImpresion As Integer, ByRef intEntradasCliente As Integer, ByRef strPuerto As String, ByRef intVariosAbonos As Integer,
                                   ByRef intTipopc As Integer, ByRef intRestringirDiasCOngelado As Integer, ByRef intDiasRestringidos As Integer, ByRef intLicenciaOnline As Integer, ByRef intHorarioFormularioIngreso As Integer, ByRef intValidarHorarioEntrada As Integer)

        Dim arlDatosDeCsonsulta As ArrayList = Gestor1.DatosDeConsulta(" SELECT unidad,enco,inem,incl,vaen,nuen,paab,cocl,nuco,numaco," & vbCrLf &
                                                                       " huella,imp,nuencl,puerto,pepaab,tipopc,rescon,diasres,vacoon,vahoen,hofoin FROM conf ", , Principal.cadenadeconexion)
        If Not arlDatosDeCsonsulta.Count = 0 Then
            For Each configuracion As ArrayList In arlDatosDeCsonsulta
                strunidad = configuracion(0)
                intCorreo = configuracion(1)
                intValEmp = configuracion(2)
                intValClientes = configuracion(3)
                intValEntradas = configuracion(4)
                intNumEntradas = configuracion(5)
                intPagoAbono = configuracion(6)
                intCongClient = configuracion(7)
                intNumMincongelado = configuracion(8)
                intCongelarpormes = configuracion(9)
                intHUella = configuracion(10)
                intTipoImpresion = configuracion(11)
                intEntradasCliente = configuracion(12)
                strPuerto = configuracion(13)
                intVariosAbonos = configuracion(14)
                intTipopc = configuracion(15)
                intRestringirDiasCOngelado = configuracion(16)
                intDiasRestringidos = configuracion(17)
                intLicenciaOnline = configuracion(18)
                intHorarioFormularioIngreso = configuracion(19)
                intValidarHorarioEntrada = configuracion(20)

            Next
            Dim direccion As String = strunidad & ":\PROGYM_DATOS\informes\"
            If Not My.Computer.FileSystem.DirectoryExists(direccion) Then My.Computer.FileSystem.CreateDirectory(direccion)
        End If
    End Sub

    Public Sub actualiceruta(strrutanueva As String)
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id,ruta FROM cliente where ruta IS NOT NULL", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                Dim strruta As String = cliente(1)
                Dim foto As Array = strruta.Split("\")
                con.registreDatos("UPDATE cliente set ruta='" & strrutanueva & foto(foto.Length - 1) & "' WHERE id='" & cliente(0) & "'")
            Next
        End If

    End Sub
    Public Sub VisualizarPagos(lstreporte As ListView, intIdTipo As Integer, totales As TextBox)
        Dim Consulta As String = ""
        Dim ColumnasEsNumero() As Boolean = Nothing
        Dim ColumnasJustificaciones() As Integer = Nothing
        Dim FilasEtiquetas() As Integer = Nothing
        Dim ColumnasAmplitudes() As Integer = Nothing
        Dim booPromediar As Boolean = True
        Dim total As Integer = 0
        Select Case intIdTipo
            Case 1
                Consulta = " SELECT tp.nombre,g.descripcion,g.valor FROM gastos g,tipogasto tp where g.idtipo=tp.id  AND g.fecha = current_date "
                FilasEtiquetas = {0, 1, 2}
                ColumnasEsNumero = {False, False, False}
                ColumnasJustificaciones = {0, 0, 1}
                ColumnasAmplitudes = {200, 250, 150}
                Dim arlDatos1 As ArrayList = Gestor1.DatosDeConsulta(Consulta, True, Principal.cadenadeconexion)
                Dim douSaldoEx As Double = 0
                For i As Integer = 1 To arlDatos1.Count - 1
                    If Not arlDatos1(i)(2).ToString.Equals("") Then
                        douSaldoEx += arlDatos1(i)(2)
                        totales.Text = douSaldoEx
                    End If
                Next
                booPromediar = False
                reporteListview(lstreporte, arlDatos1, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, , booPromediar)
                Exit Sub
        End Select

    End Sub
    Public Sub reporteListview(Lista As ListView, arl As ArrayList, Optional EncabezadosIncluidos As Boolean = False, Optional FilasEtiquetas() As Integer = Nothing, Optional AutoFit As Boolean = False, Optional ColumnasAmplitudes() As Integer = Nothing, Optional ColumnasJustificaciones() As Integer = Nothing, Optional ColumnasEsNumero() As Boolean = Nothing, Optional Totalizar As Boolean = False, Optional Promediar As Boolean = False)

        Lista.BeginUpdate()
        Lista.Items.Clear()
        Lista.Columns.Clear()
        Lista.Groups.Clear()
        Dim arlTotales As New ArrayList
        Dim arlPromedios As New ArrayList
        For i As Integer = 0 To arl.Count - 1
            Dim booCreeFila As Boolean = True
            If i = 0 Then
                If EncabezadosIncluidos Then booCreeFila = False
                For l As Integer = 0 To arl(0).Count - 1
                    arlTotales.Add(0)
                    arlPromedios.Add(0)
                Next
            End If
            If booCreeFila Then
                Dim Fila As New ListViewItem
                If Not IsNothing(FilasEtiquetas) Then
                    Dim strEtiqueta As String = arl(i)(FilasEtiquetas(0))
                    For n As Integer = 1 To FilasEtiquetas.Count - 1
                        strEtiqueta += "|" & arl(i)(FilasEtiquetas(n))
                    Next
                    Fila.Tag = strEtiqueta
                End If
                Dim arlFila As ArrayList = arl(i)
                For k = 0 To arlFila.Count - 1
                    If Not IsNothing(ColumnasEsNumero) Then
                        If ColumnasEsNumero(k) Then
                            Dim douValor As Double = ProceseValor(arlFila(k).ToString)
                            If Totalizar Then arlTotales(k) += douValor
                            arlFila(k) = FormatNumber(douValor, bytDecimales)
                        End If
                    End If
                    If k = 0 Then
                        Fila.Text = arlFila(k)
                    Else
                        Fila.SubItems.Add(arlFila(k).ToString)
                    End If
                Next
                Lista.Items.Add(Fila)
            End If
        Next
        If Not arl.Count = 0 Then
            If Totalizar Then
                Dim lviTotales As New ListViewItem
                lviTotales.Text = "Totales (" & Lista.Items.Count & ")"
                For s As Integer = 1 To arl(0).Count - 1
                    lviTotales.SubItems.Add("")
                    If Not IsNothing(ColumnasEsNumero) Then
                        If ColumnasEsNumero(s) Then lviTotales.SubItems(s).Text = FormatNumber(arlTotales(s), bytDecimales)
                    End If
                Next
                Lista.Items.Add(lviTotales)
            End If
            If Promediar Then
                Dim lviPromedios As New ListViewItem
                lviPromedios.Text = "Promedios"
                For s As Integer = 1 To arl(0).Count - 1
                    lviPromedios.SubItems.Add("")
                    If Not IsNothing(ColumnasEsNumero) Then
                        If ColumnasEsNumero(s) Then lviPromedios.SubItems(s).Text = FormatNumber(arlTotales(s) / (Lista.Items.Count - 1), bytDecimales)
                    End If
                Next
                Lista.Items.Add(lviPromedios)
            End If
        End If
        If Not Lista.Items.Count = 0 Then
            Lista.Items(Lista.Items.Count - 1).Selected = True
            Lista.Items(Lista.Items.Count - 1).EnsureVisible()
        End If
        If Not arl.Count = 0 Then
            Dim CuentaColumnas As ArrayList = arl(0)
            For j = 0 To CuentaColumnas.Count - 1
                Lista.Columns.Add(CuentaColumnas(j).ToString, 120)
                If Not IsNothing(ColumnasAmplitudes) Then
                    If Not IsNothing(ColumnasAmplitudes) Then Lista.Columns(j).Width = ColumnasAmplitudes(j)
                Else
                    Lista.Columns(j).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                End If
                If Not IsNothing(ColumnasJustificaciones) Then Lista.Columns(j).TextAlign = ColumnasJustificaciones(j)
            Next
        End If
        Lista.EndUpdate()
    End Sub
    Public Sub controlDeInformes()
        Dim arlUltimoInforme As ArrayList = Gestor1.DatosDeConsulta("SELECT id,fecha1,fecha2,estado FROM listainformes WHERE estado=1 limit 1", , Principal.cadenadeconexion)
        If Not arlUltimoInforme.Count = 0 Then
            For Each informe As ArrayList In arlUltimoInforme
                If (informe(2) < Now.Date) Then
                    If (Principal.intEnviarEmail = 1) Then
                        Dim bgwInforme As New BackgroundWorker
                        fdesdeinforme = informe(1)
                        fhastainforme = informe(2)
                        GenereInformeDeGastos()
                        GenereInformeDeIngresos()
                    End If
                    con.registreDatos("UPDATE listainformes SET estado=2 WHERE id='" & informe(0) & "'")
                End If
            Next
        End If

    End Sub
    Function verifiqueReferencia(referencia As String) As Boolean
        Dim booSaber = True
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM producto WHERE pro_referencia='" & referencia & "' ", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            booSaber = False
        End If
        Return booSaber
    End Function
    Function PromediarCosto(idpro As String, intcosto As Double) As Double

        Dim Dato As Double
        Dim booSaber = True
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT costo FROM kardex WHERE idproducto='" & idpro & "' order by id desc limit 1 ", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each costo As ArrayList In arlCoincidencias
                Dato = costo(0)
            Next
            Dato = (Dato + intcosto) / 2
        Else : Dato = intcosto
        End If
        Return Dato
    End Function

    Function ultimokardex(idpro As String) As Array

        Dim arlDato(3) As Double
        Dim booSaber = True
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT cantidad,valor,scantidad,costo FROM kardex WHERE idproducto='" & idpro & "' ", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlCoincidencias
                arlDato(0) = dato(0)
                arlDato(1) = dato(1)
                arlDato(2) = dato(2)
                arlDato(3) = dato(3)
            Next
        End If
        Return arlDato
    End Function

    Function saberExistenciaKardex(idpro As String, precio As Double) As Array

        Dim arlDato(2) As Double
        Dim booSaber = True
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT cantidad,scantidad,costo FROM kardex WHERE idproducto='" & idpro & "' order by id desc limit 1 ", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlCoincidencias
                arlDato(0) = dato(0)
                arlDato(1) = dato(1)
                arlDato(2) = dato(2)
            Next

        Else
            arlDato(0) = 0
            arlDato(1) = 0
            arlDato(2) = precio
        End If
        Return arlDato
    End Function
    Public Sub GuardeEnArchivo(strTexto As String, strArchivo As String, Muestre As Boolean, Optional Acumule As Boolean = False)
        Using sw As New StreamWriter(strArchivo, False, Encoding.Default)
            sw.Write(strTexto)
            sw.Close()
        End Using
        If Muestre Then
            Dim pr As New Process()
            Try
                pr.StartInfo.FileName = strArchivo
                pr.Start()
            Catch
            End Try
        End If
    End Sub
    Public Function ListViewACsv(Lista As ListView, Optional TitulosIncluidos As Boolean = True) As String
        Dim strHTML As String = ""
        If Not Lista.Groups.Count = 0 Then
            For i As Integer = 0 To Lista.Groups.Count - 1
                If Lista.Groups(i).Items.Count > 0 Then
                    For k As Integer = 0 To Lista.Columns.Count - 1
                        If Not Lista.Columns(i).Width = 0 Then strHTML += Chr(34) & Lista.Columns(k).Text & Chr(34) & ";"
                    Next
                    strHTML += vbCrLf
                    For Each Total As ListViewItem In Lista.Groups(i).Items
                        For k As Integer = 0 To Lista.Columns.Count - 1
                            If Not Lista.Columns(k).Width = 0 Then
                                strHTML += Chr(34) & Total.SubItems(k).Text & Chr(34) & ";"
                            End If
                        Next
                        strHTML += vbCrLf
                    Next
                End If
            Next
        Else
            For k As Integer = 0 To Lista.Columns.Count - 1
                If Not Lista.Columns(k).Width = 0 Then strHTML += Chr(34) & Lista.Columns(k).Text & Chr(34) & ";"
            Next
            strHTML += vbCrLf
            For Each Total As ListViewItem In Lista.Items
                For k As Integer = 0 To Lista.Columns.Count - 1
                    If Not Lista.Columns(k).Width = 0 Then
                        strHTML += Chr(34) & Total.SubItems(k).Text & Chr(34) & ";"
                    End If
                Next
                strHTML += vbCrLf
            Next
        End If
        Return strHTML
    End Function
    Function Ultimodetalle() As String
        Dim intfactura As String = 0
        Dim arlCoincidendias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM detalles ORDER BY id DESC LIMIT 1", , Principal.cadenadeconexion)
        If Not arlCoincidendias.Count = 0 Then
            intfactura = arlCoincidendias(0)(0)
        End If
        Return intfactura
    End Function
    Function esvacio(campo) As Boolean
        Dim arlCoincidencias As New ArrayList
        Dim info As Boolean = False
        arlCoincidencias = Gestor1.DatosDeConsulta("SELECT " & campo & " from informacion limit 1", , Principal.cadenadeconexion)

        If Not arlCoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlCoincidencias

                If dato(0).Equals("") Then
                    info = True
                End If
            Next
        Else
            info = True
        End If
        Return info
    End Function
    Function informaciongym(Optional campo As String = "") As String
        Dim arlCoincidencias As New ArrayList
        Dim info As String = ""
        If campo.Equals("") Then
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT no from informacion limit 1", , Principal.cadenadeconexion)
        Else
            arlCoincidencias = Gestor1.DatosDeConsulta("SELECT " & campo & " from informacion limit 1", , Principal.cadenadeconexion)
        End If

        If Not arlCoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlCoincidencias
                info = dato(0)
            Next
        End If
        Return info
    End Function
    'sender As Object, e As DoWorkEventArgs
    Private Sub GenereInformeDeGastos()
        Dim datFechaDeAyer = DateAdd(DateInterval.Day, -1, Now)
        Dim arlInforme As ArrayList = Gestor1.DatosDeConsulta(" SELECT tg.nombre AS Gasto,g.fecha AS Fecha,g.descripcion AS Descripcion,g.valor AS Valor FROM gastos g,tipogasto tg " & vbCrLf &
"                                                               WHERE g.fecha BETWEEN STR_TO_DATE(' " & fdesdeinforme & " ','%d/%m/%Y') AND STR_TO_DATE('" & fhastainforme & "','%d/%m/%Y')" & vbCrLf &
                                                                "AND tg.id=g.idtipo ", True, Principal.cadenadeconexion)
        Dim ColumnasEsNumero() As Boolean = Nothing
        Dim ColumnasJustificaciones() As Integer = Nothing
        Dim FilasEtiquetas() As Integer = Nothing
        Dim ColumnasAmplitudes() As Integer = Nothing
        Dim booPromediar As Boolean = False
        FilasEtiquetas = {0, 1, 2, 3}
        ColumnasEsNumero = {False, False, False, True}
        ColumnasJustificaciones = {1, 0, 0, 0}
        ColumnasAmplitudes = {200, 150, 150, 150}
        Dim lstInforme As New ListView
        reporteListview(lstInforme, arlInforme, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, True, booPromediar)
        GuardeEnArchivo(ListViewACsv(lstInforme, True), Principal.strunidad & ":\PROGYM_DATOS\informes\Informe de gastos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv", False)

        Notifique("Informe de gastos " & informaciongym() & " " & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & " : " & vbCrLf &
                                  "Soltec Tiendas " & Application.ProductVersion & vbCrLf & vbCrLf, 0, correos, "Informe de gastos del sistema",
                                              Principal.strunidad & ":\PROGYM_DATOS\informes\Informe de gastos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv",
                                               Application.ProductVersion, "", "infosoltectiendas@sistemasadministrativosdecolombia.com", "OP8,pJLWX38^")

        '   My.Computer.FileSystem.DeleteFile(Principal.strunidad & ":\PROGYM_DATOS\informes\Informe de gastos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv")
    End Sub
    Public Sub adicioneDias(dias As Integer)
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id,fecha_corte FROM pago WHERE fecha_corte >= current_date", , Principal.cadenadeconexion)
        If arlCoincidencias.Count > 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                Dim fecha As Date = cliente(1)
                fecha = DateAdd(DateInterval.Day, dias, fecha)
                Dim cadena As String = "UPDATE PAGO SET fecha_corte='" & Format(fecha, "yyyy-MM-dd") & "' where ID='" & cliente(0) & "'"
                con.registreDatos(cadena)
            Next
        End If
        MessageBox.Show("Se modificaron '" & arlCoincidencias.Count - 1 & "' registros  Exitosamente", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub
    Private Sub GenereInformeDeIngresos()
        Dim datFechaDeAyer = DateAdd(DateInterval.Day, -1, Now)
        Dim arlInforme As ArrayList = Gestor1.DatosDeConsulta(" SELECT IFNULL((SELECT CONCAT(c.cedula,' ',c.nombre,' ',c.apellido) FROM cliente c WHERE c.cedula=d.cedula limit 1),'SIN CLIENTE') AS Nombre, " & vbCrLf &
                                                            "IFNULL(d.fecha_pago,'SIN FECHA') AS 'Fecha',IFNULL(d.tiempo,0) AS Detalle,IFNULL(d.valor,0) AS Valor  FROM detalles d " & vbCrLf &
                                                            "WHERE fecha_pago BETWEEN STR_TO_DATE('" & fdesdeinforme & "','%d/%m/%Y') AND STR_TO_DATE('" & fhastainforme & "','%d/%m/%Y') ", True, Principal.cadenadeconexion)
        Dim ColumnasEsNumero() As Boolean = Nothing
        Dim ColumnasJustificaciones() As Integer = Nothing
        Dim FilasEtiquetas() As Integer = Nothing
        Dim ColumnasAmplitudes() As Integer = Nothing
        Dim booPromediar As Boolean = False
        FilasEtiquetas = {0, 1, 2, 3}
        ColumnasEsNumero = {False, False, False, True}
        ColumnasJustificaciones = {1, 0, 0, 0}
        ColumnasAmplitudes = {200, 150, 150, 150}
        Dim lstInforme As New ListView
        reporteListview(lstInforme, arlInforme, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, True, booPromediar)
        GuardeEnArchivo(ListViewACsv(lstInforme, True), Principal.strunidad & ":\PROGYM_DATOS\informes\Informe de Ingresos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv", False)

        Notifique("Informe de Ingresos " & informaciongym() & " " & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & " : " & vbCrLf &
                                  "Soltec Tiendas " & Application.ProductVersion & vbCrLf & vbCrLf, 0, correos, "Informe de ingresos del sistema",
                                              Principal.strunidad & ":\PROGYM_DATOS\informes\Informe de Ingresos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv",
                                               Application.ProductVersion, "", "infosoltectiendas@sistemasadministrativosdecolombia.com", "OP8,pJLWX38^")

        '  My.Computer.FileSystem.DeleteFile(Principal.strunidad & ":\PROGYM_DATOS\informes\Informe de Ingresos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv")
    End Sub
    Private Sub GenereInformeDePagos()
        Dim datFechaDeAyer = DateAdd(DateInterval.Day, -1, Now)
        Dim arlInforme As ArrayList = Gestor1.DatosDeConsulta("SELECT IFNULL(MENSUALIDADES,0) AS MENSUALIDADES,IFNULL(GASTOS,0) AS GASTOS,IFNULL((MENSUALIDADES-GASTOS),0) AS UTILIDAD FROM (SELECT SUM(valor) AS 'MENSUALIDADES' FROM detalles " & vbCrLf &
                                                              "WHERE fecha_pago BETWEEN STR_TO_DATE('" & fdesdeinforme & "','%d/%m/%Y') AND STR_TO_DATE('" & fhastainforme & "','%d/%m/%Y')) AS mensualidades, " & vbCrLf &
                                                              "(SELECT IFNULL(SUM(valor),0)AS 'GASTOS' FROM gastos " & vbCrLf &
                                                              "WHERE fecha BETWEEN STR_TO_DATE('" & fdesdeinforme & "','%d/%m/%Y') AND STR_TO_DATE('" & fhastainforme & "','%d/%m/%Y')) AS gastos", True, Principal.cadenadeconexion)
        Dim ColumnasEsNumero() As Boolean = Nothing
        Dim ColumnasJustificaciones() As Integer = Nothing
        Dim FilasEtiquetas() As Integer = Nothing
        Dim ColumnasAmplitudes() As Integer = Nothing
        Dim booPromediar As Boolean = False
        FilasEtiquetas = {0, 1, 2}
        ColumnasEsNumero = {True, True, True}
        ColumnasJustificaciones = {0, 0, 0}
        ColumnasAmplitudes = {150, 150, 150}
        Dim lstInforme As New ListView
        reporteListview(lstInforme, arlInforme, True, FilasEtiquetas, True, ColumnasAmplitudes, ColumnasJustificaciones, ColumnasEsNumero, True, booPromediar)
        GuardeEnArchivo(ListViewACsv(lstInforme, True), Principal.strunidad & ":\PROGYM_DATOS\informes\Informe general" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv", False)

        Notifique("Informe de Ingresos " & informaciongym() & " " & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & " : " & vbCrLf &
                                  "Soltec Tiendas " & Application.ProductVersion & vbCrLf & vbCrLf, 0, correos, "Informe de ingresos del sistema",
                                              Principal.strunidad & ":\PROGYM_DATOS\informes\Informe general" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv",
                                               Application.ProductVersion, "", "infosoltectiendas@sistemasadministrativosdecolombia.com", "OP8,pJLWX38^")

        '    My.Computer.FileSystem.DeleteFile(Principal.strunidad & ":\PROGYM_DATOS\informes\Informe general" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv")
    End Sub
    Public Function correos() As String

        Dim strcorreos As String = ""
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT em FROM EMAIL", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each correo As ArrayList In arlCoincidencias
                If strcorreos.Equals("") Then
                    strcorreos = correo(0)
                Else
                    strcorreos = strcorreos & "," & correo(0)
                End If

            Next
        End If


        Return strcorreos

    End Function
    Public Sub Notifique(Mensaje As String,
                       Optional Prioridad As Integer = 0,
                       Optional Para As String = "",
                       Optional Asunto As String = "",
                       Optional Adjuntos As String = "",
                       Optional Version As String = "",
                       Optional Usuario As String = "",
                       Optional Remitente As String = "",
                       Optional Contrasena As String = "")
        strMensaje = Mensaje
        strPara = Para
        strAsunto = Asunto
        intPrioridad = Prioridad
        strAdjuntos = Adjuntos
        strVersion = Version
        strUsuario = Usuario
        strRemitente = Remitente
        strContraseña = Contrasena
        EnvieCorreo()
    End Sub
    Private Sub EnvieCorreo()
        If strRemitente = "" Then Exit Sub
        Dim mmMensaje As New MailMessage
        mmMensaje.From = New MailAddress(strRemitente)
        strMensaje = "Aplicación:  " & "ProGYM" & vbCrLf &
                     "Versión:     " & strVersion & vbCrLf &
                     strMensaje
        If strMensaje = strMensajeAnterior Then Exit Sub
        strMensajeAnterior = strMensaje
        mmMensaje.To.Add(strPara)
        mmMensaje.Body = strMensaje
        mmMensaje.Subject = strAsunto
        Select Case intPrioridad
            Case -1 'baja
                mmMensaje.Priority = MailPriority.Low
            Case 0 'normal
                mmMensaje.Priority = MailPriority.Normal
            Case 1 'alta
                mmMensaje.Priority = MailPriority.High
        End Select
        'archivo adjuntar
        If Not strAdjuntos = "" Then
            Dim Adjuntar As New Net.Mail.Attachment(strAdjuntos)
            mmMensaje.Attachments.Add(Adjuntar)
        End If

        'servidor
        Dim smtp As New SmtpClient
        smtp.Port = 587
        If strRemitente.Contains("gmail") Then smtp.Host = "smtp.gmail.com"
        If strRemitente.Contains("hotmail") Then smtp.Host = "smtp.live.com"
        If strRemitente.Contains("sistemasadministrativos") Then smtp.Host = "mail.sistemasadministrativosdecolombia.com"
        smtp.UseDefaultCredentials = False
        smtp.EnableSsl = True
        smtp.Credentials = New Net.NetworkCredential(strRemitente, strContraseña)
        Try
            smtp.Send(mmMensaje)
            strRemitente = ""
            strContraseña = ""
        Catch ex As Exception
        End Try
        mmMensaje.Dispose()
        smtp.Dispose()
    End Sub
End Module
