using Microsoft.AspNetCore.Components;
using WebAppRenderModes.Shared.Utilities;

namespace WebAppRenderModes.Client.Shared.Weather;

public partial class CountryFlagEmoji : ComponentBase
{
    [EditorRequired] [Parameter] public required string FipsCode { get; set; }

    private string _emojiFlag => GetEmojiFlag();

    private string GetEmojiFlag()
    {
        if (string.IsNullOrEmpty(FipsCode))
        {
            return string.Empty;
        }

        string isoCode = CountryCodeUtility.GetIsoCode(FipsCode);
        
        // Check for empty string or invalid ISO code
        if (isoCode.Length != 2) return string.Empty;

        isoCode = isoCode.ToUpper();
        
        // Emoji flags are composed of two regional indicator symbols
        // We need to convert each letter of the ISO code to the corresponding regional indicator symbol
        
        // Convert each letter to the regional indicator symbol
        int offset = 0x1F1E6 - 'A'; // Convert any uppercase English letter (A-Z) to it's corresponding regional indicator symbol
        var firstChar = char.ConvertFromUtf32(isoCode[0] + offset);
        var secondChar = char.ConvertFromUtf32(isoCode[1] + offset);

        return firstChar + secondChar;
    }
}