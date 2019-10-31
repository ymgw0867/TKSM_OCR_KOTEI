<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbNHojo = New System.Windows.Forms.ComboBox()
        Me.cmbNKanjo = New System.Windows.Forms.ComboBox()
        Me.cmbNBumon = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbSHojo = New System.Windows.Forms.ComboBox()
        Me.cmbSKanjo = New System.Windows.Forms.ComboBox()
        Me.cmbSBumon = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdNo = New System.Windows.Forms.Button()
        Me.lblComName = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbNHojo)
        Me.GroupBox1.Controls.Add(Me.cmbNKanjo)
        Me.GroupBox1.Controls.Add(Me.cmbNBumon)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 109)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "入金"
        '
        'cmbNHojo
        '
        Me.cmbNHojo.FormattingEnabled = True
        Me.cmbNHojo.Location = New System.Drawing.Point(67, 82)
        Me.cmbNHojo.Name = "cmbNHojo"
        Me.cmbNHojo.Size = New System.Drawing.Size(161, 20)
        Me.cmbNHojo.TabIndex = 5
        '
        'cmbNKanjo
        '
        Me.cmbNKanjo.FormattingEnabled = True
        Me.cmbNKanjo.Location = New System.Drawing.Point(67, 52)
        Me.cmbNKanjo.Name = "cmbNKanjo"
        Me.cmbNKanjo.Size = New System.Drawing.Size(161, 20)
        Me.cmbNKanjo.TabIndex = 4
        '
        'cmbNBumon
        '
        Me.cmbNBumon.FormattingEnabled = True
        Me.cmbNBumon.Location = New System.Drawing.Point(67, 25)
        Me.cmbNBumon.Name = "cmbNBumon"
        Me.cmbNBumon.Size = New System.Drawing.Size(161, 20)
        Me.cmbNBumon.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "補助科目"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "勘定科目"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "部門コード"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSHojo)
        Me.GroupBox2.Controls.Add(Me.cmbSKanjo)
        Me.GroupBox2.Controls.Add(Me.cmbSBumon)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(252, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(242, 109)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出金"
        '
        'cmbSHojo
        '
        Me.cmbSHojo.FormattingEnabled = True
        Me.cmbSHojo.Location = New System.Drawing.Point(66, 77)
        Me.cmbSHojo.Name = "cmbSHojo"
        Me.cmbSHojo.Size = New System.Drawing.Size(168, 20)
        Me.cmbSHojo.TabIndex = 5
        '
        'cmbSKanjo
        '
        Me.cmbSKanjo.FormattingEnabled = True
        Me.cmbSKanjo.Location = New System.Drawing.Point(66, 51)
        Me.cmbSKanjo.Name = "cmbSKanjo"
        Me.cmbSKanjo.Size = New System.Drawing.Size(169, 20)
        Me.cmbSKanjo.TabIndex = 4
        '
        'cmbSBumon
        '
        Me.cmbSBumon.FormattingEnabled = True
        Me.cmbSBumon.Location = New System.Drawing.Point(66, 25)
        Me.cmbSBumon.Name = "cmbSBumon"
        Me.cmbSBumon.Size = New System.Drawing.Size(168, 20)
        Me.cmbSBumon.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "補助科目"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "勘定科目"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "部門コード"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(324, 168)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(82, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdNo
        '
        Me.cmdNo.Location = New System.Drawing.Point(412, 169)
        Me.cmdNo.Name = "cmdNo"
        Me.cmdNo.Size = New System.Drawing.Size(82, 22)
        Me.cmdNo.TabIndex = 4
        Me.cmdNo.Text = "NO"
        Me.cmdNo.UseVisualStyleBackColor = True
        '
        'lblComName
        '
        Me.lblComName.AutoSize = True
        Me.lblComName.Location = New System.Drawing.Point(13, 11)
        Me.lblComName.Name = "lblComName"
        Me.lblComName.Size = New System.Drawing.Size(38, 12)
        Me.lblComName.TabIndex = 5
        Me.lblComName.Text = "Label7"
        '
        'frmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 201)
        Me.Controls.Add(Me.lblComName)
        Me.Controls.Add(Me.cmdNo)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "勘定奉行 固定項目設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbNHojo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNKanjo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNBumon As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSHojo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSKanjo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSBumon As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdNo As System.Windows.Forms.Button
    Friend WithEvents lblComName As System.Windows.Forms.Label

End Class
