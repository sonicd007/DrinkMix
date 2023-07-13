using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.DataAccess.Data;
using DrinkMix.DataAccess.Models;
using DrinkMix.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DrinkMix.Tests
{
    [TestClass]
    public class RecipeServiceTests
    {
        private readonly IMapper _mapper;
        public RecipeServiceTests() 
        {
            var myProfile = new DrinkMix.BusinessLogic.AutoMapperMappings.DTOMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        [TestMethod]
        public void UpdateIngredient_happy_path()
        {
            Ingredient unmodifiedIngredient = new Ingredient()
            { 
                IngredientTypeId = 1,
                Id = 1,
                Name = "Maker's Mark"
            };

            IngredientDTO updatedIngredient = new IngredientDTO()
            {
                IngredientTypeId = 2,
                IngredientTypeName = "Gin",
                Id = 1,
                Name = "Blue Sapphire"
            };

            var mockSet = new Mock<DbSet<Ingredient>>();
            var mockContext = new Mock<DrinkMixDbContext>();

            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(unmodifiedIngredient);
            mockContext.Setup(m => m.Ingredients).Returns(mockSet.Object);

            var recipeService = new RecipeService(mockContext.Object, _mapper);
            
            var updatedObject = recipeService.UpdateIngredient(updatedIngredient);

            mockSet.Verify(m => m.Find(1), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(updatedObject.Name, updatedIngredient.Name);
            Assert.AreEqual(updatedObject.IngredientTypeId, updatedIngredient.IngredientTypeId);
        }

        [TestMethod]
        public void CreateRecipe_happy_path()
        {
            Ingredient ingredientOne = new Ingredient()
            {
                IngredientTypeId = 1,
                Id = 1,
                Name = "Maker's Mark"
            };
            var recipeDto = new RecipeDTO()
            {
                Description = "A description",
                GlassName = "Low Ball",
                Name = "Old Fashion",
                GlassTypeId = 1,
                Ingredients = new List<RecipeIngredientDTO>()
                {
                    new RecipeIngredientDTO()
                    {
                        IngredientId = ingredientOne.Id,
                        IngredientName = ingredientOne.Name,
                        Quantity = 1,
                        RecipeIngredientId = 1,
                        UnitOfMeasurement = "oz",
                        IngredientTypeId = 1,
                        IngredientType = "Foo"
                    }
                }
            };

            var mockSet = new Mock<DbSet<Ingredient>>();
            var mockContext = new Mock<DrinkMixDbContext>();

            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(ingredientOne);
            mockContext.Setup(m => m.Ingredients).Returns(mockSet.Object);

            var recipeService = new RecipeService(mockContext.Object, _mapper);

            var updatedObject = recipeService.CreateRecipe(recipeDto);

            mockSet.Verify(m => m.Find(1), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            //Assert.AreEqual(updatedObject.Name, updatedIngredient.Name);
            //Assert.AreEqual(updatedObject.IngredientTypeId, updatedIngredient.IngredientTypeId);
        }
    }
}