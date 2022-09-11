using BlazorBase.Component;
using BlazorBase.Component.Modal.Caller;
using BlazorBase.Model;
using BlazorBase.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorBase.Pages.Demo
{
    public partial class CallerModal : ModalComponentCaller
    {
        [Inject]
        public ServiceBase ServiceBase { get; set; }

        private List<Truc>ModelTestList { get; set; }
        public TableComponent<Truc> TableModelComponent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ModelTestList = new List<Truc>();
            for (var i = 0; i < 50; i++)
            {
                var truc = new Truc()
                {
                    Id = i,
                    Data = @$"Name-{i}",
                    Numeric = Faker.RandomNumber.Next(0, 50)
                };
               await ServiceBase.CreateAsync(truc);
            }

            var result = await ServiceBase.ReadAllAsync<Truc>();
            ModelTestList = result.ToList();
        }
    }
}
