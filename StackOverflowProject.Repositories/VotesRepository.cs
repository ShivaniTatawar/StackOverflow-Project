﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Repositories
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);

    }



    public class VotesRepository : IVotesRepository
    {
        StackOverflowDbContext db;

        public VotesRepository()
        {
            db = new StackOverflowDbContext();


        }

        public void UpdateVote(int aid,int uid,int value)
        {
            int updateValue;
            if (value > 0) updateValue = 1;
            else if (value < 0) updateValue = -1;
            else updateValue = 0;
            Vote vote = db.Votes.Where(temp => temp.AnswerID == aid && temp.UserID == uid).FirstOrDefault();
            if (vote != null)
            {
                vote.voteValue = updateValue;
            }
            else
            {
                Vote newVote = new Vote() { AnswerID = aid, UserID = uid, voteValue = updateValue };
                db.Votes.Add(newVote);
            }
            db.SaveChanges();
            
        }
    }
}
