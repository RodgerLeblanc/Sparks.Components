﻿using System;
using Microsoft.AspNetCore.Components;

namespace Sparks.Components.Blazor.Services
{
    /// <summary>
    /// The service that is used to show or close modal.
    /// </summary>
    public interface IModalService
    {
        /// <summary>
        /// Invoked when the modal component closes.
        /// </summary>
        event Action<ModalResult> Closed;

        /// <summary>
        /// Internal event used to trigger the modal component to show.
        /// </summary>
        event Action<string, RenderFragment, ModalParameters, ModalOptions> Shown;

        /// <summary>
        /// Shows the modal using the specified title and component type.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        void Show(string title, Type contentType);

        /// <summary>
        /// Shows the modal using the specified title and component type.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        /// <param name="options">Options to configure the modal.</param>
        void Show(string title, Type componentType, ModalOptions options);

        /// <summary>
        /// Shows the modal using the specified <paramref name="title"/> and <paramref name="componentType"/>, 
        /// passing the specified <paramref name="parameters"/>. 
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        void Show(string title, Type contentType, ModalParameters parameters);

        /// <summary>
        /// Shows the modal using the specified <paramref name="title"/> and <paramref name="componentType"/>, 
        /// passing the specified <paramref name="parameters"/> and setting a custom CSS style. 
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        /// <param name="options">Options to configure the modal.</param>
        void Show(string title, Type componentType, ModalParameters parameters, ModalOptions options);

        void Show<T>(string title, ModalParameters parameters = null, ModalOptions options = null) where T : ComponentBase;

        /// <summary>
        /// Cancels the modal and invokes the <see cref="Closed"/> event.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Closes the modal and invokes the <see cref="Closed"/> event with the specified <paramref name="modalResult"/>.
        /// </summary>
        /// <param name="modalResult"></param>
        void Close(ModalResult modalResult);
    }
}