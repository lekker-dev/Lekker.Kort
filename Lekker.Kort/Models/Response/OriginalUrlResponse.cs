namespace Lekker.Kort.Models.Response
{

    public class OriginalUrlResponse
    {
        public string OriginalUrl { get; set; }
    }

    public class UrlDetailResponse
    {
        public string OriginalUrl { get; set; }
        public string[] Hits { get; set; }
        public int HitCount { get; set; }
    }
}