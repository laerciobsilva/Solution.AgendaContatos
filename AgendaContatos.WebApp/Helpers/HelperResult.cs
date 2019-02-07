using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace AgendaContatos.WebApp.Helpers
{
    public static class HelperResult
    {
        public static string GetErrorModel(this ModelStateDictionary modelState)
        {

            var errors = new StringBuilder();


            foreach (var model in modelState)
            {
                foreach (var erro in model.Value.Errors)
                {
                    if (errors.Length > 0)
                    {
                        errors.Append($" / {erro.ErrorMessage}");
                    }
                    else
                    {
                        errors.Append($"{erro.ErrorMessage}");
                    }
                }
            }

            return errors.ToString();

        }
    }
}
