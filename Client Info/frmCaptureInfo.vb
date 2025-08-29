Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Runtime.Serialization

Public Class frmCaptureInfo
    Private Sub frmCaptureInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = Main
        intInfoOpen = 1
        btnSchedule.Enabled = blnEditInfo
        LoadCSVTemplate(strTemplatePath, cmbBoxTemplate) ' Working

        'If Not blnEditInfo = True Then
        ReadCSVCombo("Accounts.csv", cmbClient)
        'End If
        ' Working


        Dim intUpdateNotifications As Integer
        If blnEditInfo = True Then
            ReadNotifications("Notifications.csv", True, intUpdateNotifications)
            'MsgBox(strDataN(1) & "****")
            strData(16) = strDataN(16)
            strData(17) = strDataN(17)

        End If
        'MsgBox(strDataN(1) & " Hello")

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim intCount As Integer
        'MsgBox(blnAddReminder)

        strData(2) = cmbBoxTemplate.Text
        strData(0) = txt1.Text
        strData(1) = cmbClient.Text
        strData(3) = txt3.Text
        strData(4) = txt4.Text
        strData(5) = txt5.Text
        strData(6) = txt6.Text
        strData(7) = txt7.Text
        strData(8) = txt8.Text
        strData(9) = txt9.Text
        strData(10) = txt10.Text
        strData(11) = txt11.Text
        strData(12) = txt12.Text
        strData(13) = txt13.Text
        strData(14) = txt14.Text
        strData(15) = txt15.Text

        For i As Integer = 0 To 15
            If strData(i) = strDataI(i) AndAlso blnEditInfo = True Then intCount += 1
            'MsgBox(strDataI(i))
        Next

        'MsgBox(intCount)
        If intCount = 16 AndAlso blnUpdateNotify = False AndAlso blnAddReminder = False Then
            Me.Close()
            Exit Sub
        End If

        Dim allLines As String() = strData(15).Split({vbCrLf, vbLf, vbCr}, StringSplitOptions.None)

        ' Filter out lines that are empty or whitespace only
        Dim trimmedLines = allLines.Where(Function(line) Not String.IsNullOrWhiteSpace(line)).ToArray()

        ' Re-join cleaned lines
        strData(15) = String.Join(vbNewLine, trimmedLines).Trim()


        'Dim lines() As String = strData(15).Split(vbNewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        'strData(15) = String.Join(vbNewLine, lines)

        For i As Integer = 0 To 17
            If strData(i) > "" Then
                strData(i) = strData(i).Trim
            End If

        Next

        'blnInfoChange = True
        Select Case blnEditInfo
            Case Is = False
                If txt1.Text > "" Then
                    CSVComposer(strInfoCsv, 16) 'Working
                Else
                    MessageBox.Show("No client has been selected", "Select Client", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                For Each txtcontrol In Me.Controls
                    If TypeOf txtcontrol Is TextBox Then
                        If Not txtcontrol.Name = "txt1" Then
                            txtcontrol.text = ""
                        End If
                    End If
                Next

            Case Is = True

                'MsgBox(strDataN(0) & " This is n")
                CSVUPdate(strInfoCsv, 16, "ClientInfo") ' Working

                '
                ' MsgBox(blnAddReminder & " **** " & blnUpdateNotify)
                If blnAddReminder = True AndAlso blnUpdateNotify = False Then
                    ' blnNotiChange = True

                    CSVComposer(strNotificationsPath, 18)

                    blnAddReminder = False
                End If

                If blnUpdateNotify AndAlso Not String.IsNullOrEmpty(strData(16)) Then

                    'MsgBox("Fine")
                    'blnNotiChange = True
                    CSVUPdate(strNotificationsPath, 18, "Notification")


                    blnUpdateNotify = False



                End If


                'CountNotifications()
                'FrmSearch.btnSearch.PerformClick()
                frmReminderSchedule.btnSearch.PerformClick()


                Me.Close()


        End Select


    End Sub

    Private Sub cmbBoxTemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBoxTemplate.SelectedIndexChanged

        For Each txtcontrol In Me.Controls
            If TypeOf txtcontrol Is TextBox Then
                txtcontrol.visible = True
                txtcontrol.text = ""
            End If
        Next
        cmbClient.Text = ""

        CSVTemplate(strTemplatePath, cmbBoxTemplate.Text, "CaptureInfo") ' Working

    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        ACCCaptureInfo(txt1, cmbClient.SelectedItem.ToString) 'Working
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click


        Dim emailTo As String = ""
        Dim emailSubject As String = "Client Information"

        Dim emailBody As New Text.StringBuilder()

        emailBody.AppendLine("Good Day")
        emailBody.AppendLine()
        emailBody.AppendLine("Please view the information below")
        emailBody.AppendLine()

        If Not String.IsNullOrWhiteSpace(lbl1.Text) Then emailBody.AppendLine(lbl1.Text & ": " & txt1.Text)
        If Not String.IsNullOrWhiteSpace(lbl2.Text) Then emailBody.AppendLine(lbl2.Text & ": " & cmbClient.Text)
        If Not String.IsNullOrWhiteSpace(lbl3.Text) Then emailBody.AppendLine(lbl3.Text & ": " & txt3.Text)
        If Not String.IsNullOrWhiteSpace(lbl4.Text) Then emailBody.AppendLine(lbl4.Text & ": " & txt4.Text)
        If Not String.IsNullOrWhiteSpace(lbl5.Text) Then emailBody.AppendLine(lbl5.Text & ": " & txt5.Text)
        If Not String.IsNullOrWhiteSpace(lbl6.Text) Then emailBody.AppendLine(lbl6.Text & ": " & txt6.Text)
        If Not String.IsNullOrWhiteSpace(lbl7.Text) Then emailBody.AppendLine(lbl7.Text & ": " & txt7.Text)
        If Not String.IsNullOrWhiteSpace(lbl8.Text) Then emailBody.AppendLine(lbl8.Text & ": " & txt8.Text)
        If Not String.IsNullOrWhiteSpace(lbl9.Text) Then emailBody.AppendLine(lbl9.Text & ": " & txt9.Text)
        If Not String.IsNullOrWhiteSpace(lbl10.Text) Then emailBody.AppendLine(lbl10.Text & ": " & txt10.Text)
        If Not String.IsNullOrWhiteSpace(lbl11.Text) Then emailBody.AppendLine(lbl11.Text & ": " & txt11.Text)
        If Not String.IsNullOrWhiteSpace(lbl12.Text) Then emailBody.AppendLine(lbl12.Text & ": " & txt12.Text)
        If Not String.IsNullOrWhiteSpace(lbl13.Text) Then emailBody.AppendLine(lbl13.Text & ": " & txt13.Text)
        If Not String.IsNullOrWhiteSpace(lbl14.Text) Then emailBody.AppendLine(lbl14.Text & ": " & txt14.Text)
        If Not String.IsNullOrWhiteSpace(NOTES.Text) Then emailBody.AppendLine(NOTES.Text & ": " & txt15.Text)


        ' Encode subject and body for URL
        Dim subjectEncoded As String = Uri.EscapeDataString(emailSubject)
        Dim bodyEncoded As String = Uri.EscapeDataString(emailBody.ToString())

        ' Create mailto link
        Dim mailtoLink As String = $"mailto:{emailTo}?subject={subjectEncoded}&body={bodyEncoded}"

        ' Launch default mail client
        Process.Start(mailtoLink)
    End Sub

    Private WithEvents printDoc As New Printing.PrintDocument
    Private companyName As String = ""
    Private companyLogo As Image = Nothing
    Private Sub LoadCompanyInfo()
        Dim filePath As String = strDatabasePath & "\Company.txt"

        If IO.File.Exists(filePath) Then
            Dim lines() As String = IO.File.ReadAllLines(filePath)
            If lines.Length >= 2 Then
                Dim imagePath As String = lines(0).Trim()
                imagePath = strDatabasePath & "\" & lines(0)

                If IO.File.Exists(imagePath) Then

                    Using imgStream As New IO.FileStream(imagePath, IO.FileMode.Open, IO.FileAccess.Read)
                        companyLogo = Image.FromStream(imgStream)
                    End Using

                End If

                companyName = lines(1).Trim()
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        LoadCompanyInfo() ' Load logo and company name from file

        Dim printDialog As New PrintDialog()
        printDialog.Document = printDoc
        printDialog.AllowSelection = True
        printDialog.AllowSomePages = False
        printDialog.UseEXDialog = True ' Enables modern printer dialog on Windows

        If printDialog.ShowDialog() = DialogResult.OK Then
            printDoc.PrinterSettings = printDialog.PrinterSettings
            printDoc.Print()
        End If
    End Sub

    Private Sub printDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles printDoc.PrintPage
        Dim g As Graphics = e.Graphics
        Dim y As Integer = 50
        Dim leftMargin As Integer = 50
        Dim labelFont As New Font("Arial", 10, FontStyle.Bold)
        Dim valueFont As New Font("Arial", 10)

        ' Draw company logo
        If companyLogo IsNot Nothing Then
            g.DrawImage(companyLogo, 50, y, 100, 100)
        End If

        ' Draw company name
        g.DrawString(companyName, New Font("Arial", 14, FontStyle.Bold), Brushes.Black, 160, y + 30)
        y += 120

        ' Draw form fields
        If Not String.IsNullOrWhiteSpace(lbl2.Text) Then
            g.DrawString(lbl2.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(cmbClient.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl3.Text) Then
            g.DrawString(lbl3.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt3.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl4.Text) Then
            g.DrawString(lbl4.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt4.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl5.Text) Then
            g.DrawString(lbl5.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt5.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl6.Text) Then
            g.DrawString(lbl6.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt6.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl7.Text) Then
            g.DrawString(lbl7.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt7.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl8.Text) Then
            g.DrawString(lbl8.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt8.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl9.Text) Then
            g.DrawString(lbl9.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt9.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl10.Text) Then
            g.DrawString(lbl10.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt10.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl11.Text) Then
            g.DrawString(lbl11.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt11.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If
        If Not String.IsNullOrWhiteSpace(lbl12.Text) Then
            g.DrawString(lbl12.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt12.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl3.Text) Then
            g.DrawString(lbl13.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt13.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl14.Text) Then
            g.DrawString(lbl14.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt14.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

        If Not String.IsNullOrWhiteSpace(lbl2.Text) Then
            g.DrawString(NOTES.Text, labelFont, Brushes.Black, leftMargin, y)
            g.DrawString(txt15.Text, valueFont, Brushes.Black, leftMargin + 150, y)
            y += 25
        End If

    End Sub

    Private Sub frmCaptureInfo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmNotifications.btnRefresh.PerformClick()
        blnUpdateNotify = False
        intInfoOpen = 0
    End Sub

    Private Sub btnSchedule_Click(sender As Object, e As EventArgs) Handles btnSchedule.Click

        strData(2) = cmbBoxTemplate.Text
        strData(0) = txt1.Text
        strData(1) = cmbClient.Text
        strData(3) = txt3.Text
        strData(4) = txt4.Text
        strData(5) = txt5.Text
        strData(6) = txt6.Text
        strData(7) = txt7.Text
        strData(8) = txt8.Text
        strData(9) = txt9.Text
        strData(10) = txt10.Text
        strData(11) = txt11.Text
        strData(12) = txt12.Text
        strData(13) = txt13.Text
        strData(14) = txt14.Text
        strData(15) = txt15.Text

        frmAddNotification.Show()
    End Sub

    Private Sub frmCaptureInfo_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        blnUpdateNotify = False
        blnAddReminder = False

        For i As Integer = 0 To 17
            strData(i) = ""
        Next
        strNotiTemp(0) = ""
        strNotiTemp(1) = ""

    End Sub



End Class