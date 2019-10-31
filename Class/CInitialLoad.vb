Imports 固定項目保守.PCData
'Imports 固定項目保守.PCfunc

Public Class CInitialLoad
    '----------------------------------------------------------------
    '   設定情報ロード
    '----------------------------------------------------------------
    Public Sub InitialLoad()
        Dim db As New ADODB.Connection   'ADOのConnectionオブジェクトを生成
        Dim rs As New ADODB.Recordset
        Dim sSql As String
        Dim wrkConnectInfo As String
        Dim wrkErrBackColor As Long
        Dim wrkErrForeColor As Long
        Dim wrkKinBackColor As Long

        On Error GoTo ErrPrc

        Dim cf As New PCfunc
        pblInstPath = cf.GetPath()

        ' データベースを開く
        db.Open(MDBCONNECT & pblInstPath & DIR_HENKAN & CONFIGFILE & ";")

        sSql = "SELECT * FROM Config"
        rs = db.Execute(sSql)

        ' 前回選択したデータベース名
        pblBfDbName = Trim(Rs.fields("BfDb").value)

        ' 接続関連
        pblDsnPath = Trim(rs.Fields("DsnPath").Value)
        pblDsnFlg = Trim(rs.Fields("DsnFlg").Value)

        If Microsoft.VisualBasic.Information.IsDBNull(rs.Fields("DsnPassWord").Value) = True Then
            pblDsnPassWord = ""
        Else
            pblDsnPassWord = Trim(rs.Fields("DsnPassWord").Value)
        End If

        Rs.Close()
        db.Close()
        rs = Nothing
        db = Nothing

        On Error GoTo 0
        Exit Sub

ErrPrc:
        ' エラー処理
        Dim em As New CErr
        Call em.ErrMessage("設定データ取得中")

    End Sub


End Class
