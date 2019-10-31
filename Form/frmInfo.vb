Imports 固定項目保守.PCData
Public Class frmInfo

    Private Sub frmInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New ADODB.Connection             'データベース情報
        Dim RecSet As New ADODB.Recordset              'レコードセット
        Dim mySql As String
        Dim Cnt As Long
        Dim wk_nBumon As String
        Dim wk_nKanjo As String
        Dim wk_nHojo As String
        Dim wk_sBumon As String
        Dim wk_sKanjo As String
        Dim wk_sHojo As String

        '初期設定
        Dim Cini = New CInital
        Cini.Initial()

        'マスターデータロード
        Dim cLM = New CLoadMaster
        cLM.LoadMaster()

        'コンボボックス内データ設定
        '部門コード
        For Cnt = 0 To UBound(pblBumonData)
            Me.cmbNBumon.Items.Add(pblBumonData(Cnt).Code & "  " & pblBumonData(Cnt).Name)
            Me.cmbSBumon.Items.Add(pblBumonData(Cnt).Code & "  " & pblBumonData(Cnt).Name)
        Next Cnt

        Me.cmbSBumon.SelectedIndex = 0
        Me.cmbSBumon.SelectedIndex = 0


        '勘定科目
        For Cnt = 0 To UBound(pblKamokuData)
            Me.cmbNKanjo.Items.Add(pblKamokuData(Cnt).Code & "  " & pblKamokuData(Cnt).Name)
            Me.cmbSKanjo.Items.Add(pblKamokuData(Cnt).Code & "  " & pblKamokuData(Cnt).Name)
        Next Cnt

        Me.cmbNKanjo.SelectedIndex = 0
        Me.cmbSKanjo.SelectedIndex = 0

        '-----------------------------------------------------------------
        '   config.mdb rewrite
        '-----------------------------------------------------------------
        'データベース接続
        cn.Open(MDBCONNECT & pblInstPath & DIR_HENKAN & CONFIGFILE & ";")

        mySql = "select * from config"
        RecSet = cn.Execute(mySql)

        wk_nBumon = Trim(RecSet.Fields("nBumon").Value)
        wk_nKanjo = Trim(RecSet.Fields("nkamoku").Value)
        wk_nHojo = Trim(RecSet.Fields("nHojo").Value)

        wk_sBumon = Trim(RecSet.Fields("sBumon").Value)
        wk_sKanjo = Trim(RecSet.Fields("skamoku").Value)
        wk_sHojo = Trim(RecSet.Fields("sHojo").Value)

        RecSet.Close()

        cn.Close()
        cn = Nothing

        '------------------------------------------------------------------------
        '   設定部門表示
        '------------------------------------------------------------------------
        If pblBumonFlg = False Then
            Me.cmbNBumon.Enabled = False
            Me.cmbSBumon.Enabled = False
        Else

            '入金
            Me.cmbNBumon.Text = ""
            For Cnt = 0 To UBound(pblBumonData)
                If pblBumonData(Cnt).Code = wk_nBumon Then
                    Me.cmbNBumon.SelectedIndex = Cnt
                End If
            Next Cnt

            '出金
            Me.cmbSBumon.Text = ""
            For Cnt = 0 To UBound(pblBumonData)
                If pblBumonData(Cnt).Code = wk_sBumon Then
                    Me.cmbSBumon.SelectedIndex = Cnt
                End If
            Next Cnt
        End If

        '------------------------------------------------------------------------
        '   設定勘定科目表示
        '------------------------------------------------------------------------
        '入金
        Me.cmbNKanjo.Text = ""
        For Cnt = 0 To UBound(pblKamokuData)
            If pblKamokuData(Cnt).Code = wk_nKanjo Then
                Me.cmbNKanjo.SelectedIndex = Cnt
            End If
        Next Cnt

        '出金
        Me.cmbSKanjo.Text = ""
        For Cnt = 0 To UBound(pblKamokuData)
            If pblKamokuData(Cnt).Code = wk_sKanjo Then
                Me.cmbSKanjo.SelectedIndex = Cnt
            End If
        Next Cnt

        '------------------------------------------------------------------------
        '   設定補助科目表示
        '------------------------------------------------------------------------
        '入金
        Me.cmbNHojo.Text = ""

        If Me.cmbNKanjo.Text = "" Then
            Me.cmbNHojo.Text = ""
        Else
            If pblKamokuData(Me.cmbNKanjo.SelectedIndex).HojoExist = True Then
                For Cnt = 0 To UBound(pblKamokuData(Me.cmbNKanjo.SelectedIndex).HojoData)
                    If pblKamokuData(Me.cmbNKanjo.SelectedIndex).HojoData(Cnt).Code = wk_nHojo Then
                        Me.cmbNHojo.SelectedIndex = Cnt
                    End If
                Next Cnt
            End If
        End If


        '出金
        Me.cmbSHojo.Text = ""

        If Me.cmbSKanjo.Text = "" Then
            Me.cmbSHojo.Text = ""
        Else
            If pblKamokuData(Me.cmbSKanjo.SelectedIndex).HojoExist = True Then
                For Cnt = 0 To UBound(pblKamokuData(Me.cmbSKanjo.SelectedIndex).HojoData)
                    If pblKamokuData(Me.cmbSKanjo.SelectedIndex).HojoData(Cnt).Code = wk_sHojo Then
                        Me.cmbSHojo.SelectedIndex = Cnt
                    End If
                Next Cnt
            End If
        End If

        'フォームタグ初期化
        Me.Tag = ""

        Me.lblComName.Text = pblComData.Name

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cmdNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNo.Click
        '--------------------------------------------
        '   処理終了
        '--------------------------------------------
        Me.Tag = "cmdExit"
        Me.Dispose()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim wk_nBumon As String
        Dim wk_sBumon As String
        Dim wk_nKanjo As String
        Dim wk_sKanjo As String
        Dim wk_nHojo As String
        Dim wk_sHojo As String
        Dim mySql As String
        Dim ans As String
        Dim db As New ADODB.Connection   'ADOのConnectionオブジェクトを生成

        '--------------------------------------------------
        '   エラーチェック
        '--------------------------------------------------
        If pblBumonFlg = True Then

            '入金部門
            If cmbNBumon.SelectedIndex < 0 Then
                MsgBox("入金部門を正しく設定してください", vbExclamation + vbOKOnly, "部門エラー")
                cmbNBumon.Select()
                Exit Sub
            End If

            '出金部門
            If cmbSBumon.SelectedIndex < 0 Then
                MsgBox("出金部門を正しく設定してください", vbExclamation + vbOKOnly, "部門エラー")
                cmbSBumon.Select()
                Exit Sub
            End If

        End If

        '入金勘定科目
        If cmbNKanjo.SelectedIndex < 0 Then
            MsgBox("入金勘定科目を正しく設定してください", vbExclamation + vbOKOnly, "勘定科目エラー")
            cmbNKanjo.Select()
            Exit Sub
        End If

        '出金勘定科目
        If cmbSKanjo.SelectedIndex < 0 Then
            MsgBox("出金勘定科目を正しく設定してください", vbExclamation + vbOKOnly, "勘定科目エラー")
            cmbSKanjo.Select()
            Exit Sub
        End If

        '入金補助科目
        If pblKamokuData(cmbNKanjo.SelectedIndex).HojoExist = True Then
            If cmbNHojo.Items.Count < 0 Then
                MsgBox("入金補助科目を設定してください", vbExclamation + vbOKOnly, "補助科目エラー")
                cmbNHojo.Select()
                Exit Sub
            End If
        End If

        '出金補助科目
        If pblKamokuData(cmbSKanjo.SelectedIndex).HojoExist = True Then
            If cmbSHojo.Items.Count < 0 Then
                MsgBox("出金補助科目を設定してください", vbExclamation + vbOKOnly, "補助科目エラー")
                cmbSHojo.Select()
                Exit Sub
            End If
        End If

        '-----------------------------------------------------------------
        '   設定データベース更新
        '-----------------------------------------------------------------
        '部門コード
        If pblBumonFlg = False Then
            wk_nBumon = ""
            wk_sBumon = ""
        Else
            wk_nBumon = pblBumonData(cmbNBumon.SelectedIndex).Code
            wk_sBumon = pblBumonData(cmbSBumon.SelectedIndex).Code
        End If

        '勘定科目
        wk_nKanjo = pblKamokuData(cmbNKanjo.SelectedIndex).Code
        wk_sKanjo = pblKamokuData(cmbSKanjo.SelectedIndex).Code

        '入金補助科目
        If pblKamokuData(cmbNKanjo.SelectedIndex).HojoExist = True Then
            wk_nHojo = pblKamokuData(cmbNKanjo.SelectedIndex).HojoData(cmbNHojo.SelectedIndex).Code
        Else
            wk_nHojo = ""
        End If

        '出金補助科目
        If pblKamokuData(cmbSKanjo.SelectedIndex).HojoExist = True Then
            wk_sHojo = pblKamokuData(cmbSKanjo.SelectedIndex).HojoData(cmbSHojo.SelectedIndex).Code
        Else
            wk_sHojo = ""
        End If

        '-----------------------------------------------------------
        '       更新確認
        '-----------------------------------------------------------
        ans = MsgBox("固定項目を更新します。よろしいですか", vbQuestion + vbYesNo + vbDefaultButton1, "更新確認")
        If ans = vbNo Then
            Exit Sub
        End If

        '-----------------------------------------------------------
        '       データベース更新
        '-----------------------------------------------------------
        'データベース接続情報
        db.Open(MDBCONNECT & pblInstPath & DIR_HENKAN & CONFIGFILE & ";")

        mySql = "UPDATE config set NBumon = '" & wk_nBumon & "',SBumon = '" & wk_sBumon _
                & "',NKamoku = '" & wk_nKanjo & "',SKamoku = '" & wk_sKanjo _
                & "',NHojo = '" & wk_nHojo & "',SHojo = '" & wk_sHojo & "'"

        db.Execute(mySql)
        db.Close()
        db = Nothing

        Me.Dispose()

    End Sub

 

    Private Sub cmbNKanjo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNKanjo.SelectedIndexChanged

        '-------------------------------------------------
        '   入金勘定科目選択
        '-------------------------------------------------
        cmbNHojo.Items.Clear()

        If cmbNKanjo.Items.Count < 0 Then
            Exit Sub
        End If

        cmbNHojo.Enabled = True

        '選択された科目の補助設定がある場合、補助コンボリストを表示
        If pblKamokuData(cmbNKanjo.SelectedIndex).HojoExist = True Then

            '補助科目リストループ
            For Cnt = 0 To UBound(pblKamokuData(cmbNKanjo.SelectedIndex).HojoData)

                '補助リスト格納
                cmbNHojo.Items.Add(pblKamokuData(cmbNKanjo.SelectedIndex).HojoData(Cnt).Code & "  " _
                        & pblKamokuData(cmbNKanjo.SelectedIndex).HojoData(Cnt).Name)
                cmbNHojo.Focus()
                cmbNHojo.SelectedIndex = 0
                cmbNKanjo.Focus()
            Next

        Else
            cmbNHojo.Enabled = False
        End If

    End Sub

 

    Private Sub cmbSKanjo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSKanjo.SelectedIndexChanged

        '-------------------------------------------------
        '   出金勘定科目選択
        '-------------------------------------------------
        cmbSHojo.Items.Clear()

        If cmbSKanjo.Items.Count < 0 Then
            Exit Sub
        End If

        cmbSHojo.Enabled = True

        '選択された科目の補助設定がある場合、補助コンボリストを表示
        If pblKamokuData(cmbSKanjo.SelectedIndex).HojoExist = True Then

            '補助科目リストループ
            For Cnt = 0 To UBound(pblKamokuData(cmbSKanjo.SelectedIndex).HojoData)

                '補助リスト格納
                cmbSHojo.Items.Add(pblKamokuData(cmbSKanjo.SelectedIndex).HojoData(Cnt).Code & "  " _
                        & pblKamokuData(cmbSKanjo.SelectedIndex).HojoData(Cnt).Name)
                cmbSHojo.Focus()
                cmbSHojo.SelectedIndex = 0
                cmbSKanjo.Focus()
            Next

        Else
            cmbSHojo.Enabled = False
        End If

    End Sub

    Private Sub cmbSHojo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSHojo.SelectedIndexChanged
    End Sub
    Private Sub cmbNHojo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNHojo.SelectedIndexChanged

    End Sub
End Class
