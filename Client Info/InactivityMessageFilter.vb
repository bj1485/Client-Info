Imports System.Windows.Forms

Public Class InactivityMessageFilter
    Implements IMessageFilter

    Public Delegate Sub ActivityDetectedHandler()
    Public Event ActivityDetected As ActivityDetectedHandler

    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        Select Case m.Msg
            Case &H200, &H201, &H100, &H101 ' MouseMove, MouseDown, KeyDown, KeyUp
                RaiseEvent ActivityDetected()
        End Select
        Return False ' Allow the message to continue normally
    End Function
End Class
