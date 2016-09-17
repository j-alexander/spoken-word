namespace SpokenWord

open System
open UIKit
open Foundation
open Xamarin.Forms

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()

    let window = new UIWindow (UIScreen.MainScreen.Bounds)

    override this.FinishedLaunching (app, options) =
        Forms.Init()
        window.RootViewController <- App.GetMainPage().CreateViewController()
        window.MakeKeyAndVisible()
        true