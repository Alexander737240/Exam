CREATE DATABASE BookStoreDB;
GO

USE BookStoreDB;
GO

CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    Publisher NVARCHAR(255),
    Pages INT CHECK (Pages > 0),
    Genre NVARCHAR(100),
    Year INT CHECK (Year >= 1000 AND Year <= YEAR(GETDATE())),
    CostPrice DECIMAL(10,2) CHECK (CostPrice >= 0),
    SalePrice DECIMAL(10,2) CHECK (SalePrice >= 0),
    Quantity INT CHECK (Quantity >= 0)
);
GO

INSERT INTO Books (Title, Author, Publisher, Pages, Genre, Year, CostPrice, SalePrice, Quantity)
VALUES
(N'Война и мир',N'Лев Толстой', N'Азбука', 864, N'Классика', 1869, 500.00, 700.00, 10),
(N'Преступление и наказание', N'Федор Достоевский', N'Русский Печатник', 576, N'Классика', 1866, 400.00, 600.00, 5),
(N'Мастера и Маргарита', N'Михаил Булгаков', N'Эксмо', 480, N'Роман', 1966, 350.00, 550.00, 8),
(N'Властелин колец', N'Дж.Р.Р. Толкин', N'HarperCollins', 1216, N'Фэнтези', 1954, 1200.00, 1500.00, 3),
(N'Маленький принц', N'Антуан де Сент-Экзюпери', N'Gallimard', 96, N'Детская литература', 1943, 250.00, 400.00, 20);
GO