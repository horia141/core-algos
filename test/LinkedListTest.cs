using FluentAssertions;
using System;
using Xunit;

using CoreAlgos;

namespace CoreAlgos.Test
{
    public class SinglyLinkedListTest
    {
        #region Construction

        [Fact]
        public void CreateEmptyList()
        {
            var list = new SinglyLinkedList<int>();
            list.Length.Should().Be(0);
        }

        #endregion

        #region IEnumerableIntegration

        [Fact]
        public void ConstructionViaInitializer()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.Length.Should().Be(3);
            list.GetAtIndex(0).Should().Be(10);
            list.GetAtIndex(1).Should().Be(20);
            list.GetAtIndex(2).Should().Be(30);
        }

        [Fact]
        public void CanBeIterated()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            var enumerator = list.GetEnumerator();

            enumerator.Current.Should().Be(0);
            enumerator.MoveNext().Should().Be(true);
            enumerator.Current.Should().Be(10);
            enumerator.MoveNext().Should().Be(true);
            enumerator.Current.Should().Be(20);
            enumerator.MoveNext().Should().Be(true);
            enumerator.Current.Should().Be(30);
            enumerator.MoveNext().Should().Be(false);
            enumerator.Current.Should().Be(30);
            enumerator.MoveNext().Should().Be(false);
            enumerator.Current.Should().Be(30);
            enumerator.MoveNext().Should().Be(false);
            enumerator.Current.Should().Be(30);
        }

        [Fact]
        public void EnumeratorReset()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            var enumerator = list.GetEnumerator();

            enumerator.Current.Should().Be(0);
            enumerator.MoveNext().Should().Be(true);
            enumerator.Current.Should().Be(10);
            enumerator.MoveNext().Should().Be(true);
            enumerator.Current.Should().Be(20);
            enumerator.Reset();
            enumerator.Current.Should().Be(0);
            enumerator.MoveNext().Should().Be(true);
            enumerator.Current.Should().Be(10);
        }

        [Fact]
        public void CanBeIteratedViaForEach()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.Should().ContainInOrder(new [] {10, 20, 30});

            int idx = 0;
            foreach (var elem in list)
            {
                switch (idx)
                {
                    case 0:
                        elem.Should().Be(10);
                        break;
                    case 1:
                        elem.Should().Be(20);
                        break;
                    case 2:
                        elem.Should().Be(30);
                        break;
                    default:
                        true.Should().Be(false);
                        break;
                }
                idx++;
            }
        }

        #endregion

        #region GetAtIndex

        [Fact]
        public void GetAtIndexThrowsForNegativeIndex()
        {
            var list = new SinglyLinkedList<int>();
            Action action = () => list.GetAtIndex(-1);
            action.ShouldThrow<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetAtIndexThrowsForIndexOutsideOfRange()
        {
            var list = new SinglyLinkedList<int>();
            Action action1 = () => list.GetAtIndex(0);
            Action action2 = () => list.GetAtIndex(1);
            action1.ShouldThrow<IndexOutOfRangeException>();
            list.Append(10);
            action2.ShouldThrow<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetAtIndexProducesTheRightElement()
        {
            var list = new SinglyLinkedList<int>() { 10 };
            list.GetAtIndex(0).Should().Be(10);
        }

        #endregion

        #region Append

        [Fact]
        public void AppendReturnsTheSameList()
        {
            var list = new SinglyLinkedList<int>() { };
            var newList = list.Append(10);
            newList.Should().BeSameAs(list);
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

        #endregion

        #region Add

        [Fact]
        public void AddAddsAnElement()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(10);
            list.Length.Should().Be(1);
            list.GetAtIndex(0).Should().Be(10);
        }

        [Fact]
        public void AddAddsTwoElements()
        {
            var list = new SinglyLinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Length.Should().Be(2);
            list.GetAtIndex(0).Should().Be(10);
            list.GetAtIndex(1).Should().Be(20);
        }

        #endregion

        #region PopLast

        [Fact]
        public void PopLastThrowsWhenThereAreNoElements()
        {
            var list = new SinglyLinkedList<int>();
            Action action = () => list.PopLast(out int notUsed);
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void PopLastReturnsTheSameList()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            var newList = list.PopLast(out int notUsed);
            newList.Should().BeSameAs(list);
        }

        [Fact]
        public void PopLastSingleElement()
        {
            var list = new SinglyLinkedList<int>() {10};
            list.PopLast(out int first);
            first.Should().Be(10);
            list.Length.Should().Be(0);
        }

        [Fact]
        public void PopLastRemovesTheLastElement()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.PopLast(out int first);
            first.Should().Be(30);
            list.Length.Should().Be(2);
            list.GetAtIndex(0).Should().Be(10);
            list.GetAtIndex(1).Should().Be(20);
            list.PopLast(out int second);
            second.Should().Be(20);
            list.Length.Should().Be(1);
            list.GetAtIndex(0).Should().Be(10);
            list.PopLast(out int third);
            third.Should().Be(10);
            list.Length.Should().Be(0);
        }

        #endregion

        #region Prepend

        [Fact]
        public void PrependReturnsTheSameList()
        {
            var list = new SinglyLinkedList<int>();
            var newList = list.Prepend(10);
            newList.Should().BeSameAs(list);
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

        #endregion

        #region PopFirst

        [Fact]
        public void PopFirstThrowsWhenThereAreNoElements()
        {
            var list = new SinglyLinkedList<int>();
            Action action = () => list.PopFirst(out int notUsed);
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void PopFirstReturnsTheSameList()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(10).Append(20).Append(30);
            var newList = list.PopFirst(out int notUsed);
            newList.Should().BeSameAs(list);
        }

        [Fact]
        public void PopFirstSingleElement()
        {
            var list = new SinglyLinkedList<int>() {10};
            list.PopFirst(out int first);
            first.Should().Be(10);
            list.Length.Should().Be(0);
        }

        [Fact]
        public void PopFirstRemovesTheFirstElement()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.PopFirst(out int first);
            first.Should().Be(10);
            list.Length.Should().Be(2);
            list.GetAtIndex(0).Should().Be(20);
            list.GetAtIndex(1).Should().Be(30);
            list.PopFirst(out int second);
            second.Should().Be(20);
            list.Length.Should().Be(1);
            list.GetAtIndex(0).Should().Be(30);
            list.PopFirst(out int third);
            third.Should().Be(30);
            list.Length.Should().Be(0);
        }

        #endregion

        #region FindElement

        [Fact]
        public void FindElementReturnsTheElementsPosition()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.FindElement(10).Should().Be(0);
            list.FindElement(20).Should().Be(1);
            list.FindElement(30).Should().Be(2);
        }

        [Fact]
        public void FindElementReturnsMinus1WhenItCantFindAnElement()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.FindElement(-10).Should().Be(-1);
            list.FindElement(-20).Should().Be(-1);
            list.FindElement(-30).Should().Be(-1);
        }

        [Fact]
        public void FindElementWithFilterReturnsTheElementsPosition()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.FindElement(x => x == 10).Should().Be(0);
            list.FindElement(x => x == 20).Should().Be(1);
            list.FindElement(x => x == 30).Should().Be(2);
        }

        [Fact]
        public void FindElementWithFilterReturnsMinus1WhenItCantFindAnElement()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.FindElement(x => x == -10).Should().Be(-1);
            list.FindElement(x => x == -20).Should().Be(-1);
            list.FindElement(x => x == -30).Should().Be(-1);
        }

        [Fact]
        public void FindElementWithFilterAndNonEquality()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.FindElement(x => x > 10).Should().Be(1);
        }

        #endregion

        #region Reverse

        [Fact]
        public void ReverseProducesANewList()
        {
            var list = new SinglyLinkedList<int>();
            var reversedList = list.Reverse();
            reversedList.Should().NotBeSameAs(list);
            reversedList.Length.Should().Be(0);
        }

        [Fact]
        public void ReverseOneElement()
        {
            var list = new SinglyLinkedList<int>() {10};
            var reversedList = list.Reverse();
            reversedList.Length.Should().Be(1);
            reversedList.GetAtIndex(0).Should().Be(10);
        }

        [Fact]
        public void ReverseMultipleElements()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            var reversedList = list.Reverse();
            reversedList.Length.Should().Be(3);
            reversedList.GetAtIndex(0).Should().Be(30);
            reversedList.GetAtIndex(1).Should().Be(20);
            reversedList.GetAtIndex(2).Should().Be(10);
        }

        #endregion

        #region ReverseInPlace

        [Fact]
        public void ReverseInPlaceProducesTheSameList()
        {
            var list = new SinglyLinkedList<int>();
            var reversedList = list.ReverseInPlace();
            reversedList.Should().BeSameAs(list);
        }

        [Fact]
        public void ReverseInPlaceOneElement()
        {
            var list = new SinglyLinkedList<int>() {10};
            list.ReverseInPlace();
            list.Length.Should().Be(1);
            list.GetAtIndex(0).Should().Be(10);
        }

        [Fact]
        public void ReverseInPlaceMultipleElements()
        {
            var list = new SinglyLinkedList<int>() {10, 20, 30};
            list.ReverseInPlace();
            list.Length.Should().Be(3);
            list.GetAtIndex(0).Should().Be(30);
            list.GetAtIndex(1).Should().Be(20);
            list.GetAtIndex(2).Should().Be(10);
        }

        #endregion
    }
}
