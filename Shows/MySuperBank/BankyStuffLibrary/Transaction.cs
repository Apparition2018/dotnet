using System;
using System.Globalization;
using Humanizer;

namespace BankyStuffLibrary
{
    /// <summary>交易</summary>
    public class Transaction
    {
        /// <summary>金额</summary>
        public decimal Amount { get; }

        /// <summary>金额（人性化）</summary>
        public string AmountForHumans => ((int)Amount).ToWords(CultureInfo.InvariantCulture);

        /// <summary>日期</summary>
        public DateTime Date { get; }

        /// <summary>注释</summary>
        public string Notes { get; }

        /// <summary>创建交易</summary>
        /// <param name="amount">金额</param>
        /// <param name="date">日期</param>
        /// <param name="notes">注释</param>
        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }
}
