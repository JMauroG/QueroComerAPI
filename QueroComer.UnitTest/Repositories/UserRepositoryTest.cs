using Microsoft.AspNetCore.Identity;
using QueroComer.Mock.Entidades;
using QueroComer.Mock;
using QueroComer.Data.Repositories;

namespace QueroComer.UnitTest.Repositories
{
    public class UserRepositoryTest
    {

        [Fact]
        public async Task UserRepository_RetornaUsuarioPorEmailAsync_Success()
        {
            //Arrange
            IdentityUser userMock = UserMock.GetUserMock();
            var usersMock = UserMock.GetListUserMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RetornaUsuarioPorEmailAsyncTest");
            contextMock.Users.AddRange(usersMock);
            contextMock.SaveChanges();
            var userRepositoryMock = new UserRepository(contextMock);

            //Act
            var user = await userRepositoryMock.RetornaUsuarioPorEmailAsync(userMock.Email!);

            //Assert
            Assert.Equal(userMock.Id, user.Id);
            Assert.IsType<IdentityUser>(user);
        }

        [Fact]
        public async Task UserRepository_RetornaUsuarioPorIdAsync_Success()
        {
            //Arrange
            IdentityUser userMock = UserMock.GetUserMock();
            var contextMock = new InMemoryDbContextFactory().GetDbContext("RetornaUsuarioPorIdAsyncTest");
            var usersMock = UserMock.GetListUserMock();
            contextMock.Users.AddRange(usersMock);
            contextMock.SaveChanges();
            var userRepositoryMock = new UserRepository(contextMock);

            //Act
            var user = await userRepositoryMock.RetornaUsuarioPorIdAsync(userMock.Id);

            //Assert
            Assert.Equal(userMock.Id, user.Id);
            Assert.IsType<IdentityUser>(user);
        }
    }
}
