// <copyright file="ShapeHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Handlers
{
    using Alphabet_School.Models;
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// This class handles the shape of the letter. It can be used to create, update and delete shapes.
    /// </summary>
    public class ShapeHandler
    {
        /// <summary>
        /// List of shapes. This list is used to store all the shapes that are not assigned.
        /// </summary>
        private List<Shape> shapes;

        // List of letters. Used to store that are changed.
        private List<Shape> undoShapes;

        // The recently excecuted letter command, that can be undone.
        private UndoCommandEnum undoCommand;

        // Used to undo the update command.
        private int undoIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeHandler"/> class.
        /// </summary>
        public ShapeHandler()
        {
            // Initialize the list of shapes.
            this.shapes = new List<Shape>();
            this.shapes.Add(new Shape(ShapeTypeEnum.BigLine, ColorsEnum.Blue, TexturesEnum.Sand));
            this.shapes.Add(new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Red, TexturesEnum.Dotted));
            this.shapes.Add(new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Orange, TexturesEnum.Solid));
            this.shapes.Add(new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Green, TexturesEnum.Sand));
            this.shapes.Add(new Shape(ShapeTypeEnum.SmallLine, ColorsEnum.Red, TexturesEnum.Dotted));
            this.shapes.Add(new Shape(ShapeTypeEnum.SmallCurve, ColorsEnum.Blue, TexturesEnum.Sand));
            this.shapes.Add(new Shape(ShapeTypeEnum.SmallCurve, ColorsEnum.Blue, TexturesEnum.Solid));
            this.shapes.Add(new Shape(ShapeTypeEnum.BigLine, ColorsEnum.Green, TexturesEnum.Solid));
            this.shapes.Add(new Shape(ShapeTypeEnum.BigLine, ColorsEnum.Orange, TexturesEnum.Dotted));
            this.shapes.Add(new Shape(ShapeTypeEnum.BigCurve, ColorsEnum.Red, TexturesEnum.Sand));
            this.shapes.Add(new Shape(ShapeTypeEnum.BigCurve, ColorsEnum.Blue, TexturesEnum.Dotted));

            // Initialize the list of shapes that are changed.
            this.undoShapes = new List<Shape>();

            // At start there is nothing to undo
            this.undoCommand = 0;

            this.undoIndex = -1;
        }

        /// <summary>
        /// This method is used to create a shape.
        /// </summary>
        /// <param name="strColor">Color name of string data type.</param>
        /// <param name="strTexture">Texture name of string data type.</param>
        /// <param name="strType">Shape type name of string data type.</param>
        /// <returns>True, if the shape is created. Otherwise false.</returns>
        public bool CreateShape(string strColor, string strTexture, string strType)
        {
            ColorsEnum colorsEnum;
            TexturesEnum texturesEnum;
            ShapeTypeEnum shapeTypeEnum;

            if (Enum.TryParse(strColor, out colorsEnum) && Enum.TryParse(strTexture, out texturesEnum) && Enum.TryParse(strType, out shapeTypeEnum))
            {
                // Create a new shape.
                Shape shape = new Shape(shapeTypeEnum, colorsEnum, texturesEnum);

                // Add the shape to the list of shapes.
                this.shapes.Add(shape);

                // Add the shape to the list of shapes that are changed.
                this.undoShapes.Add(shape);

                // Set the recently excecuted command to create.
                this.undoCommand = UndoCommandEnum.Add;

                // Return the created shape.
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method is used to update a shape.
        /// </summary>
        /// <param name="id">The id of the shape in the list.</param>
        /// <param name="strColor">The new color of the shape.</param>
        /// <param name="strTexture">The new texture of the shape.</param>
        /// <param name="strType">The new type of the shape.</param>
        /// <returns>True if the shape was updated, otherwise false.</returns>
        public bool UpdateShape(int id, string strColor, string strTexture, string strType)
        {
            ColorsEnum colorsEnum;
            TexturesEnum texturesEnum;
            ShapeTypeEnum shapeTypeEnum;

            if (id >= 1 && id < this.shapes.Count && Enum.TryParse(strColor, out colorsEnum) && Enum.TryParse(strTexture, out texturesEnum) && Enum.TryParse(strType, out shapeTypeEnum))
            {
                // Get the shape from the list of shapes.
                Shape shape = this.shapes[id - 1];

                // Update the color of the shape.
                shape.Color = colorsEnum;

                // Update the texture of the shape.
                shape.Texture = texturesEnum;

                // Update the type of the shape.
                shape.Type = shapeTypeEnum;

                // Add the shape to the list of shapes that are changed.
                this.undoShapes.Add(shape);

                // Set the undo index to the index of shape that is changed.
                this.undoIndex = id - 1;

                // Set the recently excecuted command to update.
                this.undoCommand = UndoCommandEnum.Update;
            }

            // false if no shape was found.
            return false;
        }

        /// <summary>
        /// This method is used to delete all the user shapes.
        /// </summary>
        public void DeleteAllShapes()
        {
            // Save all the shapes because they are changed.
            this.undoShapes = this.shapes;

            // Set the recently excecuted command to delete.
            this.undoCommand = UndoCommandEnum.DeleteAll;

            // Clear the list of shapes.
            this.shapes = new List<Shape>();
        }

        /// <summary>
        /// This method is used to get a shape by its id.
        /// </summary>
        /// <param name="id">The id of the shape.</param>
        /// <returns>True if the shape is deleted, otherwise false.</returns>
        public bool DeleteShape(int id)
        {
            // Check if the id is valid.
            if (id < this.shapes.Count && id >= 1)
            {
                // Store the shape that is being deleted.
                this.undoShapes.Add(this.shapes[id - 1]);

                // Set the recently excecuted command to delete.
                this.undoCommand = UndoCommandEnum.Delete;

                // Remove the shape from the list of shapes.
                this.shapes.RemoveAt(id - 1);
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method will match the shape with the given list of shapes and removes them from the user's shape list.
        /// </summary>
        /// <param name="matchShapes">The sample of shape types to be matched.</param>
        /// <returns>List of shapes removed from user's shape list, if the shapes match. Null if the shapes don't match.</returns>
        public List<Shape>? RemoveMatchingShapes(List<Shape> matchShapes)
        {
            // List of shapes that are removed.
            List<Shape> shapesToRemove = new List<Shape>();

            for (int j = 0; j < matchShapes.Count; j++)
            {
                // If the shape is found in the list of shapes.
                bool isAdded = false;
                for (int i = 0; i < this.shapes.Count; i++)
                {
                    // remove the matching shapes from the user's shape list and add them to the list of shapes to be removed.
                    if (matchShapes[j].Type == this.shapes[i].Type && isAdded == false)
                    {
                        shapesToRemove.Add(this.shapes[i]);
                        this.shapes.Remove(this.shapes[i]);

                        // Set to true so that the shape is not added again.
                        isAdded = true;

                        // Break the loop.
                        break;
                    }
                }
            }

            // Check if the shapes removed are equal to the shapes to be given for matching.
            if (shapesToRemove.Count != matchShapes.Count)
            {
                // If the shapes are not equal, retain all the shapes removed and return null.
                foreach (Shape retainShape in shapesToRemove)
                {
                    this.shapes.Add(retainShape);
                }

                return null;
            }

            return shapesToRemove;
        }

        /// <summary>
        /// This method is used to get the list of shapes.
        /// </summary>
        /// <returns>The list of shapes.</returns>
        public List<Shape> GetShapes()
        {
            // Return the list of shapes.
            return this.shapes;
        }

        /// <summary>
        /// This method is used to get shape by their color.
        /// </summary>
        /// <param name="strColor">The color of the shapes.</param>
        /// <returns>The shapes with the given color.</returns>
        public List<Shape> GetShapeByColor(string strColor)
        {
            // parse the color.
            ColorsEnum colorsEnum = Enum.TryParse(strColor, out colorsEnum) ? colorsEnum : 0;

            if (colorsEnum != 0)
            {
                // Return the list of shapes with the given color.
                return this.shapes.Where(shape => shape.Color == colorsEnum).ToList();
            }

            // return an empty list if the color is not valid.
            return new ();
        }

        /// <summary>
        /// This method is used to get shapes by their texture.
        /// </summary>
        /// <param name="strTexture">The texture of the shapes.</param>
        /// <returns>The shapes with the given texture.</returns>
        public List<Shape> GetShapesByTexture(string strTexture)
        {
            // parse the color.
            TexturesEnum textureEnum = Enum.TryParse(strTexture, out textureEnum) ? textureEnum : 0;

            if (textureEnum != 0)
            {
                // Return the list of shapes with the given color.
                return this.shapes.Where(shape => shape.Texture == textureEnum).ToList();
            }

            // return an empty list if the texture is not valid.
            return new ();
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
                this.shapes.Remove(this.undoShapes[0]);
            }
            else if (this.undoCommand == UndoCommandEnum.Update)
            {
                this.shapes[this.undoIndex] = this.undoShapes[0];
            }
            else if (this.undoCommand == UndoCommandEnum.Delete)
            {
                this.shapes.Add(this.undoShapes[0]);
            }
            else if (this.undoCommand == UndoCommandEnum.DeleteAll)
            {
                this.shapes = this.undoShapes;
                this.undoShapes = new List<Shape>();
            }

            // Reset the fields and return the command number.
            int commandNumber = (int)this.undoCommand;
            this.undoCommand = 0;
            this.undoShapes.Clear();
            return commandNumber;
        }
    }
}
