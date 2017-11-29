using System;

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
    public class SinglyLinkedList<T>
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
