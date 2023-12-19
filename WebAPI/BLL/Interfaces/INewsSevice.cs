using BLL.DTOs;

namespace BLL.Interfaces;

public interface INewsSevice : IBaseService<NewsDTO>
{
    Task<IEnumerable<NewsDTO>> GetByRubricId(int id);
    Task<IEnumerable<NewsDTO>> GetByTagId(int id);
    Task<IEnumerable<NewsDTO>> GetByAuthorId(int id);
}
