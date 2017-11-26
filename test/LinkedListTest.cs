using Xunit;
using FluentAssertions;

using CoreAlgos;

namespace CoreAlgos.Test
{
    public class SinglyLinkedListTest
    {
        [Fact]
        public void CreateEmptyList()
        {
            var list = new SinglyLinkedList<int>();
            list.Length.Should().Be(0);
        }

        [Fact]
        public void AppendAddsAnElement()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(10);
            list.Length.Should().Be(1);
            list.GetAtIndex(0).Should().Be(10);
        }

        [Fact]
        public void AppendAddsTwoElements()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(10);
            list.Append(20);
            list.Length.Should().Be(2);
            list.GetAtIndex(0).Should().Be(10);
            list.GetAtIndex(1).Should().Be(20);
        }
    }
}
