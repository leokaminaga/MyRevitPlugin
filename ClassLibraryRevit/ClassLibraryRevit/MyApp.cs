using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;

namespace Revit.Plugin.kaminaga
{
    [Transaction(TransactionMode.ReadOnly)]
    public class Application : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //メッセージダイアログを表示
            TaskDialog dialog = new TaskDialog("Welcome To Revit !");
            dialog.MainContent = "I am AMDTools";
            dialog.Show();

            //アドインウィンドウにリボンボタンを作成
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("NewRibbonPanel");

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData(
                "cmdHelloWorld",
                "Hello World",
                thisAssemblyPath,
                "Walkthrough.HelloWorld");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = "Say hello to the entire world.";

            //リボンボタンのアイコンをホロラボロゴに設定
            Uri uriImage = new Uri(@"C:\Users\rkaminaga\source\repos\ClassLibraryRecit\Square44x44Logo.targetsize-32.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            
            return Result.Succeeded;
        }
        
    }

    [Transaction(TransactionMode.ReadOnly)]
    public class Command : IExternalCommand
    {
        private Autodesk.Revit.ApplicationServices.Application m_rvtApp;
        private Document m_rvtDoc;
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //UIApplication rvtUIApp = commandData.Application;
            //UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
            //m_rvtApp = commandData.Application.Application;
            
            //Reference refPick = rvtUIDoc.Selection.PickObject(ObjectType.Element, "Pick an element");
            
            //Element elem = m_rvtDoc.GetElement(refPick);

            try
            {
                TaskDialog.Show("plugin","test: " + Add(1,2));
            }
            catch
            {
                TaskDialog.Show("Revit kaminaga",
                    "モデルファイルを開いてからアドイン実行");
            }
            

            return Result.Succeeded;
        }

        public int Add(int x, int y) { return x + y; }
    }
}