Imports 固定項目保守.PCData
Imports 固定項目保守.PCfunc
Imports 固定項目保守.frmProg

Public Class CErr
    '----------------------------------------------------------------
    '   エラー時の処理
    '----------------------------------------------------------------
    Public Sub ErrMessage(ByVal Msg As String)
        Dim pf As New PCfunc

        Call pf.FileDelete(pblInstPath & DIR_HENKAN & TMPREAD)
        Call pf.FileDelete(pblInstPath & DIR_HENKAN & tmpFile)
        MsgBox(Msg & "にエラーが発生したため、処理を終了します。", , Title)
        frmProg.Dispose()
        End

    End Sub

End Class
