using LibraryWebApi.Exceptions;
using LibraryWebApi.Models;
using LibraryWebApi.Repositories.Abstract;

namespace LibraryWebApi.BusinessRules
{
    public class BookRules
    {
        private readonly IBookRepository _bookRepository;

        public BookRules(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void BookIsExpensive(Book book)
        {
            decimal maxPrice = 250.0m;

            if (book.Price > maxPrice)
                throw new BusinessException("Kitaplar bu kadar pahalı olmamalı. Maksimum değer 250 !");
        }

        public void BookIsPresent(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
                throw new BusinessException($"{id}ye ait kitap bulunamadı !");
        }

        public void BookNameMustBeUnique(string title)
        {
            var book = _bookRepository.GetByTitle(title);

            if (book != null)
                throw new BusinessException("Kitap ismi unique olmalıdır !");
        }
    }
}
