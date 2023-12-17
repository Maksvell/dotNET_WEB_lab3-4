using BLL.DTO;

namespace BLL.DTOs;

internal class NewsWithTagDTO : BaseDTO
{
    public int TagId { get; set; }
    public int NewsId { get; set; }
}
