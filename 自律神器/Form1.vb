Public Class Form1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick                    '利用Timer控件每隔一段时间运行一次，若要修改间隔，请修改Timer1的Interval属性

        Dim flag As Boolean
        flag = False
        Dim processlist() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcesses()
        For Each proc In processlist
            If proc.ProcessName = "Minecraft Note Block Studio" Or proc.ProcessName = "Code" Then    '检测到两个引号内的进程则不会蓝屏，Minecraft Note Block Studio代表NBS，Code代表Visual Studio Code
                Exit Sub                                                                             '退出当前程序，跳过后面的步骤
            End If
        Next
        For Each proc In processlist
            If proc.ProcessName = "javaw" Or proc.ProcessName = "java" Then                          '检测到引号内的进程则触发后续程序，javaw代表HMCL等需要Java的启动器或其他软件，java代表MC等需要Java运行的软件
                flag = True
            End If
        Next
        If flag = True Then
            For Each proc In processlist
                If proc.ProcessName = "svchost" Then                                                 '引号内为需要结束的进程，填入svchost则会导致电脑蓝屏
                    proc.Kill()
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click                '点击隐藏按钮后窗体隐藏并显示系统托盘图标
        Me.Visible = False
        NotifyIcon1.Visible = True
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.Icon = Me.Icon                                                                   '为任务栏图标赋值，若删除此语句会导致托盘图标无法显示
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click        '点击托盘内的图标隐藏图标并显示窗口
        Me.Visible = True
        NotifyIcon1.Visible = False
    End Sub
End Class
