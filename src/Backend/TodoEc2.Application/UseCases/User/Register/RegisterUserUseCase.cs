﻿using AutoMapper;
using TodoEc2.Application.Services.Cryptografy;
using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;
using TodoEc2.Domain.Repositories;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Domain.Security.Tokens;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncrypter _passwordEncrypter;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IAccessTokenGenerator _accessTokenGenerator ;

        public RegisterUserUseCase(
            IUserReadOnlyRepository readOnlyRepository,
            IUserWriteOnlyRepository writeOnlyRepository,
            IMapper mapper,
            PasswordEncrypter passwordEncrypter,
            IUnityOfWork unityOfWork,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mapper = mapper;
            _passwordEncrypter = passwordEncrypter;
            _unityOfWork = unityOfWork;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            // Validade * FluentValidator
            Validate(request);

            // Mapping * AutoMapper
            var user = _mapper.Map<Domain.Entities.User>(request);

            // Criptografy
            user.Password = _passwordEncrypter.Encrypt(request.Password);
            user.UserIdentifier = Guid.NewGuid();

            // Save DB * EntityFrameworkCore
            await _writeOnlyRepository.Add(user);

            await _unityOfWork.Commit();

            return new ResponseRegisterUserJson
            {
                Name = request.Name,
                Tokens = new ResponseTokensJson
                {
                    AccessToken = _accessTokenGenerator.Generate(user.UserIdentifier),
                }
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
