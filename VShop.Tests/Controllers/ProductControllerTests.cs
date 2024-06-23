using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.ProductApi.Controllers;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Services;
using VShop.Tests.Database;

namespace VShop.Tests.Controllers;

public class ProductControllerTests : ControllerTestsBase<ProductController, ProductService>
{
    [Fact]
    public async Task ProductController_Get_ReturnsOkObjectResult()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task ProductController_GetById_ReturnsOkObjectResult()
    {
        // Arrange
        var product = await _unitOfWork.ProductRepository.Get().FirstOrDefaultAsync();

        // Act
        var result = await _controller.GetById(product.Id);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task ProductController_GetById_ReturnsNotFoundResult()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = await _controller.GetById(id);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public async Task ProductController_Add_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var dto = new ProductDTO
        {
            Name = "Test Product",
            Price = 10.0m,
            CategoryId = 1
        };

        // Act
        var result = await _controller.Add(dto);

        // Assert
        result.Should().BeOfType<CreatedAtActionResult>();
    }

    [Fact]
    public async Task ProductController_Add_ReturnsBadRequestResult()
    {
        // Arrange
        ProductDTO dto = null;

        // Act
        var result = await _controller.Add(dto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task ProductController_Update_ReturnsOkObjectResult()
    {
        // Arrange
        var product = await _unitOfWork.ProductRepository.Get().FirstOrDefaultAsync();
        var dto = new ProductDTO
        {
            Id = product.Id,
            Name = "Test Product",
            Price = 10.0m
        };

        // Act
        var result = await _controller.Update(product.Id, dto);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task ProductController_Update_ReturnsBadRequestResult()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new ProductDTO
        {
            Id = Guid.NewGuid(),
            Name = "Test Product",
            Price = 10.0m
        };

        // Act
        var result = await _controller.Update(id, dto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task ProductController_Update_ReturnsNotFoundResult()
    {
        // Arrange
        var id = Guid.NewGuid();
        var dto = new ProductDTO
        {
            Id = id,
            Name = "Test Product",
            Price = 10.0m
        };

        // Act
        var result = await _controller.Update(id, dto);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }


    [Fact]
    public async Task ProductController_Delete_ReturnsOkObjectResult()
    {
        // Arrange
        var product = await _unitOfWork.ProductRepository.Get().FirstOrDefaultAsync();

        // Act
        var result = await _controller.Delete(product.Id);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task ProductController_Delete_ReturnsNotFoundResult()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = await _controller.Delete(id);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }
}
