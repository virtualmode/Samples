Attribute VB_Name = "mdlIQT"

Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As Any, ByVal lpFileName As String) As Long

Public Function ReadINI(Section As String, Key As String, FileName As String) As String
    
    Dim sRet As String
    sRet = String(255, Chr(0))
    ReadINI = Left(sRet, GetPrivateProfileString(Section, ByVal Key, "", sRet, Len(sRet), FileName))

End Function

Public Sub WriteINI(Section As String, Key As String, Data As String, FileName As String)

    WritePrivateProfileString Section, Key, Data, FileName
    
End Sub
