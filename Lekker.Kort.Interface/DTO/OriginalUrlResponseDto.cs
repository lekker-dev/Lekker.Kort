using System.Collections.Generic;

namespace Lekker.Kort.Interface.DTO
{
    public class OriginalUrlResponseDto
    {
        public string OriginalUrl { get; set; }
    }

    public class UrlDetailResponseDto
    {
        public string OriginalUrl { get; set; }
        public List<string> Hits { get; set; }
    }


}