using System;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Services
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback> GetFeedbackByCourseId(int courseId);
        IEnumerable<GetFeedback> GetFeedback(int userid);

        Feedback CreateFeedback(Feedback newfeedback);

    }
}