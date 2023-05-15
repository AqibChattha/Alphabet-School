// <copyright file="ShapeControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Test.ControllerTests
{
    using Engine.Controllers;
    using Engine.Models;
    using Engine.Models.Enums;
    using NUnit.Framework;

    /// <summary>
    /// ShapeControllerTest class. Contains tests for ShapeController class.
    /// </summary>
    [TestFixture(Category = "ShapeControllerTest", Description = "Test cases for ShapeController class.")]
    public class ShapeControllerTest
    {
        // Test cases using list of shapes.
        private static readonly object[] RemoveMatchingShapesSourceList =
        {
            new object[] { new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.LittleLine), new ShapeModel(ShapeTypeEnum.BigCircle) } },
            new object[] { new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.LittleCircle), new ShapeModel(ShapeTypeEnum.LittleCurve), new ShapeModel(ShapeTypeEnum.BigCurve) } },
            new object[] { new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle), new ShapeModel(ShapeTypeEnum.LittleCurve), new ShapeModel(ShapeTypeEnum.LittleCircle) } },
        };

        /// <summary>
        /// Test case to check if the shapes were found, removed and returned.
        /// </summary>
        /// <param name="shapeModels">List of shapes types to be matched.</param>
        [Test]
        [TestCaseSource(nameof(RemoveMatchingShapesSourceList))]
        public void RemoveMatchingShapes_ShapesMatchAndAreReturned_RemovesAndReturnsMatchedShapes(List<IShapeModel> shapeModels)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("LittleCurve", "Red", "Dotted");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            int totalShapes = shapeController.GetShapes().Count;
            List<IShapeModel>? result = shapeController.RemoveMatchingShapes(shapeModels);

            // Assert
            Assert.That(result, Has.Count.EqualTo(shapeModels.Count));
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(totalShapes - result.Count));

            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i].GetType().ToString(), Is.EqualTo(shapeModels[i].GetType().ToString()));
            }
        }

        /// <summary>
        /// Test case to check if the shapes were not found and returns null.
        /// </summary>
        /// <param name="shapeModels">List of shapes types to be matched.</param>
        [Test]
        [TestCaseSource(nameof(RemoveMatchingShapesSourceList))]
        [TestCase(null)]
        public void RemoveMatchingShapes_ShapesNotMatched_ReturnsNull(List<IShapeModel> shapeModels)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");

            // Act
            var result = shapeController.RemoveMatchingShapes(shapeModels);

            // Assert
            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Test case to check if the shape was created successfuly.
        /// </summary>
        /// <param name="type">The type of shape.</param>
        /// <param name="color">The color of shape.</param>
        /// <param name="texture">The texture of the shape.</param>
        [Test]
        [TestCase("BigLine", "Red", "Sand")]
        [TestCase("LittleLine", "Blue", "Dotted")]
        [TestCase("BigCurve", "Green", "Solid")]
        [TestCase("LittleCurve", "Red", "Dotted")]
        [TestCase("BigCircle", "Orange", "Sand")]
        [TestCase("LittleCircle", "Blue", "Solid")]
        public void CreateShape_ShapeCreated_ReturnsTrue(string type, string color, string texture)
        {
            // Arrange
            var shapeController = new ShapeController();

            // Act
            int totalShapes = shapeController.GetShapes().Count;
            bool result = shapeController.CreateShape(type, color, texture);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(totalShapes + 1));
        }

        /// <summary>
        /// The test case to check if the shape was not created.
        /// </summary>
        /// <param name="type">The type of shape.</param>
        /// <param name="color">The color of shape.</param>
        /// <param name="texture">The texture of the shape.</param>
        [Test]
        [TestCase("bigLine", "red", "sand")]
        [TestCase("Littleline", "Blue", "fotted")]
        [TestCase("abc", "abc", "abc")]
        [TestCase(null, null, null)]
        public void CreateShape_ShapeNotCreated_ReturnsFalse(string type, string color, string texture)
        {
            // Arrange
            var shapeController = new ShapeController();

            // Act
            int totalShapes = shapeController.GetShapes().Count;
            bool result = shapeController.CreateShape(type, color, texture);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(totalShapes));
        }

        /// <summary>
        /// Test case to check if the shape was removed successfuly.
        /// </summary>
        /// <param name="id">The (index + 1) number of an item in the list.</param>
        /// <param name="type">The type of shape.</param>
        /// <param name="color">The color of shape.</param>
        /// <param name="texture">The texture of the shape.</param>
        [Test]
        [TestCase(1, "LittleCircle", "Orange", "Dotted")]
        [TestCase(2, "BigLine", "Red", "Solid")]
        [TestCase(3, "BigLine", "Orange", "Sand")]
        [TestCase(4, "BigLine", "Blue", "Dotted")]
        [TestCase(5, "LittleCurve", "Blue", "Sand")]
        [TestCase(6, "BigCurve", "Green", "Solid")]
        public void UpdateShape_ShapeUpdated_ReturnsTrue(int id, string type, string color, string texture)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("LittleCurve", "Red", "Dotted");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            shapeController.UpdateShape(id, type, color, texture);

            // Assert
            Assert.That(shapeController.GetShapes()[id - 1].GetType().ToString(), Is.EqualTo(type));
            Assert.That(shapeController.GetShapes()[id - 1].GetColor().ToString(), Is.EqualTo(color));
            Assert.That(shapeController.GetShapes()[id - 1].GetTexture().ToString(), Is.EqualTo(texture));
        }

        /// <summary>
        /// Test case to check if the shape was not updated.
        /// </summary>
        /// <param name="id">The (index + 1) number of an item in the list.</param>
        /// <param name="type">The type of shape.</param>
        /// <param name="color">The color of shape.</param>
        /// <param name="texture">The texture of the shape.</param>
        [Test]
        [TestCase(-1, "LittleCircle", "Orange", "Dotted")]
        [TestCase(0, "BigLine", "Red", "Solid")]
        [TestCase(3, "bigline", "orange", "sand")]
        [TestCase(4, "abc", "abc", "abc")]
        [TestCase(7, "BigCurve", "Green", "Solid")]
        public void UpdateShape_ShapeNotUpdated_ReturnsTrue(int id, string type, string color, string texture)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("LittleCurve", "Red", "Dotted");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            bool result = shapeController.UpdateShape(id, type, color, texture);

            // Assert
            if (id > 0 && id <= shapeController.GetShapes().Count)
            {
                Assert.That(shapeController.GetShapes()[id - 1].GetType().ToString(), Is.Not.EqualTo(type));
                Assert.That(shapeController.GetShapes()[id - 1].GetColor().ToString(), Is.Not.EqualTo(color));
                Assert.That(shapeController.GetShapes()[id - 1].GetTexture().ToString(), Is.Not.EqualTo(texture));
            }

            Assert.That(result, Is.False);
        }

        /// <summary>
        /// Test case to check if the shape was removed successfuly.
        /// </summary>
        /// <param name="id">The (index + 1) number of an item in the list.</param>
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void DeleteShape_ShapeDeleted_ReturnsTrue(int id)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("LittleCurve", "Red", "Dotted");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            int totalShapes = shapeController.GetShapes().Count;
            bool result = shapeController.DeleteShape(id);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(totalShapes - 1));
        }

        /// <summary>
        /// Test case to check if the shape was not removed.
        /// </summary>
        /// <param name="id">The (index + 1) number of an item in the list.</param>
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(7)]
        public void DeleteShape_ShapeNotDeleted_ReturnsFalse(int id)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("LittleCurve", "Red", "Dotted");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            int totalShapes = shapeController.GetShapes().Count;
            bool result = shapeController.DeleteShape(id);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(totalShapes));
        }

        /// <summary>
        /// Test case to check if all shapes were removed successfuly.
        /// </summary>
        [Test]
        public void DeleteAllShapes_DeletesAllShapes_DeletesAllShapes()
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("LittleCurve", "Red", "Dotted");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            int shapesCount = shapeController.GetShapes().Count;
            shapeController.DeleteAllShapes();

            // Assert
            Assert.That(shapesCount, Is.Not.EqualTo(0));
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Test case to check if the shapes of given color were found and returned.
        /// </summary>
        /// <param name="color">The color of shapes.</param>
        /// <param name="expectedCount">The shapes expected to be found.</param>
        [Test]
        [TestCase("Red", 2)]
        [TestCase("Blue", 2)]
        [TestCase("Orange", 1)]
        [TestCase("Green", 0)]
        [TestCase("abc", 0)]
        [TestCase(null, 0)]
        public void GetShapeByColor_ShapesMatchAndAreReturned_ReturnsACopyMatchedShapes(string color, int expectedCount)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Dotted");
            shapeController.CreateShape("LittleCurve", "Red", "Dotted");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            List<IShapeModel>? result = shapeController.GetShapeByColor(color);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.All(x => x.GetColor().ToString() == color), Is.True);
        }

        /// <summary>
        /// Test case to check if the shapes of given texture were found and returned.
        /// </summary>
        /// <param name="texture">The texture of shapes.</param>
        /// <param name="expectedCount">The shapes expected to be found.</param>
        [Test]
        [TestCase("Dotted", 0)]
        [TestCase("Sand", 2)]
        [TestCase("Solid", 2)]
        [TestCase("abc", 0)]
        [TestCase(null, 0)]
        public void GetShapesByTexture_ShapesMatchAndAreReturned_ReturnsACopyMatchedShapes(string texture, int expectedCount)
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.CreateShape("BigCircle", "Orange", "Sand");
            shapeController.CreateShape("LittleCircle", "Blue", "Solid");

            // Act
            List<IShapeModel>? result = shapeController.GetShapesByTexture(texture);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.All(x => x.GetTexture().ToString() == texture), Is.True);
        }

        /// <summary>
        /// Test case to check if the recent action on shapes was undone.
        /// </summary>
        [Test]
        public void UndoCommand_UndoActionsPerformedByUsersOnShapes_UndosTheLastAction()
        {
            // Arrange
            var shapeController = new ShapeController();
            shapeController.CreateShape("BigLine", "Red", "Sand");
            shapeController.CreateShape("LittleLine", "Blue", "Solid");

            // Act and Assert - CreateShape
            shapeController.CreateShape("BigCurve", "Green", "Solid");
            shapeController.UndoCommand();
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(2));

            // Act and Assert - UpdateShape
            shapeController.UpdateShape(1, "LittleLine", "Blue", "Dotted");
            shapeController.UndoCommand();
            Assert.That(shapeController.GetShapes()[0].GetTexture().ToString(), Is.EqualTo("Sand"));

            // Act and Assert - DeleteShape
            shapeController.DeleteShape(1);
            shapeController.UndoCommand();
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(2));

            // Act and Assert - DeleteAllShapes
            shapeController.DeleteAllShapes();
            shapeController.UndoCommand();
            Assert.That(shapeController.GetShapes().Count, Is.EqualTo(2));
        }
    }
}
