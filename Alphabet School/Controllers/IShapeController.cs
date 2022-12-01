// <copyright file="IShapeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Controllers
{
    using Alphabet_School.Models;

    /// <summary>
    /// Interface for the shape controller.
    /// </summary>
    public interface IShapeController
    {
        /// <summary>
        /// This method is used to create a shape.
        /// </summary>
        /// <param name="strColor">Color name of string data type.</param>
        /// <param name="strTexture">Texture name of string data type.</param>
        /// <param name="strType">Shape type name of string data type.</param>
        /// <returns>True, if the shape is created. Otherwise false.</returns>
        public bool CreateShape(string strColor, string strTexture, string strType);

        /// <summary>
        /// This method is used to update a shape.
        /// </summary>
        /// <param name="id">The id of the shape in the list.</param>
        /// <param name="strColor">The new color of the shape.</param>
        /// <param name="strTexture">The new texture of the shape.</param>
        /// <param name="strType">The new type of the shape.</param>
        /// <returns>True if the shape was updated, otherwise false.</returns>
        public bool UpdateShape(int id, string strColor, string strTexture, string strType);

        /// <summary>
        /// This method is used to delete all the user shapes.
        /// </summary>
        public void DeleteAllShapes();

        /// <summary>
        /// This method is used to get a shape by its id.
        /// </summary>
        /// <param name="id">The id of the shape.</param>
        /// <returns>True if the shape is deleted, otherwise false.</returns>
        public bool DeleteShape(int id);

        /// <summary>
        /// This method will match the shape with the given list of shapes and removes them from the user's shape list.
        /// </summary>
        /// <param name="matchShapes">The sample of shape types to be matched.</param>
        /// <returns>List of shapes removed from user's shape list, if the shapes match. Null if the shapes don't match.</returns>
        public List<IShapeModel>? RemoveMatchingShapes(List<IShapeModel> matchShapes);

        /// <summary>
        /// This method is used to get the list of shapes.
        /// </summary>
        /// <returns>The list of shapes.</returns>
        public List<IShapeModel> GetShapes();

        /// <summary>
        /// This method is used to get shape by their color.
        /// </summary>
        /// <param name="strColor">The color of the shapes.</param>
        /// <returns>The shapes with the given color.</returns>
        public List<IShapeModel> GetShapeByColor(string strColor);

        /// <summary>
        /// This method is used to get shapes by their texture.
        /// </summary>
        /// <param name="strTexture">The texture of the shapes.</param>
        /// <returns>The shapes with the given texture.</returns>
        public List<IShapeModel> GetShapesByTexture(string strTexture);

        /// <summary>
        /// This method will undo the last action if there is any.
        /// </summary>
        /// <returns>The command number that is undone. 0 if there are no prior commands.</returns>
        public int UndoCommand();
    }
}
