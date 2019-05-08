////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	rectangleshape.cs
//
// summary:	Implements the rectangleshape class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismDrawingApp
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A rectangle shape. </summary>
    ///
    /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class RectangleShape : Shape // RectangleShape "is a" type of Shape
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RectangleShape()
        {
           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="graphics"> The graphics object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void Draw(Graphics graphics)
        {
            formGraphics = graphics;

            Rectangle rectangle = new Rectangle(Math.Min((Convert.ToInt32( startPoint.X)), Convert.ToInt32(endPoint.X)),
                                         Math.Min(Convert.ToInt32(startPoint.Y), Convert.ToInt32(endPoint.Y)),
                                         Math.Abs(Convert.ToInt32(endPoint.X) - Convert.ToInt32(startPoint.X)),
                                         Math.Abs(Convert.ToInt32(endPoint.Y) - Convert.ToInt32(startPoint.Y)));

            formGraphics.FillRectangle(brush, rectangle);
        }
    }
}
