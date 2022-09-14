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

        private List<Truc> ModelTestList { get; set; }
        public TableComponent<Truc> TableModelComponent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await ServiceBase.ReadAllAsync<Truc>();
            ModelTestList = result.ToList();
            foreach (var truc in ModelTestList)
            {
                await ServiceBase.DeleteOneAsync<Truc>(truc.Id);
            }

            ModelTestList = new List<Truc>();
            for (var i = 0; i < 50; i++)
            {
                try
                {

                    var truc = new Truc()
                    {
                        Data = @$"Name-{i}",
                        Numeric = Faker.RandomNumber.Next(0, 500),
                        Now = DateTime.Now
                    };
                    await ServiceBase.CreateAsync(truc);
                }
                catch (Exception e)
                {
                    Error = e.Message; 
                }
            }

            result = await ServiceBase.ReadAllAsync<Truc>();
            ModelTestList = result.ToList();
        }

        public string Error { get; set; }
    }
}
