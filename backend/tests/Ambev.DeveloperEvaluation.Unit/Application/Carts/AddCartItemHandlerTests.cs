using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Carts.CartItem;

namespace Ambev.DeveloperEvaluation.Unit.Application.Carts
{
    public class AddCartItemHandlerTests
    {
        private readonly Mock<ICartRepository> _cartRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly IMapper _mapper;
        private readonly AddCartItemHandler _handler;

        public AddCartItemHandlerTests()
        {
            _cartRepositoryMock = new Mock<ICartRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                // Se tiver mapeamentos de AutoMapper, configure aqui.
                // Exemplo: cfg.AddProfile(new ApplicationMappingProfile());
            });
            _mapper = config.CreateMapper();

            _handler = new AddCartItemHandler(_cartRepositoryMock.Object, _productRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Handle_DeveAdicionarItemNoCarrinho()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var cart = new Cart { Id = cartId };

            _cartRepositoryMock
                .Setup(repo => repo.GetByIdAsync(cartId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(cart);

            _productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(productId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Product
                {
                    Id = productId,
                    Price = 10m
                });

            var command = new AddCartItemCommand
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = 2
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.CartId.Should().Be(cartId);

            _cartRepositoryMock.Verify(
                repo => repo.UpdateAsync(cart, It.IsAny<CancellationToken>()),
                Times.Once);

            cart.Items.Should().HaveCount(1);
            var item = cart.Items.First();
            item.ProductId.Should().Be(productId);
            item.Quantity.Should().Be(2);
            item.UnitPrice.Should().Be(10m);
        }
    }
}
