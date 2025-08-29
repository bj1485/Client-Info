Public Class frmCompany

    Dim strImgPath As String
    Private Sub frmCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = Main

        Dim settingsPath As String = strDatabasePath & "\Company.txt"

        If IO.File.Exists(settingsPath) Then

            Dim lines() As String = IO.File.ReadAllLines(settingsPath)

            If lines.Length >= 2 Then
                ' Line 1: Image path
                Dim imagePath As String = lines(0).Trim()
                imagePath = strDatabasePath & "\" & lines(0)
                'If Not IO.Path.IsPathRooted(imagePath) Then
                '    imagePath = IO.Path.Combine(Application.StartupPath, imagePath)
                'End If

                If IO.File.Exists(imagePath) Then
                    'pbLogo.Image = Image.FromFile(imagePath)
                    Using imgStream As New IO.FileStream(imagePath, IO.FileMode.Open, IO.FileAccess.Read)
                        pbLogo.Image = Image.FromStream(imgStream)
                    End Using
                Else
                    MessageBox.Show("Image not found: " & imagePath, "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                ' Line 2: Company name
                txtCompany.Text = lines(1).Trim()
            Else
                MessageBox.Show("logo.txt does not contain both image path and company name.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If


    End Sub

    Private Sub btnImage_Click(sender As Object, e As EventArgs) Handles btnImage.Click

        OFDImage.Title = "Select an Image"
        OFDImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

        If OFDImage.ShowDialog() = DialogResult.OK Then
            strImgPath = OFDImage.FileName
            pbLogo.Image = Image.FromFile(OFDImage.FileName)
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click, Button2.Click

        If strImgPath = "" Then
            MessageBox.Show("Please select an image first.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtCompany.Text = "" Then
            MessageBox.Show("Please enter a Company name first.", "No Company Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Set the destination directory
        Dim destDir As String = strDatabasePath & "\"
        'If Not IO.Directory.Exists(destDir) Then
        '    IO.Directory.CreateDirectory(destDir)
        'End If

        ' Preserve the original file extension
        Dim fileExt As String = IO.Path.GetExtension(strImgPath)
        Dim newFileName As String = "Company" & fileExt
        Dim destPath As String = IO.Path.Combine(destDir, newFileName)

        ' Copy and overwrite
        IO.File.Copy(strImgPath, destPath, overwrite:=True)

        ' Write the image path and company name
        Dim strmWriter As New System.IO.StreamWriter(strDatabasePath & "\Company.txt", False)
        strmWriter.WriteLine(newFileName)
        strmWriter.WriteLine(txtCompany.Text)
        strmWriter.Close()
        strmWriter.Dispose()

        Me.Close()


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, Button1.Click
        Me.Close()
    End Sub



End Class