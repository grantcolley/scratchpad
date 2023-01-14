using SratchLib;
using System.Runtime.CompilerServices;

namespace ScratchTest
{
    [TestClass]
    public class Equality
    {
        // Additional reading
        // https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
        //

        [TestMethod]
        public void GetHashCode_Call_Repeatedly_Returns_Same_Value()
        {
            // GetHashCode returns a HashCode based on the contents of the object.
            // Calling it on the same object multiple times will return the same value.

            ///        public virtual int GetHashCode()
            ///        {
            ///            // GetHashCode is intended to serve as a hash function for this object.
            ///            // Based on the contents of the object, the hash function will return a suitable
            ///            // value with a relatively random distribution over the various inputs.
            ///            //
            ///            // The default implementation returns the sync block index for this instance.
            ///            // Calling it on the same object multiple times will return the same value, so
            ///            // it will technically meet the needs of a hash function, but it's less than ideal.
            ///            // Objects (& especially value classes) should override this method.
            ///
            ///            return RuntimeHelpers.GetHashCode(this);
            ///        }

            //Arrange
            var class1 = new MyClass("Hello world!") { X = 1, Y = 2 };
            var class2 = new MyClass("Hello world!") { X = 1, Y = 2 };

            //Act
            var class1_HashCode = class1.GetHashCode();

            //Assert
            Assert.AreEqual(class1_HashCode, class1.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_Two_ReferenceTypes_Same_Values_Return_Different_HashCode()
        {
            //Arrange
            var class1 = new MyClass("Hello world!") { X = 1, Y = 2 };
            var class2 = new MyClass("Hello world!") { X = 1, Y = 2 };

            //Assert
            var class1_HashCode = class1.GetHashCode();
            var class2_HashCode = class2.GetHashCode();

            // Two value types with the same values return different HashCode
            Assert.AreNotEqual(class1.GetHashCode(), class2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_Two_ValueTypes_Same_Values_Return_Same_HashCode()
        {
            //Arrange
            var struct1 = new MyStruct("Hello world!") { X = 1, Y = 2 };
            var struct2 = new MyStruct("Hello world!") { X = 1, Y = 2 };

            //Act
            var struct1_HashCode = struct1.GetHashCode();
            var struct2_HashCode = struct2.GetHashCode();

            //Assert

            // Two value types with the same values return the same HashCode
            Assert.AreEqual(struct1.GetHashCode(), struct2.GetHashCode());
        }

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
