namespace SpokenWord

open System
open System.IO
open System.Reflection

module Dictionary =

    let csv = 
        let resource = "Dictionary.csv"
        let assembly = typeof<Speech>.GetTypeInfo().Assembly
        let stream = assembly.GetManifestResourceStream(resource)
        use reader = new StreamReader(stream)
        reader.ReadToEnd()

    let entries =
        csv.Split('\n')
        |> Seq.skip 1
        |> Seq.map (fun row -> row.Split(','))
        |> Seq.map (fun columns ->
            { Entry.Rank =
                columns.[0] |> Int32.Parse
              Entry.Word =
                columns.[1]
              Entry.PartOfSpeech =
                columns.[2]
              Entry.Definitions =
                columns.[3].Split(';') |> Set.ofArray })
        |> Seq.toList

    let byWord =
        entries
        |> Seq.map (fun x -> x.Word, x)
        |> Map.ofSeq

    let words =
        entries
        |> Seq.map (fun x -> x.Word)
        |> Seq.toList

    let randomizeWords =
        words
        |> Seq.sortBy (fun _ -> Guid.NewGuid().ToString("n"))

    let definitionsFor word =
        byWord.[word].Definitions

    let partOfSpeechFor word =
        byWord.[word].PartOfSpeech

    let rankFor word =
        byWord.[word].Rank
