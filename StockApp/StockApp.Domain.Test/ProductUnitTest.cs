using FluentAssertions;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateCategory_WithValidParametersState()
        {
            Action action = () => new Product("example_name", "example_description", 4.00M, 10, "example_image.jpg");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Valid State Id")]
        public void CreateCategory_WithValidParametersStateId()
        {
            Action action = () => new Product(5, "example_name", "example_description", 4.00M, 10, "example_image.jpg");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Create Product With Invalid State Id")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "example_name", "example_description", 4.00M, 10, "example_image.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "example_description", 4.00M, 10, "example_image.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "ex", "example_description", 4.00M, 10, "example_image.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Null State Description")]
        public void CreateProduct_WithNullParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "example_name", null, 4.00M, 10, "example_image.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Description")]
        public void CreateProduct_WithInvalidDescriptionParameters_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "example_name", "exam", 4.00M, 10, "example_image.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreateProduct_WithInvalidPriceParameters_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "example_name", "example_description", -4.00M, 10, "example_image.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void CreateProduct_WithInvalidPriceParameters_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "example_name", "example_description", 4.00M, -10, "example_image.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Image Url")]
        public void CreateProduct_WithInvalidPriceParameters_DomainExceptionInvalidImageUrl()
        {
            Action action = () => new Product(1, "example_name", "example_description", 4.00M, 10,
                "example_descriptionnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn" +
                "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn" +
                "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn.jpg");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
        #endregion
    }
}
