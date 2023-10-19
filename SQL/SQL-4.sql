/* --film tablosunda bulunan replacement_cost sütununda bulunan birbirinden farklı değerler
SELECT DISTINCT replacement_cost FROM film; */

/* --film tablosunda bulunan replacement_cost sütununda birbirinden farklı veri
SELECT COUNT(DISTINCT replacement_cost) FROM film; */

/* --film tablosunda bulunan film isimlerinde (title) kaç tanesini T karakteri ile başlar ve aynı zamanda rating 'G' ye eşit
SELECT COUNT(*) FROM film
WHERE title LIKE 'T%' AND rating = 'G'; */

/* --country tablosunda bulunan ülke isimlerinden (country) kaç tanesi 5 karakterden oluşmaktadır
SELECT COUNT(*) FROM country 
WHERE LENGTH(country) = 5 */

/* --city tablosundaki şehir isimlerinin kaç tanesi 'R' veya r karakteri ile biter
SELECT COUNT(*) FROM city
WHERE city LIKE '%r' OR  city LIKE '%R' */
