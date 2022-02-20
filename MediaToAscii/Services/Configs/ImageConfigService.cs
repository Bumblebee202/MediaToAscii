using MediaToAscii.Configs;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaToAscii.Services.Configs
{
    internal class ImageConfigService : IImageConfigService
    {
        ImageConfig _imageConfig;
        public string ConfigPath => Path.Combine(AppContext.BaseDirectory, "imageConfig.json");

        public ImageConfigService() => CreateFileIfNotExist();

        public void ChangeSymbols(string value)
        {
           _imageConfig.Symbols = value;
            Save(_imageConfig);
        }

        public void ChangeWidth(int value)
        {
            _imageConfig.Width = value;
            Save(_imageConfig);
        }

        public void ChangeHeight(int value)
        {
            _imageConfig.Height = value;
            Save(_imageConfig);
        }

        public ImageConfig LoadImageConfig()
        {
            using var stream = new FileStream(ConfigPath, FileMode.Open, FileAccess.Read);
            _imageConfig = JsonSerializer.Deserialize<ImageConfig>(stream);
            return _imageConfig;
        }

        void CreateFileIfNotExist()
        {
            if (!File.Exists(ConfigPath))
            {
                var imageConfig = new ImageConfig
                {
                    Symbols = "#*@%=+*:-. ",
                    Width = 100,
                    Height = 50
                };

                Save(imageConfig);
            }
        }

        void Save(ImageConfig imageConfig)
        {
            string json = JsonSerializer.Serialize(imageConfig);
            File.WriteAllText(ConfigPath, json);
        }
    }
}
