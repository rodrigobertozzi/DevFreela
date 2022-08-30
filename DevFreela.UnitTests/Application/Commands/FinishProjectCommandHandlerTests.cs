using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class FinishProjectCommandHandlerTests
    {
        //Testes com erro
        [Fact]
        public async Task FinishedProject_Executed_ReturnOk()
        {
            //Arrange
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Titulo do projeto",
                Description = "Descrição do projeto",
                TotalCost = 10000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            //var finishProjectCommand = new FinishProjectCommand();
            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            //var finishProject = await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());
            
            //Assert
            Assert.NotNull(createProjectCommand);
            
            
            //projectRepositoryMock.Verify(fp => fp.FinishAsync(createProjectCommand))

            

        } 
    }
}
