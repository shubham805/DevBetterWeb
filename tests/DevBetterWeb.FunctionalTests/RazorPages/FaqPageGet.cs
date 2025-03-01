﻿using System.Net.Http;
using System.Threading.Tasks;
using DevBetterWeb.Web;
using Xunit;

namespace DevBetterWeb.FunctionalTests.RazorPages;

public class FaqPageGet : IClassFixture<CustomWebApplicationFactory<Startup>>
{
  private readonly HttpClient _client;

  public FaqPageGet(CustomWebApplicationFactory<Startup> factory)
  {
    _client = factory.CreateClient();
  }

  [Theory]
  [InlineData("/FAQ")]
  [InlineData("/faq")]
  public async Task ReturnsViewWithCorrectMessage(string route)
  {
    HttpResponseMessage response = await _client.GetAsync(route);
    response.EnsureSuccessStatusCode();
    string stringResponse = await response.Content.ReadAsStringAsync();

    Assert.Contains("Wondering if devBetter is a good fit for you?", stringResponse);
  }
}
