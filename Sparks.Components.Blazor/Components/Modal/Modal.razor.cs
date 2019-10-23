using Sparks.Components.Blazor.Services;
using System;
using Microsoft.AspNetCore.Components;

namespace Sparks.Components.Blazor
{
    /// <summary>
    /// Code behind for the Modal.
    /// https://www.telerik.com/blogs/creating-a-reusable-javascript-free-blazor-modal
    /// </summary>
    public class ModalBase : ComponentBase, IDisposable
    {
        /// <summary>
        /// Gets or sets the <see cref="IModalService"/>. This property is injected.
        /// </summary>
        [Inject] private IModalService ModalService { get; set; }

        /// <summary>
        /// Gets or sets whether the modal is visible.
        /// </summary>
        protected bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets the modal title.
        /// </summary>
        protected string Title { get; set; }

        /// <summary>
        /// Gets or sets the modal content.
        /// </summary>
        protected RenderFragment Content { get; set; }

        /// <summary>
        /// Connects to events on initialization.
        /// </summary>
        protected override void OnInitialized()
        {
            ModalService.Shown += ShowModal;
            ModalService.Closed += CloseModal;
        }

        /// <summary>
        /// Shows the modal.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void ShowModal(string title, RenderFragment content)
        {
            Title = title;
            Content = content;
            IsVisible = true;

            StateHasChanged();
        }

        protected void CancelModal()
        {
            CloseModal(ModalResult.Cancel);
        }

        /// <summary>
        /// Closes the modal.
        /// </summary>
        /// <param name="result"></param>
        public void CloseModal(ModalResult result)
        {
            IsVisible = false;
            Title = "";
            Content = null;

            StateHasChanged();
        }

        #region IDisposable implementation
        private bool _disposed = false;

        /// <summary>
        /// <see cref="IDisposable.Dispose"/> implementation.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposing of managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                ModalService.Shown -= ShowModal;
                ModalService.Closed -= CloseModal;
            }

            _disposed = true;
        }
        #endregion
    }
}