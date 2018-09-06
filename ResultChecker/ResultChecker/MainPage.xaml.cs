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

        private CandidateRepository database = App.CandidateRepository;
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

        private  void SubmitButtonClicked(object sender, EventArgs e)
        {
            var examYear = ExamYearPicker.SelectedItem as string;
            var examType = ExamTypePicker.SelectedItem as string;

            var examNo = ExamNoEntry.Text;
            if (!(String.IsNullOrEmpty(examYear) || string.IsNullOrEmpty(examType) || string.IsNullOrEmpty(examNo))) { 
            
                List<Candidate> cand = database.GetResult(examType, Int32.Parse(examYear), examNo);
                if (cand.Count > 0)
                {
                    var cands = cand[0];

                    var page = new ResultDisplay();
                    page.BindingContext = cands;

                    Navigation.PushAsync(page);
                    ExamTypePicker.SelectedItem = null;
                    ExamYearPicker.SelectedItem = null;
                    ExamNoEntry.Text = null;
                }
                else
                {
                    DisplayAlert("Info", $"Result not found for candidate: {examNo} in {examType} {examYear}", "Ok");
                }
            }
            else
            {
                DisplayAlert("Error", $"Please complete all fields", "Ok");
            }

        }
	}
}
