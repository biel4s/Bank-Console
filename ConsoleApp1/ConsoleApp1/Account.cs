using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    enum Type
    {
        User,
        Admin
    }
    class Account
    {
        private string username;
        private string password;
        private double balance;
        private double deposit;
        private double withdrawal;
        private double credit;
        private bool block;
        private Type accType;

        public Account(string username, string password, double balance, Type accType)
        {
            this.username = username;
            this.password = password;
            this.balance = balance;
            this.accType = accType;
        }

        public string GetUsername()
        {
            return this.username;
        }
        public string GetPassword()
        {
            return this.password;
        }
        public double GetBalance()
        {
            return this.balance;
        }
        public double GetCredit()
        {
            return this.credit;
        }
        public Type GetAccType()
        {
            return this.accType;
        }
        public bool GetBlock()
        {
            return this.block;
        } 
        public void Balance()
        {
            Console.WriteLine("Balance of account " + this.username + " is equal: " + this.balance + " PLN.");
        }
        public void Deposit(double deposit)  //wplacanie pieniedzy
        {
            this.deposit += deposit;
            this.balance += deposit;
            Console.WriteLine("Deposited: " + deposit + " PLN Account balance: " + this.balance + " PLN.");
        }
        public void SumDeposit()  //suma wplaconych pieniedzy
        {
            double sumDeposit = 0;
            sumDeposit += this.deposit;
            Console.WriteLine("Total deposit is equal: " + sumDeposit + " PLN.");
        }
        public void Withdrawal(double withdrawal)  //wyplacanie pieniedzy
        {
            this.withdrawal += withdrawal;
            this.balance -= withdrawal;
            Console.WriteLine("Withdrew:  " + withdrawal + " PLN Account balance: " + this.balance + " PLN.");
        }
        public void SumWithdrawal()  //suma wyplaconych pieniedzy
        {
            double sumWithdrawal = 0;
            sumWithdrawal += this.withdrawal;
            Console.WriteLine("Total withdrawal is equal: " + sumWithdrawal + " PLN.");
        }
        public void Credit(double credit)  //zaciagniecie kredytu
        {
            if (this.credit == 0)
            {
                do
                {
                    this.credit += credit;
                    this.balance += credit;
                    Console.WriteLine("Credit amount of user " + username + " is equal: " + credit + " PLN.");
                }
                while (this.credit == 0);
            }
            else
            {
                Console.WriteLine("You cant take a credit again.");
            }
        }
        public void PayOffCredit(double payoffcredit)  //splacenie kredytu
        {
            if (credit <= 0)
            {
                Console.WriteLine("You dont have any credit.");
            }
            else if (credit < payoffcredit)
            {
                Console.WriteLine("Max you can pay off for this credit is " + credit + " PLN.");
            }
            else
            {
                this.credit -= payoffcredit;
                this.balance -= payoffcredit;
                Console.WriteLine("You paid off: " + payoffcredit + " PLN.");
                if (credit == 0)
                {
                    Console.WriteLine("Your credit has been paid off.");
                }
                else
                {
                    Console.WriteLine(credit + " PLN left to pay off the credit.");
                }
            }
        }
        public void History(Account account)  //historia operacji
        {
            Console.WriteLine("History operation of current user " + account.username);
            double creditHistory = 0;
            double depositHistory = 0;
            double withdrawalHistory = 0;

            creditHistory += this.credit;
            depositHistory += this.deposit;
            withdrawalHistory += this.withdrawal;
            Console.WriteLine("Credit of " + account.GetUsername() + " is equal " + creditHistory + " PLN.");
            Console.WriteLine("Deposit of " + account.GetUsername() + " is equal " + depositHistory + " PLN.");
            Console.WriteLine("Withdrawal of " + account.GetUsername() + " is equal " + withdrawalHistory + " PLN.");
        }
        public void Transfer(double transfer, Account username1, Account username2)  //przelew
        {
            username1.balance -= transfer;
            username2.balance += transfer;
            Console.WriteLine("You have transferred: " + transfer + " PLN to " + username2.username + ".");
        }
        public bool Block(bool block)  //blokowanie konta
        {
            this.block = block;
            if (block == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"Username: {username}\nPassword: {password}\nBalance: {balance} PLN\nType: {accType}";
        }
    }
}