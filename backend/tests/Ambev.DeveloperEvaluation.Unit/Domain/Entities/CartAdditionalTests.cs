using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class CartAdditionalTests
    {
        [Fact]
        public void RemoveItem_DeveRemoverItemExistente()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();
            cart.AddItem(productId, 3, 10m);

            // Act
            cart.RemoveItem(productId);

            // Assert
            cart.Items.Should().HaveCount(0);
        }

        [Fact]
        public void RemoveItem_NaoDeveLancarExcecaoParaItemInexistente()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();

            // Act
            Action action = () => cart.RemoveItem(productId);

            // Assert
            action.Should().NotThrow();
            cart.Items.Should().HaveCount(0);
        }

        [Fact]
        public void CancelCart_DeveMarcarComoCancelado()
        {
            // Arrange
            var cart = new Cart();

            // Act
            cart.CancelCart();

            // Assert
            cart.IsCancelled.Should().BeTrue();
        }

        [Fact]
        public void CancelCart_DuasVezesDeveLancarExcecao()
        {
            // Arrange
            var cart = new Cart();
            cart.CancelCart();

            // Act
            Action action = () => cart.CancelCart();

            // Assert
            action.Should().Throw<Exception>().WithMessage("Este carrinho já foi cancelado.");
        }

        [Fact]
        public void AddItem_ComQuantidadeZeroOuNegativa_DeveLancarExcecao()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();

            // Act
            Action action = () => cart.AddItem(productId, 0, 10m);

            // Assert
            action.Should().Throw<Exception>().WithMessage("Quantidade deve ser maior que zero.");
        }

        [Fact]
        public async Task CompleteCart_ComQuantidadeMaiorQue20_DeveLancarExcecao()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();
            // Adiciona um item com quantidade maior que 20
            cart.AddItem(productId, 25, 10m);

            var fakeProductRepository = new FakeProductRepository();
            fakeProductRepository.Add(new Product { Id = productId, Price = 10m });

            // Act
            Func<Task> act = async () => await cart.CompleteCart(fakeProductRepository);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Não é possível comprar mais de 20 unidades do mesmo produto.");
        }
    }
}
