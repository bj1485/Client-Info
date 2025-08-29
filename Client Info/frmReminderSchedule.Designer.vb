<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReminderSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReminderSchedule))
        Me.dgvNotifications = New System.Windows.Forms.DataGridView()
        Me.Account_no = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Client = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTemplate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtSearch1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tmSearch = New System.Windows.Forms.Timer(Me.components)
        Me.lblUpdate = New System.Windows.Forms.Label()
        CType(Me.dgvNotifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNotifications
        '
        Me.dgvNotifications.AllowUserToAddRows = False
        Me.dgvNotifications.AllowUserToDeleteRows = False
        Me.dgvNotifications.AllowUserToResizeColumns = False
        Me.dgvNotifications.AllowUserToResizeRows = False
        Me.dgvNotifications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNotifications.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotifications.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Account_no, Me.Client, Me.clmTemplate, Me.clDate, Me.Message, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Path, Me.Edit, Me.Delete})
        Me.dgvNotifications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvNotifications.Location = New System.Drawing.Point(12, 52)
        Me.dgvNotifications.Name = "dgvNotifications"
        Me.dgvNotifications.ReadOnly = True
        Me.dgvNotifications.RowHeadersVisible = False
        Me.dgvNotifications.Size = New System.Drawing.Size(760, 297)
        Me.dgvNotifications.TabIndex = 0
        '
        'Account_no
        '
        Me.Account_no.HeaderText = "Account No:"
        Me.Account_no.Name = "Account_no"
        Me.Account_no.ReadOnly = True
        Me.Account_no.Width = 105
        '
        'Client
        '
        Me.Client.HeaderText = "Client"
        Me.Client.Name = "Client"
        Me.Client.ReadOnly = True
        Me.Client.Width = 105
        '
        'clmTemplate
        '
        Me.clmTemplate.HeaderText = "Template"
        Me.clmTemplate.Name = "clmTemplate"
        Me.clmTemplate.ReadOnly = True
        Me.clmTemplate.Width = 105
        '
        'clDate
        '
        Me.clDate.HeaderText = "Date"
        Me.clDate.Name = "clDate"
        Me.clDate.ReadOnly = True
        Me.clDate.Width = 105
        '
        'Message
        '
        Me.Message.HeaderText = "Message"
        Me.Message.Name = "Message"
        Me.Message.ReadOnly = True
        Me.Message.Width = 228
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = ""
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = ""
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = ""
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = ""
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = ""
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        '
        'Column11
        '
        Me.Column11.HeaderText = ""
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        '
        'Column12
        '
        Me.Column12.HeaderText = ""
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        '
        'Column13
        '
        Me.Column13.HeaderText = ""
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        '
        'Column14
        '
        Me.Column14.HeaderText = ""
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Visible = False
        '
        'Path
        '
        Me.Path.HeaderText = ""
        Me.Path.Name = "Path"
        Me.Path.ReadOnly = True
        Me.Path.Visible = False
        '
        'Edit
        '
        Me.Edit.HeaderText = ""
        Me.Edit.Image = Global.Client_Info.My.Resources.Resources.Edit
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Width = 50
        '
        'Delete
        '
        Me.Delete.HeaderText = ""
        Me.Delete.Image = Global.Client_Info.My.Resources.Resources.Delete
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = True
        Me.Delete.Width = 50
        '
        'txtSearch1
        '
        Me.txtSearch1.Location = New System.Drawing.Point(12, 26)
        Me.txtSearch1.Name = "txtSearch1"
        Me.txtSearch1.Size = New System.Drawing.Size(598, 20)
        Me.txtSearch1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search Notifications"
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(697, 23)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 23)
        Me.btnShow.TabIndex = 6
        Me.btnShow.Text = "Show All"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(616, 23)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tmSearch
        '
        Me.tmSearch.Interval = 400
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.Location = New System.Drawing.Point(350, 10)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(0, 13)
        Me.lblUpdate.TabIndex = 7
        '
        'frmReminderSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearch1)
        Me.Controls.Add(Me.dgvNotifications)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReminderSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scheduled Notifications"
        CType(Me.dgvNotifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvNotifications As DataGridView
    Friend WithEvents txtSearch1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnShow As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents tmSearch As Timer
    Friend WithEvents Account_no As DataGridViewLinkColumn
    Friend WithEvents Client As DataGridViewTextBoxColumn
    Friend WithEvents clmTemplate As DataGridViewTextBoxColumn
    Friend WithEvents clDate As DataGridViewTextBoxColumn
    Friend WithEvents Message As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Path As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
    Friend WithEvents lblUpdate As Label
End Class
