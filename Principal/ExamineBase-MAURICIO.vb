Module ExamineBase
    Dim gestor As New Soltec.Gestor
    Dim con As New conexion

    Public Function ExisteTabla(Tabla As String) As Boolean
        Dim arlExiste As ArrayList = gestor.DatosDeConsulta("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'gym' AND table_name = '" & Tabla & "'", , Principal.cadenadeconexion)

        If Not arlExiste.Count = 0 Then Return (arlExiste(0)(0) = 1)
        Return True
    End Function


    Public Sub tablaReportes()
        Dim arlCoincidencias As ArrayList = gestor.DatosDeConsulta("SELECT COUNT(*) FROM REPORTE", , Principal.cadenadeconexion)
        If arlCoincidencias.Count < 27 Then
            con.registreDatos("DROP TABLE REPORTE")
            examineTabla("reporte")

        End If
    End Sub
    Public Sub tablaMovimientos()
        Dim arlCoincidencias As ArrayList = gestor.DatosDeConsulta("SELECT COUNT(*) FROM tipomocimiento", , Principal.cadenadeconexion)
        If arlCoincidencias.Count < 6 Then
            con.registreDatos("DROP TABLE tipomovimiento")
            examineTabla("tipomovimiento")

        End If
    End Sub
    Public Sub verifiqueColumna(strTabla As String)
        Select Case strTabla

            Case "abonos"
                If Not existeColumna("cedula", "abonos") Then : con.registreDatos("ALTER TABLE abonos ADD COLUMN cedula VARCHAR(45) NOT NULL DEFAULT 0 AFTER idabonos") : End If
                If Not existeColumna("abono", "abonos") Then : con.registreDatos("ALTER TABLE abonos ADD COLUMN abono VARCHAR(45) NOT NULL DEFAULT 0 AFTER cedula") : End If
                If Not existeColumna("saldo", "abonos") Then : con.registreDatos("ALTER TABLE abonos ADD COLUMN saldo VARCHAR(45) NOT NULL DEFAULT 0 AFTER abono") : End If
                If Not existeColumna("estado", "abonos") Then : con.registreDatos("ALTER TABLE abonos ADD COLUMN estado VARCHAR(45) NOT NULL DEFAULT 0 AFTER saldo") : End If
                If Not existeColumna("dia", "abonos") Then : con.registreDatos("ALTER TABLE abonos ADD COLUMN dia int(11) NOT NULL DEFAULT 0 AFTER estado") : End If
                If Not existeColumna("tipo", "abonos") Then : con.registreDatos("ALTER TABLE abonos ADD COLUMN tipo int(1) NOT NULL DEFAULT 1 AFTER dia") : End If
                If Not existeColumna("mo", "abonos") Then : con.registreDatos("ALTER TABLE abonos ADD COLUMN mo TIMESTAMP  DEFAULT CURRENT_TIMESTAMP AFTER tipo") : End If

            Case "cliente"
                If Not existeColumna("cedula", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN cedula VARCHAR(45) NOT NULL DEFAULT 0 AFTER id") : End If
                If Not existeColumna("nombre", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN nombre VARCHAR(45) NOT NULL DEFAULT NULL AFTER cedula") : End If
                If Not existeColumna("apellido", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN apellido VARCHAR(45) NOT NULL DEFAULT NULL AFTER nombre") : End If
                If Not existeColumna("telefono", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN telefono VARCHAR(45)  DEFAULT NULL AFTER apellido") : End If
                If Not existeColumna("email", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN email VARCHAR(100)  DEFAULT NULL AFTER telefono") : End If
                If Not existeColumna("ruta", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN ruta VARCHAR(100) NOT NULL DEFAULT NULL AFTER ruta") : End If
                If Not existeColumna("nacimiento", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN nacimiento DATE  DEFAULT '2018-01-01' AFTER ruta") : End If
                If Not existeColumna("huella", "cliente") Then : con.registreDatos("ALTER TABLE cliente ADD COLUMN huella LONGBLOB  AFTER ruta") : End If

            Case "conf"
                If Not existeColumna("unidad", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN unidad VARCHAR(1) NOT NULL DEFAULT 'D' AFTER id") : End If
                If Not existeColumna("enco", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN enco VARCHAR(1) NOT NULL DEFAULT '2' AFTER unidad") : End If
                If Not existeColumna("inem", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN inem VARCHAR(1) NOT NULL DEFAULT '2' AFTER enco") : End If
                If Not existeColumna("incl", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN incl VARCHAR(1) NOT NULL DEFAULT '2' AFTER inem") : End If
                If Not existeColumna("vaen", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN vaen VARCHAR(1) NOT NULL DEFAULT '2' AFTER incl") : End If
                If Not existeColumna("nuen", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN nuen VARCHAR(1) NOT NULL DEFAULT '4' AFTER vaen") : End If
                If Not existeColumna("paab", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN paab INT(1) NOT NULL DEFAULT 1 AFTER nuen") : End If
                If Not existeColumna("cocl", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN cocl INT(1) NOT NULL DEFAULT 1 AFTER paab") : End If
                If Not existeColumna("nuco", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN nuco INT(2) NOT NULL DEFAULT 7 AFTER cocl") : End If
                If Not existeColumna("numaco", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN numaco INT(3) NOT NULL DEFAULT 30 AFTER nuco") : End If
                If Not existeColumna("huella", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN huella INT(1) NOT NULL DEFAULT 2  AFTER numaco") : End If
                If Not existeColumna("imp", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN imp INT(1) NOT NULL DEFAULT 0 AFTER huella") : End If
                If Not existeColumna("nuencl", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN nuencl INT(1) NOT NULL DEFAULT 2 AFTER imp") : End If
                If Not existeColumna("puerto", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN puerto INT(2) NOT NULL DEFAULT '6' AFTER nuencl") : End If
                If Not existeColumna("pepaab", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN pepaab INT(1) NOT NULL DEFAULT '2' AFTER puerto") : End If
                If Not existeColumna("tipopc", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN tipopc INT(1) NOT NULL DEFAULT '1' AFTER pepaab") : End If
                If Not existeColumna("rescon", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN rescon INT(1) NOT NULL DEFAULT '2' AFTER tipopc") : End If
                If Not existeColumna("diasres", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN diasres INT(2) NOT NULL DEFAULT '30' AFTER rescon") : End If
                If Not existeColumna("vacoon", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN vacoon INT(1) NOT NULL DEFAULT '2' AFTER diasres") : End If
                If Not existeColumna("vaabca", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN vaabca INT(1) NOT NULL DEFAULT '2' AFTER vacoon") : End If
                If Not existeColumna("hofoin", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN hofoin INT(1) NOT NULL DEFAULT '2' AFTER vaabca") : End If
                If Not existeColumna("vahoen", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN vahoen INT(1) NOT NULL DEFAULT '2' AFTER hofoin") : End If

                If Not existeColumna("mo", "conf") Then : con.registreDatos("ALTER TABLE conf ADD COLUMN mo TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP AFTER") : End If

            Case "detalles"
                If Not existeColumna("cedula", "detalles") Then : con.registreDatos("ALTER TABLE detalles ADD COLUMN cedula VARCHAR(45) NOT NULL AFTER id") : End If
                If Not existeColumna("fecha_pago", "detalles") Then : con.registreDatos("ALTER TABLE detalles ADD COLUMN fecha_pago NOT NULL AFTER cedula") : End If
                If Not existeColumna("fecha_fin", "detalles") Then : con.registreDatos("ALTER TABLE detalles ADD COLUMN fecha_fin VARCHAR(45) NOT NULL AFTER fecha_pago") : End If
                If Not existeColumna("tiempo", "detalles") Then : con.registreDatos("ALTER TABLE detalles ADD COLUMN tiempo VARCHAR(45)  NOT NULL AFTER fecha_fin") : End If
                If Not existeColumna("valor", "detalles") Then : con.registreDatos("ALTER TABLE detalles ADD COLUMN valor VARCHAR(45)  NOT NULL DEFAULT '0' AFTER tiempo") : End If
                If Not existeColumna("tarjeta", "detalles") Then : con.registreDatos("ALTER TABLE detalles ADD COLUMN tarjeta int(1) NOT NULL DEFAULT 2 AFTER valor") : End If


            Case "entrada"
                If Not existeColumna("cedula", "entrada") Then : con.registreDatos("ALTER TABLE entrada ADD COLUMN cedula VARCHAR(15) NOT NULL  AFTER id") : End If
                If Not existeColumna("fecha", "entrada") Then : con.registreDatos("ALTER TABLE entrada ADD COLUMN fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP AFTER cedula") : End If
                If existeColumna("dias", "entrada") Then : con.registreDatos("ALTER TABLE entrada DROP COLUMN DIAS ") : End If

            Case "informacion"
                If Not existeColumna("idonline", "informacion") Then : con.registreDatos("ALTER TABLE informacion ADD COLUMN idonline INT(3) NOT NULL  AFTER id") : End If
                If Not existeColumna("nit", "informacion") Then : con.registreDatos("ALTER TABLE informacion ADD COLUMN nit VARCHAR(20) NOT NULL  AFTER idonline") : End If
                If Not existeColumna("no", "informacion") Then : con.registreDatos("ALTER TABLE informacion ADD COLUMN no VARCHAR(200) NOT NULL  AFTER nit") : End If
                If Not existeColumna("regimen", "informacion") Then : con.registreDatos("ALTER TABLE informacion ADD COLUMN regimen VARCHAR(20) NOT NULL  AFTER no") : End If
                If Not existeColumna("propietario", "informacion") Then : con.registreDatos("ALTER TABLE informacion ADD COLUMN propietario VARCHAR(200) NOT NULL  AFTER regimen") : End If
                If Not existeColumna("telefono", "informacion") Then : con.registreDatos("ALTER TABLE informacion ADD COLUMN telefono VARCHAR(30) NOT NULL  AFTER regimen") : End If
                If Not existeColumna("direccion", "informacion") Then : con.registreDatos("ALTER TABLE informacion ADD COLUMN direccion text NOT NULL  AFTER telefono") : End If
            Case "kardex"

                If Not existeColumna("idproducto", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN idproducto int(11) NOT NULL DEFAULT 0 AFTER id") : End If
                If Not existeColumna("idfactura", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN idfactura int  NOT NULL DEFAULT 0 AFTER idproducto") : End If
                If Not existeColumna("cantidad", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN cantidad double NOT NULL DEFAULT 0 AFTER idfactura") : End If
                If Not existeColumna("valor", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN valor double NOT NULL DEFAULT 0 AFTER cantidad") : End If
                If Not existeColumna("scantidad", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN scantidad double NOT NULL DEFAULT 0 AFTER valor") : End If
                If Not existeColumna("costo", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN costo double NOT NULL DEFAULT 0 AFTER scantidad") : End If
                If Not existeColumna("mov", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN mov int(2) NOT NULL DEFAULT 0 AFTER costo") : End If
                If Not existeColumna("nota", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN nota TEXT  AFTER mov") : End If
                If Not existeColumna("modificado", "kardex") Then : con.registreDatos("ALTER TABLE kardex ADD COLUMN modificado TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP AFTER nota") : End If

            Case "login"
                If Not existeColumna("id", "login") Then
                    con.registreDatos("ALTER TABLE login DROP PRIMARY KEY")
                    con.registreDatos("ALTER TABLE login ADD COLUMN id INT AUTO_INCREMENT FIRST, ADD PRIMARY KEY (id)") : End If
                If Not existeColumna("usuario", "login") Then : con.registreDatos("ALTER TABLE login ADD COLUMN usuario varchar(45) AFTER id ") : End If
                If Not existeColumna("contraseña", "login") Then : con.registreDatos("ALTER TABLE login ADD COLUMN contraseña varchar(45) AFTER usuario ") : End If
                If Not existeColumna("nivel", "login") Then : con.registreDatos("ALTER TABLE login ADD COLUMN nivel int(2) AFTER contraseña") : End If
            Case "medida"
                If Not existeColumna("cliente", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN cliente VARCHAR(20) NOT NULL DEFAULT '0' AFTER id") : End If
                If Not existeColumna("edad", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN edad INT(3)  DEFAULT NULL AFTER cliente") : End If
                If Not existeColumna("sexo", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN sexo INT(3)  DEFAULT NULL AFTER edad") : End If
                If Not existeColumna("peso", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN peso INT(3)  DEFAULT NULL AFTER sexo") : End If
                If Not existeColumna("talla", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN talla INT(3)  DEFAULT NULL AFTER peso") : End If
                If Not existeColumna("fcxmin", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN fcxmin INT(3)  DEFAULT NULL AFTER talla") : End If
                If Not existeColumna("imc", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN imc INT(3)  DEFAULT NULL AFTER fcxmin") : End If
                If Not existeColumna("porgrasa", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN porgrasa INT(3)  DEFAULT NULL AFTER imc") : End If
                If Not existeColumna("pantorrilla", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN pantorrilla INT(3)  DEFAULT NULL AFTER porgrasa") : End If
                If Not existeColumna("muslomedio", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN muslomedio INT(3)  DEFAULT NULL AFTER pantorrilla") : End If
                If Not existeColumna("gluteo", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN gluteo INT(3)  DEFAULT NULL AFTER muslomedio") : End If
                If Not existeColumna("cintura", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN cintura INT(3)  DEFAULT NULL AFTER gluteo") : End If
                If Not existeColumna("espalda", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN espalda INT(3)  DEFAULT NULL AFTER cintura") : End If
                If Not existeColumna("pectorales", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN pectorales INT(3)  DEFAULT NULL AFTER espalda") : End If
                If Not existeColumna("brizq", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN brizq INT(3)  DEFAULT NULL AFTER pectorales") : End If
                If Not existeColumna("brder", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN brder INT(3)  DEFAULT NULL AFTER brizq") : End If
                If Not existeColumna("restriccion", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN restriccion LONGTEXT  DEFAULT NULL AFTER brder") : End If
                If Not existeColumna("objetivo", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN objetivo LONGTEXT  DEFAULT NULL AFTER restriccion") : End If
                If Not existeColumna("pechoespalda", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN pechoespalda INT(3)  DEFAULT NULL AFTER objetivo") : End If
                If Not existeColumna("cuello", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN cuello INT(3)  DEFAULT NULL AFTER pechoespalda") : End If
                If Not existeColumna("piizq", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN piizq INT(3)  DEFAULT NULL AFTER cuello") : End If
                If Not existeColumna("pider", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN pider INT(3)  DEFAULT NULL AFTER piizq") : End If
                If Not existeColumna("bicep", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN bicep INT(3)  DEFAULT NULL AFTER pider") : End If
                If Not existeColumna("tricep", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN tricep INT(3)  DEFAULT NULL AFTER bicep") : End If
                If Not existeColumna("subes", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN subes INT(3)  DEFAULT NULL AFTER tricep") : End If
                If Not existeColumna("supra", "medida") Then : con.registreDatos("ALTER TABLE medida ADD COLUMN supra INT(3)  DEFAULT NULL AFTER subes") : End If
                If Not existeColumna("mo", "precio") Then : con.registreDatos("ALTER TABLE precio ADD COLUMN mo TIMESTAMP  DEFAULT CURRENT_TIMESTAMP AFTER supra") : End If




            Case "precio"
                If Not existeColumna("serial", "precio") Then : con.registreDatos("ALTER TABLE precio ADD COLUMN serial INT AUTO_INCREMENT, ADD PRIMARY KEY (serial) ") : End If
                If Not existeColumna("tipo", "precio") Then : con.registreDatos("ALTER TABLE precio ADD COLUMN tipo VARCHAR(45) NOT NULL AFTER serial ") : End If
                If Not existeColumna("valor", "precio") Then : con.registreDatos("ALTER TABLE precio ADD COLUMN valor VARCHAR(45) NOT NULL AFTER tipo ") : End If
                If Not existeColumna("dias", "precio") Then : con.registreDatos("ALTER TABLE precio ADD COLUMN dias INT(10) DEFAULT 0 AFTER  valor ") : End If
                If Not existeColumna("det", "precio") Then : con.registreDatos("ALTER TABLE precio ADD COLUMN det INT(1) DEFAULT 1 AFTER  dias ") : End If
                If Not existeColumna("mo", "precio") Then : con.registreDatos("ALTER TABLE precio ADD COLUMN mo TIMESTAMP  DEFAULT CURRENT_TIMESTAMP AFTER det") : End If

            Case "temperatura"
                If Not existeColumna("id", "temperatura") Then : con.registreDatos("ALTER TABLE temperatura ADD COLUMN id INT AUTO_INCREMENT, ADD PRIMARY KEY (id) ") : End If
                If Not existeColumna("persona_id", "temperatura") Then : con.registreDatos("ALTER TABLE temperatura ADD COLUMN persona_id INT(11) NOT NULL AFTER id ") : End If
                If Not existeColumna("tem", "temperatura") Then : con.registreDatos("ALTER TABLE temperatura ADD COLUMN tem INT(5) NOT NULL AFTER persona_id ") : End If
                If Not existeColumna("obs", "temperatura") Then : con.registreDatos("ALTER TABLE temperatura ADD COLUMN obs INT(5) AFTER tem ") : End If
                If Not existeColumna("fecha", "temperatura") Then : con.registreDatos("ALTER TABLE temperatura ADD COLUMN fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP AFTER obs") : End If
                If Not existeColumna("tipo", "temperatura") Then : con.registreDatos("ALTER TABLE temperatura ADD COLUMN tipo INT(1) DEFAULT '1' AFTER fecha ") : End If

        End Select


    End Sub

    Public Sub verifiqueListaInformes()
        Dim arlCoincidencias As ArrayList = gestor.DatosDeConsulta("SELECT * FROM listainformes WHERE fecha1 < '2019-01-01' ", , Principal.cadenadeconexion)
        If arlCoincidencias.Count > 0 Then
            con.registreDatos("DROP TABLE listainformes")
        End If
    End Sub
    Function existeColumna(strcolumna As String, strtabla As String) As Boolean
        Dim booExiste As Boolean = False
        Dim arlCoincidencias As ArrayList = gestor.DatosDeConsulta(" SELECT * " & vbCrLf &
        " FROM INFORMATION_SCHEMA.COLUMNS " & vbCrLf &
        "WHERE TABLE_NAME = '" & strtabla & "' AND TABLE_SCHEMA='gym' AND COLUMN_NAME = '" & strcolumna & "';", , Principal.cadenadeconexion)
        If Not arlCoincidencias.Count = 0 Then
            booExiste = True
        End If
        Return booExiste
    End Function
    Function cantidadColumnas(strtabla As String) As Integer
        Dim intColumnas As Integer = 0
        Dim arlCoincidencias As ArrayList = gestor.DatosDeConsulta("select count(*) from INFORMATION_SCHEMA.columns where table_name = '" & strtabla & "'", , Principal.cadenadeconexion)
        intColumnas = arlCoincidencias.Count
        Return intColumnas
    End Function
    Private Sub examineTabla(tabla As String)
        Dim strcadena As String = ""
        Dim strInsert As String = ""
        Dim booinserte = False
        Dim booCeeTabla = False
        booCeeTabla = ExisteTabla(tabla)
        If Not booCeeTabla Then
            Select Case tabla
                Case "abonos"
                    strcadena = " CREATE TABLE `abonos` (" & vbCrLf &
                      "`idabonos` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`cedula` varchar(45) NOT NULL," & vbCrLf &
                      "`abono` varchar(45) NOT NULL," & vbCrLf &
                      "`saldo` varchar(45) NOT NULL," & vbCrLf &
                      "`estado` int(3) NOT NULL," & vbCrLf &
                      "`dia` int(11) DEFAULT NULL," & vbCrLf &
                      "`tipo` int(1) DEFAULT 1," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                      "PRIMARY KEY (`idabonos`)" & vbCrLf &
                    ") "
                Case "caja"
                    strcadena = "create table caja(" & vbCrLf &
                    "id integer auto_increment," & vbCrLf &
                    "movimiento int(1) not null," & vbCrLf &
                    "escredito integer(1) not null," & vbCrLf &
                    "valor integer not null," & vbCrLf &
                    "usuario varchar(40) not null," & vbCrLf &
                    "fecha timestamp default current_timestamp," & vbCrLf &
                    "primary key(id))"
                Case "caja1"
                    strcadena = "create table caja1(" & vbCrLf &
                    "id integer auto_increment," & vbCrLf &
                    "movimiento int(1) not null," & vbCrLf &
                    "escredito integer(1) not null," & vbCrLf &
                    "valor integer not null," & vbCrLf &
                    "usuario varchar(40) not null," & vbCrLf &
                    "fecha timestamp default current_timestamp," & vbCrLf &
                    "primary key(id))"
                Case "caja2"
                    strcadena = "create table caja2(" & vbCrLf &
                    "id integer auto_increment," & vbCrLf &
                    "movimiento int(1) not null," & vbCrLf &
                    "escredito integer(1) not null," & vbCrLf &
                    "valor integer not null," & vbCrLf &
                    "usuario varchar(40) not null," & vbCrLf &
                    "fecha timestamp default current_timestamp," & vbCrLf &
                    "primary key(id))"
                Case "cliente"
                    strcadena = "  CREATE TABLE `cliente` (" & vbCrLf &
                    "`id` int(11) NOT NULL AUTO_INCREMENT, " & vbCrLf &
                    "`cedula` varchar(45) NOT NULL," & vbCrLf &
                    "`nombre` varchar(45) NOT NULL, " & vbCrLf &
                    "`apellido` varchar(45) NOT NULL," & vbCrLf &
                    "`telefono` varchar(45) DEFAULT NULL, " & vbCrLf &
                    "`email` varchar(45) DEFAULT NULL," & vbCrLf &
                    "`ruta` varchar(110) NOT NULL," & vbCrLf &
                    "`nacimiento` date DEFAULT '2000-01-01'," & vbCrLf &
                    "`huella` longblob, " & vbCrLf &
                    " PRIMARY KEY (`id`) " & vbCrLf &
                    ") "

                Case "conf"
                    strcadena = "CREATE TABLE `conf` ( " & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`unidad` varchar(1) NOT NULL DEFAULT 'E'," & vbCrLf &
                      "`enco` varchar(1) NOT NULL DEFAULT '2'," & vbCrLf &
                      "`inem` varchar(1) DEFAULT '1'," & vbCrLf &
                      "`incl` varchar(1) DEFAULT '1'," & vbCrLf &
                      "`vaen` varchar(1) DEFAULT '1'," & vbCrLf &
                      "`nuen` varchar(1) DEFAULT NULL," & vbCrLf &
                      "`paab` int(1) NOT NULL DEFAULT '1'," & vbCrLf &
                      "`cocl` int(1) NOT NULL DEFAULT '1'," & vbCrLf &
                      "`nuco` int(1) NOT NULL DEFAULT '1'," & vbCrLf &
                      "`numaco` int(3) NOT NULL DEFAULT '1'," & vbCrLf &
                      "`huella` int(1) NOT NULL DEFAULT '1'," & vbCrLf &
                      "imp int(1) NOT NULL DEFAULT '1'," & vbCrLf &
                      "nuencl int(1) NOT NULL DEFAULT '1'," & vbCrLf &
                      "puerto int(2) NOT NULL DEFAULT '1'," & vbCrLf &
                      "pepaab int(1) NOT NULL DEFAULT '2'," & vbCrLf &
                      "tipopc int(1) NOT NULL DEFAULT '1'," & vbCrLf &
                      "rescon int(1) NOT NULL DEFAULT '2'," & vbCrLf &
                      "diasres int(2) NOT NULL DEFAULT '30'," & vbCrLf &
                      "vacoon int(1) NOT NULL DEFAULT '2'," & vbCrLf &
                      "vaabca int(1) NOT NULL DEFAULT '2'," & vbCrLf &
                      "hofoin int(1) NOT NULL DEFAULT '2'," & vbCrLf &
                      "vahoen int(1) NOT NULL DEFAULT '2'," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP, " & vbCrLf &
                      "PRIMARY KEY (`id`) " & vbCrLf &
                     ")"
                    booinserte = True
                    strInsert = "INSERT conf (id,unidad,enco,inem,incl,vaen,nuen,paab,cocl,nuco,numaco)VALUES(1,'e',2,1,1,1,8,1,1,8,60)"
                Case "congelado"
                    strcadena = " CREATE TABLE `congelado` ( " & vbCrLf &
                      "`serial` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`cedula` varchar(45) NOT NULL," & vbCrLf &
                      "`dias` varchar(45) NOT NULL," & vbCrLf &
                      "`estado` varchar(45) NOT NULL," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                      "PRIMARY KEY (`serial`)" & vbCrLf &
                    ") "
                Case "cortesias"
                    strcadena = " CREATE TABLE `cortesias` ( " & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`idcliente` int NOT NULL," & vbCrLf &
                      "`cant` int NOT NULL," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                      "PRIMARY KEY (`id`)" & vbCrLf &
                    ") "
                Case "cuenta_cliente"
                    strcadena = " CREATE TABLE `cuenta_cliente` (" & vbCrLf &
                                  "`idcuenta_cliente` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                                  "`cuencli_idfactura` int(11) NOT NULL," & vbCrLf &
                                  "`cuencli_valorabono` int(11) NOT NULL," & vbCrLf &
                                  "`cuencli_fechaabono` timestamp NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                                  "PRIMARY KEY (`idcuenta_cliente`)," & vbCrLf &
                                  "KEY `cuencli_idfactura_idx` (`cuencli_idfactura`)," & vbCrLf &
                                  "CONSTRAINT `cuencli_idfactura` FOREIGN KEY (`cuencli_idfactura`) REFERENCES `factura` (`id_factura`) ON DELETE NO ACTION ON UPDATE NO ACTION )"
                Case "detalles"
                    strcadena = " CREATE TABLE `detalles` (" & vbCrLf &
                      "`id` int(11) unsigned NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`cedula` varchar(45) NOT NULL," & vbCrLf &
                      "`fecha_pago` date DEFAULT NULL," & vbCrLf &
                      "`fecha_fin` varchar(45) NOT NULL," & vbCrLf &
                      "`tiempo` varchar(45) NOT NULL," & vbCrLf &
                      "`valor` varchar(45) NOT NULL," & vbCrLf &
                      "`tarjeta` int(1) NOT NULL DEFAULT 2," & vbCrLf &
                      "PRIMARY KEY (`id`) " & vbCrLf &
                    ") "
                Case "detalle_producto"
                    strcadena = " CREATE TABLE `detalle_producto` (" & vbCrLf &
                      "`iddetalle_producto` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`detpro_idfactura` int(11) NOT NULL," & vbCrLf &
                      "`detpro_idproducto` int(11) NOT NULL," & vbCrLf &
                      "`detpro_cantidad` int(11) NOT NULL," & vbCrLf &
                      "`detpro_precio` int(11) NOT NULL," & vbCrLf &
                      "PRIMARY KEY (`iddetalle_producto`)," & vbCrLf &
                      "KEY `detpro_idfactura_idx` (`detpro_idfactura`)," & vbCrLf &
                      "KEY `detpro_idpro_idx` (`detpro_idproducto`)," & vbCrLf &
                      "CONSTRAINT `detalle_producto_ibfk_1` FOREIGN KEY (`detpro_idproducto`) REFERENCES `producto` (`id`)," & vbCrLf &
                      "CONSTRAINT `detpro_idfactura` FOREIGN KEY (`detpro_idfactura`) REFERENCES `factura` (`id_factura`) ON DELETE NO ACTION ON UPDATE NO ACTION )"

                Case "email"
                    strcadena = " CREATE TABLE `email` ( " & vbCrLf &
                     "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                     "`em` varchar(50) DEFAULT NULL," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ") "
                    booinserte = True
                    strInsert = "INSERT INTO email (em) VALUES ('mauricio590@hotmail.com')"
                Case "empleado"
                    strcadena = "  CREATE TABLE `empleado` (" & vbCrLf &
                     " `id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                     "`cedula` varchar(255) NOT NULL DEFAULT ''," & vbCrLf &
                     " `nombre` varchar(255) NOT NULL DEFAULT ''," & vbCrLf &
                     "`apellido` varchar(255) NOT NULL DEFAULT ''," & vbCrLf &
                     " `cell` varchar(255) NOT NULL DEFAULT ''," & vbCrLf &
                     "`MO` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," & vbCrLf &
                     " `ruta` varchar(100) NOT NULL," & vbCrLf &
                      "`huella` longblob," & vbCrLf &
                      "PRIMARY KEY (`id`)" & vbCrLf &
                    ") "
                Case "entrada"
                    strcadena = "CREATE TABLE entrada(" & vbCrLf &
                                "id INT auto_increment," & vbCrLf &
                                "cedula VARCHAR(15), " & vbCrLf &
                                "fecha timestamp DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                                "PRIMARY KEY(id))"
                Case "factura"
                    strcadena = " CREATE TABLE `factura` (" & vbCrLf &
                                  "`id_factura` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                                  "`fac_idcliente` bigint(20) DEFAULT NULL," & vbCrLf &
                                  "`fac_idempleado` int(11) NOT NULL," & vbCrLf &
                                  "`fac_fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                                  "`fac_tipo` int(1) NOT NULL," & vbCrLf &
                                  "PRIMARY KEY (`id_factura`)) "

                Case "gastos"
                    strcadena = " CREATE TABLE `gastos` (" & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`idtipo` int(3) NOT NULL," & vbCrLf &
                      "`descripcion` longtext," & vbCrLf &
                      "`valor` int(11) NOT NULL," & vbCrLf &
                      "`fecha` date NOT NULL," & vbCrLf &
                      "PRIMARY KEY (`id`)" & vbCrLf &
                    ") "

                Case "hora"
                    strcadena = "CREATE TABLE hora( " & vbCrLf &
                        "id INT AUTO_INCREMENT, " & vbCrLf &
                        "no VARCHAR(3) NOT NULL, " & vbCrLf &
                        "nombre VARCHAR(30) NOT NULL, " & vbCrLf &
                        "PRIMARY KEY(id))"
                    booinserte = True
                    strInsert = "INSERT INTO `hora`(`no`,nombre) VALUES ('4','4 AM'),('5','5 AM'),('6','6 AM'),('7','7 AM'),('8','8 AM'),('9','9 AM'),('10','10 AM'),('11','11 AM'),('12','12 M'),('13','1 PM'),('14','2 PM'),('15','3 PM'),('16','4 PM'),('17','5 PM'),('18','6 PM'),('19','7 PM'),('20','8 PM'),('21','9 PM')"
                Case "horario"
                    strcadena = "CREATE TABLE horario(" & vbCrLf &
                        "id INT AUTO_INCREMENT," & vbCrLf &
                        "persona_id INT NOT NULL," & vbCrLf &
                        "hora_id INT NOT NULL," & vbCrLf &
                        "PRIMARY KEY(id))"
                Case "informacion"
                    strcadena = " CREATE TABLE `informacion` (" & vbCrLf &
                    "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                    "`idonline` int(3) NOT NULL," & vbCrLf &
                    "`nit` varchar(50) NOT NULL," & vbCrLf &
                    "`no` varchar(200) NOT NULL," & vbCrLf &
                    "`regimen` varchar(50) NOT NULL," & vbCrLf &
                    "`propietario` varchar(200) NOT NULL," & vbCrLf &
                    "telefono VARCHAR(30), " & vbCrLf &
                    "direccion TEXT, " & vbCrLf &
                    "PRIMARY KEY (`id`))"
                Case "kardex"
                    strcadena = "CREATE TABLE kardex ( " & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`idproducto` int(11) DEFAULT '0'," & vbCrLf &
                      "`idfactura` int(11) DEFAULT '0'," & vbCrLf &
                      "`cantidad` double DEFAULT '0'," & vbCrLf &
                      "`valor` double DEFAULT '0'," & vbCrLf &
                      "`scantidad` double DEFAULT '0'," & vbCrLf &
                      "`costo` double DEFAULT '0'," & vbCrLf &
                       "`mov` INT(2) DEFAULT '0'," & vbCrLf &
                        "nota text," & vbCrLf &
                      "`modificado` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," & vbCrLf &
                      "PRIMARY KEY (`id`));"
                Case "lic"
                    strcadena = "  CREATE TABLE `lic` (" & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`li` date NOT NULL," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ") "
                Case "login"
                    strcadena = "CREATE TABLE `login` (" & vbCrLf &
                     " `id` INT AUTO_INCREMENT," & vbCrLf &
                     " `usuario` varchar(45) NOT NULL," & vbCrLf &
                     " `contraseña` varchar(45) NOT NULL," & vbCrLf &
                     " `nivel` int(2) NOT NULL DEFAULT '1'," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ")"
                    booinserte = True
                    strInsert = "INSERT INTO login (usuario,contraseña,nivel)VALUES('mauro','bandband',4),('usuario','gym',4)"


                Case "logs"
                    strcadena = "CREATE TABLE logs( " & vbCrLf &
                   "id int auto_increment," & vbCrLf &
                    "cedula VARCHAR(20) NOT NULL," & vbCrLf &
                    "fechaCorteOld DATE  NOT NULL," & vbCrLf &
                    "fechaPagoOld DATE NOT NULL, " & vbCrLf &
                    "fechaCorteNew DATE NOT NULL," & vbCrLf &
                    "tarifa VARCHAR(255) NOT NULL," & vbCrLf &
                    "tarifaDias INT NOT NULL," & vbCrLf &
                    "usuario_id INT NOT NULL," & vbCrLf &
                    "modificado TIMESTAMP DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                    "PRIMARY KEY(id))"


                Case "medida"
                    strcadena = " CREATE TABLE `medida` (" & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`cliente` varchar(20) NOT NULL," & vbCrLf &
                      "`edad` int(3) DEFAULT NULL," & vbCrLf &
                      "`sexo` int(3) DEFAULT NULL," & vbCrLf &
                      "`peso` int(3) DEFAULT NULL," & vbCrLf &
                      "`talla` int(3) DEFAULT NULL," & vbCrLf &
                      "`fcxmin` int(3) DEFAULT NULL," & vbCrLf &
                      "`imc` int(3) DEFAULT NULL," & vbCrLf &
                      "`porgrasa` int(3) DEFAULT NULL," & vbCrLf &
                      "`pantorrilla` int(3) DEFAULT NULL," & vbCrLf &
                      "`muslomedio` int(3) DEFAULT NULL," & vbCrLf &
                      "`gluteo` int(3) DEFAULT NULL," & vbCrLf &
                      "`cintura` int(3) DEFAULT NULL," & vbCrLf &
                      "`espalda` int(3) DEFAULT NULL," & vbCrLf &
                      "`pectorales` int(3) DEFAULT NULL," & vbCrLf &
                      "`brizq` int(3) DEFAULT NULL," & vbCrLf &
                      "`brder` int(3) DEFAULT NULL," & vbCrLf &
                      "`restriccion` longtext," & vbCrLf &
                      "`objetivo` longtext," & vbCrLf &
                      "`pechoespalda` int(3) DEFAULT NULL," & vbCrLf &
                       "`cuello` int(3) DEFAULT NULL," & vbCrLf &
                       "`piizq` int(3) DEFAULT NULL," & vbCrLf &
                       "`pider` int(3) DEFAULT NULL," & vbCrLf &
                       "`bicep` int(3) DEFAULT NULL," & vbCrLf &
                       "`tricep` int(3) DEFAULT NULL," & vbCrLf &
                       "`subes` int(3) DEFAULT NULL," & vbCrLf &
                       "`supra` int(3) DEFAULT NULL," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ") "
                Case "pago"
                    strcadena = " CREATE TABLE `pago` (" & vbCrLf &
                      "`cedula` varchar(16) DEFAULT NULL," & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`fecha_corte` date DEFAULT NULL," & vbCrLf &
                      "`fecha_pago` date NOT NULL," & vbCrLf &
                      "`idprecio` bigint(11) DEFAULT NULL," & vbCrLf &
                      "PRIMARY KEY (`id`)" & vbCrLf &
                    ") "
                Case "personalizado"
                    strcadena = "CREATE TABLE personalizado(" & vbCrLf &
                        "id INT AUTO_INCREMENT," & vbCrLf &
                        "empleado_id INT NOT NULL," & vbCrLf &
                        "persona_id INT NOT NULL," & vbCrLf &
                        "hora_id INT NOT NULL," & vbCrLf &
                        "PRIMARY KEY(id)," & vbCrLf &
                        "UNIQUE(empleado_id, persona_id))"
                Case "precio"
                    strcadena = "CREATE TABLE `precio` (" & vbCrLf &
                      "`serial` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`tipo` varchar(45) NOT NULL," & vbCrLf &
                      "`valor` varchar(45) NOT NULL," & vbCrLf &
                      "`dias` int(11) DEFAULT NULL," & vbCrLf &
                      "`det` int(1) DEFAULT 1," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," & vbCrLf &
                     " PRIMARY KEY (`serial`,`tipo`)" & vbCrLf &
                    ")"
                Case "producto"
                    strcadena = " CREATE TABLE `producto` (" & vbCrLf &
                  "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                  "`pro_referencia` varchar(30) NOT NULL," & vbCrLf &
                  "`pro_nombre` varchar(55) NOT NULL," & vbCrLf &
                  "`pro_preciocosto` int(11) NOT NULL," & vbCrLf &
                  "`pro_precioventa` int(11) NOT NULL," & vbCrLf &
                  "`pro_descripcion` varchar(45) DEFAULT NULL," & vbCrLf &
                  "`pro_cantidad` int(3) NOT NULL," & vbCrLf &
                  "PRIMARY KEY (`id`)," & vbCrLf &
                  "UNIQUE KEY `pro_referencia_UNIQUE` (`pro_referencia`)" & vbCrLf &
                 ") "
                Case "reporte"
                    strcadena = "CREATE TABLE `reporte` (" & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`no` varchar(100) NOT NULL," & vbCrLf &
                      "`orden` varchar(1) NOT NULL DEFAULT 5," & vbCrLf &
                      "`mo` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                      "PRIMARY KEY (`id`)" & vbCrLf &
                    ")"
                    booinserte = True
                    strInsert = "INSERT INTO reporte(no,orden) VALUES('Mensualidades',5),('Abonos',5),('Gastos',5),('Clientes Por Vencer',5),('Clientes Activos',5),('Clientes totales',5),('Ingreso empleados',5),('ventas',5),('Detalle de venta',5),('Obsequio de cortesias',5),('Reporte de congelados',5)," & vbCrLf &
                                "('Consolidado por tarifas',5),('Historial de clientes',5),('Ingresos por horas',5),('Compras',5),('Detalle Compra',5),('Reporte de ajuste de inventario',5),('Cumpleaños',5),('Clientes Inactivos',5),('Informe del mes por dia',5),('Ingreso Spa',5),('Ganancias en Ventas',5),('Clientes por Mes',5)" & vbCrLf &
                                ",('Informe de Abonos por Mes',1),('Informe de Temperatura',2),('Horario de Clientes por Horas',2),('Ingreso por Horas Detallado',2)"
                Case "reporte_empleado"
                    strcadena = " CREATE TABLE `reporte_empleado` (" & vbCrLf &
                                  "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                                  "`idempleado` varchar(45) NOT NULL," & vbCrLf &
                                  "`fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," & vbCrLf &
                                   "PRIMARY KEY (`id`)) "
                Case "tarifasespeciales"
                    strcadena = "CREATE TABLE tarifasespeciales (" & vbCrLf &
                      "id int(6) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "idtarifa int not null," & vbCrLf &
                      "horaEntrada int(2) not null," & vbCrLf &
                      "horasalida int(2) not null," & vbCrLf &
                      "PRIMARY KEY (`id`))"
                Case "temperatura"
                    strcadena = "CREATE TABLE temperatura(" & vbCrLf &
                        "id INT AUTO_INCREMENT," & vbCrLf &
                        "persona_id INT NOT NULL," & vbCrLf &
                        "tem varchar(5) NOT NULL," & vbCrLf &
                        "obs varchar(100)," & vbCrLf &
                        "`fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," & vbCrLf &
                        "PRIMARY KEY(id))"

                Case "tipogasto"
                    strcadena = "CREATE TABLE `tipogasto` (" & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`nombre` varchar(100) NOT NULL," & vbCrLf &
                      "`descripcion` text," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ")"

                    booinserte = True
                    strInsert = "INSERT tipoGasto (nombre) values ('SERVICIOS'),('NOMINA'),('PROVEEDORES'),('TRASNPORTE'),('OTROS')"
                Case "tipomovimiento"
                    strcadena = "CREATE TABLE `tipomovimiento` (" & vbCrLf &
                      "`id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf &
                      "`nombre` varchar(100) NOT NULL," & vbCrLf &
                      "`descripcion` text," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ")"

                    booinserte = True
                    strInsert = "INSERT tipomovimiento (nombre) values ('MENSUALIDAD'),('SALDO'),('PRODUCTOS'),('GASTOS'),('COMPRA'),('AJUSTE'),('VENTA')"

                Case "versiones"
                    strcadena = "CREATE TABLE `versiones` (" & vbCrLf &
                     " `id` int(6) NOT NULL AUTO_INCREMENT," & vbCrLf &
                     "`ac` tinyint(1) NOT NULL DEFAULT '1'," & vbCrLf &
                     "`ve` varchar(20) DEFAULT ''," & vbCrLf &
                     " `modificado` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ")"
                Case "versionesacceso"
                    strcadena = "CREATE TABLE `versionesacceso` (" & vbCrLf &
                     " `id` int(6) NOT NULL AUTO_INCREMENT," & vbCrLf &
                     "`ac` tinyint(1) NOT NULL DEFAULT '1'," & vbCrLf &
                     "`ve` varchar(20) DEFAULT ''," & vbCrLf &
                     " `modificado` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," & vbCrLf &
                     " PRIMARY KEY (`id`)" & vbCrLf &
                    ")"
                Case "listainformes"
                    strcadena = "CREATE TABLE listainformes(" & vbCrLf &
                    "id INT AUTO_INCREMENT," & vbCrLf &
                    "fecha1 DATE  NOT NULL," & vbCrLf &
                    "fecha2 DATE NOT NULL," & vbCrLf &
                    "estado Int(2) DEFAULT 1, " & vbCrLf &
                    "PRIMARY KEY(id))"
                    booinserte = True
                    strInsert = "INSERT listainformes (fecha1,fecha2)VALUES ('2019-01-01','2019-01-31')," & vbCrLf &
                    "('2019-02-01','2019-02-28'),('2019-03-01','2019-03-31'),('2019-04-01','2019-04-30')," & vbCrLf &
                    "('2019-05-01','2019-05-31'),('2019-06-01','2019-06-30'),('2019-07-01','2019-07-31')," & vbCrLf &
                    "('2019-08-01','2019-08-31'),('2019-09-01','2019-09-30'),('2019-10-01','2019-10-31')," & vbCrLf &
                    "('2019-11-01','2019-11-30'),('2019-12-01','2019-12-31');"

                Case "controldeinformes"
                    strcadena = "CREATE TABLE controldeinformes(" & vbCrLf &
                    "id INT AUTO_INCREMENT," & vbCrLf &
                    "idfecha INT NOT NULL," & vbCrLf &
                    "idproximo INT NOT NULL," & vbCrLf &
                    "mo TIMESTAMP DEFAULT CURRENT_TIMESTAMP," & vbCrLf &
                    "PRIMARY KEY (id))"



            End Select

            con.registreDatos(strcadena)
            If booinserte Then
                con.registreDatos(strInsert)
            End If
        End If

    End Sub

    Public Sub examinarBase()

        verifiqueListaInformes()

        examineTabla("abonos")
        examineTabla("caja")
        examineTabla("caja1")
        examineTabla("caja2")
        examineTabla("cliente")
        examineTabla("conf")
        examineTabla("congelado")
        examineTabla("cortesias")
        examineTabla("cuenta_cliente")
        examineTabla("detalles")
        examineTabla("detalle_producto")
        examineTabla("email")
        examineTabla("empleado")
        examineTabla("entrada")
        examineTabla("factura")
        examineTabla("hora")
        examineTabla("horario")
        examineTabla("cuenta_cliente")
        examineTabla("gastos")
        examineTabla("kardex")
        examineTabla("lic")
        examineTabla("logs")
        examineTabla("login")
        examineTabla("medida")
        examineTabla("pago")
        examineTabla("personalizado")
        examineTabla("producto")
        examineTabla("precio")
        examineTabla("reporte")
        examineTabla("reporte_empleado")
        examineTabla("tarifasespeciales")
        examineTabla("tipogasto")
        examineTabla("tipomovimiento")
        examineTabla("temperatura")
        examineTabla("versiones")
        examineTabla("versionesacceso")
        examineTabla("listainformes")
        examineTabla("controldeinformes")
        examineTabla("informacion")
        tablaReportes()
        tablaMovimientos()
        verifiqueColumna("abonos")
        verifiqueColumna("cliente")
        verifiqueColumna("conf")
        verifiqueColumna("detalles")
        verifiqueColumna("entrada")
        verifiqueColumna("informacion")
        verifiqueColumna("kardex")
        verifiqueColumna("medida")
        verifiqueColumna("login")
        verifiqueColumna("precio")
        verifiqueColumna("temperatura")
        If UltimaVersion() < "5.2.0.119" Then
            con.registreDatos("ALTER TABLE `gym`.`abonos` CHANGE COLUMN `MO` `MO` DATETIME(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3) ON UPDATE CURRENT_TIMESTAMP(3)")

        End If

    End Sub



End Module
