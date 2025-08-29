Public Class FrmNewClient
    Dim strPathFile As String
    Dim intFiles As Integer
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim intCount As Integer
        'MsgBox(blnEditClient)

        strData(0) = txtAccount_No.Text
        strData(1) = txtClientName.Text
        strData(2) = "Account"
        strData(3) = txtnumTelephone_No.Text
        strData(4) = txtnumAltTelephone.Text
        strData(5) = txtnumFax.Text
        strData(6) = txtContactPerson.Text
        strData(7) = txtEmail.Text
        strData(8) = txtAltEmail.Text
        strData(9) = txtAddress1.Text
        strData(10) = txtAddress2.Text
        strData(11) = txtAddress3.Text
        strData(12) = txtnumPostal.Text
        strData(13) = txtNotes.Text


        For i As Integer = 0 To 13
            If strData(i) = strDataP(i) AndAlso blnEditClient = True Then intCount += 1
        Next

        If intCount = 14 Then
            Me.Close()
            Exit Sub
        End If

        'Dim strInvalidcar As String

        'strInvalidcar = strData(0) & " " & strData(1) & strData(2) & " " & strData(3) & " " & strData(4) & " " & strData(5) & " " & strData(6) & " " & strData(7) & " " & strData(8) & " " & strData(9) & " " & strData(10) & " " & strData(11) & " " & strData(12) & " " & strData(13)
        'Dim intstrSC As Integer
        'Dim intstrQ
        'intstrSC = InStr(strInvalidcar, ";")
        'intstrQ = InStr(strInvalidcar, """")

        'If intstrSC + intstrQ > 0 Then
        '    MessageBox.Show("You cannot use the following text "";"" or "".", "Invalid Caracter", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub

        'End If

        Dim allLines As String() = strData(13).Split({vbCrLf, vbLf, vbCr}, StringSplitOptions.None)

        ' Filter out lines that are empty or whitespace only
        Dim trimmedLines = allLines.Where(Function(line) Not String.IsNullOrWhiteSpace(line)).ToArray()

        ' Re-join cleaned lines
        strData(13) = String.Join(vbNewLine, trimmedLines).Trim()


        'Dim lines() As String = strData(13).Split(vbNewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        'strData(13) = String.Join(vbNewLine, lines)

        For i As Integer = 0 To 13
            strData(i) = strData(i).Trim
        Next


        blnClientChange = True
        Select Case blnEditClient
            Case Is = False
                If Not String.IsNullOrWhiteSpace(txtClientName.Text) Then
                    'Dim filesize As New System.IO.FileInfo(strDatabasePath & strAccountsCSV)
                    'MessageBox.Show(filesize.Length)
                    CSVComposer(strAccountsCSV, 14) 'Working

                    Me.Close()
                Else
                    MessageBox.Show("The name field cannot be blank", "Form incomplete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Is = True
                If Not String.IsNullOrWhiteSpace(txtClientName.Text) Then
                    ' MessageBox.Show(strAccountsCSV)
                    'Dim filesize As New System.IO.FileInfo(strDatabasePath & strAccountsCSV)
                    'MessageBox.Show(filesize.Length)
                    CSVUPdate(strAccountsCSV, 14, "ClientAccount")
                    If Not strDataP(1) = txtClientName.Text Then
                        CSVUpdateName(strData(1), strData(0))
                        CSVUpdateNoti(strData(1), strData(0))
                    End If

                    'FrmSearch.btnSearch.PerformClick()
                    Me.Close()

                Else
                    MessageBox.Show("The name field cannot be blank", "Form incomplete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


        End Select



    End Sub

    Private Sub FrmNewClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        intClientOpen = 1
        Me.MdiParent = Main
        If blnEditClient = False Then
            CSVNumberAccount(txtAccount_No, strAccountsCSV)
        End If
        'Working
        tmRefreshAttachments.Start()
        'Dim intcounter As Integer



    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'ReadCsv(strAccountsCSV)
        Me.Close()
    End Sub



    Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        If txtAccount_No.Text > "" Then

            If (OFDAttach.ShowDialog() = DialogResult.OK) Then
                strPathFile = OFDAttach.FileName
                CopyNameFile(strPathFile, txtAccount_No.Text)
                lvAttachments.Clear()
                ShowAttached(txtAccount_No.Text, lvAttachments, imgExtract)
            End If
        End If



    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            My.Computer.FileSystem.DeleteFile(strDatabasePath & "\" & txtAccount_No.Text & "\" & lvAttachments.SelectedItems(0).Text)
            ShowAttached(txtAccount_No.Text, lvAttachments, imgExtract)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub lvAttachments_DoubleClick(sender As Object, e As EventArgs) Handles lvAttachments.DoubleClick
        Try
            Process.Start(strDatabasePath & "\" & txtAccount_No.Text & "\" & lvAttachments.SelectedItems(0).Text)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnOpenPath_Click(sender As Object, e As EventArgs) Handles btnOpenPath.Click
        Try
            If Not System.IO.Directory.Exists(strDatabasePath & "\" & txtAccount_No.Text) Then
                System.IO.Directory.CreateDirectory(strDatabasePath & "\" & txtAccount_No.Text)
            End If
            Process.Start(strDatabasePath & "\" & txtAccount_No.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tmRefreshAttachments_Tick(sender As Object, e As EventArgs) Handles tmRefreshAttachments.Tick
        Dim intCounter As Integer

        If System.IO.Directory.Exists(strDatabasePath & "\" & txtAccount_No.Text) Then
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(strDatabasePath & "\" & txtAccount_No.Text)
                intCounter = intCounter + 1
            Next

        End If

        If intCounter <> intFiles Then
            lvAttachments.Clear()
            ShowAttached(txtAccount_No.Text, lvAttachments, imgExtract)
            intFiles = intCounter
        End If

    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Dim emailTo As String = ""
        Dim emailSubject As String = "Client Information"

        ' Build email body from TextBoxes and Labels
        Dim emailBody As New Text.StringBuilder()
        emailBody.AppendLine("Good Day")
        emailBody.AppendLine()
        emailBody.AppendLine("Please view account information below")
        emailBody.AppendLine()
        emailBody.AppendLine("Client Name: " & txtClientName.Text)
        emailBody.AppendLine("Telephone Number: " & txtnumTelephone_No.Text)
        emailBody.AppendLine("Alt Telephone Number: " & txtnumAltTelephone.Text)
        emailBody.AppendLine("Cellphone Number: " & txtnumFax.Text)
        emailBody.AppendLine("Email Address: " & txtEmail.Text)
        emailBody.AppendLine("Alt Email Address: " & txtAltEmail.Text)
        emailBody.AppendLine("Address Line 1: " & txtAddress1.Text)
        emailBody.AppendLine("Address Line 2: " & txtAddress2.Text)
        emailBody.AppendLine("Address Line 3: " & txtAddress3.Text)
        emailBody.AppendLine("Postal Code: " & txtnumPostal.Text)
        emailBody.AppendLine("Address: " & txtNotes.Text)
        emailBody.AppendLine()
        emailBody.AppendLine("Thank You")

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

        g.DrawString("Client Name:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtClientName.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Telephone No:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtnumTelephone_No.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Alt Telephone No:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtnumAltTelephone.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Cellphone No:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtnumFax.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Contact Person", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtContactPerson.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Email Address:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtEmail.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Alt Email Address:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtAltEmail.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Address Line 1:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtAddress1.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Address Line 2", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtAddress2.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Address Line 3", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtAddress3.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Postal Code:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtnumPostal.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25

        g.DrawString("Notes:", labelFont, Brushes.Black, leftMargin, y)
        g.DrawString(txtNotes.Text, valueFont, Brushes.Black, leftMargin + 150, y)
        y += 25



    End Sub

    Private Sub FrmNewClient_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        For i As Integer = 0 To 17
            strData(i) = ""
        Next

        intClientOpen = 0
    End Sub



End Class