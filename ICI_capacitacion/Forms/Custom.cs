using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICI_capacitacion.Forms
{
    public static class Custom
    {
        public static FormResult Message(string title = null, string message = null,
            bool YesNo = false, bool noCancel = false, MessageBoxIcon icon = MessageBoxImage.None)
        {
            
        }
    }

    public class FormResult
    {
        //Form object properties 
        public object Object { get; set; }
        public List<object> Objects { get; set; }
        // Form condition properties
        public bool Cancelled { get; set; }
        public bool Valid { get; set; }
        public bool Affirmative { get; set; } 
        //Constructor (default)
        public FormResult()
        {
            this.Object = null;
            this.Objects = new List<object>();
            this.Cancelled = true;
            this.Valid = false;
            this.Affirmative = false;
        }
        //Constructor (alternative)
        public FormResult(bool isValid)
        {
            this.Object = null;
            this.Objects = new List<object>();
            this.Cancelled = !isValid;
            this.Valid = isValid;
            this.Affirmative = isValid;
        }
        //Method
        public void Validate()
        {
            this.Cancelled = false;
            this.Valid = true;
            this.Affirmative = true;
        }

        public void Validate(object obj)
        {
            this.Validate();  
            this.Object = obj;
        }

        public void Validate(List<object> objs)
        {
            this.Validate();
            this.Objects = objs;
        }
    }
}
