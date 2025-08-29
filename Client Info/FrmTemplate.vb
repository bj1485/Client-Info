Public Class frmTemplate

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        strData(0) = txtTemplateName.Text
        strData(1) = txtField1.Text
        strData(2) = txtField2.Text
        strData(3) = txtField3.Text
        strData(4) = txtField4.Text
        strData(5) = txtField5.Text
        strData(6) = txtField6.Text
        strData(7) = txtField7.Text
        strData(8) = txtField8.Text
        strData(9) = txtField9.Text
        strData(10) = txtField10.Text
        strData(11) = txtField11.Text
        strData(12) = txtField12.Text
        strData(13) = txtField13.Text
        strData(14) = txtField14.Text
        strData(15) = chkNotes.Checked

        'Dim strInvalidcar As String

        'strInvalidcar = strData(0) & " " & strData(1) & strData(2) & " " & strData(3) & " " & strData(4) & " " & strData(5) & " " & strData(6) & " " & strData(7) & " " & strData(8) & " " & strData(9) & " " & strData(10) & " " & strData(11) & " " & strData(12) & " " & strData(13) & " " & strData(13) & " " & strData(14) & " " & strData(15)
        'Dim intstrSC As Integer
        'Dim intstrQ
        'intstrSC = InStr(strInvalidcar, ";")
        'intstrQ = InStr(strInvalidcar, """")

        'If intstrSC + intstrQ > 0 Then
        '    MessageBox.Show("You cannot use the following text "";"" or "".", "Invalid Caracter", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub

        'End If


        If strData(0) = "" Then
            MessageBox.Show("The template name field is required", "Template Name", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtField1.Text > "" AndAlso txtField2.Text > "" AndAlso txtField3.Text > "" Then
            CSVComposer(strTemplatePath, 16)
            Me.Close()
        Else
            MessageBox.Show("A minimum of three fields are required", "Minimum Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub frmTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class