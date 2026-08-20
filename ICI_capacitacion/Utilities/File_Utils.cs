using ICI_capacitacion.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form = System.Windows.Forms.Form;

namespace ICI_capacitacion.Utilities
{
    public static class File_Utils
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="iconPath"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void SetFormatIcon(Form form, string iconPath = null)
        {
            // Implementation for setting format icon
            // Returning to the ide of using a stream for getting the icon from resources

            iconPath ??= "ICI_capacitacion.Resources.Icons16.IconList16.ico";

            using (Stream stream = Globals.Assembly.GetManifestResourceStream(iconPath))
            {
                if (stream is not null)
                {
                    form.Icon = new Icon(stream);
                }
                else
                {
                    throw new FileNotFoundException($"Icon resource '{iconPath}' not found.");
                }
            }
        }
    }
}
