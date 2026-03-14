# AoT Test App

This test app follows this tutorial: https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/prepare-libraries-for-trimming#show-all-warnings-with-test-app

## Usage

```bash
dotnet publish
# If you do not have the signing key
dotnet publish --configuration Debug
```

There should be no trim related warning produced when publishing. If there are
then those need to be resolved. If we run this in CI, then we should have a script
like [this](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/build%2Fscripts%2Ftest-aot-compatibility.ps1)
to count and assert on the number of warnings.

Then run the published output to validate trimmed code still works:

```bash
./bin/Release/net8.0/<rid>/publish/AotCompatibility.TestApp
# If you do not have the signing key
./bin/Debug/net8.0/<rid>/publish/AotCompatibility.TestApp
```

The application should print `Success!` and exit with code 0 if all tests pass.
If it encountered an error it will print the error and exit with code 1.
