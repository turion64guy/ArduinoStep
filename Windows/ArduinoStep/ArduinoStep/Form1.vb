Public Class Form1
    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Private Declare Function MapVirtualKey Lib "user32" Alias "MapVirtualKeyA" (ByVal wCode As Integer, ByVal wMapType As Integer) As Integer
    Public Const KEYEVENTF_EXTENDEDKEY = &H1    'Key DOWN
    Public Const KEYEVENTF_KEYUP = &H2          'Key UP

    Public Const up_press As Byte = &H1     '0x01
    Public Const down_press As Byte = &H2   '0x02
    Public Const left_press As Byte = &H3   '0x03
    Public Const right_press As Byte = &H4  '0x04
    Public Const up_rel As Byte = &H5       '0x05
    Public Const down_rel As Byte = &H6     '0x06
    Public Const left_rel As Byte = &H7     '0x07
    Public Const right_rel As Byte = &H8    '0x08

    Dim ver As String = "0.2b"
    Dim comPlayer1 As String
    Dim controlVersion1 As String
    Dim RXdata As Byte

    Private Function reloadCOMList()
        Dim noserial As String = 0
        If IO.Ports.SerialPort.GetPortNames.Length = 0 Then
            MessageBox.Show("No SerialPorts detected", "Error", MessageBoxButtons.OK)
            noserial = 1
        Else
            serialPortCombo.Items.Clear()
            serialPortCombo.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
            serialPortCombo.SelectedIndex = 0
            noserial = 0
        End If
        Return noserial
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        verLabel.Text = ver
        reloadCOMList()
        Label1.Hide()
    End Sub

    Private Sub reloadSerialList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reloadSerialList.Click
        reloadCOMList()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeysListbox1.SelectedIndexChanged

    End Sub

    Private Sub conSerial1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conSerial1.Click
        Dim serialoutput As String
        If Not serialPortCombo.Text = Nothing Then
            comPlayer1 = serialPortCombo.Text
            SerialPort1.Close()
            With (SerialPort1)
                .PortName = comPlayer1
                .BaudRate = 19200
                .DataBits = 8
                .Parity = IO.Ports.Parity.None
                .StopBits = IO.Ports.StopBits.One
                .Handshake = IO.Ports.Handshake.None
                .ReceivedBytesThreshold = 1
                .ReadTimeout = 1000
            End With
            Try
                SerialPort1.Open()
                conSerial1.BackColor = Color.Yellow
                controlStatusP1.Text = "Waiting for controller"
                SerialPort1.Write("rst")
                Threading.Thread.Sleep(2000)
                serialoutput = SerialPort1.ReadExisting()
                If serialoutput = Nothing Then
                    controlStatusP1.Text = "ERROR:Timeout, please retry"
                ElseIf serialoutput.Contains("sta:") Then
                    conSerial1.BackColor = Color.Green
                    controlVersion1 = serialoutput.Split(New Char() {":"c})(1)
                    controlStatusP1.Text = "Controller connected [" & controlVersion1 & "] (" & comPlayer1 & ")"
                    conSerial1.Enabled = False
                    AddHandler SerialPort1.DataReceived, AddressOf SerialPort1_DataReceived
                ElseIf Not serialoutput.Contains("sta:") Then
                    controlStatusP1.Text = "ERROR:Bad response, please retry"
                End If
            Catch ex As Exception
                MessageBox.Show("Error opening SerialPort", "Error", MessageBoxButtons.OK)
            End Try
        Else
            MessageBox.Show("Select a COM port first", "Error", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub disconSerial1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconSerial1.Click
        RemoveHandler SerialPort1.DataReceived, AddressOf SerialPort1_DataReceived
        SerialPort1.Close()
        'SerialPort1.Dispose()
        conSerial1.BackColor = Color.Transparent
        conSerial1.Enabled = True
        controlStatusP1.Text = "Disconnected"
        upArrow.BackColor = SystemColors.ControlDark
        downArrow.BackColor = SystemColors.ControlDark
        leftArrow.BackColor = SystemColors.ControlDark
        rightArrow.BackColor = SystemColors.ControlDark
        keybd_event(Keys.Up, MapVirtualKey(Keys.Up, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.Down, MapVirtualKey(Keys.Down, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.Left, MapVirtualKey(Keys.Left, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.Right, MapVirtualKey(Keys.Right, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
    End Sub
    Delegate Sub ParseSerialDel(ByVal serialRX As Byte)
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)
        Dim ParseSerial1 = New ParseSerialDel(AddressOf ParseSerial)
        RXdata = SerialPort1.ReadByte
        Me.Invoke(ParseSerial1, RXdata)
    End Sub
    Private Sub ParseSerial(ByVal serialRX As String)
        'Label1.Text = serialRX
        'Select Case True
        '    Case serialRX.Contains(".u_p.")
        '        keybd_event(Keys.Up, MapVirtualKey(Keys.Up, 0), 1, 0) 'press up
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("UP_ARROW     PRESSED")
        '        upArrow.BackColor = Color.Orange
        '    Case serialRX.Contains(".u_r.")
        '        keybd_event(Keys.Up, MapVirtualKey(Keys.Up, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) ' release up
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("UP_ARROW    RELEASED")
        '        upArrow.BackColor = SystemColors.ControlDark
        '    Case serialRX.Contains(".d_p.")
        '        keybd_event(Keys.Down, MapVirtualKey(Keys.Down, 0), 1, 0) 'press down
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("DOWN_ARROW   PRESSED")
        '        downArrow.BackColor = Color.Orange
        '    Case serialRX.Contains(".d_r.")
        '        keybd_event(Keys.Down, MapVirtualKey(Keys.Down, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) 'release down
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("DOWN_ARROW  RELEASED")
        '        downArrow.BackColor = SystemColors.ControlDark
        '    Case serialRX.Contains(".l_p.")
        '        keybd_event(Keys.Left, MapVirtualKey(Keys.Left, 0), 1, 0) 'press left
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("LEFT_ARROW   PRESSED")
        '        leftArrow.BackColor = Color.Orange
        '    Case serialRX.Contains(".l_r.")
        '        keybd_event(Keys.Left, MapVirtualKey(Keys.Left, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) 'release left
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("LEFT_ARROW  RELEASED")
        '        leftArrow.BackColor = SystemColors.ControlDark
        '    Case serialRX.Contains(".r_p.")
        '        keybd_event(Keys.Right, MapVirtualKey(Keys.Right, 0), 1, 0) 'press right
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("RIGHT_ARROW  PRESSED")
        '        rightArrow.BackColor = Color.Orange
        '    Case serialRX.Contains(".r_r.")
        '        keybd_event(Keys.Right, MapVirtualKey(Keys.Right, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) 'release right
        '        '<- keyboard keypress simulation
        '        KeysListbox1.Items.Add("RIGHT_ARROW RELEASED")
        '        rightArrow.BackColor = SystemColors.ControlDark
        'End Select
        If serialRX.Contains(up_press) Then         '### Sorry, but i had to use IF instead of Select Case, because in VB, case does not fall through.
            keybd_event(Keys.Up, MapVirtualKey(Keys.Up, 0), 1, 0) 'press up
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("UP_ARROW     PRESSED")
            upArrow.BackColor = Color.Orange
        End If
        If serialRX.Contains(up_rel) Then
            keybd_event(Keys.Up, MapVirtualKey(Keys.Up, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) ' release up
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("UP_ARROW    RELEASED")
            upArrow.BackColor = SystemColors.ControlDark
        End If
        If serialRX.Contains(down_press) Then
            keybd_event(Keys.Down, MapVirtualKey(Keys.Down, 0), 1, 0) 'press down
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("DOWN_ARROW   PRESSED")
            downArrow.BackColor = Color.Orange
        End If
        If serialRX.Contains(down_rel) Then
            keybd_event(Keys.Down, MapVirtualKey(Keys.Down, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) 'release down
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("DOWN_ARROW  RELEASED")
            downArrow.BackColor = SystemColors.ControlDark
        End If
        If serialRX.Contains(left_press) Then
            keybd_event(Keys.Left, MapVirtualKey(Keys.Left, 0), 1, 0) 'press left
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("LEFT_ARROW   PRESSED")
            leftArrow.BackColor = Color.Orange
        End If
        If serialRX.Contains(left_rel) Then
            keybd_event(Keys.Left, MapVirtualKey(Keys.Left, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) 'release left
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("LEFT_ARROW  RELEASED")
            leftArrow.BackColor = SystemColors.ControlDark
        End If
        If serialRX.Contains(right_press) Then
            keybd_event(Keys.Right, MapVirtualKey(Keys.Right, 0), 1, 0) 'press right
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("RIGHT_ARROW  PRESSED")
            rightArrow.BackColor = Color.Orange
        End If
        If serialRX.Contains(right_rel) Then
            keybd_event(Keys.Right, MapVirtualKey(Keys.Right, 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0) 'release right
            '<- keyboard keypress simulation
            KeysListbox1.Items.Add("RIGHT_ARROW RELEASED")
            rightArrow.BackColor = SystemColors.ControlDark
        End If
        If KeysListbox1.Items.Count >= 11 Then
            'Label1.Text = KeysListbox1.Items.Count
            KeysListbox1.Items.RemoveAt(0)
            While KeysListbox1.Items.Count >= 11
                KeysListbox1.Items.RemoveAt(0)
            End While
        End If
    End Sub

    Private Sub BGWserial1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGWserial1.DoWork 'not used.
        If Not e.Argument = Nothing Then
            While SerialPort1.ReadExisting Is Nothing
                MessageBox.Show("loli")
            End While
            e.Result = SerialPort1.ReadExisting
        End If
    End Sub

    Private Sub BGWserial1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGWserial1.RunWorkerCompleted
        MessageBox.Show(e.Result.ToString())
    End Sub
End Class
