/*
-- actor ve customer tablolarında bulunan first_name sütunları için tüm verileri sırala
SELECT first_name FROM actor
UNION
SELECT first_name FROM customer;
*/

/*
-- actor ve customer tablolarında bulunan first_name sütunları için kesişen verileri sırala
SELECT actor.first_name FROM actor
INNER JOIN customer ON actor.first_name = customer.first_name;
*/

/*
-- actor ve customer tablolarında bulunan first_name sütunları için ilk tabloda bulunan ancak ikinci tabloda bulunmayan veriler
SELECT actor.first_name FROM actor
LEFT JOIN customer ON actor.first_name = customer.first_name
WHERE customer.first_name IS NULL;
*/

