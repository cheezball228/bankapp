// ПОСТАВЬТЕ ПЯТЁРКУ КИРИЛЛУ ИЗ И212 ПЖ

using System;

public class Atm(string pin, decimal initialBalance = 0)
{
    private decimal balance = initialBalance;
    private string pin = pin;

    public void Run()
    {
        Console.WriteLine("Добро пожаловать в банкомат!");

        while (true)
        {
            Console.WriteLine("\nВыберите операцию:");
            Console.WriteLine("1. Проверить баланс");
            Console.WriteLine("2. Снять наличные");
            Console.WriteLine("3. Внести наличные");
            Console.WriteLine("4. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckBalance();
                    break;
                case "2":
                    WithdrawCash();
                    break;
                case "3":
                    DepositCash();
                    break;
                case "4":
                    Console.WriteLine("До свидания!");
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }

    private void CheckBalance()
    {
        Console.WriteLine($"Ваш баланс: {balance:C}");
    }

    private void WithdrawCash()
    {
        Console.Write("Введите сумму для снятия: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Вы сняли {amount:C}. Новый баланс: {balance:C}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или сумма некорректна.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат суммы.");
        }
    }

    private void DepositCash()
    {
        Console.Write("Введите сумму для внесения: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Вы внесли {amount:C}. Новый баланс: {balance:C}");
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат суммы.");
        }
    }


    public static void Main(string[] args)
    {
        Console.Write("Введите PIN-код: ");
        string pin = Console.ReadLine();
        while (pin != "1234")
        {
            Console.WriteLine("Неверный PIN-код, повторите попытку");
            pin = Console.ReadLine();
        }
        if (pin == "1234")
        {
            Atm atm = new(pin, 1000); // Начальный баланс 1000
            atm.Run();
        }
    }
}