<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewClient))
        Me.lblFax = New System.Windows.Forms.Label()
        Me.txtnumFax = New System.Windows.Forms.TextBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.lblAltTelephone = New System.Windows.Forms.Label()
        Me.txtnumAltTelephone = New System.Windows.Forms.TextBox()
        Me.txtAltEmail = New System.Windows.Forms.TextBox()
        Me.lblPostalCode = New System.Windows.Forms.Label()
        Me.txtnumPostal = New System.Windows.Forms.TextBox()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.bgSearchAccounts = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmSelectClient = New System.Windows.Forms.Timer(Me.components)
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblTelephone_No = New System.Windows.Forms.Label()
        Me.txtnumTelephone_No = New System.Windows.Forms.TextBox()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.lblAccount_No = New System.Windows.Forms.Label()
        Me.txtAccount_No = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lvAttachments = New System.Windows.Forms.ListView()
        Me.imgExtract = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAttach = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.OFDAttach = New System.Windows.Forms.OpenFileDialog()
        Me.tmCheckAccount = New System.Windows.Forms.Timer(Me.components)
        Me.tmRefreshAttachments = New System.Windows.Forms.Timer(Me.components)
        Me.btnEmail = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnOpenPath = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Location = New System.Drawing.Point(556, 35)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(55, 13)
        Me.lblFax.TabIndex = 131
        Me.lblFax.Text = "CELL NO:"
        '
        'txtnumFax
        '
        Me.txtnumFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumFax.Location = New System.Drawing.Point(617, 32)
        Me.txtnumFax.MaxLength = 40
        Me.txtnumFax.Name = "txtnumFax"
        Me.txtnumFax.Size = New System.Drawing.Size(140, 20)
        Me.txtnumFax.TabIndex = 3
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Location = New System.Drawing.Point(12, 61)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(109, 13)
        Me.lblContact.TabIndex = 130
        Me.lblContact.Text = "CONTACT PERSON:"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson.Location = New System.Drawing.Point(138, 58)
        Me.txtContactPerson.MaxLength = 40
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(619, 20)
        Me.txtContactPerson.TabIndex = 4
        '
        'lblAltTelephone
        '
        Me.lblAltTelephone.AutoSize = True
        Me.lblAltTelephone.Location = New System.Drawing.Point(284, 35)
        Me.lblAltTelephone.Name = "lblAltTelephone"
        Me.lblAltTelephone.Size = New System.Drawing.Size(120, 13)
        Me.lblAltTelephone.TabIndex = 129
        Me.lblAltTelephone.Text = "ALT TELEPHONE NO.:"
        '
        'txtnumAltTelephone
        '
        Me.txtnumAltTelephone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumAltTelephone.Location = New System.Drawing.Point(410, 32)
        Me.txtnumAltTelephone.MaxLength = 40
        Me.txtnumAltTelephone.Name = "txtnumAltTelephone"
        Me.txtnumAltTelephone.Size = New System.Drawing.Size(140, 20)
        Me.txtnumAltTelephone.TabIndex = 2
        '
        'txtAltEmail
        '
        Me.txtAltEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAltEmail.Location = New System.Drawing.Point(138, 110)
        Me.txtAltEmail.MaxLength = 40
        Me.txtAltEmail.Name = "txtAltEmail"
        Me.txtAltEmail.Size = New System.Drawing.Size(619, 20)
        Me.txtAltEmail.TabIndex = 6
        '
        'lblPostalCode
        '
        Me.lblPostalCode.AutoSize = True
        Me.lblPostalCode.Location = New System.Drawing.Point(12, 217)
        Me.lblPostalCode.Name = "lblPostalCode"
        Me.lblPostalCode.Size = New System.Drawing.Size(85, 13)
        Me.lblPostalCode.TabIndex = 127
        Me.lblPostalCode.Text = "POSTAL CODE:"
        '
        'txtnumPostal
        '
        Me.txtnumPostal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumPostal.Location = New System.Drawing.Point(138, 214)
        Me.txtnumPostal.MaxLength = 6
        Me.txtnumPostal.Name = "txtnumPostal"
        Me.txtnumPostal.Size = New System.Drawing.Size(140, 20)
        Me.txtnumPostal.TabIndex = 10
        '
        'txtAddress3
        '
        Me.txtAddress3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress3.Location = New System.Drawing.Point(138, 188)
        Me.txtAddress3.MaxLength = 40
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(619, 20)
        Me.txtAddress3.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "ALT EMAIL ADDRESS:"
        '
        'tmSelectClient
        '
        Me.tmSelectClient.Interval = 20
        '
        'txtAddress2
        '
        Me.txtAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress2.Location = New System.Drawing.Point(138, 162)
        Me.txtAddress2.MaxLength = 40
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(619, 20)
        Me.txtAddress2.TabIndex = 8
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(12, 139)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(117, 13)
        Me.lblAddress.TabIndex = 126
        Me.lblAddress.Text = "PHYSICAL ADDRESS:"
        '
        'txtAddress1
        '
        Me.txtAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress1.Location = New System.Drawing.Point(138, 136)
        Me.txtAddress1.MaxLength = 40
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(619, 20)
        Me.txtAddress1.TabIndex = 7
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(12, 87)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(97, 13)
        Me.lblEmail.TabIndex = 125
        Me.lblEmail.Text = "EMAIL ADDRESS:"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(138, 84)
        Me.txtEmail.MaxLength = 40
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(619, 20)
        Me.txtEmail.TabIndex = 5
        '
        'lblTelephone_No
        '
        Me.lblTelephone_No.AutoSize = True
        Me.lblTelephone_No.Location = New System.Drawing.Point(12, 35)
        Me.lblTelephone_No.Name = "lblTelephone_No"
        Me.lblTelephone_No.Size = New System.Drawing.Size(97, 13)
        Me.lblTelephone_No.TabIndex = 124
        Me.lblTelephone_No.Text = "TELEPHONE NO.:"
        '
        'txtnumTelephone_No
        '
        Me.txtnumTelephone_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumTelephone_No.Location = New System.Drawing.Point(138, 32)
        Me.txtnumTelephone_No.MaxLength = 40
        Me.txtnumTelephone_No.Name = "txtnumTelephone_No"
        Me.txtnumTelephone_No.Size = New System.Drawing.Size(140, 20)
        Me.txtnumTelephone_No.TabIndex = 1
        '
        'lblClientName
        '
        Me.lblClientName.AutoSize = True
        Me.lblClientName.Location = New System.Drawing.Point(299, 9)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(82, 13)
        Me.lblClientName.TabIndex = 123
        Me.lblClientName.Text = "CLIENT NAME:"
        '
        'txtClientName
        '
        Me.txtClientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientName.Location = New System.Drawing.Point(410, 6)
        Me.txtClientName.MaxLength = 30
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(347, 20)
        Me.txtClientName.TabIndex = 0
        '
        'lblAccount_No
        '
        Me.lblAccount_No.AutoSize = True
        Me.lblAccount_No.Location = New System.Drawing.Point(12, 9)
        Me.lblAccount_No.Name = "lblAccount_No"
        Me.lblAccount_No.Size = New System.Drawing.Size(84, 13)
        Me.lblAccount_No.TabIndex = 122
        Me.lblAccount_No.Text = "ACCOUNT NO.:"
        '
        'txtAccount_No
        '
        Me.txtAccount_No.AcceptsReturn = True
        Me.txtAccount_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccount_No.Location = New System.Drawing.Point(138, 6)
        Me.txtAccount_No.MaxLength = 6
        Me.txtAccount_No.Name = "txtAccount_No"
        Me.txtAccount_No.ReadOnly = True
        Me.txtAccount_No.ShortcutsEnabled = False
        Me.txtAccount_No.Size = New System.Drawing.Size(140, 20)
        Me.txtAccount_No.TabIndex = 107
        Me.txtAccount_No.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(601, 438)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 35)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(682, 438)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 35)
        Me.btnUpdate.TabIndex = 12
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(138, 241)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(619, 79)
        Me.txtNotes.TabIndex = 11
        '
        'lvAttachments
        '
        Me.lvAttachments.HideSelection = False
        Me.lvAttachments.LargeImageList = Me.imgExtract
        Me.lvAttachments.Location = New System.Drawing.Point(219, 326)
        Me.lvAttachments.MultiSelect = False
        Me.lvAttachments.Name = "lvAttachments"
        Me.lvAttachments.Size = New System.Drawing.Size(538, 106)
        Me.lvAttachments.SmallImageList = Me.imgExtract
        Me.lvAttachments.TabIndex = 18
        Me.lvAttachments.TileSize = New System.Drawing.Size(16, 16)
        Me.lvAttachments.UseCompatibleStateImageBehavior = False
        '
        'imgExtract
        '
        Me.imgExtract.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imgExtract.ImageSize = New System.Drawing.Size(32, 32)
        Me.imgExtract.TransparentColor = System.Drawing.Color.White
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 326)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "ATTACHMENT:"
        '
        'btnAttach
        '
        Me.btnAttach.Location = New System.Drawing.Point(138, 326)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(75, 23)
        Me.btnAttach.TabIndex = 16
        Me.btnAttach.Text = "Attach"
        Me.btnAttach.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelete.Location = New System.Drawing.Point(138, 355)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'tmCheckAccount
        '
        Me.tmCheckAccount.Interval = 500
        '
        'tmRefreshAttachments
        '
        Me.tmRefreshAttachments.Interval = 500
        '
        'btnEmail
        '
        Me.btnEmail.Image = Global.Client_Info.My.Resources.Resources.Email
        Me.btnEmail.Location = New System.Drawing.Point(523, 438)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(75, 35)
        Me.btnEmail.TabIndex = 13
        Me.btnEmail.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.Client_Info.My.Resources.Resources.Print_24
        Me.btnPrint.Location = New System.Drawing.Point(442, 438)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 35)
        Me.btnPrint.TabIndex = 14
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnOpenPath
        '
        Me.btnOpenPath.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOpenPath.Image = CType(resources.GetObject("btnOpenPath.Image"), System.Drawing.Image)
        Me.btnOpenPath.Location = New System.Drawing.Point(138, 384)
        Me.btnOpenPath.Name = "btnOpenPath"
        Me.btnOpenPath.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenPath.TabIndex = 17
        Me.btnOpenPath.UseVisualStyleBackColor = True
        '
        'FrmNewClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 485)
        Me.Controls.Add(Me.btnEmail)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnOpenPath)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAttach)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvAttachments)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblFax)
        Me.Controls.Add(Me.txtnumFax)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.txtContactPerson)
        Me.Controls.Add(Me.lblAltTelephone)
        Me.Controls.Add(Me.txtnumAltTelephone)
        Me.Controls.Add(Me.txtAltEmail)
        Me.Controls.Add(Me.lblPostalCode)
        Me.Controls.Add(Me.txtnumPostal)
        Me.Controls.Add(Me.txtAddress3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.txtAddress1)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblTelephone_No)
        Me.Controls.Add(Me.txtnumTelephone_No)
        Me.Controls.Add(Me.lblClientName)
        Me.Controls.Add(Me.txtClientName)
        Me.Controls.Add(Me.lblAccount_No)
        Me.Controls.Add(Me.txtAccount_No)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmNewClient"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFax As Label
    Friend WithEvents txtnumFax As TextBox
    Friend WithEvents lblContact As Label
    Friend WithEvents txtContactPerson As TextBox
    Friend WithEvents lblAltTelephone As Label
    Friend WithEvents txtnumAltTelephone As TextBox
    Friend WithEvents txtAltEmail As TextBox
    Friend WithEvents lblPostalCode As Label
    Friend WithEvents txtnumPostal As TextBox
    Friend WithEvents txtAddress3 As TextBox
    Friend WithEvents bgSearchAccounts As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents tmSelectClient As Timer
    Friend WithEvents txtAddress2 As TextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtAddress1 As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblTelephone_No As Label
    Friend WithEvents txtnumTelephone_No As TextBox
    Friend WithEvents lblClientName As Label
    Friend WithEvents txtClientName As TextBox
    Friend WithEvents lblAccount_No As Label
    Friend WithEvents txtAccount_No As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lvAttachments As ListView
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAttach As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents OFDAttach As OpenFileDialog
    Friend WithEvents imgExtract As ImageList
    Friend WithEvents tmCheckAccount As Timer
    Friend WithEvents btnOpenPath As Button
    Friend WithEvents tmRefreshAttachments As Timer
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnEmail As Button
End Class
