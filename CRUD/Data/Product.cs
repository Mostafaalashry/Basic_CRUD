using System;
namespace CRUD.Data
{

	public class Product
	{
        public required int Id { set; get; }
        public required string Name { set; get; }
        public required string Sku { set; get; }
    }
}

