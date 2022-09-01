namespace Crypto.model
{

    public class CryptoCoinResponse
    {
        public CryptoCoinData data { get; set; }
        public long timestamp { get; set; }
    }

    public class CryptoCoinData
    {
        public string id { get; set; }
        public int rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public float supply { get; set; }
        public string maxSupply { get; set; }
        public string marketCapUsd { get; set; }
        public string volumeUsd24Hr { get; set; }
        public float priceUsd { get; set; }
        public string changePercent24Hr { get; set; }
        public string vwap24Hr { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", name);
        }
    }

    public class CryptoCoinList
    {
        public CryptoCoinData[] data { get; set; }
    }




}
