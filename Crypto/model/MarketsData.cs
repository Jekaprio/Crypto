using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.model
{
    public class MarketsData
    {

        public class MarketsResponse
        {
            public MarketData[] data { get; set; }
            public long timestamp { get; set; }
        }

        public class MarketData
        {
            public string exchangeId { get; set; }
            public string baseId { get; set; }
            public string quoteId { get; set; }
            public string baseSymbol { get; set; }
            public string quoteSymbol { get; set; }
            public string volumeUsd24Hr { get; set; }
            public string priceUsd { get; set; }
            public string volumePercent { get; set; }

            public override string ToString()
            {
                return string.Format("{0}", exchangeId);
            }
        }

        public class MarketsList
        {
            public MarketData[] data { get; set; }
            public override string ToString()
            {

                return this.data[0].ToString();
            }
            
        }


       

    }
}
