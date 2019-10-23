using Sparks.Components.Blazor.Services;
using System;
using Microsoft.AspNetCore.Components;

namespace Sparks.Components.Blazor
{
    /// <summary>
    /// Code behind for the Modal.
    /// Starting point : https://github.com/Blazored/Modal
    /// </summary>
    public class ModalBase : ComponentBase, IDisposable
    {
        const string DefaultStyle = "blazored-modal";
        const string DefaultPosition = "blazored-modal-center";

        [Inject] protected IModalService ModalService { get; set; }

        [Parameter] public bool HideCloseButton { get; set; }
        [Parameter] public bool DisableBackgroundCancel { get; set; }
        [Parameter] public string Position { get; set; }
        [Parameter] public string Style { get; set; }

        protected bool ComponentDisableBackgroundCancel { get; set; }
        protected bool ComponentHideCloseButton { get; set; }
        protected string ComponentPosition { get; set; }
        protected string ComponentStyle { get; set; }
        protected ModalOptions Options { get; set; }
        protected bool IsVisible { get; set; }
        protected string Title { get; set; }
        protected RenderFragment Content { get; set; }
        protected ModalParameters Parameters { get; set; }

        protected override void OnInitialized()
        {
            ((ModalService)ModalService).Shown += OnShown;
            ModalService.Closed += OnClosed;
        }

        public void OnShown(string title, RenderFragment content, ModalParameters parameters, ModalOptions options)
        {
            Title = title;
            Content = content;
            Parameters = parameters;

            SetModalOptions(options);

            IsVisible = true;
            StateHasChanged();
        }

        internal void OnClosed(ModalResult modalResult)
        {
            IsVisible = false;
            Title = "";
            Content = null;
            ComponentStyle = "";

            StateHasChanged();
        }

        protected void HandleBackgroundClick()
        {
            if (ComponentDisableBackgroundCancel) return;

            ModalService.Cancel();
        }

        private void SetModalOptions(ModalOptions options)
        {
            ComponentHideCloseButton = HideCloseButton;
            if (options.HideCloseButton.HasValue)
                ComponentHideCloseButton = options.HideCloseButton.Value;

            ComponentDisableBackgroundCancel = DisableBackgroundCancel;
            if (options.DisableBackgroundCancel.HasValue)
                ComponentDisableBackgroundCancel = options.DisableBackgroundCancel.Value;

            ComponentPosition = string.IsNullOrWhiteSpace(options.Position) ? Position : options.Position;
            if (string.IsNullOrWhiteSpace(ComponentPosition))
                ComponentPosition = DefaultPosition;

            ComponentStyle = string.IsNullOrWhiteSpace(options.Style) ? Style : options.Style;
            if (string.IsNullOrWhiteSpace(ComponentStyle))
                ComponentStyle = DefaultStyle;
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
                ((ModalService)ModalService).Shown -= OnShown;
                ModalService.Closed -= OnClosed;
            }

            _disposed = true;
        }
        #endregion
    }
}