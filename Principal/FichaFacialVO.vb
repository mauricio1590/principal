Public Class FichaFacialVO

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
    Private PCardiacas As Integer   'ENFERMEDADES CARDIACAS
    Private CCardiacas As String
    Private PCirculatorias As Integer   'ENFERMEDADES CIRCULATORIAS
    Private CCirculatorias As String
    Private PAlergias As Integer   'PRESENTA ALERGIAS
    Private CAlergias As String
    Private PRenales As Integer   'ENFERMEDADES RENALES
    Private CRenales As String
    Private PAzucar As Integer   'PROBLEMAS DE AZUCAR
    Private CAzucar As String
    Private PConvulsiones As Integer   'SUFRE CONVULSIONES
    Private CConvulsiones As String
    Private PDigestvas As Integer   'ENFERMEDADES DIGESTIVAS
    Private CDigestivas As String
    Private PPresion As Integer   'PROBLEMAS DE PRESIÓN
    Private CPresion As String
    Private PCremas As Integer   'CREMAS DE USO ACTUAL
    Private CCremas As String
    Private PLentes As Integer  'UTILIZA LENTES DE CONTACTO
    Private CLentes As String
    Private PPiel As Integer  'PRESENTA PROBLEMAS EN LA PIEL
    Private CPiel As String
    Private PCirugia As Integer  'SE HA REALIZADO ALGUNA CIRUGIA
    Private CCirugia As String
    Private PImplantes As Integer  'POSEE IMPLANTES DENTALES
    Private CImplantes As String
    Private PFractura As Integer  'TIENE ALGUNA FRACTURA FACIAL
    Private CFractura As String
    Private PMedicamento As Integer  'CONSUME ALGUN MEDICAMENTO
    Private CMeicamento As String
    Private PTratamiento As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private CTratamiento As String
    Private Observaciones As String 'OBSERVACIONES GENERALES
    Private PPSeca As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private PPLeveSeca As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private PPMedSeca As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private PPMuySeca As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private PPGrasa As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private PPLeveGrasa As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private PPMedGrasa As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private PPMuyGrasa As Integer  'TRATAMIENTOS DERMATOLÓGICOS
    Private ObservacionCutis As String
    Private Desvitalizada As Integer
    Private Asfictica As Integer
    Private Hidratada As Integer
    Private Standar As Integer

    Public Sub New(profesional As String, nExpediente As String, nombre As String, domicilio As String, edad As String, estadoCivil As String, fechaNacimiento As String, correo As String, telefono As String, motivoConsulta As String, pCardiacas As Integer, cCardiacas As String, pCirculatorias As Integer, cCirculatorias As String, pAlergias As Integer, cAlergias As String, pRenales As Integer, cRenales As String, pAzucar As Integer, cAzucar As String, pConvulsiones As Integer, cConvulsiones As String, pDigestvas As Integer, cDigestivas As String, pPresion As Integer, cPresion As String, pCremas As Integer, cCremas As String, pLentes As Integer, cLentes As String, pPiel As Integer, cPiel As String, pCirugia As Integer, cCirugia As String, pImplantes As Integer, cImplantes As String, pFractura As Integer, cFractura As String, pMedicamento As Integer, cMeicamento As String, pTratamiento As Integer, cTratamiento As String, observaciones As String, pPSeca As Integer, pPLeveSeca As Integer, pPMedSeca As Integer, pPMuySeca As Integer, pPGrasa As Integer, pPLeveGrasa As Integer, pPMedGrasa As Integer, pPMuyGrasa As Integer, observacionCutis As String, desvitalizada As Integer, asfictica As Integer, hidratada As Integer, standar As Integer)
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
        Me.PCardiacas = pCardiacas
        Me.CCardiacas = cCardiacas
        Me.PCirculatorias = pCirculatorias
        Me.CCirculatorias = cCirculatorias
        Me.PAlergias = pAlergias
        Me.CAlergias = cAlergias
        Me.PRenales = pRenales
        Me.CRenales = cRenales
        Me.PAzucar = pAzucar
        Me.CAzucar = cAzucar
        Me.PConvulsiones = pConvulsiones
        Me.CConvulsiones = cConvulsiones
        Me.PDigestvas = pDigestvas
        Me.CDigestivas = cDigestivas
        Me.PPresion = pPresion
        Me.CPresion = cPresion
        Me.PCremas = pCremas
        Me.CCremas = cCremas
        Me.PLentes = pLentes
        Me.CLentes = cLentes
        Me.PPiel = pPiel
        Me.CPiel = cPiel
        Me.PCirugia = pCirugia
        Me.CCirugia = cCirugia
        Me.PImplantes = pImplantes
        Me.CImplantes = cImplantes
        Me.PFractura = pFractura
        Me.CFractura = cFractura
        Me.PMedicamento = pMedicamento
        Me.CMeicamento = cMeicamento
        Me.PTratamiento = pTratamiento
        Me.CTratamiento = cTratamiento
        Me.Observaciones = observaciones
        Me.PPSeca = pPSeca
        Me.PPLeveSeca = pPLeveSeca
        Me.PPMedSeca = pPMedSeca
        Me.PPMuySeca = pPMuySeca
        Me.PPGrasa = pPGrasa
        Me.PPLeveGrasa = pPLeveGrasa
        Me.PPMedGrasa = pPMedGrasa
        Me.PPMuyGrasa = pPMuyGrasa
        Me.ObservacionCutis = observacionCutis
        Me.Desvitalizada = desvitalizada
        Me.Asfictica = asfictica
        Me.Hidratada = hidratada
        Me.Standar = standar
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

    Public Property PCardiacas1 As Integer
        Get
            Return PCardiacas
        End Get
        Set(value As Integer)
            PCardiacas = value
        End Set
    End Property

    Public Property CCardiacas1 As String
        Get
            Return CCardiacas
        End Get
        Set(value As String)
            CCardiacas = value
        End Set
    End Property

    Public Property PCirculatorias1 As Integer
        Get
            Return PCirculatorias
        End Get
        Set(value As Integer)
            PCirculatorias = value
        End Set
    End Property

    Public Property CCirculatorias1 As String
        Get
            Return CCirculatorias
        End Get
        Set(value As String)
            CCirculatorias = value
        End Set
    End Property

    Public Property PAlergias1 As Integer
        Get
            Return PAlergias
        End Get
        Set(value As Integer)
            PAlergias = value
        End Set
    End Property

    Public Property CAlergias1 As String
        Get
            Return CAlergias
        End Get
        Set(value As String)
            CAlergias = value
        End Set
    End Property

    Public Property PRenales1 As Integer
        Get
            Return PRenales
        End Get
        Set(value As Integer)
            PRenales = value
        End Set
    End Property

    Public Property CRenales1 As String
        Get
            Return CRenales
        End Get
        Set(value As String)
            CRenales = value
        End Set
    End Property

    Public Property PAzucar1 As Integer
        Get
            Return PAzucar
        End Get
        Set(value As Integer)
            PAzucar = value
        End Set
    End Property

    Public Property CAzucar1 As String
        Get
            Return CAzucar
        End Get
        Set(value As String)
            CAzucar = value
        End Set
    End Property

    Public Property PConvulsiones1 As Integer
        Get
            Return PConvulsiones
        End Get
        Set(value As Integer)
            PConvulsiones = value
        End Set
    End Property

    Public Property CConvulsiones1 As String
        Get
            Return CConvulsiones
        End Get
        Set(value As String)
            CConvulsiones = value
        End Set
    End Property

    Public Property PDigestvas1 As Integer
        Get
            Return PDigestvas
        End Get
        Set(value As Integer)
            PDigestvas = value
        End Set
    End Property

    Public Property CDigestivas1 As String
        Get
            Return CDigestivas
        End Get
        Set(value As String)
            CDigestivas = value
        End Set
    End Property

    Public Property PPresion1 As Integer
        Get
            Return PPresion
        End Get
        Set(value As Integer)
            PPresion = value
        End Set
    End Property

    Public Property CPresion1 As String
        Get
            Return CPresion
        End Get
        Set(value As String)
            CPresion = value
        End Set
    End Property

    Public Property PCremas1 As Integer
        Get
            Return PCremas
        End Get
        Set(value As Integer)
            PCremas = value
        End Set
    End Property

    Public Property CCremas1 As String
        Get
            Return CCremas
        End Get
        Set(value As String)
            CCremas = value
        End Set
    End Property

    Public Property PLentes1 As Integer
        Get
            Return PLentes
        End Get
        Set(value As Integer)
            PLentes = value
        End Set
    End Property

    Public Property CLentes1 As String
        Get
            Return CLentes
        End Get
        Set(value As String)
            CLentes = value
        End Set
    End Property

    Public Property PPiel1 As Integer
        Get
            Return PPiel
        End Get
        Set(value As Integer)
            PPiel = value
        End Set
    End Property

    Public Property CPiel1 As String
        Get
            Return CPiel
        End Get
        Set(value As String)
            CPiel = value
        End Set
    End Property

    Public Property PCirugia1 As Integer
        Get
            Return PCirugia
        End Get
        Set(value As Integer)
            PCirugia = value
        End Set
    End Property

    Public Property CCirugia1 As String
        Get
            Return CCirugia
        End Get
        Set(value As String)
            CCirugia = value
        End Set
    End Property

    Public Property PImplantes1 As Integer
        Get
            Return PImplantes
        End Get
        Set(value As Integer)
            PImplantes = value
        End Set
    End Property

    Public Property CImplantes1 As String
        Get
            Return CImplantes
        End Get
        Set(value As String)
            CImplantes = value
        End Set
    End Property

    Public Property PFractura1 As Integer
        Get
            Return PFractura
        End Get
        Set(value As Integer)
            PFractura = value
        End Set
    End Property

    Public Property CFractura1 As String
        Get
            Return CFractura
        End Get
        Set(value As String)
            CFractura = value
        End Set
    End Property

    Public Property PMedicamento1 As Integer
        Get
            Return PMedicamento
        End Get
        Set(value As Integer)
            PMedicamento = value
        End Set
    End Property

    Public Property CMeicamento1 As String
        Get
            Return CMeicamento
        End Get
        Set(value As String)
            CMeicamento = value
        End Set
    End Property

    Public Property PTratamiento1 As Integer
        Get
            Return PTratamiento
        End Get
        Set(value As Integer)
            PTratamiento = value
        End Set
    End Property

    Public Property CTratamiento1 As String
        Get
            Return CTratamiento
        End Get
        Set(value As String)
            CTratamiento = value
        End Set
    End Property

    Public Property Observaciones1 As String
        Get
            Return Observaciones
        End Get
        Set(value As String)
            Observaciones = value
        End Set
    End Property

    Public Property PPSeca1 As Integer
        Get
            Return PPSeca
        End Get
        Set(value As Integer)
            PPSeca = value
        End Set
    End Property



    Public Property PPLeveSeca1 As Integer
        Get
            Return PPLeveSeca
        End Get
        Set(value As Integer)
            PPLeveSeca = value
        End Set
    End Property



    Public Property PPMedSeca1 As Integer
        Get
            Return PPMedSeca
        End Get
        Set(value As Integer)
            PPMedSeca = value
        End Set
    End Property



    Public Property PPMuySeca1 As Integer
        Get
            Return PPMuySeca
        End Get
        Set(value As Integer)
            PPMuySeca = value
        End Set
    End Property


    Public Property PPGrasa1 As Integer
        Get
            Return PPGrasa
        End Get
        Set(value As Integer)
            PPGrasa = value
        End Set
    End Property


    Public Property PPLeveGrasa1 As Integer
        Get
            Return PPLeveGrasa
        End Get
        Set(value As Integer)
            PPLeveGrasa = value
        End Set
    End Property


    Public Property PPMedGrasa1 As Integer
        Get
            Return PPMedGrasa
        End Get
        Set(value As Integer)
            PPMedGrasa = value
        End Set
    End Property



    Public Property PPMuyGrasa1 As Integer
        Get
            Return PPMuyGrasa
        End Get
        Set(value As Integer)
            PPMuyGrasa = value
        End Set
    End Property



    Public Property ObservacionCutis1 As String
        Get
            Return ObservacionCutis
        End Get
        Set(value As String)
            ObservacionCutis = value
        End Set
    End Property

    Public Property Desvitalizada1 As Integer
        Get
            Return Desvitalizada
        End Get
        Set(value As Integer)
            Desvitalizada = value
        End Set
    End Property

    Public Property Asfictica1 As Integer
        Get
            Return Asfictica
        End Get
        Set(value As Integer)
            Asfictica = value
        End Set
    End Property

    Public Property Hidratada1 As Integer
        Get
            Return Hidratada
        End Get
        Set(value As Integer)
            Hidratada = value
        End Set
    End Property

    Public Property Standar1 As Integer
        Get
            Return Standar
        End Get
        Set(value As Integer)
            Standar = value
        End Set
    End Property
End Class