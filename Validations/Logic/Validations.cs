using PRFTLatam.Workshop.Infrastructure.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace PRFTLatam.Workshop.Services.Logic
{
    public class Validations
    {
        public static List<string> IdValidator(string id)
        {
            List<string> errors = new();

            if (string.IsNullOrEmpty(id))
            {
                errors.Add($"{nameof(id)} is null or Empty");
                return errors;
            }

            if (!Regex.IsMatch(id, @"^[a-fA-F0-9]+$"))
            {
                errors.Add($"{nameof(id)} not only contains hexadecimal: A-F 0-9");
            }

            if (!IsOnIDFile(id))
            {
                errors.Add($"{nameof(id)} is not on ids file");
            }

            var idLength = id.Length;

            if (!(idLength >= 10 && idLength <= 32))
            {
                if (idLength < 10)
                {
                    errors.Add($"The {nameof(id)} length is lower than 5");
                }
                else
                {
                    errors.Add($"The {nameof(id)} length is higger than 32");
                }
            }

            return errors;
        }

        private static bool IsOnIDFile(string id)
        {

            if (Read.ReadFile(@"../Validations/Models/ValidIDs.txt").Contains(id))
            {
                return true;
            }

            return false;
        }
    }
}
