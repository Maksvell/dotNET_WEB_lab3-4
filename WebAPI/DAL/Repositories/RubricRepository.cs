using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RubricRepository(NewsSiteContext context) : BaseRepository<Rubric>(context), IRubricRepository
{
}
