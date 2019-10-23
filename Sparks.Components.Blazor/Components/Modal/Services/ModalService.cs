using Microsoft.AspNetCore.Components;
using System;

namespace Sparks.Components.Blazor.Services
{
    /// <summary>
    /// The service that is used to show or hide modal.
    /// </summary>
    public class ModalService : IModalService
    {
        /// <summary>
        /// Custom event fired when the modal is shown.
        /// </summary>
        public event Action<string, RenderFragment> OnShow;

        /// <summary>
        /// Custom event fired when the modal is hidden.
        /// </summary>
        public event Action OnHide;

        /// <summary>
        /// Shows the modal.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="contentType"></param>
        public void Show(string title, Type contentType)
        {
            if (contentType.BaseType != typeof(ComponentBase))
            {
                throw new ArgumentException($"{contentType.FullName} must be a Blazor Component");
            }

            RenderFragment content = new RenderFragment(x => { x.OpenComponent(1, contentType); x.CloseComponent(); });

            OnShow?.Invoke(title, content);
        }

        /// <summary>
        /// Hides the modal.
        /// </summary>
        public void Hide()
        {
            OnHide?.Invoke();
        }
    }
}
