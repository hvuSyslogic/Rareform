﻿using FlagLib.Console.Drawing;
using FlagLib.Measure;

namespace FlagLib.Console.Controls
{
    /// <summary>
    /// Base class for all controls
    /// </summary>
    public abstract class Control
    {
        #region Members

        private bool isVisible = true;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets or sets the parent control.
        /// </summary>
        /// <value>The parent control.</value>
        public virtual Control Parent { get; set; }

        /// <summary>
        /// Gets the top control (the screen).
        /// </summary>
        /// <value>The top control.</value>
        public virtual Control Top
        {
            get { return this.Parent.Top; }
        }

        /// <summary>
        /// Gets or sets the relative position to the parent container.
        /// </summary>
        /// <value>The relative position to the parent container.</value>
        public virtual Position RelativePosition { get; set; }

        /// <summary>
        /// Gets the absolute position to the console.
        /// </summary>
        /// <value>The absolute position to the console.</value>
        public virtual Position AbsolutePosition
        {
            get { return this.RelativePosition + this.Parent.AbsolutePosition; }
        }

        /// <summary>
        /// Gets or sets the size of the control.
        /// </summary>
        /// <value>The size of the control.</value>
        public virtual Size Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Control"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public virtual bool IsVisible
        {
            get { return this.isVisible; }

            set
            {
                this.isVisible = value;

                if (isVisible)
                {
                    this.Draw();
                }

                else
                {
                    this.Clear();
                }
            }
        }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        public Control()
        {
            this.RelativePosition = new Position();
            this.Size = new Size();
        }

        #endregion Constructor

        #region Public methods

        /// <summary>
        /// Updates the control if visible is set to true.
        /// </summary>
        public virtual void Update()
        {
            if (this.IsVisible)
            {
                this.Clear();
                this.Draw();
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        public abstract void Draw();

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Clears the control's area.
        /// </summary>
        protected virtual void Clear()
        {
            Rectangle eraseArea = new Rectangle(this.AbsolutePosition, this.Size, ' ', true);
            eraseArea.Draw();
        }

        #endregion Protected methods
    }
}