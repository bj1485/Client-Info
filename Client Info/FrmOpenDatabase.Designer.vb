<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOpenDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOpenDatabase))
        Me.tvDatabase = New System.Windows.Forms.TreeView()
        Me.ilTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.txtpassw = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tvDatabase
        '
        Me.tvDatabase.ImageIndex = 0
        Me.tvDatabase.ImageList = Me.ilTreeView
        Me.tvDatabase.Location = New System.Drawing.Point(13, 13)
        Me.tvDatabase.Name = "tvDatabase"
        Me.tvDatabase.SelectedImageIndex = 0
        Me.tvDatabase.Size = New System.Drawing.Size(310, 198)
        Me.tvDatabase.TabIndex = 1
        '
        'ilTreeView
        '
        Me.ilTreeView.ImageStream = CType(resources.GetObject("ilTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTreeView.Images.SetKeyName(0, "Hdd.ico")
        Me.ilTreeView.Images.SetKeyName(1, "Database.ico")
        Me.ilTreeView.Images.SetKeyName(2, "CheckMark.ico")
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(167, 261)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(248, 261)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtpassw
        '
        Me.txtpassw.Location = New System.Drawing.Point(13, 234)
        Me.txtpassw.Name = "txtpassw"
        Me.txtpassw.Size = New System.Drawing.Size(310, 20)
        Me.txtpassw.TabIndex = 0
        Me.txtpassw.UseSystemPasswordChar = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(12, 218)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(127, 13)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Enter database password"
        '
        'FrmOpenDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 296)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtpassw)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.tvDatabase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOpenDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Open Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tvDatabase As TreeView
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents ilTreeView As ImageList
    Friend WithEvents txtpassw As TextBox
    Friend WithEvents lblPassword As Label
End Class
