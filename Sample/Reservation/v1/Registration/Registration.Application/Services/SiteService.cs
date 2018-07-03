using System;
using System.Collections.Generic;
using Registration.Application.EventSourcedNormalizers;
using Registration.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Registration.Domain.Repositories.Interfaces;
using Registration.Domain.ReadModel;
using CqrsFramework.Domain;
using System.Linq;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;

namespace Registration.Application.Services
{
    public class SiteService : ISiteService
    {
        //private readonly ISession _session;
        private readonly ISiteRepository _siteRepository;

        public SiteService(
            //ISession session,
                               ISiteRepository siteRepository
                              )
        {
            //_session = session;
            _siteRepository = siteRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Site> FindSites()
        {
            return _siteRepository.Find(_ => true);
        }
    }
}
