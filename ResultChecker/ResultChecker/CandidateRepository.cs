using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ResultChecker
{
    public class CandidateRepository
    {
        SQLiteAsyncConnection database;

        public CandidateRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Candidate>().Wait();
            
            
        }

        public async Task<int> AddCandidate(Candidate candidate)
        {
            return await database.InsertAsync(candidate);
        }

        public async Task<int> DeleteCandidate(Candidate candidate)
        {
            return await database.DeleteAsync(candidate);
        }

        public async Task<int> DeleteAllContact()
        {
            return await database.DropTableAsync<Candidate>();
        }

        public async Task<int> UpdateContact(Candidate candidate)
        {
            return await database.UpdateAsync(candidate);
        }

        public async Task<Candidate> GetContact(int id)
        {
            return await database.GetAsync<Candidate>(id);
        }

        public async Task<List<Candidate>> GetAllContactAsync()
        {
            return await database.Table<Candidate>().ToListAsync();
        }

        public  List<Candidate> GetResult(string examinationType, int examinationYear, string examinationNo)
        {
            List<Candidate> cand = new List<Candidate>();
            //try
            //{
            //    cand = await database.QueryAsync<Candidate>("select * from Candidate where examinationtype=? and examinationyear=? and examinationnumber=?", examinationType, examinationYear, examinationNo);
            //    foreach(Candidate candidate in cand)
            //    {

            //    }
            //}catch(IndexOutOfRangeException err)
            //{
            //    cand = new List<Candidate>();
            //    Console.WriteLine(err.Message);
            //}
            //return cand;
            if (examinationType.Equals("Nov/Dec") && examinationYear.Equals(2014) && examinationNo.Equals("5010101001"))
            {
                Candidate candidate = new Candidate(2014, "Nov/Dec", "5010101001", "tester's name", "male", "ojota snr", "101710221033104X105H1088110911111102");
                cand.Add(candidate);
            }
            
            return cand;
        }

    }
}
