using System;
using System.Collections.Generic;
using System.Text;

namespace Sparks.Components.Blazor
{
    /// <summary>
    /// Modal options.
    /// </summary>
    public class ModalOptions
    {
        /// <summary>
        /// Gets or sets wether clicking on background to cancel should be disabled.
        /// </summary>
        public bool? DisableBackgroundCancel { get; set; }

        /// <summary>
        /// Gets or sets wether the close button should be hidden.
        /// </summary>
        public bool? HideCloseButton { get; set; }

        /// <summary>
        /// Gets or sets the position of the modal.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the style of the modal.
        /// </summary>
        public string Style { get; set; }
    }
}
