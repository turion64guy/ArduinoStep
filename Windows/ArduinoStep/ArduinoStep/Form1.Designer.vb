<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.verLabel = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.controlStatusP1 = New System.Windows.Forms.Label()
        Me.disconSerial1 = New System.Windows.Forms.Button()
        Me.conSerial1 = New System.Windows.Forms.Button()
        Me.reloadSerialList = New System.Windows.Forms.Button()
        Me.serialPortCombo = New System.Windows.Forms.ComboBox()
        Me.PSlabel = New System.Windows.Forms.Label()
        Me.KeysListbox1 = New System.Windows.Forms.ListBox()
        Me.keysP1Box = New System.Windows.Forms.GroupBox()
        Me.BGWserial1 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.upArrow = New System.Windows.Forms.Panel()
        Me.downArrow = New System.Windows.Forms.Panel()
        Me.leftArrow = New System.Windows.Forms.Panel()
        Me.rightArrow = New System.Windows.Forms.Panel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.keysP1Box.SuspendLayout()
        Me.SuspendLayout()
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(13, 13)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(121, 25)
        Me.titleLabel.TabIndex = 2
        Me.titleLabel.Text = "ArduinoStep"
        '
        'verLabel
        '
        Me.verLabel.AutoSize = True
        Me.verLabel.Location = New System.Drawing.Point(131, 22)
        Me.verLabel.Name = "verLabel"
        Me.verLabel.Size = New System.Drawing.Size(28, 13)
        Me.verLabel.TabIndex = 3
        Me.verLabel.Text = "v0.0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 45)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(283, 117)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.controlStatusP1)
        Me.TabPage1.Controls.Add(Me.disconSerial1)
        Me.TabPage1.Controls.Add(Me.conSerial1)
        Me.TabPage1.Controls.Add(Me.reloadSerialList)
        Me.TabPage1.Controls.Add(Me.serialPortCombo)
        Me.TabPage1.Controls.Add(Me.PSlabel)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(275, 91)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Player 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'controlStatusP1
        '
        Me.controlStatusP1.AutoSize = True
        Me.controlStatusP1.Location = New System.Drawing.Point(9, 65)
        Me.controlStatusP1.Name = "controlStatusP1"
        Me.controlStatusP1.Size = New System.Drawing.Size(73, 13)
        Me.controlStatusP1.TabIndex = 13
        Me.controlStatusP1.Text = "Disconnected"
        '
        'disconSerial1
        '
        Me.disconSerial1.Location = New System.Drawing.Point(90, 35)
        Me.disconSerial1.Name = "disconSerial1"
        Me.disconSerial1.Size = New System.Drawing.Size(75, 23)
        Me.disconSerial1.TabIndex = 12
        Me.disconSerial1.Text = "Disconnect"
        Me.disconSerial1.UseVisualStyleBackColor = True
        '
        'conSerial1
        '
        Me.conSerial1.Location = New System.Drawing.Point(9, 35)
        Me.conSerial1.Name = "conSerial1"
        Me.conSerial1.Size = New System.Drawing.Size(75, 23)
        Me.conSerial1.TabIndex = 11
        Me.conSerial1.Text = "Connect"
        Me.conSerial1.UseVisualStyleBackColor = True
        '
        'reloadSerialList
        '
        Me.reloadSerialList.Location = New System.Drawing.Point(194, 7)
        Me.reloadSerialList.Name = "reloadSerialList"
        Me.reloadSerialList.Size = New System.Drawing.Size(75, 23)
        Me.reloadSerialList.TabIndex = 10
        Me.reloadSerialList.Text = "Refresh"
        Me.reloadSerialList.UseVisualStyleBackColor = True
        '
        'serialPortCombo
        '
        Me.serialPortCombo.FormattingEnabled = True
        Me.serialPortCombo.Location = New System.Drawing.Point(67, 8)
        Me.serialPortCombo.Name = "serialPortCombo"
        Me.serialPortCombo.Size = New System.Drawing.Size(121, 21)
        Me.serialPortCombo.TabIndex = 8
        '
        'PSlabel
        '
        Me.PSlabel.AutoSize = True
        Me.PSlabel.Location = New System.Drawing.Point(6, 11)
        Me.PSlabel.Name = "PSlabel"
        Me.PSlabel.Size = New System.Drawing.Size(61, 13)
        Me.PSlabel.TabIndex = 9
        Me.PSlabel.Text = "Serial Port :"
        '
        'KeysListbox1
        '
        Me.KeysListbox1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeysListbox1.FormattingEnabled = True
        Me.KeysListbox1.ItemHeight = 15
        Me.KeysListbox1.Location = New System.Drawing.Point(230, 174)
        Me.KeysListbox1.Name = "KeysListbox1"
        Me.KeysListbox1.Size = New System.Drawing.Size(151, 169)
        Me.KeysListbox1.TabIndex = 7
        '
        'keysP1Box
        '
        Me.keysP1Box.Controls.Add(Me.rightArrow)
        Me.keysP1Box.Controls.Add(Me.leftArrow)
        Me.keysP1Box.Controls.Add(Me.downArrow)
        Me.keysP1Box.Controls.Add(Me.upArrow)
        Me.keysP1Box.Location = New System.Drawing.Point(12, 168)
        Me.keysP1Box.Name = "keysP1Box"
        Me.keysP1Box.Size = New System.Drawing.Size(212, 182)
        Me.keysP1Box.TabIndex = 1
        Me.keysP1Box.TabStop = False
        Me.keysP1Box.Text = "Keys Player 1"
        '
        'BGWserial1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(314, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Label1"
        '
        'upArrow
        '
        Me.upArrow.BackColor = System.Drawing.SystemColors.ControlDark
        Me.upArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.upArrow.Location = New System.Drawing.Point(73, 16)
        Me.upArrow.Name = "upArrow"
        Me.upArrow.Size = New System.Drawing.Size(57, 50)
        Me.upArrow.TabIndex = 10
        '
        'downArrow
        '
        Me.downArrow.BackColor = System.Drawing.SystemColors.ControlDark
        Me.downArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.downArrow.Location = New System.Drawing.Point(73, 124)
        Me.downArrow.Name = "downArrow"
        Me.downArrow.Size = New System.Drawing.Size(57, 50)
        Me.downArrow.TabIndex = 10
        '
        'leftArrow
        '
        Me.leftArrow.BackColor = System.Drawing.SystemColors.ControlDark
        Me.leftArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.leftArrow.Location = New System.Drawing.Point(11, 70)
        Me.leftArrow.Name = "leftArrow"
        Me.leftArrow.Size = New System.Drawing.Size(57, 50)
        Me.leftArrow.TabIndex = 10
        '
        'rightArrow
        '
        Me.rightArrow.BackColor = System.Drawing.SystemColors.ControlDark
        Me.rightArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rightArrow.Location = New System.Drawing.Point(135, 70)
        Me.rightArrow.Name = "rightArrow"
        Me.rightArrow.Size = New System.Drawing.Size(57, 50)
        Me.rightArrow.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 362)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.KeysListbox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.verLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.keysP1Box)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "ArduinoStep"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.keysP1Box.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents titleLabel As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents verLabel As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents reloadSerialList As System.Windows.Forms.Button
    Friend WithEvents serialPortCombo As System.Windows.Forms.ComboBox
    Friend WithEvents PSlabel As System.Windows.Forms.Label
    Friend WithEvents KeysListbox1 As System.Windows.Forms.ListBox
    Friend WithEvents keysP1Box As System.Windows.Forms.GroupBox
    Friend WithEvents disconSerial1 As System.Windows.Forms.Button
    Friend WithEvents conSerial1 As System.Windows.Forms.Button
    Friend WithEvents controlStatusP1 As System.Windows.Forms.Label
    Friend WithEvents BGWserial1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rightArrow As System.Windows.Forms.Panel
    Friend WithEvents leftArrow As System.Windows.Forms.Panel
    Friend WithEvents downArrow As System.Windows.Forms.Panel
    Friend WithEvents upArrow As System.Windows.Forms.Panel

End Class
