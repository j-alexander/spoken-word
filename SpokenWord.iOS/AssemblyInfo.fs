namespace SpokenWord.AssemblyInfo

open System.Resources
open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

[<assembly: AssemblyTitle("SpokenWord.iOS")>]
[<assembly: AssemblyCompany("lambda-fun.com")>]
[<assembly: AssemblyProduct("SpokenWord")>]
[<assembly: AssemblyCopyright("Copyright ©2016 Jonathan Leaver")>]
[<assembly: NeutralResourcesLanguage("en")>]

[<assembly: Xamarin.Forms.Dependency(typeof<SpokenWord.SiriSpeech>)>]

do ()