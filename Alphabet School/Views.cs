// <copyright file="Views.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School
{
    /// <summary>
    /// Represents the views of the application.
    /// </summary>
    public class Views
    {
        public static int MainMenu
        {
            get
            {
                Console.Clear();
                Console.WriteLine("Main Menu\n" +
                    "\n" +
                    "1 - Shapes.\n" +
                    "2 - Letters.\n" +
                    "3 - Exit." +
                    "\n" +
                    "Enter your choice");

                return BoundedIntegerInputFromConsole(1, 3);
            }
        }

        public static int ShapesMenu
        {
            get
            {
                Console.Clear();
                Console.WriteLine("Main Menu => Shapes Menu\n" +
                    "\n" +
                    "1 - Create a shape.\n" +
                    "2 - Display all shapes.\n" +
                    "3 - Display a shape.\n" +
                    "4 - Delete a shape.\n" +
                    "5 - Delete all shapes.\n" +
                    "6 - Go Back" +
                    "\n" +
                    "Enter your choice");

                return BoundedIntegerInputFromConsole(1, 6);
            }
        }

        public static int LetterMenu
        {
            get
            {
                Console.Clear();
                Console.WriteLine("Letter Menu\n" +
                    "\n" +
                    "1 - Create a letter.\n" +
                    "2 - Display all letters.\n" +
                    "3 - Display a letter.\n" +
                    "4 - Delete a letter.\n" +
                    "5 - Delete all letters.\n" +
                    "6 - Go Back" +
                    "\n" +
                    "Enter your choice");

                return BoundedIntegerInputFromConsole(1, 6);
            }
        }

        public static string CreateShape()
        {
            Console.Clear();
            Console.WriteLine("Create a shape\n" +
                "\n" +
                "Enter the shape type (BigLine, SmallLine, BigCurve, SmallCurve, BigCircle, SmallCircle):");
            return "Create a shape";
        }

        public static string DisplayAllShapes()
        {
            Console.Clear();
            Console.WriteLine("Display all shapes\n" +
                "\n" +
                "All shapes:");
            return "Display all shapes";
        }

        public static string DisplayShape()
        {
            Console.Clear();
            Console.WriteLine("Display a shape\n" +
                "\n" +
                "Enter the shape id:");
            return "Display a shape";
        }

        public static string DeleteShape()
        {
            Console.Clear();
            Console.WriteLine("Delete a shape\n" +
                "\n" +
                "Enter the shape id:");
            return "Delete a shape";
        }

        public static string DeleteAllShapes()
        {
            Console.Clear();
            Console.WriteLine("Delete all shapes\n" +
                "\n" +
                "Are you sure you want to delete all shapes? (Y/N)");
            return "Delete all shapes";
        }

        public static string CreateLetter()
        {
            Console.Clear();
            Console.WriteLine("Create a letter\n" +
                "\n" +
                "Enter the letter name:");
            return "Create a letter";
        }

        public static string DisplayAllLetters()
        {
            Console.Clear();
            Console.WriteLine("Display all letters\n" +
                "\n" +
                "All letters:");
            return "Display all letters";
        }

        public static string DisplayLetter()
        {
            Console.Clear();
            Console.WriteLine("Display a letter\n" +
                "\n" +
                "Enter the letter id:");
            return "Display a letter";
        }

        public static string DeleteLetter()
        {
            Console.Clear();
            Console.WriteLine("Delete a letter\n" +
                "\n" +
                "Enter the letter id:");
            return "Delete a letter";
        }

        public static string DeleteAllLetters()
        {
            Console.Clear();
            Console.WriteLine("Delete all letters\n" +
                "\n" +
                "Are you sure you want to delete all letters? (Y/N)");
            return "Delete all letters";
        }

        public static string Exit()
        {
            Console.Clear();
            Console.WriteLine("Exit\n" +
                "\n" +
                "Are you sure you want to exit? (Y/N)");
            return "Exit";
        }

        public static string InvalidInput()
        {
            Console.Clear();
            Console.WriteLine("Invalid input\n" +
                "\n" +
                "Press any key to continue");
            return "Invalid input";
        }

        public static string InvalidShapeType()
        {
            Console.Clear();
            Console.WriteLine("Invalid shape type\n" +
                "\n" +
                "Press any key to continue");
            return "Invalid shape type";
        }

        public static string InvalidShapeId()
        {
            Console.Clear();
            Console.WriteLine("Invalid shape id\n" +
                "\n" +
                "Press any key to continue");
            return "Invalid shape id";
        }

        public static string InvalidLetterId()
        {
            Console.Clear();
            Console.WriteLine("Invalid letter id\n" +
                "\n" +
                "Press any key to continue");
            return "Invalid letter id";
        }

        public static string ShapeCreated()
        {
            Console.Clear();
            Console.WriteLine("Shape created\n" +
                "\n" +
                "Press any key to continue");
            return "Shape created";
        }

        public static string ShapeDeleted()
        {
            Console.Clear();
            Console.WriteLine("Shape deleted\n" +
                "\n" +
                "Press any key to continue");
            return "Shape deleted";
        }

        public static string ShapesDeleted()
        {
            Console.Clear();
            Console.WriteLine("Shapes deleted\n" +
                "\n" +
                "Press any key to continue");
            return "Shapes deleted";
        }

        public static string LetterCreated()
        {
            Console.Clear();
            Console.WriteLine("Letter created\n" +
                "\n" +
                "Press any key to continue");
            return "Letter created";
        }

        public static string LetterDeleted()
        {
            Console.Clear();
            Console.WriteLine("Letter deleted\n" +
                "\n" +
                "Press any key to continue");
            return "Letter deleted";
        }

        public static string LettersDeleted()
        {
            Console.Clear();
            Console.WriteLine("Letters deleted\n" +
                "\n" +
                "Press any key to continue");
            return "Letters deleted";
        }

        public static string ExitConfirmed()
        {
            Console.Clear();
            Console.WriteLine("Exit confirmed\n" +
                "\n" +
                "Press any key to continue");
            return "Exit confirmed";
        }

        public static string ExitCancelled()
        {
            Console.Clear();
            Console.WriteLine("Exit cancelled\n" +
                "\n" +
                "Press any key to continue");
            return "Exit cancelled";
        }

        public static string ShapeNotDeleted()
        {
            Console.Clear();
            Console.WriteLine("Shape not deleted\n" +
                "\n" +
                "Press any key to continue");
            return "Shape not deleted";
        }

        public static string LetterNotDeleted()
        {
            Console.Clear();
            Console.WriteLine("Letter not deleted\n" +
                "\n" +
                "Press any key to continue");
            return "Letter not deleted";
        }

        public static string ShapeNotCreated()
        {
            Console.Clear();
            Console.WriteLine("Shape not created\n" +
                "\n" +
                "Press any key to continue");
            return "Shape not created";
        }

        public static string LetterNotCreated()
        {
            Console.Clear();
            Console.WriteLine("Letter not created\n" +
                "\n" +
                "Press any key to continue");
            return "Letter not created";
        }

        public static string ShapeNotUpdated()
        {
            Console.Clear();
            Console.WriteLine("Shape not updated\n" +
                "\n" +
                "Press any key to continue");
            return "Shape not updated";
        }

        public static string ShapeUpdated()
        {
            Console.Clear();
            Console.WriteLine("Shape updated\n" +
                "\n" +
                "Press any key to continue");
            return "Shape updated";
        }

        public static string UpdateShape()
        {
            Console.Clear();
            Console.WriteLine("Update a shape\n" +
                "\n" +
                "Enter the shape id:");
            return "Update a shape";
        }

        public static string UpdateShapeType()
        {
            Console.Clear();
            Console.WriteLine("Update a shape\n" +
                "\n" +
                "Enter the shape type:");
            return "Update a shape";
        }

        private static string StringInputFromConsole()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (input != null)
                {
                    return input;
                }
            }
        }

        private static int IntegerInputFromConsole()
        {
            while (true)
            {
                try
                {
                    string? input = Console.ReadLine();
                    return Convert.ToInt32(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        private static int BoundedIntegerInputFromConsole(int min, int max)
        {
            int intInput;
            bool showError = false;
            do
            {
                if (showError)
                {
                    Console.WriteLine("Input out of bounds. Please enter a number between " + min + " and " + max);
                }

                intInput = IntegerInputFromConsole();
                showError = true;
            }
            while (intInput < min || intInput > max);

            return intInput;
        }
    }
}
