Public Class CirugiaPlasticaOcularVO
    Private NomPaciente As String
    Private CCPaciente As String
    Private FirmaPaciente As String
    Private FirmaProfesional As String

    Public Sub New(nomPaciente As String, cCPaciente As String, firmaPaciente As String, firmaProfesional As String)
        Me.NomPaciente = nomPaciente
        Me.CCPaciente = cCPaciente
        Me.FirmaPaciente1 = firmaPaciente
        Me.FirmaProfesional1 = firmaProfesional
    End Sub

    Public Property NomPaciente1 As String
        Get
            Return NomPaciente
        End Get
        Set(value As String)
            NomPaciente = value
        End Set
    End Property

    Public Property CCPaciente1 As String
        Get
            Return CCPaciente
        End Get
        Set(value As String)
            CCPaciente = value
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

    Public Property FirmaProfesional1 As String
        Get
            Return FirmaProfesional
        End Get
        Set(value As String)
            FirmaProfesional = value
        End Set
    End Property
End Class
