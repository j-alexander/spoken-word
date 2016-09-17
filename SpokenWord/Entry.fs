namespace SpokenWord

type Entry =
  { Rank : int
    Word : string
    PartOfSpeech : string
    Definitions : Set<string> }