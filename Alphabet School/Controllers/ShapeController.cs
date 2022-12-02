// <copyright file="ShapeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Controllers
{
    using Alphabet_School.Models;
    using Alphabet_School.Models.Enums;

    /// <summary>
    /// This class handles the shape of the letter. It can be used to create, update and delete shapes.
    /// </summary>
    public class ShapeController : IShapeController
    {
        /// <summary>
        /// List of shapes. This list is used to store all the shapes that are not assigned.
        /// </summary>
        private List<IShapeModel> shapes;

        /// <summary>
        /// List of letters. Used to store that are changed.
        /// </summary>
        private List<IShapeModel> undoShapes;

        /// <summary>
        /// The recently excecuted letter command, that can be undone.
        /// </summary>
        private UndoCommandEnum undoCommand;

        /// <summary>
        /// Used by the undo command to locate the index in shapes list.
        /// </summary>
        private int undoIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeController"/> class.
        /// </summary>
        public ShapeController()
        {
            // Initialize the list of shapes.
            this.shapes = new List<IShapeModel>();

            // Initialize the list of shapes that are changed.
            this.undoShapes = new List<IShapeModel>();

            // At start there is nothing to undo
            this.undoCommand = 0;

            this.undoIndex = -1;
        }

        /// <inheritdoc/>
        public List<IShapeModel> Shapes => this.shapes;

        /// <inheritdoc/>
        public bool CreateShape(string strType, string strColor, string strTexture)
        {
            ColorsEnum colorsEnum;
            TexturesEnum texturesEnum;
            ShapeTypeEnum shapeTypeEnum;

            if (Enum.TryParse(strColor, out colorsEnum) && Enum.TryParse(strTexture, out texturesEnum) && Enum.TryParse(strType, out shapeTypeEnum))
            {
                // Create a new shape.
                IShapeModel shape = new ShapeModel(shapeTypeEnum, colorsEnum, texturesEnum);

                // Add the shape to the list of shapes.
                this.shapes.Add(shape);

                // Add the shape to the list of shapes that are changed.
                this.undoShapes.Add(shape);

                // Set the recently excecuted command to create.
                this.undoCommand = UndoCommandEnum.Add;
                this.undoIndex = this.shapes.Count - 1;

                // Return the created shape.
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool UpdateShape(int id, string strType, string strColor, string strTexture)
        {
            ColorsEnum colorsEnum;
            TexturesEnum texturesEnum;
            ShapeTypeEnum shapeTypeEnum;

            if (id >= 1 && id <= this.shapes.Count && Enum.TryParse(strColor, out colorsEnum) && Enum.TryParse(strTexture, out texturesEnum) && Enum.TryParse(strType, out shapeTypeEnum))
            {
                // Get the shape from the list of shapes.
                IShapeModel shape = this.shapes[id - 1];

                // Add the shape to the list of shapes that are changed.
                this.undoShapes.Add(new ShapeModel(shape.Type, shape.Color, shape.Texture));

                // Update the color of the shape.
                shape.Color = colorsEnum;

                // Update the texture of the shape.
                shape.Texture = texturesEnum;

                // Update the type of the shape.
                shape.Type = shapeTypeEnum;

                // Set the undo index to the index of shape that is changed.
                this.undoIndex = id - 1;

                // Set the recently excecuted command to update.
                this.undoCommand = UndoCommandEnum.Update;

                return true;
            }

            // false if no shape was found.
            return false;
        }

        /// <inheritdoc/>
        public void DeleteAllShapes()
        {
            // Save all the shapes because they are changed.
            this.undoShapes = this.shapes;

            // Set the recently excecuted command to delete.
            this.undoCommand = UndoCommandEnum.DeleteAll;

            // Clear the list of shapes.
            this.shapes = new List<IShapeModel>();
        }

        /// <inheritdoc/>
        public bool DeleteShape(int id)
        {
            // Check if the id is valid.
            if (id <= this.shapes.Count && id >= 1)
            {
                // Store the shape that is being deleted.
                this.undoShapes.Add(this.shapes[id - 1]);

                // Set the recently excecuted command to delete.
                this.undoCommand = UndoCommandEnum.Delete;
                this.undoIndex = id - 1;

                // Remove the shape from the list of shapes.
                this.shapes.RemoveAt(id - 1);
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public List<IShapeModel>? RemoveMatchingShapes(List<IShapeModel> matchShapes)
        {
            // List of shapes that are removed.
            List<IShapeModel> shapesToRemove = new List<IShapeModel>();

            if (matchShapes != null)
            {
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
                    foreach (IShapeModel retainShape in shapesToRemove)
                    {
                        this.shapes.Add(retainShape);
                    }

                    return null;
                }

                return shapesToRemove;
            }

            return null;
        }

        /// <inheritdoc/>
        public List<IShapeModel> GetShapeByColor(string strColor)
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

        /// <inheritdoc/>
        public List<IShapeModel> GetShapesByTexture(string strTexture)
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

        /// <inheritdoc/>
        public int UndoCommand()
        {
            if (this.undoCommand == 0)
            {
                return (int)this.undoCommand;
            }
            else if (this.undoCommand == UndoCommandEnum.Add)
            {
                this.shapes.Remove(this.undoShapes[this.undoIndex]);
            }
            else if (this.undoCommand == UndoCommandEnum.Update)
            {
                this.shapes[this.undoIndex] = this.undoShapes[0];
            }
            else if (this.undoCommand == UndoCommandEnum.Delete)
            {
                this.shapes.Insert(this.undoIndex, this.undoShapes[0]);
            }
            else if (this.undoCommand == UndoCommandEnum.DeleteAll)
            {
                this.shapes = this.undoShapes;
                this.undoShapes = new List<IShapeModel>();
            }

            // Reset the fields and return the command number.
            int commandNumber = (int)this.undoCommand;
            this.undoCommand = 0;
            this.undoIndex = -1;
            this.undoShapes.Clear();
            return commandNumber;
        }
    }
}
