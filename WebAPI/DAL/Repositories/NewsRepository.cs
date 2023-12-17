using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class NewsRepository(NewsSiteContext context) : BaseRepository<News>(context), INewsRepository
{
}
