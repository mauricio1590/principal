Imports System.ComponentModel
Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient


Module Funciones
    Public memoriatemporal As New MemoryStream()
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

    Public Sub extraerhuellaOnline(idcliente As Integer)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidor
        Builderconex.UserID = Principal.usuario
        Builderconex.Password = Principal.password
        Builderconex.Database = Principal.database
        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()
        cmd = conexion.CreateCommand
        cmd.CommandText = "SELECT huella FROM cliente WHERE id=" & idcliente
        Dim read As MySqlDataReader
        read = cmd.ExecuteReader()
        Dim verificado As Boolean = False
        Dim nombre As String = ""
        While (read.Read())
            Try
                Dim memoria As New MemoryStream(CType(read("huella"), Byte()))
                memoriatemporal = memoria
            Catch ex As Exception

            End Try

        End While



    End Sub
    Function saberTipoDato(strTabla As String) As String
        Dim strcadena As String = "SELECT DATA_TYPE,CHARACTER_MAXIMUM_LENGTH
  FROM information_schema.COLUMNS
  WHERE TABLE_SCHEMA='gym'
  AND TABLE_NAME='" & strTabla & "'
  AND COLUMN_NAME='fecha_pago';"
        Dim dato As String = ""

        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta(strcadena,, Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            dato = arlCoincidencias(0)(0)

        End If
        Return dato

    End Function
    Function saberSigno(mes As Integer, dia As Integer) As String
        Dim strCadena As String = ""

        Select Case mes
            Case 1
                If dia < 21 Then
                    strCadena = "CAPRICORNIO"
                Else
                    strCadena = "ACUARIO"
                End If
            Case 2
                If dia < 20 Then
                    strCadena = "ACUARIO"
                Else
                    strCadena = "PISCIS"
                End If
            Case 3
                If dia < 21 Then
                    strCadena = "PISCIS"
                Else
                    strCadena = "ARIES"
                End If
            Case 4
                If dia < 21 Then
                    strCadena = "ARIES"
                Else
                    strCadena = "TAURO"
                End If
            Case 5
                If dia < 21 Then
                    strCadena = "TAURO"
                Else
                    strCadena = "GÉMINIS"
                End If
            Case 6
                If dia < 22 Then
                    strCadena = "GÉMINIS"
                Else
                    strCadena = "CANCER"
                End If
            Case 7
                If dia < 23 Then
                    strCadena = "CANCER"
                Else
                    strCadena = "LEO"
                End If
            Case 8
                If dia < 23 Then
                    strCadena = "LEO"
                Else
                    strCadena = "VIRGO"
                End If
            Case 9
                If dia < 23 Then
                    strCadena = "VIRGO"
                Else
                    strCadena = "LIBRA"
                End If
            Case 10
                If dia < 23 Then
                    strCadena = "LIBRA"
                Else
                    strCadena = "ESCORPIO"
                End If
            Case 11
                If dia < 22 Then
                    strCadena = "ESCORPIO"
                Else
                    strCadena = "SAGITARIO"
                End If
            Case 12
                If dia < 22 Then
                    strCadena = "SAGITARIO"
                Else
                    strCadena = "CAPRICORNIO"
                End If
            Case Else : strCadena = ("VIVO, EL MES ES INCORRECTO")
        End Select

        Return strCadena


    End Function

    Public Sub extraerhuellaDeNube(idcliente As String)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidorOnline
        Builderconex.UserID = Principal.usuarioOnline
        Builderconex.Password = Principal.passwordOnline
        Builderconex.Database = Principal.databaseOnline
        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()
        cmd = conexion.CreateCommand
        cmd.CommandText = "SELECT huella FROM cliente WHERE cedula='" & idcliente & "'"
        Dim read As MySqlDataReader
        read = cmd.ExecuteReader()
        Dim verificado As Boolean = False
        Dim nombre As String = ""
        While (read.Read())
            Try
                Dim memoria As New MemoryStream(CType(read("huella"), Byte()))
                memoriatemporal = memoria
            Catch ex As Exception

            End Try

        End While



    End Sub
    Public Function validarUsuarioInactivo(idtarifa As Integer, strCedula As String) As Boolean
        Dim saber As Boolean = False

        If UsuarioInactivo(strCedula) Then
            saber = True
        End If

        Return saber
    End Function



    Public Function saberEdad(strCedula As String) As String
        Dim edad As String = ""
        Dim cadena As String = "SELECT nacimiento FROM cliente WHERE cedula=" & strCedula & ""
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta(cadena,, Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            Dim nacimiento As Date = arlCoincidencias(0)(0)
            edad = DateDiff(DateInterval.Year, nacimiento, Now.Date)
        End If
        Return edad
    End Function

    Public Function tarifaRestringida(idTarifa As Integer, detalle As String) As Boolean
        Dim saber As Boolean = False
        Dim cadena As String = "SELECT * FROM precio WHERE serial=" & idTarifa & " and det='" & detalle & "'"
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta(cadena,, Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            saber = True
        End If
        Return saber
    End Function
    Public Function validarReferido(strCedula As String) As Boolean
        Dim saber As Boolean = False
        Dim fechaAntigua As Date = DateAdd(DateInterval.Day, -180, Now.Date)
        Dim cadena As String = "SELECT * FROM pago WHERE cedula='" & strCedula & "' and referido=0 and fecha_corte>current_date"
        Dim arlCliente As ArrayList = Gestor1.DatosDeConsulta(cadena,, Principal.cadenadeconexion)
        If Not arlCliente.Count = 0 Then
            saber = True
        End If
        Return saber
    End Function

    Public Function UsuarioNuevo(strCedula As String) As Boolean
        Dim saber As Boolean = False
        Dim fechaAntigua As Date = DateAdd(DateInterval.Day, -180, Now.Date)
        Dim cadena As String = "SELECT * FROM pago WHERE CEDULA='" & strCedula & "'"
        Dim arlCliente As ArrayList = Gestor1.DatosDeConsulta(cadena,, Principal.cadenadeconexion)
        If arlCliente.Count = 0 Then
            saber = True
        End If
        Return saber
    End Function

    Public Function UsuarioInactivo(strCedula As String) As Boolean
        Dim saber As Boolean = False
        Dim fechaAntigua As Date = DateAdd(DateInterval.Day, -180, Now.Date)
        Dim cadena As String = "SELECT * FROM pago WHERE CEDULA='" & strCedula & "' AND fecha_corte <='" & Format(fechaAntigua, "yyyy-MM-dd") & "';"
        Dim arlCliente As ArrayList = Gestor1.DatosDeConsulta(cadena,, Principal.cadenadeconexion)
        If Not arlCliente.Count = 0 Then
            saber = True
        End If
        Return saber
    End Function
    Public Function descargarDatosDeNube(strCedula As String) As Boolean
        Dim terminado As Boolean = False
        Dim cadena As String = Principal.cadenadeconexionOnline
        Dim arlCliente As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM `cliente`  where cedula= '" & strCedula & "'", , Principal.cadenadeconexionOnline)
        If Not arlCliente.Count = 0 Then

            extraerhuellaDeNube(arlCliente(0)(1))
            registrelocal(arlCliente)

        End If

        Return terminado
    End Function
    Function actualiceLicencia() As Integer
        Dim fecha As Date = Now.Date
        fecha = DateAdd(DateInterval.Day, 30, fecha)
        Dim cadena As String = "UPDATE LIC SET LI=STR_TO_DATE('" & fecha & "','%d/%m/%Y')"
        con.registreDatos(cadena)
        Return 1
    End Function
    Public Function subirDatosANube(strCedula As String) As Boolean
        Dim terminado As Boolean = False
        Dim arlCliente As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM cliente  where cedula= '" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlCliente.Count = 0 Then

            extraerhuellaOnline(arlCliente(0)(0))
            registreOnline(arlCliente)

        End If

        Return terminado
    End Function
    Public Function subirPagoANube(strCedula As String) As Boolean
        Dim terminado As Boolean = False
        Dim arlCliente As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM pago  where cedula= '" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlCliente.Count = 0 Then
            If Not existeOline(strCedula, "pago") Then
                subirDatosPago(arlCliente)
            Else
                actualiceDatosPago(arlCliente)
            End If


        End If

        Return terminado
    End Function
    Public Function descargarPagoDeNube(strCedula As String) As Boolean
        Dim terminado As Boolean = False
        Dim arlCliente As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM pago  where cedula= '" & strCedula & "'", , Principal.cadenadeconexionOnline)
        If Not arlCliente.Count = 0 Then
            If Not existelocal(strCedula, "pago") Then
                descargarDatosPago(arlCliente)
            Else
                actualiceDatosPagolocal(arlCliente)

            End If


        End If

        Return terminado
    End Function

    Public Sub subirDatosPago(arlpago As ArrayList)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidorOnline
        Builderconex.UserID = Principal.usuarioOnline
        Builderconex.Password = Principal.passwordOnline
        Builderconex.Database = Principal.databaseOnline

        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()

        cmd = conexion.CreateCommand()
        cmd.CommandText = "INSERT INTO pago (id,cedula,fecha_corte,fecha_pago,idprecio) VALUES (null,?,?,?,?)"
        cmd.Parameters.AddWithValue("cedula", arlpago(0)(1))
        cmd.Parameters.AddWithValue("fecha_corte", arlpago(0)(2))
        cmd.Parameters.AddWithValue("fecha_pago", arlpago(0)(3))
        cmd.Parameters.AddWithValue("idprecio", arlpago(0)(4))

        cmd.ExecuteNonQuery()
        cmd.Dispose()
        conexion.Close()
        conexion.Dispose()



    End Sub
    Public Sub descargarDatosPago(arlpago As ArrayList)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidor
        Builderconex.UserID = Principal.usuario
        Builderconex.Password = Principal.password
        Builderconex.Database = Principal.database

        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()

        cmd = conexion.CreateCommand()
        cmd.CommandText = "INSERT INTO pago (id,cedula,fecha_corte,fecha_pago,idprecio) VALUES (null,?,?,?,?)"
        cmd.Parameters.AddWithValue("cedula", arlpago(0)(1))
        cmd.Parameters.AddWithValue("fecha_corte", arlpago(0)(2))
        cmd.Parameters.AddWithValue("fecha_pago", arlpago(0)(3))
        cmd.Parameters.AddWithValue("idprecio", arlpago(0)(4))

        cmd.ExecuteNonQuery()
        cmd.Dispose()
        conexion.Close()
        conexion.Dispose()



    End Sub
    Public Sub actualiceDatosPago(arlpago As ArrayList)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidorOnline
        Builderconex.UserID = Principal.usuarioOnline
        Builderconex.Password = Principal.passwordOnline
        Builderconex.Database = Principal.databaseOnline

        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()

        cmd = conexion.CreateCommand()
        cmd.CommandText = "UPDATE  pago SET fecha_corte=?,fecha_pago=?,idprecio=? where cedula=?"
        cmd.Parameters.AddWithValue("fecha_corte", arlpago(0)(2))
        cmd.Parameters.AddWithValue("fecha_pago", arlpago(0)(3))
        cmd.Parameters.AddWithValue("idprecio", arlpago(0)(4))
        cmd.Parameters.AddWithValue("cedula", arlpago(0)(1))
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        conexion.Close()
        conexion.Dispose()



    End Sub
    Public Sub actualiceDatosPagolocal(arlpago As ArrayList)
        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidor
        Builderconex.UserID = Principal.usuario
        Builderconex.Password = Principal.password
        Builderconex.Database = Principal.database

        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()

        cmd = conexion.CreateCommand()
        cmd.CommandText = "UPDATE  pago SET fecha_corte=?,fecha_pago=?,idprecio=? where cedula=?"
        cmd.Parameters.AddWithValue("fecha_corte", arlpago(0)(2))
        cmd.Parameters.AddWithValue("fecha_pago", arlpago(0)(3))
        cmd.Parameters.AddWithValue("idprecio", arlpago(0)(4))
        cmd.Parameters.AddWithValue("cedula", arlpago(0)(1))
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        conexion.Close()
        conexion.Dispose()



    End Sub
    Public Sub registreOnline(arlCliente As ArrayList)

        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidorOnline
        Builderconex.UserID = Principal.usuarioOnline
        Builderconex.Password = Principal.passwordOnline
        Builderconex.Database = Principal.databaseOnline

        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()

        cmd = conexion.CreateCommand()
        cmd.CommandText = "INSERT INTO cliente (id,cedula,nombre,apellido,telefono,direccion,correo,nacimiento,ruta,huella) VALUES (null,?,?,?,?,?,?,?,?,?)"
        cmd.Parameters.AddWithValue("cedula", arlCliente(0)(1))
        cmd.Parameters.AddWithValue("nombre", arlCliente(0)(2))
        cmd.Parameters.AddWithValue("apellido", arlCliente(0)(3))
        cmd.Parameters.AddWithValue("telefono", arlCliente(0)(4))
        cmd.Parameters.AddWithValue("direccion", arlCliente(0)(5))
        cmd.Parameters.AddWithValue("correo", arlCliente(0)(6))
        cmd.Parameters.AddWithValue("nacimiento", Format(arlCliente(0)(8), "yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("ruta", arlCliente(0)(7))
        cmd.Parameters.AddWithValue("huella", memoriatemporal.ToArray)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        conexion.Close()
        conexion.Dispose()


    End Sub

    Public Sub registrelocal(arlCliente As ArrayList)

        Dim Builderconex As New MySqlConnectionStringBuilder()
        Builderconex.Server = Principal.servidor
        Builderconex.UserID = Principal.usuario
        Builderconex.Password = Principal.password
        Builderconex.Database = Principal.database

        Dim conexion As New MySqlConnection(Builderconex.ToString())
        conexion.Open()
        Dim cmd As New MySqlCommand()

        cmd = conexion.CreateCommand()
        cmd.CommandText = "INSERT INTO cliente (id,cedula,nombre,apellido,telefono,direccion,correo,nacimiento,ruta,huella) VALUES (null,?,?,?,?,?,?,?,?,?)"
        cmd.Parameters.AddWithValue("cedula", arlCliente(0)(1))
        cmd.Parameters.AddWithValue("nombre", arlCliente(0)(2))
        cmd.Parameters.AddWithValue("apellido", arlCliente(0)(3))
        cmd.Parameters.AddWithValue("telefono", arlCliente(0)(4))
        cmd.Parameters.AddWithValue("direccion", arlCliente(0)(5))
        cmd.Parameters.AddWithValue("correo", arlCliente(0)(6))

        cmd.Parameters.AddWithValue("nacimiento", Format(arlCliente(0)(8), "yyyy-MM-dd"))
        cmd.Parameters.AddWithValue("ruta", arlCliente(0)(7))
        cmd.Parameters.AddWithValue("huella", memoriatemporal.ToArray)
        cmd.ToString()
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        conexion.Close()
        conexion.Dispose()


    End Sub
    Public Function arrayDatosCambioFecha(strCedula As String) As ArrayList
        Dim arlConicidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT p.cedula,p.fecha_corte,p.fecha_pago,IFNULL((select tiempo from detalles d where p.cedula=d.cedula order by id desc limit 1),'SIN TARIFA') as tiempo,pr.dias " & vbCrLf &
                                                                    "FROM pago p, precio pr WHERE p.idprecio=pr.serial  AND p.cedula ='" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlConicidencias.Count = 0 Then
            For Each arraydatos1 As ArrayList In arlConicidencias
                Return arraydatos1
            Next
        End If

        Return Nothing

    End Function
    Public Function traerCampo(strcedula As String, strCampo As String) As String
        Dim retorno As String = ""
        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT " & strCampo & " FROM cliente WHERE cedula ='" & strcedula & "'", , Principal.cadenadeconexion)

        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            retorno = Encontrado(0)

        Next
        Return retorno

    End Function

    Public Sub mostrarBancosCuentas(lstBancos As ListView)

        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,no,ifnull(descripcion,'nada') FROM bancoscuentas", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then lstBancos.Visible = True
        lstBancos.Items.Clear()
        lstBancos.BeginUpdate()
        For Each Encontrado As ArrayList In arlCoincidencias
            Dim lviEncontrado As New ListViewItem
            lviEncontrado.Tag = Encontrado(0)
            lviEncontrado.Text = Encontrado(1)
            lviEncontrado.SubItems.Add(Encontrado(2))
            lstBancos.Items.Add(lviEncontrado)
        Next
        lstBancos.EndUpdate()

    End Sub


    Public Sub creeSaldo()
        Dim strCedula As String = InputBox("Ingrese el Documento", "Mensaje del Sistema")
        If Not ValideCedulaExistente(strCedula, "Cliente") Then : MessageBox.Show("La Cedula no Existe en la Base de Datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub : End If
        Dim intAbono As Integer = InputBox("Ingrese el valor del Abono", "Mensaje del Sistema")
        Dim intSaldo As Integer = InputBox("Ingrese el valor del Saldo", "Mensaje del Sistema")
        Dim strCadeda As String = "INSERT INTO abonos(cedula,abono,saldo,estado,dia) values('" & strCedula & "'," & intAbono & "," & intSaldo & ",1,3);"
        If con.registreDatos(strCadeda) Then
            MessageBox.Show("La Deuda Fue Creada", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Public Sub AdicioneDias()
        Dim strCedula As String = InputBox("Ingrese el Documento", "Mensaje del Sistema")
        If Not ValideCedulaExistente(strCedula, "Cliente") Then : MessageBox.Show("La Cedula no Existe en la Base de Datos", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub : End If
        Dim intDias As Integer = InputBox("Ingrese el numero de Dias", "Mensaje del Sistema")
        Dim intValor As Integer = InputBox("Ingrese el valor Total", "Mensaje del Sistema")
        Dim fechafinal As Date
        fechafinal = DateAdd(DateInterval.Day, intDias, Now.Date)
        Dim strCadena As String = "UPDATE PAGO SET fecha_corte='" & Format(fechafinal, "yyyy-MM-dd") & "' WHERE cedula ='" & strCedula & "'"
        If con.registreDatos(strCadena) Then : Else Exit Sub : End If
        strCadena = "INSERT INTO detalles (cedula,fecha_pago,fecha_fin,tiempo,valor,tarjeta,banco) VALUES " & vbCrLf &
                             "('" & strCedula & "',now(),'" & Format(fechafinal, "yyyy-MM-dd") & "','DIA','" & intValor & "','2','0')"
        registreMovimiento(1, 0, intValor, Principal.intidusuario)
        If con.registreDatos(strCadena) Then
            MessageBox.Show("Registro Correcto", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else Exit Sub : End If
    End Sub

    Sub ponercheck(huella1 As PictureBox, huella2 As PictureBox, huella3 As PictureBox, huella4 As PictureBox)

        Dim chexk As String = Principal.strunidad & ":\SISTEMGYM_DATOS\Imagenes\checkdes.png"

        If My.Computer.FileSystem.FileExists(chexk) Then
            Dim Imagen As New Bitmap(chexk)
            huella1.Image = Imagen
            huella2.Image = Imagen
            huella3.Image = Imagen
            huella4.Image = Imagen
            huella1.Enabled = False
        End If



    End Sub

    Sub ponerhuella(huella As String, huella1 As PictureBox, huella2 As PictureBox, huella3 As PictureBox, huella4 As PictureBox)
        Dim chexk As String = Principal.strunidad & ":\SISTEMGYM_DATOS\Imagenes\check.png"
        Select Case huella
            Case 0
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella4.Image = Imagen
                End If
            Case 1
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella3.Image = Imagen
                End If
            Case 2
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella2.Image = Imagen
                End If
            Case 3
                If My.Computer.FileSystem.FileExists(chexk) Then
                    Dim Imagen As New Bitmap(chexk)
                    huella1.Image = Imagen
                End If


        End Select
    End Sub
    Public Sub EliminarFactura(id As String)

        If con.registreDatos("DELETE FROM detalle_producto WHERE detpro_idfactura= '" & id & "';DELETE FROM factura WHERE id_factura='" & id & "';") = 0 Then
            MessageBox.Show("La factura fue eliminada", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            MessageBox.Show("La factura NO fue eliminada", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Function existeOline(strCedula As String, tabla As String) As Boolean

        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM " & tabla & " WHERE cedula='" & strCedula & "'", , Principal.cadenadeconexionOnline)
        If Not arlCoincidencias.Count = 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function existelocal(strCedula As String, tabla As String) As Boolean

        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM " & tabla & " WHERE cedula='" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            Return True
        End If
        Return False
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
    Function validarTarifaNocongelable(strCedula As String) As Boolean
        Dim booSaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM tarifasnocongelables WHERE idtarifa='" & saberTarifaPorCEDULA(strCedula) & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            booSaber = True
        End If
        Return booSaber
    End Function
    Function saberTarifaPorCEDULA(strCedula As String) As Integer
        Dim intIdTarifa As String = 0
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT idprecio FROM pago WHERE cedula='" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                intIdTarifa = cliente(0)
            Next
        End If
        Return intIdTarifa
    End Function
    Function NombreClientebyd(idcliente As String) As String
        Dim strNombrePersona As String = 0
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT CONCAT(nombre,' ',apellido) as Nombre FROM cliente WHERE id='" & idcliente & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                strNombrePersona = cliente(0)
            Next
        End If
        Return strNombrePersona
    End Function
    Function NombreCliente(strCedula As String) As String
        Dim strNombrePersona As String = 0
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT CONCAT(nombre,' ',apellido) as Nombre FROM cliente WHERE cedula='" & strCedula & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                strNombrePersona = cliente(0)
            Next
        End If
        Return strNombrePersona
    End Function

    Function TieneIntructor(strIdempleado As String, strIdCliente As String) As String
        Dim saber As String = 0
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT h.nombre,e.nombre  FROM personalizado p,hora h,empleado e WHERE  h.id=p.hora_id  AND persona_id='" & strIdCliente & "'", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each encontrado As ArrayList In arlCoincidencias
                MessageBox.Show("El cliente ya tiene una hora asignada '" & encontrado(0) & "' con '" & encontrado(1) & "' .", "Informacion Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)

                saber = 1
                Return saber
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

    'restaurar tiempo de usuarios congelados 

    Public Sub restaurarTiempoCongelado()
        Dim Cadena As String
        Dim intDescongelados As Integer = 0
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM CONGELADO WHERE estado=1", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each congelado As ArrayList In arlCoincidencias
                Dim dato As Array = congelado(4).ToString.Split(" ")
                Dim fecha As Date = dato(0)
                If (DateDiff(DateInterval.Day, fecha, Now.Date) > Principal.intDiasRestringidos) Then
                    Dim ced As String = congelado(1)
                    Dim dias As Integer = congelado(2)
                    fecha = DateAdd(DateInterval.Day, dias, Now.Date)
                    Cadena = "UPDATE PAGO set fecha_corte='" & Format(fecha, "yyyy-MM-dd") & "' WHERE CEDULA='" & ced & "';UPDATE CONGELADO SET estado=2 WHERE CEDULA='" & ced & "';" & vbCrLf &
                        "INSERT INTO logs (cedula,fechaCorteOld,fechaPagoOld,fechaCorteNew,tarifa,tarifaDias,usuario_id)VALUES('" & ced & "',current_date,current_date,current_date,'DESCONGELADO'," & dias & "," & Principal.intidusuario & ");"

                    con.registreDatos(Cadena)
                    intDescongelados += 1
                End If
            Next
        End If

        If intDescongelados > 0 Then
            Principal.lblDescongelados.Text = " " & intDescongelados & " Personas fueron descongeladas"
            Principal.timerDescongelados.Enabled = (True)
        End If

    End Sub
    Function ValideCedulaExistente(strCedula As String, strTabla As String) As Boolean
        Dim booSaber As Boolean = False
        Dim strSentencia As String = "SELECT * FROM " & strTabla & " WHERE cedula='" & strCedula & "'"
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta(strSentencia, , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            booSaber = True
        End If
        Return booSaber
    End Function
    Function ElimineValorcaja(intValor As Integer) As Boolean
        Dim booSaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM caja WHERE valor='" & intValor & "' AND usuario='" & Principal.intidusuario & "' and escredito=0 order by id desc limit 1", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each congelado As ArrayList In arlCoincidencias
                con.registreDatos("DELETE FROM CAJA where id ='" & congelado(0) & "'")
            Next
        End If
        Return booSaber
    End Function
    Function ElimineValorCajagasto(intValor As Integer) As Boolean
        Dim booSaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM caja WHERE valor='" & intValor & "' AND usuario='" & Principal.intidusuario & "' and escredito=1 order by id desc limit 1", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each congelado As ArrayList In arlCoincidencias
                con.registreDatos("DELETE FROM CAJA where id ='" & congelado(0) & "'")
            Next
        End If
        Return booSaber
    End Function
    Public Sub listaArticulos(lstArticulos As ListView)

        Dim arlCoincidencias = Gestor1.DatosDeConsulta("SELECT id,pro_referencia,UPPER(pro_nombre),IFNULL((SELECT k.scantidad from kardex k where k.idproducto=p.id order by k.id desc limit 1),0),pro_precioventa FROM producto p order by pro_referencia", , Principal.cadenadeconexion)
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
    Public Function registreMovimiento(movimiento As String, escredito As Integer, valor As Integer, usuario As Integer, Optional tabla As Integer = 0, Optional tipopago As Integer = 0) As Boolean
        Dim booRegistrado As Boolean = False
        Dim consulta As String = ""
        If tabla = 0 Then
            consulta = "INSERT INTO caja (movimiento,escredito,valor,usuario,tipopago) VALUES ('" & movimiento & "','" & escredito & "','" & valor & "','" & usuario & "','" & tipopago & "')"
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
    Function nombreArticuloById(id As Integer) As String
        Dim strNobre As String = ""
        Dim arlCoincidendias As ArrayList = Gestor1.DatosDeConsulta("SELECT pro_nombre FROM producto where id= '" & id & "'", , Principal.cadenadeconexion)
        If Not arlCoincidendias.Count = 0 Then
            strNobre = arlCoincidendias(0)(0)
        End If
        Return strNobre
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

    Function extraerSaldo(intIdPersona As String) As Integer
        Dim saldo As Integer = 0
        Dim arlcoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT saldo FROM saldoventa where idCliente ='" & intIdPersona & "' ", , Principal.cadenadeconexion)
        If Not arlcoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlcoincidencias
                saldo = dato(0)
            Next
        End If
        Return saldo
    End Function
    Function extraerIdterceroporidsaldo(id As Integer) As Integer
        Dim saldo As Integer = 0
        Dim arlcoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT cl.id FROM cliente cl,saldoventa sv WHERE sv.idcliente = cl.id AND  sv.id='" & id & "' ", , Principal.cadenadeconexion)
        If Not arlcoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlcoincidencias
                saldo = dato(0)
            Next
        End If
        Return saldo
    End Function
    Function extraerSaldoId(id As Integer) As Integer
        Dim saldo As Integer = 0
        Dim arlcoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT saldo FROM saldoventa where id ='" & id & "' ", , Principal.cadenadeconexion)
        If Not arlcoincidencias.Count = 0 Then
            For Each dato As ArrayList In arlcoincidencias
                saldo = dato(0)
            Next
        End If
        Return saldo
    End Function
    Function Datoscongelado(strCedula As String, nombres As TextBox, fecha As TextBox, dias As TextBox) As Boolean
        Dim boosaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT CONCAT(UPPER(c.nombre),' ',UPPER(c.apellido)) AS nombre,p.fecha_corte FROM pago AS p,cliente AS c WHERE c.cedula='" & strCedula & "' AND c.cedula=p.cedula", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each registro As ArrayList In arlCoincidencias
                boosaber = True
                nombres.Text = registro(0)
                fecha.Text = registro(1)
                Dim diasnuevo As Integer = DateDiff(DateInterval.Day, Now.Date(), registro(1))
                dias.Text = diasnuevo

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
    Public Sub inserteEfectivoEnBanco()
        Dim strCadena As String = "INSERT INTO bancoscuentas VALUES(null,'Efectivo','Efectivo',current_Date)"
        Dim strCadena1 As String = "UPDATE bancoscuentas set id=0 WHERE no='Efectivo'"
        con.registreDatos(strCadena)
        con.registreDatos(strCadena1)
    End Sub
    Public Function verificarEfectivoEnBancos() As Boolean
        Dim booSaber As Boolean = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT * FROM bancoscuentas WHERE id=0", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            For Each cliente As ArrayList In arlCoincidencias
                booSaber = True
            Next
        End If
        Return booSaber
    End Function
    Public Sub Cargarconfiguracion(ByRef strunidad As String, ByRef intCorreo As Integer, ByRef intValEmp As Integer, ByRef intValClientes As Integer, ByRef intValEntradas As Integer, ByRef intNumEntradas As Integer, ByRef intPagoAbono As Integer, ByRef intCongClient As Integer, ByRef intNumMincongelado As Integer, ByRef intCongelarpormes As Integer, ByRef intHUella As Integer, ByRef intTipoImpresion As Integer, ByRef intEntradasCliente As Integer, ByRef strPuerto As String, ByRef intVariosAbonos As Integer,
                                   ByRef intTipopc As Integer, ByRef intRestringirDiasCOngelado As Integer, ByRef intDiasRestringidos As Integer, ByRef intLicenciaOnline As Integer,
                                   ByRef intHorarioFormularioIngreso As Integer, ByRef intValidarHorarioEntrada As Integer, ByRef intOcultarDiasAcceso As Integer, ByRef intFormatoDias As Integer,
                                   ByRef intFormularioClienteSpa As Integer, ByRef intCongelarConClaveAdmin As Integer)

        Dim arlDatosDeCsonsulta As ArrayList = Gestor1.DatosDeConsulta(" SELECT unidad,enco,inem,incl,vaen,nuen,paab,cocl,nuco,numaco," & vbCrLf &
                                                                       " huella,imp,nuencl,puerto,pepaab,tipopc,rescon,diasres,vacoon,vahoen,hofoin,ocdiac,fodi,foclsp,cococl FROM conf ", , Principal.cadenadeconexion)
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
                intOcultarDiasAcceso = configuracion(21)
                intFormatoDias = configuracion(22)
                intFormularioClienteSpa = configuracion(23)
                intCongelarConClaveAdmin = configuracion(24)


            Next
            Dim direccion As String = strunidad & ":\SISTEMGYM_DATOS\informes\"
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
                Consulta = " SELECT tp.nombre,g.descripcion,g.valor,g.id FROM gastos g,tipogasto tp where g.idtipo=tp.id  AND g.fecha = current_date "
                FilasEtiquetas = {0, 1, 2, 3}
                ColumnasEsNumero = {False, False, False, True}
                ColumnasJustificaciones = {0, 0, 1, 2}
                ColumnasAmplitudes = {200, 250, 150, 0}
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

    Function existeSado(strCedula As String) As Boolean
        Dim booSaber = False
        Dim arlCoincidencias As ArrayList = Gestor1.DatosDeConsulta("SELECT id FROM saldoVenta WHERE  idCliente='" & strCedula & "' ", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            booSaber = True
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
        GuardeEnArchivo(ListViewACsv(lstInforme, True), Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe de gastos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv", False)

        Notifique("Informe de gastos " & informaciongym() & " " & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & " : " & vbCrLf &
                                  "Soltec Tiendas " & Application.ProductVersion & vbCrLf & vbCrLf, 0, correos, "Informe de gastos del sistema",
                                              Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe de gastos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv",
                                               Application.ProductVersion, "", "infosoltectiendas@sistemasadministrativosdecolombia.com", "OP8,pJLWX38^")

        '   My.Computer.FileSystem.DeleteFile(Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe de gastos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv")
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
        GuardeEnArchivo(ListViewACsv(lstInforme, True), Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe de Ingresos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv", False)

        Notifique("Informe de Ingresos " & informaciongym() & " " & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & " : " & vbCrLf &
                                  "Soltec Tiendas " & Application.ProductVersion & vbCrLf & vbCrLf, 0, correos, "Informe de ingresos del sistema",
                                              Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe de Ingresos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv",
                                               Application.ProductVersion, "", "infosoltectiendas@sistemasadministrativosdecolombia.com", "OP8,pJLWX38^")

        '  My.Computer.FileSystem.DeleteFile(Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe de Ingresos" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv")
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
        GuardeEnArchivo(ListViewACsv(lstInforme, True), Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe general" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv", False)

        Notifique("Informe de Ingresos " & informaciongym() & " " & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & " : " & vbCrLf &
                                  "Soltec Tiendas " & Application.ProductVersion & vbCrLf & vbCrLf, 0, correos, "Informe de ingresos del sistema",
                                              Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe general" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv",
                                               Application.ProductVersion, "", "infosoltectiendas@sistemasadministrativosdecolombia.com", "OP8,pJLWX38^")

        '    My.Computer.FileSystem.DeleteFile(Principal.strunidad & ":\SISTEMGYM_DATOS\informes\Informe general" & Format(fdesdeinforme, "yyyy MM dd") & " al " & Format(fhastainforme, "yyyy MM dd") & ".csv")
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
        strMensaje = "Aplicación:  " & "SISTEMGYM" & vbCrLf &
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


    Public Class Logger
        Property HoraOcurrencia As String = ""
        Property Titulo As String = ""
        Property Evento As String = ""
        Property Datos As New List(Of String)
        Property ErrorIdentificado As String = ""
        Property ErrorDelEx As String = ""
        Property UbicacionDelLogger As String = "SOLTEC/logger"
        Property PropuestaDeSolucion As String = ""

        Public Sub New(Titulo As String, Evento As String, ErrorIdentificado As String,
                       Optional ErrorDelEx As String = "", Optional Datos As List(Of String) = Nothing,
                       Optional PropuestaDeSolucion As String = "")
            MyBase.New
            Me.HoraOcurrencia = Now.ToString("yyyy-MM-dd hh:mm:ss")
            Me.Titulo = Titulo
            Me.Evento = Evento
            Me.ErrorIdentificado = ErrorIdentificado
            Me.ErrorDelEx = ErrorDelEx
            Me.Datos = Datos
            Me.PropuestaDeSolucion = PropuestaDeSolucion
            Dim strDatos As String = "Datos Adicionales del evento:" & vbCrLf
            If Not IsNothing(Me.Datos) Then
                For Each Dato As String In Me.Datos
                    strDatos &= Dato & vbCrLf
                Next
            End If
            Dim strTexto As String = "Hora del sucento: " & Me.HoraOcurrencia & vbCrLf &
                                     "Versión del sistema: " & Application.ProductVersion & vbCrLf &
                                     "Título descriptivo: " & Me.Titulo & vbCrLf &
                                     "Evento que causa el suceso: " & Me.Evento & vbCrLf &
                                     "Datos adicionales reportados: " & strDatos & vbCrLf &
                                     "Error descrito por el desarrollador: " & Me.ErrorIdentificado & vbCrLf &
                                     "Error descrito por el controlador de excepciones: " & Me.ErrorDelEx & vbCrLf & vbCrLf &
                                     "Ubicación del logger: " & Me.UbicacionDelLogger & vbCrLf &
                                     "Propuesta de solúción: " & Me.PropuestaDeSolucion
            Try
                If Not My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\SACC\logs") Then My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\SACC\logs")
                Dim strCarpetaDestino = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\SACC\logs\"
                Using sw As New StreamWriter(strCarpetaDestino & Me.Titulo & " " & Me.HoraOcurrencia.Replace(":", " ") & ".txt", False, Encoding.UTF8)
                    sw.WriteLine(strTexto)
                    sw.Close()
                End Using
            Catch ex As Exception
            End Try
        End Sub
    End Class


End Module
