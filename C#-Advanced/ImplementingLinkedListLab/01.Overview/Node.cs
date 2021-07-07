namespace CustomDoublyLinkedList
{
    public class Node<T>
    {
        
        public T Value { get; set; }
        public Node<T> Previews { get; set; }
        public Node<T> Next { get; set; }

    }
}
