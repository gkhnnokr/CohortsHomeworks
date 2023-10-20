
--test veritabanınızda employee isimli sütun bilgileri id(INTEGER), name VARCHAR(50), birthday DATE, email VARCHAR(100) olan bir tablo oluşturalım.
 CREATE TABLE employee (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50),
    birthday DATE,
    email VARCHAR(100)
); 

  --Oluşturduğumuz employee tablosuna 'Mockaroo' servisini kullanarak 50 adet veri ekleyelim.
INSERT INTO employee (id, name, birthday, email) 
VALUES 
(1, 'John Doe', '1980-01-01', 'johndoe@example.com'),
(2, 'Jane Smith', '1985-05-15', 'janesmith@example.com'),
(3, 'Robert Johnson', '1990-07-20', 'robertjohnson@example.com'),
(4, 'Susan Brown', '1975-03-10', 'susanbrown@example.com'),
(5, 'Michael Wilson', '1982-11-30', 'michaelwilson@example.com'),
(6, 'Linda Anderson', '1988-08-12', 'lindaanderson@example.com'),
(7, 'William Lee', '1995-04-05', 'williamlee@example.com'),
(8, 'Karen Hall', '1987-06-25', 'karenhall@example.com'),
(9, 'David Clark', '1989-09-18', 'davidclark@example.com'),
(10, 'Sarah White', '1984-02-15', 'sarahwhite@example.com'),
(11, 'Richard Martin', '1983-10-22', 'richardmartin@example.com'),
(12, 'Patricia Taylor', '1992-12-05', 'patriciataylor@example.com'),
(13, 'James Moore', '1978-07-08', 'jamesmoore@example.com'),
(14, 'Nancy Davis', '1994-03-03', 'nancydavis@example.com'),
(15, 'Charles Allen', '1991-09-14', 'charlesallen@example.com'),
(16, 'Jennifer Hall', '1981-04-28', 'jenniferhall@example.com'),
(17, 'Matthew Scott', '1986-06-17', 'matthewscott@example.com'),
(18, 'Laura Adams', '1987-01-29', 'lauraadams@example.com'),
(19, 'Christopher Baker', '1993-08-04', 'christopherbaker@example.com'),
(20, 'Maria Martinez', '1980-11-11', 'mariamartinez@example.com'),
(21, 'Daniel Mitchell', '1984-07-19', 'danielmitchell@example.com'),
(22, 'Lisa Green', '1990-02-09', 'lisagreen@example.com'),
(23, 'Joseph Lewis', '1982-05-16', 'josephlewis@example.com'),
(24, 'Betty King', '1992-03-22', 'bettyking@example.com'),
(25, 'David Johnson', '1981-12-03', 'davidjohnson@example.com'),
(26, 'Cynthia Davis', '1985-09-27', 'cynthiadavis@example.com'),
(27, 'William Robinson', '1993-01-14', 'williamrobinson@example.com'),
(28, 'Karen Wright', '1986-03-08', 'karenwright@example.com'),
(29, 'Mark Brown', '1977-08-01', 'markbrown@example.com'),
(30, 'Donna Moore', '1991-06-09', 'donnamoore@example.com'),
(31, 'Michael Wilson', '1988-02-25', 'michaelwilson@example.com'),
(32, 'Sandra Taylor', '1990-04-14', 'sandrataylor@example.com'),
(33, 'Charles Thomas', '1983-05-07', 'charlesthomas@example.com'),
(34, 'Elizabeth Wilson', '1979-10-10', 'elizabethwilson@example.com'),
(35, 'Matthew Walker', '1984-12-17', 'matthewwalker@example.com'),
(36, 'Nancy Harris', '1992-06-03', 'nancyharris@example.com'),
(37, 'Kevin Moore', '1980-08-29', 'kevinmoore@example.com'),
(38, 'Carol Anderson', '1985-02-12', 'carolanderson@example.com'),
(39, 'Edward Martinez', '1986-09-08', 'edwardmartinez@example.com'),
(40, 'Donna Allen', '1993-11-24', 'donnaallen@example.com'),
(41, 'John Young', '1988-03-18', 'johnyoung@example.com'),
(42, 'Linda White', '1990-07-28', 'lindawhite@example.com'),
(43, 'Robert Thomas', '1981-01-26', 'robertthomas@example.com'),
(44, 'Mary Moore', '1987-04-19', 'marymoore@example.com'),
(45, 'James Davis', '1992-05-31', 'jamesdavis@example.com'),
(46, 'Karen Thompson', '1979-10-15', 'karenthompson@example.com'),
(47, 'Joseph Harris', '1984-12-21', 'josephharris@example.com'),
(48, 'Maria Anderson', '1990-06-23', 'mariaanderson@example.com'),
(49, 'David Garcia', '1985-02-07', 'davidgarcia@example.com'),
(50, 'Susan Taylor', '1983-09-11', 'susantaylor@example.com'); 



UPDATE employee  --name sütunu "John Doe" olan tüm kayıtların birthday sütunundaki değerini güncelle
SET birthday = '1990-01-15'
WHERE name = 'John Doe';

UPDATE employee  --birthday sütunu "1992-03-22" olan tüm kayıtların name sütunundaki değerini güncelle
SET name = 'Betty King'
WHERE birthday = '1992-03-22';

UPDATE employee  --email sütunu "johndoe@example.com" olan tüm kayıtların name sütunundaki değerini güncelle
SET name = 'John Smith'
WHERE email = 'johndoe@example.com';

UPDATE employee  --name sütunu "Jane Smith" olan tüm kayıtların email sütunundaki değerini güncelle
SET email = 'janesmith@example.net'
WHERE name = 'Jane Smith';

UPDATE employee  --email sütunu "robertjohnson@example.com" olan tüm kayıtların birthday sütunundaki değerini güncelle
SET birthday = '1995-11-30'
WHERE email = 'robertjohnson@example.com';

DELETE FROM employee  --name sütunu "John Doe" olan tüm kayıtları silelim
WHERE name = 'John Doe';

DELETE FROM employee  --birthday sütunu "1992-03-22" olan tüm kayıtları silelim
WHERE birthday = '1992-03-22';

DELETE FROM employee  --email sütunu "johndoe@example.com" olan tüm kayıtları silelim
WHERE email = 'johndoe@example.com';

DELETE FROM employee  --name sütunu "Jane Smith" olan tüm kayıtları silelim
WHERE name = 'Jane Smith';

DELETE FROM employee --birthday sütunu "1985-05-15" olan tüm kayıtları silelim
WHERE birthday = '1985-05-15';