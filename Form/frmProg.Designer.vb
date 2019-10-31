<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProg
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProg))
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.lblsyori = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(-2, 27)
        Me.prgBar.MarqueeAnimationSpeed = 10
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(251, 14)
        Me.prgBar.Step = 0
        Me.prgBar.TabIndex = 0
        Me.prgBar.UseWaitCursor = True
        '
        'lblsyori
        '
        Me.lblsyori.AutoSize = True
        Me.lblsyori.Location = New System.Drawing.Point(7, 4)
        Me.lblsyori.Name = "lblsyori"
        Me.lblsyori.Size = New System.Drawing.Size(38, 12)
        Me.lblsyori.TabIndex = 1
        Me.lblsyori.Text = "Label1"
        '
        'frmProg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 42)
        Me.Controls.Add(Me.lblsyori)
        Me.Controls.Add(Me.prgBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "勘定奉行　固定項目設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents prgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblsyori As System.Windows.Forms.Label
End Class
