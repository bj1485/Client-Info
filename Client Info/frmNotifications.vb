Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar
Imports Microsoft.VisualBasic.FileIO
Imports System.Text.RegularExpressions

Public Class frmNotifications

    Private notifications As New List(Of String()) ' Each item is an array of fields
    Private currentIndex As Integer = -1 ' To track which item is currently shown

    Private blnClick As Boolean = False
    Private blnClick2 As Boolean = False

    'Private previousNotificationCount As Integer = -1

    Private Sub frmNotifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main
        ScrollNotifications("Notifications.csv")
        btnNext.PerformClick()
        intNotiOpen = 1
        tmPerformClick.Start()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click


        If currentIndex + 1 < notifications.Count Then
            currentIndex += 1
            DisplayNotification(currentIndex)
        End If

    End Sub

    Private Sub ScrollNotifications(ByVal strFile As String)
        notifications.Clear()

        If Not InMemoryData.ContainsKey(strFile) Then Exit Sub

        For Each fields In InMemoryData(strFile)
            Try
                If fields.Length > 17 Then
                    Dim strDate As String = fields(16).Trim()
                    Dim parseDate As Date

                    If Date.TryParse(strDate, parseDate) AndAlso parseDate.Date <= Date.Today AndAlso Not fields(0).ToUpper() = "DELETED" Then
                        notifications.Add(fields)
                    End If
                End If
            Catch
                ' Optionally handle or log bad rows
            End Try
        Next
    End Sub
    'Private Sub ScrollNotifications(ByVal strFile As String)
    '    notifications.Clear()

    '    Using reader As New StreamReader(strDatabasePath & strFile)
    '        While Not reader.EndOfStream
    '            Dim decryptedLine As String = DecryptString(reader.ReadLine())


    '            Using strReader As New TextFieldParser(New StringReader(decryptedLine))
    '                strReader.Delimiters = New String() {";"}
    '                strReader.HasFieldsEnclosedInQuotes = True
    '                strReader.TextFieldType = FieldType.Delimited

    '                Dim fields() As String = strReader.ReadFields()

    '                If fields.Length > 17 Then
    '                    Dim strDate As String = fields(16).Trim()
    '                    Dim parseDate As Date

    '                    If Date.TryParse(strDate, parseDate) AndAlso parseDate.Date <= Date.Today AndAlso Not fields(0) = "DELETED" Then
    '                        notifications.Add(fields)
    '                    End If
    '                End If
    '            End Using
    '        End While
    '    End Using
    'End Sub

    Private Sub DisplayNotification(index As Integer)
        If index >= 0 AndAlso index < notifications.Count Then
            Dim fields() As String = notifications(index)

            rtxtNotifications.Clear()
            rtxtNotifications.DetectUrls = False

            linklbl.Text = fields(0)

            Dim boldFont As New Font(rtxtNotifications.Font, FontStyle.Bold)
            Dim normalFont As New Font(rtxtNotifications.Font, FontStyle.Regular)
            Dim startPos As Integer

            ' Field 1: Client Name
            startPos = rtxtNotifications.TextLength
            rtxtNotifications.AppendText("Client Name: ")
            rtxtNotifications.Select(startPos, "Client Name: ".Length)
            rtxtNotifications.SelectionFont = boldFont
            rtxtNotifications.DeselectAll()

            startPos = rtxtNotifications.TextLength
            rtxtNotifications.AppendText(fields(1) & Environment.NewLine)
            rtxtNotifications.Select(startPos, fields(1).Length)
            rtxtNotifications.SelectionFont = normalFont
            rtxtNotifications.DeselectAll()

            ' Field 16: Date
            startPos = rtxtNotifications.TextLength
            rtxtNotifications.AppendText("Date: ")
            rtxtNotifications.Select(startPos, "Date: ".Length)
            rtxtNotifications.SelectionFont = boldFont
            rtxtNotifications.DeselectAll()

            startPos = rtxtNotifications.TextLength
            rtxtNotifications.AppendText(fields(16) & Environment.NewLine)
            rtxtNotifications.Select(startPos, fields(16).Length)
            rtxtNotifications.SelectionFont = normalFont
            rtxtNotifications.DeselectAll()

            ' Field 17: Message (red text)
            startPos = rtxtNotifications.TextLength
            rtxtNotifications.AppendText("Message: ")
            rtxtNotifications.Select(startPos, "Message: ".Length)
            rtxtNotifications.SelectionFont = boldFont
            rtxtNotifications.DeselectAll()

            startPos = rtxtNotifications.TextLength
            rtxtNotifications.AppendText(fields(17) & Environment.NewLine)
            rtxtNotifications.Select(startPos, fields(17).Length)
            rtxtNotifications.SelectionFont = normalFont
            rtxtNotifications.SelectionColor = Color.Red
            rtxtNotifications.DeselectAll()

            'Dim strMessage As String
            'For i As Integer = 0 To 17
            '    strMessage = strMessage & " *** " & fields(i)

            'Next
            'MsgBox(strMessage)

        End If
    End Sub


    Private Sub linklbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linklbl.LinkClicked
        If Not intInfoOpen = 1 Then



            If currentIndex >= 0 AndAlso currentIndex < notifications.Count Then
                Dim fields() As String = notifications(currentIndex)

                If fields.Length > 17 Then
                    For i As Integer = 0 To 17
                        strDataI(i) = fields(i)
                    Next
                End If

                'If fields.Length > 17 Then
                '    For i As Integer = 0 To 17
                '        strDataN(i) = fields(i)
                '    Next
                'End If

                'Dim frm As New frmCaptureInfo()
                blnEditInfo = True
                frmCaptureInfo.Show()


                frmCaptureInfo.cmbBoxTemplate.Text = fields(2)
                frmCaptureInfo.txt1.Text = fields(0)
                frmCaptureInfo.cmbClient.Text = fields(1)
                frmCaptureInfo.txt3.Text = fields(3)
                frmCaptureInfo.txt4.Text = fields(4)
                frmCaptureInfo.txt5.Text = fields(5)
                frmCaptureInfo.txt6.Text = fields(6)
                frmCaptureInfo.txt7.Text = fields(7)
                frmCaptureInfo.txt8.Text = fields(8)
                frmCaptureInfo.txt9.Text = fields(9)
                frmCaptureInfo.txt10.Text = fields(10)
                frmCaptureInfo.txt11.Text = fields(11)
                frmCaptureInfo.txt12.Text = fields(12)
                frmCaptureInfo.txt13.Text = fields(13)
                frmCaptureInfo.txt14.Text = fields(14)
                frmCaptureInfo.txt15.Text = fields(15)

                ' MsgBox(strDataI(1))
            End If
        End If
    End Sub



    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplayNotification(currentIndex)
        End If

    End Sub

    Private Sub frmNotifications_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        intNotiOpen = 0

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click


        Dim intNotiCount As Integer

        intNotiCount = notifications.Count

        'CountNotifications()

        rtxtNotifications.Text = ""
        linklbl.Text = ""

        ScrollNotifications("Notifications.csv")

        currentIndex = currentIndex - 1


        If intNotiCount <> notifications.Count Then

            currentIndex = -1

        End If


        btnNext.PerformClick()

    End Sub

    Private Sub tmPerformClick_Tick(sender As Object, e As EventArgs) Handles tmPerformClick.Tick
        If intInfoOpen = 1 Then blnClick = True 'Else blnClick = False

        If intInfoOpen = 0 AndAlso blnClick = True Then
            blnClick = False
            btnRefresh.PerformClick()

        End If

        If intClientOpen = 1 Then blnClick2 = True 'Else blnClick = False

        If intClientOpen = 0 AndAlso blnClick2 = True Then
            blnClick2 = False
            btnRefresh.PerformClick()

        End If

        If FileChangedFlag Then
            If Not blnNotiChange AndAlso Not blnInfoChange AndAlso Not blnClientChange Then
                btnRefresh.PerformClick()

            End If

        End If


    End Sub



End Class
