Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports 固定項目保守.PCData
Imports 固定項目保守.frmProg

Public Class PCfunc

    Public Function GetDbConnect(ByVal DbName As String) As String
        Dim RetValue As String

        RetValue = ConvDsn(pblDsnPath) & "DATABASE=" & DbName & ";"
        GetDbConnect = RetValue

    End Function

    '----------------------------------------------------------------
    '   スペース前詰
    '----------------------------------------------------------------
    Public Function AddSpace(ByVal Word As String, ByVal WordLength As Integer) As String
        Dim Cnt As Integer
        Dim RetValue As String

        RetValue = Word

        Cnt = WordLength - Len(Word)
        If Cnt >= 0 Then
            RetValue = Space(Cnt) & RetValue
        End If

        AddSpace = RetValue
    End Function

    '----------------------------------------------------------------
    '   スペース後詰
    '----------------------------------------------------------------
    Public Function AddBackSpace(ByVal Word As String, ByVal WordLength As Integer) As String
        Dim Cnt As Integer
        Dim RetValue As String

        RetValue = Word

        Cnt = WordLength - Len(Word)
        If Cnt >= 0 Then
            Cnt = Cnt
            RetValue = RetValue & Space(Cnt)
        End If

        AddBackSpace = RetValue
    End Function

    '----------------------------------------------------------------
    '   ファイル削除
    '----------------------------------------------------------------
    Public Sub FileDelete(ByVal FileName As String)

        'ファイルが存在したら削除
        If (Dir(FileName) <> "") Then
            Kill(FileName)
        End If
    End Sub

    '----------------------------------------------------------------
    '   エラー時の処理
    '----------------------------------------------------------------
    Public Sub ErrMessage(ByVal Msg As String)
        Call FileDelete(pblInstPath & DIR_HENKAN & TMPREAD)
        Call FileDelete(pblInstPath & DIR_HENKAN & tmpFile)
        MsgBox(Msg & "にエラーが発生したため、処理を終了します。", , Title)
        'frmPrgの消去はコメント Unload frmProg
        End

    End Sub

    '----------------------------------------------------------------
    '   パス情報取得
    '----------------------------------------------------------------
    Public Function GetPath()
        Dim regkey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\FKDL", False)
        GetPath = ""
        If regkey Is Nothing Then
            Exit Function
        End If

        '展開して取得する
        GetPath = CStr(regkey.GetValue("InstDir"))

    End Function


    '----------------------------------------
    '　DSNファイルの展開
    '----------------------------------------
    Public Function fncGetConnect(ByVal sDsnPath As String) As String
        Dim sReadBuf As String
        Dim sCnnStr As String              '接続文字列格納用

        sCnnStr = ""

        'DSNファイルを開く
        Dim fileReader = My.Computer.FileSystem.OpenTextFileReader(sDsnPath)
        If fileReader.EndOfStream = True Then
            fileReader.Close()
            fncGetConnect = ""
            Exit Function
        End If

        '１行読み飛ばし
        sReadBuf = fileReader.ReadLine()
        Do While (fileReader.EndOfStream <> True)
            sReadBuf = fileReader.ReadLine()
            sCnnStr = sCnnStr + sReadBuf & ";"
        Loop
        fileReader.Close()

        If pblDsnPassWord <> "" Then
            'パスワードが設定されている場合のみ、パスワードを追加
            sCnnStr = sCnnStr & "PWD=" & pblDsnPassWord & ";"
        End If


        '接続文字列を返す
        fncGetConnect = sCnnStr

    End Function

    Public Function ConvDsn(ByVal DsnPath As String) As String
        Dim readbuf As String               '1行読込みバッファ
        Dim wrkPath As String
        Dim RetValue As String

        RetValue = ""
        wrkPath = DsnPath

        ' ファイルを開く
        Dim fileReader = My.Computer.FileSystem.OpenTextFileReader(DsnPath)
        If fileReader.EndOfStream = True Then
            fileReader.Close()
            Call ErrMessage("データ接続中")
        Else
            '１行読み飛ばし
            readbuf = fileReader.ReadLine()
            Do While (fileReader.EndOfStream <> True)
                readbuf = fileReader.ReadLine()
                ' DATABASE があればOK
                If InStr(1, readbuf, "DATABASE", vbTextCompare) = 0 Then
                    RetValue = RetValue + readbuf & ";"
                End If
            Loop
        End If
        fileReader.Close()

        RetValue = "Provider=MSDASQL.1;" & RetValue

        If Trim(pblDsnPassWord) <> "" Then
            'パスワードが設定されている場合のみ、パスワードを追加
            RetValue = RetValue & "PWD=" & pblDsnPassWord & ";"
        End If
        ConvDsn = RetValue
    End Function

End Class
