Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Diagnostics.Eventing
Imports System.IO.Compression
Imports System.Threading.Tasks
Imports System.Linq
Imports System.Collections.Concurrent
Imports System.Threading
'Imports Microsoft.VisualBasic.FileIO
Imports System.Net
Imports System.Diagnostics
Imports System.Reflection



Module ModCSV

    Private ReadOnly strDataILock As New Object()
    Public InMemoryData As New ConcurrentDictionary(Of String, List(Of String()))
    Public ReadOnly FileNames As String() = {"Notifications.csv", "Accounts.csv", "Information.csv"}
    Private watchers As New Dictionary(Of String, FileSystemWatcher)
    Public FileChangedFlag As Boolean = False

    Private ReadOnly strDataLock As New Object()


    Public Sub CSVComposer(ByVal strFile As String, ByVal intX As Integer)

        Const C = ";"
        Const Q = """"

        Dim intC As Integer
        Dim intQ As Integer
        Dim intV As Integer

        Dim intCounter As Integer = 0
        Dim strWriteData As String = Nothing
        Dim strRTrim(20) As String

        Do Until intCounter = intX
            strData(intCounter) = RTrim(strData(intCounter))
            strData(intCounter) = LTrim(strData(intCounter))
            intQ = InStr(strData(intCounter), Q)
            intC = InStr(strData(intCounter), C)
            intV = intQ + intC
            'EncryptString(strData(intCounter))
            'strData(intCounter) = EncryptString(strData(intCounter))

            If intC > 0 AndAlso intQ = 0 Then
                strData(intCounter) = Q & strData(intCounter) & Q
                Debug.WriteLine(strData(intCounter))
                intC = 0

            End If

            If intQ > 0 Then
                strData(intCounter) = Replace(strData(intCounter), Q, Q & Q)
                strData(intCounter) = Q & strData(intCounter) & Q
                Debug.WriteLine(strData(intCounter))
                intQ = 0
            End If

            If strData(intCounter).Contains(vbNewLine) AndAlso intV = 0 Then
                strData(intCounter) = Q & strData(intCounter) & Q
                Debug.WriteLine(strData(intCounter))
            End If
            Debug.WriteLine(strData(intCounter) & " " & intCounter)
            If intCounter < intX - 1 Then
                strWriteData = strWriteData & strData(intCounter) & ";"
                Debug.WriteLine(strData(intCounter))
            Else
                strWriteData = strWriteData & strData(intCounter)
                Debug.WriteLine(strData(intCounter))

            End If

            intV = 0

            intCounter = intCounter + 1

        Loop

        'My.Computer.FileSystem.CopyFile(strDatabasePath & strFile, strDatabasePath & strFile & ".bak", True)



        strWriteData = EncryptString(strWriteData)
        Dim strmWriter As New System.IO.StreamWriter(strDatabasePath & strFile, True)
        strmWriter.WriteLine(strWriteData)
        strmWriter.Close()
        strmWriter.Dispose()

        strWriteData = Nothing
        CSVClear()

    End Sub





    Private Sub CSVClear()

        Dim intCounter As Integer

        Do Until intCounter = 15

            strData(intCounter) = Nothing
            intCounter = intCounter + 1

        Loop

    End Sub

    Public Sub CSVNumberAccount(ByVal txtBoxAccount As TextBox, ByVal strFile As String)

        Dim intAccNumber As Integer = 0

        Try
            ' 🔁 Step 1: Read all lines and decrypt
            Dim decryptedLines As New List(Of String)

            Using reader As New StreamReader(strDatabasePath & strAccountsCSV)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    decryptedLines.Add(DecryptString(line))
                End While
            End Using

            ' 🧠 Step 2: Count each decrypted line
            For Each decryptedLine As String In decryptedLines
                If Not String.IsNullOrWhiteSpace(decryptedLine) Then
                    intAccNumber += 1
                End If
            Next

        Catch ex As System.IO.FileNotFoundException
            txtBoxAccount.Text = "0000001"
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim strAuto As String = (intAccNumber + 1).ToString().PadLeft(7, "0"c)
            txtBoxAccount.Text = strAuto

        Catch ex As System.IO.FileNotFoundException
            txtBoxAccount.Text = "0000001"
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Public Sub ReadCsv(
    ByVal strFile As String,
    ByVal strSearch1 As String, ByVal strSearch2 As String, ByVal strSearch3 As String,
    ByVal strSearch4 As String, ByVal strSearch5 As String, ByVal strSearch6 As String,
    ByVal strSearch7 As String, ByVal strSearch8 As String, ByVal strSearch9 As String,
    ByVal intStop As Integer, ByRef dgView As DataGridView, ByVal blnClear As Boolean)

        If blnClear Then dgView.Rows.Clear()

        Try
            If Not InMemoryData.ContainsKey(strFile) Then
                MsgBox("File not loaded in memory: " & strFile)
                Return
            End If

            Dim dataRows = InMemoryData(strFile)

            Dim matchingRows = dataRows.AsParallel().Select(Function(fields)
                                                                Try
                                                                    Dim strData(31) As String
                                                                    Dim intValue(10) As Integer
                                                                    Array.Clear(strData, 0, strData.Length)
                                                                    Array.Clear(intValue, 0, intValue.Length)

                                                                    Dim fieldCount As Integer = fields.Length

                                                                    For i As Integer = 0 To fieldCount - 1
                                                                        strData(i) = fields(i)
                                                                        If InStr(UCase(strData(i)), UCase(strSearch1)) > 0 Then intValue(0) = 1
                                                                        If String.IsNullOrEmpty(strSearch2) OrElse InStr(UCase(strData(i)), UCase(strSearch2)) > 0 Then intValue(1) = 1
                                                                        If String.IsNullOrEmpty(strSearch3) OrElse InStr(UCase(strData(i)), UCase(strSearch3)) > 0 Then intValue(2) = 1
                                                                        If String.IsNullOrEmpty(strSearch4) OrElse InStr(UCase(strData(i)), UCase(strSearch4)) > 0 Then intValue(3) = 1
                                                                        If String.IsNullOrEmpty(strSearch5) OrElse InStr(UCase(strData(i)), UCase(strSearch5)) > 0 Then intValue(4) = 1
                                                                        If String.IsNullOrEmpty(strSearch6) OrElse InStr(UCase(strData(i)), UCase(strSearch6)) > 0 Then intValue(5) = 1
                                                                        If String.IsNullOrEmpty(strSearch7) OrElse InStr(UCase(strData(i)), UCase(strSearch7)) > 0 Then intValue(6) = 1
                                                                        If String.IsNullOrEmpty(strSearch8) OrElse InStr(UCase(strData(i)), UCase(strSearch8)) > 0 Then intValue(7) = 1
                                                                        If String.IsNullOrEmpty(strSearch9) OrElse InStr(UCase(strData(i)), UCase(strSearch9)) > 0 Then intValue(8) = 1
                                                                    Next

                                                                    If intValue.Take(9).Sum() = 9 AndAlso strData(0) <> "DELETED" Then
                                                                        If fieldCount = 16 AndAlso intStop = 15 Then
                                                                            Return New With {
                            .Row = strData.Take(16).Concat({strFile}).ToArray(),
                            .Highlight = False
                        }

                                                                        ElseIf fieldCount = 14 AndAlso intStop = 13 Then
                                                                            strData(14) = ""
                                                                            strData(15) = ""
                                                                            Return New With {
                            .Row = strData.Take(16).Concat({strFile}).ToArray(),
                            .Highlight = True
                        }

                                                                        ElseIf fieldCount = 18 AndAlso intStop = 17 Then
                                                                            Dim reorderedRow = {
                            strData(0), strData(1), strData(2), strData(16), strData(17), strData(3), strData(4), strData(5), strData(6),
                            strData(7), strData(8), strData(9), strData(10), strData(11), strData(12),
                            strData(13), strData(14), strData(15), strFile
                        }
                                                                            Return New With {.Row = reorderedRow, .Highlight = False}
                                                                        End If
                                                                    End If
                                                                Catch
                                                                    ' Handle or ignore row error
                                                                End Try
                                                                Return Nothing
                                                            End Function).Where(Function(r) r IsNot Nothing).ToList()

            ' Populate DataGridView
            For Each item In matchingRows
                Dim rowIndex As Integer = dgView.Rows.Add(item.Row)
                If item.Highlight Then
                    dgView.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightCyan
                End If
            Next

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

    End Sub



    'Public Sub ReadCsv(
    'ByVal strFile As String,
    'ByVal strSearch1 As String, ByVal strSearch2 As String, ByVal strSearch3 As String,
    'ByVal strSearch4 As String, ByVal strSearch5 As String, ByVal strSearch6 As String,
    'ByVal strSearch7 As String, ByVal strSearch8 As String, ByVal strSearch9 As String,
    'ByVal intStop As Integer, ByRef dgView As DataGridView, ByVal blnClear As Boolean)

    '    If blnClear Then dgView.Rows.Clear()

    '    Try
    '        Dim filePath As String = strDatabasePath & strFile
    '        Dim encryptedLines() As String = File.ReadAllLines(filePath)

    '        ' Use a structure to carry row data + highlight flag
    '        Dim matchingRows = encryptedLines.AsParallel().Select(Function(encryptedLine)
    '                                                                  Try
    '                                                                      Dim decryptedLine As String = DecryptString(encryptedLine)
    '                                                                      Dim strData(31) As String
    '                                                                      Dim intValue(10) As Integer
    '                                                                      Array.Clear(strData, 0, strData.Length)
    '                                                                      Array.Clear(intValue, 0, intValue.Length)

    '                                                                      Using strReader As New TextFieldParser(New StringReader(decryptedLine))
    '                                                                          strReader.Delimiters = New String() {";"}
    '                                                                          strReader.HasFieldsEnclosedInQuotes = True
    '                                                                          strReader.TextFieldType = FieldType.Delimited

    '                                                                          Dim fields() As String = strReader.ReadFields()
    '                                                                          Dim fieldCount As Integer = fields.Length

    '                                                                          For i As Integer = 0 To fieldCount - 1
    '                                                                              strData(i) = fields(i)
    '                                                                              If InStr(UCase(strData(i)), UCase(strSearch1)) > 0 Then intValue(0) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch2) OrElse InStr(UCase(strData(i)), UCase(strSearch2)) > 0 Then intValue(1) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch3) OrElse InStr(UCase(strData(i)), UCase(strSearch3)) > 0 Then intValue(2) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch4) OrElse InStr(UCase(strData(i)), UCase(strSearch4)) > 0 Then intValue(3) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch5) OrElse InStr(UCase(strData(i)), UCase(strSearch5)) > 0 Then intValue(4) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch6) OrElse InStr(UCase(strData(i)), UCase(strSearch6)) > 0 Then intValue(5) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch7) OrElse InStr(UCase(strData(i)), UCase(strSearch7)) > 0 Then intValue(6) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch8) OrElse InStr(UCase(strData(i)), UCase(strSearch8)) > 0 Then intValue(7) = 1
    '                                                                              If String.IsNullOrEmpty(strSearch9) OrElse InStr(UCase(strData(i)), UCase(strSearch9)) > 0 Then intValue(8) = 1
    '                                                                          Next

    '                                                                          If intValue.Take(9).Sum() = 9 AndAlso strData(0) <> "DELETED" Then
    '                                                                              If fieldCount = 16 AndAlso intStop = 15 Then
    '                                                                                  Return New With {
    '                            .Row = strData.Take(16).Concat({filePath}).ToArray(),
    '                            .Highlight = False
    '                        }

    '                                                                              ElseIf fieldCount = 14 AndAlso intStop = 13 Then
    '                                                                                  strData(14) = ""
    '                                                                                  strData(15) = ""
    '                                                                                  Return New With {
    '                            .Row = strData.Take(16).Concat({filePath}).ToArray(),
    '                            .Highlight = True
    '                        }

    '                                                                              ElseIf fieldCount = 18 AndAlso intStop = 17 Then
    '                                                                                  Dim reorderedRow = {
    '                            strData(0), strData(1), strData(2), strData(16), strData(17), strData(3), strData(4), strData(5), strData(6),
    '                            strData(7), strData(8), strData(9), strData(10), strData(11), strData(12),
    '                            strData(13), strData(14), strData(15), filePath
    '                        }
    '                                                                                  Return New With {.Row = reorderedRow, .Highlight = False}
    '                                                                              End If
    '                                                                          End If
    '                                                                      End Using
    '                                                                  Catch
    '                                                                      ' Skip any errors silently
    '                                                                  End Try
    '                                                                  Return Nothing
    '                                                              End Function).Where(Function(r) r IsNot Nothing).ToList()

    '        ' Update the DataGridView on the UI thread
    '        For Each item In matchingRows
    '            Dim rowIndex As Integer = dgView.Rows.Add(item.Row)
    '            If item.Highlight Then
    '                dgView.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightCyan
    '            End If
    '        Next

    '    Catch ex As Exception
    '        MsgBox("Error: " & ex.Message)
    '    End Try

    'End Sub



    'Public Sub ReadCsv(ByVal strFile As String, ByVal strSearch1 As String, ByVal strSearch2 As String, ByVal strSearch3 As String, ByVal strSearch4 As String, ByVal strSearch5 As String, ByVal strSearch6 As String, ByVal strSearch7 As String, ByVal strSearch8 As String, ByVal strSearch9 As String, ByVal intStop As Integer, ByRef dgView As DataGridView, ByVal blnClear As Boolean)

    '    If blnClear Then dgView.Rows.Clear()

    '    Dim intc As Integer = 0

    '    Try
    '        Using reader As New StreamReader(strDatabasePath & strFile)
    '            While Not reader.EndOfStream
    '                Dim decryptedLine As String = DecryptString(reader.ReadLine())
    '                Dim intValue(10) As Integer
    '                Dim strData(31) As String ' Support up to 32 fields
    '                Array.Clear(intValue, 0, intValue.Length)

    '                Using strReader As New TextFieldParser(New StringReader(decryptedLine))
    '                    strReader.Delimiters = New String() {";"}
    '                    strReader.HasFieldsEnclosedInQuotes = True
    '                    strReader.TextFieldType = FieldType.Delimited

    '                    Dim fields() As String = strReader.ReadFields()
    '                    Dim fieldCount As Integer = fields.Length

    '                    For i As Integer = 0 To fieldCount - 1
    '                        strData(i) = fields(i)

    '                        If InStr(UCase(strData(i)), UCase(strSearch1)) > 0 Then intValue(0) = 1
    '                        If String.IsNullOrEmpty(strSearch2) OrElse InStr(UCase(strData(i)), UCase(strSearch2)) > 0 Then intValue(1) = 1
    '                        If String.IsNullOrEmpty(strSearch3) OrElse InStr(UCase(strData(i)), UCase(strSearch3)) > 0 Then intValue(2) = 1
    '                        If String.IsNullOrEmpty(strSearch4) OrElse InStr(UCase(strData(i)), UCase(strSearch4)) > 0 Then intValue(3) = 1
    '                        If String.IsNullOrEmpty(strSearch5) OrElse InStr(UCase(strData(i)), UCase(strSearch5)) > 0 Then intValue(4) = 1
    '                        If String.IsNullOrEmpty(strSearch6) OrElse InStr(UCase(strData(i)), UCase(strSearch6)) > 0 Then intValue(5) = 1
    '                        If String.IsNullOrEmpty(strSearch7) OrElse InStr(UCase(strData(i)), UCase(strSearch7)) > 0 Then intValue(6) = 1
    '                        If String.IsNullOrEmpty(strSearch8) OrElse InStr(UCase(strData(i)), UCase(strSearch8)) > 0 Then intValue(7) = 1
    '                        If String.IsNullOrEmpty(strSearch9) OrElse InStr(UCase(strData(i)), UCase(strSearch9)) > 0 Then intValue(8) = 1
    '                    Next

    '                    If intValue.Take(9).Sum() = 9 AndAlso Not strData(0) = "DELETED" Then
    '                        If fieldCount = 16 AndAlso intStop = 15 Then
    '                            dgView.Rows.Add(strData(0), strData(1), strData(2), strData(3), strData(4), strData(5), strData(6),
    '                                            strData(7), strData(8), strData(9), strData(10), strData(11), strData(12),
    '                                            strData(13), strData(14), strData(15), strDatabasePath & strFile)
    '                        End If

    '                        If fieldCount = 14 AndAlso intStop = 13 Then
    '                            strData(14) = ""
    '                            strData(15) = ""
    '                            dgView.Rows.Add(strData(0), strData(1), strData(2), strData(3), strData(4), strData(5), strData(6),
    '                                            strData(7), strData(8), strData(9), strData(10), strData(11), strData(12),
    '                                            strData(13), strData(14), strData(15), strDatabasePath & strFile)

    '                            Dim j As Integer = dgView.Rows.Count
    '                            dgView.Rows(j - 1).DefaultCellStyle.BackColor = Color.LightCyan
    '                        End If

    '                        If fieldCount = 18 AndAlso intStop = 17 Then
    '                            dgView.Rows.Add(strData(0), strData(1), strData(2), strData(16), strData(17), strData(3), strData(4), strData(5), strData(6),
    '                                            strData(7), strData(8), strData(9), strData(10), strData(11), strData(12),
    '                                            strData(13), strData(14), strData(15), strDatabasePath & strFile)
    '                        End If

    '                    End If

    '                    intc += 1
    '                    Debug.WriteLine("Line " & intc & " processed.")
    '                End Using
    '            End While
    '        End Using
    '    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
    '        MsgBox("Line error: " & ex.Message & " — line will be skipped.")
    '    Catch ex As Exception
    '        MsgBox("Unexpected error: " & ex.Message)
    '    End Try


    'End Sub



    Public Sub EditCSV()


    End Sub

    Public Sub CSVTemplate(ByVal strFile As String, ByVal strCMBValue As String, ByVal strForm As String)

        Dim blnAdd As Boolean = False

        Using reader As New StreamReader(strDatabasePath & strFile)

            While Not reader.EndOfStream
                ' 🔐 Decrypt each line
                Dim decryptedLine As String = DecryptString(reader.ReadLine())

                ' 🧾 Use TextFieldParser for correct CSV parsing (including quoted fields)
                Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                    strReader.Delimiters = New String() {";"}
                    strReader.HasFieldsEnclosedInQuotes = True
                    strReader.TextFieldType = FieldType.Delimited

                    Dim fields() As String = strReader.ReadFields()

                    ' ✅ Optional: Check for expected column count
                    If fields.Length > 0 AndAlso strForm = "CaptureInfo" Then

                        ' You can change index if needed
                        'MsgBox(fields(2))
                        Dim intStr As Integer
                        intStr = InStr(UCase(fields(0)), UCase(strCMBValue))

                        If intStr > 0 Then
                            frmCaptureInfo.lbl3.Text = UCase(fields(3))
                            frmCaptureInfo.lbl4.Text = UCase(fields(4))
                            frmCaptureInfo.lbl5.Text = UCase(fields(5))
                            frmCaptureInfo.lbl6.Text = UCase(fields(6))
                            frmCaptureInfo.lbl7.Text = UCase(fields(7))
                            frmCaptureInfo.lbl8.Text = UCase(fields(8))
                            frmCaptureInfo.lbl9.Text = UCase(fields(9))
                            frmCaptureInfo.lbl10.Text = UCase(fields(10))
                            frmCaptureInfo.lbl11.Text = UCase(fields(11))
                            frmCaptureInfo.lbl12.Text = UCase(fields(12))
                            frmCaptureInfo.lbl13.Text = UCase(fields(13))
                            frmCaptureInfo.lbl14.Text = UCase(fields(14))

                            If fields(1) > "" Then frmCaptureInfo.txt1.Enabled = True 'Else frmCaptureInfo.txt1.Visible = False
                            If fields(2) > "" Then frmCaptureInfo.cmbClient.Enabled = True 'Else frmCaptureInfo.txt2.Visible = False
                            If fields(3) > "" Then frmCaptureInfo.txt3.Enabled = True Else frmCaptureInfo.txt3.Visible = False
                            If fields(4) > "" Then frmCaptureInfo.txt4.Enabled = True Else frmCaptureInfo.txt4.Visible = False
                            If fields(5) > "" Then frmCaptureInfo.txt5.Enabled = True Else frmCaptureInfo.txt5.Visible = False
                            If fields(6) > "" Then frmCaptureInfo.txt6.Enabled = True Else frmCaptureInfo.txt6.Visible = False
                            If fields(7) > "" Then frmCaptureInfo.txt7.Enabled = True Else frmCaptureInfo.txt7.Visible = False
                            If fields(8) > "" Then frmCaptureInfo.txt8.Enabled = True Else frmCaptureInfo.txt8.Visible = False
                            If fields(9) > "" Then frmCaptureInfo.txt9.Enabled = True Else frmCaptureInfo.txt9.Visible = False
                            If fields(10) > "" Then frmCaptureInfo.txt10.Enabled = True Else frmCaptureInfo.txt10.Visible = False
                            If fields(11) > "" Then frmCaptureInfo.txt11.Enabled = True Else frmCaptureInfo.txt11.Visible = False
                            If fields(12) > "" Then frmCaptureInfo.txt12.Enabled = True Else frmCaptureInfo.txt12.Visible = False
                            If fields(13) > "" Then frmCaptureInfo.txt13.Enabled = True Else frmCaptureInfo.txt13.Visible = False
                            If fields(14) > "" Then frmCaptureInfo.txt14.Enabled = True Else frmCaptureInfo.txt14.Visible = False
                            If UCase(fields(15)) = UCase("True") Then frmCaptureInfo.txt15.Enabled = True Else frmCaptureInfo.txt15.Enabled = False

                        End If

                    ElseIf fields.Length > 0 AndAlso strForm = "EditTemplate" Then

                        Dim intStr As Integer
                        intStr = InStr(UCase(fields(0)), UCase(strCMBValue))

                        If intStr > 0 Then
                            FrmEditTemplate.txtField3.Text = fields(3)
                            FrmEditTemplate.txtField4.Text = fields(4)
                            FrmEditTemplate.txtField5.Text = fields(5)
                            FrmEditTemplate.txtField6.Text = fields(6)
                            FrmEditTemplate.txtField7.Text = fields(7)
                            FrmEditTemplate.txtField8.Text = fields(8)
                            FrmEditTemplate.txtField9.Text = fields(9)
                            FrmEditTemplate.txtField10.Text = fields(10)
                            FrmEditTemplate.txtField11.Text = fields(11)
                            FrmEditTemplate.txtField12.Text = fields(12)
                            FrmEditTemplate.txtField13.Text = fields(13)
                            FrmEditTemplate.txtField14.Text = UCase(fields(14))
                            'FrmEditTemplate.txtField14.Text = UCase(fields(15))

                            If UCase(fields(15)) = UCase("True") Then FrmEditTemplate.chkNotes.Checked = True Else FrmEditTemplate.chkNotes.Checked = False
                        End If

                    End If
                End Using
            End While
        End Using

        'Dim intCounter As Integer
        'Dim strReader As New TextFieldParser(strDatabasePath & strFile)
        'strReader.Delimiters = New String() {";"}
        'strReader.TextFieldType = FieldType.Delimited
        'Dim blnAdd As Boolean = False

        'Dim strRow As String()

        'While Not strReader.EndOfData

        '    Try
        '        strRow = strReader.ReadFields()
        '        Dim strField As String

        '        For Each strField In strRow
        '            strField = DecryptString(strField)

        '            Dim intStr As Integer
        '            strData(intCounter) = strField

        '            If intCounter = 0 Then
        '                intStr = InStr(UCase(strField), UCase(strCMBValue))
        '            End If

        '            If intStr > 0 Then
        '                blnAdd = True
        '            End If

        '            If intCounter = 15 AndAlso blnAdd = True Then


        '                frmCaptureInfo.lbl3.Text = UCase(strData(3))
        '                frmCaptureInfo.lbl4.Text = UCase(strData(4))
        '                frmCaptureInfo.lbl5.Text = UCase(strData(5))
        '                frmCaptureInfo.lbl6.Text = UCase(strData(6))
        '                frmCaptureInfo.lbl7.Text = UCase(strData(7))
        '                frmCaptureInfo.lbl8.Text = UCase(strData(8))
        '                frmCaptureInfo.lbl9.Text = UCase(strData(9))
        '                frmCaptureInfo.lbl10.Text = UCase(strData(10))
        '                frmCaptureInfo.lbl11.Text = UCase(strData(11))
        '                frmCaptureInfo.lbl12.Text = UCase(strData(12))
        '                frmCaptureInfo.lbl13.Text = UCase(strData(13))
        '                frmCaptureInfo.lbl14.Text = UCase(strData(14))

        '                If strData(1) > "" Then frmCaptureInfo.txt1.Enabled = True 'Else frmCaptureInfo.txt1.Visible = False
        '                If strData(2) > "" Then frmCaptureInfo.cmbClient.Enabled = True 'Else frmCaptureInfo.txt2.Visible = False
        '                If strData(3) > "" Then frmCaptureInfo.txt3.Enabled = True Else frmCaptureInfo.txt3.Visible = False
        '                If strData(4) > "" Then frmCaptureInfo.txt4.Enabled = True Else frmCaptureInfo.txt4.Visible = False
        '                If strData(5) > "" Then frmCaptureInfo.txt5.Enabled = True Else frmCaptureInfo.txt5.Visible = False
        '                If strData(6) > "" Then frmCaptureInfo.txt6.Enabled = True Else frmCaptureInfo.txt6.Visible = False
        '                If strData(7) > "" Then frmCaptureInfo.txt7.Enabled = True Else frmCaptureInfo.txt7.Visible = False
        '                If strData(8) > "" Then frmCaptureInfo.txt8.Enabled = True Else frmCaptureInfo.txt8.Visible = False
        '                If strData(9) > "" Then frmCaptureInfo.txt9.Enabled = True Else frmCaptureInfo.txt9.Visible = False
        '                If strData(10) > "" Then frmCaptureInfo.txt10.Enabled = True Else frmCaptureInfo.txt10.Visible = False
        '                If strData(11) > "" Then frmCaptureInfo.txt11.Enabled = True Else frmCaptureInfo.txt11.Visible = False
        '                If strData(12) > "" Then frmCaptureInfo.txt12.Enabled = True Else frmCaptureInfo.txt12.Visible = False
        '                If strData(13) > "" Then frmCaptureInfo.txt13.Enabled = True Else frmCaptureInfo.txt13.Visible = False
        '                If strData(14) > "" Then frmCaptureInfo.txt14.Enabled = True Else frmCaptureInfo.txt14.Visible = False
        '                If UCase(strData(15)) = UCase("True") Then frmCaptureInfo.txt15.Enabled = True Else frmCaptureInfo.txt15.Enabled = False

        '                Exit Sub

        '            End If

        '            intCounter = intCounter + 1

        '            If intCounter > 15 Then
        '                intCounter = 0
        '                blnAdd = False
        '            End If


        '        Next
        '    Catch ex As Microsoft.VisualBasic.
        '        FileIO.MalformedLineException
        '        MsgBox("Line " & ex.Message &
        '"is not valid and will be skipped.")
        '    End Try

        'End While

    End Sub

    Public Sub LoadCSVTemplate(ByVal strFile As String, ByRef cmbBoxTemp As ComboBox)

        Using reader As New StreamReader(strDatabasePath & strFile)

            While Not reader.EndOfStream
                ' 🔐 Decrypt each line
                Dim decryptedLine As String = DecryptString(reader.ReadLine())

                ' 🧾 Use TextFieldParser for correct CSV parsing (including quoted fields)
                Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                    strReader.Delimiters = New String() {";"}
                    strReader.HasFieldsEnclosedInQuotes = True
                    strReader.TextFieldType = FieldType.Delimited

                    Dim fields() As String = strReader.ReadFields()

                    ' ✅ Optional: Check for expected column count
                    If fields.Length > 0 Then
                        cmbBoxTemp.Items.Add(fields(0)) ' You can change index if needed
                    End If

                    'If fields.Length > 0 AndAlso Not UCase(fields(0)) = "DELETED" Then
                    '    cmbBoxTemp.Items.Add(fields(1)) ' You can change index if needed
                    'End If

                End Using
            End While
        End Using

    End Sub

    'Public Sub ReadCSVCombo(ByVal strFile As String, ByRef cmbClientInfo As ComboBox)

    '    Using reader As New StreamReader(strDatabasePath & strFile)

    '        While Not reader.EndOfStream
    '            ' 🔐 Decrypt each line
    '            Dim decryptedLine As String = DecryptString(reader.ReadLine())

    '            ' 🧾 Use TextFieldParser for correct CSV parsing (including quoted fields)
    '            Using strReader As New TextFieldParser(New StringReader(decryptedLine))
    '                strReader.Delimiters = New String() {";"}
    '                strReader.HasFieldsEnclosedInQuotes = True
    '                strReader.TextFieldType = FieldType.Delimited

    '                Dim fields() As String = strReader.ReadFields()

    '                ' ✅ Optional: Check for expected column count
    '                If fields.Length > 0 AndAlso Not UCase(fields(0)) = "DELETED" Then
    '                    cmbClientInfo.Items.Add(fields(1)) ' You can change index if needed
    '                End If

    '            End Using
    '        End While
    '    End Using

    Public Sub ReadCSVCombo(strFile As String, cmbClientInfo As ComboBox)
        If Not InMemoryData.ContainsKey(strFile) Then
            MsgBox("File not loaded in memory: " & strFile)
            Return
        End If

        Dim dataRows As List(Of String()) = InMemoryData(strFile)
        Dim clientItems As New ConcurrentBag(Of String)

        ' 🔄 Parallel loop through in-memory rows
        Parallel.ForEach(dataRows, Sub(fields)
                                       Try
                                           If fields.Length > 1 AndAlso UCase(fields(0)) <> "DELETED" Then
                                               clientItems.Add(fields(1))
                                           End If
                                       Catch ex As Exception
                                           ' Optional: ignore or log malformed rows
                                       End Try
                                   End Sub)

        ' 👇 Update ComboBox safely on the UI thread
        If cmbClientInfo.InvokeRequired Then
            cmbClientInfo.Invoke(Sub()
                                     cmbClientInfo.Items.AddRange(clientItems.Distinct().ToArray())
                                 End Sub)
        Else
            cmbClientInfo.Items.AddRange(clientItems.Distinct().ToArray())
        End If
    End Sub


    Public Sub ReadNotifications(strFile As String, blnCompare As Boolean, ByRef intCounter As Integer)
        Dim counter As Integer = 0
        Dim matchedData(17) As String
        Dim matchedFound As Boolean = False

        ' ✅ Check if in-memory data exists
        If Not InMemoryData.ContainsKey(strFile) Then Exit Sub

        Dim localLock As Object = strDataLock

        Parallel.ForEach(InMemoryData(strFile), Sub(fields)
                                                    Try
                                                        If fields Is Nothing OrElse fields.Length <= 17 Then Return

                                                        ' 🧪 Use a local buffer to avoid writing to shared strDataN
                                                        Dim localFields(17) As String
                                                        Array.Copy(fields, localFields, 18)

                                                        Dim localMatch As Boolean = False

                                                        ' 🔒 Lock only around comparison with strDataI and global counter
                                                        SyncLock localLock
                                                            If blnCompare Then
                                                                localMatch = True
                                                                For i As Integer = 0 To 15
                                                                    If localFields(i) <> strDataI(i) Then
                                                                        localMatch = False
                                                                        Exit For
                                                                    End If
                                                                Next

                                                                If localMatch Then
                                                                    blnUpdateNotify = True
                                                                    matchedFound = True
                                                                    Array.Copy(localFields, matchedData, 18) ' store safe copy for later
                                                                End If
                                                            End If

                                                            ' ✅ Check date and deletion status
                                                            Dim strDate As String = localFields(16).Trim()
                                                            Dim parseDate As Date
                                                            If Date.TryParse(strDate, parseDate) Then
                                                                If parseDate.Date <= Date.Today AndAlso Not localFields(0).ToUpper() = "DELETED" Then
                                                                    Interlocked.Increment(counter)
                                                                End If
                                                            End If
                                                        End SyncLock

                                                    Catch ex As Exception
                                                        Debug.WriteLine("Error in memory loop: " & ex.Message)
                                                    End Try
                                                End Sub)

        intCounter = counter

        ' ✅ Apply the matched result outside parallel block, safely
        If matchedFound Then
            Array.Copy(matchedData, strDataN, 18)
            strData(16) = matchedData(16)
            strData(17) = matchedData(17)
            ' MsgBox(strDataN(16) & " *** Hellooo")
        End If
    End Sub



    Public Sub CountNotifications()

        If My.Computer.FileSystem.FileExists(strDatabasePath & strNotificationsPath) Then
            Dim intCounter As Integer
            With Main.btnNotifications
                ReadNotifications("Notifications.csv", False, intCounter)
                '.Image = My.Resources.MyImage ' Replace with your actual image resource
                .Text = "(" & intCounter & ")"
                .ForeColor = Color.Red ' Set text color to red
                .Font = New Font(.Font, FontStyle.Bold) ' Make the text bold
                .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                .TextImageRelation = TextImageRelation.TextBeforeImage
            End With
        End If

    End Sub


    Public Sub ACCCaptureInfo(ByRef txtBoxAccount As TextBox, ByVal intComboValue As String)

        Using reader As New StreamReader(strDatabasePath & strAccountsCSV)

            While Not reader.EndOfStream
                ' 🔐 Decrypt each line
                Dim decryptedLine As String = DecryptString(reader.ReadLine())

                ' 🧾 Use TextFieldParser for correct CSV parsing (including quoted fields)
                Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                    strReader.Delimiters = New String() {";"}
                    strReader.HasFieldsEnclosedInQuotes = True
                    strReader.TextFieldType = FieldType.Delimited

                    Dim fields() As String = strReader.ReadFields()

                    ' ✅ Optional: Check for expected column count
                    If fields.Length > 0 Then
                        If intComboValue = fields(1) AndAlso Not fields(0) = "DELETED" Then ' You can change index if needed
                            txtBoxAccount.Text = fields(0)
                        End If

                    End If

                End Using
            End While
        End Using

    End Sub

    Public Sub CSVUPdate(ByVal strfile As String, ByVal intX As Integer, ByVal strForm As String)

        ' Read original encrypted data
        Dim strDatabaseRead As String
        Using strReader As New StreamReader(strDatabasePath & strfile)
            strDatabaseRead = strReader.ReadToEnd()
        End Using

        ' Assume strData and strDataP are declared globally or passed in
        ' If not, they should be parameters or declared locally
        ' Example: Dim strData(intX - 1) As String, strDataP(intX - 1) As String

        Const C = ";"
        Const Q = """"

        Dim strWriteData As String = ""
        Dim strWriteDataP As String = ""
        Dim intCounter As Integer = 0

        ' Helper function to escape a CSV field
        Dim EscapeField As Func(Of String, String) = Function(value As String) As String

                                                         Dim needsQuotes = value.Contains(C) OrElse value.Contains(Q) OrElse value.Contains(vbNewLine)
                                                         If value.Contains(Q) Then value = value.Replace(Q, Q & Q)
                                                         If needsQuotes Then value = Q & value & Q

                                                         Return value

                                                     End Function

        ' Encode previous and new row
        While intCounter < intX

            If strForm = "ClientAccount" Then strWriteDataP &= EscapeField(strDataP(intCounter))
            If strForm = "Template" Then strWriteDataP &= EscapeField(strDataT(intCounter))
            If strForm = "ClientInfo" Then strWriteDataP &= EscapeField(strDataI(intCounter))
            If strForm = "Notification" Then strWriteDataP &= EscapeField(strDataN(intCounter))



            strWriteData &= EscapeField(strData(intCounter))


            If intCounter < intX - 1 Then
                strWriteDataP &= ";"
                strWriteData &= ";"
            End If

            intCounter += 1
        End While


        ' Encrypt updated and original line
        ' MsgBox(strWriteDataP)

        'MsgBox(strWriteDataP)
        'MsgBox(strWriteData)
        Dim encryptedOld = EncryptString(strWriteDataP)
        Dim encryptedNew = EncryptString(strWriteData)
        ' MsgBox(encryptedOld)
        ' Replace and write updated file
        strDatabaseRead = strDatabaseRead.Replace(encryptedOld, encryptedNew)

        ' Backup file
        'My.Computer.FileSystem.CopyFile(strDatabasePath & strfile, strDatabasePath & strfile & ".bak", True)

        ' Save updated content
        Using strWriter As New StreamWriter(strDatabasePath & strfile, False)
            strWriter.Write(strDatabaseRead)
            strWriter.Close()
            strWriter.Dispose()
        End Using


    End Sub

    Public Sub CSVDeleteAll(ByVal strDeleteValue As String)

        ' 🔁 Step 1: Read all lines and decrypt
        Dim decryptedLines As New List(Of String)

        Using reader As New StreamReader(strDatabasePath & strInfoCsv)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                decryptedLines.Add(DecryptString(line))
            End While
        End Using

        ' 🧠 Step 2: Now process each decrypted line
        For Each decryptedLine As String In decryptedLines
            Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                strReader.Delimiters = New String() {";"}
                strReader.HasFieldsEnclosedInQuotes = True
                strReader.TextFieldType = FieldType.Delimited

                Dim fields() As String = strReader.ReadFields()
                Dim fieldCount As Integer = fields.Length
                'Dim intco As Integer
                If fields.Length > 0 Then
                    For i As Integer = 0 To fieldCount - 1
                        strData(i) = fields(i)
                        strDataI(i) = fields(i)

                    Next

                    ' 🔍 Check delete condition **after full field processing**
                    If strDataI(0) = strDeleteValue Then
                        strData(0) = "DELETED"

                        CSVUPdate(strInfoCsv, 16, "ClientInfo")
                    End If
                End If
            End Using
        Next



    End Sub

    Public Sub CSVDeleteNoti(ByVal strDeleteValue As String)

        ' 🔁 Step 1: Read all lines and decrypt
        Dim decryptedLines As New List(Of String)

        Using reader As New StreamReader(strDatabasePath & strNotificationsPath)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                decryptedLines.Add(DecryptString(line))
            End While
        End Using

        ' 🧠 Step 2: Now process each decrypted line
        For Each decryptedLine As String In decryptedLines
            Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                strReader.Delimiters = New String() {";"}
                strReader.HasFieldsEnclosedInQuotes = True
                strReader.TextFieldType = FieldType.Delimited

                Dim fields() As String = strReader.ReadFields()
                Dim fieldCount As Integer = fields.Length
                'Dim intco As Integer
                If fields.Length > 0 Then
                    For i As Integer = 0 To fieldCount - 1
                        strData(i) = fields(i)
                        strDataN(i) = fields(i)

                    Next

                    ' 🔍 Check delete condition **after full field processing**
                    If strDataN(0) = strDeleteValue Then
                        strData(0) = "DELETED"

                        CSVUPdate(strNotificationsPath, 18, "Notification")
                    End If
                End If
            End Using
        Next

    End Sub

    Public Sub CSVUpdateName(ByVal strUpdateName As String, ByVal strAccountNo As String)

        ' 🔁 Step 1: Read all lines and decrypt
        Dim decryptedLines As New List(Of String)

        Using reader As New StreamReader(strDatabasePath & strInfoCsv)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                decryptedLines.Add(DecryptString(line))
            End While
        End Using

        ' 🧠 Step 2: Now process each decrypted line
        For Each decryptedLine As String In decryptedLines
            Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                strReader.Delimiters = New String() {";"}
                strReader.HasFieldsEnclosedInQuotes = True
                strReader.TextFieldType = FieldType.Delimited

                Dim fields() As String = strReader.ReadFields()
                Dim fieldCount As Integer = fields.Length
                'Dim intco As Integer
                If fields.Length > 0 Then
                    For i As Integer = 0 To fieldCount - 1
                        strData(i) = fields(i)
                        strDataI(i) = fields(i)



                    Next

                    ' 🔍 Check delete condition **after full field processing**
                    If strDataI(0) = strAccountNo Then
                        strData(1) = strUpdateName
                        CSVUPdate(strInfoCsv, 16, "ClientInfo")

                    End If
                End If
            End Using
        Next

    End Sub

    Public Sub CSVUpdateNoti(ByVal strUpdateName As String, ByVal strAccountNo As String)

        ' 🔁 Step 1: Read all lines and decrypt
        Dim decryptedLines As New List(Of String)

        Using reader As New StreamReader(strDatabasePath & strNotificationsPath)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                decryptedLines.Add(DecryptString(line))
            End While
        End Using

        ' 🧠 Step 2: Now process each decrypted line
        For Each decryptedLine As String In decryptedLines
            Using strReader As New TextFieldParser(New StringReader(decryptedLine))
                strReader.Delimiters = New String() {";"}
                strReader.HasFieldsEnclosedInQuotes = True
                strReader.TextFieldType = FieldType.Delimited

                Dim fields() As String = strReader.ReadFields()
                Dim fieldCount As Integer = fields.Length
                'Dim intco As Integer
                If fields.Length > 0 Then
                    For i As Integer = 0 To fieldCount - 1
                        strData(i) = fields(i)
                        strDataN(i) = fields(i)



                    Next

                    ' 🔍 Check delete condition **after full field processing**
                    If strDataN(0) = strAccountNo Then
                        strData(1) = strUpdateName
                        CSVUPdate(strNotificationsPath, 18, "Notification")

                    End If
                End If
            End Using
        Next

    End Sub


    Public Sub ImportReadCsv(ByVal strFile As String, ByVal intStop As Integer, ByRef dgview As DataGridView)
        dgview.Rows.Clear()

        Dim strReader As New TextFieldParser(strFile)
        strReader.Delimiters = New String() {";"}
        strReader.TextFieldType = FieldType.Delimited

        Dim intAccValue As Integer = 0
        Dim strRow As String()
        Dim totalRowsImported As Integer = 0
        Dim deletedLinesSkipped As Integer = 0
        Dim malformedLinesSkipped As Integer = 0
        Dim duplicateLinesSkipped As Integer = 0

        Dim importedRows As HashSet(Of String) = Nothing
        If intStop <> 13 Then importedRows = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        ' Ensure DataGridView has correct number of columns
        dgview.ColumnCount = intStop + 1

        CSVImportAccount(intAccValue, strAccountsCSV)

        While Not strReader.EndOfData
            Try
                strRow = strReader.ReadFields()

                If strRow Is Nothing OrElse strRow.Length = 0 Then
                    If intStop = 13 Then
                        malformedLinesSkipped += 1
                        dgview.Rows.Add(CreatePlaceholderRow(intAccValue, intStop + 1))
                        totalRowsImported += 1
                        intAccValue += 1
                    End If
                    Continue While
                End If

                If strRow.Length < intStop + 1 Then
                    If intStop = 13 Then
                        malformedLinesSkipped += 1
                        dgview.Rows.Add(CreatePlaceholderRow(intAccValue, intStop + 1))
                        totalRowsImported += 1
                        intAccValue += 1
                    End If
                    Continue While
                End If

                Dim fullRowString As String = String.Join(";", strRow.Select(Function(f) f.Trim()))

                If intStop <> 13 Then
                    If importedRows.Contains(fullRowString) Then
                        duplicateLinesSkipped += 1
                        Continue While
                    End If

                    If UCase(strRow(0).Trim()) = "DELETED" Then
                        deletedLinesSkipped += 1
                        Continue While
                    End If
                End If

                ' Resize and add row
                If strRow.Length < (intStop + 1) Then Array.Resize(strRow, intStop + 1)
                dgview.Rows.Add(strRow.Take(intStop + 1).ToArray())

                If intStop <> 13 Then importedRows.Add(fullRowString)

                totalRowsImported += 1
                intAccValue += 1

            Catch ex As MalformedLineException
                malformedLinesSkipped += 1
                If intStop = 13 Then
                    dgview.Rows.Add(CreatePlaceholderRow(intAccValue, intStop + 1))
                    totalRowsImported += 1
                    intAccValue += 1
                End If
            End Try
        End While

        strReader.Close()

        MessageBox.Show($"CSV Import Complete." & vbCrLf &
                $"✔ Rows Imported: {totalRowsImported}" & vbCrLf &
                $"✖ Deleted Rows Skipped: {deletedLinesSkipped}" & vbCrLf &
                $"⚠ Malformed Lines {(If(intStop = 13, "Replaced", "Skipped"))}: {malformedLinesSkipped}" & vbCrLf &
                $"🔁 Duplicate Rows Skipped: {duplicateLinesSkipped}",
                "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub





    Private Function CreatePlaceholderRow(index As Integer, columnCount As Integer) As Object()
        Dim row(columnCount - 1) As Object
        row(0) = "PLACEHOLDER_" & index
        For i As Integer = 1 To columnCount - 1
            row(i) = ""
        Next
        Return row
    End Function


    Public Sub CSVImportAccount(ByRef intValue As Integer, ByVal strFile As String)
        Try
            Dim strReader As New TextFieldParser(strDatabasePath & strFile)
            strReader.Delimiters = New String() {";"}
            strReader.TextFieldType = FieldType.Delimited

            Dim strRow As String()
            Dim strField As String
            Dim intAccNumber As Integer
            Dim intCounter As Integer

            While Not strReader.EndOfData

                Try
                    strRow = strReader.ReadFields()
                    For Each strField In strRow

                        intCounter = intCounter + 1

                        If intCounter = 14 Then
                            intAccNumber = intAccNumber + 1
                            intCounter = 0

                        End If

                    Next

                Catch ex As System.IO.FileNotFoundException
                    intValue = 1

                Catch ex As Exception

                    MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End While



            intValue = intAccNumber + 1


        Catch ex As System.IO.FileNotFoundException
            intValue = 1

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Public Sub ImportCSVACCNo(ByVal intAccountNo As Integer, ByRef strAccounNo As String)
        Dim intValue As String
        Dim strAuto As String
        Dim intRepairFill As Integer

        intValue = intAccountNo
        strAuto = intValue

        intRepairFill = Microsoft.VisualBasic.Len(strAuto)

        If intRepairFill > 0 Then
            strAuto = Microsoft.VisualBasic.Left(strAuto, intRepairFill)
            If intRepairFill < 7 Then
                Do Until intRepairFill = 7
                    intRepairFill = intRepairFill + 1
                    strAuto = "0" & strAuto
                Loop
                strAccounNo = strAuto
            End If
        End If

    End Sub

    Public Sub SaveImport(ByVal dgImport As DataGridView, ByVal intX As Integer, ByVal strFile As String)
        Dim fullPath As String = strDatabasePath & strFile
        'My.Computer.FileSystem.CopyFile(fullPath, fullPath & ".bak", True)

        Const DELIM = ";"
        Const QUOTE = """"
        Dim sb As New System.Text.StringBuilder()

        ' Loop through each row in the DataGridView
        For Each dgRow As DataGridViewRow In dgImport.Rows
            If dgRow.IsNewRow Then Continue For ' skip empty new row at the end

            Dim rowValues As New List(Of String)

            For colIndex As Integer = 0 To intX - 1
                Dim rawValue As String = If(dgRow.Cells(colIndex).Value, "").ToString().Trim()

                ' Escape quotes and wrap in quotes if needed
                Dim needsQuotes As Boolean = rawValue.Contains(DELIM) OrElse rawValue.Contains(QUOTE) OrElse rawValue.Contains(vbNewLine)
                If rawValue.Contains(QUOTE) Then
                    rawValue = rawValue.Replace(QUOTE, QUOTE & QUOTE)
                    needsQuotes = True
                End If

                If needsQuotes Then
                    rawValue = QUOTE & rawValue & QUOTE
                End If

                rowValues.Add(rawValue)
            Next

            ' Join fields and encrypt line
            Dim composedLine As String = String.Join(DELIM, rowValues)
            composedLine = EncryptString(composedLine)

            sb.AppendLine(composedLine)
        Next

        ' Write all lines at once to the file
        System.IO.File.WriteAllText(fullPath, sb.ToString())

    End Sub

    Public Sub CopyNameFile(ByVal StrFilePath As String, ByVal strAccountNo As String)

        Dim strFileName As String = Path.GetFileName(StrFilePath)
        Dim strCopypath As String
        Dim strCreateDirectory As String
        strCreateDirectory = strDatabasePath & "\" & strAccountNo
        strCopypath = strDatabasePath & "\" & strAccountNo & "\" & strFileName
        Try
            If Not My.Computer.FileSystem.DirectoryExists(strCreateDirectory) Then
                My.Computer.FileSystem.CreateDirectory(strCreateDirectory)
            End If

            If My.Computer.FileSystem.FileExists(strCopypath) = True Then
                If MessageBox.Show("The file exists, do you want to overwrite it", "Overwrite File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    My.Computer.FileSystem.CopyFile(StrFilePath, strCopypath, True)
                End If
            Else
                My.Computer.FileSystem.CopyFile(StrFilePath, strCopypath)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ShowAttached(ByVal strAccountNo As String, ByRef lvReturn As ListView, ByRef imgList As ImageList)
        Try




            Dim dirInfo As New System.IO.DirectoryInfo(strDatabasePath & "\" & strAccountNo)
            Dim lvItem As ListViewItem
            lvReturn.BeginUpdate()
            lvReturn.Items.Clear()
            Dim dirFile As System.IO.FileInfo
            For Each dirFile In dirInfo.GetFiles

                Dim iFileIcon As Icon = SystemIcons.WinLogo
                lvItem = New ListViewItem(dirFile.Name, 1)
                If Not (imgList.Images.ContainsKey(dirFile.Extension)) Then
                    iFileIcon = System.Drawing.Icon.ExtractAssociatedIcon(dirFile.FullName)
                    imgList.Images.Add(dirFile.Extension, iFileIcon)
                End If

                lvItem.ImageKey = dirFile.Extension

                lvReturn.Items.Add(lvItem)

                'End If

            Next dirFile

            lvReturn.EndUpdate()

        Catch ex As Exception

        End Try

    End Sub


    Public Sub ReadCsvFilter(ByVal strFile As String, ByVal strSearch1 As String, ByVal strSearch2 As String, ByVal strSearch3 As String, ByVal strSearch4 As String, ByVal intStop As Integer, ByRef dgView As DataGridView, ByVal blnClear As Boolean)

        'If blnClear = True Then dgView.Rows.Clear()
        Dim intCounter As Integer
        Dim blnAdd As Boolean = False
        Dim strReader As New TextFieldParser(strDatabasePath & strFile)
        strReader.Delimiters = New String() {";"}
        strReader.TextFieldType = FieldType.Delimited
        Dim intValue(3) As Integer
        'MsgBox(strDatabasePath & strFile)
        Dim strRow As String()


        While Not strReader.EndOfData
            Console.WriteLine(strSearch1 & " *** " & strSearch2 & " *** " & strSearch3 & " *** " & strSearch4)

            Try
                strRow = strReader.ReadFields()
                Dim strField As String
                For Each strField In strRow

                    Dim intStr As Integer
                    intStr = InStr(UCase(strField), UCase(strSearch1))
                    If intStr > 0 Then intValue(0) = 1

                    '*****************
                    If Not strSearch2 = Nothing Then
                        'Console.WriteLine("KKK")
                        intStr = InStr(UCase(strField), UCase(strSearch2))
                        If intStr > 0 Then intValue(1) = 1
                    Else
                        intValue(1) = 1
                    End If


                    '******************
                    If Not strSearch3 = Nothing Then
                        intStr = InStr(UCase(strField), UCase(strSearch3))
                        If intStr > 0 Then intValue(2) = 1
                    Else
                        intValue(2) = 1
                    End If

                    '******************
                    If Not strSearch4 = Nothing Then
                        intStr = InStr(UCase(strField), UCase(strSearch4))
                        If intStr > 0 Then intValue(3) = 1
                    Else
                        intValue(3) = 1
                    End If



                    strData(intCounter) = strField


                    If intValue(0) + intValue(1) + intValue(2) + intValue(3) = 4 AndAlso intCounter = intStop AndAlso Not strData(0) = "DELETED" AndAlso intStop = 15 Then

                        dgView.Rows.Add(strData(0), strData(1), strData(2), strData(3), strData(4), strData(5), strData(6),
                                        strData(7), strData(8), strData(9), strData(10), strData(11), strData(12),
                                        strData(13), strData(14), strData(15), strDatabasePath & strFile)
                    End If


                    If intValue(0) + intValue(1) + intValue(2) + intValue(3) = 4 AndAlso intCounter = intStop AndAlso Not strData(0) = "DELETED" AndAlso intStop = 13 Then
                        strData(14) = ""
                        strData(15) = ""
                        dgView.Rows.Add(strData(0), strData(1), strData(2), strData(3), strData(4), strData(5), strData(6),
                                            strData(7), strData(8), strData(9), strData(10), strData(11), strData(12),
                                            strData(13), strData(14), strData(15), strDatabasePath & strFile)
                        If intStop = 13 Then
                            Dim i As Integer
                            i = dgView.Rows.Count
                            dgView.Rows(i - 1).DefaultCellStyle.BackColor = Color.LightCyan

                            'Else
                            '    Dim i As Integer
                            '    i = dgView.Rows.Count
                            '    dgView.Rows(i - 1).DefaultCellStyle.BackColor = Color.LightGreen

                        End If


                        blnAdd = False

                    End If

                    intCounter = intCounter + 1

                    If intCounter > intStop Then
                        intCounter = 0
                        blnAdd = False
                        intValue(0) = 0
                        intValue(1) = 0
                        intValue(2) = 0
                        intValue(3) = 0
                    End If

                Next
            Catch ex As Microsoft.VisualBasic.
                FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
        "is not valid and will be skipped.")
            End Try


        End While


    End Sub

    Public Function EncryptString(plainText As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv
            aes.Mode = CipherMode.CBC
            aes.Padding = PaddingMode.PKCS7

            Dim encryptor = aes.CreateEncryptor()
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                    Using sw As New StreamWriter(cs)
                        sw.Write(plainText)
                    End Using
                End Using
                Return Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Function

    Public Function DecryptString(cipherText As String) As String
        Try


            Using aes As Aes = Aes.Create()
                aes.Key = key
                aes.IV = iv
                aes.Mode = CipherMode.CBC
                aes.Padding = PaddingMode.PKCS7

                Dim decryptor = aes.CreateDecryptor()
                Dim buffer As Byte() = Convert.FromBase64String(cipherText)

                Using ms As New MemoryStream(buffer)
                    Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                        Using sr As New StreamReader(cs)
                            Return sr.ReadToEnd()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private ReadOnly rng As New Random()

    Public Sub GenerateRandomAlphaNumeric16(ByRef result As String)
        Const chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim builder As New System.Text.StringBuilder(16)

        For i As Integer = 1 To 16
            Dim index As Integer = rng.Next(chars.Length)
            builder.Append(chars(index))
        Next

        result = builder.ToString()
    End Sub

    Public Sub CreateZipInBackground(sourceDir As String, destinationFolder As String)
        Task.Run(Sub()
                     Try

                         If File.Exists(destinationFolder) Then File.Delete(destinationFolder)

                         ZipFile.CreateFromDirectory(sourceDir, destinationFolder, CompressionLevel.Optimal, True)

                         ' Optional: Show a message box on the UI thread
                         MessageBox.Show($"ZIP file created at: {destinationFolder}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Catch ex As Exception
                         MessageBox.Show("Error creating ZIP: " & ex.Message)
                         Exit Sub
                     End Try

                     frmBackupData.btnRepair.Enabled = True
                     blnBackupDone = True

                 End Sub)
    End Sub


    Public Sub RepairAndReplaceEncryptedCsv(csvFilePath As String, expectedFields As Integer)
        Dim tempFile As String = Path.GetTempFileName()
        Dim removedLogPath As String = Path.Combine(Path.GetDirectoryName(csvFilePath), "RemovedLines.txt")

        Dim repairedLines As Integer = 0
        Dim totalLines As Integer = 0

        Try
            Using reader As New StreamReader(csvFilePath),
              writer As New StreamWriter(tempFile, False),
              logWriter As New StreamWriter(removedLogPath, False)

                While Not reader.EndOfStream
                    Dim encryptedLine As String = reader.ReadLine()
                    totalLines += 1

                    Try
                        Dim decryptedLine As String = DecryptString(encryptedLine)
                        Dim fields() As String = decryptedLine.Split(";"c)

                        If fields.Length = expectedFields Then
                            writer.WriteLine(encryptedLine) ' Keep original encrypted line
                            repairedLines += 1
                        Else
                            logWriter.WriteLine($"[Invalid Field Count] {decryptedLine}")
                            Debug.WriteLine($"Line skipped: wrong field count ({fields.Length})")
                        End If

                    Catch ex As Exception
                        Debug.WriteLine("Decryption failed: " & ex.Message)
                        logWriter.WriteLine($"[Decryption Failed] {encryptedLine}")

                        If expectedFields = 14 Then
                            ' Replace with primary key and "Empty" in all fields if decryption fails
                            Dim fallbackFields(expectedFields - 1) As String

                            ' Set the first field as the primary key (line number, 7 digits)
                            fallbackFields(0) = totalLines.ToString("D7") ' Format as 7 digits

                            ' Set the remaining fields to "Empty"
                            For i As Integer = 1 To expectedFields - 1
                                fallbackFields(i) = "Empty"
                            Next

                            ' Join the fields and encrypt them back
                            Dim fallbackLine As String = EncryptString(String.Join(";", fallbackFields))
                            writer.WriteLine(fallbackLine)
                            repairedLines += 1
                        End If
                    End Try
                End While
            End Using

            If repairedLines > 0 Then
                ' Copy the temporary file to the original location
                File.Copy(tempFile, csvFilePath, True)
                'MessageBox.Show($"{repairedLines} out of {totalLines} lines repaired and saved." & vbCrLf &
                '             $"Removed lines were logged to: {removedLogPath}",
                '             "Repair Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No valid data found. Original file remains unchanged.",
                             "Repair Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Repair process failed: " & ex.Message,
                         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If File.Exists(tempFile) Then File.Delete(tempFile)
        End Try
    End Sub

    Public Sub CheckCsvIntegrity(csvFilePath As String, expectedFields As Integer)
        Dim totalLines As Integer = 0
        Dim validLines As Integer = 0
        Dim invalidLines As Integer = 0

        Try
            Using reader As New StreamReader(csvFilePath)
                While Not reader.EndOfStream
                    Dim encryptedLine As String = reader.ReadLine()
                    totalLines += 1

                    Try
                        Dim decryptedLine As String = DecryptString(encryptedLine)
                        Dim delimiterCount As Integer = decryptedLine.Count(Function(c) c = ";"c)

                        If delimiterCount = expectedFields - 1 Then
                            validLines += 1
                        Else
                            invalidLines += 1
                            Debug.WriteLine($"Line {totalLines}: Invalid delimiter count ({delimiterCount})")
                        End If

                    Catch ex As Exception
                        invalidLines += 1
                        Debug.WriteLine($"Line {totalLines}: Decryption error - {ex.Message}")
                    End Try
                End While
            End Using

            MessageBox.Show($"{validLines} valid lines out of {totalLines}. {invalidLines} issues found.", "CSV Integrity Check", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Integrity check failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub RepairEncryptedCsv(strFile As String, expectedColumns As Integer)
        Dim tempGrid As New DataGridView()

        ' Create columns
        For i As Integer = 0 To expectedColumns - 1
            tempGrid.Columns.Add("Col" & i, "Col" & i)
        Next

        Dim path As String = strDatabasePath & "\" & strFile

        ' Escape function to handle quotes and delimiters
        Dim Q As String = """" ' quote
        Dim C As String = ";"  ' delimiter

        Dim EscapeField As Func(Of String, String) = Function(value As String) As String
                                                         Dim needsQuotes = value.Contains(C) OrElse value.Contains(Q) OrElse value.Contains(vbNewLine)
                                                         If value.Contains(Q) Then value = value.Replace(Q, Q & Q)
                                                         If needsQuotes Then value = Q & value & Q
                                                         Return value
                                                     End Function

        Try
            Dim lineIndex As Integer = 0
            FailedPlaceholderCountGlobal = 0

            For Each line In File.ReadAllLines(path)
                Dim decryptedLine As String = ""
                Dim fields() As String = Nothing

                Try
                    decryptedLine = DecryptString(line)
                Catch
                    ' Handle unreadable lines with placeholder if expectedColumns = 14
                    If expectedColumns = 14 Then
                        Try
                            ReDim fields(expectedColumns - 1)

                            ' First column: 7-digit simulated account number
                            fields(0) = (lineIndex + 1).ToString("D7")

                            ' Fill the rest with "Empty"
                            For i As Integer = 1 To expectedColumns - 1
                                fields(i) = "Empty"
                            Next

                            ' Try adding the placeholder to the grid
                            tempGrid.Rows.Add(fields)

                        Catch
                            ' If adding placeholder fails, track it
                            FailedPlaceholderCountGlobal += 1
                        End Try
                    End If

                    lineIndex += 1
                    Continue For
                End Try

                Using parser As New TextFieldParser(New StringReader(decryptedLine))
                    parser.SetDelimiters(";")
                    parser.HasFieldsEnclosedInQuotes = True
                    parser.TextFieldType = FieldType.Delimited

                    ' ✅ Trim each field
                    fields = parser.ReadFields().Select(Function(f) f.Trim()).ToArray()

                    ' Adjust column count if needed
                    If fields.Length < expectedColumns Then
                        ReDim Preserve fields(expectedColumns - 1)
                    ElseIf fields.Length > expectedColumns Then
                        fields = fields.Take(expectedColumns).ToArray()
                    End If

                    ' ✅ Skip deleted rows if 16-column data
                    If expectedColumns = 16 AndAlso fields(0).ToUpper() = "DELETED" Then
                        Continue For
                    End If

                    tempGrid.Rows.Add(fields)
                End Using

                lineIndex += 1
            Next

            ' ✅ Write the repaired file
            Using writer As New StreamWriter(path, False)
                For Each row As DataGridViewRow In tempGrid.Rows
                    If Not row.IsNewRow Then
                        Dim values As New List(Of String)
                        For i As Integer = 0 To expectedColumns - 1
                            ' ✅ Trim again during write just in case
                            Dim rawValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString().Trim(), "")
                            values.Add(EscapeField(rawValue))
                        Next
                        Dim lineToWrite = EncryptString(String.Join(";", values))
                        writer.WriteLine(lineToWrite)
                    End If
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("Repair failed: " & ex.Message)
            FailedPlaceholderCountGlobal += 1
        End Try
    End Sub



    Public Sub WriteDeletedPlaceholders(strFile As String, expectedColumns As Integer)
        If expectedColumns <> 14 Or FailedPlaceholderCountGlobal <= 0 Then Exit Sub

        Dim path As String = strDatabasePath & "\" & strFile

        Try
            Using writer As New StreamWriter(path, True) ' Append mode
                For i As Integer = 1 To FailedPlaceholderCountGlobal
                    Dim deletedFields(expectedColumns - 1) As String
                    deletedFields(0) = "DELETED"
                    For j As Integer = 1 To expectedColumns - 1
                        deletedFields(j) = "Empty"
                    Next
                    Dim line = EncryptString(String.Join(";", deletedFields))
                    writer.WriteLine(line)
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to write deleted placeholders: " & ex.Message)
        End Try
    End Sub

    Public Sub ExportEncryptedData(strFile As String, expectedColumns As Integer, ByVal timestamp As String)
        Dim path As String = strDatabasePath & strFile
        'Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
        Dim exportDir As String = strBackupPath & "\" & strDatabaseName & "_" & timestamp
        Dim exportPath As String = exportDir & strFile

        Dim Q As String = """"
        Dim C As String = ";"

        'Dim EscapeField As Func(Of String, String) = Function(value As String) As String
        '                                                 Dim needsQuotes = value.Contains(C) OrElse value.Contains(Q) OrElse
        '                                                                   value.Contains(ControlChars.Cr) OrElse value.Contains(ControlChars.Lf)
        '                                                 If value.Contains(Q) Then value = value.Replace(Q, Q & Q)
        '                                                 If needsQuotes Then value = Q & value & Q
        '                                                 Return value
        '                                             End Function

        Dim EscapeField As Func(Of String, String) = Function(value As String) As String
                                                         Dim needsQuotes = value.Contains(C) OrElse value.Contains(Q) OrElse value.Contains(vbNewLine)
                                                         If value.Contains(Q) Then value = value.Replace(Q, Q & Q)
                                                         If needsQuotes Then value = Q & value & Q
                                                         Return value
                                                     End Function

        Try
            Dim lineIndex As Integer = 0
            'FailedPlaceholderCountGlobal = 0
            Dim dataRows As New List(Of String())

            For Each line In File.ReadAllLines(path)
                Dim decryptedLine As String = ""

                Try
                    decryptedLine = DecryptString(line)
                    If String.IsNullOrWhiteSpace(decryptedLine) Then Continue For
                Catch
                    lineIndex += 1
                    Continue For
                End Try

                Dim fields() As String
                Using parser As New TextFieldParser(New StringReader(decryptedLine))
                    parser.SetDelimiters(";")
                    parser.HasFieldsEnclosedInQuotes = True
                    parser.TextFieldType = FieldType.Delimited
                    fields = parser.ReadFields()
                End Using

                If fields.Length < expectedColumns Then
                    ReDim Preserve fields(expectedColumns - 1)
                ElseIf fields.Length > expectedColumns Then
                    fields = fields.Take(expectedColumns).ToArray()
                End If

                If (expectedColumns = 16 OrElse expectedColumns = 18) AndAlso fields(0).ToUpper() = "DELETED" Then
                    Continue For
                End If

                dataRows.Add(fields)
                lineIndex += 1
            Next

            ' Ensure export directory exists
            If Not My.Computer.FileSystem.DirectoryExists(exportDir) Then
                Try
                    My.Computer.FileSystem.CreateDirectory(exportDir)
                Catch ex As Exception
                    MessageBox.Show("Unable to create directory: " & exportDir, "Operation Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If

            ' Write file
            Using writer As New StreamWriter(exportPath, False)
                For Each fields In dataRows
                    Dim values As New List(Of String)
                    For i As Integer = 0 To expectedColumns - 1
                        Dim rawValue As String = If(fields(i) IsNot Nothing, fields(i).ToString().Trim(), "")
                        values.Add(EscapeField(rawValue))
                    Next
                    writer.WriteLine(String.Join(";", values))
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message)
            FailedPlaceholderCountGlobal += 1
        End Try
    End Sub

    Public Sub CreateZipCSV(sourceDir As String, destinationFolder As String)
        Task.Run(Sub()
                     Try

                         If File.Exists(destinationFolder) Then File.Delete(destinationFolder)

                         ZipFile.CreateFromDirectory(sourceDir, destinationFolder, CompressionLevel.Optimal, True)

                         ' Optional: Show a message box on the UI thread
                         Debug.WriteLine(sourceDir)
                         If Directory.Exists(sourceDir) Then
                             Directory.Delete(sourceDir, recursive:=True)
                         End If
                         MessageBox.Show($"ZIP file created at: {destinationFolder}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Catch ex As Exception
                         MessageBox.Show("Error creating ZIP: " & ex.Message)
                         Exit Sub
                     End Try




                 End Sub)
    End Sub

    Public Sub LoadAllCsvsToMemory()
        For Each fileName In FileNames
            Dim fullPath As String = strDatabasePath & "\" & fileName

            If File.Exists(fullPath) Then
                Try
                    'MsgBox(fullPath)
                    ' Read, decrypt and parse all lines
                    Dim parsedRows As New List(Of String())

                    Dim lines() As String = File.ReadAllLines(fullPath)

                    Parallel.ForEach(lines, Sub(line)
                                                Try
                                                    Dim decrypted = DecryptString(line)

                                                    Using parser As New TextFieldParser(New StringReader(decrypted))
                                                        parser.Delimiters = New String() {";"}
                                                        parser.HasFieldsEnclosedInQuotes = True
                                                        parser.TextFieldType = FieldType.Delimited

                                                        Dim fields() As String = parser.ReadFields()

                                                        SyncLock parsedRows
                                                            parsedRows.Add(fields)
                                                        End SyncLock
                                                    End Using
                                                Catch
                                                    ' Handle or ignore line errors
                                                End Try
                                            End Sub)

                    ' Store in memory
                    InMemoryData(fileName) = parsedRows

                Catch ex As Exception
                    MsgBox($"Error loading {fileName}: {ex.Message}")
                End Try
            End If
        Next
    End Sub

    Public Sub LoadCsvToMemory(strFile As String, ByRef isLoadingFlag As Boolean)
        isLoadingFlag = True ' Set as "loading in progress"

        Try
            Dim filePath As String = Path.Combine(strDatabasePath, strFile)
            Dim decryptedRows As New List(Of String())

            ' Use FileStream with shared read/write access
            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using sr As New StreamReader(fs)
                    While Not sr.EndOfStream
                        Dim line As String = sr.ReadLine()
                        Try
                            Dim decryptedLine = DecryptString(line)
                            Using parser As New TextFieldParser(New StringReader(decryptedLine))
                                parser.Delimiters = New String() {";"}
                                parser.HasFieldsEnclosedInQuotes = True
                                parser.TextFieldType = FieldType.Delimited
                                Dim fields() As String = parser.ReadFields()
                                decryptedRows.Add(fields)
                            End Using
                        Catch
                            ' Skip malformed lines
                        End Try
                    End While
                End Using
            End Using

            ' Replace in-memory data
            InMemoryData(strFile) = decryptedRows

        Catch ex As Exception
            MsgBox("Failed to load: " & strFile & vbCrLf & ex.Message)
        Finally
            isLoadingFlag = False ' ✅ Only flip off after load is successful or failed
        End Try
    End Sub


    'Public Sub LoadCsvToMemory(strFile As String)
    '    Try
    '        Dim filePath As String = Path.Combine(strDatabasePath, strFile)
    '        Dim decryptedRows As New List(Of String())

    '        ' Use FileStream with shared read/write access
    '        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '            Using sr As New StreamReader(fs)
    '                While Not sr.EndOfStream
    '                    Dim line As String = sr.ReadLine()
    '                    Try
    '                        Dim decryptedLine = DecryptString(line)
    '                        Using parser As New TextFieldParser(New StringReader(decryptedLine))
    '                            parser.Delimiters = New String() {";"}
    '                            parser.HasFieldsEnclosedInQuotes = True
    '                            parser.TextFieldType = FieldType.Delimited
    '                            Dim fields() As String = parser.ReadFields()
    '                            decryptedRows.Add(fields)
    '                        End Using
    '                    Catch
    '                        ' Skip malformed lines
    '                    End Try
    '                End While
    '            End Using
    '        End Using

    '        InMemoryData(strFile) = decryptedRows
    '        'MsgBox(strFile)

    '        If strFile = "Information.csv" Then blnInfoChange = False
    '        If strFile = "Accounts.csv" Then blnClientChange = False
    '        If strFile = "Notifications.csv" Then blnNotiChange = False
    '        'blnUpdating = False


    '    Catch ex As Exception
    '        MsgBox("Failed to load: " & strFile & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    Public Sub WatchCsvFile(strFile As String)
        Dim fullPath As String = Path.Combine(strDatabasePath, strFile)

        If watchers.ContainsKey(strFile) Then Return

        Dim watcher As New FileSystemWatcher(Path.GetDirectoryName(fullPath))
        watcher.Filter = Path.GetFileName(fullPath)
        watcher.NotifyFilter = NotifyFilters.LastWrite Or NotifyFilters.Size
        watcher.EnableRaisingEvents = True

        AddHandler watcher.Changed, Sub(s, e)
                                        ' Wait briefly to avoid file lock/read issues
                                        Threading.Thread.Sleep(200)

                                        ' Reload the file into memory
                                        ' LoadCsvToMemory(strFile)

                                        ' Set corresponding change flags
                                        'Select Case strFile.ToLower()
                                        '    Case "Accounts.csv"
                                        '        blnClientChange = False
                                        '    Case "Information.csv"
                                        '        blnInfoChange = False
                                        '    Case "Notifications.csv"
                                        '        blnNotiChange = False

                                        'End Select

                                        Select Case strFile.ToLower()
                                            Case "accounts.csv"
                                                LoadCsvToMemory(strFile, blnClientChange)
                                            Case "information.csv"
                                                LoadCsvToMemory(strFile, blnInfoChange)
                                            Case "notifications.csv"
                                                LoadCsvToMemory(strFile, blnNotiChange)
                                        End Select

                                        FileChangedFlag = True

                                        ' Set the general flag
                                        ' FileChangedFlag = True
                                    End Sub

        watchers(strFile) = watcher
    End Sub


    Public Sub CheckForUpdate(ByRef blnUptoDate As Boolean)
        Dim remoteVersionUrl As String = "https://cxn.co.za/clientfile/version.txt"
        Dim remoteExeUrl As String = "https://cxn.co.za/clientfile/Client%20Information%20-%20Encrypted.exe"
        Dim updaterPath As String = Path.Combine(Application.StartupPath, "Updater.exe")
        Dim currentExe As String = Process.GetCurrentProcess().MainModule.FileName

        Try
            ' Get current version
            Dim currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            Dim latestVersion As String

            ' Download version info
            Using client As New WebClient()
                latestVersion = client.DownloadString(remoteVersionUrl).Trim()
            End Using

            ' Compare versions
            If Version.Parse(latestVersion) > Version.Parse(currentVersion) Then
                Dim result = MessageBox.Show("A new version is available. Update now?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If result = DialogResult.Yes Then
                    ' Launch updater and exit
                    Process.Start(updaterPath, $"""{currentExe}"" ""{remoteExeUrl}""")
                    Application.Exit()
                    blnUptoDate = True
                End If

            Else

                blnUptoDate = False

            End If

        Catch ex As Exception
            MessageBox.Show("Update check failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub



End Module