namespace SratchLib
{
    public struct MyStruct
    {
        public MyStruct(string x)
        {
            ListA = new List<string>();
            ListA.Add(x);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public List<string> ListA { get; set; }
    }
}