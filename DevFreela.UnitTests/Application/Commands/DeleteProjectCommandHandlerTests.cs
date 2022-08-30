using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        //Teste com erro
        [Fact]
        public async Task DeleteProject_Executed_ReturnOK()
        {
            //Arrange
            var projects = new List<Project>()
            {
                new Project("Nome do Teste 1", "Descrição do projeto 1", 1, 2, 10000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();

            var deleteProjectCommand = new DeleteProjectCommand(projects.First().Id);
            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);
      
            //Act
            var projectsList = await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            //Assert
            projectRepositoryMock.Verify(pr => pr.DeleteAsync(projects.First()), Times.Once);

        }
    }
}
