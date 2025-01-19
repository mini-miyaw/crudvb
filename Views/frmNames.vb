Public Class frmNames
    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
    End Sub
    Private Sub frmNames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using app As New AppRepository
            Call app.Load(dgvNames)
        End Using
    End Sub
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim frm As New frmEntry
        frm.ShowDialog()
        Using app As New AppRepository
            Call app.Load(dgvNames)
        End Using
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvNames.SelectedRows.Count <= 0 Then
            MessageBox.Show("No record is selected for update.", "No record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim id As Integer = Convert.ToInt32(dgvNames.SelectedRows(0).Cells("Column1").Value)
        Dim frm As New frmEntry(id)
        frm.ShowDialog()
        Using app As New AppRepository
            Call app.Load(dgvNames)
        End Using
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvNames.SelectedRows.Count <= 0 Then
            MessageBox.Show("No record is selected to delete.", "No record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim id As Integer = Convert.ToInt32(dgvNames.SelectedRows(0).Cells("Column1").Value)
        If MessageBox.Show("Are you sure you want to delete this name? This cannot be reverted.", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Using app As New AppRepository
                Call app.Delete(id)
                Call app.Load(dgvNames)
            End Using
        End If
    End Sub
    Private Sub frmNames_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnCreate.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            btnUpdate.PerformClick()
        ElseIf e.KeyCode = Keys.Delete Then
            btnDelete.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
