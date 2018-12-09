using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AMMPSI.Views.Shared
{
    public static class SharedNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Dashboard => "DashboardIndex";

        public static string Category => "CategoryIndex";

        public static string Location => "LocationIndex";

        public static string Asset => "AssetIndex";

        public static string Account => "AccountIndex";

        public static string CreateAccount => "CreateAccount";

        public static string Move => "MoveIndex";

        public static string CreateMove => "CreateMove";

        public static string Task => "TaskIndex";

        public static string MoveLog => "MoveLog";

        public static string DashboardNavClass(ViewContext viewContext) => PageNavClass(viewContext, Dashboard);

        public static string CategoryNavClass(ViewContext viewContext) => PageNavClass(viewContext, Category);

        public static string LocationNavClass(ViewContext viewContext) => PageNavClass(viewContext, Location);

        public static string AssetNavClass(ViewContext viewContext) => PageNavClass(viewContext, Asset);

        public static string AccountNavClass(ViewContext viewContext) => PageNavClass(viewContext, Account);

        public static string CreateAccountNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateAccount);

        public static string MoveNavClass(ViewContext viewContext) => PageNavClass(viewContext, Move);

        public static string CreateMoveNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateMove);

        public static string TaskNavClass(ViewContext viewContext) => PageNavClass(viewContext, Task);

        public static string MoveLogNavClass(ViewContext viewContext) => PageNavClass(viewContext, MoveLog);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
