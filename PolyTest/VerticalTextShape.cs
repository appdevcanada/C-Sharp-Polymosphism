﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	VerticalTextShape.cs
//
// summary:	Implements the vertical text shape class
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
    /// <summary>   A vertical text shape. </summary>
    ///
    /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class VerticalTextShape : Shape
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public VerticalTextShape()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> The Draw method. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="graphics"> The graphics object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void Draw(Graphics graphics)
        {
            formGraphics = graphics;

            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            formGraphics.DrawString(text, font, brush, startPoint.X, startPoint.Y, drawFormat);
        }
    }
}