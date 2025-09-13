using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGHT = 250; // константа максимальной длинны заголовка книги
        public const int MAX_DESCRIPTION_LENGHT = 250; // константа максимальной длинны описания книги

        // Инициализация внутри класса
        private Book(Guid id, string title, string decription, decimal price)
        {
            this.id = id;
            this.title = title;
            this.description = decription;
            this.price = price;
        }

        // свойства Book
        public Guid id { get; }
        public string title { get; } = string.Empty;
        public string description { get; } = string.Empty;
        public decimal price { get; }

        // Валидация заголовка
        public static (Book Book, string Error) Create(Guid id, string title, string decription,  decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGHT)
            {
                error = "Title cannot be empty or longer then 250 symbols. ";
            }
            if (string.IsNullOrEmpty(decription) || decription.Length > MAX_DESCRIPTION_LENGHT)
            {
                error = "Description cannot be empty or longer then 250 symbols. ";
            }
            if (price < 0) // Нельзя ввести отрицательное значение цены книги
            {
                error = "Price can not be < 0";
            }

            var book = new Book(id, title, decription, price); // создаем новый эземпляр книги и отправляем его

            return (book, error);
        }
    }
}
