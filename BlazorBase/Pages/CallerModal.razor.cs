using BlazorBase.Modal.Caller;
using Blazored.Modal;

namespace BlazorBase.Pages
{
    public partial class CallerModal : ModalComponentCaller
    {
        public override async Task ShowModal<T>(string parameter, string title)
        {
            var parameters = new ModalParameters();
            if (parameter != null)
            {
                parameters.Add("Parameter", parameter);
            }

            var modal = Modal.Show<T>(title, parameters);
            var result = await modal.Result;

            if (!result.Cancelled)
            {
                ReturnedObject = result.Data;
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}
