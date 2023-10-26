Public Class FichaCorporalVO
    Private Profesional As String
    Private NExpediente As String
    Private Nombre As String
    Private Domicilio As String
    Private Edad As String
    Private EstadoCivil As String
    Private FechaNacimiento As String
    Private Correo As String
    Private Telefono As String
    Private MotivoConsulta As String
    Private EnfCardiacas As Integer
    Private EnfRenales As Integer
    Private EnfCirculatorias As Integer
    Private EnfPulmonares As Integer
    Private EnfDigestivas As Integer
    Private EnfHematologicas As Integer
    Private EnfEndocrinas As Integer
    Private EnfNeurologicas As Integer
    Private Presion As Integer
    Private Alergia As Integer
    Private Piel As Integer
    Private Convulsiones As Integer
    Private Tabaco As Integer
    Private Alcohol As Integer
    Private Drogas As Integer
    Private Marcapasos As Integer
    Private Peso As String
    Private Estatura As String
    Private CinturaI As String
    Private CinturaM As String
    Private CinturaF As String
    Private PechoI As String
    Private PechoM As String
    Private PechoF As String
    Private CaderaI As String
    Private CaderaM As String
    Private CaderaF As String
    Private BIzquierdoI As String
    Private BIzquierdoM As String
    Private BIzquierdoF As String
    Private BDerechoI As String
    Private BDerechoM As String
    Private BDerechoF As String
    Private MizquierdoI As String
    Private MizquierdoM As String
    Private MizquierdoF As String
    Private MDerechoI As String
    Private MDerechoM As String
    Private MDerechoF As String
    Private AAltoI As String
    Private AAltoM As String
    Private AAltoF As String
    Private AMedioI As String
    Private AMedioM As String
    Private AMedioF As String
    Private ABajoI As String
    Private ABajoM As String
    Private ABajoF As String
    Private ObsGenerales As String
    Private Diagnostico As String
    Private FirmaUsuario As String

    Public Sub New(profesional As String, nExpediente As String, nombre As String, domicilio As String, edad As String, estadoCivil As String, fechaNacimiento As String, correo As String, telefono As String, motivoConsulta As String, enfCardiacas As Integer, enfRenales As Integer, enfCirculatorias As Integer, enfPulmonares As Integer, enfDigestivas As Integer, enfHematologicas As Integer, enfEndocrinas As Integer, enfNeurologicas As Integer, presion As Integer, alergia As Integer, piel As Integer, convulsiones As Integer, tabaco As Integer, alcohol As Integer, drogas As Integer, marcapasos As Integer, peso As String, estatura As String, cinturaI As String, cinturaM As String, cinturaF As String, pechoI As String, pechoM As String, pechoF As String, caderaI As String, caderaM As String, caderaF As String, bIzquierdoI As String, bIzquierdoM As String, bIzquierdoF As String, bDerechoI As String, bDerechoM As String, bDerechoF As String, mizquierdoI As String, mizquierdoM As String, mizquierdoF As String, mDerechoI As String, mDerechoM As String, mDerechoF As String, aAltoI As String, aAltoM As String, aAltoF As String, aMedioI As String, aMedioM As String, aMedioF As String, aBajoI As String, aBajoM As String, aBajoF As String, obsGenerales As String, diagnostico As String, firmaUsuario As String)
        Me.Profesional = profesional
        Me.NExpediente = nExpediente
        Me.Nombre = nombre
        Me.Domicilio = domicilio
        Me.Edad = edad
        Me.EstadoCivil = estadoCivil
        Me.FechaNacimiento = fechaNacimiento
        Me.Correo = correo
        Me.Telefono = telefono
        Me.MotivoConsulta = motivoConsulta
        Me.EnfCardiacas = enfCardiacas
        Me.EnfRenales = enfRenales
        Me.EnfCirculatorias = enfCirculatorias
        Me.EnfPulmonares = enfPulmonares
        Me.EnfDigestivas = enfDigestivas
        Me.EnfHematologicas = enfHematologicas
        Me.EnfEndocrinas = enfEndocrinas
        Me.EnfNeurologicas = enfNeurologicas
        Me.Presion = presion
        Me.Alergia = alergia
        Me.Piel = piel
        Me.Convulsiones = convulsiones
        Me.Tabaco = tabaco
        Me.Alcohol = alcohol
        Me.Drogas = drogas
        Me.Marcapasos = marcapasos
        Me.Peso = peso
        Me.Estatura = estatura
        Me.CinturaI = cinturaI
        Me.CinturaM = cinturaM
        Me.CinturaF = cinturaF
        Me.PechoI = pechoI
        Me.PechoM = pechoM
        Me.PechoF = pechoF
        Me.CaderaI = caderaI
        Me.CaderaM = caderaM
        Me.CaderaF = caderaF
        Me.BIzquierdoI = bIzquierdoI
        Me.BIzquierdoM = bIzquierdoM
        Me.BIzquierdoF = bIzquierdoF
        Me.BDerechoI = bDerechoI
        Me.BDerechoM = bDerechoM
        Me.BDerechoF = bDerechoF
        Me.MizquierdoI = mizquierdoI
        Me.MizquierdoM = mizquierdoM
        Me.MizquierdoF = mizquierdoF
        Me.MDerechoI = mDerechoI
        Me.MDerechoM = mDerechoM
        Me.MDerechoF = mDerechoF
        Me.AAltoI = aAltoI
        Me.AAltoM = aAltoM
        Me.AAltoF = aAltoF
        Me.AMedioI = aMedioI
        Me.AMedioM = aMedioM
        Me.AMedioF = aMedioF
        Me.ABajoI = aBajoI
        Me.ABajoM = aBajoM
        Me.ABajoF = aBajoF
        Me.ObsGenerales = obsGenerales
        Me.Diagnostico = diagnostico
        Me.FirmaUsuario = firmaUsuario
    End Sub

    Public Property Profesional1 As String
        Get
            Return Profesional
        End Get
        Set(value As String)
            Profesional = value
        End Set
    End Property

    Public Property NExpediente1 As String
        Get
            Return NExpediente
        End Get
        Set(value As String)
            NExpediente = value
        End Set
    End Property

    Public Property Nombre1 As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property Domicilio1 As String
        Get
            Return Domicilio
        End Get
        Set(value As String)
            Domicilio = value
        End Set
    End Property

    Public Property Edad1 As String
        Get
            Return Edad
        End Get
        Set(value As String)
            Edad = value
        End Set
    End Property

    Public Property EstadoCivil1 As String
        Get
            Return EstadoCivil
        End Get
        Set(value As String)
            EstadoCivil = value
        End Set
    End Property

    Public Property FechaNacimiento1 As String
        Get
            Return FechaNacimiento
        End Get
        Set(value As String)
            FechaNacimiento = value
        End Set
    End Property

    Public Property Correo1 As String
        Get
            Return Correo
        End Get
        Set(value As String)
            Correo = value
        End Set
    End Property

    Public Property Telefono1 As String
        Get
            Return Telefono
        End Get
        Set(value As String)
            Telefono = value
        End Set
    End Property

    Public Property MotivoConsulta1 As String
        Get
            Return MotivoConsulta
        End Get
        Set(value As String)
            MotivoConsulta = value
        End Set
    End Property

    Public Property EnfCardiacas1 As Integer
        Get
            Return EnfCardiacas
        End Get
        Set(value As Integer)
            EnfCardiacas = value
        End Set
    End Property

    Public Property EnfRenales1 As Integer
        Get
            Return EnfRenales
        End Get
        Set(value As Integer)
            EnfRenales = value
        End Set
    End Property

    Public Property EnfCirculatorias1 As Integer
        Get
            Return EnfCirculatorias
        End Get
        Set(value As Integer)
            EnfCirculatorias = value
        End Set
    End Property

    Public Property EnfPulmonares1 As Integer
        Get
            Return EnfPulmonares
        End Get
        Set(value As Integer)
            EnfPulmonares = value
        End Set
    End Property

    Public Property EnfDigestivas1 As Integer
        Get
            Return EnfDigestivas
        End Get
        Set(value As Integer)
            EnfDigestivas = value
        End Set
    End Property

    Public Property EnfHematologicas1 As Integer
        Get
            Return EnfHematologicas
        End Get
        Set(value As Integer)
            EnfHematologicas = value
        End Set
    End Property

    Public Property EnfEndocrinas1 As Integer
        Get
            Return EnfEndocrinas
        End Get
        Set(value As Integer)
            EnfEndocrinas = value
        End Set
    End Property

    Public Property EnfNeurologicas1 As Integer
        Get
            Return EnfNeurologicas
        End Get
        Set(value As Integer)
            EnfNeurologicas = value
        End Set
    End Property

    Public Property Presion1 As Integer
        Get
            Return Presion
        End Get
        Set(value As Integer)
            Presion = value
        End Set
    End Property

    Public Property Alergia1 As Integer
        Get
            Return Alergia
        End Get
        Set(value As Integer)
            Alergia = value
        End Set
    End Property

    Public Property Piel1 As Integer
        Get
            Return Piel
        End Get
        Set(value As Integer)
            Piel = value
        End Set
    End Property

    Public Property Convulsiones1 As Integer
        Get
            Return Convulsiones
        End Get
        Set(value As Integer)
            Convulsiones = value
        End Set
    End Property

    Public Property Tabaco1 As Integer
        Get
            Return Tabaco
        End Get
        Set(value As Integer)
            Tabaco = value
        End Set
    End Property

    Public Property Alcohol1 As Integer
        Get
            Return Alcohol
        End Get
        Set(value As Integer)
            Alcohol = value
        End Set
    End Property

    Public Property Drogas1 As Integer
        Get
            Return Drogas
        End Get
        Set(value As Integer)
            Drogas = value
        End Set
    End Property

    Public Property Marcapasos1 As Integer
        Get
            Return Marcapasos
        End Get
        Set(value As Integer)
            Marcapasos = value
        End Set
    End Property

    Public Property Peso1 As String
        Get
            Return Peso
        End Get
        Set(value As String)
            Peso = value
        End Set
    End Property

    Public Property Estatura1 As String
        Get
            Return Estatura
        End Get
        Set(value As String)
            Estatura = value
        End Set
    End Property

    Public Property CinturaI1 As String
        Get
            Return CinturaI
        End Get
        Set(value As String)
            CinturaI = value
        End Set
    End Property

    Public Property CinturaM1 As String
        Get
            Return CinturaM
        End Get
        Set(value As String)
            CinturaM = value
        End Set
    End Property

    Public Property CinturaF1 As String
        Get
            Return CinturaF
        End Get
        Set(value As String)
            CinturaF = value
        End Set
    End Property

    Public Property PechoI1 As String
        Get
            Return PechoI
        End Get
        Set(value As String)
            PechoI = value
        End Set
    End Property

    Public Property PechoM1 As String
        Get
            Return PechoM
        End Get
        Set(value As String)
            PechoM = value
        End Set
    End Property

    Public Property PechoF1 As String
        Get
            Return PechoF
        End Get
        Set(value As String)
            PechoF = value
        End Set
    End Property

    Public Property CaderaI1 As String
        Get
            Return CaderaI
        End Get
        Set(value As String)
            CaderaI = value
        End Set
    End Property

    Public Property CaderaM1 As String
        Get
            Return CaderaM
        End Get
        Set(value As String)
            CaderaM = value
        End Set
    End Property

    Public Property CaderaF1 As String
        Get
            Return CaderaF
        End Get
        Set(value As String)
            CaderaF = value
        End Set
    End Property

    Public Property BIzquierdoI1 As String
        Get
            Return BIzquierdoI
        End Get
        Set(value As String)
            BIzquierdoI = value
        End Set
    End Property

    Public Property BIzquierdoM1 As String
        Get
            Return BIzquierdoM
        End Get
        Set(value As String)
            BIzquierdoM = value
        End Set
    End Property

    Public Property BIzquierdoF1 As String
        Get
            Return BIzquierdoF
        End Get
        Set(value As String)
            BIzquierdoF = value
        End Set
    End Property

    Public Property BDerechoI1 As String
        Get
            Return BDerechoI
        End Get
        Set(value As String)
            BDerechoI = value
        End Set
    End Property

    Public Property BDerechoM1 As String
        Get
            Return BDerechoM
        End Get
        Set(value As String)
            BDerechoM = value
        End Set
    End Property

    Public Property BDerechoF1 As String
        Get
            Return BDerechoF
        End Get
        Set(value As String)
            BDerechoF = value
        End Set
    End Property

    Public Property MizquierdoI1 As String
        Get
            Return MizquierdoI
        End Get
        Set(value As String)
            MizquierdoI = value
        End Set
    End Property

    Public Property MizquierdoM1 As String
        Get
            Return MizquierdoM
        End Get
        Set(value As String)
            MizquierdoM = value
        End Set
    End Property

    Public Property MizquierdoF1 As String
        Get
            Return MizquierdoF
        End Get
        Set(value As String)
            MizquierdoF = value
        End Set
    End Property

    Public Property MDerechoI1 As String
        Get
            Return MDerechoI
        End Get
        Set(value As String)
            MDerechoI = value
        End Set
    End Property

    Public Property MDerechoM1 As String
        Get
            Return MDerechoM
        End Get
        Set(value As String)
            MDerechoM = value
        End Set
    End Property

    Public Property MDerechoF1 As String
        Get
            Return MDerechoF
        End Get
        Set(value As String)
            MDerechoF = value
        End Set
    End Property

    Public Property AAltoI1 As String
        Get
            Return AAltoI
        End Get
        Set(value As String)
            AAltoI = value
        End Set
    End Property

    Public Property AAltoM1 As String
        Get
            Return AAltoM
        End Get
        Set(value As String)
            AAltoM = value
        End Set
    End Property

    Public Property AAltoF1 As String
        Get
            Return AAltoF
        End Get
        Set(value As String)
            AAltoF = value
        End Set
    End Property

    Public Property AMedioI1 As String
        Get
            Return AMedioI
        End Get
        Set(value As String)
            AMedioI = value
        End Set
    End Property

    Public Property AMedioM1 As String
        Get
            Return AMedioM
        End Get
        Set(value As String)
            AMedioM = value
        End Set
    End Property

    Public Property AMedioF1 As String
        Get
            Return AMedioF
        End Get
        Set(value As String)
            AMedioF = value
        End Set
    End Property

    Public Property ABajoI1 As String
        Get
            Return ABajoI
        End Get
        Set(value As String)
            ABajoI = value
        End Set
    End Property

    Public Property ABajoM1 As String
        Get
            Return ABajoM
        End Get
        Set(value As String)
            ABajoM = value
        End Set
    End Property

    Public Property ABajoF1 As String
        Get
            Return ABajoF
        End Get
        Set(value As String)
            ABajoF = value
        End Set
    End Property

    Public Property ObsGenerales1 As String
        Get
            Return ObsGenerales
        End Get
        Set(value As String)
            ObsGenerales = value
        End Set
    End Property

    Public Property Diagnostico1 As String
        Get
            Return Diagnostico
        End Get
        Set(value As String)
            Diagnostico = value
        End Set
    End Property

    Public Property FirmaUsuario1 As String
        Get
            Return FirmaUsuario
        End Get
        Set(value As String)
            FirmaUsuario = value
        End Set
    End Property
End Class
