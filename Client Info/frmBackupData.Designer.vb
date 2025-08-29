<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackupData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackupData))
        Me.lblPath = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.FBDPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnRepair = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(12, 9)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(162, 13)
        Me.lblPath.TabIndex = 9
        Me.lblPath.Text = "Please select the database path."
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(85, 57)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(166, 57)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(75, 23)
        Me.btnBackup.TabIndex = 2
        Me.btnBackup.Text = "Backup"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(290, 28)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(32, 23)
        Me.btnPath.TabIndex = 1
        Me.btnPath.Text = "..."
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(12, 30)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(272, 20)
        Me.txtPath.TabIndex = 0
        '
        'btnRepair
        '
        Me.btnRepair.Location = New System.Drawing.Point(247, 57)
        Me.btnRepair.Name = "btnRepair"
        Me.btnRepair.Size = New System.Drawing.Size(75, 23)
        Me.btnRepair.TabIndex = 3
        Me.btnRepair.Text = "Repair"
        Me.btnRepair.UseVisualStyleBackColor = True
        '
        'frmBackupData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 99)
        Me.Controls.Add(Me.btnRepair)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBackup)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.txtPath)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackupData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup and Repair Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPath As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnBackup As Button
    Friend WithEvents btnPath As Button
    Friend WithEvents txtPath As TextBox
    Friend WithEvents FBDPath As FolderBrowserDialog
    Friend WithEvents btnRepair As Button
End Class
