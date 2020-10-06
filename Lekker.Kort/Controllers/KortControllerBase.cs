using Lekker.Kort.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lekker.Kort.Controllers
{
    public class KortControllerBase : ControllerBase
    {
        private readonly IShortUriRepository _kortRepo;

        public KortControllerBase(IShortUriRepository kortRepository)
        {
            _kortRepo = kortRepository ?? throw new ArgumentNullException(nameof(kortRepository));
        }

        protected IShortUriRepository GetShortenedUrlRepository()
        {
            _kortRepo.SetContext();
            return _kortRepo;
        }
    }
}