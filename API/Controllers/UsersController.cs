namespace API.Controllers;
using API.Data;
using API.DTOs;
using API.DataEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UsersController(UserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper=mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberResponse>>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        var response =_mapper.Map<IEnumerable<MemberResponse>>(users);

        return Ok(response);
    }

    [HttpGet("{id:int}")] // api/users/2
    public async Task<ActionResult<MemberResponse>> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null) 
        {
            return NotFound();
        }

        return _mapper.Map<MemberResponse>(user);
    }

    [HttpGet("{username}")] // api/users/Calamardo
    public async Task<ActionResult<MemberResponse>> GetByUsernameAsync(string username)
    {
        var user = await _repository.GetByUsernameAsync(username);

        if (user == null) 
        {
            return NotFound();
        }

        return _mapper.Map<MemberResponse>(user);
    }
}