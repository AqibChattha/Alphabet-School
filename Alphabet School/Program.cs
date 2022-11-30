// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School
{
    /// <summary>
    /// The main class of the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method of the program.
        /// </summary>
        /// <param name="args">String arguments for the main method.</param>
        private static void Main(string[] args)
        {
            Views view = new Views();
            int mainMenuInput;

            do
            {
                mainMenuInput = view.MainMenu;
                int shapeMenuInput;
                int letterMenuInput;

                switch (mainMenuInput)
                {
                    case 1:
                        do
                        {
                            shapeMenuInput = view.ShapesMenu;

                            switch (shapeMenuInput)
                            {
                                case 1:
                                    view.CreateShape();
                                    break;
                                case 2:
                                    view.UpdateShape();
                                    break;
                                case 3:
                                    view.DisplayAllShapes();
                                    break;
                                case 4:
                                    view.DeleteShape();
                                    break;
                                case 5:
                                    view.DeleteAllShapes();
                                    break;
                                case 6:
                                    view.UndoLastActionFromShapesMenu();
                                    view.UndoLastAction();
                                    break;
                                default:
                                    break;
                            }
                        }
                        while (shapeMenuInput > 0 && shapeMenuInput < 7);
                        break;

                    case 2:
                        do
                        {
                            letterMenuInput = view.LetterMenu;

                            switch (letterMenuInput)
                            {
                                case 1:
                                    view.CreateLetter();
                                    break;
                                case 2:
                                    view.DisplayAllLetters();
                                    break;
                                case 3:
                                    view.DeleteLetter();
                                    break;
                                case 4:
                                    view.DeleteAllLetters();
                                    break;
                                case 5:
                                    view.UndoLastActionFromLettersMenu();
                                    view.UndoLastAction();
                                    break;
                                default:
                                    break;
                            }
                        }
                        while (letterMenuInput > 0 && letterMenuInput < 6);
                        break;

                    case 3:
                        view.UndoLastActionFromMainMenu();
                        view.UndoLastAction();
                        break;

                    default:
                        if (!view.Exit())
                        {
                            mainMenuInput = 1;
                        }

                        break;
                }
            }
            while (mainMenuInput > 0 && mainMenuInput < 4);
        }
    }
}