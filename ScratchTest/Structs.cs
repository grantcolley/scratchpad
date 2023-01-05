using SratchLib;

namespace ScratchTest
{
    [TestClass]
    public class Structs
    {
        // Additional reading
        // https://stackoverflow.com/questions/203695/does-using-new-on-a-struct-allocate-it-on-the-heap-or-stack
        // https://stackoverflow.com/questions/23628234/struct-with-reference-members-heap-or-stack

        [TestMethod]
        public void Structs_Are_Mutable()
        {
            // Structs are mutable unless you make them immutable by making the struct and its properties readonly.
            // But a struct with a reference type property is dangerous because changing one affects all copies.

            // Arrange - create a struct
            MyStruct struct1 = new MyStruct("Hello World!") { X = 1, Y = 2 }; 

            // Act - make a copy of the struct
            MyStruct struct2 = struct1;

            // Assert - struct1 and struct2 are equal - value type values and references to reference type objects have been copied
            Assert.AreEqual(struct1, struct2);

            // Act - clear the list for struct2
            struct2.ListA.Clear();

            // Assert
            Assert.AreEqual(struct1, struct2); // struct1 and struct2 are still equal
            Assert.IsFalse(struct1.ListA.Any()); // the list is empty for struct1 and struct2
            Assert.IsFalse(struct2.ListA.Any()); // because they both point to the same list 

            // Act
            // change the value of one property on struct2
            struct2.X = 5;

            // Assert
            Assert.AreNotEqual(struct1, struct2); // struct1 and struct2 are no longer equal because not all values are equal
            Assert.AreEqual(1, struct1.X); // struct1.X is still 1
            Assert.AreEqual(5, struct2.X); // struct2.X is now 5
        }
    }
}