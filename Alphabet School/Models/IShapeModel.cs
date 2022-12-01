// <copyright file="IShapeModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Models
{
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// Interface for the shape model.
    /// </summary>
    public interface IShapeModel
    {

        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        public ColorsEnum Color { get; set; }

        /// <summary>
        /// Gets or sets the texture of the shape.
        /// </summary>
        public TexturesEnum Texture { get; set; }

        /// <summary>
        /// Gets or sets the type of the shape.
        /// </summary>
        public ShapeTypeEnum Type { get; set; }
    }
}
