<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileWatcherTester
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button_StopMon = New System.Windows.Forms.Button()
        Me.Button_StartMon = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(0, 88)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(510, 226)
        Me.TextBox1.TabIndex = 17
        '
        'Button_StopMon
        '
        Me.Button_StopMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_StopMon.Location = New System.Drawing.Point(23, 50)
        Me.Button_StopMon.Name = "Button_StopMon"
        Me.Button_StopMon.Size = New System.Drawing.Size(456, 32)
        Me.Button_StopMon.TabIndex = 16
        Me.Button_StopMon.Text = "Stop Monitor"
        Me.Button_StopMon.UseVisualStyleBackColor = True
        '
        'Button_StartMon
        '
        Me.Button_StartMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_StartMon.Location = New System.Drawing.Point(23, 12)
        Me.Button_StartMon.Name = "Button_StartMon"
        Me.Button_StartMon.Size = New System.Drawing.Size(456, 32)
        Me.Button_StartMon.TabIndex = 15
        Me.Button_StartMon.Text = "Star Monitor"
        Me.Button_StartMon.UseVisualStyleBackColor = True
        '
        'FileWatcherTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(510, 314)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button_StopMon)
        Me.Controls.Add(Me.Button_StartMon)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FileWatcherTester"
        Me.Text = "FileWatcherTester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button_StopMon As System.Windows.Forms.Button
    Friend WithEvents Button_StartMon As System.Windows.Forms.Button
End Class
