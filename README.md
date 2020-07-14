# Serverless.WebApi #

Serverless.WebApi is an experiment in deploying an ASP.NET Core WebApi as a serverless application to AWS Lambda. It is intended to be used as an example for learning purposes.

## Prerequisites ##

- An AWS account with programmatic access enabled
- A S3 bucket to store your deployment packages
- [AWS Extensions for .NET CLI](https://github.com/aws/aws-extensions-for-dotnet-cli)

You can quickly install the AWS Extensions for .NET CLI for this project by running;

```
dotnet tool restore
```

## How does this work? ##

In short a package, `Amazon.Lambda.AspNetCoreServer` is installed in the WebApi project and a separate application entry point using this package, [*LambdaEntryPoint.cs*](Sources/Serverless.WebApi/LambdaEntryPoint.cs) is created for AWS Lambda. AWS Lambda uses this entry point to your application instead of the conventional [*Program.cs*](Sources/Serverless.WebApi/Program.cs). The WebApi is configured and deployed as a serverless application by using a AWS Serverless Application Model (SAM) [template](Sources/Serverless.WebApi/template.json).

## Deploying the WebApi as a Serverless Application ##

Change into the [project directory](Sources/Serverless.WebApi) of the WebApi and run;

```
dotnet lambda deploy-serverless
```

By default this command reads values provided in the file [*aws-lambda-tools-defaults.json*](Sources/Serverless.WebApi/aws-lambda-tools-defaults.json). If there are any required values that are missing, you will be prompted for them.

## More Resources ##
- [AWS Lambda for .NET Core](https://github.com/aws/aws-lambda-dotnet)
- [AWS Serverless Application Model (AWS SAM)](https://github.com/awslabs/serverless-application-model)
- [SAM CLI](https://github.com/awslabs/aws-sam-cli)
