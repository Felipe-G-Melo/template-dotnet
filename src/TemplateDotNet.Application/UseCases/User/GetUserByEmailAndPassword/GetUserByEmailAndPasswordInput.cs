﻿namespace TemplateDotNet.Application.UseCases.User.GetUserByEmailAndPassword;
public class GetUserByEmailAndPasswordInput
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    public GetUserByEmailAndPasswordInput(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
