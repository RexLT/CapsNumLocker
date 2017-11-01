'------------------------------------------------------------------------------
'  Caps Locker
'------------------------------------------------------------------------------
'  Written by Nigel Bolton, Bolton Business Services ABN 
'  PO Box 74, Glenorchy TAS 7010
'------------------------------------------------------------------------------
'  This program shows an icon in the System Tray to indicate if the caps lock
'  is on or off.
'------------------------------------------------------------------------------
'  This software is freeware.  It may be distrbuted as-is and no changes are 
'  permitted.  All risk is assumed by the user if they use or install the software. 
'------------------------------------------------------------------------------

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '-- Find current caps lock status
        UpdateCapsNumLockStatus()

        '-- Setup timer for caps lock status check
        Timer1.Interval = 100
        Timer1.Start()

        '-- Setup timer for hiding form immediately after opening
        Timer2.Interval = 10
        Timer2.Start()

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        '-- Clean up icon
        NotifyIcon1.Icon = Nothing
        NotifyIcon1.Dispose()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub btnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click

        Hide()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        '-- Check the caps lock status after the specified number of ticks
        UpdateCapsNumLockStatus()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        '-- Stop timer & hide main form
        Timer2.Stop()
        Me.Hide()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        '-- Close app when exit if selected
        Me.Close()

    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click

        '-- Show form if user requests
        Me.Show()

    End Sub

    Private Sub UpdateCapsNumLockStatus()

        '-- Check caps/number lock status
        If My.Computer.Keyboard.CapsLock = True And My.Computer.Keyboard.NumLock = True Then

            '-- Set labels on form
            lblCapLockStatus.Text = "Caps Lock is ON"
            lblNumLockStatus.Text = "Num Lock is ON"

            '-- Update image on firm
            pbxStatus.Image = My.Resources.imgCapsOnNumOn

            '-- Update icon in system tray
            NotifyIcon1.Icon = My.Resources.icoCapsOnNumOn
        Else
            If My.Computer.Keyboard.CapsLock = True And My.Computer.Keyboard.NumLock = False Then

                '-- Set labels on form
                lblCapLockStatus.Text = "Caps Lock is ON"
                lblNumLockStatus.Text = "Num Lock is OFF"

                '-- Update image on firm
                pbxStatus.Image = My.Resources.imgCapsOnNumOff

                '-- Update icon in system tray
                NotifyIcon1.Icon = My.Resources.icoCapsOnNumOff
            Else
                If My.Computer.Keyboard.CapsLock = False And My.Computer.Keyboard.NumLock = True Then

                    '-- Set labels on form
                    lblCapLockStatus.Text = "Caps Lock is OFF"
                    lblNumLockStatus.Text = "Num Lock is ON"

                    '-- Update image on firm
                    pbxStatus.Image = My.Resources.imgCapsOffNumOn

                    '-- Update icon in system tray
                    NotifyIcon1.Icon = My.Resources.icoCapsOffNumOn
                Else

                    '-- Set labels on form
                    lblCapLockStatus.Text = "Caps Lock is OFF"
                    lblNumLockStatus.Text = "Num Lock is OFF"

                    '-- Update image on firm
                    pbxStatus.Image = My.Resources.imgCapsOffNumOff

                    '-- Update icon in system tray
                    NotifyIcon1.Icon = My.Resources.icoCapsOffNumOff
                End If
            End If
        End If
        Refresh()

    End Sub

End Class
