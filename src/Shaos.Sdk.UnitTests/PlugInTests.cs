namespace Shaos.Sdk.UnitTests
{
    public class PlugInTests
    {
        private TestPlugIn _plugIn;

        public PlugInTests()
        {
            _plugIn = new TestPlugIn();
        }

        [Fact]
        public void TestPlugInAttribute()
        {
            var attribute = Attribute.GetCustomAttribute(typeof(TestPlugIn),
                                                         typeof(PlugInDescriptionAttribute)) as PlugInDescriptionAttribute;

            Assert.NotNull(attribute);
            Assert.Equal(nameof(PlugInDescriptionAttribute.Name),
                         attribute.Name);
            Assert.Equal(nameof(PlugInDescriptionAttribute.Description),
                         attribute.Description);
        }

        [Fact]
        public void TestPlugInProperties()
        {
            _plugIn.Id = 10;

            Assert.Equal(10, _plugIn.Id);
        }
    }
}