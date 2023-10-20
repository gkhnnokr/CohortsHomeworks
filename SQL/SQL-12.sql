/*
-- film tablosunda film uzunluğu length sütununda gösterilmektedir. Uzunluğu ortalama film uzunluğundan fazla kaç tane film vardır
SELECT COUNT(*) AS film_sayisi FROM film
WHERE length > (SELECT AVG(length) FROM film);
*/

/*
-- film tablosunda en yüksek rental_rate değerine sahip kaç tane film vardır
SELECT COUNT(*) AS film_sayisi FROM film
WHERE rental_rate = (SELECT MAX(rental_rate) FROM film);
*/

/*
-- film tablosunda en düşük rental_rate ve en düşün replacement_cost değerlerine sahip filmleri sırala
SELECT * FROM film
WHERE rental_rate = (SELECT MIN(rental_rate) FROM film)
  AND replacement_cost = (SELECT MIN(replacement_cost) FROM film);
*/

/*
-- payment tablosunda en fazla sayıda alışveriş yapan müşterileri(customer) sırala
SELECT customer_id, COUNT(payment_id) AS alisveris_sayisi FROM payment
GROUP BY customer_id
ORDER BY alisveris_sayisi DESC;
*/
