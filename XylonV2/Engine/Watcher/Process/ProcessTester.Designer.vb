﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProcessTester
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button_StopMon = New System.Windows.Forms.Button()
        Me.Button_StartMon = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button_StopMon
        '
        Me.Button_StopMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_StopMon.Location = New System.Drawing.Point(23, 44)
        Me.Button_StopMon.Name = "Button_StopMon"
        Me.Button_StopMon.Size = New System.Drawing.Size(456, 32)
        Me.Button_StopMon.TabIndex = 10
        Me.Button_StopMon.Text = "Stop Monitor"
        Me.Button_StopMon.UseVisualStyleBackColor = True
        '
        'Button_StartMon
        '
        Me.Button_StartMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_StartMon.Location = New System.Drawing.Point(23, 6)
        Me.Button_StartMon.Name = "Button_StartMon"
        Me.Button_StartMon.Size = New System.Drawing.Size(456, 32)
        Me.Button_StartMon.TabIndex = 9
        Me.Button_StartMon.Text = "Star Monitor"
        Me.Button_StartMon.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(0, 86)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(517, 226)
        Me.TextBox1.TabIndex = 11
        '
        'ProcessTester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(517, 312)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button_StopMon)
        Me.Controls.Add(Me.Button_StartMon)
        Me.ForeColor = System.Drawing.Color.White
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProcessTester"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProcessTester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_StopMon As System.Windows.Forms.Button
    Friend WithEvents Button_StartMon As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class