// <copyright file="ILetterController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Alphabet_School.Models;

namespace Alphabet_School.Controllers
{
    /// <summary>
    /// Interface for the letter controller.
    /// </summary>
    public interface ILetterController
    {
        /// <summary>
        /// This method is used to get the list of user letters.
        /// </summary>
        /// <returns>The list of letters.</returns>
        /// <remarks>It returns the list of letters added by the user.</remarks>
        public List<ILetterModel> GetLetters();

        /// <summary>
        /// Get the letter from the default alphabets list on the base on letter name.
        /// </summary>
        /// <param name="name">The name of the default letter to be serched.</param>
        /// <returns>Letter where the name is matched, if not then it returns null.</returns>
        public ILetterModel? GetAlphabetOnName(char name);

        /// <summary>
        /// Get all the letters in user list which are made of number of shapes greater then given number.
        /// </summary>
        /// <param name="shapesNum">The number of shapes should be greater then this param.</param>
        /// <returns>The list of letter that have shapes number greater than given number.</returns>
        public List<ILetterModel> GetLettersWithShapeNumMoreThen(int shapesNum);

        /// <summary>
        /// Get all the letters in user list which contains a shapes with the given color.
        /// </summary>
        /// <param name="strColor">The color of shapes the letters should contain.</param>
        /// <returns>List of letter which contain the shape of given color.</returns>
        public List<ILetterModel> GetLettersWithShapesColor(string strColor);

        /// <summary>
        /// This method is used to get the list of english alphabets.
        /// </summary>
        /// <returns>The list of english alphabets.</returns>
        /// <remarks>It returns the list of english alphabets.</remarks>
        public List<ILetterModel> GetEnglishAlphabets();

        /// <summary>
        /// Create and add a new letter into the users letter list.
        /// </summary>
        /// <param name="name">Name of the letter to be created.</param>
        /// <param name="shapes">The shapes that will be used to create the letter.</param>
        /// <returns>True if the letter is added successfuly.</returns>
        public bool AddLetter(char name, List<IShapeModel> shapes);

        /// <summary>
        /// This method is used to remove a letter from the list of letters.
        /// </summary>
        /// <param name="id">The id number display in the list.</param>
        /// <returns>True if the letter is removed successfully, false otherwise.</returns>
        public bool DeleteLetter(int id);

        /// <summary>
        /// Method to delete all the letters in the user letter's list.
        /// </summary>
        public void DeleteAllLetters();

        /// <summary>
        /// This method will undo the last action if there is any.
        /// </summary>
        /// <returns>The command number that is undone. 0 if there are no prior commands.</returns>
        public int UndoCommand();
    }
}
