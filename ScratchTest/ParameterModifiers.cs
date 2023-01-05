using SratchLib;

namespace ScratchTest
{
    [TestClass]
    public class ParameterModifiers
    {
        [TestMethod]
        public void Pass_Parameter_By_Value()
        {
            // Passes by value, which for value types is a copy of the value
            // and for reference types it is a copy of the reference.
            // Passing by value allows you to modify the parameter inside the 
            // called method but, because it is only a copy, the modified version
            // of the parameter is not applied to the object in the calling method

            // Arrange
            MyStruct myStruct = new MyStruct("Hello World!") { X = 1, Y = 2 };

            // Act
            ParameterModifiersExamples.Parameter_By_Value(myStruct);

            // Assert
            // the struct hasn't changed because the default is passing by value
            // so any changes are only made to a copy of the object.
            Assert.AreEqual(1, myStruct.X);
            Assert.AreEqual(2, myStruct.Y);
            Assert.AreEqual(1, myStruct.ListA.Count);
            Assert.AreEqual("Hello World!", myStruct.ListA[0]);
        }

        [TestMethod]
        public void Pass_Parameter_By_Reference()
        {
            // Passing by ref passes a reference to the parameter i.e. a pointer to the object
            // in the calling code which being passed as the parameter, regardless of whether
            // it is a value type or reference type. Therefore any modifications are applied
            // directly to the object in the calling code.

            // Arrange
            MyStruct myStruct = new MyStruct("Hello World!") { X = 1, Y = 2 };

            // Act
            ParameterModifiersExamples.Parameter_By_Reference(ref myStruct);

            // Assert
            // the struct has changed because the 'ref' modifier allows the reference to the original be modified
            Assert.AreEqual(0, myStruct.X);
            Assert.AreEqual(0, myStruct.Y);
            Assert.AreEqual("Test 123", myStruct.ListA[0]);
        }

        [TestMethod]
        public void Pass_Parameter_Using_In()
        {
            // Passing a parameter using the 'in' modifier passes it by reference,
            // however, it the makes the parameter readonly so it cannot be changed.
            // Any attempt to do so will result in a compilation error.

            // NOTE:
            // Using the 'in' modefier, is only really useful on very large value types
            // like structs, where performance improves by not passing a copy of the object.
            // The 'in' modifier doesn't offer any real gain to reference types over passing by value.

            // Arrange
            MyStruct myStruct = new MyStruct("Hello World!") { X = 1, Y = 2 };

            // Act
            ParameterModifiersExamples.Parameter_Using_In(in myStruct);

            // Assert
            // the struct hasn't changed because the 'in' modifier makes it readonly inside the called method
            Assert.AreEqual(1, myStruct.X);
            Assert.AreEqual(2, myStruct.Y);
            Assert.AreEqual(1, myStruct.ListA.Count);
            Assert.AreEqual("Hello World!", myStruct.ListA[0]);
        }

        public void Pass_Parameter_Using_Out()
        {
            // Passing a parameter using the 'out' modifier passes by
            // reference and with the expectation it will be initialised
            // in the method. Failing to do so results in a compile time error.

            // Arrange
            MyStruct myStruct = new MyStruct("Hello World!") { X = 1, Y = 2 };

            // Act
            ParameterModifiersExamples.Parameter_Using_Out(out myStruct);

            // Assert
            // the struct has changed because the 'ref' modifier allows the reference to the original be modified
            Assert.AreEqual(0, myStruct.X);
            Assert.AreEqual(0, myStruct.Y);
            Assert.AreEqual(0, myStruct.ListA.Count);
        }
    }
}
