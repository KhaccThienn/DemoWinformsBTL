CREATE DATABASE db_Library_Mgmt
GO

USE db_Library_Mgmt
GO

-- Tạo bảng Tác Giả
CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Birthdate DATE,
    Nationality NVARCHAR(100)
);

-- Tạo bảng Danh Mục
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500)
);


-- Tạo bảng Sách
CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    AuthorID INT FOREIGN KEY REFERENCES Authors(AuthorID),
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    ISBN NVARCHAR(20),
    Edition INT,
    Year INT,
    Genre NVARCHAR(100),
    Quantity INT
);


-- Tạo bảng Độc Giả
CREATE TABLE Readers (
    ReaderID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    StudentID NVARCHAR(50) NOT NULL UNIQUE,
    Address NVARCHAR(255),
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    IDCard NVARCHAR(50)
);

-- Tạo bảng Phiếu Mượn
CREATE TABLE Loans (
    LoanID INT PRIMARY KEY IDENTITY(1,1),
    BookID INT FOREIGN KEY REFERENCES Books(BookID),
    ReaderID INT FOREIGN KEY REFERENCES Readers(ReaderID),
    LoanDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    ReturnDate DATE
);

-- Tạo bảng Thẻ Thư Viện
CREATE TABLE Cards (
    CardID INT PRIMARY KEY IDENTITY(1,1),
    ReaderID INT FOREIGN KEY REFERENCES Readers(ReaderID),
    IssueDate DATE NOT NULL,
    ExpiryDate DATE
);
