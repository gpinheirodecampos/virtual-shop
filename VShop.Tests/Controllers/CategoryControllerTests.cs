using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.ProductApi.Controllers;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;
using VShop.Tests.Database;

namespace VShop.Tests.Controllers;

public class CategoryControllerTests : ControllerTestsBase<CategoryController, CategoryService>
{
    [Fact]
    public async Task CategoryController_Get_ReturnsOkObjectResult()
    {
        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task CategoryController_GetById_ReturnsOkObjectResult()
    {
        // Arrange
        var id = 1;

        // Act
        var result = await _controller.GetById(id);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task CategoryController_GetById_ReturnsNotFoundResult()
    {
        // Arrange
        var id = 0;

        // Act
        var result = await _controller.GetById(id);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public async Task CategoryController_Add_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var dto = new CategoryDTO
        {
            Name = "Test Category"
        };

        // Act
        var result = await _controller.Add(dto);

        // Assert
        result.Should().BeOfType<CreatedAtActionResult>();
    }

    [Fact]
    public async Task CategoryController_Add_ReturnsBadRequestResult()
    {
        // Arrange
        CategoryDTO dto = null;

        // Act
        var result = await _controller.Add(dto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task CategoryController_Update_ReturnsOkObjectResult()
    {
        // Arrange
        var id = 1;
        var dto = new CategoryDTO
        {
            Id = id,
            Name = "Test Category"
        };

        // Act
        var result = await _controller.Update(id, dto);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task CategoryController_Update_ReturnsBadRequestResult()
    {
        // Arrange
        var id = 1;
        CategoryDTO dto = null;

        // Act
        var result = await _controller.Update(id, dto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public async Task CategoryController_Update_ReturnsNotFoundResult()
    {
        // Arrange
        var id = 0;
        var dto = new CategoryDTO
        {
            Id = id,
            Name = "Test Category"
        };

        // Act
        var result = await _controller.Update(id, dto);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public async Task CategoryController_Delete_ReturnsOkObjectResult()
    {
        // Arrange
        var id = 1;

        // Act
        var result = await _controller.Delete(id);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task CategoryController_Delete_ReturnsNotFoundResult()
    {
        // Arrange
        var id = 0;

        // Act
        var result = await _controller.Delete(id);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }
}
