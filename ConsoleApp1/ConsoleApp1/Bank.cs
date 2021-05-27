using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Bank
    {
        private List<Account> accounts;
        private string name;
        private double sumBalance;
        private double sumCredit;
        private double creditHistory;
        public Bank(string name)
        {
            this.name = name;
            this.sumBalance  = 0;
            this.sumCredit = 0;
            this.accounts = new List<Account>();
        }
        public Account FindAccount(string login)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Account acc in this.accounts)
            {
                if (login == acc.GetUsername())
                {
                    stringBuilder.Append("\nUser: ");
                    stringBuilder.Append(acc.GetUsername());
                    return acc;
                }
            }
            return null;
        }
        public void AddAccount(Account account) //dodawanie nowego uzytkownika
        {
            this.accounts.Add(account);
        }
        public void RemoveAccount(Account account) //usuwanie uzytkownika
        {
            this.accounts.Remove(account);
        }
        public void SumBalance()  //sumowanie wszystkich sald w banku
        {
            sumBalance = 0;
            foreach(Account acc in this.accounts)
            {
                sumBalance += acc.GetBalance();
            }
            Console.WriteLine("Sum of all accounts in the bank: " + this.sumBalance + " PLN.");
        }
        public void SumCredit()  //suma kredytu
        {
            sumCredit = 0;
            foreach (Account acc in this.accounts)
            {  
                sumCredit += acc.GetCredit();
            }
            Console.WriteLine("Total credit is equal: " + sumCredit + " PLN.");
        }
        public void CreditHistory(Account account)  //historia kredytowa
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Credit history of:");
            foreach (Account acc in this.accounts)
            {
                creditHistory += acc.GetCredit();
                stringBuilder.Append(acc.GetUsername());
                stringBuilder.Append(acc.GetCredit());
                Console.WriteLine(acc.GetUsername() + " is equal " + acc.GetCredit() + " PLN.");
            }
        }
        public void Debtor(Account account)  //historia dluznikow
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("List of current debtors:");

            foreach (Account acc in this.accounts)
            {
                stringBuilder.Append(acc.GetUsername());
                stringBuilder.Append(acc.GetCredit());
                double debtorCredit = acc.GetCredit();

                if (debtorCredit > 0)
                {
                    Console.WriteLine("Credit of user " + acc.GetUsername() + " is equal " + acc.GetCredit() + "zl.");
                }
                else if (debtorCredit == 0)
                {
                    Console.WriteLine(acc.GetUsername() + " isnt debtor.");
                }
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Account acc in this.accounts)
            {
                stringBuilder.Append("\nUsername: ");
                stringBuilder.Append(acc.GetUsername());
                stringBuilder.Append("\nPassword: ");
                stringBuilder.Append(acc.GetPassword());
                stringBuilder.Append("\nBalance: ");
                stringBuilder.Append(acc.GetBalance());
                stringBuilder.Append(" PLN\n");
            }
            return $"Bank: {name}\nAccounts:\n{stringBuilder.ToString()}";
        }
    }
}