using System;
using AutoMapper;
using Business.Application.ViewModels;
using Business.Domain.Commands.Security.Tenants;
using Business.Domain.Models.ValueObjects;

namespace Business.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TenantViewModel, CreateTenantCommand>()
                .ConstructUsing(c => new CreateTenantCommand(c.Id,
                                                             c.Name,
                                                             c.DisplayName,
                                                             new Contact(c.Email, c.Email2, c.Phone, c.Phone2, c.Phone3),
                                                             new Address()
                                                             {
                                                                 State = c.State,
                                                                 City = c.City,
                                                                 Street = c.Street,
                                                                 Street2 = c.Street2,
                                                                 ForeignZip = c.ForeignZip,
                                                                 Country = c.Country,
                                                                 PostalCode = c.PostalCode
                                                             }));
            //CreateMap<TenantViewModel, UpdateTenantCommand>()
            //.ConstructUsing(c => new UpdateTenantCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }

}
