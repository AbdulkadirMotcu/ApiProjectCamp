using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün ismi boş bırakılamaz!");
            RuleFor(x => x.ProductName).MinimumLength(2).MaximumLength(50).WithMessage("En az iki ve en fazla elli karakter olmalıdır!");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş bırakılamaz!");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün 0 veya 0'dan küçük olamaz giriniz.");
            RuleFor(x => x.Price).LessThan(2500).WithMessage("Ürün fiyatı 2500'den yüksek olamaz");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz!");

        }
    }
}
