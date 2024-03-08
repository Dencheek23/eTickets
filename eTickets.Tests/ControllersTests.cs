using NUnit.Framework;
using System;
using System.Web.Mvc;
using eTickets.Controllers;
using eTickets.Models;

namespace eTickets.Tests
{
    [TestFixture]
    public class ControllersTests
    {
        [Test]
        public void CreateActionAddsCinemaAndRedirectsTest()
        {
            // Arrange
            var controller = new CinemaController();
            var cinema = new Cinema() { Name = "Test Cinema", Location = "Test Location" };

            // Act
            var result = controller.Create(cinema) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void FilterMoviesBySearchStringTest()
        {
            // Arrange
            var controller = new MoviesController();
            var searchString = "Action";

            // Act
            var result = controller.Index(searchString) as ViewResult;
            var model = result.Model as List<Movie>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.IsTrue(model.All(m => m.Genre.Contains(searchString)));
        }
    }

    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddItemToShoppingCartAddsItemTest()
        {
            // Arrange
            var cart = new ShoppingCart();
            var item = new CartItem() { ProductId = 1, Quantity = 1 };

            // Act
            cart.AddItem(item);

            // Assert
            Assert.AreEqual(1, cart.Items.Count);
            Assert.IsTrue(cart.Items.Contains(item));
        }

        [Test]
        public void RemoveItemFromShoppingCartRemovesItemTest()
        {
            // Arrange
            var cart = new ShoppingCart();
            var item = new CartItem() { ProductId = 1, Quantity = 1 };
            cart.AddItem(item);

            // Act
            cart.RemoveItem(item.ProductId);

            // Assert
            Assert.AreEqual(0, cart.Items.Count);
            Assert.IsFalse(cart.Items.Contains(item));
        }
    }
}
