namespace SpokenWord

type Speech =

    abstract member SayInForeign: word:string -> unit
    abstract member SayInNative: word:string -> unit