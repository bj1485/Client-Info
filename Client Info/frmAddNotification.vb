Public Class frmAddNotification
    Private Sub frmAddNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main
        dtpDate.Value = Date.Today

        If blnUpdateNotify = True AndAlso Not strNotiTemp(0) > "" Then

            Try
                Dim parsedDate As Date = Date.Parse(strDataN(16))
                dtpDate.Value = parsedDate
                txtHeader.Text = strDataN(17)
            Catch ex As Exception
                MessageBox.Show("Invalid date format. Please use a valid date string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf strNotiTemp(0) > "" AndAlso strNotiTemp(1) > "" Then
            Dim parsedDate As Date = Date.Parse(strNotiTemp(0))
            dtpDate.Value = parsedDate
            txtHeader.Text = strNotiTemp(1)

        End If

        blnAddReminder = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        If Not String.IsNullOrEmpty(txtHeader.Text) Then

            Dim selectedDate As Date = dtpDate.Value.Date
            strNotiTemp(0) = selectedDate.ToString("yyyy-MM-dd")
            strNotiTemp(1) = txtHeader.Text
            strData(16) = strNotiTemp(0)

            strNotiTemp(1) = strNotiTemp(1).Trim
            strData(17) = strNotiTemp(1)

            Dim allLines As String() = strData(17).Split({vbCrLf, vbLf, vbCr}, StringSplitOptions.None)

            ' Filter out lines that are empty or whitespace only
            Dim trimmedLines = allLines.Where(Function(line) Not String.IsNullOrWhiteSpace(line)).ToArray()

            ' Re-join cleaned lines
            strData(17) = String.Join(vbNewLine, trimmedLines).Trim()

            blnAddReminder = True
            Me.Close()

        Else

            MessageBox.Show("The header textbox cannot be blank.", "Header textbox empty.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If blnUpdateNotify = True Then

            If MessageBox.Show("Do you want to delete the reminder?", "Delete Reminder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                strData(0) = "DELETED"
                CSVUPdate(strNotificationsPath, 18, "Notification")
                blnUpdateNotify = False
                blnAddReminder = False
                Me.Close()
            End If

        End If

    End Sub

   

End Class