module AdventOfCode21.SyntaxScoring1.Parsing

open AdventOfCode21
open AdventOfCode21.SyntaxScoring1.Nav

let tryParseInput lines =

    let tryParseDel c =
        match c with
        | '(' -> Some(Del(Round, Open))
        | ')' -> Some(Del(Round, Close))
        | '[' -> Some(Del(Square, Open))
        | ']' -> Some(Del(Square, Close))
        | '{' -> Some(Del(Curly, Open))
        | '}' -> Some(Del(Curly, Close))
        | '<' -> Some(Del(Angle, Open))
        | '>' -> Some(Del(Angle, Close))
        | _ -> None

    let tryParseLine line =
        line
        |> Seq.map tryParseDel
        |> Option.collect
        |> Option.map Dels

    lines |> List.map tryParseLine |> Option.collect
