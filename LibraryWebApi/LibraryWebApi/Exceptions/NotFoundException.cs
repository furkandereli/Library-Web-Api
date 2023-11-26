namespace LibraryWebApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id) : base($"Idsi {id} olan veri bulunamadı !") {}
    }
}
