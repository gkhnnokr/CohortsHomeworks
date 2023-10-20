/*
-- city tablosu ile country tablosunda bulunan şehir (city) ve ülke (country) isimlerini birlikte görebileceğimiz LEFT JOIN sorgusu
SELECT city.city, country.country FROM city
LEFT JOIN country ON city.country_id = country.country_id;
*/

/*
--customer tablosu ile payment tablosunda bulunan payment_id ile customer tablosundaki first_name ve last_name isimlerini birlikte görebileceğimiz RIGHT JOIN sorgusu
SELECT payment.payment_id, customer.first_name, customer.last_name FROM customer
RIGHT JOIN payment ON customer.customer_id = payment.customer_id;
*/

/*
-- FULL JOIN desteklenmediği için bu şekilde yapıldı
SELECT rental.rental_id, customer.first_name, customer.last_name
FROM customer
LEFT JOIN rental ON customer.customer_id = rental.customer_id

UNION ALL

SELECT rental.rental_id, customer.first_name, customer.last_name
FROM customer
RIGHT JOIN rental ON customer.customer_id = rental.customer_id;
*/