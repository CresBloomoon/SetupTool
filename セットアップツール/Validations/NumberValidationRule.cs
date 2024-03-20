using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace セットアップツール.Validations {
    public class NumberValidationRule : ValidationRule {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public bool NotEmpty { get; set; }
        public string MessageHeader { get; set; }

        public NumberValidationRule() {
            MinValue = double.MinValue;
            MaxValue = double.MaxValue;
            NotEmpty = false;
            MessageHeader = null;
        }

        public NumberValidationRule(double min, double max, bool notEmpty = false, string msgHeader = null) {
            MinValue = min;
            MaxValue = max;
            NotEmpty = notEmpty;
            MessageHeader = msgHeader;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            if (null == value) {
                if (NotEmpty) {
                    var msg = "値を入力してください。";
                    if (!string.IsNullOrWhiteSpace(MessageHeader))
                        msg = MessageHeader + "に" + msg;
                    return new ValidationResult(false, msg);
                }
                else
                    return ValidationResult.ValidResult;
            }
            string str = value.ToString();
            if (string.IsNullOrEmpty(str)) {
                if (NotEmpty) {
                    var msg = "値を入力してください。";
                    if (!string.IsNullOrWhiteSpace(MessageHeader))
                        msg = MessageHeader + "に" + msg;
                    return new ValidationResult(false, msg);
                }
                else
                    return ValidationResult.ValidResult;
            }

            double ret;
            if (!double.TryParse(str, out ret)) {
                var msg = "数値を入力してください。";
                if (!string.IsNullOrWhiteSpace(MessageHeader))
                    msg = MessageHeader + "に" + msg;
                return new ValidationResult(false, msg);
            }
            if ((MinValue > ret) || (MaxValue < ret)) {
                var msg = "値が範囲外です。(" + MinValue + "～" + MaxValue + ")";
                if (!string.IsNullOrWhiteSpace(MessageHeader))
                    msg = MessageHeader + "の" + msg;
                return new ValidationResult(false, msg);
            }

            return ValidationResult.ValidResult;
        }
    }
}
