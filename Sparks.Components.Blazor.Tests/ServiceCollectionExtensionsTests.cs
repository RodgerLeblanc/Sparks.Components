using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Sparks.Components.Blazor.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Sparks.Components.Blazor.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddBlazorModal_WhenCalled_ShouldAddModalService()
        {
            Mock<IServiceCollection> services = new Mock<IServiceCollection>();

            IServiceCollection result = services.Object.AddBlazorModal();

            services.Verify(s => s.Add(It.Is<ServiceDescriptor>(sd => sd.ServiceType == typeof(ModalService))), Times.Once);
        }
    }
}
