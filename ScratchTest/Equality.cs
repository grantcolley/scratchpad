using SratchLib;

namespace ScratchTest
{
    [TestClass]
    public class Equality
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.object.equals
        // https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
        //
        //
        // Equals() is virtual and the == operator is static
        //      Value Types     - the == operator compares values
        //                      - the Equals() method defers equality comparison to the Type
        //
        //      Reference Type  - the == operator compares references
        //                      - the Equals() method compares references

        [TestMethod]
        public void Virtual_And_Static_Equals_Different_When_Value_Types_Boxed() 
        {
            // Arrange
            object x = 5;
            object y = 5;

            // Assert

            // because the values are boxed the == operator uses reference type semantics 
            // and because they are stored in different memory locations they are unequal
            Assert.IsFalse(x == y);

            // Equals() is virtual so defers to the Int32 type's Equals() 
            // method which compares the values therefore they are equal
            Assert.IsTrue(x.Equals(y));
        }

        [TestMethod]
        public void Virtual_And_Static_Equals_Different_When_Value_Types_Are_Different_Types()
        {
            // Arrange
            int x = 5;
            double y = 5;

            // Assert

            // the == operator for value types compares the values therefore they are equal
            Assert.IsTrue(x == y);

            // the Equals() method is virtual and x is Int32 while y is a double, therefore they are unequal
            Assert.IsFalse(x.Equals(y));
        }

        [TestMethod]
        public void Virtual_And_Static_Equals_Use_Value_Type_Semantics_For_Value_Types()
        {
            // Arrange
            int x = 5;
            int y = 5;

            // Assert

            // the == operator for value types compare the values therefore they are equal
            Assert.IsTrue(x == y);

            // the Equals() method for value types compare the values therefore they are equal
            Assert.IsTrue(x.Equals(y));
        }

        [TestMethod]
        public void Reference_Types_Both_Virtual_And_Static_Equals_Use_Reference_Type_Semantics()
        {
            // Arrange
            var class1 = new MyClass("Hello world!") { X = 1, Y = 2 };
            var class2 = new MyClass("Hello world!") { X = 1, Y = 2 };

            // Assert

            // the == operator for reference types compare the references therefore they are unequal
            Assert.IsFalse(class1 == class2);

            // the Equals() method for reference types compare the references therefore they are unequal
            Assert.IsFalse(class1.Equals(class2));
        }
    }
}
