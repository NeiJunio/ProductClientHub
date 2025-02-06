using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase(ProductClientHubDbContext context)
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {

            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email
            };

            context.Clients.Add(entity);  

            context.SaveChanges();

            return new ResponseClientJson();

        }

        private static void Validate(RequestClientJson request)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
