using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Użytkownik:
            //-wpłaca i wypłaca,
            //-sprawdza historię operacji na koncie,
            //-generuje podsumowanie: ile wpłacił i ile wypłacił od początku
            //-może wziąć kredyt(pole kredyt w klasie Konto), ale tylko jeden.Metoda SpłaćKredyt przelewa pieniądze z konta na spłatę kredytu.
            //-może zrobić przelew na inne konto
            //-wszystkie operacje możliwe dopiero po zalogowaniu na konto(hasło przechowujemy w klasie Account)

            //Admin:
            //-może zablokować konto użytkownikowi(pole typu bool w Account), wtedy użytkownik nie może się zalogować
            //-może dodawać i usuwać konta
            //-może robić podsumowania: ile w sumie jest pieniędzy w banku, ile wynosi łączny kredyt itd
            //-jest w posiadaniu historii kredytowej każdego klienta, może też pobrać wszystkich aktualnych dłużników
            //Klasy:

            //Account, Bank(pole: tablica/kolekcja kont)  +

            Account acc1 = new Account("kamil", "zaq123", 3000, Type.Admin);
            Account acc2 = new Account("alexandra", "zaq123", 3000, Type.Admin);
            Account acc3 = new Account("jake", "zaq123", 1800, Type.User);
            Account acc4 = new Account("jacob", "zaq123", 2400, Type.User);
            Bank bank = new Bank("Pekao24");

            Console.WriteLine("Console Bank in C#\n");
            string menuoption;

            do
            {
                Console.WriteLine("1. Log in. ");
                Console.WriteLine("2. Exit.");

                Console.Write("\nChoose your option: ");
                menuoption = Console.ReadLine();

                if ((menuoption == "1") || (menuoption == "2"))
                {
                    switch (menuoption)
                    {
                        case "1":
                            string username, password;
                            do
                            {
                                Console.Clear();
                                Console.Write("Enter username here: ");
                                username = Console.ReadLine();
                                Console.Write("Enter password here: ");
                                password = Console.ReadLine();

                                //acc1.Block(true);               //test blokowania konta

                                if ((username == acc1.GetUsername()) && (password == acc1.GetPassword()))
                                {
                                    if (acc1.GetBlock() == true)
                                    {
                                        for (int i = 1; i <= 5; i++)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Logging in... Please wait. " + i +"/5");
                                            Thread.Sleep(450);
                                        }
                                        Console.Clear();
                                        Console.WriteLine("Your account has been blocked.");
                                    }
                                    else
                                    {
                                        for (int i = 1; i <= 5; i++)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Logging in... Please wait. " + i + "/5");
                                            Thread.Sleep(450);
                                        }
                                        Console.Clear();

                                        Console.WriteLine("You are logged as: " + acc1.GetUsername() + "\nType of account: " + acc1.GetAccType());
                                        Console.WriteLine("Menu:\n");
                                        Console.WriteLine("User options: ");
                                        Console.WriteLine("1. Balance.");
                                        Console.WriteLine("2. Deposit.");
                                        Console.WriteLine("3. Withdrawal.");
                                        Console.WriteLine("4. Sum of Deposits.");
                                        Console.WriteLine("5. Sum of Withdrawals.");
                                        Console.WriteLine("6. History of operations.");
                                        Console.WriteLine("7. Take the credit.");
                                        Console.WriteLine("8. Pay off the credit.");
                                        Console.WriteLine("9. Transfer.");
                                        Console.WriteLine("10. Find user.");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.WriteLine("Admin options: ");
                                        Console.WriteLine("11. Block.");
                                        Console.WriteLine("12. Unblock.");
                                        Console.WriteLine("13. Add new user.");
                                        Console.WriteLine("14. Remove user.");
                                        Console.WriteLine("15. Sum of money from all accounts.");
                                        Console.WriteLine("16. Sum of credit from all accounts.");
                                        Console.WriteLine("17. Credit history.");
                                        Console.WriteLine("18. List of current debtors.");
                                        Console.WriteLine("19. List of all accounts.");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.WriteLine("20. Exit.");

                                        bank.AddAccount(acc1);         //test dodawania uzytkownikow
                                        bank.AddAccount(acc2);
                                        bank.AddAccount(acc3);
                                        bank.AddAccount(acc4);

                                        //acc1.Credit(1000);
                                        //acc2.Credit(1000);

                                        while (true)
                                        {
                                            Console.Write("\nChoose your option: ");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":  //balans konta
                                                    acc1.Balance();
                                                    break;
                                                case "2":  //wplacanie
                                                    Console.WriteLine("How much would you like to deposit?");
                                                    double valueDeposit = Convert.ToInt32(Console.ReadLine());
                                                    acc1.Deposit(valueDeposit);
                                                    break;
                                                case "3":  //wyplacanie
                                                    Console.WriteLine("How much would you like to  withdrawal?");
                                                    double valueWithdrawal = Convert.ToInt32(Console.ReadLine());
                                                    if (valueWithdrawal > acc1.GetBalance())
                                                    {
                                                        Console.WriteLine("You dont have enough money to withdraw.");
                                                    }
                                                    else
                                                    {
                                                        acc1.Withdrawal(valueWithdrawal);
                                                    }
                                                    break;
                                                case "4":  //suma wplaconych pieniedzy
                                                    acc1.SumDeposit();
                                                    break;
                                                case "5":  //suma wyplaconych pieniedzy
                                                    acc1.SumWithdrawal();
                                                    break;
                                                case "6":  //historia operacji
                                                    acc1.History(acc1);
                                                    break;
                                                case "7":  //kredyt
                                                    Console.WriteLine("How much money would you like to take?");
                                                    int valueCredit;
                                                    do
                                                    {
                                                        valueCredit = Convert.ToInt32(Console.ReadLine());
                                                        if (valueCredit < 0)
                                                        {
                                                            Console.WriteLine("Enter only positive number.");  //or uint 
                                                        }
                                                        else
                                                        {
                                                            acc1.Credit(valueCredit);
                                                        }
                                                    } while (valueCredit <= 0);
                                                    break;
                                                case "8":  //splacenie kredytu
                                                    Console.WriteLine("How much money would you like to pay off?");
                                                    int valuePayOffCredit = Convert.ToInt32(Console.ReadLine());
                                                    acc1.PayOffCredit(valuePayOffCredit);
                                                    break;
                                                case "9":  //przelew
                                                    Console.WriteLine("How much money would you like to transfer?");
                                                    int valueTransfer = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("To who would you like to transfer money?");
                                                    string valueTransferUser = Console.ReadLine();
                                                    Account TransferUser = bank.FindAccount(valueTransferUser);
                                                    acc1.Transfer(valueTransfer, acc1, TransferUser);
                                                    break;
                                                case "10":  //wyszukiwanie uzytkownika
                                                    Console.WriteLine("What user would you like to find?");
                                                    string valueUser = Console.ReadLine();
                                                    Account findAcc = bank.FindAccount(valueUser);
                                                    if (findAcc != null)
                                                    {
                                                        Console.WriteLine("Account found: " + findAcc.GetUsername());
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Account " + valueUser + " didnt found.");
                                                    }
                                                    break;
                                                case "11":  //blokowanie uzytkownika
                                                    Type blockType = acc1.GetAccType();
                                                    if (blockType == Type.Admin)
                                                    {
                                                        Console.WriteLine("What user do you want to block?");
                                                        string blockUser = Console.ReadLine();
                                                        Account blockFindAcc = bank.FindAccount(blockUser);
                                                        if (blockFindAcc != null)
                                                        {
                                                            blockFindAcc.Block(true);
                                                            Console.WriteLine("Account " + blockFindAcc.GetUsername() + " has been blocked.");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Account " + blockUser + " didnt found.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("You dont have permission to this option.");
                                                    }
                                                    break;
                                                case "12":  //odblokowywanie uzytkownika;
                                                    Type unblockType = acc1.GetAccType();
                                                    if (unblockType == Type.Admin)
                                                    {
                                                        Console.WriteLine("What user do you want to unblock?");
                                                        string unblockUser = Console.ReadLine();
                                                        Account unblockFindAcc = bank.FindAccount(unblockUser);
                                                        if (unblockFindAcc != null)
                                                        {
                                                            unblockFindAcc.Block(false);
                                                            Console.WriteLine("Account " + unblockFindAcc.GetUsername() + " has been unblocked.");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Account " + unblockUser + " didnt found.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("You dont have permission to this option.");
                                                    }
                                                    break;
                                                case "13":  //dodawanie nowego uzytkownika
                                                    Type addUserType = acc1.GetAccType();
                                                    if (addUserType == Type.Admin)
                                                    {
                                                        Console.WriteLine("Enter username: ");
                                                        string newUsername = Console.ReadLine();
                                                        Console.WriteLine("Enter password: ");
                                                        string newPassword = Console.ReadLine();
                                                        Console.WriteLine("Enter balance: ");
                                                        double newBalance = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Enter type of an account: ");
                                                        string newAccType;
                                                        do
                                                        {
                                                            Console.WriteLine("1 = Admin\n2 = User. ");
                                                            newAccType = Console.ReadLine();
                                                            if (newAccType == "1")
                                                            {
                                                                Type newType = Type.Admin;
                                                                Account newAcc = new Account(newUsername, newPassword, newBalance, newType);
                                                                bank.AddAccount(newAcc);
                                                                Console.WriteLine("Account created successfully, details below:");
                                                                Console.WriteLine(newAcc);
                                                            }
                                                            else if (newAccType == "2")
                                                            {
                                                                Type newType = Type.User;
                                                                Account newAcc = new Account(newUsername, newPassword, newBalance, newType);
                                                                bank.AddAccount(newAcc);
                                                                Console.WriteLine("Account created successfully, details below:");
                                                                Console.WriteLine(newAcc);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Wrong number. Choose 1 or 2.");
                                                            }
                                                        } while (newAccType != "1" && newAccType != "2");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("You dont have permission to this option.");
                                                    }
                                                    break;
                                                case "14":  //usuwanie uzytkownika
                                                    Type RemoveUserType = acc1.GetAccType();
                                                    if (RemoveUserType == Type.Admin)
                                                    {
                                                        Console.WriteLine("What user do you want to remove?");
                                                        string removeUser = Console.ReadLine();
                                                        Account removeAcc = bank.FindAccount(removeUser); ;
                                                        if (removeAcc != null)
                                                        {
                                                            bank.RemoveAccount(removeAcc);
                                                            Console.WriteLine("Account " + removeAcc.GetUsername() + " has been removed");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Account " + removeUser + " didnt found.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("You dont have permission to this option.");
                                                    }
                                                    break;
                                                case "15":  //suma sald wszyskitch uzytkownikow
                                                    Type SumMoneyType = acc1.GetAccType();
                                                    if (SumMoneyType == Type.Admin)
                                                    {
                                                        bank.SumBalance();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("You dont have permission to this option.");
                                                    }
                                                    break;
                                                case "16":  //suma kredytow wszyskitch uzytkownikow
                                                    Type SumCreditType = acc1.GetAccType();
                                                    if (SumCreditType == Type.Admin)
                                                    {
                                                        bank.SumCredit();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("You dont have permission to this option.");
                                                    }
                                                    break;
                                                case "17":  //historia kredytowa
                                                    bank.CreditHistory(acc1);
                                                    break;
                                                case "18":  //historia dluznikow
                                                    bank.Debtor(acc1);
                                                    break;
                                                case "19":  //lista uzytkownikow
                                                    Type ListType = acc1.GetAccType();
                                                    if (ListType == Type.Admin)
                                                    {
                                                        Console.WriteLine(bank);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("You dont have permission to this option.");
                                                    }
                                                    break;
                                                case "20":  //wyjscie z programu
                                                    return;
                                                default:
                                                    Console.WriteLine("Wrong number. Type number in range between 1 to 20");
                                                    break;
                                            }
                                        }

                                        //Console.WriteLine(bank);

                                        //acc1.Balance();

                                        //bank.RemoveAccount(acc3);      //test usuwania uzytkownikow
                                        //Console.WriteLine(bank);     

                                        //Console.WriteLine(acc1);

                                        //acc1.Deposit(500);              //test wplacania pieniedzy
                                        //acc1.Deposit(500);
                                        //acc1.Deposit(500);
                                        //acc1.SumDeposit();              //test sumy wplaconych pieniedzy

                                        //acc1.Withdrawal(1000);          //test wyplacania pieniedzy
                                        //acc1.Withdrawal(100);
                                        //acc1.Withdrawal(100);
                                        //acc1.SumWithdrawal();           //test sumy wyplaconych pieniedzy

                                        //acc1.Credit(10000);             //test zaciagania kredytu
                                        //acc1.Credit(10000);
                                        //acc2.Credit(100);
                                        //bank.SumCredit();
                                        //acc1.PayOffCredit(6000);        //test splacania kredytu
                                        //acc1.PayOffCredit(4000);

                                        //acc1.Transfer(500, acc1, acc2); //test przelewu

                                        //bank.SumBalance();              //test sumowania sald wszyskitch uzytkownikow
                                        //bank.SumCredit();               //test sumowania kredytow wszyskitch uzytkownikow
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Wrong username or password! Try again!\n");
                                }
                            }
                            while (!((username == acc1.GetUsername()) && (password == acc1.GetPassword())));
                            break;
                        case "2":  //wyjscie z programu
                            Console.Clear();
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong number. Try again!\n");
                }
            } while (!(menuoption == "1") ^ (menuoption == "2"));
        }
    }
}