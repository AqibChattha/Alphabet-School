// <copyright file="Shape.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Models
{
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// Represents a shape. A shape is a geometric figure. A single or multiple shapes are used to create a letter.
    /// </summary>
    public class Shape
    {
        // The shape's color.
        private ColorsEnum color;

        // The shape's type.
        private TexturesEnum texture;

        // The shape's texture.
        private ShapeTypeEnum type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// A shape without any color or texture.
        /// </summary>
        /// <param name="type">The type of shape.</param>
        public Shape(ShapeTypeEnum type)
        {
            this.type = type;
            this.color = 0;
            this.texture = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// A shape with all parameter defined such as color, texture and type.
        /// </summary>
        /// <param name="color">The color of the shape.</param>
        /// <param name="texture">The texture of the shape.</param>
        /// <param name="type">The type of the shape.</param>
        public Shape(ColorsEnum color, TexturesEnum texture, ShapeTypeEnum type)
        {
            this.color = color;
            this.texture = texture;
            this.type = type;
        }

        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        public ColorsEnum Color
        {
            get => this.color;
            set => this.color = value;
        }

        /// <summary>
        /// Gets or sets the texture of the shape.
        /// </summary>
        public TexturesEnum Texture
        {
            get => this.texture;
            set => this.texture = value;
        }

        /// <summary>
        /// Gets or sets the type of the shape.
        /// </summary>
        public ShapeTypeEnum Type
        {
            get => this.type;
            set => this.type = value;
        }

        /// <summary>
        /// Returns a string representation of the shape.
        /// </summary>
        /// <returns>A string representation of the shape.</returns>
        public override string ToString()
        {
            string result = string.Empty;
            if (this.color != 0 || this.texture != 0)
            {
                result += "(";
                if (this.color != 0)
                {
                    result += "Color: " + this.color;
                }

                if (this.color != 0 && this.texture != 0)
                {
                    result += "; Texture: " + this.texture;
                }
                else
                {
                    result += "Texture: " + this.texture;
                }

                result += ")";
            }

            return result;
        }
    }
}
