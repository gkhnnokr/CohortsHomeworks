/* --country tablosunda bulunan country sütunundaki ülke isimlerinden 'A' karakteri ile başlayıp 'a' karakteri ile sonlananlar
SELECT country FROM country
WHERE country LIKE 'A%a' */

/* --country tablosunda bulunan country sütunundaki ülke isimlerinden en az 6 karakterden oluşan ve sonu 'n' karakteri ile sonlananlar
SELECT country FROM country
WHERE LENGTH(country) >= 6 AND RIGHT(country, 1) = 'n' */

/* --film tablosunda bulunan title sütunundaki film isimlerinden en az 4 adet büyük ya da küçük harf farketmesizin 'T' karakteri içeren film isimler
SELECT title FROM film
WHERE LOWER(title) LIKE '%t%t%t%t%' OR UPPER(title) LIKE '%T%T%T%T%'; */

/* --film tablosunda bulunan tüm sütunlardaki verilerden title 'C' karakteri ile başlayan ve uzunluğu (length) 90 dan büyük olan ve rental_rate 2.99 olan veriler
SELECT * FROM film
WHERE title LIKE 'C%' AND length > 90 AND rental_rate = 2.99; */