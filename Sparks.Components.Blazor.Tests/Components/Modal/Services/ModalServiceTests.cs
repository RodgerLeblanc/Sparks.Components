using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Moq;
using Sparks.Components.Blazor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace Sparks.Components.Blazor.Tests.Components.Modal.Services
{
    public class ModalServiceTests
    {
        [Fact]
        public void Show_WrongBaseType_ShouldThrowArgumentException()
        {
            ModalService service = new ModalService();

            Action action = () => service.Show("", typeof(string));

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Show_ComponentBase_ShouldShowModal()
        {
            Mock<ComponentBase> mockComponent = new Mock<ComponentBase>();
            ModalService service = new ModalService();
            bool eventCalled = false;
            service.Shown += (title, renderFragment, _, __) => eventCalled = true;

            service.Show("Test", mockComponent.Object.GetType());

            eventCalled.Should().BeTrue();
        }

        [Fact]
        public void Show_ComponentBase_ShouldSetModalTitle()
        {
            Mock<ComponentBase> mockComponent = new Mock<ComponentBase>();
            ModalService service = new ModalService();
            string modalTitle = null;
            service.Shown += (title, renderFragment, _, __) => modalTitle = title;

            service.Show("Test", mockComponent.Object.GetType());

            modalTitle.Should().Be("Test");
        }

        [Fact]
        public void Show_ComponentBase_ShouldSetModalRenderFragment()
        {
            Mock<ComponentBase> mockComponent = new Mock<ComponentBase>();
            ModalService service = new ModalService();
            RenderFragment modalRenderFragment = null;
            service.Shown += (title, renderFragment, _, __) => modalRenderFragment = renderFragment;

            service.Show("Test", mockComponent.Object.GetType());

            modalRenderFragment.Should().NotBeNull().And.BeOfType<RenderFragment>();
        }

        [Fact]
        public void Close_ComponentBase_ShouldCloseModal()
        {
            ModalService service = new ModalService();
            bool eventCalled = false;
            service.Closed += (result) => eventCalled = true;

            service.Cancel();

            eventCalled.Should().BeTrue();
        }
    }
}
