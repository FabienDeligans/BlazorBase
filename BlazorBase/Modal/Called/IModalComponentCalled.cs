using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace BlazorBase.Modal.Called
{
    public interface IModalComponentCalled : IComponent
    {
        [CascadingParameter]
        BlazoredModalInstance ModalInstance { get; set; }

        [Parameter]
        public string Parameter { get; set; }
        public object ReturnedObject { get; set; }

        public void Submit();
        public void Cancel();
    }
}
