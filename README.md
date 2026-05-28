# TransToQuik

[![CI](https://github.com/ZylAlexander/TransToQuik/actions/workflows/ci.yml/badge.svg)](https://github.com/ZylAlexander/TransToQuik/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/TransToQuik.svg)](https://www.nuget.org/packages/TransToQuik/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Типобезопасная **.NET**-библиотека для работы с [TRANS2QUIK API](https://arqatech.com/ru/support/files/) терминала **QUIK**: подключение, отправка транзакций, подписка на заявки и сделки.

> **Важно:** пакет NuGet содержит только управляемый код. Нативная библиотека `trans2quik.dll` поставляется вместе с QUIK и должна быть доступна в каталоге приложения. См. [настройку QUIK](docs/QUIK_SETUP.md).

## Возможности

- Подключение к запущенному терминалу QUIK по пути к каталогу установки
- Синхронные и асинхронные транзакции (лимитные заявки, стоп-заявки, снятие заявок)
- Подписка на потоки заявок и сделок с типизированными моделями
- Строгая валидация параметров транзакций до отправки в QUIK
- Расширения для чтения дополнительных полей из callback-дескрипторов

## Требования

| Компонент | Версия |
|-----------|--------|
| .NET | 9.0+ |
| ОС | Windows (x86/x64 — как у установленного QUIK) |
| QUIK | Установленный терминал с включёнными внешними транзакциями |
| `trans2quik.dll` | Из каталога QUIK (см. [docs/QUIK_SETUP.md](docs/QUIK_SETUP.md)) |

### Торговый счёт (`Account`)

В заявках указывается поле **`Account`** — торговый счёт для транзакции (не логин QUIK и не «код клиента» демо).

**Где посмотреть в терминале:** Торговля → Заявка (при выборе `ClassCode` / `SecCode`), или в таблице заявок / разделе счетов. Подробнее — [Где взять Account](docs/QUIK_SETUP.md#4-где-взять-торговый-счёт-account).

## Установка

```bash
dotnet add package TransToQuik
```

## Быстрый старт

```csharp
using TransToQuik;
using TransToQuik.Enums;
using TransToQuik.Models.Transactions;

var client = QuikClientFactory.CreateClient();
var connect = client.Connect(@"C:\QUIK\");
if (!connect.Success)
{
    throw new InvalidOperationException($"QUIK connect failed: {connect.ErrorKind}");
}

client.SubscribeOrders(b => b.Add("QJSIM", "VTBR"));
client.StartOrders(new MyOrderHandler());

var order = new QuikNewOrder
{
    ClassCode = "QJSIM",
    SecCode = "VTBR",
    Account = "YOUR_ACCOUNT",
    Operation = QuikOperation.Buy,
    Quantity = 1,
    Price = 100.0,
    Type = QuikTypeOrder.Limit,
};

var result = await client.SendTransactionAsync(order);
Console.WriteLine($"Status: {result.ErrorKind}, OrderNum: {result.OrderNum}");
```

Полный рабочий пример — в проекте [`TransQuik.Example`](TransQuik.Example/README.md).

### Ограничения процесса

- **Один активный `QuikClient` на процесс** — все экземпляры делят подключение к QUIK, `trans2quik.dll` и таблицу ожиданий async-ответов (`TRANS_ID`).
- Дополнительные поля заявок, сделок и ответов на транзакцию доступны через `Details` / `Reply` (снимок в callback), а не через «живой» дескриптор QUIK.
- Точность цены в транзакции: свойство **`PriceScale`** (как `scale` в `getSecurityInfo`). См. [QUIK_SETUP.md — формат PRICE](docs/QUIK_SETUP.md#5-точность-цены-price-stopprice).

Подробнее о singleton/static и вариантах развития — [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md).

Личные заметки (пароли, пути к QUIK) — в папке [`notes/`](notes/README.md) (файлы `*.local.md` не попадают в git).

## Структура репозитория

```
TransToQuik/
├── TransToQuik/          # NuGet-библиотека
├── TransToQuik.Tests/    # Unit-тесты (Moq + xUnit)
├── TransQuik.Example/    # Консольный пример
├── docs/                 # Документация по настройке QUIK
└── .github/workflows/    # CI и публикация в NuGet
```

## Сборка из исходников

```bash
git clone https://github.com/ZylAlexander/TransToQuik.git
cd TransToQuik

# Скопируйте trans2quik.dll из каталога QUIK (для примера)
copy "%QUIK_PATH%\trans2quik.dll" libs\

dotnet build TransToQuik.sln
dotnet test TransToQuik.Tests/TransToQuik.Tests.csproj
```

Запуск примера:

```bash
cd TransQuik.Example
copy appsettings.Development.json.example appsettings.Development.json
# отредактируйте путь к QUIK и торговые параметры
dotnet run
```

## Публикация NuGet

Релизы публикуются автоматически при создании тега `v*.*.*` (см. [`.github/workflows/release.yml`](.github/workflows/release.yml)).

Для публикации в [nuget.org](https://www.nuget.org/) добавьте секрет репозитория `NUGET_API_KEY`.

## Участие в разработке

См. [CONTRIBUTING.md](CONTRIBUTING.md).

## Лицензия

Код библиотеки распространяется по [MIT](LICENSE).  
`trans2quik.dll` и терминал QUIK — продукты [АРКА Технологии](https://arqatech.com/); их использование регулируется их лицензией.

## Отказ от ответственности

Проект не связан с АРКА Технологии и не является официальным SDK. Используйте на свой риск, особенно на реальных торговых счетах.
