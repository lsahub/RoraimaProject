# RoraimaProject

Стукртура проекта

-RoraimaFront: фронт на react hook + redux

-RoraimaProject: бекэнд на .net api core 3.1. - пушится в docker hub как public репозитарий. см docker-compose.yml

-MS SQL: База должна подняться из файлов при запуске docker-compose + в папке data/backup есть последний бекап базы. 

-RoraimaProjectTests: тесты котроллеров

-elastic search: поиск сделан на основе elastic search

-docker-compose.yml: упаковано все через docker-compose

Запускать: docker-compose up --build

Для запуска сервисов потребуется какое-то время

Для проверки можно использовать:

-сервис бекэнда: http://localhost:6533/api/test

-сервис elastic search http://localhost:5601/

-фронт http://localhost:3000/

конект к базе из хостовой машины по адресу localhost,6462 

Логин SA

пароль StrongPassword@123
