CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Category" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Category" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Description" TEXT NOT NULL
);

CREATE TABLE "Clients" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Clients" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Phone" TEXT NOT NULL
);

CREATE TABLE "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Price" TEXT NOT NULL,
    "Description" TEXT NOT NULL,
    "CategoryId" INTEGER NOT NULL,
    CONSTRAINT "FK_Products_Category_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Category" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Orders" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY AUTOINCREMENT,
    "Date" TEXT NOT NULL,
    "Total" TEXT NOT NULL,
    "ClientId" INTEGER NOT NULL,
    CONSTRAINT "FK_Orders_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "Clients" ("Id") ON DELETE CASCADE
);

CREATE TABLE "OrderItem" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_OrderItem" PRIMARY KEY AUTOINCREMENT,
    "ProductId" INTEGER NOT NULL,
    "Quantity" INTEGER NOT NULL,
    "Total" TEXT NOT NULL,
    "OrderId" INTEGER NOT NULL,
    CONSTRAINT "FK_OrderItem_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_OrderItem_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_OrderItem_OrderId" ON "OrderItem" ("OrderId");

CREATE INDEX "IX_OrderItem_ProductId" ON "OrderItem" ("ProductId");

CREATE INDEX "IX_Orders_ClientId" ON "Orders" ("ClientId");

CREATE INDEX "IX_Products_CategoryId" ON "Products" ("CategoryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240718002601_Initial', '8.0.7');

COMMIT;

