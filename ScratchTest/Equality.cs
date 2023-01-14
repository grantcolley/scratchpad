using SratchLib;

namespace ScratchTest
{
    [TestClass]
    public class Equality
    {
        // Additional reading
        // https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden

        [TestMethod]
        public void Difference_Between_Boxed_Value_Types_Virtual_And_Static_Equals() 
        {
            // Equals is virtual and the == operator is static
            // When a value type is boxed
            // - the == operator will use reference type symantics 
            // - the Equals method uses the overriden Equals of the underlying type

            // Arrange
            object x = 5;
            object y = 5;

            // Assert

            // because the values are boxed the == operator uses reference type symantics 
            // and because they are stored in different memory locations they are unequal
            Assert.IsFalse(x == y);

            Assert.IsTrue(x.Equals(y));
            // Equals is virtual and deferred to the Int32 type's Equals method which
            // compares the values therefore they are equal
            //
            //      public virtual bool Equals(object? obj)
            //      {
            //          return this == obj;
            //      }
        }

        [TestMethod]
        public void Value_Types_Both_Virtual_And_Static_Equals_Use_Value_Type_Semantics()
        {
            // Arrange
            int x = 5;
            int y = 5;

            // Assert

            // value types compare the values therefore they are equal
            Assert.IsTrue(x == y);

            Assert.IsTrue(x.Equals(y));
            // Equals uses value type semantics therefore they are equal
            //
            //      private readonly int m_value;
            //      
            //      [NonVersionable]
            //      public bool Equals(int obj)
            //      {
            //          return m_value == obj;
            //      }
        }

        [TestMethod]
        public void Reference_Types_Both_Virtual_And_Static_Equals_Use_Reference_Type_Semantics()
        {
            // Arrange
            var class1 = new MyClass("Hello world!") { X = 1, Y = 2 };
            var class2 = new MyClass("Hello world!") { X = 1, Y = 2 };

            // Assert

            // because they are reference types and therfore stored
            // in different memory locations they are unequal
            Assert.IsFalse(class1 == class2);

            // Equals compares the references therefore they are unequal
            Assert.IsFalse(class1.Equals(class2));
        }
    }
}
