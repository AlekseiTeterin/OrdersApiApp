# OrdersApiApp

Техническое задание:
API "Заказы".
БД содержит 4 таблицы:
1) Товар - содержит id, наименование товар, артикул (число) - 
2) Заказ - содержит id, id клиента (связь), описание заказа (description)
3) Расшивка заказ-товар - содержит id, id товара (связь), id заказа (связь), кол-во единиц товара
4) Клиент - содержит id, имя клиента

-----
Необходимо реализовать Web API для CRUD-операций в указанной модели данных.
CRUD - create read update delete

ЗАДАНИЕ
1. Реализовать базовый CRUD в виде API для всех сущностей
2. Реализовать возможность получения полной информации о заказе со списком товаров и кол-ве товаров в нем
3. Реализовать запрос "Чек", который пречисляет товары в заказе и суммирует их стоимость в общую сумму
4. Реализовать возможность удаления заказа вместе со всеми записями расшивки и клиента (
	цепочка удаления должна работать при удалении любой из записей вышепеерчисленных таблиц
)

# Приложение развёрнуто на amvera, БД используется облачная, ссылка:
## https://ordersapiapp-lyaksey777.amvera.io

- тестирование операций с таблицей клиента
     /client/all (/get, /add, /delete, /update)
- тестирование операций с таблицей заказа
     /order/all (/get, /add, /delete, /update)
- тестирование операций с таблицей продукта
     /product/all (/get, /add, /delete, /update)
- тестирование операций с таблицей заказ-товар
     /order_product/all (/get, /add, /delete, /update)

- тестирование запроса на получение информации о товаре 
     /order/info
- тестирование запроса на получение чека с заказом
     /order/check

