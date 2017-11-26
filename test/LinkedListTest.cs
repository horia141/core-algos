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
            list.Append(10).Append(20);
            list.Length.Should().Be(2);
            list.GetAtIndex(0).Should().Be(10);
            list.GetAtIndex(1).Should().Be(20);
        }

        [Fact]
        public void PrependAddsAnElement()
        {
            var list = new SinglyLinkedList<int>();
            list.Prepend(10);
            list.Length.Should().Be(1);
            list.GetAtIndex(0).Should().Be(10);
        }

        [Fact]
        public void PrependAddsTwoElements()
        {
            var list = new SinglyLinkedList<int>();
            list.Prepend(10).Prepend(20);
            list.Length.Should().Be(2);
            list.GetAtIndex(0).Should().Be(20);
            list.GetAtIndex(1).Should().Be(10);
        }

        [Fact]
        public void AppendAndPrepend()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(10).Prepend(20).Append(30).Prepend(40);
            list.Length.Should().Be(4);
            list.GetAtIndex(0).Should().Be(40);
            list.GetAtIndex(1).Should().Be(20);
            list.GetAtIndex(2).Should().Be(10);
            list.GetAtIndex(3).Should().Be(30);
        }
    }
}
