CREATE TABLE [dbo].[Tickets]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Placa] NVARCHAR(50) NOT NULL, 
    [FechaEntrada] DATETIME NOT NULL, 
    [FechaSalida] DATETIME NULL, 
    [CostoTotal] DECIMAL(10, 2) NULL
)

