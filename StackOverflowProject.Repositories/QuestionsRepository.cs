using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Repositories
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question q);
        void UpdateQuestionDetails(Question q);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid,int value);
        void DeleteQuestion(int qid);
        List<Question> GetQuestions();
        List<Question> GetQuestionByQuestionID(int qid);
    }

    public class QuestionsRepository: IQuestionsRepository
    {
        StackOverflowDbContext db;

        public QuestionsRepository()
        {
            db = new StackOverflowDbContext();
        }

        public void InsertQuestion(Question q)
        {
            db.Questions.Add(q);
            db.SaveChanges();
        }

        public void UpdateQuestionDetails(Question q)
        {
            Question ques = db.Questions.Where(temp => temp.QuestionID == q.QuestionID).FirstOrDefault();
            if(ques!=null)
            {
                ques.QuestionName = q.QuestionName;
                ques.QuestionDateAndTime = q.QuestionDateAndTime;
                ques.CategoryID = q.CategoryID;
                db.SaveChanges();
            }
        }
        public void UpdateQuestionVotesCount(int qid,int value)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if(qt!=null)
            {
                qt.VotesCount += value;
                db.SaveChanges();
            }
        }


        public void UpdateQuestionAnswersCount(int qid,int value)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if(qt!=null)
            {
                qt.AnswersCount += value;
                db.SaveChanges();
            }

        }

        public void UpdateQuestionViewsCount(int qid,int value)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if(qt!=null)
            {
                qt.ViewsCount += value;
                db.SaveChanges();
            }

        }

        public void DeleteQuestion(int qid)
        {
            Question qt = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();

            if (qt != null)
            {

                db.Questions.Remove(qt);
                db.SaveChanges();
            }
        }

        public List<Question> GetQuestions()
        {
            List<Question> ques = db.Questions.OrderByDescending(temp => temp.QuestionDateAndTime).ToList();
            return ques;
        }

        public List<Question> GetQuestionByQuestionID(int qid)
        {
            List<Question> ques = db.Questions.Where(temp => temp.QuestionID == qid).ToList();
            return ques;
        }


    }
}
