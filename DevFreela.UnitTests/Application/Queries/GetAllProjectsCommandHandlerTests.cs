﻿using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            //Arrange
            var projects = new PaginationResult<Project>()
            {
                Data = new List<Project> {
                    new Project("Nome do Teste 1", "Descrição do projeto 1", 1, 2, 10000),
                    new Project("Nome do Teste 2", "Descrição do projeto 2", 1, 2, 20000),
                    new Project("Nome do Teste 3", "Descrição do projeto 3", 1, 2, 30000)
                }
            };
            

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery { Query = "", Page = 1 };
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);
            //Act
            var paginationProjectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken()); 

            //Assert
            Assert.NotNull(paginationProjectViewModelList);
            Assert.NotEmpty(paginationProjectViewModelList.Data);
            Assert.Equal(projects.Data.Count, paginationProjectViewModelList.Data.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>()).Result, Times.Once);
        }
    }
}
