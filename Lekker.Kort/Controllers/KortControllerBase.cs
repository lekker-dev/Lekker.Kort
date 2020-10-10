using Lekker.Kort.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lekker.Kort.Controllers
{
    public abstract class KortControllerBase : ControllerBase
    {
        private readonly IModifiedUrlRepository _kortRepo;

        protected KortControllerBase(IModifiedUrlRepository kortRepository)
        {
            _kortRepo = kortRepository ?? throw new ArgumentNullException(nameof(kortRepository));
        }

        protected IModifiedUrlRepository GetShortenedUrlRepository()
        {
            _kortRepo.SetContext();
            return _kortRepo;
        }
    }
}