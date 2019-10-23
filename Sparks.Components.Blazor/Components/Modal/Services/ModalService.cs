﻿using Microsoft.AspNetCore.Components;
using System;

namespace Sparks.Components.Blazor.Services
{
    /// <summary>
    /// The service that is used to show or close modal.
    /// </summary>
    public class ModalService : IModalService
    {
        /// <summary>
        /// Invoked when the modal component closes.
        /// </summary>
        public event Action<ModalResult> Closed;

        /// <summary>
        /// Internal event used to trigger the modal component to show.
        /// </summary>
        public event Action<string, RenderFragment, ModalParameters, ModalOptions> Shown;

        /// <summary>
        /// Shows the modal using the specified title and component type.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        public void Show(string title, Type componentType)
        {
            Show(title, componentType, new ModalParameters(), new ModalOptions());
        }

        /// <summary>
        /// Shows the modal using the specified title and component type.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        /// <param name="options">Options to configure the modal.</param>
        public void Show(string title, Type componentType, ModalOptions options)
        {
            Show(title, componentType, new ModalParameters(), options);
        }

        /// <summary>
        /// Shows the modal using the specified <paramref name="title"/> and <paramref name="componentType"/>, 
        /// passing the specified <paramref name="parameters"/>. 
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        public void Show(string title, Type componentType, ModalParameters parameters)
        {
            Show(title, componentType, parameters, new ModalOptions());
        }

        /// <summary>
        /// Shows the modal using the specified <paramref name="title"/> and <paramref name="componentType"/>, 
        /// passing the specified <paramref name="parameters"/> and setting a custom CSS style. 
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        /// <param name="options">Options to configure the modal.</param>
        public void Show(string title, Type componentType, ModalParameters parameters, ModalOptions options)
        {
            if (!typeof(ComponentBase).IsAssignableFrom(componentType))
            {
                throw new ArgumentException($"{componentType.FullName} must be a Blazor Component");
            }

            RenderFragment content = new RenderFragment(x => { x.OpenComponent(1, componentType); x.CloseComponent(); });

            Shown?.Invoke(title, content, parameters, options);
        }

        /// <summary>
        /// Closes the modal and invokes the <see cref="Closed"/> event.
        /// </summary>
        public void Cancel()
        {
            Closed?.Invoke(ModalResult.Cancel());
        }

        /// <summary>
        /// Closes the modal and invokes the <see cref="Closed"/> event with the specified <paramref name="modalResult"/>.
        /// </summary>
        /// <param name="modalResult"></param>
        public void Close(ModalResult modalResult)
        {
            Closed?.Invoke(modalResult);
        }

        public void Show<T>(string title, ModalParameters parameters = null, ModalOptions options = null) where T : ComponentBase
        {
            Show(title,
                 typeof(T),
                 parameters ?? new ModalParameters(),
                 options ?? new ModalOptions());
        }
    }
}
