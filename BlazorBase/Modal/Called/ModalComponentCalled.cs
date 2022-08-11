﻿using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBase.Modal.Called
{
    public abstract class ModalComponentCalled : ComponentBase, IModalComponentCalled
    {
        [CascadingParameter]
        public BlazoredModalInstance ModalInstance { get; set; }
        
        [Parameter]
        public string Parameter { get; set; }
        
        public object ReturnedObject { get; set; }

        public virtual void Submit()
        {
            ModalInstance.CloseAsync(ModalResult.Ok(ReturnedObject));
        }

        public virtual void Cancel()
        {
            ModalInstance.CancelAsync();
        }
    }
}
