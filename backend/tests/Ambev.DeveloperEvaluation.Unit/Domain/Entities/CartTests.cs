using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class CartTests
    {
        [Fact]
        public void AddItem_DeveAdicionarItemSeNaoExistir()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();

            // Act
            cart.AddItem(productId, 2, 10m);

            // Assert
            cart.Items.Should().HaveCount(1);
            cart.Items[0].Quantity.Should().Be(2);
            cart.Items[0].UnitPrice.Should().Be(10m);
            cart.Items[0].Discount.Should().Be(0m);
            cart.Items[0].TotalAmount.Should().Be(20m);
        }

        [Fact]
        public void AddItem_DeveSomarQuantidadeSeItemJaExistir()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();
            cart.AddItem(productId, 2, 10m);

            // Act
            cart.AddItem(productId, 3, 10m);

            // Assert
            var item = cart.Items.First(i => i.ProductId == productId);
            item.Quantity.Should().Be(5);
            item.TotalAmount.Should().Be(50m);
        }

        [Fact]
        public void AddItem_DeveAplicarDescontoDe10PorcentoSeQuantidadeEntre4e9()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();

            // Act
            cart.AddItem(productId, 5, 10m);

            // Assert
            var item = cart.Items.First(i => i.ProductId == productId);
            item.Discount.Should().Be(0.1m);
            item.TotalAmount.Should().Be(45m);
        }

        [Fact]
        public void AddItem_DeveAplicarDescontoDe20PorcentoSeQuantidadeEntre10e20()
        {
            // Arrange
            var cart = new Cart();
            var productId = Guid.NewGuid();

            // Act
            cart.AddItem(productId, 10, 10m);

            // Assert
            var item = cart.Items.First(i => i.ProductId == productId);
            item.Discount.Should().Be(0.2m);
            item.TotalAmount.Should().Be(80m);
        }

        [Fact]
        public async Task CompleteCart_DeveCalcularTotalPriceCorretamente()
        {
            // Arrange
            var cart = new Cart();

            // Definindo dois produtos com seus IDs e preços
            var productId1 = Guid.NewGuid();
            var productId2 = Guid.NewGuid();

            // Adiciona itens ao carrinho
            // Primeiro item: 2 unidades a R$10 cada = 20
            cart.AddItem(productId1, 2, 10m);
            // Segundo item: 5 unidades a R$10 cada, com desconto de 10% (se a lógica aplicar desconto para quantidade entre 4 e 9)
            // 5 x 10 = 50 - 10% = 45
            cart.AddItem(productId2, 5, 10m);

            // Cria o fake do repositório de produtos e adiciona os produtos com os preços esperados
            var fakeProductRepository = new FakeProductRepository();
            fakeProductRepository.Add(new Product { Id = productId1, Price = 10m });
            fakeProductRepository.Add(new Product { Id = productId2, Price = 10m });

            // Act
            await cart.CompleteCart(fakeProductRepository);

            // Assert
            cart.TotalPrice.Should().Be(65m);
            cart.IsCompleted.Should().BeTrue();
        }

    }
}
