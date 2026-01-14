#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

#endregion

namespace RevCol
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
#if REVIT2024_OR_EARLIER
                //TaskDialog.Show("Startup", "Running in Revit 2024 or earlier (.NET 4.8)");
#elif REVIT2025_OR_LATER
                //TaskDialog.Show("Startup", "Running in Revit 2025 or later (.NET 8)");
#endif
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
