﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAssemble.Cloud;
using XamarinAssemble.Models;

namespace XamarinAssemble.ViewModels
{
    public class SpeakersViewModel : ViewModelBase
    {
        public Task Initialization { get; private set; }

        public SpeakersViewModel()
        {
            Speakers = new ObservableCollection<Speaker>();
            Title = "Speakers";
            Initialization = GetSpeakers();
            GetSpeakersCommand = new Command(async () => await GetSpeakers());
        }

        public ObservableCollection<Speaker> Speakers { get; set; }

        public Command GetSpeakersCommand { get; set; }

        private async Task GetSpeakers()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var items = await AzureDataManager.DefaultManager.GetSpeakersAsync();

                Speakers.Clear();

                foreach (var item in items)
                {
                    Speakers.Add(item);
                }
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }
    }
}
