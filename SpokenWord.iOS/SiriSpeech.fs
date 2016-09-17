namespace SpokenWord

open AVFoundation

type SiriSpeech() = 

    let synthesizer = new AVSpeechSynthesizer()

    let inRussian(text:string) =
        new AVSpeechUtterance(text,
            Rate=AVSpeechUtterance.MaximumSpeechRate / 4.0f,
            Voice=AVSpeechSynthesisVoice.FromLanguage("ru-RU"),
            PreUtteranceDelay=0.,
            PostUtteranceDelay=0.,
            PitchMultiplier=float32 1.,
            Volume=float32 0.9)

    let inEnglish(text:string) =
        new AVSpeechUtterance(text,
            Rate=AVSpeechUtterance.MaximumSpeechRate / 2.0f,
            Voice=AVSpeechSynthesisVoice.FromLanguage("en-AU"),
            PreUtteranceDelay=0.,
            PostUtteranceDelay=0.,
            PitchMultiplier=float32 1.,
            Volume=float32 1.)
        

    interface Speech with

        member x.SayInForeign(word) =
            synthesizer.SpeakUtterance(inRussian(" "))
            synthesizer.SpeakUtterance(inRussian(word))

        member x.SayInNative(word) =
            synthesizer.SpeakUtterance(inEnglish(" "))
            synthesizer.SpeakUtterance(inEnglish(word))