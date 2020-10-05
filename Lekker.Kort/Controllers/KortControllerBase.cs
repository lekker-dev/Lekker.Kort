using Lekker.Kort.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lekker.Kort.Controllers
{
    public class KortControllerBase : ControllerBase
    {
        private readonly IKortRepository _kortRepo;

        public KortControllerBase(IKortRepository kortRepository)
        {
            _kortRepo = kortRepository ?? throw new ArgumentNullException(nameof(kortRepository));
        }

        protected IKortRepository GetKortRepo()
        {
            _kortRepo.SetContext();
            return _kortRepo;
        }
    }
}