using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        public async Task CreatedComment_Executed_ReturnOk()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createCommentCommand = new CreateCommentCommand()
            {
                Content = "Meu comentario",
                IdProject = 1,
                IdUser = 1
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMock.Object);

            //Act
            var comment = await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());
            
            //Assert
            Assert.NotNull(createCommentCommand.Content);
            Assert.NotEmpty(createCommentCommand.Content);

            projectRepositoryMock.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}
