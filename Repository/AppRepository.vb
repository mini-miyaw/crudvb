Public Class AppRepository
    Implements IDisposable
    Public Function Load(dgv As DataGridView) As DataTable
        Using db As New DBConnection
            dgv.DataSource = db.Load("SELECT * FROM vwinformation;")
        End Using
    End Function
    Public Function Save(name As Name) As Boolean
        Using db As New DBConnection
            Dim param As New Dictionary(Of String, String) From {{"@Id", name.Id.ToString()}, {"@LastName", name.LastName}, {"@FirstName", name.FirstName}, {"@MiddleName", name.MiddleName}}

            If name.Id = 0 Then
                Return db.Save("INSERT INTO information(last_name,middle_name,first_name)VALUES(@LastName,@MiddleName,@FirstName);", param)
            Else
                Return db.Save("UPDATE information SET last_name=@LastName, middle_name=@MiddleName, first_name=@FirstName WHERE id = @Id;", param)
            End If
            Console.WriteLine($"ID: {name.Id}")
        End Using
    End Function
    Public Function GetField(name As Name) As Name
        Dim dt As DataTable

        Using db As New DBConnection
            Dim param As New Dictionary(Of String, String) From {{"@Id", name.Id.ToString()}}
            dt = db.Load("SELECT * FROM information WHERE id = @Id;", param)

            If dt.Rows.Count > 0 Then
                Dim names As New Name With {.LastName = dt.Rows(0)(1).ToString(), .MiddleName = dt.Rows(0)(2).ToString(), .FirstName = dt.Rows(0)(3).ToString()}
                Return names
            End If
        End Using
        Return Nothing
    End Function
    Public Function Delete(id As Integer) As Name
        Dim name As New Name
        Using db As New DBConnection
            Dim param As New Dictionary(Of String, String) From {{"@Id", id}}

            Call db.Save("DELETE FROM information WHERE id = @Id;", param)
        End Using
    End Function
    Public Sub Capitalization(txt As TextBox)
        Dim text As String = txt.Text
        Dim textCase As String = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txt.Text)
        txt.Text = textCase
        txt.SelectionStart = txt.Text.Length
    End Sub

    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
