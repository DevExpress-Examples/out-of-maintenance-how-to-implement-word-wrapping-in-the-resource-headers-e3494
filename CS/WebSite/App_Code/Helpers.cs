using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;

public class ResourceFiller {
    public static string[] Users = new string[] { "Sarah Brighton", "Ryan Fischer", "Andrew Miller", "Barbara Chinavare", "Lewis Borrmann", "Alberta Berntsen" };
    public static string[] Usernames = new string[] { "sbrighton", "rfischer", "amiller", "bchinavare", "lborrmann", "aberntsen" };

    public static void FillResources(ASPxSchedulerStorage storage) {
        ResourceCollection resources = storage.Resources.Items;
        storage.BeginUpdate();
        try {
            for (int i = 1; i <= Users.Length; i++) {
                resources.Add(storage.CreateResource(Usernames[i - 1], Users[i - 1]));
            }
        }
        finally {
            storage.EndUpdate();
        }
    }
}
