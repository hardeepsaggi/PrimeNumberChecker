@echo off

REM Build the entire solution
dotnet build /p:ExcludeProjects= PrimeNumberChecker.Tests/PrimeNumberChecker.Tests.csproj


PAUSE
