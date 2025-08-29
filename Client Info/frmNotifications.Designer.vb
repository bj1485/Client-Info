<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotifications
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotifications))
        Me.rtxtNotifications = New System.Windows.Forms.RichTextBox()
        Me.linklbl = New System.Windows.Forms.LinkLabel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.tmPerformClick = New System.Windows.Forms.Timer(Me.components)
        Me.lblUpdate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'rtxtNotifications
        '
        Me.rtxtNotifications.Enabled = False
        Me.rtxtNotifications.Location = New System.Drawing.Point(12, 20)
        Me.rtxtNotifications.Name = "rtxtNotifications"
        Me.rtxtNotifications.Size = New System.Drawing.Size(345, 112)
        Me.rtxtNotifications.TabIndex = 5
        Me.rtxtNotifications.Text = ""
        '
        'linklbl
        '
        Me.linklbl.AutoSize = True
        Me.linklbl.Location = New System.Drawing.Point(12, 4)
        Me.linklbl.Name = "linklbl"
        Me.linklbl.Size = New System.Drawing.Size(0, 13)
        Me.linklbl.TabIndex = 6
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = Global.Client_Info.My.Resources.Resources.Refresh_24
        Me.btnRefresh.Location = New System.Drawing.Point(120, 138)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 37)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.BackgroundImage = Global.Client_Info.My.Resources.Resources.Next_24
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNext.Location = New System.Drawing.Point(282, 138)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 37)
        Me.btnNext.TabIndex = 3
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Image = Global.Client_Info.My.Resources.Resources.Previous_24
        Me.btnPrevious.Location = New System.Drawing.Point(201, 138)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(75, 37)
        Me.btnPrevious.TabIndex = 1
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'tmPerformClick
        '
        Me.tmPerformClick.Interval = 1000
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.Location = New System.Drawing.Point(156, 4)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(0, 13)
        Me.lblUpdate.TabIndex = 9
        '
        'frmNotifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 187)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.linklbl)
        Me.Controls.Add(Me.rtxtNotifications)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNotifications"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Notifications"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents rtxtNotifications As RichTextBox
    Friend WithEvents linklbl As LinkLabel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents tmPerformClick As Timer
    Friend WithEvents lblUpdate As Label
End Class
