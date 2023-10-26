Public Class AutorizacionFacialVO
    Private NomPaciente As String
    Private NomAcomp As String
    Private CedAcomp As String
    Private Fecha As String
    Private NomOperador As String
    Private FirmaPaciente As String
    Private FirmaAcomp As String

    Public Sub New(nomPaciente As String, nomAcomp As String, cedAcomp As String, fecha As String, nomOperador As String, firmaPaciente As String, firmaAcomp As String)
        Me.NomPaciente = nomPaciente
        Me.NomAcomp = nomAcomp
        Me.CedAcomp = cedAcomp
        Me.Fecha = fecha
        Me.NomOperador = nomOperador
        Me.FirmaPaciente = firmaPaciente
        Me.FirmaAcomp = firmaAcomp
    End Sub

    Public Property NomPaciente1 As String
        Get
            Return NomPaciente
        End Get
        Set(value As String)
            NomPaciente = value
        End Set
    End Property

    Public Property NomAcomp1 As String
        Get
            Return NomAcomp
        End Get
        Set(value As String)
            NomAcomp = value
        End Set
    End Property

    Public Property CedAcomp1 As String
        Get
            Return CedAcomp
        End Get
        Set(value As String)
            CedAcomp = value
        End Set
    End Property

    Public Property Fecha1 As String
        Get
            Return Fecha
        End Get
        Set(value As String)
            Fecha = value
        End Set
    End Property

    Public Property NomOperador1 As String
        Get
            Return NomOperador
        End Get
        Set(value As String)
            NomOperador = value
        End Set
    End Property

    Public Property FirmaPaciente1 As String
        Get
            Return FirmaPaciente
        End Get
        Set(value As String)
            FirmaPaciente = value
        End Set
    End Property

    Public Property FirmaAcomp1 As String
        Get
            Return FirmaAcomp
        End Get
        Set(value As String)
            FirmaAcomp = value
        End Set
    End Property
End Class
