using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphabet_School.Models
{

    /// <summary>
    /// Interface for the letter model.
    /// </summary>
    public interface ILetterModel
    {
        /// <summary>
        /// Gets or sets the character representing the letter name.
        /// </summary>
        public char Name { get; set; }

        /// <summary>
        /// Gets or sets the list of shapes that are used to create the letter.
        /// </summary>
        public List<IShapeModel> Shapes { get; set; }
    }
}
