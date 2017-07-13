using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiPto.Models;
using WebApiPto.DataClasses;

namespace WebApiPto.Classes
{
    public static class Mapper
    {


        public static PatientFormDto MapToDTO(PatientForm classMapFrom)
        {
            PatientFormDto retval = null;
            if (classMapFrom != null)
            {
                retval = new PatientFormDto
                {
                    PatientFormId = classMapFrom.PatientFormId,
                    PatientId = classMapFrom.PatientId,
                    FormTypeId = classMapFrom.FormTypeId,
                    FormTypeName = classMapFrom.FormType.FormTypeName,
                    CreatedOn = (DateTime)classMapFrom.CreatedOn,
                    LastUpdatedOn = classMapFrom.LastUpdatedOn
                };
            }
            return retval;
        }

        public static PatientForm MapFromDTO(PatientFormDto classMapFrom)
        {
            PatientForm retval = null;
            if (classMapFrom != null)
            {
                retval = new PatientForm
                {
                    PatientFormId = classMapFrom.PatientFormId,
                    PatientId = classMapFrom.PatientId,
                    FormTypeId = classMapFrom.FormTypeId,
                    CreatedOn = classMapFrom.CreatedOn,
                    LastUpdatedOn = (DateTime)classMapFrom.LastUpdatedOn
                };
            }
            return retval;
        }

        public static QuestionDto MapToDTO(Question classMapFrom)
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

        public static QuestionDto MapToDTO(AnswerListView classMapFrom)
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

        public static Question MapFromDTO(QuestionDto classMapFrom)
        {
            Question retval = null;
            if (classMapFrom != null)
            {
                retval = new Question
                {
                    //QuestionId = classMapFrom.QuestionId,
                    //FormTypeId = classMapFrom.FormTypeId,
                    //QuestionText = classMapFrom.QuestionText,
                    //DefaultAnswer = classMapFrom.DefaultAnswer,
                    //QuestionIndex = classMapFrom.QuestionIndex
                };
            }
            return retval;
        }

        public static FormTypeDto MapToDTO(FormType classMapFrom)
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

        public static PatientDto MapToDTO(PatientListView classMapFrom)
        {
            PatientDto retval = null;
            if (classMapFrom != null)
            {
                retval = new PatientDto
                {
                    Id = classMapFrom.PatientId,
                    LastName = classMapFrom.LastName,
                    FirstName = classMapFrom.FirstName,
                    LastVisitDate = (DateTime)classMapFrom.LastVisited
                };
            }
            return retval;
        }

        public static AnswerDto MapToDTO(Answer classMapFrom)
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

        public static Answer MapFromDTO(AnswerDto classMapFrom)
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