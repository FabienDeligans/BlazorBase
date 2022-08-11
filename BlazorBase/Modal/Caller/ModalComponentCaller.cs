using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBase.Modal.Caller
{
    public abstract class ModalComponentCaller : ComponentBase, IModalComponentCaller
    {
        [CascadingParameter]
        public IModalService Modal { get; set; }
        public object ReturnedObject { get; set; }

        public virtual async Task ShowModal<T>(string parameter, string title) where T : IComponent
        {
            var parameters = new ModalParameters();
            if (parameter != null)
            {
                parameters.Add("Parameter", parameter);
            }

            var modal = Modal.Show<T>(title, parameters);
            var result = await modal.Result;

            if(!result.Cancelled)
            {
                ReturnedObject = result.Data;
            }
            await InvokeAsync(StateHasChanged);
        }
    }
}
