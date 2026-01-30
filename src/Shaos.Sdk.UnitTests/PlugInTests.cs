namespace Shaos.Sdk.UnitTests
{
    public class PlugInTests
    {
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
        public void TestPlugInPropertiesAndDispose()
        {
            {
                using var plugIn = new TestPlugIn();

                plugIn.Id = 10;

                Assert.NotNull(plugIn.Devices);
                Assert.Equal(10, plugIn.Id);
            }
        }
    }
}