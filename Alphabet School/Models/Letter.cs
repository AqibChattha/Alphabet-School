// <copyright file="Letter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Models
{
    /// <summary>
    /// Represents a english alphabet Letter. A single or multiple shapes are used to create a letter.
    /// </summary>
    public class Letter
    {
        // The list letter's component shapes.
        private List<Shape> shapes;

        // The letter's name.
        private char name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Letter"/> class.
        /// </summary>
        /// <param name="name">The character representing the shape.</param>
        /// <param name="shapes">The shapes used to build this letter.</param>
        public Letter(char name, List<Shape> shapes)
        {
            this.name = name;
            this.shapes = shapes;
        }

        /// <summary>
        /// Gets the character representing the letter name.
        /// </summary>
        public char Name => this.name;

        /// <summary>
        /// Gets the list of shapes that are used to create the letter.
        /// </summary>
        public List<Shape> Shapes => this.shapes;

        /// <inheritdoc/>
        public override string ToString()
        {
            string result = string.Empty;
            result += this.name + "[";
            for (int i = 0; i < this.shapes.Count; i++)
            {
                // Add the shape's string representation to the result string.
                result += this.shapes[i].ToString();

                // Add a comma if it is not the last shape.
                if (i == this.shapes.Count - 1)
                {
                    result += "]";
                }
                else
                {
                    result += ", ";
                }
            }

            return result;
        }
    }
}
