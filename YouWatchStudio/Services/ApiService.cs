using System.Net.Http.Headers;

namespace YouWatchStudio.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5126/swagger/") // Alterar para endereço da API
            };
        }

        public void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> Login(string email, string password)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password)
            });

            return await _httpClient.PostAsync("auth/login", content);
        }

        public async Task<HttpResponseMessage> UploadFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                // Criação do conteúdo do formulário para upload de arquivos
                var content = new MultipartFormDataContent();
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = fileName
                };
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                content.Add(streamContent);

                // Envia o arquivo para o endpoint de upload (substitua '/upload' pela rota correta)
                var response = await _httpClient.PostAsync("/upload", content);

                return response;
            }
            catch (Exception ex)
            {
                // Aqui você pode registrar o erro ou lançar uma exceção personalizada
                throw new Exception($"Erro ao fazer upload do arquivo: {ex.Message}");
            }
        }
    }
}

