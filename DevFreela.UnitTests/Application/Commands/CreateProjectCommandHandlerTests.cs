using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var skillRepositoryMock = new Mock<ISkillRepository>();

            unitOfWorkMock.SetupGet(uow => uow.Projects).Returns(projectRepositoryMock.Object);
            unitOfWorkMock.SetupGet(uow => uow.Skills).Returns(skillRepositoryMock.Object);

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Titulo do projeto",
                Description = "Descrição do projeto",
                TotalCost = 10000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(unitOfWorkMock.Object);

            //Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Asset
            projectRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
