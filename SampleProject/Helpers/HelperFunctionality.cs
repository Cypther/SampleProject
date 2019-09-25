using SampleProject.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Helpers
{
    public static class HelperFunctionality
    {
        public static List<ErrorModelView> GetModelStateErrors(ModelStateDictionary ModelState)
        {
            var errors = ModelState.Where(m => m.Value.Errors.Count > 0).ToList();

            List<ErrorModelView> errorModel = new List<ErrorModelView>();
            foreach (var e in errors)
            {
                errorModel.Add(new ErrorModelView
                {
                    Key = e.Key,
                    Value = e.Value.Errors.FirstOrDefault().ErrorMessage
                });
            }
            return errorModel;
        }
    }
}