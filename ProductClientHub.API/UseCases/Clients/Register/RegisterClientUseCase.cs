﻿using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    //public class RegisterClientUseCase(ProductClientHubDbContext context)
    public class RegisterClientUseCase
    {

        public ResponseShortClientJson Execute(RequestClientJson request)
        {

            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email
            };

            dbContext.Clients.Add(entity);  

            dbContext.SaveChanges();

            //return new ResponseClientJson();
            return new ResponseShortClientJson
            {
                Id = entity.Id,
                Name = entity.Name,
                //Email = entity.Email
            };

        }

        private static void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
