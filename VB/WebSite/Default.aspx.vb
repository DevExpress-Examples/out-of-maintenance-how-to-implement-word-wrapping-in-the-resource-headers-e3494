Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxScheduler

Partial Public Class [Default]
    Inherits System.Web.UI.Page

    Private ReadOnly Property Storage() As ASPxSchedulerStorage
        Get
            Return ASPxScheduler1.Storage
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        SetupMappings()
        ResourceFiller.FillResources(Me.ASPxScheduler1.Storage)

        ASPxScheduler1.AppointmentDataSource = appointmentDataSource
        ASPxScheduler1.DataBind()

        ASPxScheduler1.GroupType = SchedulerGroupType.Resource
    End Sub
    Private Sub SetupMappings()
        Dim mappings As ASPxAppointmentMappingInfo = Storage.Appointments.Mappings
        Storage.BeginUpdate()
        Try
            mappings.AppointmentId = "Id"
            mappings.Start = "StartTime"
            mappings.End = "EndTime"
            mappings.Subject = "Subject"
            mappings.AllDay = "AllDay"
            mappings.Description = "Description"
            mappings.Label = "Label"
            mappings.Location = "Location"
            mappings.RecurrenceInfo = "RecurrenceInfo"
            mappings.ReminderInfo = "ReminderInfo"
            mappings.ResourceId = "OwnerId"
            mappings.Status = "Status"
            mappings.Type = "EventType"
        Finally
            Storage.EndUpdate()
        End Try
    End Sub
    'Initilazing ObjectDataSource
    Protected Sub appointmentsDataSource_ObjectCreated(ByVal sender As Object, ByVal e As ObjectDataSourceEventArgs)
        e.ObjectInstance = New CustomEventDataSource(GetCustomEvents())
    End Sub
    Private Function GetCustomEvents() As CustomEventList

        Dim events_Renamed As CustomEventList = TryCast(Session("ListBoundModeObjects"), CustomEventList)
        If events_Renamed Is Nothing Then
            events_Renamed = New CustomEventList()
            Session("ListBoundModeObjects") = events_Renamed
        End If
        Return events_Renamed
    End Function

    ' User generated appointment id    
    Protected Sub ASPxScheduler1_AppointmentInserting(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)
        SetAppointmentId(sender, e)
    End Sub

    Private Sub SetAppointmentId(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)

        Dim storage_Renamed As ASPxSchedulerStorage = DirectCast(sender, ASPxSchedulerStorage)
        Dim apt As Appointment = CType(e.Object, Appointment)
        storage_Renamed.SetAppointmentId(apt, apt.GetHashCode())
    End Sub
End Class
