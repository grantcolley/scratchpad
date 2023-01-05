namespace SratchLib
{
    public static class ParameterModifiersExamples
    {
        public static void Parameter_By_Value(MyStruct myStruct)
        {
            // can modify the parameter but modifications 
            myStruct = new MyStruct();
        }

        public static void Parameter_By_Reference(ref MyStruct myStruct)
        {
            // can modify and the returned 
            myStruct = new MyStruct("Test 123");
        }

        public static void Parameter_Using_In(in MyStruct myStruct)
        {
            // these won't compile because passing the parameter using 'in' makes it readonly
            // myStruct.X = 5;
            // myStruct = new MyStruct();
        }

        public static void Parameter_Using_Out(out MyStruct myStruct)
        {
            // won't compile because passing the parameter using 'out'
            // requires the parameter to be assigned
            myStruct = new MyStruct();
        }
    }
}
