<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDatabasePath = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCompany = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNewClient = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCaptureInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNotification = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSearchNoti = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCheckForUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpenDatabase = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBackupDatabase = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNewClient = New System.Windows.Forms.ToolStripButton()
        Me.btnInformation = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNotifications = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLock = New System.Windows.Forms.ToolStripButton()
        Me.tmFileWatch = New System.Windows.Forms.Timer(Me.components)
        Me.mnuMain.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ClientToolStripMenuItem, Me.ImportToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(1008, 24)
        Me.mnuMain.TabIndex = 1
        Me.mnuMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDatabasePath, Me.mnuCompany, Me.mnuNewDatabase, Me.mnuOpenDatabase, Me.ToolStripSeparator3, Me.mnuLock, Me.ToolStripSeparator12, Me.BackupToolStripMenuItem, Me.ToolStripSeparator5, Me.mnuChangePassword, Me.ToolStripSeparator4, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mnuDatabasePath
        '
        Me.mnuDatabasePath.Name = "mnuDatabasePath"
        Me.mnuDatabasePath.Size = New System.Drawing.Size(219, 22)
        Me.mnuDatabasePath.Text = "&Database Path"
        '
        'mnuCompany
        '
        Me.mnuCompany.Enabled = False
        Me.mnuCompany.Name = "mnuCompany"
        Me.mnuCompany.Size = New System.Drawing.Size(219, 22)
        Me.mnuCompany.Text = "&Company Details"
        '
        'mnuNewDatabase
        '
        Me.mnuNewDatabase.Enabled = False
        Me.mnuNewDatabase.Name = "mnuNewDatabase"
        Me.mnuNewDatabase.Size = New System.Drawing.Size(219, 22)
        Me.mnuNewDatabase.Text = "New Database"
        '
        'mnuOpenDatabase
        '
        Me.mnuOpenDatabase.Enabled = False
        Me.mnuOpenDatabase.Name = "mnuOpenDatabase"
        Me.mnuOpenDatabase.Size = New System.Drawing.Size(219, 22)
        Me.mnuOpenDatabase.Text = "Open Database"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(216, 6)
        '
        'mnuLock
        '
        Me.mnuLock.Enabled = False
        Me.mnuLock.Name = "mnuLock"
        Me.mnuLock.Size = New System.Drawing.Size(219, 22)
        Me.mnuLock.Text = "Lock Database"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(216, 6)
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Enabled = False
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(216, 6)
        '
        'mnuChangePassword
        '
        Me.mnuChangePassword.Enabled = False
        Me.mnuChangePassword.Name = "mnuChangePassword"
        Me.mnuChangePassword.Size = New System.Drawing.Size(219, 22)
        Me.mnuChangePassword.Text = "Change Database Password"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(216, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'ClientToolStripMenuItem
        '
        Me.ClientToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.mnuNewClient, Me.mnuCaptureInformation, Me.ToolStripSeparator9, Me.EditSearchToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuNotification, Me.mnuSearchNoti, Me.ToolStripSeparator10, Me.NewTemplateToolStripMenuItem, Me.EditTemplateToolStripMenuItem})
        Me.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem"
        Me.ClientToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.ClientToolStripMenuItem.Text = "Client"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(179, 6)
        '
        'mnuNewClient
        '
        Me.mnuNewClient.Enabled = False
        Me.mnuNewClient.Name = "mnuNewClient"
        Me.mnuNewClient.Size = New System.Drawing.Size(182, 22)
        Me.mnuNewClient.Text = "New Client"
        '
        'mnuCaptureInformation
        '
        Me.mnuCaptureInformation.Enabled = False
        Me.mnuCaptureInformation.Name = "mnuCaptureInformation"
        Me.mnuCaptureInformation.Size = New System.Drawing.Size(182, 22)
        Me.mnuCaptureInformation.Text = "Capture Information"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(179, 6)
        '
        'EditSearchToolStripMenuItem
        '
        Me.EditSearchToolStripMenuItem.Enabled = False
        Me.EditSearchToolStripMenuItem.Name = "EditSearchToolStripMenuItem"
        Me.EditSearchToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.EditSearchToolStripMenuItem.Text = "Edit and Search"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(179, 6)
        '
        'mnuNotification
        '
        Me.mnuNotification.Enabled = False
        Me.mnuNotification.Name = "mnuNotification"
        Me.mnuNotification.Size = New System.Drawing.Size(182, 22)
        Me.mnuNotification.Text = "Notifications"
        '
        'mnuSearchNoti
        '
        Me.mnuSearchNoti.Enabled = False
        Me.mnuSearchNoti.Name = "mnuSearchNoti"
        Me.mnuSearchNoti.Size = New System.Drawing.Size(182, 22)
        Me.mnuSearchNoti.Text = "Search Notification"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(179, 6)
        '
        'NewTemplateToolStripMenuItem
        '
        Me.NewTemplateToolStripMenuItem.Enabled = False
        Me.NewTemplateToolStripMenuItem.Name = "NewTemplateToolStripMenuItem"
        Me.NewTemplateToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.NewTemplateToolStripMenuItem.Text = "Create Templates"
        '
        'EditTemplateToolStripMenuItem
        '
        Me.EditTemplateToolStripMenuItem.Enabled = False
        Me.EditTemplateToolStripMenuItem.Name = "EditTemplateToolStripMenuItem"
        Me.EditTemplateToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.EditTemplateToolStripMenuItem.Text = "Edit Template"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportCSVToolStripMenuItem, Me.ToolStripSeparator14, Me.mnuExport})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(114, 20)
        Me.ImportToolStripMenuItem.Text = "Import and Export"
        '
        'ImportCSVToolStripMenuItem
        '
        Me.ImportCSVToolStripMenuItem.Enabled = False
        Me.ImportCSVToolStripMenuItem.Name = "ImportCSVToolStripMenuItem"
        Me.ImportCSVToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ImportCSVToolStripMenuItem.Text = "Import CSV"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(169, 6)
        '
        'mnuExport
        '
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(172, 22)
        Me.mnuExport.Text = "Export Data to CSV"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCheckForUpdates, Me.ToolStripSeparator15, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuCheckForUpdates
        '
        Me.mnuCheckForUpdates.Name = "mnuCheckForUpdates"
        Me.mnuCheckForUpdates.Size = New System.Drawing.Size(180, 22)
        Me.mnuCheckForUpdates.Text = "Check for Updates"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(177, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenDatabase, Me.ToolStripSeparator6, Me.btnBackupDatabase, Me.ToolStripSeparator7, Me.btnNewClient, Me.btnInformation, Me.ToolStripSeparator8, Me.btnSearch, Me.ToolStripSeparator11, Me.btnNotifications, Me.ToolStripSeparator13, Me.btnLock})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 39)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpenDatabase
        '
        Me.btnOpenDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpenDatabase.Enabled = False
        Me.btnOpenDatabase.Image = CType(resources.GetObject("btnOpenDatabase.Image"), System.Drawing.Image)
        Me.btnOpenDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenDatabase.Name = "btnOpenDatabase"
        Me.btnOpenDatabase.Size = New System.Drawing.Size(36, 36)
        Me.btnOpenDatabase.Text = "ToolStripButton2"
        Me.btnOpenDatabase.ToolTipText = "Open Database"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'btnBackupDatabase
        '
        Me.btnBackupDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBackupDatabase.Enabled = False
        Me.btnBackupDatabase.Image = CType(resources.GetObject("btnBackupDatabase.Image"), System.Drawing.Image)
        Me.btnBackupDatabase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBackupDatabase.Name = "btnBackupDatabase"
        Me.btnBackupDatabase.Size = New System.Drawing.Size(36, 36)
        Me.btnBackupDatabase.Text = "ToolStripButton3"
        Me.btnBackupDatabase.ToolTipText = "Backup"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 39)
        '
        'btnNewClient
        '
        Me.btnNewClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNewClient.Enabled = False
        Me.btnNewClient.Image = CType(resources.GetObject("btnNewClient.Image"), System.Drawing.Image)
        Me.btnNewClient.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNewClient.Name = "btnNewClient"
        Me.btnNewClient.Size = New System.Drawing.Size(36, 36)
        Me.btnNewClient.Text = "ToolStripButton4"
        Me.btnNewClient.ToolTipText = "New Client"
        '
        'btnInformation
        '
        Me.btnInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInformation.Enabled = False
        Me.btnInformation.Image = CType(resources.GetObject("btnInformation.Image"), System.Drawing.Image)
        Me.btnInformation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInformation.Name = "btnInformation"
        Me.btnInformation.Size = New System.Drawing.Size(36, 36)
        Me.btnInformation.Text = "ToolStripButton5"
        Me.btnInformation.ToolTipText = "Capture Client"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 39)
        '
        'btnSearch
        '
        Me.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSearch.Enabled = False
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(36, 36)
        Me.btnSearch.Text = "ToolStripButton6"
        Me.btnSearch.ToolTipText = "Search"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 39)
        '
        'btnNotifications
        '
        Me.btnNotifications.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNotifications.Enabled = False
        Me.btnNotifications.Image = CType(resources.GetObject("btnNotifications.Image"), System.Drawing.Image)
        Me.btnNotifications.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNotifications.Name = "btnNotifications"
        Me.btnNotifications.Size = New System.Drawing.Size(36, 36)
        Me.btnNotifications.Text = "Notifications"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 39)
        '
        'btnLock
        '
        Me.btnLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLock.Enabled = False
        Me.btnLock.Image = Global.Client_Info.My.Resources.Resources.Lock
        Me.btnLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(36, 36)
        Me.btnLock.Text = "Lock Database"
        '
        'tmFileWatch
        '
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.mnuMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "Main"
        Me.Text = "Client Info"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuNewDatabase As ToolStripMenuItem
    Friend WithEvents mnuDatabasePath As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuNewClient As ToolStripMenuItem
    Friend WithEvents NewTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuOpenDatabase As ToolStripMenuItem
    Friend WithEvents EditSearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuCaptureInformation As ToolStripMenuItem
    Friend WithEvents mnuCompany As ToolStripMenuItem
    Friend WithEvents EditTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents mnuChangePassword As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnOpenDatabase As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btnBackupDatabase As ToolStripButton
    Friend WithEvents btnNewClient As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnInformation As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents mnuNotification As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents btnNotifications As ToolStripButton
    Friend WithEvents mnuSearchNoti As ToolStripMenuItem
    Friend WithEvents mnuLock As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents btnLock As ToolStripButton
    Friend WithEvents ImportCSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuExport As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents tmFileWatch As Timer
    Friend WithEvents mnuCheckForUpdates As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
End Class
