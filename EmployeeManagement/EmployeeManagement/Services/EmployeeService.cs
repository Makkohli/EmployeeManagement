
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using System.Net.Http.Json;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _http;

    public EmployeeService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<EmployeeDto>>("api/employees") ?? new List<EmployeeDto>();
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<EmployeeDto>($"api/employees/{id}");
    }

    public async Task<bool> AddAsync(EmployeeDto employee)
    {
        var response = await _http.PostAsJsonAsync("api/employees", employee);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(EmployeeDto employee)
    {
        var response = await _http.PutAsJsonAsync($"api/employees/{employee.Id}", employee);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/employees/{id}");
        return response.IsSuccessStatusCode;
    }
}