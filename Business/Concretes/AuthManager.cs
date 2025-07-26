
    using Business.Abstracts;
    using Business.Constants;
    using Business.Rules;
    using Core.Security.Dtos;
    using Core.Security.Entites;
    using Core.Security.Hashing;
    using Core.Security.JWT;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IOperationClaimRepository _operationClaimRepository;

    public AuthManager(
        IUserService userService,
        ITokenHelper tokenHelper,
        IUserOperationClaimRepository userOperationClaimRepository,
        AuthBusinessRules authBusinessRules,
        IOperationClaimRepository operationClaimRepository)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _authBusinessRules = authBusinessRules;
        _operationClaimRepository = operationClaimRepository;
    }

    public AccessToken CreateAccessToken(User user)
    {
        // Kullanıcının claimlerini al
        List<OperationClaim> claims = _userOperationClaimRepository.Query()
            .AsNoTracking()
            .Where(x => x.UserId == user.Id)
            .Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToList();

        // Token oluştur
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }

    public AccessToken Login(UserForLoginDto userForLoginDto)
    {
        // Email ile kullanıcıyı getir
        var user = _userService.GetByMail(userForLoginDto.Email);

        // Kuralları uygula
        _authBusinessRules.UserShouldBeExists(user); // Kullanıcı var mı kontrol et
        _authBusinessRules.UserPasswordShouldBeMatch(user.Id, userForLoginDto.Password); // Parola doğru mu kontrol et
        // _authBusinessRules.UserEmailShouldBeExists(userForLoginDto.Email); // Bu kurala gerek yok çünkü UserShouldBeExists zaten kontrol ediyor

        // Token üret
        var accessToken = CreateAccessToken(user);
        return accessToken;
    }

    public AccessToken Register(UserForRegisterDto userForRegisterDto)
    {
        // Email zaten var mı kontrol et
        _authBusinessRules.UserEmailShouldBeNotExists(userForRegisterDto.Email);

        // Şifre hash ve salt oluştur
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

        // Yeni kullanıcı nesnesi oluştur
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        // Kullanıcıyı ekle
        User createdUser = _userService.AddEntity(user);

        // Varsayılan rolü ata
        OperationClaim? defaultRole = _operationClaimRepository.Get(x => x.Name == OperationClaims.Default);
        if (defaultRole == null)
            throw new Exception("Default role not found."); // Role kontrolü eklenebilir

        UserOperationClaim userOperationClaim = new UserOperationClaim
        {
            UserId = createdUser.Id,
            OperationClaimId = defaultRole.Id
        };

        _userOperationClaimRepository.Add(userOperationClaim);

        // Token oluştur
        var accessToken = CreateAccessToken(createdUser);
        return accessToken;
    }
}

