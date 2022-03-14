using System;
using BankyStuffLibrary;
using Xunit;

namespace BankingTests
{
    public class BasicTests
    {
        [Fact]
        public void TrueIsTrue()
        {
            Assert.True(true);
        }

        /**
         * Test for a negative balance
         */
        [Fact]
        public void CantTakeMoreThanYouHave()
        {
            var account = new BankAccount("Kendra", 10000);
            Assert.Throws<InvalidOperationException>(
                () => account.MakeWithdrawal(80000, DateTime.Now, "Attempt to overdraw")
            );
        }

        /**
         * Test that the initial balances must be positive.
         */
        [Fact]
        public void NeedMoneyToStart()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BankAccount("invalid", -55)
            );
        }
    }
}