using Flurl;
using Flurl.Http;
using KinoPlus.Models;
using KinoPlus.WinUI.Extensions;
using KinoPlus.WinUI.Properties;

namespace eProdaja.WinUI
{
    public class APIService
    {
        private string _apiUrl = Settings.Default.ApiUrl;
        private string _resource { get; set; }
        public static string? Token { get; set; }
        public static List<MovieDto> Movies { get; set; } = new List<MovieDto>();

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async Task<T?> Get<T>(object? queryParams = null)
        {
            return await HandleApiResponseAsync<T>(async () =>
            {
                return await $"{_apiUrl}{_resource}".SetQueryParams(queryParams).WithOAuthBearerToken(Token).GetJsonAsync<T>();
            });
        }

        public async Task<T?> GetById<T>(object id)
        {
            return await HandleApiResponseAsync<T>(async () =>
            {
                return await $"{_apiUrl}{_resource}/{id}".WithOAuthBearerToken(Token).GetJsonAsync<T>();
            });
        }

        public async Task<T?> Post<T>(object data)
        {
            return await HandleApiResponseAsync<T>(async () =>
            {
                return await $"{_apiUrl}{_resource}".WithOAuthBearerToken(Token).PostJsonAsync(data).ReceiveJson<T>();
            });
        }

        public async Task<T?> Update<T>(int id, object data)
        {
            return await HandleApiResponseAsync<T>(async () =>
            {
                return await $"{_apiUrl}{_resource}/{id}".WithOAuthBearerToken(Token).PutJsonAsync(data).ReceiveJson<T>();
            });
        }

        public async Task<UserDto?> Login(string korisnickoIme, string password)
        {
            var login = new LoginDto
            {
                Username = korisnickoIme,
                Password = password,
            };

            var user = await HandleApiResponseAsync<UserDto>(async () =>
            {
                return await $"{_apiUrl}{_resource}/login".PostJsonAsync(login).ReceiveJson<UserDto>();
            });

            if (user == null)
                return null;

            Token = user.Token;
            return user;
        }

        private async Task<T?> HandleApiResponseAsync<T>(Func<Task<T>> apiCall)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var resource = await apiCall();
                Cursor.Current = Cursors.Arrow;

                return resource;
            }
            catch (FlurlHttpException ex)
            {
                var responseString = await ex.GetResponseStringAsync();

                if (responseString.IsJson())
                {
                    var error = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiException>(responseString);
                    if (!string.IsNullOrWhiteSpace(error?.Message))
                    {
                        MessageBox.Show(error.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var errorDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorDetails>(responseString);
                        MessageBox.Show(errorDetails!.ToErrorString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(responseString, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return default;
            }
        }
    }
}