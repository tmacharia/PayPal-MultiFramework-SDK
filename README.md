<p align="center">
  <img height="100" src="https://raw.githubusercontent.com/devTimmy/PayPal-MultiFramework-SDK/master/paypal-logo.png" 
			 alt="PayPal logo" title="PayPal logo">
</p>

# MultiFramework PayPal .NET SDK
Multi-framework PayPal SDK for .NET developers targeting different frameworks and run-times e.g .NET Framework, .NET Core, and .NETStandard 

[![Build status](https://ci.appveyor.com/api/projects/status/pp4hovop0ye54dav?svg=true)](https://ci.appveyor.com/project/devTimmy/paypal-multiframework-sdk)
![Nuget](https://img.shields.io/nuget/v/PayPal.MultiTarget.svg?logo=nuget&link=https://www.nuget.org/packages/PayPal.MultiTarget/1.0.0//left)
![SDK Downloads on Nuget](https://img.shields.io/nuget/dt/PayPal.MultiTarget.svg?color=%23009be1&label=downloads&logo=nuget&link=https://www.nuget.org/packages/PayPal.MultiTarget/1.0.0//left)

## Notice

It is important to note that the original SDK was written by the original developers i.e [PayPal](https://github.com/paypal) and their repository can be found [here](https://github.com/paypal/PayPal-NET-SDK) if any questions arise.

This version transforms the original code in order to target other frameworks such as .NET Standard & Core which are not factored for in the original source code.

## Usage

Install the SDK package from Nuget by running the following command in Package Manager Console.

```bash
Install-Package PayPal.MultiTarget -Version 1.0.1-beta1
```
Once installed, you need to define the configuration file from which the package will read settings from. If you have a Web.config or App.config file, just copy the settings below and them to your file, otherwise create a new App.Config file in the root folder of your application and add this settings therein. 

*N.B* Set the _Build Action_ property of the config file to _Content_ and _Copy To Output Directory_ property to _Copy always_ so that the file is available when you build your project.

```xml
<configSections>
    <section name="paypal" type="PayPal.SDKConfigHandler, PayPal.MultiTarget"/>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net"/>
  </configSections>
  
  <!-- PayPal SDK config -->
  <paypal>
    <settings>
      <add name="mode" value="sandbox"/>
      <add name="connectionTimeout" value="360000"/>
      <add name="requestRetries" value="3"/>
      <add name="clientId" value="AYrAaReQUybACfY3NJNZ1CNpbf8IdERKSHvA-urkP5G8YXzJd2khdkD8LT2WpDMUhXjn8NPl4sTFnYa2"/>
      <add name="clientSecret" value="EObW1isFRDZKO6xe2FvpwABDdOsGrhrsKqMrWzSC4Ndz8k5WeYnpYofCm9EAdibSEBv5Gel6J86TzENj"/>
    </settings>
  </paypal>

  <log4net>
    <appender name="FileAppender" type="log4net.Appender.FileAppender">
      <file value="PayPal.TestingLog.log"/>
      <appendToFile value="true"/>
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] %message%newline"/>
      </layout>
    </appender>
    <root>
      <level value="DEBUG"/>
      <appender-ref ref="FileAppender"/>
    </root>
  </log4net>

  <appSettings>
    <add key="PayPalLogger" value="PayPal.Log.Log4netLogger"/>
    <add key="PayPalLogger.Delimiter" value="|" />
  </appSettings>
```
Replace the *clientId* and *clientSecret* with your own keys from [PayPal Developer Account](https://developer.paypal.com) and change the *mode* from _sandbox_ to _live_ when you everything is working for you and the application is ready to go into production.

## Targets

+ NET Framework 4.0
+ NET Framework 4.5
+ NET Framework 4.5.1
+ NET Framework 4.6.1
+ NET Framework 4.6.2
+ NET Core 2.0
+ NET Standard 2.0
