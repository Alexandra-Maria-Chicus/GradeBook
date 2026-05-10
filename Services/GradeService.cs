using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

public class GradeService :  IGradeService
{
   private readonly IGradeReader _reader;
    public GradeService(IGradeReader reader)
    {
        _reader = reader;
    }

    public Task<IEnumerable<Grade>> GetAll()
    {
        return _reader.GetAllAsync();
    }

    public Task<Grade?> GetById(int id)
    {
        return _reader.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Grade>> GetTopN(int n)
    {
        var grades = await _reader.GetAllAsync();
        var topGrades = grades.Where(g => g.Value >= 5).Take(n);
        return topGrades;
    }
}