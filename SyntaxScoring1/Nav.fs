module AdventOfCode21.SyntaxScoring1.Nav

type ChunkType =
    | Round
    | Square
    | Curly
    | Angle

type DelDir =
    | Open
    | Close

type Del = Del of ChunkType * DelDir

type NavLine = Dels of Del list

let delType (Del (t, _)) = t

let delDir (Del (_, d)) = d
