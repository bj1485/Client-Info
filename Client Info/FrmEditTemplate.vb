Public Class FrmEditTemplate
    Private Sub FrmEditTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main
        LoadCSVTemplate(strTemplatePath, cmbTemplate)
    End Sub

    Private Sub cmbTemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTemplate.SelectedIndexChanged

        CSVTemplate(strTemplatePath, cmbTemplate.Text, "EditTemplate")

        strDataT(0) = cmbTemplate.Text
        strDataT(1) = txtField1.Text
        strDataT(2) = txtField2.Text
        strDataT(3) = txtField3.Text
        strDataT(4) = txtField4.Text
        strDataT(5) = txtField5.Text
        strDataT(6) = txtField6.Text
        strDataT(7) = txtField7.Text
        strDataT(8) = txtField8.Text
        strDataT(9) = txtField9.Text
        strDataT(10) = txtField10.Text
        strDataT(11) = txtField11.Text
        strDataT(12) = txtField12.Text
        strDataT(13) = txtField13.Text
        strDataT(14) = txtField14.Text
        strDataT(15) = chkNotes.Checked

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If cmbTemplate.SelectedIndex = -1 Then
            Me.Close()
            Exit Sub

        End If

        strData(0) = strDataT(0)
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

        'MsgBox(strData(15))
        CSVUPdate(strTemplatePath, 16, "Template") ' Working

        Me.Close()


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class