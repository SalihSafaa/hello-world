this ReadMe is gonna be split into 2 parts (the user part), and the dev part

//user

this project is a simple catalog for products and categories providing a way to :
1. Add Category
2. Add Product
3. List Products
4. List Products By Category
5. Search Products Bt name
6. Update Product
7. Delete Product with Confirmation (y/n)
8. Reports (Total Catalog Price, most expensive product, Out of stock Products, 
Average Category Price, Category Products Count)
0. Exit

//developer

this entire project is built over the course of 8 days,
started with basic knowledge of the C# .NET framwork and kept learning as i worked through the app; so you see many lines of code being commented out (old code replaced when i learned better way of doing the same thing)

used 2 json files as (mock db) to save and read data from (handled the IO exepction aswell) and made sure to not crash the app on the first run because the file doesn't exist yet

the code was rewritten many times each time considring more advanced concepts from datatypes to decision flow to OOP principals all the way to LINQ methods

i tried adding inheritance and abstract classes but it felt like overdoing it just to check the box so i sticked to using the interface and implementing it in the service


Folder Structure (this structure was AI Generated)
{
    ```text
    hello-world/
    |-- Helpers/
    |   |-- UI.cs
    |   |-- Validations.cs
    |-- Models/
    |   |-- Category.cs
    |   |-- IBaseEntity.cs
    |   |-- Product.cs
    |-- Services/
    |   |-- CatalogService.cs
    |   |-- ICatalogService.cs
    |-- Program.cs
    |-- hello world.csproj
    |-- README.md
    ```

    `Helpers` contains the menu and input validation code.
    `Models` contains the category, product, and base entity classes.
    `Services` contains the catalog interface and its implementation.
}

the app was fully built and functional using 
bash 
dotnet build

and runs normally using 
bash
dotnet run

the full journey of this small project was documented in github as commits check the link:

https://github.com/SalihSafaa/hello-world

