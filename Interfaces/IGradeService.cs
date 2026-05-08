using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Interfaces;

public interface IGradeService
{
    Task<IEnumerable<Grade>> GetAll();
    Task<Grade?> GetById(int id);

    Task<IEnumerable<Grade>> GetTopN(int n);
}
