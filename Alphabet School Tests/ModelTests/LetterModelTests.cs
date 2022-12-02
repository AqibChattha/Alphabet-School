// <copyright file="LetterModelTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School_Tests.ModelTests
{
    using Alphabet_School.Models;
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// LetterModelTests class. Contains tests for LetterModel class.
    /// </summary>
    [TestFixture(Category = "LetterModelTests", Description = "Test cases for LetterModel class.")]
    public class LetterModelTests
    {
        // Letter constructor data.
        private static readonly object[] LetterModelSourceList =
        {
            new object[] { 'A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Orange, TexturesEnum.Solid) } },
            new object[] { 'O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) } },
            new object[] { 'Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) } },
        };

        /// <summary>
        /// Test to check if letter model class getters return correct values.
        /// </summary>
        /// <param name="letter">Letter name.</param>
        /// <param name="shapes">Shapes used to make letter.</param>
        [Test]
        [TestCaseSource(nameof(LetterModelSourceList))]
        public void LetterModel_TestingGetters_TrueIfTheGetterReturnSameInput(char letter, List<IShapeModel> shapes)
        {
            // Arrange
            ILetterModel letterModel = new LetterModel(letter, shapes);

            // Assert
            Assert.That(letterModel.Name, Is.EqualTo(letter));
            Assert.That(shapes, Is.EqualTo(letterModel.Shapes));
        }

        /// <summary>
        /// Test to check if shape model class setters set values correctly.
        /// </summary>
        /// <param name="letter">Letter name.</param>
        /// <param name="shapes">Shapes used to make letter.</param>
        [Test]
        [TestCaseSource(nameof(LetterModelSourceList))]
        public void LetterModel_TestingSetters_TrueIfTheGetterReturnSameInput(char letter, List<IShapeModel> shapes)
        {
            // Arrange
            ILetterModel letterModel = new LetterModel('\0', new List<IShapeModel>());

            // Act
            letterModel.Name = letter;
            letterModel.Shapes = shapes;

            // Assert
            Assert.That(letterModel.Name, Is.EqualTo(letter));
            Assert.That(shapes, Is.EqualTo(letterModel.Shapes));
        }

        /// <summary>
        /// Test to check if shape model class getters return correct values.
        /// </summary>
        /// <param name="letter">Letter name.</param>
        /// <param name="shapes">Shapes used to make letter.</param>
        [Test]
        [TestCaseSource(nameof(LetterModelSourceList))]
        public void ToString_ReturnCorrectFormatString_ReturnsString(char letter, List<IShapeModel> shapes)
        {
            // Arrange
            ILetterModel letterModel = new LetterModel(letter, shapes);

            // Act
            string result = letter + " [";
            for (int i = 0; i < shapes.Count; i++)
            {
                result += shapes[i].ToString();
                if (i == shapes.Count - 1)
                {
                    result += "]";
                }
                else
                {
                    result += ", ";
                }
            }

            // Assert
            Assert.That(letterModel.ToString(), Is.EqualTo(result));
        }
    }
}
