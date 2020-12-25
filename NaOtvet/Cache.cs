using NaOtvet.Properties;
using NaUrokApiClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace NaOtvet
{
    public class Cache
    {
        public static Cache CacheObjects { get; private set; } = new Cache();

        public Dictionary<string, Image> Pictures { get; set; }
        public List<KeyValuePair<int, TestSession>> SolvedTestSessions { get; set; }

        public Cache()
        {
            Load();
            CacheObjects = this;
        }

        private void Load()
        {
            var cache = (Cache)JsonConvert.DeserializeObject(Settings.Default.Cache);

            Pictures            = cache?.Pictures is null ? new Dictionary<string, Image>() : cache.Pictures;
            SolvedTestSessions  = cache?.SolvedTestSessions is null ? new List<KeyValuePair<int, TestSession>>() : cache.SolvedTestSessions;
        }

        public void Save()
        {
            Settings.Default.Cache = JsonConvert.SerializeObject(this);
        }
    }
}
