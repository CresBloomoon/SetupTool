using System.Collections.Generic;
using System.Collections.ObjectModel;
using セットアップツール.ComboBox;

namespace セットアップツール {
    internal sealed class MainWindowViewModel {

        public Dictionary<WeatherType, string> WeatherNames { get; set; }

        public MainWindowViewModel() {
            WeatherNames = new Dictionary<WeatherType, string> {
                [WeatherType.Sunny] = "晴れ",
                [WeatherType.Cloudy] = "曇り",
                [WeatherType.Rainy] = "雨",
                [WeatherType.Snow] = "雪",
            };
        }

        public string SelectItem { get; set; }
    }
}
