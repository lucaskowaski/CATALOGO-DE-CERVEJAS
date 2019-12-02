using AutoMapper;
using Catalogo.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.Tests.Services
{
    public class ApplicationBaseTets
    {
        protected MapperConfiguration _mapperConfiguration;
        public ApplicationBaseTets()
        {
            ConfigurarAutomapper();
        }
        public void ConfigurarAutomapper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToModelMappingProfile());
            });
        }
        
    }
}
