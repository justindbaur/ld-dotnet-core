using LaunchDarkly.Sdk;

try
{
    var expectedJson = """
    {"kind":"user","key":"test"}
    """;
    var contextJson = Context.New(ContextKind.Default, "test").ToString();
    if (contextJson != expectedJson)
    {
        throw new Exception($"Actual Json: '{contextJson}' does not match expected json: '{expectedJson}'");
    }

    var ldValueString = "[1,2]";
    var ldValue = LdValue.Parse(ldValueString);
    
    var actualLdValueString = ldValue.ToJsonString();
    if (actualLdValueString != ldValueString)
    {
        throw new Exception($"Actual: '{actualLdValueString}' Expected: {ldValueString}");
    }

    var expectedEvaluationDetail = "ERROR(FLAG_NOT_FOUND)";

    var actualEvaluationDetail = EvaluationReason.ErrorReason(EvaluationErrorKind.FlagNotFound).ToString();

    if (actualEvaluationDetail != expectedEvaluationDetail)
    {
        throw new Exception($"Actual: '{actualEvaluationDetail}' Expected: '{expectedEvaluationDetail}'");
    }

    Console.WriteLine("Success!");
    return 0;
}
catch (Exception ex)
{
     Console.WriteLine(ex);
     return 1;
}
