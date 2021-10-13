namespace Exemplum.EndToEndTests.Pages
{
    using FluentAssertions;
    using PlaywrightSharp;
    using System.Threading.Tasks;

    public class TaskListPage : BasePage
    {
        public TaskListPage(IPage page) : base(page)
        {
        }

        protected override string PagePath => "todolists";

        public async Task ValidateCanAccessPage()
        {
            var todoListTitle = await Page.WaitForSelectorAsync("#todo-list-title");
            todoListTitle.Should().NotBeNull();
        }
    }
}