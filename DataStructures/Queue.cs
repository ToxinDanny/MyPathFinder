namespace MyPathFinder.DataStructures
{
    public class Node<T>
    {
        public T Value;
        public Node<T>? Parent { get; set; }
        public Node<T>? Child { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public class DoubleLinkedList<T>(T root)
        where T : IEquatable<T>
    {
        public Node<T>? Root { get; set; } = new Node<T>(root);
        public Node<T>? Last { get; set; } = new Node<T>(root);

        public int Length { get; set; } = 1;

        public Node<T>? this[T value]
        {
            get => Root is not null ? Search(value, Root) : null;
        }

        public T? this[int index]
        {
            get
            {
                if (Root is null)
                    return default;

                var traverse = Traverse(Root, index);

                if (traverse != null)
                    return traverse.Value;

                return default;
            }
        }

        public void AddLast(Node<T> toAdd)
        {
            AddTail(Root?.Child is null ? Root : Last, toAdd);
            Last = toAdd;
        }

        private void AddTail(Node<T>? addTo, Node<T> toAdd)
        {
            if (addTo == null)
                return;

            if (addTo.Child == null)
            {
                addTo.Child = toAdd;
                toAdd.Parent = addTo;
                Length++;
                return;
            }

            AddTail(addTo.Child, toAdd);
        }

        public void AddFirst(Node<T> toAdd)
        {
            AddHead(Root, toAdd);
            Root = toAdd;
        }

        private void AddHead(Node<T>? addTo, Node<T> toAdd)
        {
            if(addTo == null)
                return;

            if (addTo.Parent == null)
            {
                addTo.Parent = toAdd;
                toAdd.Child = addTo;
                Length++;
                return;
            }

            AddHead(addTo.Parent, toAdd);
        }
                
        private static Node<T>? Search(T value, Node<T> start)
        {
            if (start is null || start.Value is null)
                return null;

            if(start.Value.Equals(value))
                return start;

            if (start.Child is null)
                return null;

            return Search(value, start.Child);
        }

        private static Node<T>? Traverse(Node<T> start, int index)
        {
            if (start is null)
                return null;

            if (index == 0)
                return start;

            if (start.Child is null)
                return null;

            return Traverse(start.Child, --index);
        }
    }

    public class Queue<T>
        where T : IEquatable<T>
    {
        private DoubleLinkedList<T>? _values;

        public void Enqueue(T item) 
        {
            if (_values == null)
            {
                _values = new(item);
                return;
            }

            _values.AddLast(new Node<T>(item));
        }

        public T? Dequeue()
        {
            if (_values == null)
                return default;

            var first = _values.Root;

            _values.Root = _values.Root?.Child ?? null;
            
            if(_values.Root != null)
            {
                _values.Root.Parent = null;
                _values.Length--;
            }
            else
            {
                _values.Last = null;
                _values = null;
            }

            return first is not null ? first.Value : default;
        }

        public T? this[int index] => _values is not null ? _values[index] : default;

        public Node<T>? this[T value] => _values is not null ? _values[value] : default;

        public int Length => _values?.Length ?? 0;
    }
}
