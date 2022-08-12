using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBase.Component.Modal.Caller
{
    public interface IModalComponentCaller
    {
        [CascadingParameter] public IModalService Modal { get; set; }
        Task ShowModal<T>(string parameter, string title) where T : IComponent;
    }
}