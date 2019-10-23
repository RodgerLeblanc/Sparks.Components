using System;
using Microsoft.AspNetCore.Components;

namespace Sparks.Components.Blazor.Services
{
    /// <summary>
    /// The service that is used to show or close modal.
    /// </summary>
    public interface IModalService
    {
        /// <summary>
        /// Custom event fired when the modal is shown.
        /// </summary>
        event Action<string, RenderFragment> Shown;

        /// <summary>
        /// Custom event fired when the modal is closed.
        /// </summary>
        event Action<ModalResult> Closed;

        /// <summary>
        /// Shows the modal.
        /// </summary>
        void Show(string title, Type contentType);

        /// <summary>
        /// Closes the modal.
        /// </summary>
        void Close();
    }
}