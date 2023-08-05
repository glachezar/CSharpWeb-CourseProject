namespace MyGarage.Web.Infrastructure.ModelBinders
{
    using System.Globalization;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (result != ValueProviderResult.None 
                && !string.IsNullOrWhiteSpace(result.FirstValue))
            {
                decimal parsedValue = 0m;
                bool success = false;

                try
                {
                    string formDecimalValue = result.FirstValue;
                    formDecimalValue = formDecimalValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    formDecimalValue = formDecimalValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    parsedValue = Convert.ToDecimal(formDecimalValue);
                    success = true;
                }
                catch (FormatException fe)
                { 
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}
