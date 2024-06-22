using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.ProductApi.Context;
using VShop.ProductApi.DTOs.Mappings;
using VShop.ProductApi.Repository;
using VShop.ProductApi.Repository.Interfaces;

namespace VShop.Tests.Database;

public class ControllerTestsBase<TController, TService> : IDisposable
    where TController : class
    where TService : class
{
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly TController _controller;
    protected readonly AppDbContext _context;
    protected readonly TService _service;

    public ControllerTestsBase()
    {
        var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(dbContextOptions);
        DatabaseInitializer.Reinitialize(dbContextOptions);
        DatabaseInitializer.Initialize(dbContextOptions);

        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        _unitOfWork = new UnitOfWork(_context);
        _service = CreateServiceInstance();
        _controller = CreateControllerInstance();
    }

    protected virtual TService CreateServiceInstance()
    {
        return Activator.CreateInstance(typeof(TService), _unitOfWork, _mapper) as TService;
    }

    protected virtual TController CreateControllerInstance()
    {
        return Activator.CreateInstance(typeof(TController), _service) as TController;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
