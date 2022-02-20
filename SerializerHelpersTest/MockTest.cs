using Xunit;
using SerializerHelpers;

namespace SerializerHelpersTest
{
    public class MockTest
    {
        [Fact]
        public void Test1()
        {
            string? ser1 = Serializer.Serialize(99);
            int des1 = Serializer.Deserialize<int>(ser1);

            string? ser2 = Serializer.Serialize(99);
            int des2 = Serializer.Deserialize<int>(ser2);


        }
    }
}