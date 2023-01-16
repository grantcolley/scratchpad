using SratchLib;

namespace ScratchTest
{
    [TestClass]
    public class HashCode
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.object.gethashcode
        // https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
        //
        // "GetHashCode() is a hash function is used to quickly generate a number (hash code) that
        // corresponds to the value of an object."
        //
        // "A hash code is a numeric value that is used to insert and identify an object in a hash-based collection
        // such as the Dictionary<TKey,TValue> class or HashSet<T> class.
        // The GetHashCode() method provides a hash code for algorithms that need quick checks of object equality."
        // 
        // Note:
        //  - You should not assume that equal hash codes imply object equality.
        //  - You should never persist or use a hash code outside the application domain in which it was created.
        //  - Do not use the hash code as the key to retrieve an object from a keyed collection.
        //  - GetHashCode() is NOT unique
        //  - GetHashCode() does NOT guarantee equality
        //  - GetHashCode() returns the same value for an object in the application domain, but NOT between domains.
        //  - Two objects that are equal must both return the same HashCode
        //  - Two objects that are unequal CAN return the same HashCode
        //
        // Generally
        //      Value Types     - compute the hash code based on the values of the type's fields
        //                      - different value types with same value typially return different HashCodes
        //
        //      Reference Type  - computes a hash code based on an object's reference
        //                      - when overriding the Equals() method you must also override GetHashCode() using IEqualityComparer
        //                          - be careful using mutable fields
        //                          - ensure that the hash code of a mutable object does not change
        //
        // Hash functions are usually specific to each type and, for uniqueness, must use at least one of the
        // instance fields as input. Hash codes should not be computed by using the values of static fields.
        // 
        // From the source code:
        //
        //      public virtual int GetHashCode()
        //      {
        //          // GetHashCode is intended to serve as a hash function for this object.
        //          // Based on the contents of the object, the hash function will return a suitable
        //          // value with a relatively random distribution over the various inputs.
        //          //
        //          // The default implementation returns the sync block index for this instance.
        //          // Calling it on the same object multiple times will return the same value, so
        //          // it will technically meet the needs of a hash function, but it's less than ideal.
        //          // Objects (& especially value classes) should override this method.
        //
        //          return RuntimeHelpers.GetHashCode(this);
        //      }

        [TestMethod]
        public void GetHashCode_Returns_Same_Value_Between_Calls()
        {
            //Arrange
            var class1 = new MyClass("Hello world!") { X = 1, Y = 2 };

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

            // Act
            var class1_HashCode = class1.GetHashCode();
            var class2_HashCode = class2.GetHashCode();

            //Assert

            // Two obects with the same values return different HashCodes
            Assert.AreNotEqual(class1_HashCode, class2_HashCode);
        }

        [TestMethod]
        public void GetHashCode_Two_ValueTypes_Same_Values_Same_Type_Return_Same_HashCode()
        {
            //Arrange
            var struct1 = new MyStruct("Hello world!") { X = 1, Y = 2 };
            var struct2 = new MyStruct("Hello world!") { X = 1, Y = 2 };

            //Act
            var struct1_HashCode = struct1.GetHashCode();
            var struct2_HashCode = struct2.GetHashCode();

            //Assert

            // Two value types with the same values and same type return the same HashCode
            Assert.AreEqual(struct1_HashCode, struct2_HashCode);
        }

        [TestMethod]
        public void GetHashCode_Two_ValueTypes_Same_Values_Different_Type_Return_Different_HashCodes()
        {
            //Arrange
            int value1 = 5;
            double value2 = 5;

            //Act
            var value1_HashCode = value1.GetHashCode();
            var value2_HashCode = value2.GetHashCode();

            //Assert

            // Two value types with the same values but different types return different HashCodes
            Assert.AreNotEqual(value1_HashCode, value2_HashCode);
        }
    }
}
