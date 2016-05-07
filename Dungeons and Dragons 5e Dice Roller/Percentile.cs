using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Dungeons_and_Dragons_5e_Dice_Roller
{
    [Activity(Label = "Percentile")]
    public class Percentile : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Percentile" layout resource
            SetContentView(Resource.Layout.Percentile);

            //  Define variables
            int PercentileValue = 0;
            int die1Value, die2Value;

            //  Initialize random number generator for this activity
            Random generator = new Random(DateTime.Now.Millisecond);

            //  Create the dice for this activity
            DieClass die1 = new DieClass(10, generator.Next());
            DieClass die2 = new DieClass(10, generator.Next());

            // Get buttons from the layout resource
            ImageButton D20Button = FindViewById<ImageButton>(Resource.Id.D20ImageButton);
            ImageButton DamageButton = FindViewById<ImageButton>(Resource.Id.DamageImageButton);
            Button RollButton = FindViewById<Button>(Resource.Id.RollButton);

            // Get text fields from the layout resource
            TextView PercentileRollText = FindViewById<TextView>(Resource.Id.PercentileRollText);

            //  Get images from the layout resource
            ImageView TensDieImage = FindViewById<ImageView>(Resource.Id.TensDieImage);
            ImageView OnesDieImage = FindViewById<ImageView>(Resource.Id.OnesDieImage);

            //  Assign values to text fields
            PercentileRollText.Text = PercentileValue.ToString();

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

            // ROLL DICE button actions
            RollButton.Click += delegate
            {
                PercentileValue = 0;

                die1Value = die1.RollDie() * 10;
                die2Value = die2.RollDie() - 1;

                DisplayDie(die1Value, TensDieImage);
                DisplayDie(die2Value, OnesDieImage);

                if (die1Value == 100)
                    PercentileValue = die2Value;
                else
                    PercentileValue = die1Value + die2Value;

                if (PercentileValue == 0)
                    PercentileRollText.Text = ("100");
                else
                    PercentileRollText.Text = PercentileValue.ToString();
            };
        }

        //  Displays the correct die image
        protected void DisplayDie(int die, ImageView dieImage)
        {
            switch (die)
            {
                case 1:
                    dieImage.SetImageResource(Resource.Drawable.d10_1);
                    break;
                case 2:
                    dieImage.SetImageResource(Resource.Drawable.d10_2);
                    break;
                case 3:
                    dieImage.SetImageResource(Resource.Drawable.d10_3);
                    break;
                case 4:
                    dieImage.SetImageResource(Resource.Drawable.d10_4);
                    break;
                case 5:
                    dieImage.SetImageResource(Resource.Drawable.d10_5);
                    break;
                case 6:
                    dieImage.SetImageResource(Resource.Drawable.d10_6);
                    break;
                case 7:
                    dieImage.SetImageResource(Resource.Drawable.d10_7);
                    break;
                case 8:
                    dieImage.SetImageResource(Resource.Drawable.d10_8);
                    break;
                case 9:
                    dieImage.SetImageResource(Resource.Drawable.d10_9);
                    break;
                case 0:
                    dieImage.SetImageResource(Resource.Drawable.d10_0);
                    break;
                case 10:
                    dieImage.SetImageResource(Resource.Drawable.d10_10);
                    break;
                case 20:
                    dieImage.SetImageResource(Resource.Drawable.d10_20);
                    break;
                case 30:
                    dieImage.SetImageResource(Resource.Drawable.d10_30);
                    break;
                case 40:
                    dieImage.SetImageResource(Resource.Drawable.d10_40);
                    break;
                case 50:
                    dieImage.SetImageResource(Resource.Drawable.d10_50);
                    break;
                case 60:
                    dieImage.SetImageResource(Resource.Drawable.d10_60);
                    break;
                case 70:
                    dieImage.SetImageResource(Resource.Drawable.d10_70);
                    break;
                case 80:
                    dieImage.SetImageResource(Resource.Drawable.d10_80);
                    break;
                case 90:
                    dieImage.SetImageResource(Resource.Drawable.d10_90);
                    break;
                case 100:
                    dieImage.SetImageResource(Resource.Drawable.d10_00);
                    break;
                default:
                    break;
            }
        }
    }
}