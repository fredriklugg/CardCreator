using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CardCreator;
using CardCreator.Model;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CardCreator
{
    public class JsonHandler
    {
        public void SerializeCard(CardData card)
        {
            string path;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Save map as JSON",
                Filter = "JSON|*.json"
            };

            if (sfd.ShowDialog() == true)
            {
                path = Path.GetFullPath(sfd.FileName);
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, card);
                }
            }
        }

        public CardData DeserializeCard()
        {
            CardData deserializedCard = null;

            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a JSON map file",
                Filter = "Only supports JSON|*.json"
            };
            if (op.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(op.FileName))
                {
                    string line;

                    line = sr.ReadLine();

                    deserializedCard = JsonConvert.DeserializeObject<CardData>(line);

                    Console.WriteLine(deserializedCard);

                }
            }
            return deserializedCard;
        }
    }
}