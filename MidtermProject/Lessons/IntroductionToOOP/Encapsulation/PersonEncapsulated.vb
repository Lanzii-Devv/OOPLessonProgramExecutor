Public Class PersonEncapsulated

    Private _name As String
    Private _age As Integer

    Public Property Name As String

        Get
            Return _name
        End Get

        Set(value As String)
            _name = value
        End Set

    End Property

    Public Property Age As Integer

        Get
            Return _age
        End Get

        Set(value As Integer)
            If value >= 0 Then
                _age = value
            End If
        End Set

    End Property

End Class
