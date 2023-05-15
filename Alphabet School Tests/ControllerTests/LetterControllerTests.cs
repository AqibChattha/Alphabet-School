// <copyright file="LetterControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Test.ControllerTests
{
    using Engine.Controllers;
    using Engine.Models;
    using Engine.Models.Enums;
    using NUnit.Framework;

    /// <summary>
    /// LetterControllerTests class. Contains tests for LetterController class.
    /// </summary>
    [TestFixture(Category = "LetterControllerTests", Description = "Test cases for LetterController class.")]
    public class LetterControllerTests
    {
        // RemoveMatchingShapes test cases input data.
        private static readonly object[] GetAlphabetShapesOnNameSourceList =
        {
            new object[] { 'A', new LetterModel('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.LittleLine) }) },
            new object[] { 'O', new LetterModel('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle) }) },
            new object[] { 'Z', new LetterModel('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.LittleLine) }) },
        };

        // RemoveMatchingShapes test cases input data.
        private static readonly object[] AddLetterSourceList =
        {
            new object[] { 'A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Orange, TexturesEnum.Solid) } },
            new object[] { 'O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) } },
            new object[] { 'Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) } },
        };

        /// <summary>
        /// Test to check if GetAlphabetShapesOnName method returns correct result.
        /// </summary>
        /// <param name="letterName">Letter name.</param>
        /// <param name="expectedLetter">Expected result.</param>
        [Test]
        [TestCaseSource(nameof(GetAlphabetShapesOnNameSourceList))]
        public void GetAlphabetShapesOnName_AlphabetFound_ReturnsAlphabetShapes(char letterName, ILetterModel expectedLetter)
        {
            // Arrange
            var letterController = new LetterController();

            // Act
            var result = letterController.GetAlphabetShapesOnName(letterName);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expectedLetter.GetShapes().Count));
            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i].GetType(), Is.EqualTo(expectedLetter.GetShapes()[i].GetType()));
            }
        }

        /// <summary>
        /// Test case to check if the letter was created successfuly.
        /// </summary>
        /// <param name="letterName">Letter name.</param>
        /// <param name="shapes">Shapes list.</param>
        [Test]
        [TestCaseSource(nameof(AddLetterSourceList))]
        public void AddLetter_ShapeCreated_ReturnsTrue(char letterName, List<IShapeModel> shapes)
        {
            // Arrange
            var letterController = new LetterController();

            // Act
            letterController.AddLetter(letterName, shapes);

            // Assert
            Assert.That(letterController.GetLetters(), Has.Count.EqualTo(1));
        }

        /// <summary>
        /// Test case to check if the letter was removed successfuly.
        /// </summary>
        /// <param name="id">The (index + 1) number of an item in the list.</param>
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DeleteLetter_LetterDeleted_ReturnsTrue(int id)
        {
            // Arrange
            var letterController = new LetterController();
            letterController.AddLetter('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Orange, TexturesEnum.Solid) });
            letterController.AddLetter('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) });
            letterController.AddLetter('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) });

            // Act
            var result = letterController.DeleteLetter(id);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(letterController.GetLetters(), Has.Count.EqualTo(2));
        }

        /// <summary>
        /// Test case to check if the letter was not removed.
        /// </summary>
        /// <param name="id">The (index + 1) number of an item in the list.</param>
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(7)]
        public void DeleteLetter_LetterNotDeleted_ReturnsFalse(int id)
        {
            // Arrange
            var letterController = new LetterController();
            letterController.AddLetter('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Orange, TexturesEnum.Solid) });
            letterController.AddLetter('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) });
            letterController.AddLetter('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) });

            // Act
            var result = letterController.DeleteLetter(id);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(letterController.GetLetters(), Has.Count.EqualTo(3));
        }

        /// <summary>
        /// Test case to check if all letters were removed successfuly.
        /// </summary>
        [Test]
        public void DeleteAllLetters_DeletesAllLetters_DeletesAllLetters()
        {
            // Arrange
            var letterController = new LetterController();
            letterController.AddLetter('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Orange, TexturesEnum.Solid) });
            letterController.AddLetter('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) });
            letterController.AddLetter('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) });

            // Act
            letterController.DeleteAllLetters();

            // Assert
            Assert.That(letterController.GetLetters(), Has.Count.EqualTo(0));
        }

        /// <summary>
        /// Test case to check if the letters containing any shape of given color were found and returned.
        /// </summary>
        /// <param name="color">The color of shapes.</param>
        /// <param name="expectedCount">The number of letters returned.</param>
        [Test]
        [TestCase("Red", 2)]
        [TestCase("Blue", 1)]
        [TestCase("Orange", 2)]
        [TestCase("Green", 2)]
        [TestCase("abc", 0)]
        [TestCase(null, 0)]
        public void GetLettersWithShapesColor_LetterShapesColorsAreMatchAndAreReturned_ReturnsACopyMatchedShapeLetters(string color, int expectedCount)
        {
            // Arrange
            var letterController = new LetterController();
            letterController.AddLetter('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Solid) });
            letterController.AddLetter('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) });
            letterController.AddLetter('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) });

            // Act
            var result = letterController.GetLettersWithShapesColor(color);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        }

        /// <summary>
        /// Test case to check if the letters with shapes count greater than given number were found and returned.
        /// </summary>
        /// <param name="shapeCount">The number to compare shapes count.</param>
        /// <param name="expectedCount">The number of letters returned.</param>
        [Test]
        [TestCase(-1, 3)]
        [TestCase(0, 3)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        [TestCase(3, 0)]
        [TestCase(4, 0)]
        public void GetLettersWithShapeNumMoreThen_CountsTheLetterShapesAgainstTheGivenInput_ReturnsACopyLettersWithMoreShapes(int shapeCount, int expectedCount)
        {
            // Arrange
            var letterController = new LetterController();
            letterController.AddLetter('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Solid) });
            letterController.AddLetter('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) });
            letterController.AddLetter('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) });

            // Act
            var result = letterController.GetLettersWithShapeNumMoreThen(shapeCount);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        }

        /// <summary>
        /// Test case to check if the recent action on letters was undone.
        /// </summary>
        [Test]
        public void UndoCommand_UndoActionsPerformedByUsersOnLetters_UndosTheLastAction()
        {
            // Arrange
            var letterController = new LetterController();
            letterController.AddLetter('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Solid) });
            letterController.AddLetter('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Sand) });

            // Act and Assert - AddLetter
            letterController.AddLetter('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Green, TexturesEnum.Sand) });
            letterController.UndoCommand();
            Assert.That(letterController.GetLetters().Count, Is.EqualTo(2));

            // Act and Assert - DeleteLetter
            letterController.DeleteLetter(1);
            letterController.UndoCommand();
            Assert.That(letterController.GetLetters().Count, Is.EqualTo(2));

            // Act and Assert - DeleteAllLetters
            letterController.DeleteAllLetters();
            letterController.UndoCommand();
            Assert.That(letterController.GetLetters().Count, Is.EqualTo(2));
        }
    }
}
