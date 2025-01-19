Public Class Name
    Private _id As Integer
    Private _lastname As String
    Private _firstname As String
    Private _middlename As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _lastname
        End Get
        Set(value As String)
            _lastname = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _firstname
        End Get
        Set(value As String)
            _firstname = value
        End Set
    End Property

    Public Property MiddleName As String
        Get
            Return _middlename
        End Get
        Set(value As String)
            _middlename = value
        End Set
    End Property

End Class
