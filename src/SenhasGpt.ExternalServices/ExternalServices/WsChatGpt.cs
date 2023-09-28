using SenhasGpt.Domain.Exceptions;
using SenhasGpt.Domain.IServices;
using SenhasGpt.Domain.Entidade;
using Newtonsoft.Json;
using System.Text;

namespace SenhasGpt.ExternalServices;

public class WsChatGpt : IWsChatGpt
{
    private readonly HttpClient _httpClient;

    public WsChatGpt(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void InjetarComfiguracao(SenhaGptConfiguracao config)
    {
        _httpClient.BaseAddress = new Uri(config.UrlBase);
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.ChaveAcesso}");
    }

    public async Task<string> ObterPalavrasSimilares(string palavraChave)
    {
        try
        {
            var requestData = new
            {
                model = "text-davinci-003",
                prompt = $"Generate an array with 5 words related to '{palavraChave}' in portuguese.",
                max_tokens = 50,
                temperature = 1,
            };

            var response = await _httpClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseObject = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                return responseObject?.choices[0].text ?? "";
            }

            throw new GptException("Erro ao integrar com chat gpt.");
        }
        catch (Exception)
        {
            throw new GptException("Erro ao integrar com chat gpt.");
        }
    }
}
