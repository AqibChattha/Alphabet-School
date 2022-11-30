// <copyright file="UndoCommands.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Alphabet_School.Models.Enums
{
    /// <summary>
    /// This enum is used to define the types of undo commands.
    /// </summary>
    public enum UndoCommandEnum
    {
        /// <summary>
        /// When an object is added to the control list.
        /// </summary>
        Add = 1,

        /// <summary>
        /// When an object fields are changed.
        /// </summary>
        Update = 2,

        /// <summary>
        /// When an object is deleted.
        /// </summary>
        Delete = 3,

        /// <summary>
        /// When all the objects in the control list are deleted.
        /// </summary>
        DeleteAll = 4,
    }
}
