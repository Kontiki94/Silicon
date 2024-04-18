﻿using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;


    public async Task<ResponseResult> CreateAddressAsync(AddressModel model)
    {
        try

        {
            var result = await _addressRepository.CreateOneAsync(AddressFactory.Create(model.UserId, model.AddressLine1, model.AddressLine2, model.PostalCode, model.City));
            if (result.StatusCode == StatusCode.OK)
            {
                var createdAddressEntity = (AddressEntity)result.ContentResult!;
                createdAddressEntity.UserId = model.UserId;
                var newUserAddress = new UserAddressEntity
                {
                    UserId = model.UserId,
                    AddressId = model.Id
                };

                var createdAddressModel = AddressFactory.Create(createdAddressEntity);
                return ResponseFactory.Ok(result.ContentResult!);
            }
            return result;

        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

    public async Task<ResponseResult> CreateOrUpdateAddressAsync(AddressModel model)
    {
        try
        {
            if (model is not null)
            {
                var addressResult = await _addressRepository.GetOneAsync(a => a.UserId == model.UserId);

                if (addressResult.StatusCode == StatusCode.OK)
                {
                    var existingAddress = (AddressEntity)addressResult.ContentResult!;
                    var updatedAddressEntity = AddressFactory.Update(existingAddress, model);
                    var updateResult = await _addressRepository.UpdateOneAsync(a => a.UserId == model.UserId, updatedAddressEntity);

                    if (updateResult.StatusCode == StatusCode.OK)
                        return ResponseFactory.Ok(existingAddress);

                    return updateResult;
                }
                else if (addressResult.StatusCode == StatusCode.NOT_FOUND)
                {
                    return await CreateAddressAsync(model);
                }
            }
            return ResponseFactory.NotFound("Address not found.");
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

    public async Task<ResponseResult> GetAddressByIdAsync(string userId)
    {
        try
        {
            var result = await _addressRepository.GetOneAsync(x => x.UserId == userId);
            if (result.StatusCode == StatusCode.OK)
            {
                var addressEntity = (AddressEntity)result.ContentResult!;
                var addressModel = AddressFactory.Create(addressEntity);
                return new ResponseResult()
                {
                    StatusCode = result.StatusCode,
                    ContentResult = addressModel,
                };
            }
            return ResponseFactory.NotFound("Address not found");
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}
