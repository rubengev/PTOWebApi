using System;
using WebApiPto.Models;
using WebApiPto.DataClasses;

namespace WebApiPto.Classes
{
    public static class Mapper
    {


        public static PatientFormDto MapToDto(PatientForm classMapFrom)
        {
            PatientFormDto retval = null;
            if (classMapFrom != null)
            {
                retval = new PatientFormDto
                {
                    Id = classMapFrom.PatientFormId,
                    PatientId = classMapFrom.PatientId,
                    FormTypeId = classMapFrom.FormTypeId,
                    FormTypeName = classMapFrom.FormType.FormTypeName,
                    VisitDate = classMapFrom.CreatedOn ?? DateTime.Now
                };
            }
            return retval;
        }

        public static PatientForm MapFromDto(PatientFormDto classMapFrom)
        {
            PatientForm retval = null;
            if (classMapFrom != null)
            {
                retval = new PatientForm
                {
                    PatientFormId = classMapFrom.Id,
                    PatientId = classMapFrom.PatientId,
                    FormTypeId = classMapFrom.FormTypeId,
                    CreatedOn = classMapFrom.VisitDate,
                    LastUpdatedOn = DateTime.Now
                };
            }
            return retval;
        }

        public static QuestionDto MapToDto(Question classMapFrom)
        {
            QuestionDto retval = null;
            if (classMapFrom != null)
            {
                retval = new QuestionDto
                {
                    Id = classMapFrom.QuestionId,
                    Index = classMapFrom.QuestionIndex,
                    Question = classMapFrom.QuestionText,
                    Type = classMapFrom.QuestionType,
                    Checked = classMapFrom.DefaultAnswer,
                    Answer = ""
                };
            }
            return retval;
        }

        public static QuestionDto MapToDto(AnswerListView classMapFrom)
        {
            QuestionDto retval = null;
            if (classMapFrom != null)
            {
                retval = new QuestionDto
                {
                    Id = classMapFrom.QuestionId,
                    Index = classMapFrom.QuestionIndex,
                    Question = classMapFrom.QuestionText,
                    Type = classMapFrom.QuestionType,
                    Checked = classMapFrom.AnswerChecked,
                    Answer = classMapFrom.AnswerText
                };
            }
            return retval;
        }

        //public static Question MapFromDto(QuestionDto classMapFrom)
        //{
        //    Question retval = null;
        //    if (classMapFrom != null)
        //    {
        //        retval = new Question
        //        {
        //            //QuestionId = classMapFrom.QuestionId,
        //            //FormTypeId = classMapFrom.FormTypeId,
        //            //QuestionText = classMapFrom.QuestionText,
        //            //DefaultAnswer = classMapFrom.DefaultAnswer,
        //            //QuestionIndex = classMapFrom.QuestionIndex
        //        };
        //    }
        //    return retval;
        //}

        public static FormTypeDto MapToDto(FormType classMapFrom)
        {
            FormTypeDto retval = null;
            if (classMapFrom != null)
            {
                retval = new FormTypeDto
                {
                    FormTypeId = classMapFrom.FormTypeId,
                    FormTypeName = classMapFrom.FormTypeName
                };
            }
            return retval;
        }

        public static PatientDto MapToDto(PatientListView classMapFrom)
        {
            PatientDto retval = null;
            if (classMapFrom != null)
            {
                retval = new PatientDto
                {
                    Id = classMapFrom.PatientId,
                    LastName = classMapFrom.LastName,
                    FirstName = classMapFrom.FirstName,
                    LastVisitDate = classMapFrom.LastVisited ?? DateTime.Now
                };
            }
            return retval;
        }

        public static AnswerDto MapToDto(Answer classMapFrom)
        {
            AnswerDto retval = null;
            if (classMapFrom != null)
            {
                retval = new AnswerDto
                {
                    AnswerId = classMapFrom.AnswerId,
                    PatientFormId = classMapFrom.PatientFormId,
                    QuestionId = classMapFrom.QuestionId,
                    AnswerChecked = classMapFrom.AnswerChecked,
                    AnswerText = classMapFrom.AnswerText,
                    Question = classMapFrom.Question.QuestionText
                };
            }
            return retval;
        }

        public static Answer MapFromDto(AnswerDto classMapFrom)
        {
            Answer retval = null;
            if (classMapFrom != null)
            {
                retval = new Answer
                {
                    AnswerId = classMapFrom.AnswerId,
                    PatientFormId = classMapFrom.PatientFormId,
                    QuestionId = classMapFrom.QuestionId,
                    AnswerChecked = classMapFrom.AnswerChecked,
                    AnswerText = classMapFrom.AnswerText
                };
            }
            return retval;
        }

    }
}