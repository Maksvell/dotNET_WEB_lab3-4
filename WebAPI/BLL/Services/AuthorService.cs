using BLL.DTOs;
using DAL.Interfaces;
using AutoMapper;
using FluentValidation;
using BLL.Interfaces;
using BLL.Validators;
using DAL.Entities;

namespace BLL.Services;

public class AuthorService(IUnitOfWork unit, IMapper mapper) : BaseSevice<AuthorDTO>(unit, mapper), IAuthorService
{
    protected private readonly AuthorValidator _validator = new();

    public async Task<IEnumerable<AuthorDTO>> GetAll()
    {
        var entities = await _unit.AuthorRepository.GetAll();
        var collection = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(entities);
        return collection;
    }

    public async Task<AuthorDTO> GetById(int id)
    {
        var entity = await _unit.AuthorRepository.GetById(id) ?? throw new NullReferenceException();
        var author = _mapper.Map<AuthorDTO>(entity);
        return author;
    }

    public async Task Add(AuthorDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var author = _mapper.Map<Author>(entity);
        
        //auth

        await _unit.AuthorRepository.Add(author);
        await _unit.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var author = await _unit.AuthorRepository.GetById(id) ?? throw new NullReferenceException();
        await _unit.AuthorRepository.Delete(author);
        await _unit.SaveChangesAsync();
    }

    public async Task Update(int id, AuthorDTO entity)
    {
        _validator.ValidateAndThrow(entity);

        var author = await _unit.AuthorRepository.GetById(id) ?? throw new NullReferenceException();

        author.Name = entity.Name;
        author.Email = entity.Email;
        author.Password = entity.Password; //hashing?
        
        await _unit.AuthorRepository.Update(author);
        await _unit.SaveChangesAsync();
    }
}
