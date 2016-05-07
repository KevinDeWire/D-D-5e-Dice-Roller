using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Dungeons_and_Dragons_5e_Dice_Roller
{
    [Activity(Label = "DamageDice")]
    public class DamageDice : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "DamageDice" layout resource
            SetContentView(Resource.Layout.DamageDice);

            //  Define Constants
            const int UP = 1;
            const int DOWN = -1;

            //  Define variables
            int modifierValue = 0;
            int numOfDice = 1;
            int numOfSides;
            int totalValue = 0;

            //  Initialize random number generator for this activity
            Random generator = new Random(DateTime.Now.Millisecond);

            //  Create the dice for this activity
            MultipleDiceClass diceBag;

            // Get buttons from the layout resource
            ImageButton D20Button = FindViewById<ImageButton>(Resource.Id.D20ImageButton);
            ImageButton PercentileButton = FindViewById<ImageButton>(Resource.Id.PercentileImageButton);
            ImageButton AmountUpButton = FindViewById<ImageButton>(Resource.Id.AmountUpButton);
            ImageButton AmountDownButton = FindViewById<ImageButton>(Resource.Id.AmountDownButton);
            ImageButton ModifierUpButton = FindViewById<ImageButton>(Resource.Id.ModifierUpButton);
            ImageButton ModifierDownButton = FindViewById<ImageButton>(Resource.Id.ModifierDownButton);
            Button RollButton = FindViewById<Button>(Resource.Id.RollButton);

            // Get text fields from the layout resource
            TextView ModifierValueText = FindViewById<TextView>(Resource.Id.ModifierValueText);
            TextView AmountValueText = FindViewById<TextView>(Resource.Id.AmountValueText);
            TextView DieRollText = FindViewById<TextView>(Resource.Id.DieRollText);
            TextView TotalRollText = FindViewById<TextView>(Resource.Id.TotalRollText);

            //  Assign values to text fields
            AmountValueText.Text = numOfDice.ToString();
            ModifierValueText.Text = modifierValue.ToString();
            TotalRollText.Text = totalValue.ToString();

            //  Assign change activity actions.
            D20Button.Click += delegate
            {
                var d20Start = new Intent(this, typeof(d20));
                d20Start.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTop);
                StartActivity(d20Start);
            };

            PercentileButton.Click += delegate
            {
                var PercentileStart = new Intent(this, typeof(Percentile));
                PercentileStart.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTop);
                StartActivity(PercentileStart);
            };

            //  Assign Amount control actions
            AmountUpButton.Click += delegate
            {
                numOfDice = AmountAction(numOfDice, UP, AmountValueText);
            };

            AmountDownButton.Click += delegate
            {
                numOfDice = AmountAction(numOfDice, DOWN, AmountValueText);
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
                numOfSides = DetermineSides();

                diceBag = new MultipleDiceClass(numOfSides, numOfDice, generator.Next());

                DieRollText.Text = diceBag.ToString();
                totalValue = diceBag.Total() + modifierValue;
                TotalRollText.Text = totalValue.ToString();
            };

        }
        
        //  Checks the radio buttons to determine the number of sides to use.
        private int DetermineSides()
        {
            RadioButton d4RadioButton = FindViewById<RadioButton>(Resource.Id.d4RadioButton);
            RadioButton d6RadioButton = FindViewById<RadioButton>(Resource.Id.d6RadioButton);
            RadioButton d8RadioButton = FindViewById<RadioButton>(Resource.Id.d8RadioButton);
            RadioButton d10RadioButton = FindViewById<RadioButton>(Resource.Id.d10RadioButton);
            RadioButton d12RadioButton = FindViewById<RadioButton>(Resource.Id.d12RadioButton);
            RadioButton d20RadioButton = FindViewById<RadioButton>(Resource.Id.d20RadioButton);

            if (d4RadioButton.Checked)
                return 4;
            if (d6RadioButton.Checked)
                return 6;
            if (d8RadioButton.Checked)
                return 8;
            if (d10RadioButton.Checked)
                return 10;
            if (d12RadioButton.Checked)
                return 12;
            if (d20RadioButton.Checked)
                return 20;

            return 0;
        }

        //  Adds and subtracts from the amount value, preventing values less than 1.
        protected int AmountAction(int numOfDice, int adjustment, TextView amountText)
        {
            if (numOfDice > 1)
            {
                numOfDice = numOfDice + adjustment;
                amountText.Text = numOfDice.ToString();
                return numOfDice;
            }

            if (numOfDice == 1 && adjustment == 1)
            {
                numOfDice = numOfDice + adjustment;
                amountText.Text = numOfDice.ToString();
                return numOfDice;
            }

            return 1;
        }
        
        //  Adds and subtracts from the modifier value.
        protected int ModifierAction(int modifier, int adjustment, TextView modifierText)
        {
            modifier = modifier + adjustment;
            modifierText.Text = modifier.ToString();
            return modifier;
        }
    }
}