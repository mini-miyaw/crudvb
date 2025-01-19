Public Class frmEntry
    Private id As Integer
    Public Sub New(id As Integer)
        InitializeComponent()
        Me.id = id
        Using app As New AppRepository
            Dim name As New Name With {.Id = Me.id}
            If name IsNot Nothing Then
                Me.Fields(app.GetField(name))
            End If
        End Using
        Label1.Text = "Update"
        btnSave.Text = "Update"
        Console.WriteLine(id)
        Me.KeyPreview = True
        txtLastName.Focus()
    End Sub
    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
        txtLastName.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MessageBox.Show("Please fill up required fields.", "Missing field", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLastName.Focus()
            Return
        ElseIf String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Please fill up required fields.", "Missing field", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFirstName.Focus()
            Return
        Else
            Using app As New AppRepository
                Dim name As New Name With {.Id = Me.id, .LastName = txtLastName.Text, .MiddleName = txtMiddleName.Text, .FirstName = txtFirstName.Text}
                Call app.Save(name)
                Console.WriteLine($"id: {name.Id}")
            End Using
        End If

        MessageBox.Show("The entered name is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Public Sub Fields(name As Name)
        txtLastName.Text = name.LastName
        txtMiddleName.Text = name.MiddleName
        txtFirstName.Text = name.FirstName
    End Sub
    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        Using app As New AppRepository
            app.Capitalization(txtLastName)
        End Using
    End Sub
    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged
        Using app As New AppRepository
            app.Capitalization(txtFirstName)
        End Using
    End Sub
    Private Sub txtMiddleName_TextChanged(sender As Object, e As EventArgs) Handles txtMiddleName.TextChanged
        Using app As New AppRepository
            app.Capitalization(txtMiddleName)
        End Using
    End Sub
    Private Sub frmEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class