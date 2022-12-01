﻿// <copyright file="LetterController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Controllers
{
    using Alphabet_School.Models;
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// This class handles the alphabatical letters. It can be used to create, update and delete letters.
    /// </summary>
    public class LetterController : ILetterController
    {
        // List of letters. This list is used to store all the capital alphbet letters of english.
        private List<ILetterModel> englishAlphabets;

        // List of letters. These are the letters that are created by the children during the program execution.
        private List<ILetterModel> userLetters;

        // List of letters. Used to store that are changed.
        private List<ILetterModel> undoLetters;

        // The recently excecuted letter command, that can be undone.
        private UndoCommandEnum undoCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetterController"/> class.
        /// </summary>
        public LetterController()
        {
            // Initialize the list of letters added by user.
            this.userLetters = new List<ILetterModel>();

            // Initialize the list of letters that are changed.
            this.undoLetters = new List<ILetterModel>();

            // Initialize the list of english alphabets.
            this.englishAlphabets = new List<ILetterModel>();

            // At start there is nothing to undo
            this.undoCommand = 0;

            // Add all the english alphabets with their shapes to the list.
            this.englishAlphabets.Add(new LetterModel('A', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('B', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallCurve), new ShapeModel(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new LetterModel('C', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCurve) }));
            this.englishAlphabets.Add(new LetterModel('D', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigCurve) }));
            this.englishAlphabets.Add(new LetterModel('E', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('F', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('G', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCurve), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('H', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('I', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('J', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new LetterModel('K', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('L', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('M', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('N', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new LetterModel('O', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle) }));
            this.englishAlphabets.Add(new LetterModel('P', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new LetterModel('Q', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('R', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallCurve), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('S', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.SmallCurve), new ShapeModel(ShapeTypeEnum.SmallCurve) }));
            this.englishAlphabets.Add(new LetterModel('T', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new LetterModel('U', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallCurve), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('V', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new LetterModel('W', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('X', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.BigLine) }));
            this.englishAlphabets.Add(new LetterModel('Y', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));
            this.englishAlphabets.Add(new LetterModel('Z', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.SmallLine), new ShapeModel(ShapeTypeEnum.BigLine), new ShapeModel(ShapeTypeEnum.SmallLine) }));

            this.userLetters.Add(new LetterModel('C', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigCircle, ColorsEnum.Blue, TexturesEnum.Solid) }));
            this.userLetters.Add(new LetterModel('I', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Red, TexturesEnum.Dotted), new ShapeModel(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid) }));
            this.userLetters.Add(new LetterModel('M', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Blue, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid), new ShapeModel(ShapeTypeEnum.SmallLine, ColorsEnum.Blue, TexturesEnum.Solid) }));
            this.userLetters.Add(new LetterModel('P', new List<IShapeModel> { new ShapeModel(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Sand), new ShapeModel(ShapeTypeEnum.SmallCurve, ColorsEnum.Blue, TexturesEnum.Solid) }));
        }

        /// <inheritdoc/>
        public List<ILetterModel> GetLetters() => this.userLetters;

        /// <inheritdoc/>
        public ILetterModel? GetAlphabetOnName(char name)
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

        /// <inheritdoc/>
        public List<ILetterModel> GetLettersWithShapeNumMoreThen(int shapesNum)
        {
            return this.userLetters.Where(letter => letter.Shapes.Count > shapesNum).ToList();
        }

        /// <inheritdoc/>
        public List<ILetterModel> GetLettersWithShapesColor(string strColor)
        {
            // parse the color.
            ColorsEnum color = Enum.TryParse(strColor, out color) ? color : 0;
            return this.userLetters.Where(letter => letter.Shapes.Any(shape => shape.Color == color)).ToList();
        }

        /// <inheritdoc/>
        public List<ILetterModel> GetEnglishAlphabets() => this.englishAlphabets;

        /// <inheritdoc/>
        public bool AddLetter(char name, List<IShapeModel> shapes)
        {
            ILetterModel letter = new LetterModel(name, shapes);

            // Add the letter to the list of letters. And return true.
            this.userLetters.Add(letter);
            this.undoCommand = UndoCommandEnum.Add;
            this.undoLetters.Add(letter);
            return true;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void DeleteAllLetters()
        {
            this.undoCommand = UndoCommandEnum.DeleteAll;
            this.undoLetters = this.userLetters;
            this.userLetters = new List<ILetterModel>();
        }

        /// <inheritdoc/>
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
                this.undoLetters = new List<ILetterModel>();
            }

            // Reset the fields and return the command number.
            int commandNumber = (int)this.undoCommand;
            this.undoCommand = 0;
            this.undoLetters.Clear();
            return commandNumber;
        }
    }
}