
namespace GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T item)
        {
            this.Item = item;
        }

        public T Item { get; set; }

        public override string ToString()
        {
            return $"{this.Item.GetType()}: {this.Item}";//this.Item.GetType() or typeof(T)
        }
    }
}
