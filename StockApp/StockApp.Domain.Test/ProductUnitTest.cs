using FluentAssertions;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParametersState()
        {
            Action action = () => new Product( "Product Name", "Product Description", 20.00M, 100, "Image.png");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParametersStateId()
        {
            Action action = () => new Product(2, "Product Name", "Product Description", 20.00M, 100, "Image.png");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Create Product With Invalid State Id")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-2, "Product Name", "Product Description", 20.00M, 100, "Image.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(2, null, "Product Description", 20.00M, 100, "Image.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(2, "Na", "Product Description", 20.00M, 100, "Image.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }
        [Fact(DisplayName = "Create Product With Null State Description")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(2, "Product Name", null, 20.00M, 100, "Image.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Description")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(2, "Product Name", "Desc", 20.00M, 100, "Image.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(2, "Product Name", "Product Description", -20.00M, 100, "Image.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(2, "Product Name", "Product Description", 20.00M, -100, "Image.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }
        [Fact(DisplayName = "Create Product With Invalid State Image Url")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidImageUrl()
        {
            Action action = () => new Product(2, "Product Name", "Product Description", 20.00M, 100, "Image" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.png");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        #endregion
    }
}
