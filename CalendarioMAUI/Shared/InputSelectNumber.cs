using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace CalendarioMAUI.Shared
{
    public class InputSelectNumber<T> : InputSelect<T>
    {
        protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out T result, [NotNullWhen(false)] out string validationErrorMessage)
        {
            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (T)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "El número elegido no es un número valido";
                    return false;
                }

            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
            return base.TryParseValueFromString(value, out result, out validationErrorMessage);
        }
    }
}
