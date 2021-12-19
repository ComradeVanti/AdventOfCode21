module AdventOfCode21.Chiton1.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing
open AdventOfCode21.Chiton1.Navigation

let tryParseInput lines : DangerMap option =

    let tryParseCell c = c |> string |> tryParseInt

    let tryParseRow s = s |> Seq.map tryParseCell |> Option.collect

    lines
    |> List.map tryParseRow
    |> Option.collect
    |> Option.bind Grid.tryMake
