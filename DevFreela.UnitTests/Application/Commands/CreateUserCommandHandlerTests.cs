using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand()
            {
                FullName = "Edson Arantes do nascimento",
                Email = "pele@gmail.com",
                BirthDate = new DateTime(1940, 10, 23),
                Role = "Client",
                Password = "1000gols"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            userRepositoryMock.Verify(ur => ur.AddAsync(It.IsAny<User>()), Times.Once);

        }
    }
}
