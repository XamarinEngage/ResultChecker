using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResultChecker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultDisplay : ContentPage
	{
		public ResultDisplay ()
		{
			InitializeComponent ();
            //Candidate cand = BindingContext as Candidate;s
            //PopulateResults(cand);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateResults();
        }


        void PopulateResults()
        {
            var cand = this.BindingContext as Candidate;

            List<Grade> grade = cand.Grades;

            for(int i = 0; i < grade.Count; i++)
            {
                Grade score = grade[i];
                ResultGrid.Children.Add(new Label
                {
                    Text = score.Subject,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 15
                }, 0, i);

                ResultGrid.Children.Add(new Label
                {
                    Text = score.Score,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 15
                }, 1, i);
            }
        }

        private void CloseButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void PrintButtonClicked(object sender, EventArgs e)
        {

        }
	}
}