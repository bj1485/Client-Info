Imports System.IO

Public Class Main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        strPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Path", Nothing)
        strDatabasePath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database Path", Nothing)
        strDatabaseName = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database", Nothing)
        strBackupPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "BackupPath", Nothing)
        blnSearchAccOnly = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchAccOnly", Nothing)
        blnSearchFilter = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchFilter", Nothing)

        'strEncryptKey = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", strDatabaseName & "Key", Nothing)
        'strEncryptIVKey = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", strDatabaseName & "IV", Nothing)

        mnuNotification.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        mnuNotification.TextImageRelation = TextImageRelation.ImageAboveText

        Dim foundDbDir As Boolean = False
        If System.IO.Directory.Exists(strPath) Then
            'Dim foundDbDir As Boolean = False
            mnuNewDatabase.Enabled = True

            Try
                Dim strDir As New DirectoryInfo(strPath)

                For Each dir As DirectoryInfo In strDir.GetDirectories()
                    If dir.Name.ToUpper().Contains(".DB") Then
                        foundDbDir = True
                        Exit For
                    End If
                Next

                mnuOpenDatabase.Enabled = foundDbDir
                btnOpenDatabase.Enabled = foundDbDir

            Catch ex As Exception
                ' MessageBox.Show("Error accessing directory: " & ex.Message)
                Exit Sub
            End Try
        End If


        If (String.IsNullOrEmpty(strEncryptKey) OrElse String.IsNullOrEmpty(strEncryptIVKey)) AndAlso foundDbDir Then
            FrmOpenDatabase.Show()
        End If


        If Not String.IsNullOrWhiteSpace(strPath) AndAlso Not String.IsNullOrWhiteSpace(strEncryptIVKey) AndAlso Not String.IsNullOrWhiteSpace(strEncryptKey) Then

            ' mnuOpenDatabase.Enabled = True
            mnuNewDatabase.Enabled = True
            mnuCompany.Enabled = True
            mnuNewClient.Enabled = True
            mnuCaptureInformation.Enabled = True
            EditSearchToolStripMenuItem.Enabled = True
            NewTemplateToolStripMenuItem.Enabled = True
            ImportCSVToolStripMenuItem.Enabled = True
            EditTemplateToolStripMenuItem.Enabled = True
            BackupToolStripMenuItem.Enabled = True
            mnuNotification.Enabled = True

        End If
    End Sub
    Private Sub mnuDatabasePath_Click(sender As Object, e As EventArgs) Handles mnuDatabasePath.Click
        FrmDatabasePath.Show()

    End Sub

    Private Sub mnuNewDatabase_Click(sender As Object, e As EventArgs) Handles mnuNewDatabase.Click
        FrmAddDatabase.Show()
    End Sub

    Private Sub mnuOpenDatabase_Click(sender As Object, e As EventArgs) Handles mnuOpenDatabase.Click
        FrmOpenDatabase.Show()
    End Sub

    Private Sub mnuNewClient_Click(sender As Object, e As EventArgs) Handles mnuNewClient.Click
        If Not intClientOpen = 1 Then blnEditClient = False
        FrmNewClient.Show()
    End Sub

    Private Sub NewTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTemplateToolStripMenuItem.Click
        frmTemplate.Show()
    End Sub

    Private Sub EditSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditSearchToolStripMenuItem.Click
        FrmSearch.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub mnuCaptureInformation_Click(sender As Object, e As EventArgs) Handles mnuCaptureInformation.Click
        If Not intInfoOpen = 1 Then blnEditInfo = False
        frmCaptureInfo.Show()
    End Sub

    Private Sub ImportCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportCSVToolStripMenuItem.Click
        frmImportCSV.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub mnuFilter_Click(sender As Object, e As EventArgs)
        frmFilter.Show()
    End Sub

    Private Sub CompanyDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCompany.Click
        frmCompany.Show()
    End Sub

    Private Sub EditTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditTemplateToolStripMenuItem.Click
        FrmEditTemplate.Show()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        frmBackupData.Show()
    End Sub

    Private Sub mnuChangePassword_Click(sender As Object, e As EventArgs) Handles mnuChangePassword.Click
        frmChangePassword.Show()
    End Sub

    Private Sub btnOpenDatabase_Click(sender As Object, e As EventArgs) Handles btnOpenDatabase.Click
        FrmOpenDatabase.Show()

    End Sub

    Private Sub btnBackupDatabase_Click(sender As Object, e As EventArgs) Handles btnBackupDatabase.Click
        frmBackupData.Show()

    End Sub

    Private Sub btnNewClient_Click(sender As Object, e As EventArgs) Handles btnNewClient.Click

        If Not intClientOpen = 1 Then blnEditClient = False
        FrmNewClient.Show()

    End Sub

    Private Sub btnInformation_Click(sender As Object, e As EventArgs) Handles btnInformation.Click
        If Not intInfoOpen = 1 Then blnEditInfo = False
        frmCaptureInfo.Show()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FrmSearch.Show()
    End Sub

    Private Sub NotificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuNotification.Click
        frmNotifications.Show()
    End Sub
End Class
