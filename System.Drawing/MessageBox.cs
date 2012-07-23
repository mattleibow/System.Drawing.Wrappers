namespace System.Drawing
{
    using System;
    using Android;
    using Android.App;
    using Android.Views;

    public class AndroidFormsAdapter
    {
        public static View CurrentView { get; set; }
    }

    public class Form
    {
    }

    public class MessageBox
    {
        public static int Show(string text, string title)
        {
            var ad = new AlertDialog.Builder(AndroidFormsAdapter.CurrentView.Context);
            ad.SetMessage(text);
            ad.SetIcon(Resource.Drawable.IcMenuHelp);
            ad.SetTitle(title);
            ad.SetPositiveButton(Resource.String.Ok, (ob, args) => { });
            ad.Create().Show();
            return 0;
        }
    }

    public class MessageForm
    {
        private readonly AlertDialog.Builder ad;

        public MessageForm(object _base, string title, string[] body)
        {
            ad = new AlertDialog.Builder(AndroidFormsAdapter.CurrentView.Context);
            ad.SetMessage(body[0]); //TODO
            ad.SetIcon(Resource.Drawable.IcMenuHelp);
            ad.SetTitle(title);
            ad.SetPositiveButton(Resource.String.Ok, (ob, args) => { });
        }

        public int Show()
        {
            ad.Create().Show();
            return 0;
        }
    }

    public class PaintEventArgs
    {
        public PaintEventArgs(Graphics g, Rectangle r)
        {
            Graphics = g;
            ClipRectangle = r;
        }

        public Graphics Graphics { get; set; }
        public Rectangle ClipRectangle { get; set; }
    }

    public class Timer : IDisposable
    {
        private System.Timers.Timer cdt;
        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                //
                enabled = value;
                if (enabled)
                {
                    cdt = new System.Timers.Timer(Interval);
                    cdt.Elapsed += (sender, e) =>
                                       {
                                           Tick(this, e);
                                           cdt.Enabled = false;
                                       };
                    cdt.Enabled = true;
                }
            }
        }

        public int Interval { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

        public event EventHandler Tick;
    }
}