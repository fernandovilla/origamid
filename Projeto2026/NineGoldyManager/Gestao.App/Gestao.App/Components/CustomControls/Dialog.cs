using Blazored.LocalStorage;
using Gestao.App.Data;
using Gestao.App.Services.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Gestao.App.Components.Pages.Base
{
    public enum DialogStyleEnum
    {
        Ok = 1,
        Question = 2,
    }

    public enum DialogDefaultButton
    {
        Ok = 1,
        Sim = 2,
        Nao = 3
    }

    public enum DialogIconEnum
    {
        None = 0,
        Information = 1,
        Exclamation = 2,
        Question = 3,
        Critical = 4
    }
}