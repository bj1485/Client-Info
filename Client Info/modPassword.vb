Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Module modPassword

    ' Encrypt text using AES with a password
    Public Function EncryptText(plainText As String, password As String) As String
        Dim salt As Byte() = GenerateRandomBytes(16)
        Dim iv As Byte() = GenerateRandomBytes(16)
        Dim key As Byte() = DeriveKey(password, salt)

        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv

            Using ms As New MemoryStream()
                ' Write salt and IV first (needed for decryption)
                ms.Write(salt, 0, salt.Length)
                ms.Write(iv, 0, iv.Length)

                Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                    Using sw As New StreamWriter(cs)
                        sw.Write(plainText)
                    End Using
                End Using

                Return Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Function

    Public Function DecryptText(cipherText As String, password As String, ByRef success As Boolean) As String
        Try
            Dim fullCipher As Byte() = Convert.FromBase64String(cipherText)

            Dim salt(15) As Byte
            Dim iv(15) As Byte

            Array.Copy(fullCipher, 0, salt, 0, 16)
            Array.Copy(fullCipher, 16, iv, 0, 16)

            Dim key As Byte() = DeriveKey(password, salt)

            Using aes As Aes = Aes.Create()
                aes.Key = key
                aes.IV = iv

                Using ms As New MemoryStream(fullCipher, 32, fullCipher.Length - 32)
                    Using cs As New CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read)
                        Using sr As New StreamReader(cs)
                            success = True
                            Return sr.ReadToEnd()
                        End Using
                    End Using
                End Using
            End Using
        Catch
            success = False
            Return String.Empty
        End Try
    End Function




    ' Derives a 256-bit key from a password and salt
    Private Function DeriveKey(password As String, salt As Byte()) As Byte()
        Dim pdb As New Rfc2898DeriveBytes(password, salt, 10000)
        Return pdb.GetBytes(32) ' AES-256
    End Function

    ' Generate random bytes
    Private Function GenerateRandomBytes(length As Integer) As Byte()
        Dim bytes(length - 1) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(bytes)
        End Using
        Return bytes
    End Function

End Module
