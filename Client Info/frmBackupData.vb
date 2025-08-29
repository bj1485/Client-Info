Public Class frmBackupData
    Private Sub frmBackupData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main
        txtPath.Text = strBackupPath

    End Sub

    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        If (FBDPath.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = FBDPath.SelectedPath
        End If

    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Dim strTemp As String
        'Dim blnBackup As Boolean
        strTemp = txtPath.Text

        If System.IO.Directory.Exists(strTemp) Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "BackupPath", strTemp)
            strBackupPath = strTemp

            Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            CreateZipInBackground(strDatabasePath, strBackupPath & "\" & strDatabaseName & "_" & timestamp & ".zip")


        Else
            MessageBox.Show("The path is invalid.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.Close()

    End Sub

    Private Sub btnRepair_Click(sender As Object, e As EventArgs) Handles btnRepair.Click

        If blnBackupDone = False Then
            MessageBox.Show("Run backup first before trying to repair the database", "Backup Data First", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            CheckCsvIntegrity(strDatabasePath & "\" & strAccountsCSV, 14)
            CheckCsvIntegrity(strDatabasePath & "\" & strInfoCsv, 16)
            CheckCsvIntegrity(strDatabasePath & "\" & strTemplatePath, 16)
            CheckCsvIntegrity(strDatabasePath & "\" & strNotificationsPath, 18)

            RepairEncryptedCsv(strAccountsCSV, 14)
            RepairAndReplaceEncryptedCsv(strDatabasePath & "\" & strAccountsCSV, 14)
            WriteDeletedPlaceholders("accounts.csv", 14)

            RepairEncryptedCsv(strInfoCsv, 16)
            RepairAndReplaceEncryptedCsv(strDatabasePath & "\" & strInfoCsv, 16)

            RepairEncryptedCsv(strTemplatePath, 16)
            RepairAndReplaceEncryptedCsv(strDatabasePath & "\" & strTemplatePath, 16)

            RepairEncryptedCsv(strNotificationsPath, 18)
            RepairAndReplaceEncryptedCsv(strDatabasePath & "\" & strNotificationsPath, 18)
            '   RepairAndReplaceEncryptedCsv(strDatabasePath & "\" & strAccountsCSV, 14)
            '   RepairAndReplaceEncryptedCsv(strDatabasePath & "\" & strInfoCsv, 16)
            '   RepairAndReplaceEncryptedCsv(strDatabasePath & "\" & strTemplatePath, 16)


            MessageBox.Show("CSV repaired and saved successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If



    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

 

End Class