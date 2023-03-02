using Newtonsoft.Json;
using System;
using System.Linq;
using static Domain.EntitysExternal.AtivosReposta;

namespace Domain.EntitysExternal
{
    public class AtivosReposta
    {
        [JsonProperty("chart")]
        public Chart chart { get; set; }

        public class Chart
        {
            [JsonProperty("result")]
            public List<Result> result { get; set; }
        }

        public class Result
        {
            [JsonProperty("timestamp")]
            public List<int> timestamp { get; set; }

            [JsonProperty("indicators")]
            public Indicators indicators { get; set; }
        }

        public class Indicators
        {
            [JsonProperty("quote")]
            public List<Quote> quote { get; set; }
        }

        public class Quote
        {
            [JsonProperty("open")]
            public List<double?> open { get; set; }
        }
    }
}