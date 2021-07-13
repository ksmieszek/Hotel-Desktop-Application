using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MVVMFirma.Models.Validators
{
    public class Validators
    {
        #region Constructor
        public Validators()
        {
        }
        #endregion

        #region ValidatorFunctions
        public static string SprawdzStringSzczegolowo(string wartosc)
        {
            if (wartosc == null) return null;
            try
            {
                if (wartosc.Length < 3)
                {
                    return "Za mała liczba znaków";
                }
            }
            catch (Exception) { };

            try
            {
                if (!Regex.IsMatch(wartosc, @"^\p{L}+$"))//czy sa tylko litery
                {
                    return "Nieprawiłowe znaki";
                }
            }
            catch (Exception) { };

            try
            {
                if (!char.IsUpper(wartosc, 0))//jezeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "Rozpocznij od dużej litery";
                }
            }
            catch (Exception) { };

            return null;
        }

        public static string SprawdzPesel(string wartosc)
        {
            if (wartosc == null) return null;
            try
            {
                if (wartosc.Length != 11)
                {
                    return "Wprowadź prawidłową ilość znaków";
                }
            }
            catch (Exception) { };

            try
            {
                if (!Regex.IsMatch(wartosc, @"^\d+$"))
                {
                    return "Nieprawidłowe znaki";
                }
            }
            catch (Exception) { };

            return null;
        }

        public static string SprawdzNumerTelefonu(string number)
        {
            if (number == null) return null;

            number = number.Trim()
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("(", "")
            .Replace(")", "");

            try
            {
                if (!Regex.IsMatch(number, @"^([0-9]{9})$"))
                    return "Nieprawidłowy numer telefonu";
            }
            catch (Exception) { };
            return null;
        }

        static public string RegonValidate(string RegonValidate)// dziala
        {
            byte[] weights;
            ulong regon = ulong.MinValue;
            byte[] digits;

            if (ulong.TryParse(RegonValidate, out regon).Equals(false)) return "Podaj prawidłowy regon";

            switch (RegonValidate.Length)
            {
                case 7:
                    weights = new byte[] { 2, 3, 4, 5, 6, 7 };
                    break;

                case 9:
                    weights = new byte[] { 8, 9, 2, 3, 4, 5, 6, 7 };
                    break;

                case 14:
                    weights = new byte[] { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
                    break;

                default:
                    return "Podaj prawidłowy regon";
            }

            string sRegon = regon.ToString();
            digits = new byte[sRegon.Length];

            for (int i = 0; i < sRegon.Length; i++)
            {
                if (byte.TryParse(sRegon[i].ToString(), out digits[i]).Equals(false)) return "Podaj prawidłowy regon";
            }

            int checksum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                checksum += weights[i] * digits[i];
            }
            return null;
        }

        public static string IsValidNIP(string input)
        {
            if (input == null) return null;

            if (!Regex.IsMatch(input, @"^\d+$"))
            {
                return "Nieprawidłowe znaki";
            }

            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            
            if (input.Length == 10)
            {
                int k = 0;
                int offset = 0;

                for (int i = 0; i < input.Length - 1; i++)
                {
                    k += weights[i + offset] * int.Parse(input[i].ToString());
                }

                int controlSum = k;

                int controlNum = controlSum % 11;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }

                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                if(controlNum == lastDigit)
                    return null;
            }
            return "Nieprawidłowa ilość znaków";
        }

        public static string SprawdzEmail(string email)
        {
            try
            {
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase))
                {
                    return "Nieprawidłowy adres email";
                }
            }
            catch (Exception) { };
            return null;
        }

        public static string SprawdzCzyTylkoCyfry(string wartosc)
        {
            if (wartosc == null) return null;
            try
            {
                if (!Regex.IsMatch(wartosc, @"^\d+$"))
                {
                    return "Nieprawidłowe znaki";
                }
            }
            catch (Exception) { };
            return null;
        }

        public static string SprawdzKodPocztowy(string kodPocztowy)
        {
            if (kodPocztowy == null) return null;

            try
            {
                if (kodPocztowy.Length != 6)
                {
                    return "Nieprawidłowa liczba znaków";
                }
            }
            catch (Exception) { };

            try
            {
                string x = kodPocztowy[2].ToString();
                if (x != "-")
                {
                    return "Brak myślnika";
                }
            }
            catch (Exception) { };

            try
            {
                if (!Regex.IsMatch(kodPocztowy, @"^\d{2}-\d{3}|\d$",
                    RegexOptions.IgnoreCase))
                {
                    return "Nieprawidłowy kod pocztowy";
                }
            }
            catch (Exception) { };
            return null;
        }

        public static string SprawdzCzyOdDuzejLitery(string wartosc)
        {
            if (wartosc == null) return null;
            try
            {
                if (!char.IsUpper(wartosc, 0))//jezeli na pozycji 0 w wartosci nie jest duza litera
                {
                    return "Rozpocznij od dużej litery";
                }
            }
            catch (Exception) { };

            return null;
        }
        #endregion
    }
}
