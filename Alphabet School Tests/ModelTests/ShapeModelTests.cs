// <copyright file="ShapeModelTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Test.ModelTests
{
    using Engine.Models;
    using Engine.Models.Enums;
    using NUnit.Framework;

    /// <summary>
    /// ShapeModelTests class. Contains tests for ShapeModel class.
    /// </summary>
    [TestFixture(Category = "ShapeModelTests", Description = "Test cases for ShapeModel class.")]
    public class ShapeModelTests
    {
        /// <summary>
        /// Test to check if shape model class getters return correct values.
        /// </summary>
        /// <param name="type">Shape type.</param>
        /// <param name="color">Shape color.</param>
        /// <param name="texture">Shape texture.</param>
        [Test]
        [TestCase(ShapeTypeEnum.BigLine, ColorsEnum.Red, TexturesEnum.Sand)]
        [TestCase(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Dotted)]
        [TestCase(ShapeTypeEnum.BigCurve, ColorsEnum.Green, TexturesEnum.Solid)]
        [TestCase(ShapeTypeEnum.LittleCurve, ColorsEnum.Red, TexturesEnum.Dotted)]
        [TestCase(ShapeTypeEnum.BigCircle, ColorsEnum.Orange, TexturesEnum.Sand)]
        [TestCase(ShapeTypeEnum.LittleCircle, ColorsEnum.Blue, TexturesEnum.Solid)]
        public void ShapeModel_TestingGetters_TrueIfTheGetterReturnSameInput(ShapeTypeEnum type, ColorsEnum color, TexturesEnum texture)
        {
            // Arrange
            IShapeModel shapeModel = new ShapeModel(type, color, texture);

            // Assert
            Assert.That(shapeModel.GetType(), Is.EqualTo(type));
            Assert.That(shapeModel.GetColor(), Is.EqualTo(color));
            Assert.That(shapeModel.GetTexture(), Is.EqualTo(texture));
        }

        /// <summary>
        /// Test to check if shape model class setters set values correctly.
        /// </summary>
        /// <param name="type">Shape type.</param>
        /// <param name="color">Shape color.</param>
        /// <param name="texture">Shape texture.</param>
        [Test]
        [TestCase(ShapeTypeEnum.BigLine, ColorsEnum.Red, TexturesEnum.Sand)]
        [TestCase(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Dotted)]
        [TestCase(ShapeTypeEnum.BigCurve, ColorsEnum.Green, TexturesEnum.Solid)]
        [TestCase(ShapeTypeEnum.LittleCurve, ColorsEnum.Red, TexturesEnum.Dotted)]
        [TestCase(ShapeTypeEnum.BigCircle, ColorsEnum.Orange, TexturesEnum.Sand)]
        [TestCase(ShapeTypeEnum.LittleCircle, ColorsEnum.Blue, TexturesEnum.Solid)]
        public void ShapeModel_TestingSetters_TrueIfTheGetterReturnSameInput(ShapeTypeEnum type, ColorsEnum color, TexturesEnum texture)
        {
            // Arrange
            IShapeModel shapeModel = new ShapeModel(0, 0, 0);

            // Act
            shapeModel.SetType(type);
            shapeModel.SetColor(color);
            shapeModel.SetTexture(texture);

            // Assert
            Assert.That(shapeModel.GetType(), Is.EqualTo(type));
            Assert.That(shapeModel.GetColor(), Is.EqualTo(color));
            Assert.That(shapeModel.GetTexture(), Is.EqualTo(texture));
        }

        /// <summary>
        /// Test to check if shape model class getters return correct values.
        /// </summary>
        /// <param name="type">Shape type.</param>
        /// <param name="color">Shape color.</param>
        /// <param name="texture">Shape texture.</param>
        [Test]
        [TestCase(ShapeTypeEnum.BigLine, ColorsEnum.Red, TexturesEnum.Sand)]
        [TestCase(ShapeTypeEnum.LittleLine, ColorsEnum.Blue, TexturesEnum.Dotted)]
        [TestCase(ShapeTypeEnum.BigCurve, ColorsEnum.Green, TexturesEnum.Solid)]
        [TestCase(ShapeTypeEnum.LittleCurve, ColorsEnum.Red, TexturesEnum.Dotted)]
        [TestCase(ShapeTypeEnum.BigCircle, ColorsEnum.Orange, TexturesEnum.Sand)]
        [TestCase(ShapeTypeEnum.LittleCircle, ColorsEnum.Blue, TexturesEnum.Solid)]
        public void ToString_CorrectFormatString_ReturnsString(ShapeTypeEnum type, ColorsEnum color, TexturesEnum texture)
        {
            // Arrange
            IShapeModel shapeModel = new ShapeModel(type, color, texture);

            // Assert
            Assert.That(shapeModel.ToString(), Is.EqualTo($"{type} (Color: {color}; Texture: {texture})"));
        }
    }
}
