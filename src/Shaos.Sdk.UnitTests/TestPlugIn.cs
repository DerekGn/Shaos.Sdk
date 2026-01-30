
namespace Shaos.Sdk.UnitTests
{
    [PlugInDescription("Name", "Description")]
    internal class TestPlugIn : PlugInBase
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async override Task ExecuteAsync(CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        }
    }
}
