using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1
{
    internal class ZodiacViewModel : INotifyPropertyChanged
    {

        private readonly UserModel user;

        public ZodiacViewModel()
        {
            user = new UserModel();
        }

        public DateTime BirthDate
        {
            get { return user.birthDate; }
            set
            {

                DateTime now = DateTime.Now;
                var age = now.Year - value.Year;

                if (now.Month < value.Month || now.Month == value.Month && now.Day < value.Day)
                {
                    age--;
                }

                if (age > 135 || age <= 0)
                {
                    MessageBox.Show("Error! You are not born yet or are already dead!");
                }
                else
                {
                    user.birthDate = value;
                    Age = age.ToString();
                    GetWestern();
                    GetChinese();
                    HappyBirthDay();
                }
            }
        }

        public string Age
        {
            get { return $"   Your age is: {user.age}"; }
            set
            {
                user.age = int.Parse(value);
                OnPropertyChanged(nameof(Age));
            }
        }

        public string WesternZS
        {
            get { return user.westernZS; }
            set
            {
                user.westernZS = $"   Your Western sign is : {value}";
                OnPropertyChanged(nameof(WesternZS));
            }
        }

        private void GetWestern()
        {
            if (BirthDate.Month == 9 && BirthDate.Day >= 22 || BirthDate.Month == 10 && BirthDate.Day <= 21)
                WesternZS = "Libra";
            if (BirthDate.Month == 10 && BirthDate.Day >= 22 || BirthDate.Month == 11 && BirthDate.Day <= 21)
                WesternZS = "Scorpio";
            if (BirthDate.Month == 11 && BirthDate.Day >= 22 || BirthDate.Month == 12 && BirthDate.Day <= 21)
                WesternZS = "Sagittarius";
            if (BirthDate.Month == 12 && BirthDate.Day >= 22 || BirthDate.Month == 1 && BirthDate.Day <= 21)
                WesternZS = "Capricorn";
            if (BirthDate.Month == 1 && BirthDate.Day >= 22 || BirthDate.Month == 2 && BirthDate.Day <= 21)
                WesternZS = "Aquarius";
            if (BirthDate.Month == 2 && BirthDate.Day >= 22 || BirthDate.Month == 3 && BirthDate.Day <= 21)
                WesternZS = "Pisces";
            if (BirthDate.Month == 3 && BirthDate.Day >= 22 || BirthDate.Month == 4 && BirthDate.Day <= 21)
                WesternZS = "Aries";
            if (BirthDate.Month == 4 && BirthDate.Day >= 22 || BirthDate.Month == 5 && BirthDate.Day <= 21)
                WesternZS = "Taurus";
            if (BirthDate.Month == 5 && BirthDate.Day >= 22 || BirthDate.Month == 6 && BirthDate.Day <= 21)
                WesternZS = "Gemini";
            if (BirthDate.Month == 6 && BirthDate.Day >= 22 || BirthDate.Month == 7 && BirthDate.Day <= 21)
                WesternZS = "Cancer";
            if (BirthDate.Month == 7 && BirthDate.Day >= 22 || BirthDate.Month == 8 && BirthDate.Day <= 21)
                WesternZS = "Leo";
            if (BirthDate.Month == 8 && BirthDate.Day >= 22 || BirthDate.Month == 9 && BirthDate.Day <= 21)
                WesternZS = "Virgo";
        }

        private void HappyBirthDay()
        {
            if (BirthDate.Month == DateTime.Today.Month && BirthDate.Day == DateTime.Today.Day)
            {
                MessageBox.Show("Best wishes for your Birthday!");
            }
        }

        public string ChineseZS
        {
            get { return user.chineseZS; }
            set
            {
                user.chineseZS = $"   Your Chinese Sign is : {value}";
                OnPropertyChanged(nameof(ChineseZS));
            }
        }

        private void GetChinese()
        {
            if (BirthDate.Year % 12 == 0)
                ChineseZS = "Monkey";
            if (BirthDate.Year % 12 == 1)
                ChineseZS = "Rooster";
            if (BirthDate.Year % 12 == 2)
                ChineseZS = "Dog";
            if (BirthDate.Year % 12 == 3)
                ChineseZS = "Pig";
            if (BirthDate.Year % 12 == 4)
                ChineseZS = "Rat";
            if (BirthDate.Year % 12 == 5)
                ChineseZS = "Ox";
            if (BirthDate.Year % 12 == 6)
                ChineseZS = "Tiger";
            if (BirthDate.Year % 12 == 7)
                ChineseZS = "Rabbit";
            if (BirthDate.Year % 12 == 8)
                ChineseZS = "Dragon";
            if (BirthDate.Year % 12 == 9)
                ChineseZS = "Snake";
            if (BirthDate.Year % 12 == 10)
                ChineseZS = "Horse";
            if (BirthDate.Year % 12 == 11)
                ChineseZS = "Sheep";
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


