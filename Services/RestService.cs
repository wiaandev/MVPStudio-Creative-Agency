﻿using Microsoft.VisualBasic;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace MVPStudio_Creative_Agency.Services
{
    public class StaffRestService : IRestService
    {
        //Our httpClient
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        //List of Items
        public List<Employee> Items { get; private set; }

        //Constructor - Creating our httpClient
        public StaffRestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        // POST linked with modal
        //pass employe in
        public async Task<bool> PostEmployeeAsync(Employee employee)
        {
            Uri uri = new Uri(baseUrl + "Employees");

            try
            {
                string json = JsonSerializer.Serialize(employee, _serializerOptions);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //post hier leke
                HttpResponseMessage response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    // Employee was successfully created on the server
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"\tERROR: Unable to post employee data.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<List<Employee>> RefreshDataAsync()
        {
            Items = new List<Employee>();

            Uri uri = new(string.Format(baseUrl + "Employees", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Employee>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            Employee employee = null;

            Uri uri = new Uri(string.Format(baseUrl + "Employees/{0}", id));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    employee = JsonSerializer.Deserialize<Employee>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return employee;
        }
        
        
        
    }
}
