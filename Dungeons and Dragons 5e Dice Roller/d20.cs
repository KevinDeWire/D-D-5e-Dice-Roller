using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Dungeons_and_Dragons_5e_Dice_Roller
{
    [Activity(Label = "d20")]

    public class d20 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "d20" layout resource
            SetContentView(Resource.Layout.d20);

            //  Define Constants
            const int UP = 1;
            const int DOWN = -1;

            //  Define variables
            int modifierValue = 0;
            int d20RollValue = 0;
            int die1Value, die2Value;

            //  Initialize random number generator for this activity
            Random generator = new Random(DateTime.Now.Millisecond);

            //  Create the dice for this activity
            DieClass die1 = new DieClass(20, generator.Next());
            DieClass die2 = new DieClass(20, generator.Next());

            // Get buttons from the layout resource
            ImageButton DamageButton = FindViewById<ImageButton>(Resource.Id.DamageImageButton);
            ImageButton PercentileButton = FindViewById<ImageButton>(Resource.Id.PercentileImageButton);
            CheckBox AdvantageCheckBox = FindViewById<CheckBox>(Resource.Id.AdvantageCheckBox);
            CheckBox DisadvantageCheckBox = FindViewById<CheckBox>(Resource.Id.DisadvantageCheckBox);
            ImageButton ModifierUpButton = FindViewById<ImageButton>(Resource.Id.ModifierUpButton);
            ImageButton ModifierDownButton = FindViewById<ImageButton>(Resource.Id.ModifierDownButton);
            Button RollButton = FindViewById<Button>(Resource.Id.RollButton);

            // Get text fields from the layout resource
            TextView ModifierValueText = FindViewById<TextView>(Resource.Id.ModifierValueText);
            TextView d20RollText = FindViewById<TextView>(Resource.Id.d20RollText);

            //  Get images from the layout resource
            ImageView d20Left = FindViewById<ImageView>(Resource.Id.d20LeftImage);
            ImageView d20Right = FindViewById<ImageView>(Resource.Id.d20RightImage);
            ImageView d20LeftX = FindViewById<ImageView>(Resource.Id.LeftXImage);
            ImageView d20RightX = FindViewById<ImageView>(Resource.Id.RightXImage);

            //  Assign values to text fields
            ModifierValueText.Text = modifierValue.ToString();
            d20RollText.Text = d20RollValue.ToString();

            //  Assign change activity actions.
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

            //  Assign advantage/disadvantage check box actions.
            AdvantageCheckBox.Click += delegate
            {
                CheckBoxAction(DisadvantageCheckBox);
            };

            DisadvantageCheckBox.Click += delegate
            {
                CheckBoxAction(AdvantageCheckBox);
            };

            //  Assign Modifier control actions
            ModifierUpButton.Click += delegate
            {
                modifierValue = ModifierAction(modifierValue, UP, ModifierValueText);
            };

            ModifierDownButton.Click += delegate
            {
                modifierValue = ModifierAction(modifierValue, DOWN, ModifierValueText);
            };

            // ROLL DICE button actions
            RollButton.Click += delegate
            {
                die1Value = die1.RollDie();
                die2Value = die2.RollDie();

                DisplayDie(die1Value, d20Left);
                DisplayDie(die2Value, d20Right);

                d20Right.Visibility = ViewStates.Visible;       // This is to reset the die visibility after a single die being rolled


                if (AdvantageCheckBox.Checked)
                {
                    if (die1Value > die2Value)
                    {
                        d20RollValue = UseDie(d20LeftX, d20RightX, die1Value, modifierValue);
                        d20RollText.Text = d20RollValue.ToString();
                    }
                    else
                    {
                        d20RollValue = UseDie(d20RightX, d20LeftX, die2Value, modifierValue);
                        d20RollText.Text = d20RollValue.ToString();
                    }
                }
                else
                {
                    if (DisadvantageCheckBox.Checked)
                    {
                        if (die1Value > die2Value)
                        {
                            d20RollValue = UseDie(d20RightX, d20LeftX, die2Value, modifierValue);
                            d20RollText.Text = d20RollValue.ToString();
                        }
                        else
                        {
                            d20RollValue = UseDie(d20LeftX, d20RightX, die1Value, modifierValue);
                            d20RollText.Text = d20RollValue.ToString();
                        }
                    }
                    else
                    {
                        d20LeftX.Visibility = ViewStates.Invisible;
                        d20RightX.Visibility = ViewStates.Invisible;
                        d20Right.Visibility = ViewStates.Invisible;
                        d20RollText.Text = (die1Value + modifierValue).ToString();
                    }
                }
            };


        }

        //  Ensures that only one check box is checked at a time.
        protected void CheckBoxAction(CheckBox otherCheckBox)
        {
            if (otherCheckBox.Checked)
                otherCheckBox.Checked = false;
        }

        //  Adds and subtracts from the modifier value.
        protected int ModifierAction(int modifier, int adjustment, TextView modifierText)
        {
            modifier = modifier + adjustment;
            modifierText.Text = modifier.ToString();
            return modifier;
        }

        //  Displays the correct die image
        protected void DisplayDie(int die, ImageView dieImage)
        {
            switch(die)
            {
                case 1:
                    dieImage.SetImageResource(Resource.Drawable.d20_1);
                    break;
                case 2:
                    dieImage.SetImageResource(Resource.Drawable.d20_2);
                    break;
                case 3:
                    dieImage.SetImageResource(Resource.Drawable.d20_3);
                    break;
                case 4:
                    dieImage.SetImageResource(Resource.Drawable.d20_4);
                    break;
                case 5:
                    dieImage.SetImageResource(Resource.Drawable.d20_5);
                    break;
                case 6:
                    dieImage.SetImageResource(Resource.Drawable.d20_6);
                    break;
                case 7:
                    dieImage.SetImageResource(Resource.Drawable.d20_7);
                    break;
                case 8:
                    dieImage.SetImageResource(Resource.Drawable.d20_8);
                    break;
                case 9:
                    dieImage.SetImageResource(Resource.Drawable.d20_9);
                    break;
                case 10:
                    dieImage.SetImageResource(Resource.Drawable.d20_10);
                    break;
                case 11:
                    dieImage.SetImageResource(Resource.Drawable.d20_11);
                    break;
                case 12:
                    dieImage.SetImageResource(Resource.Drawable.d20_12);
                    break;
                case 13:
                    dieImage.SetImageResource(Resource.Drawable.d20_13);
                    break;
                case 14:
                    dieImage.SetImageResource(Resource.Drawable.d20_14);
                    break;
                case 15:
                    dieImage.SetImageResource(Resource.Drawable.d20_15);
                    break;
                case 16:
                    dieImage.SetImageResource(Resource.Drawable.d20_16);
                    break;
                case 17:
                    dieImage.SetImageResource(Resource.Drawable.d20_17);
                    break;
                case 18:
                    dieImage.SetImageResource(Resource.Drawable.d20_18);
                    break;
                case 19:
                    dieImage.SetImageResource(Resource.Drawable.d20_19);
                    break;
                case 20:
                    dieImage.SetImageResource(Resource.Drawable.d20_20);
                    break;
                default:
                    break;
            }
        }

        // Returns the die value plus the modifier while also diplaying an X over the value not used
        int UseDie(ImageView image1, ImageView image2, int dieValue, int modifierValue)
        {
            image1.Visibility = ViewStates.Invisible;
            image2.Visibility = ViewStates.Visible;

            return (dieValue + modifierValue);
        }
    }
}