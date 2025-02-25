public string CleanInput(string input)
{
    return HttpUtility.HtmlEncode(input); // Potansiyel zararlı karakterleri encode eder
}
