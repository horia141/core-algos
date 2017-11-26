namespace CoreAlgos
{
    public class SinglyLinkedList<T>
    {
        private class Node
        {
            private T Data { get; set; }
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
        public int Length { get; private set; }

        public SinglyLinkedList()
        {
            Head = new Node();
            Tail = new Node();
            Head.Next = Tail;
            Length = 0;
        }

        public SinglyLinkedList<T> Append(T newData)
        {
            var newNode = new Node(newData);
            Tail.Next = newNode;
            Tail = newNode;
            Length = Length + 1;

            return this;
        }
    }
}
