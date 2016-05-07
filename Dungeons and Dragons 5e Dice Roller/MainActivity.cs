using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace Dungeons_and_Dragons_5e_Dice_Roller
{
    [Activity(Label = "Dungeons & Dragons 5e Dice Roller", MainLauncher = true, Icon = "@drawable/d20_20")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get buttons from the layout resource
            ImageButton D20Button = FindViewById<ImageButton>(Resource.Id.D20ImageButton);
            ImageButton DamageButton = FindViewById<ImageButton>(Resource.Id.DamageImageButton);
            ImageButton PercentileButton = FindViewById<ImageButton>(Resource.Id.PercentileImageButton);

            //  Assign change activity actions.
            D20Button.Click += delegate
            {
                var d20Start = new Intent(this, typeof(d20));
                d20Start.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTop);
                StartActivity(d20Start);
            };

            DamageButton.Click += delegate
            {
                var DamageStart = new Intent(this, typeof(DamageDice));
                DamageStart.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTop);
                StartActivity(DamageStart);
            };

            PercentileButton.Click += delegate
            {
                var PercentileStart = new Intent(this, typeof(Percentile));
                PercentileStart.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTop);
                StartActivity(PercentileStart);
            };
        }
    }
}

