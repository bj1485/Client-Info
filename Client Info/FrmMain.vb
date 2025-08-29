Imports System.IO
Imports System.Reflection.Emit

Public Class Main

    Private WithEvents inactivityTimer As New Timer With {.Interval = 1000}
    Private inactivitySeconds As Integer = 0
    Private lockAfterSeconds As Integer = 900 ' 5 minutes
    Private activityFilter As InactivityMessageFilter
    Public frmNotificationsInstance As frmNotifications
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForUpdate(False)

        activityFilter = New InactivityMessageFilter()
        AddHandler activityFilter.ActivityDetected, AddressOf OnUserActivity
        Application.AddMessageFilter(activityFilter)

        tmFileWatch.Start()

        strPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Path", Nothing)
        strDatabasePath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database Path", Nothing)
        strDatabaseName = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Database", Nothing)
        strBackupPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "BackupPath", Nothing)
        blnSearchAccOnly = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchAccOnly", Nothing)
        blnSearchFilter = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchFilter", Nothing)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "Application", Application.ExecutablePath)
        'strEncryptKey = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", strDatabaseName & "Key", Nothing)
        'strEncryptIVKey = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", strDatabaseName & "IV", Nothing)



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


        'If Not String.IsNullOrWhiteSpace(strPath) AndAlso Not String.IsNullOrWhiteSpace(strEncryptIVKey) AndAlso Not String.IsNullOrWhiteSpace(strEncryptKey) Then

        '    ' mnuOpenDatabase.Enabled = True
        '    mnuNewDatabase.Enabled = True
        '    mnuCompany.Enabled = True
        '    mnuNewClient.Enabled = True
        '    mnuCaptureInformation.Enabled = True
        '    EditSearchToolStripMenuItem.Enabled = True
        '    NewTemplateToolStripMenuItem.Enabled = True
        '    ImportCSVToolStripMenuItem.Enabled = True
        '    EditTemplateToolStripMenuItem.Enabled = True
        '    BackupToolStripMenuItem.Enabled = True
        '    mnuNotification.Enabled = True
        '    mnuSearchNoti.Enabled = True
        '    mnuLock.Enabled = True

        'End If


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

        For Each f As Form In Me.MdiChildren
            If TypeOf f Is frmNotifications Then
                f.Activate()
                Return
            End If
        Next

        ' Create and show
        frmNotificationsInstance = New frmNotifications
        frmNotificationsInstance.MdiParent = Me
        frmNotificationsInstance.StartPosition = FormStartPosition.Manual

        Dim x As Integer = Me.ClientSize.Width - frmNotificationsInstance.Width - 10
        Dim y As Integer = 5

        frmNotificationsInstance.Location = New Point(x, y)
        frmNotificationsInstance.Show()

        ' Check if frmNotifications is already open
        'For Each f As Form In Me.MdiChildren
        '    If TypeOf f Is frmNotifications Then
        '        f.Activate() ' Bring it to front
        '        Return ' Do not open another one
        '    End If
        'Next

        '' Not open yet — create and show the form
        'Dim childForm As New frmNotifications
        'childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual

        'Dim x As Integer = Me.ClientSize.Width - childForm.Width - 10
        'Dim y As Integer = 5


        'childForm.Location = New Point(x, y)
        'childForm.Show()
    End Sub

    Private Sub btnNotifications_Click(sender As Object, e As EventArgs) Handles btnNotifications.Click

        For Each f As Form In Me.MdiChildren
            If TypeOf f Is frmNotifications Then
                f.Activate()
                Return
            End If
        Next

        ' Create and show
        frmNotificationsInstance = New frmNotifications
        frmNotificationsInstance.MdiParent = Me
        frmNotificationsInstance.StartPosition = FormStartPosition.Manual

        Dim x As Integer = Me.ClientSize.Width - frmNotificationsInstance.Width - 10
        Dim y As Integer = 5

        frmNotificationsInstance.Location = New Point(x, y)
        frmNotificationsInstance.Show()

        '' Check if frmNotifications is already open
        'For Each f As Form In Me.MdiChildren
        '    If TypeOf f Is frmNotifications Then
        '        f.Activate() ' Bring it to front
        '        Return ' Do not open another one
        '    End If
        'Next

        '' Not open yet — create and show the form
        'Dim childForm As New frmNotifications
        'childForm.MdiParent = Me
        'childForm.StartPosition = FormStartPosition.Manual

        'Dim x As Integer = Me.ClientSize.Width - childForm.Width - 10
        'Dim y As Integer = 5


        'childForm.Location = New Point(x, y)
        'childForm.Show()

    End Sub


    Private Sub mnuCalendar_Click_1(sender As Object, e As EventArgs) Handles mnuSearchNoti.Click
        frmReminderSchedule.Show()
    End Sub

    Private Sub mnuLock_Click(sender As Object, e As EventArgs) Handles mnuLock.Click
        frmLock.Show()
    End Sub

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        frmLock.Show()
    End Sub

    Public Sub ResetInactivityTimer()
        inactivitySeconds = 0
        If Not inactivityTimer.Enabled Then inactivityTimer.Start()
        'Debug.WriteLine("Inactivity timer reset at " & DateTime.Now.ToLongTimeString())
    End Sub

    Private Sub inactivityTimer_Tick(sender As Object, e As EventArgs) Handles inactivityTimer.Tick
        inactivitySeconds += 1

        If inactivitySeconds >= lockAfterSeconds AndAlso blnLoadData = True Then
            inactivityTimer.Stop()
            btnLock.PerformClick()
        End If

    End Sub

    Private Sub OnUserActivity()
        ResetInactivityTimer()
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        Application.RemoveMessageFilter(activityFilter)
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub ExportCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuExport.Click
        frmExportDatabase.Show()
    End Sub

    Private Sub tmFileWatch_Tick(sender As Object, e As EventArgs) Handles tmFileWatch.Tick
        Static retryCount As Integer = 0
        Const maxRetries As Integer = 10

        If FileChangedFlag Then
            If blnNotiChange OrElse blnInfoChange OrElse blnClientChange Then
                FrmSearch.Text = "Search Information - Updating"
                FrmSearch.lblUpdate.Text = "Updating"
                FrmSearch.lblUpdate.ForeColor = Color.Red
                FrmSearch.lblUpdate.Font = New Font(FrmSearch.lblUpdate.Font, FontStyle.Bold)

                frmReminderSchedule.Text = "Scheduled Notifications - Updating"
                frmReminderSchedule.lblUpdate.Text = "Updating"
                frmReminderSchedule.lblUpdate.ForeColor = Color.Red
                frmReminderSchedule.lblUpdate.Font = New Font(FrmSearch.lblUpdate.Font, FontStyle.Bold)

                If frmNotificationsInstance IsNot Nothing AndAlso Not frmNotificationsInstance.IsDisposed Then
                    frmNotificationsInstance.Text = "Notifications - Updating"
                    frmNotificationsInstance.lblUpdate.Text = "Updating"
                    frmNotificationsInstance.lblUpdate.ForeColor = Color.Red
                    frmNotificationsInstance.lblUpdate.Font = New Font(frmNotificationsInstance.lblUpdate.Font, FontStyle.Bold)
                End If

                retryCount = 0 ' reset retry since changes still pending
                Exit Sub
            End If

            If Not blnNotiChange AndAlso Not blnInfoChange AndAlso Not blnClientChange Then
                retryCount += 1

                If retryCount >= maxRetries Then
                    FrmSearch.Text = "Search Information"
                    FrmSearch.lblUpdate.Text = ""
                    FrmSearch.lblUpdate.ForeColor = Color.Red
                    FrmSearch.lblUpdate.Font = New Font(FrmSearch.lblUpdate.Font, FontStyle.Bold)

                    frmReminderSchedule.Text = "Scheduled Notifications"
                    frmReminderSchedule.lblUpdate.Text = ""
                    frmReminderSchedule.lblUpdate.ForeColor = Color.Red
                    frmReminderSchedule.lblUpdate.Font = New Font(FrmSearch.lblUpdate.Font, FontStyle.Bold)

                    If frmNotificationsInstance IsNot Nothing AndAlso Not frmNotificationsInstance.IsDisposed Then
                        frmNotificationsInstance.Text = "Notifications"
                        frmNotificationsInstance.lblUpdate.Text = ""

                    End If

                    CountNotifications()

                    FrmSearch.btnSearch.PerformClick()
                    frmReminderSchedule.btnSearch.PerformClick()

                    FileChangedFlag = False
                    retryCount = 0
                End If
            End If
        Else
            retryCount = 0 ' Reset if FileChangedFlag is off
        End If
    End Sub

    Private Sub mnuCheckForUpdates_Click(sender As Object, e As EventArgs) Handles mnuCheckForUpdates.Click
        Dim blnUpdate As Boolean

        CheckForUpdate(blnUpdate)

        If blnUpdate = False Then
            MessageBox.Show("The application is up to date.", "No Update Needed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub



    'Private Sub tmFileWatch_Tick(sender As Object, e As EventArgs) Handles tmFileWatch.Tick
    '    If FileChangedFlag = True Then

    '        If blnNotiChange = True Or blnInfoChange = True Or blnClientChange = True Then
    '            FrmSearch.Text = "Search Information - Updating"
    '            FrmSearch.lblUpdate.Text = "Updating"
    '            FrmSearch.lblUpdate.ForeColor = Color.Red
    '            FrmSearch.lblUpdate.Font = New Font(FrmSearch.lblUpdate.Font, FontStyle.Bold)
    '        End If

    '        Console.WriteLine(blnNotiChange & "****" & blnInfoChange)

    '        If Not blnNotiChange AndAlso Not blnInfoChange AndAlso Not blnClientChange Then
    '            FrmSearch.Text = "Search Information"
    '            FrmSearch.lblUpdate.Text = ""
    '            FrmSearch.lblUpdate.ForeColor = Color.Red
    '            FrmSearch.lblUpdate.Font = New Font(FrmSearch.lblUpdate.Font, FontStyle.Bold)

    '            CountNotifications()
    '            FrmSearch.btnSearch.PerformClick()
    '            frmReminderSchedule.btnSearch.PerformClick()
    '            FileChangedFlag = False

    '        End If

    '    End If

    'End Sub


End Class
