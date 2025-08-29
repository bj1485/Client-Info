Imports System.ComponentModel
Public Class frmFilter

    'Private Sub frmFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Me.MdiParent = Main
    '    LoadCSVTemplate(strTemplatePath, cmbTemplate) ' Working
    '    ReadCSVCombo(strAccountsCSV, cmbClient) ' Working
    'End Sub

    'Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click

    '    If btnShow.Text = "Show All" Then
    '        btnShow.Text = "Hide"
    '        dgvSearch.Columns("Text6").Visible = True
    '        dgvSearch.Columns("Text7").Visible = True
    '        dgvSearch.Columns("Text8").Visible = True
    '        dgvSearch.Columns("Text9").Visible = True
    '        dgvSearch.Columns("Text10").Visible = True
    '        dgvSearch.Columns("Text11").Visible = True
    '        dgvSearch.Columns("Text12").Visible = True
    '        dgvSearch.Columns("Text13").Visible = True
    '        dgvSearch.Columns("Text14").Visible = True
    '        dgvSearch.Columns("Text15").Visible = True
    '    Else
    '        btnShow.Text = "Show All"
    '        dgvSearch.Columns("Text6").Visible = False
    '        dgvSearch.Columns("Text7").Visible = False
    '        dgvSearch.Columns("Text8").Visible = False
    '        dgvSearch.Columns("Text9").Visible = False
    '        dgvSearch.Columns("Text10").Visible = False
    '        dgvSearch.Columns("Text11").Visible = False
    '        dgvSearch.Columns("Text12").Visible = False
    '        dgvSearch.Columns("Text13").Visible = False
    '        dgvSearch.Columns("Text14").Visible = False
    '        dgvSearch.Columns("Text15").Visible = False

    '    End If

    'End Sub

    'Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
    '    Dim strTxtValue As String
    '    Dim strSearchValues(10) As String
    '    Dim intStrtxt As Integer
    '    Dim intCounter As Integer

    '    strTxtValue = cmbClient.Text & " " & cmbTemplate.Text
    '    intStrtxt = InStr(strTxtValue, " ")

    '    Try
    '        Do Until intCounter = 9
    '            strSearchValues(intCounter) = Microsoft.VisualBasic.Left(strTxtValue, intStrtxt)
    '            strTxtValue = Replace(strTxtValue, strSearchValues(intCounter), "")
    '            strSearchValues(intCounter) = strSearchValues(intCounter).Trim()

    '            Console.WriteLine("[" & strSearchValues(intCounter) & "]" & "  " & intCounter)

    '            intStrtxt = InStr(strTxtValue, " ")

    '            If intStrtxt = 0 AndAlso strTxtValue > "" Then

    '                If Not strSearchValues(0) = Nothing Then intCounter = intCounter + 1
    '                strSearchValues(intCounter) = strTxtValue
    '                Console.WriteLine("[" & strSearchValues(intCounter) & "]" & " " & intCounter)
    '                Exit Do
    '            End If

    '            intCounter = intCounter + 1

    '        Loop

    '    Catch ex As Exception

    '    End Try
    '    Console.WriteLine("[" & strSearchValues(0) & "]" & " Hello " & strSearchValues(1) & " Hello " & strSearchValues(2) & " Hello " & strSearchValues(3))
    '    ReadCsv(strAccountsCSV, strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 13, dgvSearch, True) ' working
    '    ReadCsv(strInfoCsv, strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 15, dgvSearch, False) 'working
    '    dgvSearch.Sort(dgvSearch.Columns(2), ListSortDirection.Ascending)
    '    'End If


    'End Sub

    'Private Sub dgvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellContentClick
    '    Dim intColumnIndex As Integer
    '    Dim intRowNumber
    '    intColumnIndex = dgvSearch.CurrentCell.ColumnIndex
    '    intRowNumber = dgvSearch.CurrentRow.Index

    '    Try
    '        If dgvSearch.CurrentCell.ColumnIndex > 0 AndAlso dgvSearch.CurrentCell.ColumnIndex < 17 Then
    '            Dim strClipboard As String = dgvSearch.CurrentCell.Value
    '            Clipboard.SetText(strClipboard)
    '        End If
    '    Catch ex As Exception

    '    End Try


    '    Select Case intColumnIndex
    '        Case Is = 0, 17
    '            Dim intStr As Integer
    '            intStr = InStr(dgvSearch.Rows(intRowNumber).Cells(16).Value, "Accounts")
    '            If intStr > 0 Then

    '                blnEdit = True
    '                FrmNewClient.Show()
    '                FrmNewClient.txtAccount_No.Text = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                FrmNewClient.txtClientName.Text = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                'FrmNewClient.txtClientName.Text = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                FrmNewClient.txtnumTelephone_No.Text = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                FrmNewClient.txtnumAltTelephone.Text = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                FrmNewClient.txtnumFax.Text = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                FrmNewClient.txtContactPerson.Text = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                FrmNewClient.txtEmail.Text = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                FrmNewClient.txtAltEmail.Text = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                FrmNewClient.txtAddress1.Text = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                FrmNewClient.txtAddress2.Text = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                FrmNewClient.txtAddress3.Text = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                FrmNewClient.txtnumPostal.Text = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                FrmNewClient.txtNotes.Text = dgvSearch.Rows(intRowNumber).Cells(13).Value

    '                ShowAttached(dgvSearch.Rows(intRowNumber).Cells(0).Value, FrmNewClient.lvAttachments, FrmNewClient.imgExtract)

    '                strDataP(0) = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                strDataP(1) = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                strDataP(2) = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                strDataP(3) = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                strDataP(4) = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                strDataP(5) = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                strDataP(6) = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                strDataP(7) = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                strDataP(8) = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                strDataP(9) = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                strDataP(10) = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                strDataP(11) = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                strDataP(12) = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                strDataP(13) = dgvSearch.Rows(intRowNumber).Cells(13).Value


    '            Else
    '                blnEdit = True
    '                frmCaptureInfo.Show()
    '                frmCaptureInfo.cmbBoxTemplate.Text = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                frmCaptureInfo.txt1.Text = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                frmCaptureInfo.cmbClient.Text = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                frmCaptureInfo.txt3.Text = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                frmCaptureInfo.txt4.Text = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                frmCaptureInfo.txt5.Text = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                frmCaptureInfo.txt6.Text = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                frmCaptureInfo.txt7.Text = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                frmCaptureInfo.txt8.Text = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                frmCaptureInfo.txt9.Text = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                frmCaptureInfo.txt10.Text = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                frmCaptureInfo.txt11.Text = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                frmCaptureInfo.txt12.Text = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                frmCaptureInfo.txt13.Text = dgvSearch.Rows(intRowNumber).Cells(13).Value
    '                frmCaptureInfo.txt14.Text = dgvSearch.Rows(intRowNumber).Cells(14).Value
    '                frmCaptureInfo.txt15.Text = dgvSearch.Rows(intRowNumber).Cells(15).Value

    '                strDataP(0) = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                strDataP(1) = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                strDataP(2) = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                strDataP(3) = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                strDataP(4) = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                strDataP(5) = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                strDataP(6) = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                strDataP(7) = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                strDataP(8) = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                strDataP(9) = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                strDataP(10) = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                strDataP(11) = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                strDataP(12) = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                strDataP(13) = dgvSearch.Rows(intRowNumber).Cells(13).Value
    '                strDataP(14) = dgvSearch.Rows(intRowNumber).Cells(14).Value
    '                strDataP(15) = dgvSearch.Rows(intRowNumber).Cells(15).Value
    '                Debug.WriteLine(strDataP(15) & "Hello")

    '                strDataP(0) = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                strDataP(0) = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                strDataP(0) = dgvSearch.Rows(intRowNumber).Cells(0).Value

    '            End If

    '        Case Is = 18
    '            Dim intStr As Integer
    '            intStr = InStr(dgvSearch.Rows(intRowNumber).Cells(16).Value, "Accounts")
    '            If intStr > 0 Then

    '                If MessageBox.Show("The account with all captured information will be deleted. Do you want to continue", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
    '                    strDataP(0) = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                    strDataP(1) = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                    strDataP(2) = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                    strDataP(3) = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                    strDataP(4) = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                    strDataP(5) = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                    strDataP(6) = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                    strDataP(7) = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                    strDataP(8) = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                    strDataP(9) = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                    strDataP(10) = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                    strDataP(11) = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                    strDataP(12) = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                    strDataP(13) = dgvSearch.Rows(intRowNumber).Cells(13).Value

    '                    strData(0) = "DELETED"
    '                    strData(1) = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                    strData(2) = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                    strData(3) = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                    strData(4) = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                    strData(5) = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                    strData(6) = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                    strData(7) = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                    strData(8) = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                    strData(9) = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                    strData(10) = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                    strData(11) = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                    strData(12) = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                    strData(13) = dgvSearch.Rows(intRowNumber).Cells(13).Value

    '                    CSVUPdate(strAccountsCSV, 14)
    '                    CSVDeleteAll(dgvSearch.Rows(intRowNumber).Cells(0).Value)
    '                    btnFilter.PerformClick()
    '                End If

    '            Else
    '                If MessageBox.Show("The information will be deleted, do you want to continue", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
    '                    strDataP(0) = dgvSearch.Rows(intRowNumber).Cells(0).Value
    '                    strDataP(1) = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                    strDataP(2) = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                    strDataP(3) = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                    strDataP(4) = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                    strDataP(5) = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                    strDataP(6) = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                    strDataP(7) = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                    strDataP(8) = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                    strDataP(9) = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                    strDataP(10) = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                    strDataP(11) = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                    strDataP(12) = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                    strDataP(13) = dgvSearch.Rows(intRowNumber).Cells(13).Value
    '                    strDataP(14) = dgvSearch.Rows(intRowNumber).Cells(14).Value
    '                    strDataP(15) = dgvSearch.Rows(intRowNumber).Cells(15).Value

    '                    strData(0) = "DELETED"
    '                    strData(1) = dgvSearch.Rows(intRowNumber).Cells(1).Value
    '                    strData(2) = dgvSearch.Rows(intRowNumber).Cells(2).Value
    '                    strData(3) = dgvSearch.Rows(intRowNumber).Cells(3).Value
    '                    strData(4) = dgvSearch.Rows(intRowNumber).Cells(4).Value
    '                    strData(5) = dgvSearch.Rows(intRowNumber).Cells(5).Value
    '                    strData(6) = dgvSearch.Rows(intRowNumber).Cells(6).Value
    '                    strData(7) = dgvSearch.Rows(intRowNumber).Cells(7).Value
    '                    strData(8) = dgvSearch.Rows(intRowNumber).Cells(8).Value
    '                    strData(9) = dgvSearch.Rows(intRowNumber).Cells(9).Value
    '                    strData(10) = dgvSearch.Rows(intRowNumber).Cells(10).Value
    '                    strData(11) = dgvSearch.Rows(intRowNumber).Cells(11).Value
    '                    strData(12) = dgvSearch.Rows(intRowNumber).Cells(12).Value
    '                    strData(13) = dgvSearch.Rows(intRowNumber).Cells(13).Value
    '                    strData(14) = dgvSearch.Rows(intRowNumber).Cells(14).Value
    '                    strData(15) = dgvSearch.Rows(intRowNumber).Cells(15).Value

    '                    CSVUPdate(strInfoCsv, 16)
    '                    btnFilter.PerformClick()
    '                End If

    '            End If


    '    End Select
    'End Sub

End Class