namespace AdventOfCode.Day4
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class DayFour
    {
        public static int RunPartOne()
        {
            var result = 0;

            var input = File.ReadAllText("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day4\\Input.txt");

            var passports = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var requiredFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" }.ToList();

            var allowedHairColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.ToList();

            var validPassports = new List<string>();

            foreach (var passport in passports)
            {
                if (requiredFields.All(x => passport.Contains(x)))
                {
                    validPassports.Add(passport);
                }
            }

            result = validPassports.Count;

            return result;
        }

        public static int RunPartTwo()
        {
            var result = 0;

            var input = File.ReadAllText("C:\\git\\advent-of-code\\2020\\AdventOfCode\\Day4\\Input.txt");

            var passports = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var requiredFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" }.ToList();

            var allowedHairColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.ToList();

            var validPassports = new List<string>();

            foreach (var passport in passports)
            {
                if (requiredFields.All(x => passport.Contains(x)))
                {
                    var passportProperties = passport.Split(new[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var isValid = true;

                    foreach (var passportProperty in passportProperties)
                    {
                        var propertyName = passportProperty.Split(":")[0];
                        var propertyValue = passportProperty.Split(":")[1];

                        if (propertyName == "byr")
                        {
                            var propertyValueInt = int.Parse(propertyValue);

                            if (propertyValue.Length != 4 || !(propertyValueInt >= 1920 && propertyValueInt <= 2002))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (propertyName == "iyr")
                        {
                            var propertyValueInt = int.Parse(propertyValue);

                            if (propertyValue.Length != 4 || !(propertyValueInt >= 2010 && propertyValueInt <= 2020))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (propertyName == "eyr")
                        {
                            var propertyValueInt = int.Parse(propertyValue);

                            if (propertyValue.Length != 4 || !(propertyValueInt >= 2020 && propertyValueInt <= 2030))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (propertyName == "hgt")
                        {
                            var propertyValueInt = int.Parse(Regex.Split(propertyValue, @"\D+")[0]);

                            if (!propertyValue.Contains("cm") && !propertyValue.Contains("in"))
                            {
                                isValid = false;
                                break;
                            }

                            if (propertyValue.Contains("cm") && !(propertyValueInt >= 150 && propertyValueInt <= 193))
                            {
                                isValid = false;
                                break;
                            }

                            if (propertyValue.Contains("in") && !(propertyValueInt >= 59 && propertyValueInt <= 76))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (propertyName == "hcl")
                        {

                            if (!propertyValue.StartsWith("#"))
                            {
                                isValid = false;
                                break;
                            }

                            if (propertyValue.StartsWith("#") && propertyValue.Length != 7)
                            {
                                isValid = false;
                                break;
                            }

                            if (!Regex.IsMatch(propertyValue, @"^#(?:[0-9a-fA-F]{3}){1,2}$"))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (propertyName == "ecl")
                        {
                            if (!allowedHairColors.Any(x => propertyValue.Contains(x)))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (propertyName == "pid")
                        {

                            if (propertyValue.Length != 9)
                            {
                                isValid = false;
                                break;
                            }

                            if (!Regex.IsMatch(propertyValue, @"^[0-9]"))
                            {
                                isValid = false;
                                break;
                            }
                        }
                    }

                    if (isValid)
                    {
                        validPassports.Add(passport);
                    }
                }
            }

            result = validPassports.Count;

            return result;
        }
    }
}
