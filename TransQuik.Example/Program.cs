using Microsoft.Extensions.Configuration;
using TransQuik.Example;
using TransToQuik;
using TransToQuik.Enums;
using TransToQuik.Extension;
using TransToQuik.Interfaces;
using TransToQuik.Models;
using TransToQuik.Models.Transactions;
using TransToQuik.Models.Transactions.KillTransaction;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables(prefix: "TRANSTOQUIK_")
    .Build();

var options = configuration.GetSection(QuikExampleOptions.SectionName).Get<QuikExampleOptions>()
    ?? throw new InvalidOperationException($"Section '{QuikExampleOptions.SectionName}' is missing in configuration.");

if (string.IsNullOrWhiteSpace(options.Path))
{
    throw new InvalidOperationException("Quik:Path must point to the QUIK installation directory.");
}

Console.WriteLine("TransToQuik example");
Console.WriteLine($"QUIK path: {options.Path}");
Console.WriteLine($"Instrument: {options.ClassCode}/{options.SecCode}");
Console.WriteLine();

using var client = QuikClientFactory.CreateClient();

if (!await TryConnect(client, options.Path))
{
    return 1;
}

var newOrderResult = default(QuikAsyncTransactionResult);
var lastResult = default(QuikAsyncTransactionResult);
var hasNewOrderResult = false;

if (options.PlaceDemoOrder)
{
    newOrderResult = await SendTransactionAsync(client, new QuikNewOrder
    {
        ClassCode = options.ClassCode,
        SecCode = options.SecCode,
        Account = options.Account,
        Operation = QuikOperation.Buy,
        Quantity = 1,
        Price = 1,
        PriceScale = 1,
        Type = QuikTypeOrder.Limit,
    });
    if (!newOrderResult.Success)
    {
        Console.WriteLine($"Error: {newOrderResult.ErrorKind} {newOrderResult.ResultMessage}");
        return 1;
    }
    hasNewOrderResult = true;
    PrintTransactionSummary(lastResult);
}

if (options.PlaceDemoStopOrder)
{
    lastResult = await SendTransactionAsync(client, new QuikSimpleStopOrder
    {
        ClassCode = options.ClassCode,
        SecCode = options.SecCode,
        Account = options.Account,
        Operation = QuikOperation.Buy,
        Quantity = 1,
        Price = 1,
        Type = QuikTypeOrder.Limit,
        StopPrice = 1,
    });
    PrintTransactionSummary(lastResult);
}

if (options.CancelLastOrder && hasNewOrderResult && newOrderResult.OrderNum > 0)
{
    lastResult = await SendTransactionAsync(client, new QuikKillOrderTransaction
    {
        ClassCode = options.ClassCode,
        SecCode = options.SecCode,
        Account = options.Account,
        OrderKey = newOrderResult.OrderNum,
    });
    PrintTransactionSummary(lastResult);
}

Console.WriteLine();
Console.WriteLine("Listening for order and trade callbacks. Press Enter to exit.");
Console.ReadLine();
return 0;

static async Task<bool> TryConnect(IQuikClient client, string quikPath)
{
    const int maxAttempts = 15;

    for (var attempt = 1; attempt <= maxAttempts; attempt++)
    {
        var result = client.Connection.Connect(quikPath);

        if (result.Success && client.Connection.Connected)
        {
            Console.WriteLine($"Connected (attempt {attempt}): {client.Connection.Status}");
            return true;
        }

        Console.WriteLine(
            $"Attempt {attempt}/{maxAttempts}: {result.ErrorKind}, QUIK={client.Connection.Status}, DLL={client.Connection.DLLConnected}");

        if (!string.IsNullOrWhiteSpace(result.Message))
        {
            Console.WriteLine($"  {result.Message}");
        }

        await Task.Delay(1000);
    }

    Console.Error.WriteLine();
    Console.Error.WriteLine("Не удалось подключиться к QUIK.");
    Console.Error.WriteLine("1. Запустите терминал QUIK и дождитесь подключения к серверу.");
    Console.Error.WriteLine("2. Сервис → Настройки → Торговля → включите «Внешние транзакции».");
    Console.Error.WriteLine("3. Запускайте QUIK и это приложение с одинаковыми правами (оба без администратора).");
    Console.Error.WriteLine("4. Проверьте Quik:Path в appsettings.Development.json.");
    Console.Error.WriteLine("5. Положите trans2quik.dll рядом с .exe (при сборке — из libs\\).");
    return false;
}

static async Task<QuikAsyncTransactionResult> SendTransactionAsync(IQuikClient client, QuikTransaction transaction)
{
    var result = await client.SendTransactionAsync(transaction);
    Console.WriteLine($"[{transaction.Action}] ErrorKind={result.ErrorKind}, OrderNum={result.OrderNum}");
    return result;
}

static void PrintTransactionSummary(QuikAsyncTransactionResult result) =>
    Console.WriteLine($"  Account={result.Account()}, Price={result.Price()}, Qty={result.Quantity()}, Balance={result.Balance()}");
