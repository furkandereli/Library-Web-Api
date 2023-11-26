using AutoMapper;
using LibraryWebApi.BusinessRules;
using LibraryWebApi.Dtos.Requests;
using LibraryWebApi.Dtos.Responses;
using LibraryWebApi.Exceptions;
using LibraryWebApi.Models;
using LibraryWebApi.Repositories.Abstract;
using LibraryWebApi.ReturnModels;
using LibraryWebApi.Services.Abstract;

namespace LibraryWebApi.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly BookRules _bookRules;

        public BookService(IBookRepository bookRepository, IMapper mapper, BookRules bookRules)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookRules = bookRules;
        }

        public ReturnModel<BookDto> Add(CreateBookRequestDto requestDto)
        {
            try
            {
                Book book = _mapper.Map<Book>(requestDto);

                _bookRules.BookNameMustBeUnique(requestDto.Title);
                _bookRules.BookIsExpensive(book);

                _bookRepository.Add(book);

                BookDto response = _mapper.Map<BookDto>(book);

                ReturnModel<BookDto> result = new ReturnModel<BookDto>()
                {
                    Data = response,
                    Message = "Kitap başarıyla eklendi !",
                    StatusCode = System.Net.HttpStatusCode.Created
                };

                return result;
            }
            catch (BusinessException ex)
            {
                return new ReturnModel<BookDto>()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }     
        }

        public ReturnModel<BookDto> Delete(int id)
        {
            try
            {       
                var book = _bookRepository.GetById(id);

                _bookRules.BookIsPresent(book.Id);
                
                _bookRepository.Delete(id);
                
                var response = _mapper.Map<BookDto>(book);

                return new ReturnModel<BookDto>()
                {   
                    Data = response, 
                    Message = $"Idsi : {id} olan kitap kaydı başarıyla silindi !",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }

            catch (NotFoundException ex)
            {
                return new ReturnModel<BookDto>()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
        }

        public ReturnModel<BookDto> GetById(int id)
        {
            try
            {
                var book = _bookRepository.GetById(id);

                _bookRules.BookIsPresent(book.Id);

                BookDto response = _mapper.Map<BookDto>(book);

                return new ReturnModel<BookDto>()
                {
                    Data = response,
                    Message = "Verdiğiniz idye ait kitap getirildi !",
                    StatusCode = System.Net.HttpStatusCode.OK
                };

            }
            catch(NotFoundException ex)
            {
                return new ReturnModel<BookDto>()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
        }

        public ReturnModel<List<BookDto>> GetList()
        {
            var bookList = _bookRepository.GetList();
            List<BookDto> response = _mapper.Map<List<BookDto>>(bookList);

            return new ReturnModel<List<BookDto>>()
            {
                Data = response,
                Message = "Kitaplar listelendi !",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public ReturnModel<BookDto> Update(UpdateBookRequestDto requestDto)
        {
            try
            {
                var book = _mapper.Map<Book>(requestDto);

                _bookRules.BookNameMustBeUnique(book.Title);
                _bookRules.BookIsExpensive(book);

                _bookRepository.Update(book);

                var response = _mapper.Map<BookDto>(book);

                return new ReturnModel<BookDto>()
                {
                    Data = response,
                    Message = $"{response.Id}ye ait kayıt güncellendi",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (NotFoundException ex)
            {
                return new ReturnModel<BookDto>()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
        }
    }
}
