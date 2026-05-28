# TransQuik.Example

Консольное приложение, демонстрирующее работу с **TransToQuik**.

## Подготовка

1. Установите и запустите QUIK (см. [docs/QUIK_SETUP.md](../docs/QUIK_SETUP.md)).
2. Положите `trans2quik.dll` рядом с приложением — одним из способов:
   - **При сборке:** скопируйте в `libs/` — MSBuild положит DLL в `bin` рядом с `.exe`
   - **Вручную:** скопируйте в папку с `TransQuik.Example.exe`

   ```powershell
   Copy-Item "C:\QUIK Junior\trans2quik.dll" "..\libs\"
   ```

3. Создайте локальную конфигурацию:

   ```powershell
   Copy-Item appsettings.Development.json.example appsettings.Development.json
   ```

4. Укажите в `appsettings.Development.json`:
   - `Quik:Path` — каталог QUIK
   - `Quik:Account` — торговый счёт (см. [где взять Account](../docs/QUIK_SETUP.md#4-где-взять-торговый-счёт-account))
   - флаги `PlaceDemoOrder`, `PlaceDemoStopOrder`, `CancelLastOrder` — только если хотите отправлять реальные демо-транзакции

## Запуск

```bash
dotnet run --project TransQuik.Example/TransQuik.Example.csproj
```

Переменные окружения (префикс `TRANSTOQUIK_`):

```powershell
$env:TRANSTOQUIK_Quik__Path = "C:\QUIK Junior\"
$env:TRANSTOQUIK_Quik__PlaceDemoOrder = "false"
dotnet run --project TransQuik.Example/TransQuik.Example.csproj
```

## Что делает пример

1. Подключается к QUIK по указанному пути.
2. Подписывается на заявки и сделки по инструменту `ClassCode`/`SecCode`.
3. Опционально выставляет лимитную заявку, стоп-заявку и снимает последнюю заявку.
4. Выводит callback заявок и сделок в консоль до нажатия Enter.
