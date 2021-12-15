﻿// <copyright file="ApiService.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TimerApp.ViewModels;

    /// <summary>
    /// API Service class.
    /// </summary>
    public class ApiService : ITimerService
    {
        private readonly string url = "http://localhost:32930/api/timeritems";
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<TimerItemViewModel>> GetTimers()
        {
            // HttpClient httpClient = new HttpClient();
            using (HttpResponseMessage response = await this.httpClient.GetAsync(this.url).ConfigureAwait(false))
            {
                // Make sure we were successful and, if so, parse the JSON data into a structure.
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<ObservableCollection<TimerItemViewModel>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                return result;
            }
        }

        public async Task<TimerItemViewModel> GetTimer(int id)
        {
            using (HttpResponseMessage response = await this.httpClient.GetAsync(this.url + $"/{id}").ConfigureAwait(false))
            {
                // Make sure we were successful and, if so, parse the JSON data into a structure.
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<TimerItemViewModel>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                return result;
            }
        }

        async Task ITimerService.AddTimer(TimerItemViewModel timerItemViewModel)
        {
            using (HttpResponseMessage response = await this.httpClient.PostAsync(this.url, new StringContent(
                JsonConvert.SerializeObject(timerItemViewModel), Encoding.UTF8, "application/json")).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        async Task ITimerService.DeleteTimer(TimerItemViewModel timerItemViewModel)
        {
            using (HttpResponseMessage response = await this.httpClient.DeleteAsync(this.url + $"/{timerItemViewModel.Id}").ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        async Task ITimerService.UpdateTimer(TimerItemViewModel timerItemViewModel)
        {
            using (HttpResponseMessage response = await this.httpClient.PutAsync(this.url+$"/{timerItemViewModel.Id}", new StringContent(
                JsonConvert.SerializeObject(timerItemViewModel), Encoding.UTF8, "application/json")).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
