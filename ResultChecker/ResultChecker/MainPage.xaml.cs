using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ResultChecker
{
	public partial class MainPage : ContentPage
	{
        private List<String> ExamYear = new List<string>();
        private List<String> ExamType = new List<string>();

        public MainPage()
		{
			InitializeComponent();
            PopulatePicker();
		}

        void PopulatePicker()
        {
            ExamType.Add("May/June");
            ExamType.Add("Nov/Dec");
            ExamType.Add("School cand");
            ExamType.Add("Private cand");
            ExamYear.Add("2001");
            ExamYear.Add("2002");
            ExamYear.Add("2015");
            ExamYear.Add("2014");
            
            ExamYear.Sort();
            ExamType.Sort();

            ExamTypePicker.ItemsSource = ExamType;
            ExamYearPicker.ItemsSource = ExamYear;

            

        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            SubmitButton.IsEnabled = false;
            
            
            var examYear = ExamYearPicker.SelectedItem as string;
            var examType = ExamTypePicker.SelectedItem as string;

            var examNo = ExamNoEntry.Text;

            //if all fields are filled
            if (!(String.IsNullOrEmpty(examYear) || string.IsNullOrEmpty(examType) || string.IsNullOrEmpty(examNo))) {
                Loader.IsRunning = true;
                //if internet connection is available 
                if (CrossConnectivity.Current.IsConnected)
                {
                    Candidate candidate = await App.Service.GetResult(examYear, examType, examNo);

                    //if candidate result is available
                    if (candidate != null)
                    {

                        var page = new ResultDisplay();
                        page.BindingContext = candidate;

                        await Navigation.PushAsync(page);
                        ExamTypePicker.SelectedItem = null;
                        ExamYearPicker.SelectedItem = null;
                        ExamNoEntry.Text = null;
                        Loader.IsRunning = false;
                        SubmitButton.IsEnabled = true;
                    }
                    else
                    {
                        Loader.IsRunning = false;
                        SubmitButton.IsEnabled = true;
                        await DisplayAlert("Info", $"Result not found for candidate: {examNo} in {examType} {examYear}", "Ok");
                    }
                }
                else
                {
                    Loader.IsRunning = false;
                    SubmitButton.IsEnabled = true;
                    await DisplayAlert("Error", "Unable to connect to server.\n Check your device's internet connectivity", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please complete all fields", "Ok");
                Loader.IsRunning = false;
                SubmitButton.IsEnabled = true;
            }

        }
	}
}
