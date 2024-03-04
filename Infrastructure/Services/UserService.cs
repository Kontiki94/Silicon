using Infrastructure.Entitys;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Models.Sections;
using Infrastructure.Repositories;


namespace Infrastructure.Services
{
    public class UserService(UserRepository repository, AddressService addressService)
    {
        private readonly UserRepository _repository = repository;
        private readonly AddressService _addressService = addressService;

        public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
        {
            try
            {
                var exists = await _repository.AlreadyExistsAsync(x => x.Email == model.Email);
                if (exists.StatusCode == StatusCode.EXISTS)
                    return exists;

                var (user, credentials) = UserFactory.Create(model);

                var result = await _repository.CreateUserWithCredentialsAsync(user, credentials);
                if (result.StatusCode != StatusCode.OK)
                    return result;

                return ResponseFactory.Ok("User created successfully.");
            }
            catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
        }

        public async Task<ResponseResult> SignInUserAsync(SignInModel model)
        {
            try
            {
                var userEntity = await _repository.GetUserAndIncludeCredentialsAsync(x => x.Email == model.Email);
                if (userEntity != null)
                {
                    var credentialEntity = userEntity.Credentials.FirstOrDefault();
                    if (credentialEntity != null && PasswordHasher.ValidateSecurePassword(model.Password, credentialEntity.HashedPassword, credentialEntity.Salt, credentialEntity.SecurityKey))
                    {
                        return ResponseFactory.Ok();
                    }
                }

                return ResponseFactory.Error("Incorrect email or password");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> UpdateCredentials(AccountSecurityModel securityModel)
        {
            try
            {
                var email = "ted@ted.se";//Plockar från användarsession när vi löst det
                var userEntity = await _repository.GetUserAndIncludeCredentialsAsync(x => x.Email == email);
                if (userEntity is null)
                {
                    return ResponseFactory.NotFound();
                }
                else if (userEntity is not null)
                {
                    var credentialEntity = userEntity.Credentials.FirstOrDefault();
                    if (credentialEntity != null && PasswordHasher.ValidateSecurePassword(securityModel.Password, credentialEntity.HashedPassword, credentialEntity.Salt, credentialEntity.SecurityKey))
                    {
                        var generateNewPassword = PasswordHasher.GenerateSecurePassword(securityModel.NewPassword);
                        credentialEntity.HashedPassword = generateNewPassword.HashedPassword;
                        credentialEntity.Salt = generateNewPassword.Salt;
                        credentialEntity.SecurityKey = generateNewPassword.SecurityKey;
                        userEntity.Password = generateNewPassword.HashedPassword;
                        var updated = await _repository.UpdateAsync(userEntity);
                        if (updated.StatusCode == StatusCode.OK)
                        {
                            return updated;
                        }
                    }
                }
                return ResponseFactory.Error("Something went wrong");

            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> UpdateUserAsync(UserEntity entity)
        {
            try
            {
                var entityToUpdate = await _repository.UpdateOneAsync(x => x.Email == entity.Email, entity);
                if (entityToUpdate != null)
                {
                    return ResponseFactory.Ok(entityToUpdate);
                }
                return ResponseFactory.Error("Incorrect email or password");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> DeleteUser()
        {

            try
            {
                var email = "ted@ted.se"; //inloggade sessionen
                var result = await _repository.DeleteAsync(x => x.Email == email);

                if (result.StatusCode == StatusCode.OK)
                {
                    return ResponseFactory.Ok();
                }
                else
                {
                    return ResponseFactory.Error("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
    }
}


