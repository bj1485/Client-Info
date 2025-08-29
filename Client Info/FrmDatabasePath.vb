Imports System.IO

Public Class FrmDatabasePath

    Private Sub FrmNewDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main
        txtPath.Text = strPath

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim strTemp As String = txtPath.Text

        If System.IO.Directory.Exists(strTemp) Then
            Dim foundDbDir As Boolean = False

            Try
                Dim strDir As New DirectoryInfo(strTemp)

                For Each dir As DirectoryInfo In strDir.GetDirectories()
                    If dir.Name.ToUpper().Contains(".DB") Then
                        foundDbDir = True
                        Exit For
                    End If
                Next

                Main.btnOpenDatabase.Enabled = foundDbDir
                Main.mnuOpenDatabase.Enabled = foundDbDir

            Catch ex As Exception
                ' MessageBox.Show("Error accessing directory: " & ex.Message)
                Exit Sub
            End Try

            ' Save the path if needed
            My.Computer.Registry.CurrentUser.CreateSubKey("SOFTWARE\Client Information")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Path", strTemp)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database Path", "")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database", "")

            blnLoadData = False
            ' Update menu items
            Main.mnuNewDatabase.Enabled = True
            Main.mnuCompany.Enabled = False
            Main.mnuNewClient.Enabled = False
            Main.mnuCaptureInformation.Enabled = False
            Main.EditSearchToolStripMenuItem.Enabled = False
            Main.NewTemplateToolStripMenuItem.Enabled = False
            Main.ImportCSVToolStripMenuItem.Enabled = False
            Main.EditTemplateToolStripMenuItem.Enabled = False
            Main.BackupToolStripMenuItem.Enabled = False
            Main.mnuNotification.Enabled = False
            Main.mnuSearchNoti.Enabled = False
            Main.mnuLock.Enabled = False
            Main.mnuExport.Enabled = False

            Main.btnBackupDatabase.Enabled = False
            Main.btnNewClient.Enabled = False
            Main.btnInformation.Enabled = False
            Main.btnSearch.Enabled = False
            Main.btnNotifications.Enabled = False
            Main.btnLock.Enabled = False

            strPath = strTemp
            Me.Close()
        Else
            MessageBox.Show("The path is invalid.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        If (FBDPath.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = FBDPath.SelectedPath
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class