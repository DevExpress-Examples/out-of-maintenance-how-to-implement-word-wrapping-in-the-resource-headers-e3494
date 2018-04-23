Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.XtraScheduler

Public Class ResourceFiller
    Public Shared Users() As String = { "Sarah Brighton", "Ryan Fischer", "Andrew Miller", "Barbara Chinavare", "Lewis Borrmann", "Alberta Berntsen" }
    Public Shared Usernames() As String = { "sbrighton", "rfischer", "amiller", "bchinavare", "lborrmann", "aberntsen" }

    Public Shared Sub FillResources(ByVal storage As ASPxSchedulerStorage)
        Dim resources As ResourceCollection = storage.Resources.Items
        storage.BeginUpdate()
        Try
            For i As Integer = 1 To Users.Length
                resources.Add(storage.CreateResource(Usernames(i - 1), Users(i - 1)))
            Next i
        Finally
            storage.EndUpdate()
        End Try
    End Sub
End Class
