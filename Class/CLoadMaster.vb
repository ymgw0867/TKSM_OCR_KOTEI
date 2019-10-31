'Imports 固定項目保守.Cfunction
Imports 固定項目保守.frmInfo
Imports 固定項目保守.PCData
Imports 固定項目保守.frmProg
Imports fs = Microsoft.VisualBasic.Strings

Public Class CLoadMaster

    '----------------------------------------------------------------
    '   各種情報ロード
    '----------------------------------------------------------------
    Public Sub LoadMaster()
        Dim AdoData As New ADODB.Connection     'ADOのConnectionオブジェクトを生成
        Dim Rs As ADODB.Recordset          'Recordsetオブジェクトの生成
        Dim wrkConnectInfo As String
        Dim Cnt As Integer
        Dim LoopCnt As Integer
        Dim ErrMsg As String

        Dim cntKamoku As Integer                  '補助科目用
        Dim wrkBfNcd As String
        Dim wrkNcd As String
        Dim wrkKamoku As String
        Dim kamokuFlg As Boolean

        Dim strOtherName As String
        Dim lCnt As Integer                  'フレックスグリッドの表示行添え字

        On Error GoTo ErrPrc

        Dim fProg As New frmProg
        fProg.Show()

        '接続文字列
        Dim wcl As New PCfunc
        wrkConnectInfo = wcl.GetDbConnect(pblDbName)


        'DBを開く
        AdoData.ConnectionString = wrkConnectInfo
        AdoData.Open()

        '-----------------------------------------------------
        ' 会社データ取得
        '-----------------------------------------------------
        'fProg.Text = "データロード中・・・会社データ"
        fProg.lblsyori.Text = "データロード中・・・会社データ"
        fProg.lblsyori.Update()
        fProg.prgBar.Value = 25
        ErrMsg = "会社データ取得中"

        'レコードを開く
        Rs = New ADODB.Recordset

        '取得方法追加「バージョンを取得」 (v6.0対応)--
        Rs.Open("SELECT sDateKisyu,sDateKimatu,tiKaisi,sCorpNm,sGngo,sHosei,tiIsMiddle,tiIsVersion FROM wdhead", AdoData, , ADODB.LockTypeEnum.adLockReadOnly)

        With pblComData
            .Name = Trim(Rs.Fields("sCorpNm").Value)
            .FromYear = Mid(Trim(Rs.Fields("sDateKisyu").Value), 1, 4)
        End With

        pblComData.TaxMas = frmComSelect.TaxMas

        '接続を切断
        Rs.Close()

        '西暦のとき
        If pblComData.Hosei = "0" Then
            pblComData.Reki = "20"

            '和暦のとき
        Else
            pblComData.Reki = pblComData.Gengou
        End If

        '-----------------------------------------------------
        ' 科目データ
        '-----------------------------------------------------
        'fProg.Text = "データロード中・・・科目コード"
        fProg.lblsyori.Text = "データロード中・・・科目コード"
        fProg.lblsyori.Update()
        fProg.prgBar.Value = 50
        ErrMsg = "勘定科目データ取得中"

        Rs = New ADODB.Recordset
        Rs.Open("SELECT sUcd,sNcd,sNm,tiIsTrk,tiIsZei FROM wkskm01 WHERE tiIsTrk = 1 ORDER BY sUcd", AdoData, , ADODB.LockTypeEnum.adLockReadOnly)
        Cnt = 0
        Do While Rs.EOF = False
            ReDim Preserve pblKamokuData(Cnt)
            pblKamokuData(Cnt).Code = Trim(Rs.Fields("sUcd").Value)
            pblKamokuData(Cnt).Ncd = Trim(Rs.Fields("sNcd").Value)
            pblKamokuData(Cnt).Name = Trim(Rs.Fields("sNm").Value)

            pblKamokuData(Cnt).IsZei = CStr(Rs.Fields("tiIsZei").Value)

            Cnt = Cnt + 1
            Rs.MoveNext()
        Loop
        Rs.Close()

        '-----------------------------------------------------
        ' 補助データ
        '-----------------------------------------------------
        'fProg.Text = "データロード中・・・補助科目コード"
        fProg.lblsyori.Text = "データロード中・・・補助科目コード"
        fProg.lblsyori.Update()
        fProg.prgBar.Value = 75
        ErrMsg = "補助科目取得中"


        Rs = New ADODB.Recordset
        Rs.Open("SELECT sHjoUcd,sNm,sSknNcd FROM wkhjm01 ORDER BY sSknNcd,sHjoUcd", AdoData, , ADODB.LockTypeEnum.adLockReadOnly)

        Cnt = 0
        cntKamoku = -1
        wrkBfNcd = ""

        Do While Rs.EOF = False
            '勘定科目内部コード取得
            wrkNcd = Trim(Rs.Fields("sSknNcd").Value)

            '勘定科目の内部コードが前回と異なっていた場合
            If wrkNcd <> wrkBfNcd Then
                'コード「0」が先頭の場合は、書き込みをスキップ
                If Val(Rs.Fields("sHjoUcd").Value) = 0 Then
                    GoTo Skip1
                End If

                'カウント初期化
                Cnt = 0
                cntKamoku = -1
                '勘定科目の検索
                For LoopCnt = 0 To UBound(pblKamokuData)
                    '科目コードがあったらOK
                    If (pblKamokuData(LoopCnt).Ncd = wrkNcd) Then
                        pblKamokuData(LoopCnt).HojoExist = True
                        cntKamoku = LoopCnt
                        Exit For
                    End If
                Next
                '万が一、勘定科目が見つからなかった場合は書込スキップ
                If cntKamoku = -1 Then
                    '-- 処理追加「前回番号に戻す」 (障害対応)-- 2004.03.26
                    wrkNcd = wrkBfNcd
                    GoTo Skip1
                End If
            End If

            '補助データの追加
            ReDim Preserve pblKamokuData(cntKamoku).HojoData(Cnt)
            pblKamokuData(cntKamoku).HojoData(Cnt).Code = Format(Val(Trim(Rs.Fields("sHjoUcd").Value)))
            pblKamokuData(cntKamoku).HojoData(Cnt).Name = Trim(Rs.Fields("sNm").Value)
            Cnt = Cnt + 1

Skip1:
            wrkBfNcd = wrkNcd
            Rs.MoveNext()
        Loop
        Rs.Close()

        '-----------------------------------------------------
        ' 部門データ
        '-----------------------------------------------------
        'fProg.Text = "データロード中・・・部門コード"
        fProg.lblsyori.Text = "データロード中・・・部門コード"
        fProg.lblsyori.Update()
        fProg.prgBar.Value = 100
        ErrMsg = "部門データ取得中"

        strOtherName = ""
        pblBumonFlg = False

        Rs = New ADODB.Recordset
        Rs.Open("SELECT sUcd,sNm FROM wkbnm01 ORDER BY sUcd", AdoData, , ADODB.LockTypeEnum.adLockReadOnly)
        Cnt = 0
        'pblBumonNum = 0
        ReDim Preserve pblBumonData(Cnt)
        Do While Rs.EOF = False
            'コードが「その他」以外
            If (Val(Trim(Rs.Fields("sUcd").Value)) <> 0) Then
                '部門フラグをON
                If pblBumonFlg = False Then
                    pblBumonFlg = True
                End If
                ReDim Preserve pblBumonData(Cnt)
                pblBumonData(Cnt).Code = Trim(Rs.Fields("sUcd").Value)
                pblBumonData(Cnt).Name = Trim(Rs.Fields("sNm").Value)

                Cnt = Cnt + 1
            Else
                'コードが「0」の場合は、名称のみ取得
                strOtherName = Trim(Rs.Fields("sNm").Value)
            End If
            Rs.MoveNext()
        Loop
        Rs.Close()

        '部門ありなら、「その他」追加
        If pblBumonFlg = True Then
            ReDim Preserve pblBumonData(Cnt)
            pblBumonData(Cnt).Code = "0"
            pblBumonData(Cnt).Name = strOtherName

        End If

        AdoData.Close()
        AdoData = Nothing


        fProg.Dispose()

        Exit Sub

        On Error GoTo 0

ErrPrc:
        Dim em As New CErr
        Call em.ErrMessage(ErrMsg)

    End Sub

End Class
