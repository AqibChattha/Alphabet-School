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
            int mainMenuInput = 0;
            do
            {
                mainMenuInput = Views.MainMenu;
                int shapeMenuInput;
                int letterMenuInput;

                switch (mainMenuInput)
                {
                    case 1:
                        do
                        {
                            shapeMenuInput = Views.ShapesMenu;
                        }
                        while (shapeMenuInput > 0 && shapeMenuInput < 6);
                        break;

                    case 2:
                        do
                        {
                            letterMenuInput = Views.LetterMenu;
                        }
                        while (letterMenuInput > 0 && letterMenuInput < 6);
                        break;

                    default:
                        break;
                }
            }
            while (mainMenuInput > 0 && mainMenuInput < 3);
        }
    }
}