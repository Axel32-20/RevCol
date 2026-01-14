#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

#endregion

namespace RevCol
{
    [Transaction(TransactionMode.Manual)]

    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Mensaje según versión
#if REVIT2024_OR_EARLIER
                            //TaskDialog.Show("Command", "Running in Revit 2024 or earlier (.NET 4.8)");
#elif REVIT2025_OR_LATER
                   // TaskDialog.Show("Command", "Running in Revit 2025 or later (.NET 8)");
#endif
            //pick object
            var pickObject = uidoc.Selection.PickObject(ObjectType.Element, "Select an element");
            if (pickObject == null)
            {
                return Result.Cancelled;
            }
            else
            {
                ElementId idEl = pickObject.ElementId;
                Element ele = doc.GetElement(idEl);
                TaskDialog.Show("Element Selected", $"You selected a {ele.GetType().Name} with id {ele.Id}");

            }



            // Modificación dentro de una transacción (aunque no hace nada acá)
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Transaction Name");

                tx.Commit();
            }

            return Result.Succeeded;
        }

    }

}
