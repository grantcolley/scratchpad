namespace SratchLib
{
    public class MyClass
    {
        public MyClass(string x)
        {
            ListA = new List<string>();
            ListA.Add(x);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public List<string> ListA { get; set; }
    }
}
