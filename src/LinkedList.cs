using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreAlgos
{
    /// <summary>
    ///   A singly linked list data structure. It is not thread-safe, so synchronization falls to
    ///   the user.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     Implementation-wise this is the classic singly linked list, with a single sentinel node
    ///     and a circular structure.
    ///   </para>
    /// </remarks>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Data { get; private set; }
            public Node Next { get; set; }

            public Node()
            {
                Data = default(T);
                Next = null;
            }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private class Enumerator : IEnumerator<T>
        {
            private SinglyLinkedList<T> _list;
            private Node _curr;

            public Enumerator(SinglyLinkedList<T> list)
            {
                _list = list;
                _curr = list.Head;
            }

            public bool MoveNext()
            {
                if (_curr.Next == _list.Head) {
                    return false;
                }

                _curr = _curr.Next;
                return true;
            }

            public void Reset()
            {
                _curr = _list.Head;
            }

            void IDisposable.Dispose() {}
            public T Current => _curr.Data;
            object IEnumerator.Current => Current;
        }

        private Node Head { get; set; }
        private Node Tail { get; set; }
        private int _length;

        /// <summary>
        ///   Construct an empty list.
        /// </summary>
        public SinglyLinkedList()
        {
            Head = new Node();
            Tail = Head;
            Head.Next = Tail;
            _length = 0;
        }

        /// <summary>
        ///   Obtain an enumerator for this collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator" /> for the collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        ///   Retrieve the element at the provided index in the list.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(index)</c> - linear in the size of the index therefore.
        ///     The space complexity is <c>O(1)</c>.
        ///   </para>
        /// </remarks>
        /// <param name="index">The position of the element to retrieve</param>
        /// <returns>The value at position <paramref name="index"/></returns>
        /// <exception cref="IndexOutOfRangeException">
        ///   If <paramref name="index"/> is less than <c>0</c> or larger than the length of the
        ///   list.
        /// </exception>
        public T GetAtIndex(int index)
        {
            if (index < 0 || index >= _length)
                throw new IndexOutOfRangeException();

            var curr = Head.Next;

            for (var i = 0; i < index; i++)
                curr = curr.Next;

            return curr.Data;
        }

        /// <summary>
        ///   Add a new element to the end of the list.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(1)</c> and the space complexity is the same.
        ///   </para>
        /// </remarks>
        /// <param name="newData">The element to add</param>
        /// <returns>The list, for use in fluent interfaces</returns>
        public SinglyLinkedList<T> Append(T newData)
        {
            var newNode = new Node(newData);
            newNode.Next = Head;
            Tail.Next = newNode;
            Tail = newNode;
            _length++;

            return this;
        }

        /// <summary>
        ///   Add a new element to the end of the list. Standard collection interface.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(1)</c> and the space complexity is the same.
        ///   </para>
        /// </remarks>
        /// <param name="newData">The element to add</param>
        public void Add(T newData) => Append(newData);

        /// <summary>
        ///   Remove the last element from the list.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(N)</c> and the space complexity is <c>O(1)</c>.
        ///   </para>
        /// </remarks>
        /// <param name="result">An output parameter which will contain the removed value</param>
        /// <returns>
        ///     The list, for use in fluent interfaces and the removed element as an output
        ///     parameter.
        /// </returns>
        /// <exception cref="InvalidOperationException">If there are no elements to remove</exception>
        public SinglyLinkedList<T> PopLast(out T result)
        {
            if (_length == 0)
                throw new InvalidOperationException();

            var newTail = Head.Next;
            while (newTail.Next != Tail)
                newTail = newTail.Next;

            result = Tail.Data;
            newTail.Next = Head;
            Tail = newTail;
            _length--;

            return this;
        }

        /// <summary>
        ///   Add a new element to the front of the list.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(1)</c> and the space complexity is the same.
        ///   </para>
        /// </remarks>
        /// <param name="newData">The element to add</param>
        /// <returns>The list, for use in fluent interfaces</returns>
        public SinglyLinkedList<T> Prepend(T newData)
        {
            var newNode = new Node(newData);
            newNode.Next = Head.Next;
            Head.Next = newNode;
            _length++;

            return this;
        }

        /// <summary>
        ///   Remove the first element from the list.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(1)</c> and the space complexity is the same.
        ///   </para>
        /// </remarks>
        /// <param name="result">An output parameter which will contain the removed value</param>
        /// <returns>
        ///     The list, for use in fluent interfaces and the removed element as an output
        ///     parameter.
        /// </returns>
        /// <exception cref="InvalidOperationException">If there are no elements to remove</exception>
        public SinglyLinkedList<T> PopFirst(out T result)
        {
            if (_length == 0)
                throw new InvalidOperationException();

            result = Head.Next.Data;
            Head.Next = Head.Next.Next;
            _length--;

            return this;
        }

        /// <summary>
        ///   Finds the first position a given value appears in the list.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(N)</c> in the worst and average cases, and the space
        ///     complexity is <c>O(1)</c>.
        ///   </para>
        ///   <para>
        ///     Only finds the first occurrence of the given element.
        ///   </para>
        /// </remarks>
        /// <param name="needle">The element to find</param>
        /// <returns>The position in the list at which the element was found, or -1 if it wasn't found</returns>
        public int FindElement(T needle)
        {
            var currNode = Head.Next;
            var index = 0;

            while (currNode != Head)
            {
                if (currNode.Data.Equals(needle))
                    return index;

                currNode = currNode.Next;
                index++;
            }

            return -1;
        }

        /// <summary>
        ///   Finds the first position a given filter function is true.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(N)</c> in the worst and average cases, and the space
        ///     complexity is <c>O(1)</c>.
        ///   </para>
        ///   <para>
        ///     Only finds the first occurrence of the element.
        ///   </para>
        /// </remarks>
        /// <param name="filter">The function to apply to each element</param>
        /// <returns>The position in the list at which the element was found, or -1 if it wasn't found</returns>
        public int FindElement(Func<T, bool> filter)
        {
            var currNode = Head.Next;
            var index = 0;

            while (currNode != Head)
            {
                if (filter(currNode.Data))
                    return index;

                currNode = currNode.Next;
                index++;
            }

            return -1;
        }

        /// <summary>
        ///   Build a reversed version of the current list as a new list.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(N)</c> and the space complexity is <c>O(N)</c> since it
        ///     creates a new list.
        ///   </para>
        /// </remarks>
        /// <returns>A copy of the current list, only in reverse</returns>
        public SinglyLinkedList<T> Reverse()
        {
            var reversedList = new SinglyLinkedList<T>();
            var currNode = Head.Next;

            while (currNode != Head)
            {
                reversedList.Prepend(currNode.Data);
                currNode = currNode.Next;
            }

            return reversedList;
        }

        /// <summary>
        ///   Reverse the current list in place.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The time complexity is <c>O(N)</c> and the space complexity is <c>O(1)</c>, but the
        ///     list is affected.
        ///   </para>
        /// </remarks>
        /// <returns>The list, for use in fluent interfaces</returns>
        public SinglyLinkedList<T> ReverseInPlace()
        {
            // The trick here is to use currNode as the current iterator for the list
            // Head as the "previous" node and Tail as the "next" node. We walk each node
            // and switch its Next reference to the previous node / Head. We use Tail
            // so that we can then move to the next reference.
            var currNode = Head.Next;
            Tail = currNode;

            // We basically process the list until we reach the last element, which will point to
            // the Head of the list.
            while (currNode.Next != Head)
            {
                Tail = currNode.Next;
                currNode.Next = Head;
                Head = currNode;
                currNode = Tail;
            }

            return this;
        }

        /// <summary>
        ///   The number of elements in the list.
        /// </summary>
        public int Length => _length;
    }
}
