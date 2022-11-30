// <copyright file="LetterHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Handlers
{
    using Alphabet_School.Models;
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// This class handles the alphabatical letters. It can be used to create, update and delete letters.
    /// </summary>
    public class LetterHandler
    {
        // List of letters. This list is used to store all the capital alphbet letters of english.
        private List<Letter> englishAlphabets;

        // List of letter. These are the letters that are created by the children during the program execution.
        private List<Letter> userLetters;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetterHandler"/> class.
        /// </summary>
        public LetterHandler()
        {
            // Initialize the list of letters.
            this.userLetters = new List<Letter>();

            // Initialize the list of english alphabets.
            this.englishAlphabets = new List<Letter>();

            // Add all the english alphabets with their shapes to the list.
            this.englishAlphabets.Add(new Letter('A', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('B', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallCurve), new Shape(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new Letter('C', new List<Shape> { new Shape(ShapeTypeEnum.BigCurve) }));
            this.englishAlphabets.Add(new Letter('D', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigCurve) }));
            this.englishAlphabets.Add(new Letter('E', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('F', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('G', new List<Shape> { new Shape(ShapeTypeEnum.BigCurve), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('H', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('I', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('J', new List<Shape> { new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new Letter('K', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('L', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('M', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('N', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new Letter('O', new List<Shape> { new Shape(ShapeTypeEnum.BigCircle) }));
            this.englishAlphabets.Add(new Letter('P', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new Letter('Q', new List<Shape> { new Shape(ShapeTypeEnum.BigCircle), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('R', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallCurve), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('S', new List<Shape> { new Shape(ShapeTypeEnum.SmallCurve), new Shape(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new Letter('T', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new Letter('U', new List<Shape> { new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallCurve), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('V', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new Letter('W', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('X', new List<Shape> { new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new Letter('Y', new List<Shape> { new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new Letter('Z', new List<Shape> { new Shape(ShapeTypeEnum.SmallLine), new Shape(ShapeTypeEnum.BigLine), new Shape(ShapeTypeEnum.SmallLine) }));
        }

        /// <summary>
        /// Gets the user letter list in the form of a string.
        /// </summary>
        /// <returns>The user letter list in the form of a string.</returns>
        public string StringifiedUserLetters
        {
            get
            {
                string result = string.Empty;
                for (int i = 0; i < this.userLetters.Count; i++)
                {
                    result += i + 1 + "- " + this.userLetters[i].ToString();

                    if (i < this.userLetters.Count - 1)
                    {
                        result += Environment.NewLine;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the alphabet letter list in the form of a string.
        /// </summary>
        /// <returns>The alphabet letter list in the form of a string.</returns>
        public string StringifiedAlphabetLetters
        {
            get
            {
                string result = string.Empty;
                for (int i = 0; i < this.englishAlphabets.Count; i++)
                {
                    result += i + 1 + "- " + this.englishAlphabets[i].ToString();

                    if (i < this.englishAlphabets.Count - 1)
                    {
                        result += Environment.NewLine;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// This method is used to get the list of user letters.
        /// </summary>
        /// <returns>The list of letters.</returns>
        /// <remarks>It returns the list of letters added by the user.</remarks>
        public List<Letter> GetLetters() => this.userLetters;

        /// <summary>
        /// This method is used to get the list of english alphabets.
        /// </summary>
        /// <returns>The list of english alphabets.</returns>
        /// <remarks>It returns the list of english alphabets.</remarks>
        public List<Letter> GetEnglishAlphabets() => this.englishAlphabets;

        /// <summary>
        /// This method is used to add a letter to the list of letters.
        /// </summary>
        /// <param name="letter">The letter to be added.</param>
        /// <returns>True if the letter is added successfully, false otherwise.</returns>
        public bool AddLetter(Letter letter)
        {
            // Check if the letter is valid english alphabet.
            if (this.IsLetterValidEnglishAlphabet(letter))
            {
                // Add the letter to the list of letters. And return true.
                this.userLetters.Add(letter);
                return true;
            }

            // Return false if the letter is not a valid english alphabet.
            return false;
        }

        private bool IsLetterValidEnglishAlphabet(Letter letter)
        {
            // Loop through all the english alphabets.
            foreach (Letter alphabet in this.englishAlphabets)
            {
                // If the letter is found in the english alphabets, then it is valid.
                if (alphabet.Name == letter.Name)
                {
                    // Check if the shapes are valid.
                    if (alphabet.Shapes.Count == letter.Shapes.Count)
                    {
                        // create a copy of matched alphabet's shapes.
                        List<Shape> alphShapes = alphabet.Shapes;

                        // Loop through all the shapes of the letter.
                        foreach (Shape letterShape in letter.Shapes)
                        {
                            // Loop through all the shapes of the alphabet matched.
                            foreach (Shape alphShape in alphShapes)
                            {
                                // If the shape is found in the alphabet's shapes, then remove it from the copied list.
                                if (alphShape.Type == letterShape.Type)
                                {
                                    alphShapes.Remove(alphShape);

                                    // Break the loop as the shape is removed.
                                    break;
                                }
                            }
                        }

                        // If the copied list is empty, then all the shapes are matched. So, the letter is valid, then return true.
                        if (alphShapes.Count == 0)
                        {
                            return true;
                        }

                        // Else, the letter is invalid, then return false.
                        else
                        {
                            return false;
                        }
                    }

                    // If the number of shapes are not equal, then the letter is invalid, then return false.
                    else
                    {
                        return false;
                    }
                }
            }

            // If the letter is not found in the english alphabets, then it is invalid, then return false.
            return false;
        }
    }
}