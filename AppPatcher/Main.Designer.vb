<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.start_patch = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Main_text = New System.Windows.Forms.Label()
        Me.Debugger1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'start_patch
        '
        Me.start_patch.Location = New System.Drawing.Point(12, 83)
        Me.start_patch.Name = "start_patch"
        Me.start_patch.Size = New System.Drawing.Size(75, 23)
        Me.start_patch.TabIndex = 0
        Me.start_patch.Text = "Patch"
        Me.start_patch.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 43)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(273, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'Main_text
        '
        Me.Main_text.AutoSize = True
        Me.Main_text.Location = New System.Drawing.Point(12, 14)
        Me.Main_text.Name = "Main_text"
        Me.Main_text.Size = New System.Drawing.Size(39, 13)
        Me.Main_text.TabIndex = 2
        Me.Main_text.Text = "Label1"
        '
        'Debugger1
        '
        Me.Debugger1.FormattingEnabled = True
        Me.Debugger1.Location = New System.Drawing.Point(15, 125)
        Me.Debugger1.Name = "Debugger1"
        Me.Debugger1.Size = New System.Drawing.Size(271, 173)
        Me.Debugger1.TabIndex = 4
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 314)
        Me.Controls.Add(Me.Debugger1)
        Me.Controls.Add(Me.Main_text)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.start_patch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppPatcher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents start_patch As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Main_text As Label
    Friend WithEvents Debugger1 As ListBox
End Class
