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

        // List of letters. These are the letters that are created by the children during the program execution.
        private List<Letter> userLetters;

        // List of letters. Used to store that are changed.
        private List<Letter> undoLetters;

        // The recently excecuted letter command, that can be undone.
        private UndoCommandEnum undoCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetterHandler"/> class.
        /// </summary>
        public LetterHandler()
        {
            // Initialize the list of letters added by user.
            this.userLetters = new List<Letter>();

            // Initialize the list of letters that are changed.
            this.undoLetters = new List<Letter>();

            // Initialize the list of english alphabets.
            this.englishAlphabets = new List<Letter>();

            // At start there is nothing to undo
            this.undoCommand = 0;

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

            this.userLetters.Add(new Letter('C', new List<Shape> { new Shape(ShapeTypeEnum.BigCircle, ColorsEnum.Blue, TexturesEnum.Solid) }));
            this.userLetters.Add(new Letter('I', new List<Shape> { new Shape(ShapeTypeEnum.BigLine, ColorsEnum.Red, TexturesEnum.Dotted), new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid), new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid) }));
            this.userLetters.Add(new Letter('M', new List<Shape> { new Shape(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new Shape(ShapeTypeEnum.BigLine, ColorsEnum.Blue, TexturesEnum.Solid), new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid), new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid) }));
            this.userLetters.Add(new Letter('P', new List<Shape> { new Shape(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Sand), new Shape(ShapeTypeEnum.SmallCurve, ColorsEnum.Blue, TexturesEnum.Solid) }));
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
        /// Get the letter from the default alphabets list on the base on letter name.
        /// </summary>
        /// <param name="name">The name of the default letter to be serched.</param>
        /// <returns>Letter where the name is matched, if not then it returns null.</returns>
        public Letter? GetAlphabetOnName(char name)
        {
            for (int i = 0; i < this.englishAlphabets.Count; i++)
            {
                if (this.englishAlphabets[i].Name == name)
                {
                    return this.englishAlphabets[i];
                }
            }

            return null;
        }

        /// <summary>
        /// This method is used to get the list of user letters.
        /// </summary>
        /// <returns>The list of letters.</returns>
        /// <remarks>It returns the list of letters added by the user.</remarks>
        public List<Letter> GetLetters() => this.userLetters;

        /// <summary>
        /// Get all the letters in user list which are made of number of shapes greater then given number.
        /// </summary>
        /// <param name="shapesNum">The number of shapes should be greater then this param.</param>
        /// <returns>The list of letter that have shapes number greater than given number.</returns>
        public List<Letter> GetLettersWithShapeNumMoreThen(int shapesNum)
        {
            return this.userLetters.Where(letter => letter.Shapes.Count > shapesNum).ToList();
        }

        /// <summary>
        /// Get all the letters in user list which contains a shapes with the given color.
        /// </summary>
        /// <param name="strColor">The color of shapes the letters should contain.</param>
        /// <returns>List of letter which contain the shape of given color.</returns>
        public List<Letter> GetLettersWithShapesColor(string strColor)
        {
            // parse the color.
            ColorsEnum color = Enum.TryParse(strColor, out color) ? color : 0;
            return this.userLetters.Where(letter => letter.Shapes.Any(shape => shape.Color == color)).ToList();
        }

        /// <summary>
        /// This method is used to get the list of english alphabets.
        /// </summary>
        /// <returns>The list of english alphabets.</returns>
        /// <remarks>It returns the list of english alphabets.</remarks>
        public List<Letter> GetEnglishAlphabets() => this.englishAlphabets;

        /// <summary>
        /// Create and add a new letter into the users letter list.
        /// </summary>
        /// <param name="name">Name of the letter to be created.</param>
        /// <param name="shapes">The shapes that will be used to create the letter.</param>
        /// <returns>True if the letter is added successfuly.</returns>
        public bool AddLetter(char name, List<Shape> shapes)
        {
            Letter letter = new Letter(name, shapes);

            // Add the letter to the list of letters. And return true.
            this.userLetters.Add(letter);
            this.undoCommand = UndoCommandEnum.Add;
            this.undoLetters.Add(letter);
            return true;
        }

        /// <summary>
        /// This method is used to remove a letter from the list of letters.
        /// </summary>
        /// <param name="id">The id number display in the list.</param>
        /// <returns>True if the letter is removed successfully, false otherwise.</returns>
        public bool DeleteLetter(int id)
        {
            if (id >= 1 && id < this.userLetters.Count)
            {
                this.undoCommand = UndoCommandEnum.Delete;
                this.undoLetters.Add(this.userLetters[id - 1]);

                // Remove the letter from the list of letters. And return true.
                this.userLetters.RemoveAt(id - 1);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to delete all the letters in the user letter's list.
        /// </summary>
        public void DeleteAllLetters()
        {
            this.undoCommand = UndoCommandEnum.DeleteAll;
            this.undoLetters = this.userLetters;
            this.userLetters = new List<Letter>();
        }

        /// <summary>
        /// This method will undo the last action if there is any.
        /// </summary>
        /// <returns>The command number that is undone. 0 if there are no prior commands.</returns>
        public int UndoCommand()
        {
            if (this.undoCommand == 0)
            {
                return (int)this.undoCommand;
            }
            else if (this.undoCommand == UndoCommandEnum.Add)
            {
                this.userLetters.Remove(this.undoLetters[0]);
            }
            else if (this.undoCommand == UndoCommandEnum.Delete)
            {
                this.userLetters.Add(this.undoLetters[0]);
            }
            else if (this.undoCommand == UndoCommandEnum.DeleteAll)
            {
                this.userLetters = this.undoLetters;
                this.undoLetters = new List<Letter>();
            }

            // Reset the fields and return the command number.
            int commandNumber = (int)this.undoCommand;
            this.undoCommand = 0;
            this.undoLetters.Clear();
            return commandNumber;
        }
    }
}