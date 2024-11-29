using Backend_Test.Domain.Models;

namespace Backend_Test.Application.Interfaces
{
    public interface ICsvService
    {
        Task<byte[]> GenerateCsvReportAsync(int id);
    }
}
