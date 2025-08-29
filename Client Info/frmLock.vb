Imports System
Imports System.IO
Imports System.Text
Public Class frmLock

    Private previouslyVisibleForms As New List(Of Form)
    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click

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
                .mnuExport.Enabled = True

                .btnOpenDatabase.Enabled = True
                .btnBackupDatabase.Enabled = True
                .btnNewClient.Enabled = True
                .btnInformation.Enabled = True
                .btnSearch.Enabled = True
                .btnNotifications.Enabled = True



                Me.Close()

            End With

            'For Each f As Form In Application.OpenForms.Cast(Of Form).ToList()
            '    If Not f.Name.Equals("Main", StringComparison.OrdinalIgnoreCase) AndAlso Not f.Visible Then
            '        f.Show()
            '    End If
            'Next

            For Each f As Form In openFormsList.ToList()
                If Not f.IsDisposed Then
                    f.Show()
                End If
            Next

            openFormsList.Clear() ' Optional: Clear the list after restoring


        End If

    End Sub

    Private Sub frmLock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'openFormsList.Clear() ' Optional: Clear the list after restoring

        Me.MdiParent = Main
        Me.AcceptButton = btnLock

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
        Main.mnuExport.Enabled = False


        Main.btnOpenDatabase.Enabled = True
        Main.btnBackupDatabase.Enabled = False
        Main.btnNewClient.Enabled = False
        Main.btnInformation.Enabled = False
        Main.btnSearch.Enabled = False
        Main.btnNotifications.Enabled = False

        For Each f As Form In Application.OpenForms.Cast(Of Form).ToList()
            openFormsList.Add(f)
            If Not f.Name.Equals("Main", StringComparison.OrdinalIgnoreCase) AndAlso f.Visible Then
                f.Hide()
            End If
        Next




    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub



End Class