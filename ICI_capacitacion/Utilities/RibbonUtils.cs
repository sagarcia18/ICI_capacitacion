using Autodesk.Revit.UI;
using System.Diagnostics;
using ICI_capacitacion.General;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ICI_capacitacion.Utilities
{
    public static class RibbonUtils
    {
        #region RIBBON BUTTON CREATION
        public static PushButtonData NewPushButtonData(string buttonName, string className)
        {

            //Get our base name
            var baseName = CommandToBaseName(className);

            var pushButtonData = new PushButtonData(baseName, buttonName, Globals.AssemblyPath, className);

            // Set the values

            pushButtonData.ToolTip = LookUpTooltip(baseName);

            pushButtonData.Image = GetIcon(baseName, resolution: 16);
            pushButtonData.LargeImage = GetIcon(baseName, resolution: 32);

            return pushButtonData;
        }
        /// <summary>
        /// Creates a new PulldownButtonData object with the specified button name and class name.
        /// </summary>
        /// <param name="buttonName">The name the user sees</param>
        /// <param name="className">The class name of the command</param>
        /// <returns>The created PulldownButtonData object</returns>
        public static PulldownButtonData NewPulldownButtonData(string buttonName, string className)
        {

            //Get our base name
            var baseName = CommandToBaseName(className);

            var pullButtonData = new PulldownButtonData(baseName, buttonName);

            // Set the values

            pullButtonData.ToolTip = LookUpTooltip(baseName);
            pullButtonData.Image = GetIcon(baseName, resolution: 16);
            pullButtonData.LargeImage = GetIcon(baseName, resolution: 32);

            return pullButtonData;
        }


        #endregion
        #region RESOURCE MANAGEMENT
        //Method to get base name 

        public static string CommandToBaseName (string commandName)
        {
            return commandName.Replace("ICI_capacitacion.Cmds_", "").Replace(".Cmd", "");
        }

        //Method to get a value from a dictionary key
        public static string LookUpTooltip(string key, string failValue = null)
        {
            failValue ??= "No Tooltip  was found.";

            if (Globals.Tooltips.TryGetValue(key, out string value))
            {
                return value;
            }
            return failValue;
        }

        // Method to get an icon as an image source
        public static ImageSource GetIcon(string baseName, int resolution = 32)
        {
            var resourcePath= $"ICI_capacitacion.Resources.Icons{resolution}.{baseName}{resolution}.png";

            using (var stream = Globals.Assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream is null) { return null;}

                var decoder = new PngBitmapDecoder(
                    stream, 
                    BitmapCreateOptions.PreservePixelFormat,
                    BitmapCacheOption.OnLoad);

                if (decoder.Frames.Count > 0)
                {
                    var frame = decoder.Frames.First();

                    Debug.WriteLine($"PixelWidth: {frame.PixelWidth}");
                    Debug.WriteLine($"PixelHeight: {frame.PixelHeight}");
                    Debug.WriteLine($"DPI: {frame.DpiX} x {frame.DpiY}");
                    return decoder.Frames.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
    }
}
