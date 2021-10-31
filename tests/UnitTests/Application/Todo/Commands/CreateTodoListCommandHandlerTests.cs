﻿namespace Exemplum.UnitTests.Application.Todo.Commands
{
    using AutoFixture;
    using Exemplum.Application.TodoList.Commands;
    using Exemplum.Domain.Todo;
    using FluentAssertions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class CreateTodoListCommandHandlerTests : HandlerTestBase 
    {
        [Fact]
        public async Task Handle_returns_the_created_item()
        {
            var fixture = CreateFixture();
            
            var command = fixture.Build<CreateTodoListCommand>()
                .With(x => x.Colour,Colour.Blue)
                .Create();
            
            var sut = fixture.Create<CreateTodoListCommandHandler>();

            var result = await sut.Handle(command, CancellationToken.None);

            result.Title.Should().Be(command.Title);
        }
        
        [Fact]
        public async Task Handle_with_invalid_colour_throw()
        {
            var fixture = CreateFixture();
            
            var command = fixture.Build<CreateTodoListCommand>()
                .With(x => x.Colour, "Invalid")
                .Create();
            
            var sut = fixture.Create<CreateTodoListCommandHandler>();

            Func<Task> act = async () => await sut.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<UnsupportedColourException>();
        }
    }
}