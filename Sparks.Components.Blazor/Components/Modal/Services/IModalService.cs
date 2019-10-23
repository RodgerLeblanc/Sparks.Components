using System;
using Microsoft.AspNetCore.Components;

namespace Sparks.Components.Blazor.Services
{
    /// <summary>
    /// The service that is used to show or hide modal.
    /// </summary>
    public interface IModalService
    {
        /// <summary>
        /// Custom event fired when the modal is shown.
        /// </summary>
        event Action<string, RenderFragment> OnShow;

        /// <summary>
        /// Custom event fired when the modal is hidden.
        /// </summary>
        event Action<ModalResult> OnHide;

        /// <summary>
        /// Shows the modal.
        /// </summary>
        void Show(string title, Type contentType);

        /// <summary>
        /// Hides the modal.
        /// </summary>
        void Hide();
    }
}