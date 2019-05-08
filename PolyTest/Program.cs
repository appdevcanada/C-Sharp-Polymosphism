﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Program.cs
//
// summary:	Implements the program class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolymorphismDrawingApp
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A program. </summary>
    ///
    /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static class Program
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The main entry point for the application. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
