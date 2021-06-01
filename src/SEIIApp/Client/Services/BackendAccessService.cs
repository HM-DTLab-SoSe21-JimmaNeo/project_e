﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SEIIApp.Shared.DomainDto;

namespace SEIIApp.Client.Services
{
    public class BackendAccessService
    {
        private HttpClient HttpClient { get; set; }

        public BackendAccessService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        private string GetUrlWithId(int id)
        {
            return $"api/users/{id}";
        }

        private string GetUrlBasic()
        {
            return "api/users";
        }

        public async Task<StudentDto> GetStudentById(int id)
        {
            return await HttpClient.GetFromJsonAsync<StudentDto>(GetUrlWithId(id));
        }

        public async Task<StudentDto> GetStudentByNameAndPw(string name, string pw)
        {
            var response = await HttpClient.GetAsync($"api/users?name={name}&password={pw}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StudentDto>();
            }

            return null;
        }

        public async Task<bool> UploadContentFile(ContentDto entryFile)
        {
            var response = await HttpClient.PutAsJsonAsync("api/content", entryFile);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<ContentDto> GetContentById(int id)
        {
            return await HttpClient.GetFromJsonAsync<ContentDto>($"api/content/{id}");
        }

        public async Task<ContentDto[]> GetAllContent()
        {
            return await HttpClient.GetFromJsonAsync<ContentDto[]>("api/content");
        }
    }
}