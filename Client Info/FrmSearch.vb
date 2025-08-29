Imports System.ComponentModel
Imports System.Reflection
Imports System.Runtime.ExceptionServices
Imports Microsoft.VisualBasic.FileIO
Public Class FrmSearch
    Dim intTimer As Integer


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'If txtSearch.Text.Length.ToString > 1 Then
        Dim strTxtValue As String
        Dim strSearchValues(10) As String
        Dim intStrtxt As Integer
        Dim intCounter As Integer


        If blnSearchFilter = True Then
            If cmbClient.Text > "" Then
                strTxtValue = cmbClient.Text & " " & cmbTemplate.Text
            Else
                strTxtValue = cmbTemplate.Text

            End If

        End If

        If blnSearchFilter = False Then
            strTxtValue = txtSearch1.Text

        End If

        intStrtxt = InStr(strTxtValue, " ")

        Try
            Do Until intCounter = 9
                strSearchValues(intCounter) = Microsoft.VisualBasic.Left(strTxtValue, intStrtxt)
                strTxtValue = Replace(strTxtValue, strSearchValues(intCounter), "")
                strSearchValues(intCounter) = strSearchValues(intCounter).Trim()

                Console.WriteLine("[" & strSearchValues(intCounter) & "]" & "  " & intCounter)

                intStrtxt = InStr(strTxtValue, " ")

                If intStrtxt = 0 AndAlso strTxtValue > "" Then

                    If Not strSearchValues(0) = Nothing Then intCounter = intCounter + 1
                    strSearchValues(intCounter) = strTxtValue
                    Console.WriteLine("[" & strSearchValues(intCounter) & "]" & " " & intCounter)
                    Exit Do
                End If

                intCounter = intCounter + 1

            Loop

        Catch ex As Exception

        End Try

        If chbSearchAcc.Checked = True Then
            ReadCsv("Accounts.csv", strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 13, dgvSearch, True)
        Else
            ReadCsv("Accounts.csv", strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 13, dgvSearch, True) ' working
            ReadCsv("Information.csv", strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 15, dgvSearch, False) 'working

        End If
        dgvSearch.Sort(dgvSearch.Columns(2), ListSortDirection.Ascending)
        'End If


    End Sub

    Private Sub FrmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.MdiParent = Main
        LoadCSVTemplate(strTemplatePath, cmbTemplate) ' Working
        ReadCSVCombo("Accounts.csv", cmbClient) ' Working
        If blnSearchAccOnly = True Then chbSearchAcc.Checked = True
        If blnSearchFilter = True Then
            rbFilter.Checked = True
        Else
            rbSearch.Checked = True

        End If
    End Sub

    Private Sub tmSearch_Tick(sender As Object, e As EventArgs) Handles tmSearch.Tick
        intTimer = intTimer + 1
        If intTimer = 3 Then
            Dim strTxtValue As String
            Dim strSearchValues(10) As String
            Dim intStrtxt As Integer
            Dim intCounter As Integer

            strTxtValue = txtSearch1.Text
            intStrtxt = InStr(strTxtValue, " ")

            Try
                Do Until intCounter = 9
                    strSearchValues(intCounter) = Microsoft.VisualBasic.Left(strTxtValue, intStrtxt)
                    strTxtValue = Replace(strTxtValue, strSearchValues(intCounter), "")
                    strSearchValues(intCounter) = strSearchValues(intCounter).Trim()

                    Console.WriteLine("[" & strSearchValues(intCounter) & "]" & "  " & intCounter)

                    intStrtxt = InStr(strTxtValue, " ")

                    If intStrtxt = 0 AndAlso strTxtValue > "" Then

                        If Not strSearchValues(0) = Nothing Then intCounter = intCounter + 1
                        strSearchValues(intCounter) = strTxtValue
                        Console.WriteLine("[" & strSearchValues(intCounter) & "]" & " " & intCounter)
                        Exit Do
                    End If

                    intCounter = intCounter + 1

                Loop
            Catch ex As Exception

            End Try
            If chbSearchAcc.Checked = True Then
                ReadCsv("Accounts.csv", strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 13, dgvSearch, True)
            Else
                ReadCsv("Accounts.csv", strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 13, dgvSearch, True) ' working
                ReadCsv("Information.csv", strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 15, dgvSearch, False) 'working
            End If
            dgvSearch.Sort(dgvSearch.Columns(2), ListSortDirection.Ascending)
            tmSearch.Stop()

        End If

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch1.TextChanged
        dgvSearch.Rows.Clear()

        If txtSearch1.Text.Length < 2 Then
            tmSearch.Stop()
            Exit Sub
        End If

        intTimer = 0
        tmSearch.Start()


    End Sub

    Private Sub dgvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellContentClick
        'Private Sub dgvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellContentClick
        If e.RowIndex < 0 Then Exit Sub ' Avoid header click crash

        Dim selectedRow As DataGridViewRow = dgvSearch.Rows(e.RowIndex)
        Dim intColumnIndex As Integer = e.ColumnIndex

        Try
            If intColumnIndex > 0 AndAlso intColumnIndex < 17 Then
                Clipboard.SetText(selectedRow.Cells(intColumnIndex).Value?.ToString())
            End If
        Catch ex As Exception
            MessageBox.Show("Clipboard error: " & ex.Message)
        End Try

        Select Case intColumnIndex
            Case 0, 17

                If blnNotiChange = True Or blnInfoChange = True Or blnClientChange = True Then
                    MessageBox.Show("Client Info is busy updating, wait until the update has finished.", "Update in progress", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Exit Sub
                End If
                'blnEdit = True
                Dim isAccount As Boolean = selectedRow.Cells(16).Value?.ToString().Contains("Accounts")

                If isAccount AndAlso intClientOpen = 0 Then
                    blnEditClient = True
                    ' Show Accounts Form
                    FrmNewClient.Show()
                    FrmNewClient.txtAccount_No.Text = selectedRow.Cells(0).Value
                    FrmNewClient.txtClientName.Text = selectedRow.Cells(1).Value
                    FrmNewClient.txtnumTelephone_No.Text = selectedRow.Cells(3).Value
                    FrmNewClient.txtnumAltTelephone.Text = selectedRow.Cells(4).Value
                    FrmNewClient.txtnumFax.Text = selectedRow.Cells(5).Value
                    FrmNewClient.txtContactPerson.Text = selectedRow.Cells(6).Value
                    FrmNewClient.txtEmail.Text = selectedRow.Cells(7).Value
                    FrmNewClient.txtAltEmail.Text = selectedRow.Cells(8).Value
                    FrmNewClient.txtAddress1.Text = selectedRow.Cells(9).Value
                    FrmNewClient.txtAddress2.Text = selectedRow.Cells(10).Value
                    FrmNewClient.txtAddress3.Text = selectedRow.Cells(11).Value
                    FrmNewClient.txtnumPostal.Text = selectedRow.Cells(12).Value
                    FrmNewClient.txtNotes.Text = selectedRow.Cells(13).Value

                    ShowAttached(selectedRow.Cells(0).Value.ToString(), FrmNewClient.lvAttachments, FrmNewClient.imgExtract)
                    FillStringDataPFromRow(selectedRow, strDataP, 14)

                ElseIf isAccount = False AndAlso intInfoOpen = 0 Then
                    blnEditInfo = True
                    ' Show General Info Form
                    FillStringDataPFromRow(selectedRow, strDataI, 16)
                    frmCaptureInfo.Show()
                    frmCaptureInfo.cmbBoxTemplate.Text = selectedRow.Cells(2).Value
                    frmCaptureInfo.txt1.Text = selectedRow.Cells(0).Value
                    frmCaptureInfo.cmbClient.Text = selectedRow.Cells(1).Value
                    frmCaptureInfo.txt3.Text = selectedRow.Cells(3).Value
                    frmCaptureInfo.txt4.Text = selectedRow.Cells(4).Value
                    frmCaptureInfo.txt5.Text = selectedRow.Cells(5).Value
                    frmCaptureInfo.txt6.Text = selectedRow.Cells(6).Value
                    frmCaptureInfo.txt7.Text = selectedRow.Cells(7).Value
                    frmCaptureInfo.txt8.Text = selectedRow.Cells(8).Value
                    frmCaptureInfo.txt9.Text = selectedRow.Cells(9).Value
                    frmCaptureInfo.txt10.Text = selectedRow.Cells(10).Value
                    frmCaptureInfo.txt11.Text = selectedRow.Cells(11).Value
                    frmCaptureInfo.txt12.Text = selectedRow.Cells(12).Value
                    frmCaptureInfo.txt13.Text = selectedRow.Cells(13).Value
                    frmCaptureInfo.txt14.Text = selectedRow.Cells(14).Value
                    frmCaptureInfo.txt15.Text = selectedRow.Cells(15).Value


                End If

            Case 18
                Dim isAccount As Boolean = selectedRow.Cells(16).Value?.ToString().Contains("Accounts")

                If blnNotiChange = True Or blnInfoChange = True Or blnClientChange = True Then
                    MessageBox.Show("Client Info is busy updating, wait until the update has finished.", "Update in progress", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If


                If isAccount Then
                    If MessageBox.Show("The account with all captured information will be deleted. Do you want to continue?", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
                        FillStringDataPFromRow(selectedRow, strDataP, 14)
                        FillStringDataPFromRow(selectedRow, strData, 14)
                        strData(0) = "DELETED"
                        CSVUPdate(strAccountsCSV, 14, "ClientAccount")
                        CSVDeleteAll(selectedRow.Cells(0).Value.ToString())
                        CSVDeleteNoti(selectedRow.Cells(0).Value.ToString())
                        btnSearch.PerformClick()
                    End If
                Else
                    If MessageBox.Show("The information will be deleted, do you want to continue?", "Delete Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
                        FillStringDataPFromRow(selectedRow, strDataI, 16)
                        FillStringDataPFromRow(selectedRow, strData, 16)
                        strData(0) = "DELETED"
                        'CSVUPdate(strInfoCsv, 16, "ClientInfo")


                        ' Temp Fix *****
                        Dim intC As Integer
                        strDataI(17) = ""
                        ReadNotifications(strNotificationsPath, True, intC)

                        If Not strDataI(17) > "" Then
                            CSVUPdate(strInfoCsv, 16, "ClientInfo")
                        Else
                            MessageBox.Show("Please delete the reminder first.", "Active Reminder Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        'CSVUPdate(strNotificationsPath, 18, "ClientInfo")

                        '**** Temp Fix


                        btnSearch.PerformClick()
                    End If
                End If
        End Select

    End Sub

    Private Sub FillStringDataPFromRow(row As DataGridViewRow, ByRef target() As String, count As Integer)
        For i = 0 To count - 1
            target(i) = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
        Next
    End Sub


    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If btnShow.Text = "Show All" Then
            btnShow.Text = "Hide"
            dgvSearch.Columns("Text6").Visible = True
            dgvSearch.Columns("Text7").Visible = True
            dgvSearch.Columns("Text8").Visible = True
            dgvSearch.Columns("Text9").Visible = True
            dgvSearch.Columns("Text10").Visible = True
            dgvSearch.Columns("Text11").Visible = True
            dgvSearch.Columns("Text12").Visible = True
            dgvSearch.Columns("Text13").Visible = True
            dgvSearch.Columns("Text14").Visible = True
            dgvSearch.Columns("Text15").Visible = True
        Else
            btnShow.Text = "Show All"
            dgvSearch.Columns("Text6").Visible = False
            dgvSearch.Columns("Text7").Visible = False
            dgvSearch.Columns("Text8").Visible = False
            dgvSearch.Columns("Text9").Visible = False
            dgvSearch.Columns("Text10").Visible = False
            dgvSearch.Columns("Text11").Visible = False
            dgvSearch.Columns("Text12").Visible = False
            dgvSearch.Columns("Text13").Visible = False
            dgvSearch.Columns("Text14").Visible = False
            dgvSearch.Columns("Text15").Visible = False

        End If

    End Sub

    Private Sub chbSearchAcc_CheckedChanged(sender As Object, e As EventArgs) Handles chbSearchAcc.CheckedChanged
        If chbSearchAcc.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchAccOnly", "True")
            blnSearchAccOnly = True

        Else
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchAccOnly", "False")
            blnSearchAccOnly = False
        End If

    End Sub

    Private Sub rbSearch_CheckedChanged(sender As Object, e As EventArgs) Handles rbSearch.CheckedChanged
        If rbSearch.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchFilter", "False")
            txtSearch1.Visible = True
            cmbClient.Visible = False
            cmbTemplate.Visible = False
            blnSearchFilter = False

        End If

    End Sub

    Private Sub rbFilter_CheckedChanged(sender As Object, e As EventArgs) Handles rbFilter.CheckedChanged
        If rbFilter.Checked = True Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", "SearchFilter", "True")
            txtSearch1.Visible = False
            cmbClient.Visible = True
            cmbTemplate.Visible = True
            blnSearchFilter = True

        End If

    End Sub



End Class