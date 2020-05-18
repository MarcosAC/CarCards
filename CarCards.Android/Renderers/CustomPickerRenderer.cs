﻿using Android.Content;
using Android.Graphics.Drawables;
using CarCards.Controls;
using CarCards.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace CarCards.Droid.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }
    }
}
