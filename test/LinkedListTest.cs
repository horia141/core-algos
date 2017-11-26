using Xunit;
using FluentAssertions;

using CoreAlgos;

namespace CoreAlgos.Test
{
    public class SinglyLinkedListTest
    {
        [Fact]
        public void ShouldCreateEmptyList()
        {
            var list = new SinglyLinkedList<int>();
            list.Length.Should().Be(0);
        }
    }
}
