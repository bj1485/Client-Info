Imports System
Imports System.IO
Imports System.Text
Public Class FrmOpenDatabase
    Private Sub FrmOpenDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = Main
        Me.AcceptButton = btnOpen


        Try

            Dim strDir As New DirectoryInfo(strPath)
            Dim strTemp As String
            tvDatabase.Nodes.Add(strPath).SelectedImageIndex = 0
            tvDatabase.SelectedNode = tvDatabase.Nodes(0)
            For Each dir As DirectoryInfo In strDir.GetDirectories
                strTemp = dir.Name
                Dim intValue As Integer

                intValue = InStr(strTemp, ".DB")

                If intValue > 0 Then
                    strTemp = Microsoft.VisualBasic.Left(strTemp, intValue - 1)
                    Dim tvNode As New TreeNode
                    tvNode.Text = strTemp
                    tvNode.ImageIndex = 1
                    tvNode.SelectedImageIndex = 2
                    tvDatabase.Nodes(0).Nodes.Add(tvNode)


                End If

            Next

            tvDatabase.ExpandAll()

            Dim intCounter As Integer
            For Each node As TreeNode In tvDatabase.Nodes(0).Nodes

                If node.Text = strDatabaseName Then
                    tvDatabase.SelectedNode = tvDatabase.Nodes(0).Nodes(intCounter)
                    Exit Sub

                End If

                intCounter = intCounter + 1

            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            If Not tvDatabase.SelectedNode.Text = strPath Then

                ' Ensure password is entered
                If String.IsNullOrWhiteSpace(txtpassw.Text) Then
                    MessageBox.Show("Please enter your password.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                blnLoadData = False

                Main.mnuOpenDatabase.Enabled = True
                Main.mnuNewDatabase.Enabled = True
                Main.mnuCompany.Enabled = False
                Main.mnuNewClient.Enabled = False
                Main.mnuCaptureInformation.Enabled = False
                Main.EditSearchToolStripMenuItem.Enabled = False
                Main.NewTemplateToolStripMenuItem.Enabled = False
                Main.ImportCSVToolStripMenuItem.Enabled = False
                Main.EditTemplateToolStripMenuItem.Enabled = False
                Main.BackupToolStripMenuItem.Enabled = False
                Main.mnuChangePassword.Enabled = False
                Main.mnuNotification.Enabled = False
                Main.mnuSearchNoti.Enabled = False
                Main.mnuLock.Enabled = False
                Main.mnuExport.Enabled = False

                Main.btnOpenDatabase.Enabled = True
                Main.btnBackupDatabase.Enabled = False
                Main.btnNewClient.Enabled = False
                Main.btnInformation.Enabled = False
                Main.btnSearch.Enabled = False
                Main.btnNotifications.Enabled = False
                Main.btnLock.Enabled = False

                ' Set paths and registry entries
                strDatabaseName = tvDatabase.SelectedNode.Text
                strDatabasePath = Path.Combine(strPath, strDatabaseName & ".DB")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database", strDatabaseName)
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database Path", strDatabasePath)

                strBackupPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "BackupPath", Nothing)
                blnSearchAccOnly = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchAccOnly", Nothing)
                blnSearchFilter = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchFilter", Nothing)

                ' Attempt to decrypt keys from file
                Dim filePath As String = Path.Combine(strDatabasePath, "Key.dat")
                If Not File.Exists(filePath) Then
                    MessageBox.Show("The key file is missing, please restore the database from backup.", "Cannot Decrypt Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim lines() As String = File.ReadAllLines(filePath)
                If lines.Length < 2 Then
                    MessageBox.Show("Key file is incomplete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim success1 As Boolean = False
                Dim success2 As Boolean = False
                Dim decrypted1 As String = DecryptText(lines(0), txtpassw.Text, success1)
                Dim decrypted2 As String = DecryptText(lines(1), txtpassw.Text, success2)

                If Not success1 OrElse Not success2 Then
                    MessageBox.Show("The password is invalid.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                blnLoadData = True
                ' Assign encryption keys
                strEncryptKey = decrypted1
                strEncryptIVKey = decrypted2
                key = Encoding.UTF8.GetBytes(strEncryptKey)
                iv = Encoding.UTF8.GetBytes(strEncryptIVKey)

                ' Enable application features
                If Not String.IsNullOrEmpty(strPath) AndAlso Not String.IsNullOrEmpty(strEncryptKey) AndAlso Not String.IsNullOrEmpty(strEncryptIVKey) Then
                    With Main
                        .mnuOpenDatabase.Enabled = True
                        .mnuNewDatabase.Enabled = True
                        .mnuCompany.Enabled = True
                        .mnuNewClient.Enabled = True
                        .mnuCaptureInformation.Enabled = True
                        .EditSearchToolStripMenuItem.Enabled = True
                        .NewTemplateToolStripMenuItem.Enabled = True
                        .ImportCSVToolStripMenuItem.Enabled = True
                        .EditTemplateToolStripMenuItem.Enabled = True
                        .BackupToolStripMenuItem.Enabled = True
                        .mnuChangePassword.Enabled = True
                        .mnuNotification.Enabled = True
                        .mnuSearchNoti.Enabled = True
                        .mnuLock.Enabled = True
                        .mnuExport.Enabled = True

                        .btnOpenDatabase.Enabled = True
                        .btnBackupDatabase.Enabled = True
                        .btnNewClient.Enabled = True
                        .btnInformation.Enabled = True
                        .btnSearch.Enabled = True
                        .btnNotifications.Enabled = True
                        .btnLock.Enabled = True

                    End With
                End If

                InMemoryData.Clear()

                'For Each fileName In {"Notifications.csv", "Accounts.csv", "Information.csv"}
                '    LoadCsvToMemory(fileName)
                '    WatchCsvFile(fileName)
                'Next

                For Each fileName In {"Notifications.csv", "Accounts.csv", "Information.csv"}
                    Select Case fileName.ToLower()
                        Case "notifications.csv"
                            LoadCsvToMemory(fileName, blnNotiChange)
                        Case "accounts.csv"
                            LoadCsvToMemory(fileName, blnClientChange)
                        Case "information.csv"
                            LoadCsvToMemory(fileName, blnInfoChange)
                    End Select

                    WatchCsvFile(fileName)
                Next


                blnClientChange = False
                blnInfoChange = False
                blnNotiChange = False

                CountNotifications()

                Me.Close()


                Else
                    MessageBox.Show("Please select a database.", "No Database Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

   

End Class