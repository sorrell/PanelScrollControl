/**
 * PanelScrollControl
 * 
 * The MIT License (MIT)
 * Copyright (c) 2015, Cintio Ltd. - http://cint.io |  Nick Sorrell - https://github.com/sorrell
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in the 
 * Software without restriction, including without limitation the rights to use, copy, 
 * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
 * and to permit persons to whom the Software is furnished to do so, subject to the 
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
 * CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
 * OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cintio.PanelScrollControl
{
    /// <summary>
    ///  This is just a user control with two buttons and a panel sandwiched between.
    ///  The buttons have been created, you provide the panel!
    /// </summary>
    /// 
    /// PanelScrollControl
    ///      --------------------
    ///     |         ^          |
    ///      --------------------
    ///     |                    |
    ///     |                    |
    ///     |       Panel        |
    ///     |                    |
    ///      --------------------
    ///     |         v          |
    ///      --------------------
    /// 
    [ToolboxBitmap(typeof(Panel))]
    public partial class PanelScrollControl : UserControl
    {
        protected bool _hovering = false;
        private Panel _panelContainer;
        protected enum ScollValue { UP = -1, DOWN = 1 };
        protected int ScrollSpeed { get; set; }
        protected Control TopControl { get; set; }
        protected Control BottomControl { get; set; }
        protected int TopHeightMargin { get; set; }
        protected int BottomHeightMargin { get; set; }

        public PanelScrollControl()
        {
            InitializeComponent();
            _btnScrollUp.Visible = false;
            _btnScrollDown.Visible = false;
        }
        
        /// <summary>
        ///     The PanelContainer is the main panel that is sandwiched between two scrollable
        ///     buttons.  So remember to set this after you inherit/create this control!
        /// </summary>
        protected Panel PanelContainer
        {
            get { return _panelContainer; }
            set {
                _panelContainer = value;
                _panelContainer.VerticalScroll.Visible = false;
                _panelContainer.HorizontalScroll.Visible = false;
                _panelContainer.VerticalScroll.Minimum = 0;
                _panelContainer.VerticalScroll.Maximum = _panelContainer.Height - 10;
                _panelContainer.AutoScrollPosition = new Point(0, 0);
                _panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this._panelContainer_Paint);
            }
        }

        /// <summary>
        ///  This helper provides a sane (positive) value when seeking the Y position of the PanelContainer
        /// </summary>
        /// <returns>Y value of PanelContainer</returns>
        protected int GetVerticalScrollPosition()
        {
            return (PanelContainer.AutoScrollPosition.Y * (-1));
        }
        protected virtual void DoScroll(ScollValue s)
        {
            _hovering = true;
            while (_hovering)
            {
                // DoEvents handles a MouseLeave event...
                Application.DoEvents();
                // Adjust the Y value: s is positive if scrolling down, negative if scrolling up
                PanelContainer.AutoScrollPosition = new Point(0, GetVerticalScrollPosition() + (ScrollSpeed * (int)s));
                // If we're out of real estate, toggle the buttons
                ToggleButtons();
            }
        }

        protected virtual void StopScroll()
        {
            _hovering = false;
        }

        /// <summary>
        ///  This really comes into play when you have resizable/collapsible elements at the bottom of your panel.
        ///  You will want to check if they are expanded/collapsed, and act accordingly in the ToggleButtons method.
        /// </summary>
        /// <returns>bool</returns>
        protected virtual bool BottomPredicateCheck()
        {
            // Could be something like
            // return panelResultsComponents.Visible;
            return true;
        }

        /// <summary>
        ///  Checking conditions at the top of your panel.
        /// </summary>
        /// <returns>bool</returns>
        protected virtual bool TopPredicateCheck()
        {
            return true;
        }

        /// <summary>
        ///  You must implement this.  The standard implementation (1) doesn't consider any collapsible/expandable
        ///  elements.  However, the modified implementation (2) does, and shows/hides the bottom button accordingly.
        /// </summary>
        protected virtual void ToggleButtons()
        {
            if (!this.DesignMode)
                throw new NotImplementedException();

            // 1. Standard implementation
            //var topPosition = PointToClient(TopControl.PointToScreen(Point.Empty));
            //_btnScrollUp.Visible = (GetVerticalScrollPosition() > 1);

            //var bottomPosition = PointToClient(BottomControl.PointToScreen(Point.Empty));
            //_btnScrollDown.Visible = ((bottomPosition.Y - GetVerticalScrollPosition()) > _panelContainer.ClientSize.Height);

            // 2. Modified implementation
            // Need finer grained control?  Reset the BottomControl here if you have areas that expand/collapse
            //BottomControl = BottomPredicateCheck() ? (Control)progressBar : BottomControl;
            //_btnScrollDown.Visible = BottomPredicateCheck() ?
            //                        ((bottomPosition.Y + BottomControl.Height) > _panelContainer.ClientSize.Height) :
            //                        ((bottomPosition.Y - GetVerticalScrollPosition()) > _panelContainer.ClientSize.Height);
        }

        protected virtual void _btnScrollUp_MouseHover(object sender, EventArgs e)
        {
            DoScroll(ScollValue.UP);
        }

        protected virtual void _btnScrollDown_MouseHover(object sender, EventArgs e)
        {
            DoScroll(ScollValue.DOWN);
        }

        protected virtual void _btnScrollDown_MouseLeave(object sender, EventArgs e)
        {
            StopScroll();
        }

        protected virtual void _btnScrollUp_MouseLeave(object sender, EventArgs e)
        {
            StopScroll();
        }

        protected virtual void _panelContainer_Paint(object sender, PaintEventArgs e)
        {
            ToggleButtons();
        }

    }
}
