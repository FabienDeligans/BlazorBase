

namespace BlazorBase.Pages
{
    public partial class Index
    {
        private List<string>ListString { get; set; }
        protected override void OnInitialized()
        {
            ListString = new List<string>()
            {
                Faker.Name.First(),
                Faker.Name.First(),
                Faker.Name.First(),
                Faker.Name.First(),
                Faker.Name.First(),
            }; 
        }
    }
}
