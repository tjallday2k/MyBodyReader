using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
namespace MyBodyReader
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var LabelStyle = new Style(typeof(Label))
            {
                Setters = {
        new Setter {Property = Label.FontSizeProperty, Value = 50}
    }
            };
            var header = new Style(typeof(Label))
            {
                Setters = {
        new Setter {Property = Label.FontSizeProperty, Value = 20}
    }
            };
            var info = new Style(typeof(Label))
            {
                Setters = {
        new Setter {Property = Label.FontSizeProperty, Value = 15}
    }
            };
            var personal = new Style(typeof(Label))
            {
                Setters = {
        new Setter {Property = Label.FontSizeProperty, Value = 25}
    }
            };
            Label title = new Label
            {
                Text = "MyBodyReader",
                Style = LabelStyle,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                BackgroundColor = Color.Gold
            };
            var unit = new List<string>();
            unit.Add("US (in and lbs)");
            unit.Add("Metric (cm and kg)");
            var picker = new Picker { Title = "Pick A Unit Of Measure", Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            picker.ItemsSource = unit;
            picker.SelectedIndex = 0;
            var Gender = new List<string>();
            Gender.Add("Male");
            Gender.Add("Female");
            var pick = new Picker { Title = "Pick A Gender", Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            pick.ItemsSource = Gender;
            pick.SelectedIndex = 0;
            var Active = new List<string>();
            Active.Add("Sedentary");
            Active.Add("Lightly Active");
            Active.Add("Moderately Active");
            Active.Add("Very Active");
            Active.Add("Extremely Active");
            var pickers = new Picker { Title = "Pick Activity Level", Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            pickers.ItemsSource = Active;
            pickers.SelectedIndex = 0;
            var goal = new List<string>();
            goal.Add("Lose Fast");
            goal.Add("Lose Normal");
            goal.Add("Maintain");
            goal.Add("Gain Normal");
            goal.Add("Gain Fast");
            var Pick = new Picker { Title = "Pick Weight Goal", Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            Pick.ItemsSource = goal;
            Pick.SelectedIndex = 0;
            void Entry_Completed(object sender, EventArgs e)
            {
                var text = ((Entry)sender).Text; //cast sender to access the properties of the Entry
            }
            void Entry_TextChanged(object sender, TextChangedEventArgs e)
            {
                var oldText = e.OldTextValue;
                var newText = e.NewTextValue;
            }
            var Age = new Entry { Placeholder = "Enter Age", Keyboard = Keyboard.Numeric, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, ReturnType = ReturnType.Next, Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            Age.Completed += Entry_Completed;
            Age.TextChanged += Entry_TextChanged;
            var Height = new Entry { Placeholder = "Enter Height", Keyboard = Keyboard.Numeric, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, ReturnType = ReturnType.Next, Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            Height.Completed += Entry_Completed;
            Height.TextChanged += Entry_TextChanged;
            var Weight = new Entry { Placeholder = "Enter Weight", Keyboard = Keyboard.Numeric, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, ReturnType = ReturnType.Next, Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            Weight.Completed += Entry_Completed;
            Weight.TextChanged += Entry_TextChanged;
            var Waist = new Entry { Placeholder = "Enter Waist Circumference", Keyboard = Keyboard.Numeric, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, ReturnType = ReturnType.Next, Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            Waist.Completed += Entry_Completed;
            Waist.TextChanged += Entry_TextChanged;
            var Neck = new Entry { Placeholder = "Enter Neck Circumference", Keyboard = Keyboard.Numeric, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, ReturnType = ReturnType.Next, Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            Neck.Completed += Entry_Completed;
            Neck.TextChanged += Entry_TextChanged;
            var Hip = new Entry { Placeholder = "Enter Hip Circumference", Keyboard = Keyboard.Numeric, ClearButtonVisibility = ClearButtonVisibility.WhileEditing, ReturnType = ReturnType.Next, Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
            Hip.Completed += Entry_Completed;
            Hip.TextChanged += Entry_TextChanged;
            Button enter = new Button { Text = "Enter For Results", Style = personal, FontAttributes = FontAttributes.Bold, TextColor = Color.Gold, BackgroundColor = Color.Black };
            enter.Clicked += OnButtonClicked;
            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Gold,
                Children =
                {
                    title,picker,pick,Age,Height,Weight,Waist,Neck,Hip,pickers,Pick,enter
                }
            };
            ScrollView scrollView = new ScrollView
            {
                Content = stackLayout
            };
            Content = scrollView;
            void OnButtonClicked(object sender, EventArgs e)
            {
                    if (Age.Text == null)
                    {
                        Age.Text = "0";
                    }
                    if (Height.Text == null)
                    {
                        Height.Text = "0";
                    }
                    if (Weight.Text == null)
                    {
                        Weight.Text = "0";
                    }
                    if (Waist.Text == null)
                    {
                        Waist.Text = "0";
                    }
                    if (Neck.Text == null)
                    {
                        Neck.Text = "0";
                    }
                    if (Hip.Text == null)
                    {
                        Hip.Text = "0";
                    }
                string m = null;
                string measurement = picker.SelectedItem.ToString();
                string gender = pick.SelectedItem.ToString();
                string active = pickers.SelectedItem.ToString();
                string plan = Pick.SelectedItem.ToString();
                double age = double.Parse(Age.Text);
                double height = double.Parse(Height.Text);
                double weight = double.Parse(Weight.Text);
                double waist = double.Parse(Waist.Text);
                double neck = double.Parse(Neck.Text);
                double hip = double.Parse(Hip.Text);
                double bmi, bfp, fm, lm, whe, whi, bmr, need, start, ibw, bsa;
                bmi = 0;
                bfp = 0;
                fm = 0;
                lm = 0;
                whe = 0;
                whi = 0;
                bmr = 0;
                need = 0;
                start = 0;
                ibw = 0;
                bsa = 0;
                double carbs, proteins, fats, water;
                water = 0;
                double vitaminA, vitaminC, vitaminD, vitaminE, vitaminK, vitaminB1, vitaminB2, vitaminB3, vitaminB5, vitaminB7, vitaminB6, vitaminB12, vitaminB9, choline;
                vitaminA = 0;
                vitaminC = 0;
                vitaminD = 0;
                vitaminE = 0;
                vitaminK = 0;
                vitaminB1 = 0;
                vitaminB2 = 0;
                vitaminB3 = 0;
                vitaminB5 = 0;
                vitaminB7 = 0;
                vitaminB6 = 0;
                vitaminB12 = 0;
                vitaminB9 = 0;
                choline = 0;
                double magnesium, calcium, zinc, iron, copper, selenium, manganese, phosphorus, potassium, iodine, chromium, molybdenum, sodium, fluoride, chloride;
                magnesium = 0;
                calcium = 0;
                zinc = 0;
                iron = 0;
                copper = 0;
                selenium = 0;
                manganese = 0;
                phosphorus = 0;
                potassium = 0;
                iodine = 0;
                chromium = 0;
                molybdenum = 0;
                fluoride = 0;
                sodium = 2300;
                chloride = 0;
                string bmiRead = null;
                string bfRead = null;
                string wheRead = null;
                string whiRead = null;
                switch (measurement)
                {
                    case "US (in and lbs)":
                        switch (gender)
                        {
                            case "Male":
                                bsa = Math.Sqrt(((height * 2.54) * (weight / 2.205)) / 3600);
                                ibw = (50 + (0.91 * ((height * 2.54) - 152.4))) * 2.205;
                                m = "lbs";
                                bmi = (703 * weight) / (height * height);
                                bfp = (495 / (1.0324 - 0.19077 * Math.Log10((2.54 * waist) - (2.54 * neck)) + 0.15456 * Math.Log10(2.54 * height))) - 450;
                                fm = (bfp * .01) * weight;
                                lm = weight - fm;
                                whe = waist / height;
                                whi = waist / hip;
                                bmr = 66 + (6.3 * weight) + (12.9 * height) - (6.8 * age);
                                water = (weight * (0.5));
                                if (bmi < 15)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Underweight.";
                                }
                                if (bmi >= 15 && bmi < 16)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Underweight.";
                                }
                                if (bmi >= 16 && bmi < 18.5)
                                {
                                    bmiRead = "Based On Your BMI, You Are Underweight.";
                                }
                                if (bmi >= 18.5 && bmi < 25)
                                {
                                    bmiRead = "Based On Your BMI, You Are Normal.";
                                }
                                if (bmi > 25 && bmi < 30)
                                {
                                    bmiRead = "Based On Your BMI, You Are Overweight.";
                                }
                                if (bmi >= 30 && bmi < 35)
                                {
                                    bmiRead = "Based On Your BMI, You Are Moderately Obese.";
                                }
                                if (bmi >= 35 && bmi < 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Obese.";
                                }
                                if (bmi >= 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Obese.";
                                }
                                if (bfp < 6)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You Have Only Essential Fat.";
                                }
                                if (bfp >= 6 && bfp < 14)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're An Athlete.";
                                }
                                if (bfp >= 14 && bfp < 18)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Fit";
                                }
                                if (bfp >= 18 && bfp < 25)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Average";
                                }
                                if (bfp >= 25)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Obese";
                                }
                                if (whe >= 0.63)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Highly Obese.";
                                }
                                if (whe < 0.63 && whe >= 0.58)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Overweight.";
                                }
                                if (whe < 0.58 && whe >= 0.53)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Overweight.";
                                }
                                if (whe < 0.53 && whe >= 0.46)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Healthy.";
                                }
                                if (whe < 0.46 && whe >= 0.43)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Slender And Healthy.";
                                }
                                if (whe < 0.43 && whe >= 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Slim.";
                                }
                                if (whe < 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Abnormally Slim.";
                                }
                                if (whi < 0.85)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Excellent.";
                                }
                                if (whi >= 0.85 && whi < 0.90)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Good.";
                                }
                                if (whi >= 0.90 && whi < 0.95)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Average.";
                                }
                                if (whi >= 0.95)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Bad.";
                                }
                                break;
                            case "Female":
                                bsa = Math.Sqrt(((height * 2.54) * (weight / 2.205)) / 3600);
                                ibw = (45.5 + (0.91 * ((height * 2.54) - 152.4))) * 2.205;
                                m = "lbs";
                                bmi = (703 * weight) / (height * height);
                                bfp = (495 / (1.29579 - 0.35004 * Math.Log10((2.54 * waist) + (2.54 * hip) - (2.54 * neck)) + 0.22100 * Math.Log10(2.54 * height))) - 450;
                                fm = (bfp * .01) * weight;
                                lm = weight - fm;
                                whe = waist / height;
                                whi = waist / hip;
                                bmr = 655 + (4.3 * weight) + (4.7 * height) - (4.7 * age);
                                water = (weight * (0.5));
                                if (bmi < 15)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Underweight.";
                                }
                                if (bmi >= 15 && bmi < 16)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Underweight.";
                                }
                                if (bmi >= 16 && bmi < 18.5)
                                {
                                    bmiRead = "Based On Your BMI, You Are Underweight.";
                                }
                                if (bmi >= 18.5 && bmi < 25)
                                {
                                    bmiRead = "Based On Your BMI, You Are Normal.";
                                }
                                if (bmi > 25 && bmi < 30)
                                {
                                    bmiRead = "Based On Your BMI, You Are Overweight.";
                                }
                                if (bmi >= 30 && bmi < 35)
                                {
                                    bmiRead = "Based On Your BMI, You Are Moderately Obese.";
                                }
                                if (bmi >= 35 && bmi < 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Obese.";
                                }
                                if (bmi >= 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Obese.";
                                }
                                if (bfp < 14)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You Have Only Essential Fat.";
                                }
                                if (bfp >= 14 && bfp < 21)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're An Athlete.";
                                }
                                if (bfp >= 21 && bfp < 25)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Fit";
                                }
                                if (bfp >= 25 && bfp < 32)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Average";
                                }
                                if (bfp >= 32)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Obese";
                                }
                                if (whe >= 0.58)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Highly Obese.";
                                }
                                if (whe < 0.58 && whe >= 0.54)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Overweight.";
                                }
                                if (whe < 0.54 && whe >= 0.49)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Overweight.";
                                }
                                if (whe < 0.49 && whe >= 0.46)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Healthy.";
                                }
                                if (whe < 0.46 && whe >= 0.42)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Slender And Healthy.";
                                }
                                if (whe < 0.42 && whe >= 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Slim.";
                                }
                                if (whe < 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Abnormally Slim.";
                                }
                                if (whi < 0.75)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Excellent.";
                                }
                                if (whi >= 0.75 && whi < 0.80)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Good.";
                                }
                                if (whi >= 0.80 && whi < 0.86)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Average.";
                                }
                                if (whi >= 0.86)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Bad.";
                                }
                                break;
                        }
                        break;
                    case "Metric (cm and kg)":
                        switch (gender)
                        {
                            case "Male":
                                bsa = Math.Sqrt((height * weight) / 3600);
                                ibw = 50 + (0.91 * (height - 152.4));
                                m = "kg";
                                bmi = (weight / (height * height)) * 10000;
                                bfp = (495 / (1.0324 - 0.19077 * Math.Log10(waist - neck) + 0.15456 * Math.Log10(height))) - 450;
                                fm = (bfp * .01) * weight;
                                lm = weight - fm;
                                whe = waist / height;
                                whi = waist / hip;
                                bmr = 66 + (6.3 * (weight / 2.205)) + (12.9 * (height / 2.54)) - (6.8 * age);
                                water = ((weight * 2.205) * (0.5));
                                if (bmi < 15)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Underweight.";
                                }
                                if (bmi >= 15 && bmi < 16)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Underweight.";
                                }
                                if (bmi >= 16 && bmi < 18.5)
                                {
                                    bmiRead = "Based On Your BMI, You Are Underweight.";
                                }
                                if (bmi >= 18.5 && bmi < 25)
                                {
                                    bmiRead = "Based On Your BMI, You Are Normal.";
                                }
                                if (bmi > 25 && bmi < 30)
                                {
                                    bmiRead = "Based On Your BMI, You Are Overweight.";
                                }
                                if (bmi >= 30 && bmi < 35)
                                {
                                    bmiRead = "Based On Your BMI, You Are Moderately Obese.";
                                }
                                if (bmi >= 35 && bmi < 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Obese.";
                                }
                                if (bmi >= 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Obese.";
                                }
                                if (bfp < 6)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You Have Only Essential Fat.";
                                }
                                if (bfp >= 6 && bfp < 14)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're An Athlete.";
                                }
                                if (bfp >= 14 && bfp < 18)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Fit";
                                }
                                if (bfp >= 18 && bfp < 25)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Average";
                                }
                                if (bfp >= 25)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Obese";
                                }
                                if (whe >= 0.63)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Highly Obese.";
                                }
                                if (whe < 0.63 && whe >= 0.58)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Overweight.";
                                }
                                if (whe < 0.58 && whe >= 0.53)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Overweight.";
                                }
                                if (whe < 0.53 && whe >= 0.46)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Healthy.";
                                }
                                if (whe < 0.46 && whe >= 0.43)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Slender And Healthy.";
                                }
                                if (whe < 0.43 && whe >= 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Slim.";
                                }
                                if (whe < 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Abnormally Slim.";
                                }
                                if (whi < 0.85)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Excellent.";
                                }
                                if (whi >= 0.85 && whi < 0.90)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Good.";
                                }
                                if (whi >= 0.90 && whi < 0.95)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Average.";
                                }
                                if (whi >= 0.95)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Bad.";
                                }
                                break;
                            case "Female":
                                bsa = Math.Sqrt((height * weight) / 3600);
                                ibw = 45.5 + (0.91 * (height - 152.4));
                                m = "kg";
                                bmi = (weight / (height * height)) * 10000;
                                bfp = (495 / (1.29579 - 0.35004 * Math.Log10(waist + hip - neck) + 0.22100 * Math.Log10(height))) - 450;
                                fm = (bfp * .01) * weight;
                                lm = weight - fm;
                                whe = waist / height;
                                whi = waist / hip;
                                bmr = 655 + (4.3 * (weight / 2.205)) + (4.7 * (height / 2.54)) - (4.7 * age);
                                water = ((weight * 2.205) * (0.5));
                                if (bmi < 15)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Underweight.";
                                }
                                if (bmi >= 15 && bmi < 16)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Underweight.";
                                }
                                if (bmi >= 16 && bmi < 18.5)
                                {
                                    bmiRead = "Based On Your BMI, You Are Underweight.";
                                }
                                if (bmi >= 18.5 && bmi < 25)
                                {
                                    bmiRead = "Based On Your BMI, You Are Normal.";
                                }
                                if (bmi > 25 && bmi < 30)
                                {
                                    bmiRead = "Based On Your BMI, You Are Overweight.";
                                }
                                if (bmi >= 30 && bmi < 35)
                                {
                                    bmiRead = "Based On Your BMI, You Are Moderately Obese.";
                                }
                                if (bmi >= 35 && bmi < 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Severely Obese.";
                                }
                                if (bmi >= 40)
                                {
                                    bmiRead = "Based On Your BMI, You Are Very Severely Obese.";
                                }
                                if (bfp < 14)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You Have Only Essential Fat.";
                                }
                                if (bfp >= 14 && bfp < 21)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're An Athlete.";
                                }
                                if (bfp >= 21 && bfp < 25)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Fit";
                                }
                                if (bfp >= 25 && bfp < 32)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Average";
                                }
                                if (bfp >= 32)
                                {
                                    bfRead = "Based On Your Body Fat Percentage, You're Obese";
                                }
                                if (whe >= 0.58)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Highly Obese.";
                                }
                                if (whe < 0.58 && whe >= 0.54)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Overweight.";
                                }
                                if (whe < 0.54 && whe >= 0.49)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Overweight.";
                                }
                                if (whe < 0.49 && whe >= 0.46)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Healthy.";
                                }
                                if (whe < 0.46 && whe >= 0.42)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Slender And Healthy.";
                                }
                                if (whe < 0.42 && whe >= 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Extremely Slim.";
                                }
                                if (whe < 0.35)
                                {
                                    wheRead = "Based On Your Waist To Height Ratio, You Are Abnormally Slim.";
                                }
                                if (whi < 0.75)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Excellent.";
                                }
                                if (whi >= 0.75 && whi < 0.80)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Good.";
                                }
                                if (whi >= 0.80 && whi < 0.86)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Average.";
                                }
                                if (whi >= 0.86)
                                {
                                    whiRead = "Your Waist To Hip Ratio Is Bad.";
                                }
                                break;
                        }
                        break;
                }
                if (active == "Sedentary")
                {
                    start = bmr * 1.2;
                    if (plan == "Gain Fast")
                    {
                        need = start * 1.4;
                    }
                    if (plan == "Gain Normal")
                    {
                        need = start * 1.2;
                    }
                    if (plan == "Maintain")
                    {
                        need = start;
                    }
                    if (plan == "Lose Normal")
                    {
                        need = start * 0.8;
                    }
                    if (plan == "Lose Fast")
                    {
                        need = start * 0.6;
                    }
                }
                if (active == "Lightly Active")
                {
                    start = bmr * 1.375;
                    water = water + 12;
                    if (plan == "Gain Fast")
                    {
                        need = start * 1.4;
                    }
                    if (plan == "Gain Normal")
                    {
                        need = start * 1.2;
                    }
                    if (plan == "Maintain")
                    {
                        need = start;
                    }
                    if (plan == "Lose Normal")
                    {
                        need = start * 0.8;
                    }
                    if (plan == "Lose Fast")
                    {
                        need = start * 0.6;
                    }
                }
                if (active == "Moderately Active")
                {
                    start = bmr * 1.55;
                    water = water + 24;
                    if (plan == "Gain Fast")
                    {
                        need = start * 1.4;
                    }
                    if (plan == "Gain Normal")
                    {
                        need = start * 1.2;
                    }
                    if (plan == "Maintain")
                    {
                        need = start;
                    }
                    if (plan == "Lose Normal")
                    {
                        need = start * 0.8;
                    }
                    if (plan == "Lose Fast")
                    {
                        need = start * 0.6;
                    }
                }
                if (active == "Very Active")
                {
                    start = bmr * 1.725;
                    water = water + 36;
                    if (plan == "Gain Fast")
                    {
                        need = start * 1.4;
                    }
                    if (plan == "Gain Normal")
                    {
                        need = start * 1.2;
                    }
                    if (plan == "Maintain")
                    {
                        need = start;
                    }
                    if (plan == "Lose Normal")
                    {
                        need = start * 0.8;
                    }
                    if (plan == "Lose Fast")
                    {
                        need = start * 0.6;
                    }
                }
                if (active == "Extremely Active")
                {
                    start = bmr * 1.9;
                    water = water + 48;
                    if (plan == "Gain Fast")
                    {
                        need = start * 1.4;
                    }
                    if (plan == "Gain Normal")
                    {
                        need = start * 1.2;
                    }
                    if (plan == "Maintain")
                    {
                        need = start;
                    }
                    if (plan == "Lose Normal")
                    {
                        need = start * 0.8;
                    }
                    if (plan == "Lose Fast")
                    {
                        need = start * 0.6;
                    }
                }
                carbs = (need * .4) / 4;
                proteins = (need * .3) / 4;
                fats = (need * 0.3) / 9;
                if (age < 0.5)
                {
                    vitaminA = 400;
                    vitaminC = 40;
                    vitaminD = 10;
                    vitaminE = 4;
                    vitaminK = 2;
                    vitaminB1 = 0.2;
                    vitaminB2 = 0.3;
                    vitaminB3 = 2;
                    vitaminB5 = 1.7;
                    vitaminB7 = 5;
                    vitaminB6 = 0.1;
                    vitaminB12 = 0.4;
                    vitaminB9 = 65;
                    choline = 125;
                    magnesium = 30;
                    calcium = 200;
                    zinc = 2;
                    iron = 0.27;
                    copper = 200;
                    selenium = 20;
                    manganese = 0.6;
                    phosphorus = 100;
                    potassium = 400;
                    iodine = 110;
                    chromium = 0.2;
                    molybdenum = 2;
                    fluoride = 0.01;
                    chloride = 1.5;
                }
                if (age >= 0.5 && age < 1)
                {
                    vitaminA = 500;
                    vitaminC = 50;
                    vitaminD = 10;
                    vitaminE = 5;
                    vitaminK = 2.5;
                    vitaminB1 = 0.3;
                    vitaminB2 = 0.4;
                    vitaminB3 = 4;
                    vitaminB5 = 1.8;
                    vitaminB7 = 6;
                    vitaminB6 = 0.3;
                    vitaminB12 = 0.5;
                    vitaminB9 = 80;
                    choline = 150;
                    magnesium = 75;
                    calcium = 260;
                    zinc = 3;
                    iron = 11;
                    copper = 200;
                    selenium = 15;
                    manganese = 0.003;
                    phosphorus = 275;
                    potassium = 860;
                    iodine = 130;
                    chromium = 5.5;
                    molybdenum = 3;
                    fluoride = 0.5;
                    chloride = 1.5;
                }
                if (age >= 1 && age < 4)
                {
                    vitaminA = 300;
                    vitaminC = 15;
                    vitaminD = 15;
                    vitaminE = 6;
                    vitaminK = 30;
                    vitaminB1 = 0.5;
                    vitaminB2 = 0.5;
                    vitaminB3 = 6;
                    vitaminB5 = 2;
                    vitaminB7 = 8;
                    vitaminB6 = 0.5;
                    vitaminB12 = 0.9;
                    vitaminB9 = 150;
                    choline = 200;
                    magnesium = 80;
                    calcium = 700;
                    zinc = 3;
                    iron = 7;
                    copper = 340;
                    selenium = 20;
                    manganese = 1.2;
                    phosphorus = 460;
                    potassium = 2000;
                    iodine = 90;
                    chromium = 11;
                    molybdenum = 17;
                    fluoride = 0.6;
                    chloride = 1.5;
                }
                if (age >= 4 && age < 9)
                {
                    vitaminA = 400;
                    vitaminC = 25;
                    vitaminD = 15;
                    vitaminE = 7;
                    vitaminK = 55;
                    vitaminB1 = 0.6;
                    vitaminB2 = 0.6;
                    vitaminB3 = 8;
                    vitaminB5 = 3;
                    vitaminB7 = 12;
                    vitaminB6 = 0.6;
                    vitaminB12 = 1.2;
                    vitaminB9 = 200;
                    choline = 250;
                    magnesium = 130;
                    calcium = 1000;
                    zinc = 5;
                    iron = 10;
                    copper = 440;
                    selenium = 30;
                    manganese = 1.5;
                    phosphorus = 500;
                    potassium = 2300;
                    iodine = 90;
                    chromium = 15;
                    molybdenum = 22;
                    fluoride = 1.1;
                    chloride = 1.9;
                }
                if (age >= 9 && age < 14 && gender == "Male")
                {
                    vitaminA = 600;
                    vitaminC = 45;
                    vitaminD = 15;
                    vitaminE = 11;
                    vitaminK = 60;
                    vitaminB1 = 0.9;
                    vitaminB2 = 0.9;
                    vitaminB3 = 12;
                    vitaminB5 = 4;
                    vitaminB7 = 20;
                    vitaminB6 = 1;
                    vitaminB12 = 1.8;
                    vitaminB9 = 400;
                    choline = 375;
                    magnesium = 240;
                    calcium = 1300;
                    zinc = 8;
                    iron = 8;
                    copper = 700;
                    selenium = 40;
                    manganese = 1.9;
                    phosphorus = 1250;
                    potassium = 2500;
                    iodine = 120;
                    chromium = 25;
                    molybdenum = 34;
                    fluoride = 2;
                    chloride = 2.3;
                }
                if (age >= 9 && age < 14 && gender == "Female")
                {
                    vitaminA = 600;
                    vitaminC = 45;
                    vitaminD = 15;
                    vitaminE = 11;
                    vitaminK = 60;
                    vitaminB1 = 0.9;
                    vitaminB2 = 0.9;
                    vitaminB3 = 12;
                    vitaminB5 = 4;
                    vitaminB7 = 20;
                    vitaminB6 = 1;
                    vitaminB12 = 1.8;
                    vitaminB9 = 400;
                    choline = 375;
                    magnesium = 240;
                    calcium = 1300;
                    zinc = 8;
                    iron = 8;
                    copper = 700;
                    selenium = 40;
                    manganese = 1.6;
                    phosphorus = 1250;
                    potassium = 2300;
                    iodine = 120;
                    chromium = 21;
                    molybdenum = 34;
                    fluoride = 2;
                    chloride = 2.3;
                }
                if (age >= 14 && age < 19 && gender == "Male")
                {
                    vitaminA = 900;
                    vitaminC = 75;
                    vitaminD = 15;
                    vitaminE = 15;
                    vitaminK = 75;
                    vitaminB1 = 1.2;
                    vitaminB2 = 1.3;
                    vitaminB3 = 16;
                    vitaminB5 = 5;
                    vitaminB7 = 25;
                    vitaminB6 = 1.3;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 550;
                    magnesium = 410;
                    calcium = 1300;
                    zinc = 11;
                    iron = 11;
                    copper = 890;
                    selenium = 55;
                    manganese = 2.2;
                    phosphorus = 1250;
                    potassium = 3000;
                    iodine = 150;
                    chromium = 35;
                    molybdenum = 43;
                    fluoride = 3;
                    chloride = 2.3;
                }
                if (age >= 14 && age < 19 && gender == "Female")
                {
                    vitaminA = 700;
                    vitaminC = 65;
                    vitaminD = 15;
                    vitaminE = 15;
                    vitaminK = 75;
                    vitaminB1 = 1;
                    vitaminB2 = 1;
                    vitaminB3 = 14;
                    vitaminB5 = 5;
                    vitaminB7 = 25;
                    vitaminB6 = 1.2;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 400;
                    magnesium = 360;
                    calcium = 1300;
                    zinc = 9;
                    iron = 15;
                    copper = 890;
                    selenium = 55;
                    manganese = 1.6;
                    phosphorus = 1250;
                    potassium = 2300;
                    iodine = 150;
                    chromium = 24;
                    molybdenum = 43;
                    fluoride = 3;
                    chloride = 2.3;
                }
                if (age >= 19 && age < 51 && gender == "Male")
                {
                    vitaminA = 900;
                    vitaminC = 90;
                    vitaminD = 15;
                    vitaminE = 15;
                    vitaminK = 120;
                    vitaminB1 = 1.2;
                    vitaminB2 = 1.3;
                    vitaminB3 = 16;
                    vitaminB5 = 5;
                    vitaminB7 = 30;
                    vitaminB6 = 1.3;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 550;
                    magnesium = 420;
                    calcium = 1000;
                    zinc = 11;
                    iron = 8;
                    copper = 900;
                    selenium = 55;
                    manganese = 2.3;
                    phosphorus = 700;
                    potassium = 3400;
                    iodine = 150;
                    chromium = 35;
                    molybdenum = 45;
                    fluoride = 4;
                    chloride = 2.3;
                }
                if (age >= 19 && age < 51 && gender == "Female")
                {
                    vitaminA = 700;
                    vitaminC = 75;
                    vitaminD = 15;
                    vitaminE = 15;
                    vitaminK = 90;
                    vitaminB1 = 1.1;
                    vitaminB2 = 1.1;
                    vitaminB3 = 14;
                    vitaminB5 = 5;
                    vitaminB7 = 30;
                    vitaminB6 = 1.3;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 425;
                    magnesium = 320;
                    calcium = 1000;
                    zinc = 8;
                    iron = 18;
                    copper = 900;
                    selenium = 55;
                    manganese = 1.8;
                    phosphorus = 700;
                    potassium = 2600;
                    iodine = 150;
                    chromium = 25;
                    molybdenum = 45;
                    fluoride = 3;
                    chloride = 2.3;
                }
                if (age >= 51 && age < 71 && gender == "Male")
                {
                    vitaminA = 900;
                    vitaminC = 90;
                    vitaminD = 15;
                    vitaminE = 15;
                    vitaminK = 120;
                    vitaminB1 = 1.2;
                    vitaminB2 = 1.3;
                    vitaminB3 = 16;
                    vitaminB5 = 5;
                    vitaminB7 = 30;
                    vitaminB6 = 1.7;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 550;
                    magnesium = 420;
                    calcium = 1000;
                    zinc = 11;
                    iron = 8;
                    copper = 900;
                    selenium = 55;
                    manganese = 2.3;
                    phosphorus = 700;
                    potassium = 3400;
                    iodine = 150;
                    chromium = 30;
                    molybdenum = 45;
                    fluoride = 4;
                    chloride = 2;
                }
                if (age >= 51 && age < 71 && gender == "Female")
                {
                    vitaminA = 700;
                    vitaminC = 75;
                    vitaminD = 15;
                    vitaminE = 15;
                    vitaminK = 90;
                    vitaminB1 = 1.1;
                    vitaminB2 = 1.1;
                    vitaminB3 = 14;
                    vitaminB5 = 5;
                    vitaminB7 = 30;
                    vitaminB6 = 1.5;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 425;
                    magnesium = 320;
                    calcium = 1200;
                    zinc = 8;
                    iron = 8;
                    copper = 900;
                    selenium = 55;
                    manganese = 1.8;
                    phosphorus = 700;
                    potassium = 2600;
                    iodine = 150;
                    chromium = 20;
                    molybdenum = 45;
                    fluoride = 3;
                    chloride = 2;
                }
                if (age >= 71 && gender == "Male")
                {
                    vitaminA = 900;
                    vitaminC = 90;
                    vitaminD = 20;
                    vitaminE = 15;
                    vitaminK = 120;
                    vitaminB1 = 1.2;
                    vitaminB2 = 1.3;
                    vitaminB3 = 16;
                    vitaminB5 = 5;
                    vitaminB7 = 30;
                    vitaminB6 = 1.7;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 550;
                    magnesium = 420;
                    calcium = 1200;
                    zinc = 11;
                    iron = 8;
                    copper = 900;
                    selenium = 55;
                    manganese = 2.3;
                    phosphorus = 700;
                    potassium = 3400;
                    iodine = 150;
                    chromium = 30;
                    molybdenum = 45;
                    fluoride = 4;
                    chloride = 1.8;
                }
                if (age >= 71 && gender == "Female")
                {
                    vitaminA = 700;
                    vitaminC = 75;
                    vitaminD = 20;
                    vitaminE = 15;
                    vitaminK = 90;
                    vitaminB1 = 1.1;
                    vitaminB2 = 1.1;
                    vitaminB3 = 14;
                    vitaminB5 = 5;
                    vitaminB7 = 30;
                    vitaminB6 = 1.5;
                    vitaminB12 = 2.4;
                    vitaminB9 = 400;
                    choline = 425;
                    magnesium = 420;
                    calcium = 1200;
                    zinc = 8;
                    iron = 8;
                    copper = 900;
                    selenium = 55;
                    manganese = 1.8;
                    phosphorus = 700;
                    potassium = 2600;
                    iodine = 150;
                    chromium = 20;
                    molybdenum = 45;
                    fluoride = 3;
                    chloride = 1.8;
                }
                var bsaPrint = new Label { Text = "Body Surface Area: " + Math.Round(bsa, 2) + "m^2", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var ibwPrint = new Label { Text = "Ideal Body Weight: " + Math.Round(ibw, 1) + m, Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var body = new Label { Text = "Body Information", Style = header, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var bmiPrint = new Label { Text = "Body Mass Index: " + Math.Round(bmi, 2) + "kg/m^2", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var bmiReading = new Label { Text = bmiRead, Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var bfPrint = new Label { Text = "Body Fat Percentage: " + Math.Round(bfp, 2) + "%", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var bfReading = new Label { Text = bfRead, Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var fMassPrint = new Label { Text = "Fat Mass: " + Math.Round(fm, 1) + m, Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var lMassPrint = new Label { Text = "Lean Mass: " + Math.Round(lm, 1) + m, Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var whtPrint = new Label { Text = "Waist To Height Ratio: " + Math.Round(whe, 2), Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var whtReading = new Label { Text = wheRead, Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var whpPrint = new Label { Text = "Waist To Hip Ratio: " + Math.Round(whi, 2), Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var whpReading = new Label { Text = whiRead, Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var bmrPrint = new Label { Text = "Basal Metabolic Rate: " + Math.Round(bmr, 0) + "kcal", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var recommend = new Label { Text = "Daily Intake Recommendations", Style = header, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var calNeedPrint = new Label { Text = "Calories: " + Math.Round(need, 0) + "kcal", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var carbsPrint = new Label { Text = "Carbs: " + Math.Round(carbs, 0) + "g", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var proteinsPrint = new Label { Text = "Protein: " + Math.Round(proteins, 0) + "g", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var fatsPrint = new Label { Text = "Fat: " + Math.Round(fats, 0) + "g", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var waterPrint = new Label { Text = "Water: " + Math.Round(water, 0) + "oz", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminAPrint = new Label { Text = "Vitamin A: " + Math.Round(vitaminA, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminCPrint = new Label { Text = "Vitamin C: " + Math.Round(vitaminC, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminDPrint = new Label { Text = "Vitamin D: " + Math.Round(vitaminD, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminEPrint = new Label { Text = "Vitamin E: " + Math.Round(vitaminE, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminKPrint = new Label { Text = "Vitamin K: " + Math.Round(vitaminK, 1) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB1Print = new Label { Text = "Vitamin B1: " + Math.Round(vitaminB1, 1) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB2Print = new Label { Text = "Vitamin B2: " + Math.Round(vitaminB2, 1) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB3Print = new Label { Text = "Vitamin B3: " + Math.Round(vitaminB3, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB5Print = new Label { Text = "Vitamin B5: " + Math.Round(vitaminB5, 1) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB7Print = new Label { Text = "Vitamin B7: " + Math.Round(vitaminB7, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB6Print = new Label { Text = "Vitamin B6: " + Math.Round(vitaminB6, 1) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB12Print = new Label { Text = "Vitamin B12: " + Math.Round(vitaminB12, 1) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var vitaminB9Print = new Label { Text = "Vitamin B9: " + Math.Round(vitaminB9, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var cholinePrint = new Label { Text = "Choline: " + Math.Round(choline, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var magnesiumPrint = new Label { Text = "Magnesium: " + Math.Round(magnesium, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var calciumPrint = new Label { Text = "Calcium: " + Math.Round(calcium, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var zincPrint = new Label { Text = "Zinc: " + Math.Round(zinc, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var ironPrint = new Label { Text = "Iron: " + Math.Round(iron, 2) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var copperPrint = new Label { Text = "Copper: " + Math.Round(copper, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var seleniumPrint = new Label { Text = "Selenium: " + Math.Round(selenium, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var manganesePrint = new Label { Text = "Manganese: " + Math.Round(manganese, 3) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var phosphorusPrint = new Label { Text = "Phosphorus: " + Math.Round(phosphorus, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var potassiumPrint = new Label { Text = "Potassium: " + Math.Round(potassium, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var iodinePrint = new Label { Text = "Iodine: " + Math.Round(iodine, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var chromiumPrint = new Label { Text = "Chromium: " + Math.Round(chromium, 1) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var molybdenumPrint = new Label { Text = "Molybdenum: " + Math.Round(molybdenum, 0) + "mcg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var fluoridePrint = new Label { Text = "Fluoride: " + Math.Round(fluoride, 2) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var sodiumPrint = new Label { Text = "Sodium: " + Math.Round(sodium, 0) + "mg", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                var chloridePrint = new Label { Text = "Chloride: " + Math.Round(chloride, 1) + "g", Style = info, FontAttributes = FontAttributes.Bold, TextColor = Color.Black, BackgroundColor = Color.Gold };
                StackLayout stackLayout1 = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.Gold,
                    Children =
                        {
                            title,picker,pick,Age,Height,Weight,Waist,Neck,Hip,pickers,Pick,enter,
                            body, bmiPrint, bmiReading,bsaPrint,bfPrint,bfReading, fMassPrint, lMassPrint, whtPrint, whtReading, whpPrint, whpReading, bmrPrint, ibwPrint,
                            recommend, calNeedPrint, carbsPrint, proteinsPrint, fatsPrint, waterPrint, vitaminAPrint, vitaminCPrint, vitaminDPrint,
                            vitaminEPrint, vitaminKPrint, vitaminB1Print, vitaminB2Print, vitaminB3Print, vitaminB5Print, vitaminB7Print, vitaminB6Print,
                            vitaminB12Print, vitaminB9Print, cholinePrint, magnesiumPrint, calciumPrint, zincPrint, ironPrint, copperPrint, seleniumPrint,
                            manganesePrint, phosphorusPrint, potassiumPrint, iodinePrint, chromiumPrint, molybdenumPrint, fluoridePrint, sodiumPrint, chloridePrint
                        }
                };
                ScrollView scrollView1 = new ScrollView
                {
                    Content = stackLayout1
                };
                Content = scrollView1;
            }

        }
    }
}