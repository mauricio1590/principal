Public Class HidraFacialVO
    Private NomPaciente As String
    Private Fecha As String
    Private FirmaPaciente As String
    Private FirmaAcomp As String
    Private Procedimiento As String

    Public Sub New(nomPaciente As String, fecha As String, firmaPaciente As String, firmaAcomp As String, procedimiento As String)
        Me.NomPaciente1 = nomPaciente
        Me.Fecha1 = fecha
        Me.FirmaPaciente1 = firmaPaciente
        Me.FirmaAcomp1 = firmaAcomp
        Me.Procedimiento1 = procedimiento
    End Sub

    Public Property NomPaciente1 As String
        Get
            Return NomPaciente
        End Get
        Set(value As String)
            NomPaciente = value
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

    Public Property Procedimiento1 As String
        Get
            Return Procedimiento
        End Get
        Set(value As String)
            Procedimiento = value
        End Set
    End Property
End Class
