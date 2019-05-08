//  Name: Luis Souza
// Date: 2019-04-04

////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Shape.cs
//
// summary:	Implements the shape class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolymorphismDrawingApp
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A shape. </summary>
    ///
    /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    abstract class Shape // a abstract base class
    {
        /// <summary>   The brush. </summary>
        protected System.Drawing.SolidBrush brush;
        /// <summary>   The pen. </summary>
        protected System.Drawing.Pen pen;
        /// <summary>   The font. </summary>
        protected Font font;
   
        /// <summary>   The graphics object. </summary>
        protected Graphics formGraphics;

        /// <summary>   The start point. </summary>
        protected Point startPoint;
        /// <summary>   The end point. </summary>
        protected Point endPoint;

        /// <summary>   The text. </summary>
        protected string text;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Shape()
        {
            brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            pen = new System.Drawing.Pen(System.Drawing.Color.Black);
            font = new System.Drawing.Font("Arial", 16); // using a known default font
            text = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Finaliser. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ~Shape() // we are responsible for cleaning up these graphic items
        {
            brush.Dispose();
            pen.Dispose();
            formGraphics.Dispose();
            font.Dispose();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Draws to the given graphics device.
        /// </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="graphics"> The graphics object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public virtual void Draw(Graphics graphics) // the concept of drawing an undefined shape is abstract 
        //{

        //}

        public abstract void Draw(Graphics graphics); // the concept of drawing an undefined shape is abstract 

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets start point. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="point">    The point. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetStartPoint(Point point)
        {
            startPoint = point;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets end point. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="point">    The point. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetEndPoint(Point point)
        {
            endPoint = point;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets pen colour. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="colour">   The colour. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetPenColour(Color colour)
        {
            pen.Color = colour;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets brush colour. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="colour">   The colour. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetBrushColour(Color colour)
        {
            brush.Color = colour;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a font. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="font"> The font. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetFont(Font font)
        {
            this.font = font;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a text. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetText(string text)
        {
            this.text = text;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets pen colour. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <returns>   The pen colour. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Color GetPenColour() { return pen.Color; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets brush colour. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <returns>   The brush colour. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Color GetBrushColour() { return brush.Color; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets start point. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <returns>   The start point. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Point GetStartPoint() { return startPoint; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets end point. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <returns>   The end point. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Point GetEndPoint() { return endPoint; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the text. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <returns>   The text. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetText() { return text; }
    }
}

// Brief description:
// Amazing experience, and before starting seent to be so difficult
// and after your explanation looked so clear and obvious.
// Polymorphism is something fast to develop and also for running.
// Besides, it uses main feature to reuse code and gain performance, 
// memory, and cleanliness of code.

// Commenting:
// Virtual is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class.
// Override is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.
// Abstract in a class indicates that a class is intended only to be a base class of other classes. Members marked as abstract, or included
//    in an abstract class, must be implemented by classes that derive from the abstract class.
// Abstract in a method indicates that the method or property does not contain implementation.
// A base class is a class that is used to create, or derive, other classes. Classes derived from a base class are called child classes, 
//    subclasses or derived classes. A base class does not inherit from any other class and is considered parent of a derived class.
///////////////