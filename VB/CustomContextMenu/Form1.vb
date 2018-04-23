Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.Utils

Namespace CustomContextMenu
    Partial Public Class Form1
        Inherits Form

        Private Const aptDataFileName As String = "..\..\Data\appointments.xml"
        Private Const resDataFileName As String = "..\..\Data\resources.xml"

        Public Sub New()
            InitializeComponent()
            schedulerControl1.Start = New Date(2010, 7, 05)
            schedulerControl1.DayView.TopRowTime = New TimeSpan(16, 0, 0)
            FillData()
        End Sub

        #Region "FillData"
        Private Sub FillData()
            Dim customNameMapping As New AppointmentCustomFieldMapping("CustomName", "CustomName")
            Dim customStatusMapping As New AppointmentCustomFieldMapping("CustomStatus", "CustomStatus")
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customNameMapping)
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customStatusMapping)
            FillResourceStorage(schedulerStorage1.Resources.Items, resDataFileName)
            FillAppointmentStorage(schedulerStorage1.Appointments.Items, aptDataFileName)
        End Sub

        Private Shared Function GetFileStream(ByVal fileName As String) As Stream
            Return (New StreamReader(fileName)).BaseStream
        End Function

        Private Shared Sub FillResourceStorage(ByVal c As ResourceCollection, ByVal fileName As String)
            Using stream As Stream = GetFileStream(fileName)
                c.ReadXml(stream)
                stream.Close()
            End Using
        End Sub
        Private Shared Sub FillAppointmentStorage(ByVal c As AppointmentCollection, ByVal fileName As String)
            Using stream As Stream = GetFileStream(fileName)
                c.ReadXml(stream)
                stream.Close()
            End Using
        End Sub
        #End Region

        Private Sub schedulerStorage_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsChanged, schedulerStorage1.AppointmentsInserted, schedulerStorage1.AppointmentsDeleted
            schedulerStorage1.Appointments.Items.WriteXml(aptDataFileName)
        End Sub

        Private Sub schedulerControl1_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs) Handles schedulerControl1.PopupMenuShowing
            ' Check if it's the default menu of a Scheduler.
            If e.Menu.Id = SchedulerMenuItemId.DefaultMenu Then

                ' Disable the "New Recurring Appointment" menu item.
                e.Menu.DisableMenuItem(SchedulerMenuItemId.NewRecurringAppointment)

                ' Hide the "New Recurring Event" menu item.
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent)

                ' Enable the "Go To Today" menu item.
                e.Menu.EnableMenuItem(SchedulerMenuItemId.GotoToday)

                ' Find the "New Appointment" menu item and rename it.
                Dim item As SchedulerMenuItem = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment, False)
                If item IsNot Nothing Then
                    item.Caption = "&Rent a Car"
                End If

                ' Find the "New All Day Event" menu item and rename it.
                item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAllDayEvent, False)
                If item IsNot Nothing Then
                    item.Caption = "&Perform a Maintenance"
                End If

                Dim myMenu As New SchedulerMenuItem("Click!", New EventHandler(AddressOf MyMenuItemClick))
                myMenu.Image = imageList1.Images(0)
                e.Menu.Items.Add(myMenu)
            End If
        End Sub

        Private Sub MyMenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim apt As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
            apt.Start = schedulerControl1.SelectedInterval.Start
            apt.End = schedulerControl1.SelectedInterval.End
            apt.Subject = "Fly to Iceland!"
            schedulerStorage1.Appointments.Add(apt)
            System.Diagnostics.Process.Start("http://www.icelandtouristboard.com/")
        End Sub

        Private Sub schedulerControl1_EditAppointmentFormShowing(ByVal sender As Object, ByVal e As AppointmentFormEventArgs) Handles schedulerControl1.EditAppointmentFormShowing
            ' Fill in the Subject field for the newly created appointment.
            If DirectCast(sender, SchedulerControl).Storage.Appointments.IsNewAppointment(e.Appointment) Then
               If e.Appointment.AllDay Then
                   e.Appointment.Subject = "Perform a maintenance"
               Else
                   e.Appointment.Subject="Rent a car"
               End If
            End If
        End Sub
    End Class
End Namespace