using Siemens.Internship2026.GradeBook.DTOs;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class GradeRepository : IGradeReader
{
    private readonly HttpClient _httpClient;

    public GradeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    private async Task<List<Grade>> FetchGradesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<GradeResponse>("https://gist.githubusercontent.com/ArdeleanTudor/8ea407832cd9794960e0e6bbd1319f6e/raw");
        return response?.Items ?? new List<Grade>();
    }
    public async Task<Grade?> GetByIdAsync(int id)
    {
        var response = await FetchGradesAsync();
        return response.Where(g => g.IsActive).FirstOrDefault(g => g.Id == id);
    }

    public async Task<IEnumerable<Grade>> GetAllAsync()
    {
        var response = await FetchGradesAsync();
        return response.Where(g => g.IsActive);
    }
}
