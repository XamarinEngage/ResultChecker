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

        //private CandidateRepository database = App.CandidateRepository;
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

            Loader.IsRunning = true;
            
            var examYear = ExamYearPicker.SelectedItem as string;
            var examType = ExamTypePicker.SelectedItem as string;

            var examNo = ExamNoEntry.Text;
            if (!(String.IsNullOrEmpty(examYear) || string.IsNullOrEmpty(examType) || string.IsNullOrEmpty(examNo))) {

                //List<Candidate> cand = database.GetResult(examType, Int32.Parse(examYear), examNo);
                Candidate candidate = await App.Service.GetResult(examYear, examType, examNo);
                if (candidate != null)
                {
                    //var cands = cand[0];

                    var page = new ResultDisplay();
                    page.BindingContext = candidate;

                    await Navigation.PushAsync(page);
                    ExamTypePicker.SelectedItem = null;
                    ExamYearPicker.SelectedItem = null;
                    ExamNoEntry.Text = null;
                    Loader.IsRunning = false;
                }
                else
                {
                    Loader.IsRunning = false;
                    await  DisplayAlert("Info", $"Result not found for candidate: {examNo} in {examType} {examYear}", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", $"Please complete all fields", "Ok");
            }

        }
	}
}
