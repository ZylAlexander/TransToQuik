# Участие в проекте

Спасибо за интерес к TransToQuik!

## Как предложить изменение

1. Форкните репозиторий и создайте ветку от `main`.
2. Внесите изменения с понятными коммитами.
3. Убедитесь, что проходят проверки локально:

   ```bash
   dotnet build TransToQuik.sln -c Release
   dotnet test TransToQuik.Tests/TransToQuik.Tests.csproj -c Release --no-build
   ```

4. Откройте Pull Request с описанием **что** изменено и **зачем**.

## Стиль кода

- Следуйте [.editorconfig](.editorconfig) в корне репозитория.
- Публичные API — с XML-документацией, где это уместно.
- Не коммитьте секреты, пароли, пути к личным счетам, `appsettings.Development.json` и файлы `notes/*.local.md`.

## Тесты

- Новая логика в `TransToQuik` — с unit-тестами в `TransToQuik.Tests`.
- Интеграционные тесты с реальным QUIK в CI не запускаются.

## Версионирование

Проект следует [Semantic Versioning](https://semver.org/). Версия задаётся в `TransToQuik/TransToQuik.csproj` и дублируется тегом `v1.2.3` при релизе.

## Вопросы

Используйте [Issues](https://github.com/ZylAlexander/TransToQuik/issues) для багов и предложений.
