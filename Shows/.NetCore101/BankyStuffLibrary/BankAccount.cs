using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankyStuffLibrary
{
    /// <summary>银行账号</summary>
    public class BankAccount
    {
        /// <summary>号码</summary>
        public string Number { get; }

        /// <summary>所有人</summary>
        public string Owner { get; set; }

        /// <summary>余额</summary>
        public decimal Balance
        {
            get { return _allTransactions.Sum(transaction => transaction.Amount); }
        }

        private static long _accountNumberSeed = 1234567890;
        private readonly List<Transaction> _allTransactions = new List<Transaction>();

        /// <summary>创建账号</summary>
        /// <param name="name">名称</param>
        /// <param name="initialBalance">初始余额</param>
        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            Number = _accountNumberSeed.ToString();
            _accountNumberSeed++;
        }

        private void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        /// <summary>取款</summary>
        /// <param name="amount">数量</param>
        /// <param name="date">日期</param>
        /// <param name="note"></param>
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }

        /// <summary>获取账号历史</summary>
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            // HEADER
            report.AppendLine($"Date\t\t{"Amount",-30}Note");
            foreach (var transaction in _allTransactions)
            {
                // ROWS
                report.AppendLine(String.Format("{0}\t{1,-30}{2}",
                    transaction.Date.ToShortDateString(), transaction.AmountForHumans, transaction.Notes));
            }

            return report.ToString();
        }
    }
}
