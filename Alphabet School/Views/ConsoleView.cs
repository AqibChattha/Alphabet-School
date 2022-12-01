// <copyright file="ConsoleView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Views
{
    using Alphabet_School.Controllers;

    /// <summary>
    /// Represents the views of the console application.
    /// </summary>
    public class ConsoleView : IConsoleView
    {
        /// <summary>
        /// The handler to manage the letter objects.
        /// </summary>
        private LetterController letterHandler;

        /// <summary>
        /// The handler to manage the shape objects.
        /// </summary>
        private ShapeController shapeHandler;

        /// <summary>
        /// Check whether the last action performed for shape or not.
        /// </summary>
        private bool isLastActionForShape;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleView"/> class.
        /// </summary>
        public ConsoleView()
        {
            this.letterHandler = new LetterController();
            this.shapeHandler = new ShapeController();
            this.isLastActionForShape = false;
        }

        /// <inheritdoc/>
        public int MainMenu
        {
            get
            {
                Console.Clear();
                Console.Write("Main Menu\n" +
                    "\n" +
                    "1 - Shapes.\n" +
                    "2 - Letters.\n" +
                    "3 - Undo last action\n" +
                    "4 - Exit.\n" +
                    "\n" +
                    "Enter your choice: ");

                return this.BoundedIntegerInputFromConsole(1, 4);
            }
        }

        /// <inheritdoc/>
        public int ShapesMenu
        {
            get
            {
                Console.Clear();
                Console.Write("Main Menu => Shapes Menu\n" +
                    "\n" +
                    "1 - Create a shape.\n" +
                    "2 - Update a shape\n" +
                    "3 - Display all shapes.\n" +
                    "4 - Delete a shape.\n" +
                    "5 - Delete all shapes.\n" +
                    "6 - Undo last action\n" +
                    "7 - Go Back.\n" +
                    "\n" +
                    "Enter your choice: ");

                return this.BoundedIntegerInputFromConsole(1, 7);
            }
        }

        /// <inheritdoc/>
        public int LettersMenu
        {
            get
            {
                Console.Clear();
                Console.Write("Main Menu => Letter Menu\n" +
                    "\n" +
                    "1 - Create a letter.\n" +
                    "2 - Display all letters.\n" +
                    "3 - Delete a letter.\n" +
                    "4 - Delete all letters.\n" +
                    "5 - Undo last action\n" +
                    "6 - Go Back.\n" +
                    "\n" +
                    "Enter your choice: ");

                return this.BoundedIntegerInputFromConsole(1, 6);
            }
        }

        /// <inheritdoc/>
        public void UndoLastActionFromMainMenu()
        {
            Console.Clear();
            Console.Write("Main Menu => Undo last action\n" +
                "\n");
        }

        /// <inheritdoc/>
        public void UndoLastActionFromShapesMenu()
        {
            Console.Clear();
            Console.Write("Main Menu => Shapes => Undo last action\n" +
                "\n");
        }

        /// <inheritdoc/>
        public void UndoLastActionFromLettersMenu()
        {
            Console.Clear();
            Console.Write("Main Menu => Letters => Undo last action\n" +
                "\n");
        }

        /// <inheritdoc/>
        public void UndoLastAction()
        {
            int commandType;
            if (this.isLastActionForShape)
            {
                commandType = this.shapeHandler.UndoCommand();
            }
            else
            {
                commandType = this.letterHandler.UndoCommand();
            }

            // If there is prior command to undo.
            if (commandType == 0)
            {
                Console.WriteLine("There is no action to undo.");
            }

            // If the command to be undone is of add type.
            else if (commandType == 1)
            {
                if (this.isLastActionForShape)
                {
                    Console.WriteLine("The last add shape action is undone.");
                }
                else
                {
                    Console.WriteLine("The last add letter action is undone.");
                }
            }

            // If the command to be undone is of update type.
            else if (commandType == 2)
            {
                if (this.isLastActionForShape)
                {
                    Console.WriteLine("The last update shape action is undone.");
                }
                else
                {
                    Console.WriteLine("The last update letter action is undone.");
                }
            }

            // If the command to be undone is of delete type.
            else if (commandType == 3)
            {
                if (this.isLastActionForShape)
                {
                    Console.WriteLine("The last delete shape action is undone.");
                }
                else
                {
                    Console.WriteLine("The last delete letter action is undone.");
                }
            }

            // If the command to be undone is of delete all type.
            else if (commandType == 4)
            {
                if (this.isLastActionForShape)
                {
                    Console.WriteLine("The last delete all shapes action is undone.");
                }
                else
                {
                    Console.WriteLine("The last delete all letters action is undone.");
                }
            }

            // If the command type is not recognized.
            else
            {
                Console.WriteLine("The last action command is not recognized.");
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public void CreateShape()
        {
            // Clear the console and get the necessory input from the user to create a shape.
            Console.Clear();
            Console.Write("Main Menu => Shapes Menu => Create a shape\n" +
                "\n" +
                "Enter the shape type (BigLine, SmallLine, BigCurve, SmallCurve, BigCircle, SmallCircle): ");
            string type = this.StringInputFromConsole();
            Console.Write("Enter the shape color (Red, Blue, Orange, Green): ");
            string color = this.StringInputFromConsole();
            Console.Write("Enter the shape texture (Sand, Solid, Dotted): ");
            string texture = this.StringInputFromConsole();
            Console.WriteLine();

            // Create a shape object and store it in the list. If the shape was created successfully, then add the command to the command list.
            if (this.shapeHandler.CreateShape(color, texture, type))
            {
                Console.WriteLine("Shape created successfully.");
                this.isLastActionForShape = true;
            }
            else
            {
                Console.WriteLine("Shape creation failed.");
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public void UpdateShape()
        {
            // Clear the console and get the necessory input from the user to update a shape.
            Console.Clear();
            Console.WriteLine("Main Menu => Shapes Menu => Update a shape\n" +
                "\n" +
                "Enter the id shape you want to update:");
            int id = this.IntegerInputFromConsole();

            if (id > 0 && id <= this.shapeHandler.GetShapes().Count)
            {
                Console.WriteLine();
                Console.Write("Enter the shape type (BigLine, SmallLine, BigCurve, SmallCurve, BigCircle, SmallCircle): ");
                string type = this.StringInputFromConsole();
                Console.Write("Enter the shape color (Red, Blue, Orange, Green): ");
                string color = this.StringInputFromConsole();
                Console.Write("Enter the shape texture (Sand, Solid, Dotted): ");
                string texture = this.StringInputFromConsole();
                Console.WriteLine();

                // Update the shape at the given index with the new values. If the shape was updated successfully, then add the command to the command list.
                if (this.shapeHandler.UpdateShape(id, color, texture, type))
                {
                    Console.WriteLine("Shape updated successfully.");
                    this.isLastActionForShape = true;
                }
                else
                {
                    Console.WriteLine("Shape updation failed.");
                }
            }
            else
            {
                Console.WriteLine("Shape to update with given id is not found.");
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public void DisplayAllShapes()
        {
            // Clear the console and display all the shapes in the list.
            Console.Clear();
            Console.WriteLine("Main Menu => Shapes Menu => Display all shapes\n" +
                "\n" +
                "All shapes:\n");

            int i = 1;

            // Print all the shapes in the list with id.
            foreach (var shape in this.shapeHandler.GetShapes())
            {
                Console.WriteLine(i + " - " + shape.ToString());
                i++;
            }

            // Wait for user to press any key to continue.
            char key = '\0';
            do
            {
                // If the user presses 'f' or 'F' then filter the shapes on tha basis of their colors.
                if (key == 'f' || key == 'F')
                {
                    Console.WriteLine();
                    Console.Write("Enter the shape color (Red, Blue, Orange, Green): ");
                    string color = this.StringInputFromConsole();
                    Console.Clear();
                    Console.WriteLine("Main Menu => Shapes Menu => Display all shapes => Filtered\n" +
                        "\n" +
                        "All shapes filtered by color '" + color + "':\n");
                    foreach (var shape in this.shapeHandler.GetShapeByColor(color))
                    {
                        // Print all the shapes in the list with id of total list context.
                        Console.WriteLine((this.shapeHandler.GetShapes().FindIndex(a => a == shape) + 1) + " - " + shape.ToString());
                    }
                }

                // If the user presses 't' or 'T' then filter the shapes on tha basis of their colors.
                else if (key == 't' || key == 'T')
                {
                    Console.WriteLine();
                    Console.Write("Enter the shape texture (Sand, Solid, Dotted): ");
                    string texture = this.StringInputFromConsole();
                    Console.Clear();
                    Console.WriteLine("Main Menu => Shapes Menu => Display all shapes => Filtered\n" +
                        "\n" +
                        "All shapes filtered by texture " + texture + ":\n");
                    foreach (var shape in this.shapeHandler.GetShapesByTexture(texture))
                    {
                        // Print all the shapes in the list with id of total list context.
                        Console.WriteLine((this.shapeHandler.GetShapes().FindIndex(a => a == shape) + 1) + " - " + shape.ToString());
                    }
                }

                // Display the menu for filtering the shapes.
                Console.WriteLine();
                key = this.PressAnyKeyToContinue("Press (F) to filter shapes by color, \n" +
                    "(T) to filter shapes by texture, \n" +
                    "or any other key to go back to the shapes menu.");
            }

            // If the user presses 'f' or 'F' or 't' or 'T' again then continue the loop.
            while (key == 'f' || key == 'F' || key == 't' || key == 'T');
        }

        /// <inheritdoc/>
        public void DeleteShape()
        {
            // Clear the console and get the id from the user to delete a shape.
            Console.Clear();
            Console.Write("Main Menu => Shapes Menu => Delete a shape\n" +
                "\n" +
                "Enter the shape id: ");
            int id = this.IntegerInputFromConsole();
            Console.WriteLine();

            // Delete the shape at the given index. If the shape was deleted successfully, then add the command to the command list.
            if (this.shapeHandler.DeleteShape(id))
            {
                Console.WriteLine("Shape deleted successfully.");
                this.isLastActionForShape = true;
            }
            else
            {
                Console.WriteLine("Shape deletion failed.");
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public void DeleteAllShapes()
        {
            // Clear the console and ask the user for confirmation.
            Console.Clear();
            Console.Write("Main Menu => Shapes Menu => Delete all shapes\n" +
                "\n" +
                "Are you sure you want to delete all shapes? (Y/N) : ");
            string input = this.StringInputFromConsole();
            Console.WriteLine();

            // If the user confirms the deletion, then delete all the shapes and add the command to the command list.
            if (string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase))
            {
                this.shapeHandler.DeleteAllShapes();
                Console.WriteLine("All shapes deleted successfully.");
                this.isLastActionForShape = true;
            }
            else
            {
                Console.WriteLine("All Shapes deletion cancelled.");
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public void CreateLetter()
        {
            // Clear the console and get the letter details from the user.
            Console.Clear();
            Console.WriteLine("Main Menu => Letter Menu => Create a letter\n" +
                "\n" +
                "Enter the letter name: ");

            char name;

            // Get the shapes needed to create the given letter.
            try
            {
                name = Convert.ToChar(this.StringInputFromConsole());
            }
            catch (Exception)
            {
                name = '\0';
            }

            // The template shapes needed to create the given letter.
            var alphbetShapes = this.letterHandler.GetAlphabetOnName(name)?.Shapes;

            if (alphbetShapes != null)
            {
                // Get the shapes needed to create the given letter from the list of shapes.
                var shapes = this.shapeHandler.RemoveMatchingShapes(alphbetShapes);

                // If the shapes were found in the list of shapes then create the letter and add it to list, then add the command to the command list.
                if (shapes != null && name != '\0')
                {
                    this.letterHandler.AddLetter(name, shapes);
                    Console.WriteLine("Letter created successfully.");
                    this.isLastActionForShape = false;
                }
                else
                {
                    Console.WriteLine("Letter creation failed.");
                }
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public void DisplayAllLetters()
        {
            // Clear the console and display all the letters in the list.
            Console.Clear();
            Console.WriteLine("Main Menu => Letter Menu => Display all letters\n" +
                "\n" +
                "All letters:");
            int i = 1;
            foreach (var letter in this.letterHandler.GetLetters())
            {
                Console.WriteLine(i + " - " + letter.ToString());
                i++;
            }

            // Wait for user to press any key to continue.
            char key = '\0';
            do
            {
                // If the user presses 'f' or 'F' then filter the letters on the basis of their shapes number.
                if (key == 'f' || key == 'F')
                {
                    Console.WriteLine();
                    Console.Write("Filter the letters containing nunber of shapes greater than: ");
                    int shapesNum = this.IntegerInputFromConsole();
                    Console.Clear();
                    Console.WriteLine("Main Menu => Letter Menu => Display all letters => Filtered\n" +
                        "\n" +
                        "All letter having number of shapes greater then '" + shapesNum + "':\n");

                    // Print all the letters in the list with id of total list context.
                    foreach (var letter in this.letterHandler.GetLettersWithShapeNumMoreThen(shapesNum))
                    {
                        Console.WriteLine((this.letterHandler.GetLetters().FindIndex(a => a == letter) + 1) + " - " + letter.ToString());
                    }
                }

                // If the user presses 't' or 'T' then filter the letters on the basis of their shapes color.
                else if (key == 't' || key == 'T')
                {
                    Console.WriteLine();
                    Console.Write("Filter the letters containing shapes of color: ");
                    string color = this.StringInputFromConsole();
                    Console.Clear();
                    Console.WriteLine("Main Menu => Letter Menu => Display all letters => Filtered\n" +
                        "\n" +
                        "All letter containing shapes of color '" + color + "':\n");

                    // Print all the letters in the list with id of total list context.
                    foreach (var letter in this.letterHandler.GetLettersWithShapesColor(color))
                    {
                        Console.WriteLine((this.letterHandler.GetLetters().FindIndex(a => a == letter) + 1) + " - " + letter.ToString());
                    }
                }

                // Display the menu for filtering the letters.
                Console.WriteLine();
                key = this.PressAnyKeyToContinue("Press (F) to filter letters with no. of shapes greater then, \n" +
                    "(T) to filter letters containg shapes of specific color, \n" +
                    "or any other key to go back to the shapes menu.");
            }

            // If the user presses 'f' or 'F' or 't' or 'T' then display the menu again.
            while (key == 'f' || key == 'F' || key == 't' || key == 'T');
        }

        /// <inheritdoc/>
        public void DeleteLetter()
        {
            // Clear the console and display all the letters in the list. Get the letter id from the user.
            Console.Clear();
            Console.WriteLine("Main Menu => Letter Menu => Delete a letter\n" +
                "\n" +
                "Enter the letter id:");
            int id = this.IntegerInputFromConsole();
            Console.WriteLine();

            // If the letter was deleted successfully, then add the command to the command list.
            if (this.letterHandler.DeleteLetter(id))
            {
                Console.WriteLine("Letter deleted successfully.");
                this.isLastActionForShape = false;
            }
            else
            {
                Console.WriteLine("Letter deletion failed.");
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public void DeleteAllLetters()
        {
            // Clear the console and get the confirmation from the user.
            Console.Clear();
            Console.Write("Main Menu => Letter Menu => Delete all letters\n" +
                "\n" +
                "Are you sure you want to delete all letters? (Y/N): ");
            string input = this.StringInputFromConsole();
            Console.WriteLine();

            // If the user confirms the deletion, then delete all the letters and add the command to the command list.
            if (string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase))
            {
                this.letterHandler.DeleteAllLetters();
                Console.WriteLine("All letters deleted successfully.");
                this.isLastActionForShape = false;
            }
            else
            {
                Console.WriteLine("All letters deletion cancelled.");
            }

            // Wait for user to press any key to continue.
            Console.WriteLine();
            this.PressAnyKeyToContinue();
        }

        /// <inheritdoc/>
        public bool Exit()
        {
            // Clear the console and get the confirmation from the user.
            Console.Clear();
            Console.Write("Main Menu => Exit\n" +
                "\n" +
                "Are you sure you want to exit? (Y/N): ");
            string input = this.StringInputFromConsole();
            Console.WriteLine();

            // If the user confirms the exit, then return true.
            if (string.Equals(input, "Y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public string StringInputFromConsole()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                // If the input is not null, then return the input.
                if (input != null)
                {
                    return input;
                }

                Console.Write("Invalid input, Please try again: ");
            }
        }

        /// <inheritdoc/>
        public int IntegerInputFromConsole()
        {
            while (true)
            {
                // catch the exception when the user enters a string.
                try
                {
                    string? input = Console.ReadLine();

                    // If the input is not null, then return the input.
                    return Convert.ToInt32(input);
                }
                catch (Exception)
                {
                    Console.Write("Invalid input, Please try again: ");
                }
            }
        }

        /// <inheritdoc/>
        public int BoundedIntegerInputFromConsole(int min, int max)
        {
            int intInput;

            // Don't show the error on first iteration.
            bool showError = false;
            do
            {
                // If the error is to be shown, then show the error.
                if (showError)
                {
                    Console.WriteLine("Input out of bounds. Please enter a number between " + min + " and " + max);
                }

                // Get the integer input from the user.
                intInput = this.IntegerInputFromConsole();
                showError = true;
            }

            // Repeat the loop until the user enters a valid input.
            while (intInput < min || intInput > max);

            // Return the valid input.
            return intInput;
        }

        /// <inheritdoc/>
        public char PressAnyKeyToContinue(string message = "Press any key to continue...")
        {
            Console.WriteLine(message);
            return Console.ReadKey().KeyChar;
        }
    }
}
