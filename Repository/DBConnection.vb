Imports MySqlConnector
Public Class DBConnection
    Implements IDisposable
    Private connection As MySqlConnection
    Dim connectionString As String
    Public Sub New()
        Dim server As String = ""
        Dim user As String = ""
        Dim pw As String = ""
        Dim database As String = ""
        Dim port As String = ""

        Me.connectionString = String.Format("yourConnectionString;", server, user, pw, database, port)
        Me.Connect()
    End Sub
    Public Sub DB()
        Me.connection = New MySqlConnection(connectionString)
    End Sub
    Private Protected Sub Connect()
        Try
            If connection Is Nothing Then
                connection = New MySqlConnection(connectionString)
            End If

            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)
        End Try
    End Sub
    Public Function Load(query As String, param As Dictionary(Of String, String)) As DataTable
        Dim dt As New DataTable()

        Using cmd As New MySqlCommand(query, Me.connection)
            If param IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, String) In param
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                Next
            End If

            Using da As New MySqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using

        Return dt

    End Function
    Public Function Load(query As String) As DataTable
        Return Me.Load(query, Nothing)
    End Function
    Public Function Save(query As String, param As Dictionary(Of String, String)) As Boolean
        Try
            Using cmd As New MySqlCommand(query, Me.connection)
                If param IsNot Nothing Then
                    For Each kvp As KeyValuePair(Of String, String) In param
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                    Next

                    cmd.ExecuteNonQuery()
                    Return True
                End If
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)
        End Try
    End Function
    Public Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub

End Class
