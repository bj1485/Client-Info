Imports System.IO
Imports System.Text

Public Class frmChangePassword
    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main

        lblDatabase.Text = strDatabaseName

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filePath = Path.Combine(strPath, strDatabaseName & ".DB", "Key.dat")
        Dim success1 As Boolean = False
        Dim success2 As Boolean = False

        If File.Exists(filePath) Then
            Dim lines() As String = File.ReadAllLines(filePath)

            If lines.Length >= 2 Then
                Dim decrypted1 As String = DecryptText(lines(0), txtOldPassword.Text, success1)
                Dim decrypted2 As String = DecryptText(lines(1), txtOldPassword.Text, success2)

                If Not success1 OrElse Not success2 Then
                    MessageBox.Show("The old password is incorrect.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If Not txtPassword.Text = txtConfirmPassword.Text Then
                    MessageBox.Show("The passwords do not match.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim password As String = txtPassword.Text

                Dim hasSpecialChar As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))
                Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))

                If password.Length < 8 OrElse Not hasSpecialChar OrElse Not hasDigit Then
                    MessageBox.Show("Password must be at least 8 characters long, contain at least one special character, and at least one number.", "Password Complexity Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim encrypted(1)
                encrypted(0) = EncryptText(decrypted1, txtPassword.Text)
                encrypted(1) = EncryptText(decrypted2, txtPassword.Text)
                '
                ''Dim filePath As String = Path.Combine(strPath, strDatabaseName & ".DB", "Key.dat")

                Dim tempFilePath = filePath & ".tmp"

                Using writer As New StreamWriter(tempFilePath, False)
                    writer.WriteLine(encrypted(0))
                    writer.WriteLine(encrypted(1))
                End Using

                File.Replace(tempFilePath, filePath, Nothing)

                Me.Close()

            Else
                MessageBox.Show("Key file is incomplete, please restore the database from backup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("The key file is missing, please restore the database from backup.", "Cannot Decrypt Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub



End Class