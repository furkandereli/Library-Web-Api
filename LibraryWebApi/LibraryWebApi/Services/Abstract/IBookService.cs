using LibraryWebApi.Dtos.Requests;
using LibraryWebApi.Dtos.Responses;
using LibraryWebApi.ReturnModels;

namespace LibraryWebApi.Services.Abstract
{
    public interface IBookService
    {
        ReturnModel<List<BookDto>> GetList();
        ReturnModel<BookDto> Add(CreateBookRequestDto requestDto);
        ReturnModel<BookDto> Update(UpdateBookRequestDto requestDto);
        ReturnModel<BookDto> Delete(int id);
        ReturnModel<BookDto> GetById(int id);
    }
}
