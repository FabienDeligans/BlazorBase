using BlazorBase.Component;
using BlazorBase.Component.Modal.Caller;
using BlazorBase.Model;
using Blazored.Modal;

namespace BlazorBase.Pages.Demo
{
    public partial class CallerModal : ModalComponentCaller
    {
        private List<ModelTest>ModelTestList { get; set; }
        public TableComponent<ModelTest> TableModelComponent { get; set; }

        protected override void OnInitialized()
        {
            ModelTestList = new List<ModelTest>();
            for (var i = 0; i < 357; i++)
            {
                ModelTestList.Add(new ModelTest()
                {
                    Id = i, 
                    Name = @$"Name-{i}"
                });
            }
        }
    }
}
