////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Form1.cs
//
// summary:	Implements the form 1 class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolymorphismDrawingApp
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent shape types. </summary>
    ///
    /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    enum ShapeTypes
    {
        /// <summary>   An enum constant representing the line option. </summary>
        Line,
        /// <summary>   An enum constant representing the rectangle option. </summary>
        Rectangle,
        /// <summary>   An enum constant representing the ellipse option. </summary>
        Ellipse,
        /// <summary>   An enum constant representing the outlined rectangle option. </summary>
        OutlinedRectangle,
        /// <summary>   An enum constant representing the outlined ellipse option. </summary>
        OutlinedEllipse,
        /// <summary>   An enum constant representing the horizontal text option. </summary>
        HorizontalText,
        /// <summary>   An enum constant representing the vertical text option. </summary>
        VerticalText
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A form 1. </summary>
    ///
    /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Form1 : Form
    {
        #region Fields

        /// <summary>   The shapes. </summary>
        private List<Shape> shapes;
        
        /// <summary>   Type of the current shape. </summary>
        private ShapeTypes currentShapeType;
     
        /// <summary>   The new shape. </summary>
        private Shape newShape;
       
        /// <summary>   The current pen colour. </summary>
        private Color currentPenColour;
        /// <summary>   The current brush colour. </summary>
        private Color currentBrushColour;
       
        /// <summary>   List of colours of the customs. </summary>
        private int[] customColours;
       
        /// <summary>   The font. </summary>
        private Font font;
      
        /// <summary>   The current text. </summary>
        private string currentText;

        /// <summary>   true to drawing. </summary>
        private bool drawing;

        #endregion

        #region Construction and Destruction/Finalizer

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            DoubleBuffered = true;

            InitializeComponent();

            drawing = false;

            shapes = new List<Shape>();

            currentShapeType = ShapeTypes.Line;
            lineToolStripMenuItem.Checked = true;

            currentPenColour = Color.Black;
            currentBrushColour = Color.Blue;

            customColours = new int[16];

            font = new Font("Arial", 16); // default to known font 

            currentText = "Set Text";
        }

         ////////////////////////////////////////////////////////////////////////////////////////////////////
         /// <summary>  Finaliser. </summary>
         ///
         /// <remarks>  Tony Davidson, 2018-03-28. </remarks>
         ////////////////////////////////////////////////////////////////////////////////////////////////////

         ~Form1()
        {
            font.Dispose(); 
        }

        #endregion

        #region Paint/Draw

         ////////////////////////////////////////////////////////////////////////////////////////////////////
         /// <summary>  Event handler. Called by Form1 for paint events. </summary>
         ///
         /// <remarks>  Tony Davidson, 2018-03-28. </remarks>
         ///
         /// <param name="sender">  Source of the event. </param>
         /// <param name="e">       Paint event information. </param>
         ////////////////////////////////////////////////////////////////////////////////////////////////////

         private void Form1_Paint(object sender, PaintEventArgs e)
         {
             foreach (Shape s in shapes)
             {
                     s.Draw(e.Graphics);
             }

             if (drawing)
             {
                newShape.Draw(e.Graphics);
            }
        }

#endregion

        #region Mouse Events

         ////////////////////////////////////////////////////////////////////////////////////////////////////
         /// <summary>  Event handler. Called by Form1 for mouse move events. </summary>
         ///
         /// <remarks>  Tony Davidson, 2018-03-28. </remarks>
         ///
         /// <param name="sender">  Source of the event. </param>
         /// <param name="e">       Mouse event information. </param>
         ////////////////////////////////////////////////////////////////////////////////////////////////////

         private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            string title = string.Format("X: {0}  Y: {1}", e.X , e.Y);
            this.Text = title;
            if(drawing)
            {
                newShape.SetEndPoint(e.Location);

                this.Refresh();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Form1 for mouse down events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawing = true;

                switch(currentShapeType)
                {
                    case ShapeTypes.Line:
                    default:
                    newShape = new LineShape();
                    break;

                    case ShapeTypes.Rectangle:
                    newShape = new RectangleShape();
                    break;

                    case ShapeTypes.Ellipse:
                    newShape = new EllipseShape();
                    break;

                    case ShapeTypes.OutlinedRectangle:
                    newShape = new OutlinedRectangleShape();
                    break;

                    case ShapeTypes.OutlinedEllipse:
                    newShape = new OutlinedEllipseShape();
                    break;

                    case ShapeTypes.HorizontalText:
                    newShape = new TextShape();
                    break;

                    case ShapeTypes.VerticalText:
                    newShape = new VerticalTextShape();
                    break;

                }
                newShape.SetPenColour(currentPenColour);
                newShape.SetBrushColour(currentBrushColour);
                newShape.SetFont(font);
                newShape.SetText(currentText);
                newShape.SetStartPoint( e.Location);
                newShape.SetEndPoint(e.Location);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Form1 for mouse up events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawing = false;

                shapes.Add(newShape);

                this.Refresh();
            }
        }

        #endregion

        #region Menu Items

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by exitToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Quit?", "Annoying Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clears the menu item checks. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ClearMenuItemChecks()
        {
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            outlinedRectangleToolStripMenuItem.Checked = false;
            outlinedEllipseToolStripMenuItem.Checked = false;
            horizontalTextToolStripMenuItem.Checked = false;
            verticalTextToolStripMenuItem.Checked = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by lineToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemChecks();
            lineToolStripMenuItem.Checked = true;
            currentShapeType = ShapeTypes.Line;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by rectangleToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemChecks();
            rectangleToolStripMenuItem.Checked = true;
            currentShapeType = ShapeTypes.Rectangle;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by ellipseToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemChecks();
            ellipseToolStripMenuItem.Checked = true;
            currentShapeType = ShapeTypes.Ellipse;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by undoToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(shapes.Count != 0)
            {
                shapes.RemoveAt(shapes.Count - 1);
                this.Refresh();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by aboutToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Polymorphism is amazing!!!", "About Polymorphism Drawing App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by penToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseColour(ref currentPenColour);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by brushToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void brushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseColour(ref currentBrushColour);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by outlinedRectangleToolStripMenuItem for click events.
        /// </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void outlinedRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemChecks();
            outlinedRectangleToolStripMenuItem.Checked = true;
            currentShapeType = ShapeTypes.OutlinedRectangle;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by outlinedEllipseToolStripMenuItem for click events.
        /// </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void outlinedEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemChecks();
            outlinedEllipseToolStripMenuItem.Checked = true;
            currentShapeType = ShapeTypes.OutlinedEllipse;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by horizontalTextToolStripMenuItem for click events.
        /// </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void horizontalTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemChecks();
            horizontalTextToolStripMenuItem.Checked = true;
            currentShapeType = ShapeTypes.HorizontalText;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by verticalTextToolStripMenuItem for click events.
        /// </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void verticalTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemChecks();
            verticalTextToolStripMenuItem.Checked = true;
            currentShapeType = ShapeTypes.VerticalText;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by eraseAllToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void eraseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Erase All Shapes?", "Confirm Erase", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                shapes.Clear();
                this.Refresh();
            }
        }

        #endregion

        #region Dialog Windows

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Choose colour. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="colour">   [in,out] The colour. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ChooseColour(ref Color colour)
        {
            ColorDialog ColourPickerDialog = new ColorDialog();

            ColourPickerDialog.AllowFullOpen = true;

            ColourPickerDialog.FullOpen = true;

            ColourPickerDialog.AnyColor = true;

            ColourPickerDialog.CustomColors = customColours;

            ColourPickerDialog.ShowHelp = true;

            ColourPickerDialog.Color = colour;

            if (ColourPickerDialog.ShowDialog() == DialogResult.OK)
            {
                colour = ColourPickerDialog.Color;
                customColours = ColourPickerDialog.CustomColors;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by fontToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            fontDialog.Font = font;

            fontDialog.ShowEffects = true;

            fontDialog.Color = currentBrushColour;

            fontDialog.ShowColor = true;

            fontDialog.ShowApply = true;

            DialogResult result = fontDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                font = fontDialog.Font;
                currentBrushColour = fontDialog.Color;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by setTextToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void setTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox.Show("New text string", "Enter Text:", ref currentText); // should return DialogResult.OK
        }

        #endregion

    }
}
