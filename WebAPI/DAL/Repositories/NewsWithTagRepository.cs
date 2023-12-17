using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories;

public class NewsWithTagRepository(NewsSiteContext context) : BaseRepository<NewsWithTag>(context), INewsWithTagRepository
{
}
