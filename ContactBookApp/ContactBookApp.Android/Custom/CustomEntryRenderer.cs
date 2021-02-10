using Android.Content;
using Android.Views;
using Android.Widget;
using ContactBookApp.Droid.Custom;
using ContactBookApp.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ContactBookApp.Droid.Custom
{
    class CustomEntryRenderer : EntryCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context) as EntryCellView;

            if (cell != null)
            {
                var textField = cell.EditText as TextView;
                textField.SetBackgroundColor(Android.Graphics.Color.Argb(0, 0, 0, 0));

            }

            return cell;
        }
    }
}