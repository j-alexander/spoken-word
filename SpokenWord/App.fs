namespace SpokenWord

open System
open Xamarin.Forms

type App() =

    static let random = new Random()

    static member GetMainPage() =
        let speech = DependencyService.Get<Speech>()
        let words = Dictionary.randomizeWords |> Seq.toArray

        let wordLabel =
            new Label(
                Font=Font.SystemFontOfSize(22., FontAttributes.Bold),
                VerticalOptions=LayoutOptions.CenterAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand)
        let definitionLabel =
            new Label(
                VerticalOptions=LayoutOptions.CenterAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand)
        let repeatButton =
            new Button(
                Text="Repeat",
                VerticalOptions=LayoutOptions.CenterAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand)
        let displayButton =
            new Button(
                Text="Next",
                VerticalOptions=LayoutOptions.CenterAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand)

        let word = ref ""
        let definition = ref ""

        let sayInForeign() =
            speech.SayInForeign(!word)
        let sayInNative() =
            speech.SayInNative(!definition)

        let repeat _ =
            sayInForeign()
            sayInNative()
            sayInForeign()

        let chooseAWord _ =
            word := words.[random.Next(words.Length)]
            wordLabel.Text <- !word

            definition := Dictionary.definitionsFor !word |> String.concat ","
            definitionLabel.Text <- !definition

            repeat()

        chooseAWord()
        
        displayButton.Clicked.Add(chooseAWord)
        repeatButton.Clicked.Add(repeat)

        wordLabel.GestureRecognizers.Add(
            new TapGestureRecognizer(
                Command=new Command(sayInForeign)))
        definitionLabel.GestureRecognizers.Add(
            new TapGestureRecognizer(
                Command=new Command(sayInNative)))

        let commandStack =
            let layout =
                new StackLayout(
                    Orientation=StackOrientation.Horizontal)
            layout.Children.Add(repeatButton)
            layout.Children.Add(displayButton)
            layout

        let contentStack =
            let layout =
                new StackLayout(
                    Orientation=StackOrientation.Vertical)
            layout.Children.Add(wordLabel)
            layout.Children.Add(definitionLabel)
            layout.Children.Add(commandStack)
            layout

        new ContentPage(Content=contentStack)