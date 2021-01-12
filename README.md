<h3 align="center">
  Gismeteo
</h3>
Состоит из 3 компонентов:

**Parser**
---
Консольное приложение для парсинга и сохранения в Бд данных о погоде за 10 дней
в популярных городах России. <img src="parser.png">
><br>При помощи HtmlAgilityPack вырезаем из html нужные нам данные
> и сохраняем в Бд.

**WEB API**
---
Web Api MVC имеет открытый метод, позволяющий делать запрос в БД и 
представление-клиент для обращения к этому методу и выводу bootstrap таблицы
с погодой из БД.

**WinForms Client**
---
Клиент WinForm для обращения к открытому методу Web Api и выводу полученной
информации.



`perlmodstyle`

- [`twitter-kv`](https://github.com/noffle/twitter-kv)

*([Submit a pull request](https://github.com/noffle/common-readme/pulls) and add
yours here!)*

    $ npm install -g common-readme

`common-readme`

