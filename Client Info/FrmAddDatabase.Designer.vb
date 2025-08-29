<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddDatabase))
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtDatabaseName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.ilDatabaseIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.tvDatabase = New System.Windows.Forms.TreeView()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword1 = New System.Windows.Forms.Label()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(248, 305)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(167, 305)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtDatabaseName
        '
        Me.txtDatabaseName.Location = New System.Drawing.Point(12, 193)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.txtDatabaseName.Size = New System.Drawing.Size(311, 20)
        Me.txtDatabaseName.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 177)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(93, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Database Name - "
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(105, 177)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(0, 13)
        Me.lblPath.TabIndex = 5
        '
        'ilDatabaseIcons
        '
        Me.ilDatabaseIcons.ImageStream = CType(resources.GetObject("ilDatabaseIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilDatabaseIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ilDatabaseIcons.Images.SetKeyName(0, "HDD.ico")
        Me.ilDatabaseIcons.Images.SetKeyName(1, "Database.ico")
        '
        'tvDatabase
        '
        Me.tvDatabase.ImageIndex = 0
        Me.tvDatabase.ImageList = Me.ilDatabaseIcons
        Me.tvDatabase.Location = New System.Drawing.Point(12, 12)
        Me.tvDatabase.Name = "tvDatabase"
        Me.tvDatabase.SelectedImageIndex = 1
        Me.tvDatabase.Size = New System.Drawing.Size(311, 162)
        Me.tvDatabase.TabIndex = 5
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(12, 236)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(308, 20)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblPassword1
        '
        Me.lblPassword1.AutoSize = True
        Me.lblPassword1.Location = New System.Drawing.Point(12, 220)
        Me.lblPassword1.Name = "lblPassword1"
        Me.lblPassword1.Size = New System.Drawing.Size(81, 13)
        Me.lblPassword1.TabIndex = 9
        Me.lblPassword1.Text = "Enter Password"
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Location = New System.Drawing.Point(12, 263)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(91, 13)
        Me.lblConfirmPassword.TabIndex = 11
        Me.lblConfirmPassword.Text = "Confirm Password"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(12, 279)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(308, 20)
        Me.txtConfirmPassword.TabIndex = 2
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'FrmAddDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 340)
        Me.Controls.Add(Me.lblConfirmPassword)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.lblPassword1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.tvDatabase)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtDatabaseName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddDatabase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtDatabaseName As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblPath As Label
    Friend WithEvents ilDatabaseIcons As ImageList
    Friend WithEvents tvDatabase As TreeView
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword1 As Label
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
End Class
