// <copyright file="IConsoleView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Views
{
    /// <summary>
    /// The interface for the console view.
    /// </summary>
    public interface IConsoleView
    {
        /// <summary>
        /// Gets the Main Menu input from the user after displaying the Main Menu.
        /// </summary>
        public int MainMenu { get; }

        /// <summary>
        /// Gets the Shapes Menu input from the user after displaying the Shapes Menu.
        /// </summary>
        public int ShapesMenu { get; }

        /// <summary>
        /// Gets the Letter Menu input from the user after displaying the Letter Menu.
        /// </summary>
        public int LettersMenu { get; }

        /// <summary>
        /// Takes input from the user, creates a shape and stores it into the list. Tells whether the shape was created or not.
        /// </summary>
        public void CreateShape();

        /// <summary>
        /// Updates the shape at the given index with the new values.
        /// </summary>
        public void UpdateShape();

        /// <summary>
        /// Display all the shapes in the list.
        /// </summary>
        public void DisplayAllShapes();

        /// <summary>
        /// Deletes the shape at the given index.
        /// </summary>
        public void DeleteShape();

        /// <summary>
        /// Deletes all the shapes in the list.
        /// </summary>
        public void DeleteAllShapes();

        /// <summary>
        /// Creates a new letter and adds it to the list.
        /// </summary>
        public void CreateLetter();

        /// <summary>
        /// Displays all the letters in the list.
        /// </summary>
        public void DisplayAllLetters();

        /// <summary>
        /// Deletes a letter from the list.
        /// </summary>
        public void DeleteLetter();

        /// <summary>
        /// Deletes all the letters from the list.
        /// </summary>
        public void DeleteAllLetters();

        /// <summary>
        /// Print the header when inside undo section from the Shapes Menu.
        /// </summary>
        public void UndoLastActionFromShapesMenu();

        /// <summary>
        /// Print the header when inside undo section from the Letters Menu.
        /// </summary>
        public void UndoLastActionFromLettersMenu();

        /// <summary>
        /// Print the header when inside undo section from the Main Menu.
        /// </summary>
        public void UndoLastActionFromMainMenu();

        /// <summary>
        /// This will undo the last action performed by the user.
        /// </summary>
        public void UndoLastAction();

        /// <summary>
        /// Confirms about the exit from the application.
        /// </summary>
        /// <returns>True if the confirms the exit, otherwise false.</returns>
        public bool Exit();

        /// <summary>
        /// Gets the string input from the console.
        /// </summary>
        /// <returns>String input.</returns>
        public string StringInputFromConsole();

        /// <summary>
        /// Gets the integer input from the console.
        /// </summary>
        /// <returns>Integer input.</returns>
        public int IntegerInputFromConsole();

        /// <summary>
        /// Gets the integer input from the console within a boundry.
        /// </summary>
        /// <param name="min">The lower limit of the integer input.</param>
        /// <param name="max">The upper limit of the integer input.</param>
        /// <returns>The integer input with the bounds.</returns>
        public int BoundedIntegerInputFromConsole(int min, int max);

        /// <summary>
        /// Method called at the end of each function to stop and read a user key to continue.
        /// </summary>
        /// <param name="message">Messege to be displayed when the program is halted.</param>
        /// <returns>The key that user pressed.</returns>
        public char PressAnyKeyToContinue(string message);
    }
}
