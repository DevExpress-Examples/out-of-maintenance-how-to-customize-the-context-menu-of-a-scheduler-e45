Namespace CustomContextMenu
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
            Me.splitterControl1 = New DevExpress.XtraEditors.SplitterControl()
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 0)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(469, 415)
            Me.schedulerControl1.Start = New Date(2010, 7, 5, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' schedulerStorage1
            ' 
            ' 
            ' dateNavigator1
            ' 
            Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right
            Me.dateNavigator1.Location = New System.Drawing.Point(474, 0)
            Me.dateNavigator1.Name = "dateNavigator1"
            Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
            Me.dateNavigator1.Size = New System.Drawing.Size(179, 415)
            Me.dateNavigator1.TabIndex = 1
            ' 
            ' splitterControl1
            ' 
            Me.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right
            Me.splitterControl1.Location = New System.Drawing.Point(469, 0)
            Me.splitterControl1.Name = "splitterControl1"
            Me.splitterControl1.Size = New System.Drawing.Size(5, 415)
            Me.splitterControl1.TabIndex = 2
            Me.splitterControl1.TabStop = False
            ' 
            ' imageList1
            ' 
            Me.imageList1.ImageStream = (DirectCast(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
            Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
            Me.imageList1.Images.SetKeyName(0, "holiday.png")
            Me.imageList1.Images.SetKeyName(1, "biztrip.png")
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(653, 415)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.splitterControl1)
            Me.Controls.Add(Me.dateNavigator1)
            Me.Name = "Form1"
            Me.Text = "Custom Context Menu Demo"
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private WithEvents schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
        Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator
        Private splitterControl1 As DevExpress.XtraEditors.SplitterControl
        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
        Private imageList1 As System.Windows.Forms.ImageList
    End Class
End Namespace

