using Lekker.Kort.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lekker.Kort.Controllers
{
    public class KortControllerBase : ControllerBase
    {
        private readonly IShortUrlRepository _kortRepo;

        public KortControllerBase(IShortUrlRepository kortRepository)
        {
            _kortRepo = kortRepository ?? throw new ArgumentNullException(nameof(kortRepository));
        }

        protected IShortUrlRepository GetShortenedUrlRepository()
        {
            _kortRepo.SetContext();
            return _kortRepo;
        }
    }
}