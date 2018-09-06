using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ResultChecker
{
	public partial class App : Application
	{

        private static CandidateRepository candidateRepository = null;

        public static CandidateRepository CandidateRepository
        {
            get
            {
                if (candidateRepository == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Candidates.db");
                    candidateRepository = new CandidateRepository(dbPath);
                }
                return candidateRepository;
            }

        }

        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage( new ResultChecker.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
