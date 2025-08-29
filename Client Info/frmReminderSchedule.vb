Imports System.IO
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic.FileIO
Imports System.ComponentModel
Imports System.Net

Public Class frmReminderSchedule

    Dim intTimer As Integer

    Private Sub frmReminderSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main

    End Sub



    Private Sub CSVDataGrid(ByVal strFile As String)


        Using reader As New StreamReader(strDatabasePath & strFile)
            While Not reader.EndOfStream
                Dim decryptedLine As String = DecryptString(reader.ReadLine())


                Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                    strReader.Delimiters = New String() {";"}
                    strReader.HasFieldsEnclosedInQuotes = True
                    strReader.TextFieldType = FieldType.Delimited

                    Dim fields() As String = strReader.ReadFields()

                    If fields.Length > 17 AndAlso Not fields(0) = "DELETED" Then

                        dgvNotifications.Rows.Add(fields(0), fields(1), fields(16), fields(17), decryptedLine)


                    End If
                End Using
            End While
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
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


        ReadCsv("Notifications.csv", strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 17, dgvNotifications, True) ' working
        ' ReadCsv(strInfoCsv, strSearchValues(0), strSearchValues(1), strSearchValues(2), strSearchValues(3), strSearchValues(4), strSearchValues(5), strSearchValues(6), strSearchValues(7), strSearchValues(8), 15, dgvSearch, False) 'working


        dgvNotifications.Sort(dgvNotifications.Columns(3), ListSortDirection.Ascending)
        'End If


    End Sub

    Private Sub dgvNotifications_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNotifications.CellContentClick
        If e.RowIndex < 0 Then Exit Sub ' Avoid header click crash

        Dim selectedRow As DataGridViewRow = dgvNotifications.Rows(e.RowIndex)
        Dim intColumnIndex As Integer = e.ColumnIndex

        Try
            If intColumnIndex > 0 AndAlso intColumnIndex < 17 Then
                Clipboard.SetText(selectedRow.Cells(intColumnIndex).Value?.ToString())
            End If
        Catch ex As Exception
            MessageBox.Show("Clipboard error: " & ex.Message)
        End Try

        Select Case intColumnIndex
            Case 0, 19

                If blnNotiChange = True Or blnInfoChange = True Or blnClientChange = True Then
                    MessageBox.Show("Client Info is busy updating, wait until the update has finished.", "Update in progress", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Exit Sub
                End If

                'blnEdit = True
                'Dim isAccount As Boolean = selectedRow.Cells(16).Value?.ToString().Contains("Accounts")

                If intInfoOpen = 0 Then


                    blnEditInfo = True

                    Dim mapStrDataI() As Integer = {0, 1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 3, 4}
                    For i As Integer = 0 To mapStrDataI.Length - 1
                        strDataI(i) = selectedRow.Cells(mapStrDataI(i)).Value
                    Next


                    frmCaptureInfo.Show()
                    frmCaptureInfo.cmbBoxTemplate.Text = selectedRow.Cells(2).Value
                    frmCaptureInfo.txt1.Text = selectedRow.Cells(0).Value
                    frmCaptureInfo.cmbClient.Text = selectedRow.Cells(1).Value
                    frmCaptureInfo.txt3.Text = selectedRow.Cells(5).Value
                    frmCaptureInfo.txt4.Text = selectedRow.Cells(6).Value
                    frmCaptureInfo.txt5.Text = selectedRow.Cells(7).Value
                    frmCaptureInfo.txt6.Text = selectedRow.Cells(8).Value
                    frmCaptureInfo.txt7.Text = selectedRow.Cells(9).Value
                    frmCaptureInfo.txt8.Text = selectedRow.Cells(10).Value
                    frmCaptureInfo.txt9.Text = selectedRow.Cells(11).Value
                    frmCaptureInfo.txt10.Text = selectedRow.Cells(12).Value
                    frmCaptureInfo.txt11.Text = selectedRow.Cells(13).Value
                    frmCaptureInfo.txt12.Text = selectedRow.Cells(14).Value
                    frmCaptureInfo.txt13.Text = selectedRow.Cells(15).Value
                    frmCaptureInfo.txt14.Text = selectedRow.Cells(16).Value
                    frmCaptureInfo.txt15.Text = selectedRow.Cells(17).Value

                End If

            Case 20

                If blnNotiChange = True Or blnInfoChange = True Or blnClientChange = True Then
                    MessageBox.Show("Client Info is busy updating, wait until the update has finished.", "Update in progress", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Exit Sub
                End If

                If MessageBox.Show("The information will be deleted, do you want to continue?", "Delete Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then

                    Dim mapStrDataN() As Integer = {0, 1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 3, 4}
                    Dim mapStrData() As Integer = {1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 3, 4}

                    ' Assign values to strDataN
                    For i As Integer = 0 To mapStrDataN.Length - 1
                        strDataN(i) = selectedRow.Cells(mapStrDataN(i)).Value
                    Next

                    ' First element of strData is always "DELETED"
                    strData(0) = "DELETED"

                    ' Assign values to strData, skipping index 0
                    For i As Integer = 0 To mapStrData.Length - 1
                        strData(i + 1) = selectedRow.Cells(mapStrData(i)).Value
                    Next

                    CSVUPdate(strNotificationsPath, 18, "Notification")
                    btnSearch.PerformClick()

                End If

        End Select

    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click

        If btnShow.Text = "Show All" Then
            btnShow.Text = "Hide"
            dgvNotifications.Columns("Column2").Visible = True
            dgvNotifications.Columns("Column3").Visible = True
            dgvNotifications.Columns("Column4").Visible = True
            dgvNotifications.Columns("Column5").Visible = True
            dgvNotifications.Columns("Column6").Visible = True
            dgvNotifications.Columns("Column7").Visible = True
            dgvNotifications.Columns("Column8").Visible = True
            dgvNotifications.Columns("Column9").Visible = True
            dgvNotifications.Columns("Column10").Visible = True
            dgvNotifications.Columns("Column11").Visible = True
            dgvNotifications.Columns("Column12").Visible = True
            dgvNotifications.Columns("Column13").Visible = True
            dgvNotifications.Columns("Column14").Visible = True

        Else
            btnShow.Text = "Show All"
            dgvNotifications.Columns("column2").Visible = False
            dgvNotifications.Columns("Column3").Visible = False
            dgvNotifications.Columns("Column4").Visible = False
            dgvNotifications.Columns("Column5").Visible = False
            dgvNotifications.Columns("Column6").Visible = False
            dgvNotifications.Columns("Column7").Visible = False
            dgvNotifications.Columns("Column8").Visible = False
            dgvNotifications.Columns("Column9").Visible = False
            dgvNotifications.Columns("Column10").Visible = False
            dgvNotifications.Columns("Column11").Visible = False
            dgvNotifications.Columns("Column12").Visible = False
            dgvNotifications.Columns("Column13").Visible = False
            dgvNotifications.Columns("Column14").Visible = False
        End If
    End Sub

    Private Sub tmSearch_Tick(sender As Object, e As EventArgs) Handles tmSearch.Tick
        intTimer = intTimer + 1
        If intTimer = 3 Then
            btnSearch.PerformClick()
            tmSearch.Stop()

        End If

    End Sub

    Private Sub txtSearch1_TextChanged(sender As Object, e As EventArgs) Handles txtSearch1.TextChanged
        dgvNotifications.Rows.Clear()

        If txtSearch1.Text.Length < 2 Then
            tmSearch.Stop()
            Exit Sub
        End If

        intTimer = 0
        tmSearch.Start()
    End Sub


End Class