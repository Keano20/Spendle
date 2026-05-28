namespace Spendle.API.Tests;

using Spendle.API.Helpers;
using Xunit;

public class PasswordHelperTests
{
    [Fact]
    public void VerifyPassword()
    {
        string originalPassword = "TestPassword123@";
        string hashedPassword = PasswordHelper.HashPassword(originalPassword);

        bool isMatch = PasswordHelper.VerifyPassword(originalPassword, hashedPassword);
        Assert.True(isMatch);
    }
}
