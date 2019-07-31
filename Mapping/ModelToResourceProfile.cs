using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
            CreateMap<SaveProductResource, Product>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => FromDescriptionString(src.UnitOfMeasurement)));;
        }
   

        private static EUnitOfMeasurement FromDescriptionString(string description)
        {
            EUnitOfMeasurement res = EUnitOfMeasurement.Unity;
            switch (description) 
            {
                case "UN": 
                    res = EUnitOfMeasurement.Unity;
                    break;
                case "L":
                    res = EUnitOfMeasurement.Liter;
                    break;
                case "KG":
                    res = EUnitOfMeasurement.Kilogram;
                    break;
                case "MG":
                    res = EUnitOfMeasurement.Milligram;
                    break;
                case "G":
                    res = EUnitOfMeasurement.Gram;
                    break;
            }

            return res;
        }
    }
}