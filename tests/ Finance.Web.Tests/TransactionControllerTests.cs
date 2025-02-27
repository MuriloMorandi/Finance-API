using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Finance.Domain.Entities;
using Finance.Domain.Enums;
using Finance.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

public class TransactionControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TransactionControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostTransaction_ShouldReturnOk()
    {
        var transaction = new TransactionDTO("description",10,DateTime.Now,"Credit");
        
        var response = await _client.PostAsJsonAsync("/api/transaction", transaction);
        
        response.EnsureSuccessStatusCode();
    }
}