Imports System
Imports System.IO
Imports System.Net.Sockets
Public Class FrmAddDatabase
    Private ReadOnly rng As New Random()
    Private Sub FrmAddDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = Main
        lblPath.Text = strPath
        Me.AcceptButton = btnAdd
        tvDatabase.Nodes.Add(strPath).SelectedImageIndex = 0
        Try

            Dim strDir As New DirectoryInfo(strPath)
            Dim strTemp As String

            For Each dir As DirectoryInfo In strDir.GetDirectories
                strTemp = dir.Name
                Dim intValue As Integer
                intValue = InStr(strTemp, ".DB")
                If intValue > 0 Then
                    strTemp = Microsoft.VisualBasic.Left(strTemp, intValue - 1)
                    tvDatabase.Nodes(0).Nodes.Add(strTemp).ImageIndex = 1

                End If

            Next
            tvDatabase.ExpandAll()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If String.IsNullOrWhiteSpace(txtDatabaseName.Text) Then
            MessageBox.Show("The database name is invalid.", "Invalid Database Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not txtPassword.Text = txtConfirmPassword.Text Then
            MessageBox.Show("The passwords do not match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim password As String = txtPassword.Text

        Dim hasSpecialChar As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))
        Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))

        If password.Length < 8 OrElse Not hasSpecialChar OrElse Not hasDigit Then
            MessageBox.Show("Password must be at least 8 characters long, contain at least one special character, and at least one number.", "Password Complexity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not String.IsNullOrWhiteSpace(txtDatabaseName.Text) AndAlso Not txtDatabaseName.Text.Any(AddressOf Char.IsWhiteSpace) Then
            'Try

            If Not System.IO.Directory.Exists(strPath & "\" & txtDatabaseName.Text & ".DB") Then
                My.Computer.FileSystem.CreateDirectory(strPath & "\" & txtDatabaseName.Text & ".DB")

                'Try


                Dim fs As FileStream = File.Create(strPath & "\" & txtDatabaseName.Text & ".DB" & "\" & strAccountsCSV)
                Dim fs1 As FileStream = File.Create(strPath & "\" & txtDatabaseName.Text & ".DB" & "\" & strInfoCsv)
                Dim fs2 As FileStream = File.Create(strPath & "\" & txtDatabaseName.Text & ".DB" & "\" & strTemplatePath)
                Dim fs3 As FileStream = File.Create(strPath & "\" & txtDatabaseName.Text & ".DB" & "\" & strNotificationsPath)

                fs.Close()
                fs1.Close()
                fs2.Close()
                fs3.Close()

                Dim rng As New Random()
                Dim result As String = ""

                For i As Integer = 1 To 16
                    result &= rng.Next(0, 10).ToString()
                Next
                '***************
                Dim strIVkey As String = ""
                Const chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
                Dim builder As New System.Text.StringBuilder(16)

                For i As Integer = 1 To 16
                    Dim index As Integer = rng.Next(chars.Length)
                    builder.Append(chars(index))
                Next

                strIVkey = builder.ToString()
                '************


                'Using writer As New StreamWriter(filePath, False) ' False = overwrite; True = append
                '    writer.WriteLine("Windows Registry Editor Version 5.00")
                '    writer.WriteLine("")
                '    writer.WriteLine("[HKEY_CURRENT_USER\Software\Client Information]")
                '    writer.WriteLine("""" & txtDatabaseName.Text & "Key" & """" & "=""" & result & """")
                '    writer.WriteLine("""" & txtDatabaseName.Text & "IV" & """" & "=""" & strIVkey & """")

                'End Using

                'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", txtDatabaseName.Text & "Key", result)
                'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Client Information", txtDatabaseName.Text & "IV", strIVkey)

                If Not strEncryptKey > "" Or Not strEncryptIVKey > "" Then
                    Main.mnuOpenDatabase.Enabled = True
                    FrmOpenDatabase.Show()

                End If
                'Catch ex As Exception
                'MessageBox.Show(ex.ToString)

                'End Try

                Dim encrypted(1)
                encrypted(0) = EncryptText(result, txtPassword.Text)
                encrypted(1) = EncryptText(strIVkey, txtPassword.Text)

                Dim filePath As String = Path.Combine(strPath, txtDatabaseName.Text & ".DB", "Key.dat")

                Using writer As New StreamWriter(filePath, False) ' False = overwrite; True = append

                    writer.WriteLine(encrypted(0))
                    writer.WriteLine(encrypted(1))

                End Using

                Me.Close()
            Else
                MessageBox.Show("The database already exists.", "Database Exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


            'Catch ex As Exception
            'MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub



End Class