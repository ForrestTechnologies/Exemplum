namespace Application.UnitTests.Application.Exceptions
{
    using AutoFixture;
    using Exemplum.Application.Common.Exceptions;
    using Exemplum.Application.Common.Exceptions.Converters;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class UnauthorizedAccessExceptionConverterTests
    {
        [Fact]
        public void Convert_should_set_message()
        {
            var fixture = new Fixture();

            var sut = new ExceptionToErrorConverter(new List<ICustomExceptionErrorConverter>
            {
                new UnauthorizedAccessExceptionConverter()
            });

            var errorInfo = sut.Convert(new UnauthorizedAccessException(), true);

            errorInfo.Message.Should().Be("Unauthorized");
        }
    }
}