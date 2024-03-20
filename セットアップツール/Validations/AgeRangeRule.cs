using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace セットアップツール.Validations {
    public class AgeRangeRule : ValidationRule {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            var age = 0;

            try {
                if (((string)value).Length > 0)
                    age = int.Parse((string)value);
            }
            catch (Exception e) {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            if ((age < Min) || (age > Max)) {
                return new ValidationResult(false,
                    "Please enter an age in the range: " + Min + " - " + Max + ".");
            }
            return new ValidationResult(true, null);
        }
    }
}
