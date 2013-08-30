using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpaStore.Model;

namespace SpaStore.Mapper
{
    public static class DtoMapperExtensions
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
                       {
                           Id = product.Id,
                           CategoryId = product.CategoryId,
                           Name = product.Name,
                           Description = product.Description,
                           Price = product.Price,
                           Images = product.Images.ToDtos()
                       };
        }

        public static IEnumerable<ProductDto> ToDtos(this IEnumerable<Product> products)
        {
            return products.Select(product => product.ToDto());
        }

        public static ImageDto ToDto(this Image image)
        {
            return new ImageDto
                       {
                           Id = image.Id,
                           Name = image.Name,
                           Url = image.Url,
                           IsPrimary = image.IsPrimary,
                           ProductId = image.ProductId
                       };
        }

        public static IEnumerable<ImageDto> ToDtos(this IEnumerable<Image> images)
        {
            return images.Select(image => image.ToDto());
        }

        // To Entity
        public static Product ToEntity(this ProductDto dto)
        {
            return new Product
                       {
                           Id = dto.Id,
                           CategoryId = dto.CategoryId,
                           Name = dto.Name,
                           Description = dto.Description,
                           Price = dto.Price,
                           Images = dto.Images.ToEntities().ToList()
                       };
        }

        public static IEnumerable<Product> ToEntities(this IEnumerable<ProductDto> dtos)
        {
            return dtos.Select(d => d.ToEntity());
        }

        public static Image ToEntity(this ImageDto dto)
        {
            return new Image
                       {
                           Id = dto.Id,
                           Name = dto.Name,
                           Url = dto.Url,
                           IsPrimary = dto.IsPrimary,
                           ProductId = dto.ProductId
                       };
        }

        public static IEnumerable<Image> ToEntities(this IEnumerable<ImageDto> dtos)
        {
            return dtos.Select(d => d.ToEntity());
        }
    }
}