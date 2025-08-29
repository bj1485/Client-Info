Imports System.IO

Public Class frmExportDatabase
    Private Sub frmExportDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main
        txtPath.Text = strBackupPath
        Me.AcceptButton = btnOkay
        txtPasswd.Select()

    End Sub

    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        If (FBDPath.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = FBDPath.SelectedPath
        End If
    End Sub

    Private Sub btnOkay_Click(sender As Object, e As EventArgs) Handles btnOkay.Click

        If String.IsNullOrWhiteSpace(txtPasswd.Text) Then
            MessageBox.Show("Please enter database password.", "Password Blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End If

        Dim strTemp As String
        'Dim blnBackup As Boolean
        strTemp = txtPath.Text

        If System.IO.Directory.Exists(strTemp) Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "BackupPath", strTemp)
            strBackupPath = strTemp

            Dim filePath As String = Path.Combine(strDatabasePath, "Key.dat")
            Dim lines() As String = File.ReadAllLines(filePath)

            Dim success1 As Boolean = False
            Dim success2 As Boolean = False
            Dim decrypted1 As String = DecryptText(lines(0), txtPasswd.Text, success1)
            Dim decrypted2 As String = DecryptText(lines(1), txtPasswd.Text, success2)

            If Not success1 OrElse Not success2 Then
                MessageBox.Show("The password is invalid.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else

                Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                ExportEncryptedData(strAccountsCSV, 14, timestamp)
                ExportEncryptedData(strInfoCsv, 16, timestamp)
                ExportEncryptedData(strTemplatePath, 16, timestamp)
                ExportEncryptedData(strNotificationsPath, 18, timestamp)
                CreateZipCSV(strBackupPath & "\" & strDatabaseName & "_" & timestamp, strBackupPath & "\" & strDatabaseName & "_" & timestamp & "-CSV.zip")

                Me.Close()
            End If

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class