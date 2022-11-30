// <copyright file="ShapeHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Handlers
{
    using Alphabet_School.Models;
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// This class handles the shape of the letter. It can be used to create, update and delete shapes.
    /// </summary>
    public class ShapeHandler
    {
        /// <summary>
        /// List of shapes. This list is used to store all the shapes that are not assigned.
        /// </summary>
        private List<Shape> shapes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeHandler"/> class.
        /// </summary>
        public ShapeHandler()
        {
            // Initialize the list of shapes.
            this.shapes = new List<Shape>();
        }

        /// <summary>
        /// This method is used to create a shape.
        /// </summary>
        /// <param name="strColor">Color name of string data type.</param>
        /// <param name="strTexture">Texture name of string data type.</param>
        /// <param name="strType">Shape type name of string data type.</param>
        /// <returns>True, if the shape is created. Otherwise false.</returns>
        public bool CreateShape(string strColor, string strTexture, string strType)
        {
            ColorsEnum colorsEnum;
            TexturesEnum texturesEnum;
            ShapeTypeEnum shapeTypeEnum;

            if (Enum.TryParse(strColor, out colorsEnum) && Enum.TryParse(strTexture, out texturesEnum) && Enum.TryParse(strType, out shapeTypeEnum))
            {
                // Create a new shape.
                Shape shape = new Shape(colorsEnum, texturesEnum, shapeTypeEnum);

                // Add the shape to the list of shapes.
                this.shapes.Add(shape);

                // Return the created shape.
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method is used to update a shape.
        /// </summary>
        /// <param name="shape">The shape that needs to be updated.</param>
        /// <param name="color">The new color of the shape.</param>
        /// <param name="texture">The new texture of the shape.</param>
        /// <param name="type">The new type of the shape.</param>
        /// <returns>The updated shape.</returns>
        public Shape UpdateShape(Shape shape, ColorsEnum color, TexturesEnum texture, ShapeTypeEnum type)
        {
            // Update the color of the shape.
            shape.Color = color;

            // Update the texture of the shape.
            shape.Texture = texture;

            // Update the type of the shape.
            shape.Type = type;

            // Return the updated shape.
            return shape;
        }

        /// <summary>
        /// This method is used to delete a shape.
        /// </summary>
        /// <param name="shape">The shape that needs to be deleted.</param>
        public void DeleteShape(Shape shape)
        {
            // Remove the shape from the list of shapes.
            this.shapes.Remove(shape);
        }

        /// <summary>
        /// This method is used to get a shape by its id.
        /// </summary>
        /// <param name="id">The id of the shape.</param>
        public void DeleteShape(int id)
        {
            // Check if the id is valid.
            if (id < this.shapes.Count && id >= 0)
            {
                // Remove the shape from the list of shapes.
                this.shapes.RemoveAt(id);
            }
        }

        /// <summary>
        /// This method is used to get the list of shapes.
        /// </summary>
        /// <returns>The list of shapes.</returns>
        public List<Shape> GetShapes()
        {
            // Return the list of shapes.
            return this.shapes;
        }

        /// <summary>
        /// This method is used to get shape by their color.
        /// </summary>
        /// <param name="color">The color of the shapes.</param>
        /// <returns>The shapes with the given color.</returns>
        public List<Shape> GetShapeByColor(ColorsEnum color)
        {
            // Create a list of shapes.
            List<Shape> shapes = new List<Shape>();

            // Loop through all the shapes.
            foreach (Shape shape in shapes)
            {
                // Check if the color of the shape is equal to the given color.
                if (shape.Color == color)
                {
                    // Add the shape to the list.
                    shapes.Add(shape);
                }
            }

            // Return the list of shapes.
            return shapes;
        }

        /// <summary>
        /// This method is used to get shapes by their type.
        /// </summary>
        /// <param name="type">The type of the shapes.</param>
        /// <returns>The shapes with the given type.</returns>
        public List<Shape> GetShapesByType(ShapeTypeEnum type)
        {
            // Create a list of shapes.
            List<Shape> shapes = new List<Shape>();

            // Loop through all the shapes.
            foreach (Shape shape in shapes)
            {
                // Check if the type of the shape is equal to the given type.
                if (shape.Type == type)
                {
                    // Add the shape to the list.
                    shapes.Add(shape);
                }
            }

            // Return the list of shapes.
            return shapes;
        }

        /// <summary>
        /// This method is used to get shapes by their texture.
        /// </summary>
        /// <param name="texture">The texture of the shapes.</param>
        /// <returns>The shapes with the given texture.</returns>
        public List<Shape> GetShapesByTexture(TexturesEnum texture)
        {
            // Create a list of shapes.
            List<Shape> shapes = new List<Shape>();

            // Loop through all the shapes.
            foreach (Shape shape in this.shapes)
            {
                // Check if the texture of the shape is equal to the given texture.
                if (shape.Texture == texture)
                {
                    // Add the shape to the list.
                    shapes.Add(shape);
                }
            }

            // Return the list of shapes.
            return shapes;
        }

        /// <summary>
        /// This method is used to tell whether the string is a valid color or not.
        /// </summary>
        /// <param name="strColor">Color name of string data type.</param>
        /// <returns>True, if the color name is valid. Otherwise false.</returns>
        private bool IsValidShapeColor(string strColor)
        {
            ColorsEnum color;
            return ColorsEnum.TryParse(strColor, out color);
        }

        /// <summary>
        /// This method is used to tell whether the string is a valid texture or not.
        /// </summary>
        /// <param name="strTexture">Texture name of string data type.</param>
        /// <returns>True, if the texture name is valid. Otherwise false.</returns>
        private bool IsValidShapeTexture(string strTexture)
        {
            TexturesEnum texture;
            return TexturesEnum.TryParse(strTexture, out texture);
        }

        /// <summary>
        /// This method is used to tell whether the string is a valid shape type or not.
        /// </summary>
        /// <param name="strType">Shape type name of string data type.</param>
        /// <returns>True, if the shape type name is valid. Otherwise false.</returns>
        private bool IsValidShapeType(string strType)
        {
            ShapeTypeEnum type;
            return ShapeTypeEnum.TryParse(strType, out type);
        }

        /// <summary>
        /// This method is used to tell whether the parameters used to create a shape are valid or not.
        /// </summary>
        /// <param name="strColor">Color name of string data type.</param>
        /// <param name="strTexture">Texture name of string data type.</param>
        /// <param name="strType">Shape type name of string data type.</param>
        /// <returns>True, if the shape parameters are all valid. Otherwise false.</returns>
        private bool IsValidShapeParameter(string strColor, string strTexture, string strType)
        {
            return this.IsValidShapeColor(strColor) && this.IsValidShapeTexture(strTexture) && this.IsValidShapeType(strType);
        }
    }
}
