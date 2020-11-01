create table BasketItem(
   Id INT NOT NULL AUTO_INCREMENT,
   CustomerId INT NOT NULL,
   ProductId INT NOT NULL,
   ProductPrice DECIMAL(10,2),
   Quantity INT NOT NULL,
   PRIMARY KEY ( Id )
);