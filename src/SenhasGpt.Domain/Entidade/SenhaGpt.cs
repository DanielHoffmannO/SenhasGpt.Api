using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace SenhasGpt.Domain.Entidade;
public class SenhaGpt : Entity<SenhaGpt, short>
{
    public SenhaGpt(string palavraChave)
    {
        PalavraChave = palavraChave;
        DataCadastro = DateTime.Now;
    }

    public string PalavraChave { get; set; }
    public string SenhaGerada { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataVigencia { get; set; }

    public void AdicionarNumerais()
    {
        if (SenhaGerada.Length < 14)
        {
            var caracteresFaltantes = 14 - SenhaGerada.Length;

            var random = new Random();
            var senhaBuilder = new StringBuilder(SenhaGerada);

            for (int i = 0; i < caracteresFaltantes; i++)
            {
                char numeroAleatorio = (char)random.Next('0', '9' + 1);
                senhaBuilder.Append(numeroAleatorio);
            }

            SenhaGerada = senhaBuilder.ToString();
        }
    }

    public void AumentarComplexidade()
    {
        var complexPassword = new StringBuilder(SenhaGerada.Length);
        var random = new Random();
        var substitutions = new Dictionary<char, string[]>
    {
        { 'a', new string[] { "@", "4", "A" } },
        { 'e', new string[] { "3", "8", "&" } },
        { 'i', new string[] { "!", "1", "|" } },
        { 'o', new string[] { "0", "O" } },
    };

        foreach (char c in SenhaGerada)
            if (substitutions.ContainsKey(c))
            {
                string[] possibleSubstitutions = substitutions[c];
                string randomSubstitution = possibleSubstitutions[random.Next(possibleSubstitutions.Length)];
                complexPassword.Append(randomSubstitution);
            }
            else
                complexPassword.Append(c);

        SenhaGerada = complexPassword.ToString();
    }



    public void ConcatenarPalavras(string input) =>
        SenhaGerada = RemoverAcentosEspecial(ConcatenarPalavras(ConverterStringArrey(input)));

    private static string RemoverAcentosEspecial(string input)
    {
        var sb = new StringBuilder();
        foreach (char c in input.Normalize(NormalizationForm.FormD))
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark &&
                (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
                sb.Append(c);

        return sb.ToString();
    }

    private static string[] ConverterStringArrey(string input)
    {
        var regex = new Regex("'(.*?)'");
        var matches = regex.Matches(input);

        var words = new string[matches.Count];

        for (int i = 0; i < matches.Count; i++)
            words[i] = matches[i].Groups[1].Value;

        return words;
    }

    private static string ConcatenarPalavras(string[] palavras)
    {
        var palavras1 = new string[palavras.Length];
        for (int i = 0; i < palavras.Length; i++)
            palavras1[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavras[i].ToLower());

        var random = new Random();
        int indiceAleatorio1 = random.Next(palavras.Length);
        int indiceAleatorio2;
        do
        {
            indiceAleatorio2 = random.Next(palavras.Length);
        } while (indiceAleatorio2 == indiceAleatorio1);

        return palavras1[indiceAleatorio1] + palavras1[indiceAleatorio2];
    }
}
