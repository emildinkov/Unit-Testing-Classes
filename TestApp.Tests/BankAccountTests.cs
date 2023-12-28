using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Arrange
        double initialBalance = 100;

        // Act
        BankAccount account = new BankAccount(initialBalance);

        // Assert
        Assert.AreEqual(initialBalance, account.Balance);

    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        double initialBalance = 100;
        double depositAmount = 50;
        BankAccount account = new BankAccount(initialBalance);

        double expected = initialBalance + depositAmount;

        // Act
        account.Deposit(depositAmount);

        // Assert
        Assert.AreEqual(expected, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 100;
        double depositAmount = -50;
        BankAccount account = new BankAccount(initialBalance);

        // Act & Assert
        Assert.That(() => account.Deposit(depositAmount), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        double initialBalance = 100;
        double withdrawAmount = 50;
        BankAccount account = new BankAccount(initialBalance);

        double expected = initialBalance - withdrawAmount;

        // Act
        account.Withdraw(withdrawAmount);

        // Assert
        Assert.AreEqual(expected, account.Balance);
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 100;
        double withdrawAmount = -50;
        BankAccount account = new BankAccount(initialBalance);

        // Act & Assert
        Assert.That(() => account.Withdraw(withdrawAmount), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
        double initialBalance = 100;
        double withdrawAmount = 150;
        BankAccount account = new BankAccount(initialBalance);

        // Act & Assert
        Assert.That(() => account.Withdraw(withdrawAmount), Throws.ArgumentException);
    }
}
