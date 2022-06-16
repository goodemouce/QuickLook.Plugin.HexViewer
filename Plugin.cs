using System.IO;
using System.Windows;
using System.Windows.Controls;
using QuickLook.Common.Plugin;

namespace QuickLook.Plugin.HexViewer
{
    public class Plugin : IViewer
    {
        public int Priority => -1000;

        public void Init()
        {
        }

        public bool CanHandle(string path)
        {
            FileInfo fi = new FileInfo(path);
            return (fi.Attributes & FileAttributes.Directory) == 0;
        }

        public void Prepare(string path, ContextObject context)
        {
            context.PreferredSize = new Size(635, 450);
        }

        public void View(string path, ContextObject context)
        {
            var viewer = new HexControl(path);

            context.ViewerContent = viewer;
            context.Title = $"{Path.GetFileName(path)}";

            context.IsBusy = false;
        }

        public void Cleanup()
        {
        }
    }
}