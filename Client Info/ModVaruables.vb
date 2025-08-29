Imports System.Text

Module ModVaruables

    Public key As Byte()
    Public iv As Byte()

    Public blnInfoChange As Boolean = False
    Public blnClientChange As Boolean = False
    Public blnNotiChange As Boolean = False

    Public strPath As String
    Public strDatabasePath As String
    Public strDatabaseName As String

    Public strData(17) As String
    Public strDataP(16) As String
    Public strDataT(16) As String
    Public strDataI(17) As String

    Public openFormsList As New List(Of Form)
    Public blnLoadData As Boolean

    Public blnUpdateNotify As Boolean
    Public strDataN(17) As String
    Public blnAddReminder As Boolean
    ' Public intNotiCounter As Integer
    Public intNotiOpen As Integer
    Public strNotiTemp(1) As String


    Public blnEditClient As Boolean
    Public blnEditInfo As Boolean
    Public intInfoOpen As Integer
    Public intClientOpen As Integer
    Public blnSearchFilter As Boolean
    Public blnSearchAccOnly As Boolean
    Public blnBackupDone As Boolean
    Public Const strAccountsCSV As String = "\Accounts.csv"
    Public Const strInfoCsv As String = "\Information.csv"
    Public Const strTemplatePath As String = "\Template.csv"
    Public Const strNotificationsPath As String = "\Notifications.csv"
    Public strEncryptKey As String
    Public strEncryptIVKey As String
    Public strBackupPath As String
    Public FailedPlaceholderCountGlobal As Integer = 0
    Public intOpenDatabase As Integer = 0

End Module
