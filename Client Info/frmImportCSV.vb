Public Class frmImportCSV
    Private Sub frmImportCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main
        cmbTemplate.Items.Add("Accounts")
        cmbTemplate.Items.Add("Information")
        cmbTemplate.Items.Add("Templates")
        cmbTemplate.Items.Add("Notifications")
        'LoadCSVTemplate(strTemplatePath, cmbTemplate)
    End Sub

    Private Sub cmbTemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTemplate.SelectedIndexChanged
        dgvImport.Columns.Clear()
        btnImport.Enabled = True
        btnSave.Enabled = False
        Select Case cmbTemplate.SelectedItem.ToString
            Case Is = "Accounts"

                dgvImport.Columns.Add("Account_No", "Account No")
                'dgvImport.Columns("Account_no").Visible = False
                dgvImport.Columns.Add("Client_Name", " Client Name")
                dgvImport.Columns.Add("Template", "Template")
                dgvImport.Columns.Add("Telephone_No", "Tel No")
                dgvImport.Columns.Add("AltTelephone_No", "Alt Tel No")
                dgvImport.Columns.Add("Cellphone_No", "Cell No")
                dgvImport.Columns.Add("Contact_Person", "Contact")
                dgvImport.Columns.Add("Email", "Email")
                dgvImport.Columns.Add("Alt_Email", "Alt Email")
                dgvImport.Columns.Add("Address1", "Address 1")
                dgvImport.Columns.Add("Address2", "Address 2")
                dgvImport.Columns.Add("Address3", "Address 3")
                dgvImport.Columns.Add("Post_Code", "Postal Code")
                dgvImport.Columns.Add("Notes", "Notes")

            Case Is = "Information"
                dgvImport.Columns.Add("Account_No", "Account No")
                dgvImport.Columns.Add("Client_Name", " Client Name")
                dgvImport.Columns.Add("Template", "Template")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("Notes", "Notes")

            Case Is = "Templates"

                dgvImport.Columns.Add("Template", "Template")
                dgvImport.Columns.Add("Default_1", "Default 1")
                dgvImport.Columns.Add("Default_2", "Default 2")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("Notes", "Notes")

            Case Is = "Notifications"

                dgvImport.Columns.Add("Account_No", "Account No")
                dgvImport.Columns.Add("Client_Name", " Client Name")
                dgvImport.Columns.Add("Template", "Template")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("", "")
                dgvImport.Columns.Add("Notes", "Notes")
                dgvImport.Columns.Add("clmDate", "Date")
                dgvImport.Columns.Add("Message", "Message")
                'Case Else
                ' CSVTemplateImport(strTemplatePath, cmbTemplate.Text, dgvImport)

        End Select
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim strFN
        If ofdCsv.ShowDialog = DialogResult.OK Then
            strFN = ofdCsv.FileName

            Select Case cmbTemplate.Text
                Case Is = "Accounts"
                    ImportReadCsv(strFN, 13, dgvImport)
                    btnSave.Enabled = True

                Case Is = "Notifications"
                    ImportReadCsv(strFN, 17, dgvImport)
                        btnSave.Enabled = True
                Case Else

                    ImportReadCsv(strFN, 15, dgvImport)
                    btnSave.Enabled = True

            End Select
            'If cmbTemplate.Text = "Accounts" Then

            'Else

            'End If

        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Select Case cmbTemplate.Text

            Case Is = "Accounts"
                SaveImport(dgvImport, 14, strAccountsCSV)
            Case Is = "Templates"
                SaveImport(dgvImport, 16, strTemplatePath)
            Case Is = "Information"
                SaveImport(dgvImport, 16, strInfoCsv)
            Case Is = "Notifications"
                SaveImport(dgvImport, 18, strNotificationsPath)

        End Select
        'If cmbTemplate.Text = "Accounts" Then
        '    SaveImport(dgvImport, 14, strAccountsCSV)
        'Else
        '    SaveImport(dgvImport, 16, strInfoCsv)
        'End If

        Me.Close()

    End Sub



End Class