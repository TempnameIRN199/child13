using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Chat;

namespace child13_AI.AdditionalStructures.Service
{
    public class API
    {
        private string api;
        private ChatClient client;

        public API() { }

        public string _APIGet()
        {
            return api;
        }

        public string _APISet(string inAPI)
        {
            api = inAPI;
            return api;
        }

        public string _APIReset()
        {
            api = null;
            return api;
        }

        public bool _APIIsSet()
        {
            return api != null;
        }

        public bool _APIIsNotSet()
        {
            return api == null;
        }

        public void Translate(ChatClient client, string api, string model, string text)
        {
            client = new ChatClient(model: $"{model}", apiKey: Environment.GetEnvironmentVariable($"{api}"));
        }
    }
}
