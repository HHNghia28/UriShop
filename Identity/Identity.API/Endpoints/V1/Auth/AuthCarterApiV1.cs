using Carter;
using Identity.Application.Features.Auth.Commands.AccessToken;
using Identity.Application.Features.Auth.Commands.ChangeDeleteUser;
using Identity.Application.Features.Auth.Commands.ChangePassword;
using Identity.Application.Features.Auth.Commands.ConfirmEmail;
using Identity.Application.Features.Auth.Commands.ForgotPassword;
using Identity.Application.Features.Auth.Commands.LoginUser;
using Identity.Application.Features.Auth.Commands.RegisterUser;
using Identity.Application.Features.Auth.Commands.ResendEmail;
using Identity.Application.Features.Auth.Commands.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Identity.API.Endpoints.V1.Auth
{
    public class AuthCarterApiV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/auth";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.NewVersionedApi("auth-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group.MapPost("register", Register);
            group.MapPost("login", Login);
            group.MapGet("confirm-email", ConfirmEmail);
            group.MapPost("resend-comfirm", ReSendConfirmEmail);
            group.MapPut("change-password", ChangePassword);
            group.MapPut("forgot-password", ForgotPassword);
            group.MapPut("reset-password", ResetPassword);
            group.MapPut("access-token", AccessToken);
            group.MapPut("block", Block).RequireAuthorization("AdminPolicy");
            group.MapPut("unblock", UnBlock).RequireAuthorization("AdminPolicy");
        }

        public async Task<IResult> Register(ISender sender, [FromBody] RegisterUserCommand command)
        {
            await sender.Send(command);
            return Results.Ok("User registered successfully.");
        }

        public async Task<IResult> Login(ISender sender, [FromBody] LoginUserCommand command)
        {
            var response = await sender.Send(command);
            if (response == null) return Results.Unauthorized();
            return Results.Ok(response);
        }

        public async Task<IResult> ConfirmEmail(ISender sender, [FromQuery] Guid userId, [FromQuery] string code)
        {
            var response = await sender.Send(new ConfirmEmailCommand { Code = code, UserId = userId});
            return Results.Ok(response);
        }

        public async Task<IResult> ReSendConfirmEmail(ISender sender, [FromBody] ResendConfirmEmailCommand command)
        {
            await sender.Send(command);
            return Results.Ok("Resend successful");
        }

        public async Task<IResult> ChangePassword(ISender sender, [FromBody] ChangePasswordCommand command)
        {
            await sender.Send(command);
            return Results.Ok("Change password successful");
        }

        public async Task<IResult> ForgotPassword(ISender sender, [FromBody] ForgotPasswordCommand command)
        {
            await sender.Send(command);
            return Results.Ok("Email sended");
        }

        public async Task<IResult> ResetPassword(ISender sender, [FromBody] ResetPasswordCommand command)
        {
            await sender.Send(command);
            return Results.Ok("Reset password successful");
        }

        public async Task<IResult> AccessToken(ISender sender, [FromBody] AccessTokenCommand command)
        {
            var response = await sender.Send(command);
            return Results.Ok(response);
        }

        public async Task<IResult> Block(ISender sender, Guid id)
        {
            ChangeDeletedUserCommand command = new() { IsDeleted = true, UserId = id };
            await sender.Send(command);
            return Results.Ok("Block successful");
        }

        public async Task<IResult> UnBlock(ISender sender, Guid id)
        {
            ChangeDeletedUserCommand command = new() { IsDeleted = false, UserId = id };
            await sender.Send(command);
            return Results.Ok("UnBlock successful");
        }
    }
}
