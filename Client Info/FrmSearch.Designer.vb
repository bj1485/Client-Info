<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSearch))
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.Account_No = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Client_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Text15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtSearch1 = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tmSearch = New System.Windows.Forms.Timer(Me.components)
        Me.btnShow = New System.Windows.Forms.Button()
        Me.cmbTemplate = New System.Windows.Forms.ComboBox()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.rbSearch = New System.Windows.Forms.RadioButton()
        Me.rbFilter = New System.Windows.Forms.RadioButton()
        Me.chbSearchAcc = New System.Windows.Forms.CheckBox()
        Me.lblUpdate = New System.Windows.Forms.Label()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.AllowUserToResizeColumns = False
        Me.dgvSearch.AllowUserToResizeRows = False
        Me.dgvSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSearch.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Account_No, Me.Client_Name, Me.Text2, Me.Text3, Me.Text4, Me.Text5, Me.Text6, Me.Text7, Me.Text8, Me.Text9, Me.Text10, Me.Text11, Me.Text12, Me.Text13, Me.Text14, Me.Text15, Me.FilePath, Me.Edit, Me.Delete})
        Me.dgvSearch.Location = New System.Drawing.Point(13, 53)
        Me.dgvSearch.MultiSelect = False
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.RowHeadersVisible = False
        Me.dgvSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSearch.ShowRowErrors = False
        Me.dgvSearch.Size = New System.Drawing.Size(760, 296)
        Me.dgvSearch.TabIndex = 5
        '
        'Account_No
        '
        Me.Account_No.HeaderText = "Account No."
        Me.Account_No.Name = "Account_No"
        Me.Account_No.ReadOnly = True
        Me.Account_No.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Account_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Account_No.Width = 105
        '
        'Client_Name
        '
        Me.Client_Name.HeaderText = "Client"
        Me.Client_Name.Name = "Client_Name"
        Me.Client_Name.ReadOnly = True
        Me.Client_Name.Width = 105
        '
        'Text2
        '
        Me.Text2.HeaderText = ""
        Me.Text2.Name = "Text2"
        Me.Text2.ReadOnly = True
        Me.Text2.Width = 110
        '
        'Text3
        '
        Me.Text3.HeaderText = ""
        Me.Text3.Name = "Text3"
        Me.Text3.ReadOnly = True
        Me.Text3.Width = 110
        '
        'Text4
        '
        Me.Text4.HeaderText = ""
        Me.Text4.Name = "Text4"
        Me.Text4.ReadOnly = True
        Me.Text4.Width = 110
        '
        'Text5
        '
        Me.Text5.HeaderText = ""
        Me.Text5.Name = "Text5"
        Me.Text5.ReadOnly = True
        Me.Text5.Width = 110
        '
        'Text6
        '
        Me.Text6.HeaderText = ""
        Me.Text6.Name = "Text6"
        Me.Text6.ReadOnly = True
        Me.Text6.Visible = False
        '
        'Text7
        '
        Me.Text7.HeaderText = ""
        Me.Text7.Name = "Text7"
        Me.Text7.ReadOnly = True
        Me.Text7.Visible = False
        '
        'Text8
        '
        Me.Text8.HeaderText = ""
        Me.Text8.Name = "Text8"
        Me.Text8.ReadOnly = True
        Me.Text8.Visible = False
        '
        'Text9
        '
        Me.Text9.HeaderText = ""
        Me.Text9.Name = "Text9"
        Me.Text9.ReadOnly = True
        Me.Text9.Visible = False
        '
        'Text10
        '
        Me.Text10.HeaderText = ""
        Me.Text10.Name = "Text10"
        Me.Text10.ReadOnly = True
        Me.Text10.Visible = False
        '
        'Text11
        '
        Me.Text11.HeaderText = ""
        Me.Text11.Name = "Text11"
        Me.Text11.ReadOnly = True
        Me.Text11.Visible = False
        '
        'Text12
        '
        Me.Text12.HeaderText = ""
        Me.Text12.Name = "Text12"
        Me.Text12.ReadOnly = True
        Me.Text12.Visible = False
        '
        'Text13
        '
        Me.Text13.HeaderText = ""
        Me.Text13.Name = "Text13"
        Me.Text13.ReadOnly = True
        Me.Text13.Visible = False
        '
        'Text14
        '
        Me.Text14.HeaderText = ""
        Me.Text14.Name = "Text14"
        Me.Text14.ReadOnly = True
        Me.Text14.Visible = False
        '
        'Text15
        '
        Me.Text15.HeaderText = ""
        Me.Text15.Name = "Text15"
        Me.Text15.ReadOnly = True
        Me.Text15.Visible = False
        '
        'FilePath
        '
        Me.FilePath.HeaderText = ""
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        Me.FilePath.Visible = False
        '
        'Edit
        '
        Me.Edit.HeaderText = ""
        Me.Edit.Image = Global.Client_Info.My.Resources.Resources.Edit
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Edit.Width = 50
        '
        'Delete
        '
        Me.Delete.HeaderText = ""
        Me.Delete.Image = Global.Client_Info.My.Resources.Resources.Delete
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = True
        Me.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Delete.Width = 50
        '
        'txtSearch1
        '
        Me.txtSearch1.Location = New System.Drawing.Point(13, 25)
        Me.txtSearch1.Name = "txtSearch1"
        Me.txtSearch1.Size = New System.Drawing.Size(479, 20)
        Me.txtSearch1.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(616, 22)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Search Accounts and Client Information"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.Client_Info.My.Resources.Resources.Edit
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 50
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = Global.Client_Info.My.Resources.Resources.Delete
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 50
        '
        'DataGridViewImageColumn3
        '
        Me.DataGridViewImageColumn3.HeaderText = ""
        Me.DataGridViewImageColumn3.Image = Global.Client_Info.My.Resources.Resources.Delete
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn3.Width = 50
        '
        'tmSearch
        '
        Me.tmSearch.Interval = 400
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(697, 22)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 23)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "Show All"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'cmbTemplate
        '
        Me.cmbTemplate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTemplate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTemplate.FormattingEnabled = True
        Me.cmbTemplate.Location = New System.Drawing.Point(253, 24)
        Me.cmbTemplate.Name = "cmbTemplate"
        Me.cmbTemplate.Size = New System.Drawing.Size(239, 21)
        Me.cmbTemplate.TabIndex = 2
        '
        'cmbClient
        '
        Me.cmbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(12, 24)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(235, 21)
        Me.cmbClient.TabIndex = 1
        '
        'rbSearch
        '
        Me.rbSearch.AutoSize = True
        Me.rbSearch.Location = New System.Drawing.Point(498, 28)
        Me.rbSearch.Name = "rbSearch"
        Me.rbSearch.Size = New System.Drawing.Size(59, 17)
        Me.rbSearch.TabIndex = 7
        Me.rbSearch.TabStop = True
        Me.rbSearch.Text = "Search"
        Me.rbSearch.UseVisualStyleBackColor = True
        '
        'rbFilter
        '
        Me.rbFilter.AutoSize = True
        Me.rbFilter.Location = New System.Drawing.Point(563, 27)
        Me.rbFilter.Name = "rbFilter"
        Me.rbFilter.Size = New System.Drawing.Size(47, 17)
        Me.rbFilter.TabIndex = 8
        Me.rbFilter.TabStop = True
        Me.rbFilter.Text = "Filter"
        Me.rbFilter.UseVisualStyleBackColor = True
        '
        'chbSearchAcc
        '
        Me.chbSearchAcc.AutoSize = True
        Me.chbSearchAcc.Location = New System.Drawing.Point(498, 4)
        Me.chbSearchAcc.Name = "chbSearchAcc"
        Me.chbSearchAcc.Size = New System.Drawing.Size(135, 17)
        Me.chbSearchAcc.TabIndex = 6
        Me.chbSearchAcc.Text = "Search Accounts  Only"
        Me.chbSearchAcc.UseVisualStyleBackColor = True
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.Location = New System.Drawing.Point(253, 9)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(0, 13)
        Me.lblUpdate.TabIndex = 9
        '
        'FrmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.chbSearchAcc)
        Me.Controls.Add(Me.rbFilter)
        Me.Controls.Add(Me.rbSearch)
        Me.Controls.Add(Me.cmbTemplate)
        Me.Controls.Add(Me.cmbClient)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch1)
        Me.Controls.Add(Me.dgvSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSearch"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Information"
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSearch As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn3 As DataGridViewImageColumn
    Friend WithEvents tmSearch As Timer
    Friend WithEvents Account_No As DataGridViewLinkColumn
    Friend WithEvents Client_Name As DataGridViewTextBoxColumn
    Friend WithEvents Text2 As DataGridViewTextBoxColumn
    Friend WithEvents Text3 As DataGridViewTextBoxColumn
    Friend WithEvents Text4 As DataGridViewTextBoxColumn
    Friend WithEvents Text5 As DataGridViewTextBoxColumn
    Friend WithEvents Text6 As DataGridViewTextBoxColumn
    Friend WithEvents Text7 As DataGridViewTextBoxColumn
    Friend WithEvents Text8 As DataGridViewTextBoxColumn
    Friend WithEvents Text9 As DataGridViewTextBoxColumn
    Friend WithEvents Text10 As DataGridViewTextBoxColumn
    Friend WithEvents Text11 As DataGridViewTextBoxColumn
    Friend WithEvents Text12 As DataGridViewTextBoxColumn
    Friend WithEvents Text13 As DataGridViewTextBoxColumn
    Friend WithEvents Text14 As DataGridViewTextBoxColumn
    Friend WithEvents Text15 As DataGridViewTextBoxColumn
    Friend WithEvents FilePath As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewImageColumn
    Friend WithEvents Delete As DataGridViewImageColumn
    Friend WithEvents btnShow As Button
    Friend WithEvents cmbTemplate As ComboBox
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents rbSearch As RadioButton
    Friend WithEvents rbFilter As RadioButton
    Friend WithEvents chbSearchAcc As CheckBox
    Friend WithEvents txtSearch1 As TextBox
    Friend WithEvents lblUpdate As Label
End Class
