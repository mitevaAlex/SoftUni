using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.Contains(tx))
            {
                transactions.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException("No such transaction exists.");
            }

            transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx) => this.Contains(tx.Id);

        public bool Contains(int id) => this.transactions.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .Where(x => x.Amount >= lo && x.Amount <= hi);

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id);

            return wantedTransactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> wantedReceivers = transactions
                .Values
                      .Where(x => x.Status == status)
                      .OrderByDescending(x => x.Amount)
                      .Select(x => x.To);
            if (wantedReceivers.Count() == 0)
            {
                throw new InvalidOperationException("There are no receivers of transactions with the given status.");
            }

            return wantedReceivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> wantedSenders = transactions
                .Values
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount)
                .Select(x => x.From);
            if (wantedSenders.Count() == 0)
            {
                throw new InvalidOperationException("There are no senders of transactions with the given status.");
            }

            return wantedSenders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("No such transaction exists.");
            }

            return this.transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .Where(x => x.To == receiver)
                .Where(x => x.Amount >= lo && x.Amount < hi)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id);
            if (wantedTransactions.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given receiver or having amount between the wanted range.");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id);
            if (wantedTransactions.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given receiver.");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .Where(x => x.From == sender)
                .Where(x => x.Amount > amount)
                .OrderByDescending(x => x.Amount);
            if (wantedTransactions.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given sender or having amount above the minimum.");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .Where(x => x.From == sender)
                .OrderByDescending(x => x.Amount);
            if (wantedTransactions.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given sender.");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount);
            if (wantedTransactions.Count() == 0)
            {
                throw new InvalidOperationException("There are no transactions with the given status.");
            }

            return wantedTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> wantedTransactions = transactions
                .Values
                .Where(x => x.Status == status)
                .Where(x => x.Amount <= amount)
                .OrderByDescending(x => x.Amount);

            return wantedTransactions;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
                yield return transactions[i];
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("No such transaction exists.");
            }

            transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
