namespace System.Drawing
{
    using System;
    using System.Collections.Generic;

    namespace ComponentModel
    {
        public class BindingList<T> : List<T>
        {
        }
    }

    namespace Windows.Forms
    {
        public class Application
        {
            public static void DoEvents()
            {
                //throw new NotSupportedException("DoEvents not supported");
                //DOES NOTHING
            }

            public static void Run(object form)
            {
                throw new NotSupportedException("Not supported");
            }
        }

        namespace ComboBox
        {
            public class ObjectCollection
            {
                public void Add(object o)
                {
                }
            }
        }
    }
}